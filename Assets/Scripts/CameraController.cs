using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject Wendy;
    [SerializeField] private Vector3 TrackingOffset;
    [SerializeField] private Vector2 MinCameraBounds;
    [SerializeField] private Vector2 MaxCameraBounds;
    
    void Update()
    {
        Vector3 newPos = new Vector3(
            Mathf.Clamp(Wendy.transform.position.x, MinCameraBounds.x, MaxCameraBounds.x),
            Mathf.Clamp(Wendy.transform.position.y, MinCameraBounds.y, MaxCameraBounds.y),
            -10
        );

        newPos = newPos + TrackingOffset;
        transform.position = Vector3.Lerp(transform.position, newPos, 0.0085f);
    }
}
