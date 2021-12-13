using System;
using System.Collections;
using System.Collections.Generic;
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
    private float maxTongueSpeed;
    
    [Tooltip("What value the tongue adds to its speed every update. Also works for pull/retracting the tongue")]
    [SerializeField] 
    private float tongueAcceleration;
    
    [Tooltip("At what range the tongue stops accelerating and starts decelerating instead.")]
    [SerializeField]
    private float tongueAccelerationThreshold;

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
        if (!tongueCollider) Debug.LogError("TongueComponent - No Sprite Renderer found");
        
        // Hide the tongue on game start
        DeactivateTongue();

        PushTongue();
    }

    private void Update()
    {
        if (bIsActive)
        {
            if (bIsPushing)
            {
                // Add acceleration
                if (currentTongueRange < tongueAccelerationThreshold)
                {
                    currentTongueSpeed = Mathf.Max(maxTongueSpeed, currentTongueSpeed + tongueAcceleration);
                }

                // Calculate tongue range with clamping
                currentTongueRange += Mathf.Max(maxTongueRange, currentTongueRange + currentTongueSpeed);

                // If fully extended, switch to pulling
                if (currentTongueRange >= maxTongueRange)
                {
                    currentTongueSpeed = 0.0f;
                    bIsPushing = false;
                }
            }
            
            // Is pulling
            else
            {
                // Decelerate the tongue
                currentTongueSpeed = Mathf.Max(maxTongueSpeed, currentTongueSpeed + tongueAcceleration);
                
                currentTongueRange = Mathf.Max(0.0f, currentTongueRange - currentTongueSpeed);

                if (currentTongueRange < minimumSpriteDimensions.x)
                {
                    
                }
            }
            
            UpdateTongueStretch();
        }
    }

    public void PushTongue()
    {
        // Show tongue
        tongueSpriteRenderer.enabled = false;
        tongueCollider.enabled = false;
        
        bIsPushing = true;
    }

    public void PullTongue()
    {
        bIsPushing = false;
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
        if (tongueSpriteRenderer)
        {
            tongueSpriteRenderer.size = new Vector2(
                Mathf.Max(currentTongueRange, minimumSpriteDimensions.x),
                tongueSpriteRenderer.size.y
            );
        }
    }

}
