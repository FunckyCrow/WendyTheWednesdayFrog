using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private Collider2D m_Collider;
    private Collider2D m_GroundTrigger;
    private Animator m_Animator;
    private ParticleSystem m_ParticleSystem;

    [Header("Physics")]
    [SerializeField] LayerMask m_GeometryLayerMask;
    
    [Header("Jump Config")]
    [SerializeField] private Vector2 m_JumpDirection;
    [SerializeField] private float m_MinJumpPowerCharge;
    [SerializeField] private float m_MaxJumpPowerCharge;
    [SerializeField] private float m_JumpPowerChargeRate;
    private float m_JumpPowerCharge;
    
    private State m_CurrentState;
    private TongueState m_CurrentTongueState;
    
    private bool m_IsJumpButtonPressed = false;
    private bool m_IsTongueButtonPressed;
    private bool m_IsGrounded;

    private string m_currentAnimName;

    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider2D>();

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
        m_ParticleSystem = GetComponentInChildren<ParticleSystem>();

        m_CurrentState = State.Idle;
        m_currentAnimName = "Idle";
        
        m_CurrentTongueState = TongueState.Idle;
        m_Animator.SetBool("Idle", true);
    }

    private void FixedUpdate()
    {
        m_IsGrounded = IsGrounded();
    }
    
    private void Update()
    {
        switch (m_CurrentState)
        {
            case State.Idle:
                if (!m_IsGrounded)
                {
                    // Idle and not grounded means we slid off or something
                    SetCurrentState(State.Jumping, "Jumping");
                }
                break;
            
            case State.Charging:
                ChargeJumpPower();
                break;
            
            case State.Jumping:
                if (m_IsGrounded)
                {
                    Debug.Log("Found grounded!");
                    SetCurrentState(State.Idle, "Idle");
                    
                    // Make tongue disappear
                    
                    m_ParticleSystem.Play();
                }
                break;

            case State.Grabbing:
                break;
        }

        switch (m_CurrentTongueState)
        {
            case TongueState.Idle:
                //Debug.Log("Tongue Idle");
                m_Animator.SetBool("Grabing", false);
                break;
            case TongueState.Extending:
                //Debug.Log("Tongue Extending");
                m_Animator.SetBool("Grabing", true);
                break;
            case TongueState.Retracting:
                //Debug.Log("Tongue Retracting");
                break;
            case TongueState.Grabbing:
                //Debug.Log("Tongue Grabing");
                break;
        }
    }

    private void ChargeJumpPower()
    {
        m_JumpPowerCharge += m_JumpPowerChargeRate*Time.deltaTime;
        m_JumpPowerCharge = Mathf.Clamp(m_JumpPowerCharge, 0, m_MaxJumpPowerCharge);
    }

    public void SetJumpState(bool bIsJumping)
    {
        if (m_CurrentState == State.Idle && bIsJumping)
        {
            SetCurrentState(State.Charging, "Charging");

            m_JumpPowerCharge = m_MinJumpPowerCharge;
        }
        else if (m_CurrentState == State.Charging && !bIsJumping)
        {
            SetCurrentState(State.Jumping, "Jumping");

            Vector2 JumpVector = m_JumpDirection;
            JumpVector.Normalize();
            JumpVector *= m_JumpPowerCharge;
            
            m_Rigidbody.AddForce(JumpVector, ForceMode2D.Impulse);
            
            m_JumpPowerCharge = 0;
            m_IsGrounded = false;
        }

        m_IsJumpButtonPressed = bIsJumping;
    }
    
    public void SetTongueState(bool bIsTonguing)
    {
        if (m_CurrentState == State.Jumping)
        {
            if (bIsTonguing)
            {
                Debug.Log("Push tongue!");
            }

            if (!bIsTonguing)
            {
                Debug.Log("Pull tongue!");
            }
        }
    }
    
    public void SetInputDirection(Vector2 Direction)
    {
    }
    public void SetCursorPosition(Vector2 Position)
    {
        // Called when a pointer sets a position
        // Can currently be triggered by moving the left mouse or by touching the screen
    }

    private bool IsGrounded()
    {
        var Ray = Physics2D.BoxCast(m_Collider.bounds.center, m_Collider.bounds.size, 0f, Vector2.down,0.1f, m_GeometryLayerMask);
        bool isGrounded = Ray != null && Ray.collider != null && Ray.collider != m_Collider && m_Rigidbody.velocity.y <= 0;

        return isGrounded;
    }

    private void SetCurrentState(State newState, string animationName)
    {
        m_Animator.SetBool(m_currentAnimName, false);
        m_Animator.SetBool(animationName, true);

        m_CurrentState = newState;
        m_currentAnimName = animationName;
    }

    enum State
    {
        Idle,
        Charging,
        Jumping,
        Grabbing
    }
    enum TongueState
    {
        Idle,
        Extending,
        Retracting,
        Grabbing
    }
}
