using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public delegate void TongueTetherEvent(bool bIsTethered);

public delegate void TongueActiveEvent(bool bIsActive);

public class TongueComponent : MonoBehaviour
{
    [Header("Tongue initial configuration")]
    [Tooltip("At what offset from Wendy's center the tongue spawns")]
    [SerializeField] 
    private Vector2 tongueOffset;
    
    [Tooltip("The sprite renderer for the base of the tongue")]
    [SerializeField]
    private SpriteRenderer tongueBaseSpriteRenderer;
    
    [Header("Tongue Push Properties")]
    [FormerlySerializedAs("maxTongueRange")]
    [Tooltip("The range at which the tongue starts dragging back")]
    [SerializeField] 
    private float tongueDecelerationRange;
    
    [Tooltip("The maximum speed the tongue can reach")] 
    [SerializeField]
    private float initialTongueSpeed;

    [Tooltip("The force at which the tongue starts decelerating.")]
    [SerializeField]
    private float tongueDeceleration;

    [Header("Tongue Tether Properties")] 
    [Tooltip("What force the tongue applies as a pull every frame")]
    [SerializeField]
    private float tongueTetherPullForce;
    
    [Tooltip("At what range the tongue drops the tether")]
    [SerializeField]
    private float tongueTetherDropRange;

    private Transform tongueParent;
    private SpriteRenderer tongueSpriteRenderer;
    private Collider2D tongueCollider;
    private Rigidbody2D boundBody;
    
    private Vector2 minimumSpriteDimensions = new Vector2(0.5f, 0.5f);
    private float currentTongueSpeed = 0.0f;
    private float currentTongueRange;

    /*
    private bool bIsPushing = false;
    private bool bIsActive = false;
    private bool bTethered = false;
    */

    private TongueState tongueState;

    public event TongueTetherEvent OnTongueTetherChanged;
    public event TongueActiveEvent OnTongueActiveChanged;

    private void Awake()
    {
        tongueParent = transform.parent;
        tongueSpriteRenderer = GetComponent<SpriteRenderer>();
        if (!tongueSpriteRenderer) Debug.LogError("TongueComponent - No Sprite Renderer found");
        if (!tongueBaseSpriteRenderer) Debug.LogError("TongueComponent - No Sprite Renderer for tongue base found");
        
        tongueCollider = GetComponent<Collider2D>();
        if (!tongueCollider) Debug.LogError("TongueComponent - No Collider found for the tongue");
    }

    private void Start()
    {
        // Hide the tongue on game start
        DeactivateTongue();
    }

    private void Update()
    {
        switch (tongueState)
        {
            case TongueState.Pushing:
            {
                currentTongueRange = Vector3.Distance(transform.position, tongueBaseSpriteRenderer.transform.position);
                if (currentTongueRange >= tongueDecelerationRange)
                {
                    PullTongue();
                }

                transform.localPosition += transform.right * (currentTongueSpeed * Time.deltaTime);
                
                UpdateTongueStretch();
                break;
            }

            case TongueState.Pulling:
            {
                currentTongueRange = Vector3.Distance(transform.position, tongueBaseSpriteRenderer.transform.position);

                currentTongueSpeed = Mathf.Max(-initialTongueSpeed, currentTongueSpeed - (tongueDeceleration * Time.deltaTime));
                if (currentTongueRange <= minimumSpriteDimensions.x / 2)
                {
                    DeactivateTongue();
                }

                transform.localPosition += transform.right * (currentTongueSpeed * Time.deltaTime);
                
                UpdateTongueStretch();
                break;
            }

            case TongueState.Tethered:
                currentTongueRange = Vector3.Distance(transform.position, tongueBaseSpriteRenderer.transform.position);
                
                if (currentTongueRange <= tongueTetherDropRange)
                {
                    DeactivateTongue();
                    OnTongueTetherChanged(false);
                }
                else
                {
                    UpdateTongueTether();
                }
                break;
            
            case TongueState.Hidden:
                break;
            default:
                break;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // We hit terrain! Tether!
        boundBody.velocity = Vector2.zero;
        boundBody.gravityScale = 1;
        TetherTongue();
    }

    public void PushTongue(Vector2 pushDirection)
    {
        // Show tongue
        ActivateTongue();

        transform.right = pushDirection;

        transform.localPosition = tongueOffset;
        currentTongueSpeed = initialTongueSpeed;
        tongueState = TongueState.Pushing;
    }

    public void PullTongue()
    {
        if (tongueState == TongueState.Pushing)
        {
            tongueState = TongueState.Pulling;
        }
    }

    public void TetherTongue()
    {
        transform.parent = null;
        tongueState = TongueState.Tethered;
        currentTongueSpeed = 0.0f;

        OnTongueTetherChanged(true);
    }

    public void ActivateTongue()
    {
        transform.parent = tongueParent;
        tongueSpriteRenderer.enabled = true;
        tongueBaseSpriteRenderer.enabled = true;
        tongueCollider.enabled = true;

        OnTongueActiveChanged(true);
    }

    public void DeactivateTongue()
    {
        tongueState = TongueState.Hidden;
        boundBody.gravityScale = 3;
        
        // Reinitialize physics variables
        currentTongueRange = 0.0f;
        currentTongueSpeed = 0.0f;
        
        // Hide tongue
        tongueSpriteRenderer.enabled = false;
        tongueBaseSpriteRenderer.enabled = false;
        tongueCollider.enabled = false;

        OnTongueActiveChanged(false);
    }

    public void BindTongueToBody(Rigidbody2D bodyToBind)
    {
        boundBody = bodyToBind;
    }

    private void UpdateTongueStretch()
    {
        if (tongueState != TongueState.Hidden)
        {
            if (tongueBaseSpriteRenderer)
            {
                tongueBaseSpriteRenderer.size = new Vector2(
                    Mathf.Max(currentTongueRange - tongueSpriteRenderer.size.x/2, minimumSpriteDimensions.x),
                    tongueBaseSpriteRenderer.size.y
                );
            }
        }
    }

    private void UpdateTongueTether()
    {
        Vector2 tongueOrigin = tongueCollider.bounds.center;
        Vector2 forceDirection = tongueOrigin - boundBody.position;
        
        boundBody.AddForce(forceDirection.normalized * tongueTetherPullForce * Time.deltaTime);
        
        // Calculate the tongue range so the collider stays at the same spot
        currentTongueRange = Vector2.Distance(tongueOrigin, boundBody.position);
        
        UpdateTongueStretch();
    }
}

internal enum TongueState
{
    Pushing,
    Pulling,
    Tethered,
    Hidden
}
