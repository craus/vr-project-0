using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRNodeFollow : MonoBehaviour
{
    public XRNode node;

    public bool local = true;

    void Update() {
        if (local) {
            transform.localPosition = XRInput.node(node).Position() ?? transform.localPosition;
            transform.localRotation = XRInput.node(node).Rotation() ?? transform.localRotation;
        } else {
            transform.position = XRInput.node(node).Position() ?? transform.position;
            transform.rotation = XRInput.node(node).Rotation() ?? transform.rotation;
        }
    }
}
