using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRCamera : MonoBehaviour
{
    void Update() {
        transform.position = XRInput.leftHand.Position();
        transform.rotation = XRInput.leftHand.Rotation();
    }
}
