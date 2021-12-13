using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private State m_CurrentState;
    private TongueState m_CurrentTongueState;

    [SerializeField] private Vector2 m_JumpDirection;
    [SerializeField] private float m_MaxJumpPowerCharge;
    [SerializeField] private float m_JumpPowerChargeRate;
    private float m_JumpPowerCharge;
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (m_CurrentState)
        {
            case State.Idle:
                if (Pressed())
                {
                    m_CurrentState = State.Charging;
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
                break;
            case State.Grabbing:
                break;
        }

        switch (m_CurrentTongueState)
        {
            case TongueState.Idle:
                break;
            case TongueState.Extending:
                break;
            case TongueState.Retracting:
                break;
            case TongueState.Grabbing:
                break;
        }
    }

    void ChargeJumpPower()
    {
        m_JumpPowerCharge += m_JumpPowerChargeRate*Time.deltaTime;
        m_JumpPowerCharge = Mathf.Clamp(m_JumpPowerCharge, 0, m_MaxJumpPowerCharge);
    }

    bool Pressed()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began) return true;
        else return false;
    }
    bool Pressing()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) return true;
        else return false;
    }
    bool Released()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended) return true;
        else return false;
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
