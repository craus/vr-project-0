using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRNodeFollow : MonoBehaviour
{
    public XRNode node;

    void Update() {
        transform.position = XRInput.node(node).Position();
        transform.rotation = XRInput.node(node).Rotation();
    }
}
