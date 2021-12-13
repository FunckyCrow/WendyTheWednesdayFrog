using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject m_Wendy;
    [SerializeField] private Vector3 m_Offset;
    void Update()
    {
        transform.position = new Vector3(m_Wendy.transform.position.x, 0, 0) + m_Offset;
    }
}
