using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveSpaceThumbstick : MonoBehaviour
{
    public string leftXAxe;
    public string leftYAxe;
    public string rightXAxe;
    public string rightYAxe;
    public Transform space;
    public Transform left;
    public Transform right;

    public float speed = 1;

    public float leftX => Input.GetAxisRaw(leftXAxe);
    public float leftY => Input.GetAxisRaw(leftYAxe);
    public float rightX => Input.GetAxisRaw(rightXAxe);
    public float rightY => Input.GetAxisRaw(rightYAxe);

    private void Awake() {
        if (space == null) {
            space = transform;
        }
    }

    void Update() {
        space.Translate((left.forward * leftY - left.right * leftX) * speed * Time.deltaTime, Space.World);
        space.Translate((right.forward * rightY - right.right * rightX) * speed * Time.deltaTime, Space.World);
    }
}
