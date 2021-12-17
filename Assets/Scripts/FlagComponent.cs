using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagComponent : MonoBehaviour
{
    [SerializeField] private string NextLevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(NextLevelName);
    }
}
