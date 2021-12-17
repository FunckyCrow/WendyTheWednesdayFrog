using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagComponent : MonoBehaviour
{
    [SerializeField] private string NextLevelName;

    private Animator animator;
    private float nextLevelWaitTime = 3.0f;
    private bool bIsLevelComplete;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animator.StopPlayback();
        animator.enabled = false;
    }

    private void Update()
    {
        if (bIsLevelComplete) nextLevelWaitTime -= Time.deltaTime;
        if (nextLevelWaitTime <= 0f) SceneManager.LoadScene(NextLevelName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.enabled = true;
        animator.Play("LevelComplete");

        bIsLevelComplete = true;
    }
}
