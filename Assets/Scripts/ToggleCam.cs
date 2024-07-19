using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCam : MonoBehaviour {
    public Camera FirstPersonCamera;
    public Camera ThirdPersonCamera;

    private void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            ShowThirdPersonView();
        }
        if(Input.GetKey(KeyCode.F))
        {
            ShowFirstPersonView();
        }
    }
    
    // Call this function to disable FPS camera
    // and enable overhead camera.
    public void ShowThirdPersonView() {
        FirstPersonCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
    }
    
    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView() {
        FirstPersonCamera.enabled = true;
        ThirdPersonCamera.enabled = false;
    }
}