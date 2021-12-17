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
    private TongueComponent m_tongueComp;

    [Header("Physics")] 
    [SerializeField] LayerMask m_GeometryLayerMask;

    [Header("Visuals")] 
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private Transform m_TongueBase;
    [SerializeField] private GameObject m_deathVfx;

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

    private Vector2 inputDirection;
    private Vector2 cursorPosition;

    private void Awake()
    {
        m_tongueComp = GetComponentInChildren<TongueComponent>();
        m_Collider = GetComponent<BoxCollider2D>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        
        m_Animator = GetComponentInChildren<Animator>();
        m_ParticleSystem = GetComponentInChildren<ParticleSystem>();
        
        if (m_tongueComp && m_Rigidbody) m_tongueComp.BindTongueToBody(m_Rigidbody);
        
        m_CurrentState = State.Idle;
        m_currentAnimName = "Idle";
        
        m_CurrentTongueState = TongueState.Idle;
        m_Animator.SetBool("Idle", true);
    }

    private void OnEnable()
    {
        m_tongueComp.OnTongueTetherChanged += OnTongueTetherChanged;
        m_tongueComp.OnTongueActiveChanged += OnTongueActivechanged;
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
                    SetCurrentState(State.Idle, "Idle");
                    
                    m_ParticleSystem.Play();
                }
                break;

            case State.Grabbing:
                if (m_IsGrounded)
                {
                    m_SpriteRenderer.transform.right = Vector3.right;
                    m_tongueComp.DeactivateTongue();
                    SetCurrentState(State.Idle, "Idle");
                    
                    m_ParticleSystem.Play();
                }
                else
                {
                    m_SpriteRenderer.transform.right = m_tongueComp.transform.position - m_TongueBase.position;
                }
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
                SetCurrentState(State.Grabbing, "Grabbing");
                Vector2 pushDirection = Vector2.right;
                
                if (cursorPosition != Vector2.zero)
                {
                    Debug.Log("Using cursor!");
                    pushDirection = Camera.main.ScreenToWorldPoint(cursorPosition) - transform.position;
                }
                else if(inputDirection != Vector2.zero)
                {
                    Debug.Log("Using controller!");
                    pushDirection = inputDirection;
                }

                Debug.Log(pushDirection);
                m_tongueComp.PushTongue(pushDirection);
            }

            if (!bIsTonguing)
            {
                m_tongueComp.PullTongue();
            }
        }

        else if (m_CurrentState == State.Grabbing && bIsTonguing)
        {
            m_tongueComp.DeactivateTongue();
        }
    }

    public void Die()
    {
        Instantiate(m_deathVfx, transform.position, m_deathVfx.transform.rotation);

        m_tongueComp.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void SetInputDirection(Vector2 Direction)
    {
        inputDirection = Direction;
    }
    public void SetCursorPosition(Vector2 Position)
    {
        cursorPosition = Position;
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
    
    private void OnTongueTetherChanged(bool bIsTethered)
    {
        if (!bIsTethered && m_CurrentState == State.Grabbing)
        {
            m_SpriteRenderer.transform.right = Vector3.right;
            SetCurrentState(State.Jumping, "Jumping");
        }
    }

    private void OnTongueActivechanged(bool bIsActive)
    {
        if (!bIsActive && m_CurrentState == State.Grabbing)
        {
            m_SpriteRenderer.transform.right = Vector3.right;
            SetCurrentState(State.Jumping, "Jumping");
        }
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
