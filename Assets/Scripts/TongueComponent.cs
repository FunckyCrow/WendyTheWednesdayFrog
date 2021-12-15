using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class TongueComponent : MonoBehaviour
{
    [Header("Tongue initial configuration")]
    [Tooltip("At what offset from Wendy's center the tongue spawns")]
    [SerializeField] 
    private Vector2 tongueOffset;
    
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

    private SpriteRenderer tongueSpriteRenderer;
    private Collider2D tongueCollider;
    private Rigidbody2D boundBody;
    
    private Vector2 minimumSpriteDimensions = new Vector2(0.5f, 0.5f);
    private float currentTongueRange = 0.0f;
    private float currentTongueSpeed = 0.0f;

    /*
    private bool bIsPushing = false;
    private bool bIsActive = false;
    private bool bTethered = false;
    */

    private TongueState tongueState;

    public Action TongueTethered;

    private void Awake()
    {
        tongueSpriteRenderer = GetComponent<SpriteRenderer>();
        if (!tongueSpriteRenderer) Debug.LogError("TongueComponent - No Sprite Renderer found");
        
        tongueCollider = GetComponent<Collider2D>();
        if (!tongueCollider) Debug.LogError("TongueComponent - No Collider found for the tongue");
    }

    private void Start()
    {
        // Hide the tongue on game start
        //DeactivateTongue();

        PushTongue();
    }

    private void Update()
    {
        switch (tongueState)
        {
            case TongueState.Pushing:
            {
                if (currentTongueRange >= tongueDecelerationRange)
                {
                    PullTongue();
                }

                currentTongueRange += (currentTongueSpeed * Time.deltaTime);
                UpdateTongueStretch();
                break;
            }

            case TongueState.Pulling:
            {
                currentTongueSpeed = Mathf.Max(-initialTongueSpeed, currentTongueSpeed - (tongueDeceleration * Time.deltaTime));
                if (currentTongueRange <= minimumSpriteDimensions.x / 2)
                {
                    DeactivateTongue();
                }

                currentTongueRange += (currentTongueSpeed * Time.deltaTime);
                UpdateTongueStretch();
                break;
            }

            case TongueState.Tethered:
                if (currentTongueRange <= tongueTetherDropRange)
                {
                    tongueState = TongueState.Hidden;
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

    private void OnTriggerEnter(Collider otherCollider)
    {
        // We hit terrain! Switch to pull mode!
        tongueState = TongueState.Tethered;
        currentTongueSpeed = 0.0f;
    }

    public void PushTongue()
    {
        // Show tongue
        ActivateTongue();
        
        currentTongueSpeed = initialTongueSpeed;
        tongueState = TongueState.Pushing;
    }

    public void PullTongue()
    {
        tongueState = TongueState.Pulling;
    }

    public void ActivateTongue()
    {
        tongueSpriteRenderer.enabled = true;
        tongueCollider.enabled = true;
    }

    public void DeactivateTongue()
    {
        tongueState = TongueState.Hidden;
        
        // Reinitialize physics variables
        currentTongueRange = 0.0f;
        currentTongueSpeed = 0.0f;
        
        // Hide tongue
        tongueSpriteRenderer.enabled = false;
        tongueCollider.enabled = false;
    }

    public void BindTongueToBody(Rigidbody2D bodyToBind)
    {
        boundBody = bodyToBind;
    }

    private void UpdateTongueStretch()
    {
        if (tongueState != TongueState.Hidden)
        {
            if (tongueSpriteRenderer)
            {
                tongueSpriteRenderer.size = new Vector2(
                    Mathf.Max(currentTongueRange, minimumSpriteDimensions.x),
                    tongueSpriteRenderer.size.y
                );
            }

            if (tongueCollider)
            {
                tongueCollider.offset = new Vector2(
                    tongueSpriteRenderer.size.x - minimumSpriteDimensions.x/2,
                    tongueCollider.offset.y
                );
            }
        }
    }

    private void UpdateTongueTether()
    {
        Vector2 tongueOrigin = tongueCollider.bounds.center;
        Vector2 forceDirection = boundBody.position - tongueOrigin;
        
        boundBody.AddForce(forceDirection.normalized * tongueTetherPullForce * Time.deltaTime);
        
        // Calculate the tongue range so the collider stays at the same spot
        currentTongueRange = Vector2.Distance(tongueOrigin, boundBody.position + tongueOffset);
        
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
