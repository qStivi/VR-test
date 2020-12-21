using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR.InteractionSystem;

public class Walking : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    private Vector2 inputAxis;
    public CharacterController character;

    private void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(inputSource); // Get selected device
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis); // Listen to input
    }

    private void FixedUpdate()
    {
        var direction = new Vector3(inputAxis.x, inputAxis.y); // calculate direction

        character.Move(direction * (Time.fixedDeltaTime * speed)); // Move character
    }
}
