using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveSpace : MonoBehaviour
{
    public KeyCode leftGrip;
    public KeyCode rightGrip;
    public Transform leftGripper;
    public Transform rightGripper;
    public Transform leftGripped;
    public Transform rightGripped;
    public Transform bothGripped;
    public Transform space;
    public Transform primaryGripper;
    public Transform secondaryGripper => primaryGripper == leftGripper ? rightGripper : leftGripper;

    void Grip(Transform gripper, Transform gripped) {
        space.SetParent(null);
        gripped.SetParent(null);
        Drag(gripper, gripped);
        space.SetParent(gripped);
    }

    void Drag(Transform gripper, Transform gripped) {
        gripped.position = gripper.position;
        gripped.rotation = gripper.rotation;
    }

    void DoubleGrip() {
        space.SetParent(null);
        bothGripped.SetParent(null);
        DoubleDrag();
        space.SetParent(bothGripped);
    }

    void DoubleDrag() {
        bothGripped.position = primaryGripper.position;
        bothGripped.rotation = primaryGripper.rotation;
        bothGripped.localScale = Vector3.one * Vector3.Distance(leftGripper.position, rightGripper.position);
    }

    private void Awake() {
        if (space == null) {
            space = transform;
        }
    }

    void Update() {
        if (Input.GetKeyDown(leftGrip) || Input.GetKeyUp(rightGrip) && Input.GetKey(leftGrip)) {
            Grip(leftGripper, leftGripped);
            if (Input.GetKey(rightGrip)) {
                primaryGripper = leftGripper;
                DoubleGrip();
            }
        }
        DebugManager.DebugValue("Left Thumbstick X", Input.GetAxisRaw("Left Thumbstick X"));
        DebugManager.DebugValue("Left Thumbstick Y", Input.GetAxisRaw("Left Thumbstick Y"));
        DebugManager.DebugValue("Right Thumbstick X", Input.GetAxisRaw("Right Thumbstick X"));
        DebugManager.DebugValue("Right Thumbstick Y", Input.GetAxisRaw("Right Thumbstick Y"));
        //Input.
        if (Input.GetKeyDown(rightGrip) || Input.GetKeyUp(leftGrip) && Input.GetKey(rightGrip)) {
            Grip(rightGripper, rightGripped);
            if (Input.GetKey(leftGrip)) {
                primaryGripper = rightGripper;
                DoubleGrip();
            }
        }
        if (Input.GetKey(rightGrip) && Input.GetKey(leftGrip)) {
            DoubleDrag();
        } else {
            if (Input.GetKey(rightGrip)) {
                Drag(rightGripper, rightGripped);
            }
            if (Input.GetKey(leftGrip)) {
                Drag(leftGripper, leftGripped);
            }
        }
    }
}
