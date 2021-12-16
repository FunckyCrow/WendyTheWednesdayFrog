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
        var Coliders = GetComponents<BoxCollider2D>();
        if (Coliders[1].isTrigger)
        {
            m_Collider = Coliders[0];
            m_GroundTrigger = Coliders[1];
        }
        else
        {
            m_Collider = Coliders[1];
            m_GroundTrigger = Coliders[0];
        }

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
        m_ParticleSystem = GetComponentInChildren<ParticleSystem>();

        m_CurrentState = State.Idle;
        m_CurrentTongueState = TongueState.Idle;
        m_Animator.SetBool("Idle", true);
    }

    private void FixedUpdate()
    {
        m_IsGrounded = IsGrounded();
    }

    // private void OnTriggerEnter2D(Collider other)
    // {
    //     if (m_Rigidbody.velocity.y <= 0)
    //     {
    //         m_IsGrounded = true;
    //     }
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        List<Collider2D> Colliders = new List<Collider2D>();
        m_GroundTrigger.GetContacts(Colliders);
        if (Colliders.Count > 0)
        {
            m_IsGrounded = true;
        }
        else
        {
            m_IsGrounded = false;
        }
    }

    private void Update()
    {
        switch (m_CurrentState)
        {
            case State.Idle:
                if (!m_IsGrounded)
                {
                    m_CurrentState = State.Jumping;
                }
                else if (Pressed())
                {
                    m_CurrentState = State.Charging;
                    m_Animator.SetBool("Idle", false);
                    m_Animator.SetBool("Charging", true);
                    
                    m_JumpPowerCharge = m_MinJumpPowerCharge;
                }
                break;
            
            case State.Charging:
                if (Pressing())
                {
                    ChargeJumpPower();
                }
                else
                {
                    m_CurrentState = State.Jumping;
                    m_Animator.SetBool("Jumping", true);
                    m_Animator.SetBool("Charging", false);
                    
                    Vector2 JumpVector = m_JumpDirection;
                    JumpVector.Normalize();
                    JumpVector *= m_JumpPowerCharge;
                    m_JumpPowerCharge = 0;
                    m_Rigidbody.AddForce(JumpVector, ForceMode2D.Impulse);
                    m_IsGrounded = false;
                }
                
                break;
            
            case State.Jumping:
                if (Pressed())
                {
                    m_CurrentTongueState = TongueState.Extending;
                    m_Animator.SetBool("Grabing", true);
                }
                else if (!Pressing() && m_CurrentTongueState == TongueState.Extending)
                {
                    m_Animator.SetBool("Grabing", false);
                    m_CurrentTongueState = TongueState.Retracting;
                }

                if (m_IsGrounded)
                {
                    m_CurrentState = State.Idle;
                    m_Animator.SetBool("Idle", true);
                    m_Animator.SetBool("Jumping", false);
                    
                    m_CurrentTongueState = TongueState.Retracting;
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
            
        }
        m_IsJumpButtonPressed = bIsJumping;
    }
    public void SetTongueState(bool bIsTonguing)
    {
        m_IsTongueButtonPressed = bIsTonguing;
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
        var Ray = Physics2D.BoxCast(m_Collider.bounds.center, m_Collider.bounds.size, 0f, Vector2.down,0.05f, m_GeometryLayerMask);
        bool isGrounded = Ray != null && Ray.collider != null && Ray.collider != m_Collider && m_Rigidbody.velocity.y <= 0;

        return isGrounded;
    }

    private void SetCurrentState(State newState, string animationName)
    {
        
    }

    bool Pressed()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) return true;
        else return false;
#else
        if (Input.GetTouch(0).phase == TouchPhase.Began) return true;
        else return false;
#endif
    }
    bool Pressing()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0)) return true;
        else return false;
#else
        if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) return true;
        else return false;
#endif
    }
    bool Released()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0)) return true;
        else return false;
#else
        if (Input.GetTouch(0).phase == TouchPhase.Ended) return true;
        else return false;
#endif
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
