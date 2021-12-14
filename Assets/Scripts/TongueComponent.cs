using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TongueComponent : MonoBehaviour
{
    [Tooltip("At what offset from Wendy's center the tongue spawns")]
    [SerializeField] 
    private Vector2 tongueOffset;
    
    [Tooltip("The maximum range the tongue can reach")]
    [SerializeField] 
    private float maxTongueRange;
    
    [Tooltip("The maximum speed the tongue can reach")] 
    [SerializeField]
    private float initialTongueSpeed;

    [Tooltip("The force at which the tongue starts decelerating.")]
    [SerializeField]
    private float tongueDeceleration;

    private SpriteRenderer tongueSpriteRenderer;
    private Collider2D tongueCollider;
    
    private Vector2 minimumSpriteDimensions = new Vector2(0.5f, 0.5f);
    private float currentTongueRange = 0.0f;
    private float currentTongueSpeed = 0.0f;

    private bool bIsPushing = false;
    private bool bIsActive = false;

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
        if (bIsActive)
        {
            if (bIsPushing)
            {
                Debug.Log("We push!");
                if (currentTongueRange >= maxTongueRange)
                {
                    Debug.Log("Switch to Pull Tongue!");
                    PullTongue();
                }
            }
            else
            {
                Debug.Log("We pull!");
                currentTongueSpeed = Mathf.Max(-initialTongueSpeed, currentTongueSpeed - (tongueDeceleration * Time.deltaTime));

                if (currentTongueRange <= minimumSpriteDimensions.x / 2)
                {
                    Debug.Log("We Deactivate the Tongue!");
                    DeactivateTongue();   
                }
            }
            
            currentTongueRange += (currentTongueSpeed * Time.deltaTime);
            UpdateTongueStretch();
        }
    }

    public void PushTongue()
    {
        // Show tongue
        ActivateTongue();
        
        currentTongueSpeed = initialTongueSpeed;
        bIsPushing = true;
    }

    public void PullTongue()
    {
        bIsPushing = false;
    }

    public void ActivateTongue()
    {
        bIsActive = true;
        
        tongueSpriteRenderer.enabled = true;
        tongueCollider.enabled = true;
    }

    public void DeactivateTongue()
    {
        bIsActive = false;
        
        // Reinitialize physics variables
        currentTongueRange = 0.0f;
        currentTongueSpeed = 0.0f;
        
        // Hide tongue
        tongueSpriteRenderer.enabled = false;
        tongueCollider.enabled = false;
    }

    private void UpdateTongueStretch()
    {
        if (bIsActive)
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

}
