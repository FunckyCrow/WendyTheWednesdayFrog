using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class KillZone : MonoBehaviour
{
    private float deathWaitTime = 3.0f;
    private bool bIsFrogDead; // God is, that I know

    private void Update()
    {
        if (bIsFrogDead) deathWaitTime -= Time.deltaTime;
        if (deathWaitTime <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController wendy = other.gameObject.GetComponent<CharacterController>();
        if (wendy) wendy.Die();
        
        bIsFrogDead = true;
    }
}
