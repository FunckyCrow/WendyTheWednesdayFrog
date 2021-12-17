using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private string NextLevelName;
    
    InputAction myAction = new InputAction(binding: "/*/<button>");
    private void Awake()
    {
        myAction.performed += OnInputPressed;
        myAction.Enable();
    }

    private void OnInputPressed(InputAction.CallbackContext obj)
    {
        myAction.Disable();
        SceneManager.LoadScene(NextLevelName);
    }
}
