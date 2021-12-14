using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Vector2 m_JumpDirection;
    [SerializeField] private float m_MinJumpPowerCharge;
    [SerializeField] private float m_MaxJumpPowerCharge;
    [SerializeField] private float m_JumpPowerChargeRate;
    private float m_JumpPowerCharge;
    
    private Rigidbody2D m_Rigidbody;
    private Collider2D m_Collider;
    private State m_CurrentState;
    private TongueState m_CurrentTongueState;
    private bool m_IsGrounded;
    
    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_CurrentState = State.Idle;
        m_CurrentTongueState = TongueState.Idle;
    }

    private void FixedUpdate()
    {
        var Ray = Physics2D.Raycast(transform.position, Vector2.down, 0.01f);
        m_IsGrounded = Ray != null && Ray.collider != null;
    }

    private void Update()
    {
        switch (m_CurrentState)
        {
            case State.Idle:
                if (Pressed())
                {
                    m_CurrentState = State.Charging;
                    m_JumpPowerCharge = m_MinJumpPowerCharge;
                }
                break;
            case State.Charging:
                if (Pressing())
                {
                    ChargeJumpPower();
                }
                else if (Released())
                {
                    Vector2 JumpVector = m_JumpDirection;
                    JumpVector.Normalize();
                    JumpVector *= m_JumpPowerCharge;
                    m_JumpPowerCharge = 0;
                    m_Rigidbody.AddForce(JumpVector, ForceMode2D.Impulse);
                    Debug.Log(JumpVector);
                    m_CurrentState = State.Jumping;
                }
                break;
            case State.Jumping:
                if (Pressed())
                {
                    m_CurrentTongueState = TongueState.Extending;
                }
                else if (Pressing())
                {
                    
                }
                else if (Released())
                {
                    m_CurrentTongueState = TongueState.Retracting;
                }

                if (m_IsGrounded)
                {
                    m_CurrentState = State.Idle;
                    m_CurrentTongueState = TongueState.Retracting;
                }
                
                break;
            case State.Grabbing:
                Debug.Log("Grabing");
                break;
        }

        switch (m_CurrentTongueState)
        {
            case TongueState.Idle:
                Debug.Log("Tongue Idle");
                break;
            case TongueState.Extending:
                Debug.Log("Tongue Extending");
                break;
            case TongueState.Retracting:
                Debug.Log("Tongue Retracting");
                break;
            case TongueState.Grabbing:
                Debug.Log("Tongue Grabing");
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
        // Called when a jump input is pressed or released (bIsJumping)
        // Can currently be triggered from any gamepad button, left clicking and touching the screen
    }

    public void SetTongueState(bool bIsTonguing)
    {
        // Called when a tongue input is pressed or released (bIsJumping)
        // Can currently be triggered from any gamepad button, left clicking and touching the screen
    }

    public void SetInputDirection(Vector2 Direction)
    {
        // Called when a direction is input
        // Can currently be triggered from the gamepad's left stick and D-pad
    }

    public void SetCursorPosition(Vector2 Position)
    {
        // Called when a pointer sets a position
        // Can currently be triggered by moving the left mouse or by touching the screen
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
