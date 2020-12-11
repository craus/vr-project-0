using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotateByAxes : MonoBehaviour
{
    public string xAxis;
    public string yAxis;
    public string zAxis;

    public Vector3 multiplier = Vector3.one;

    public Transform target;
    public CharacterController targetCharacter;
    public Transform relativeTo;

    public bool allowFastDiagonalRotation = false;

    public float speed = 1;

    private float x => xAxis != "" ? Input.GetAxisRaw(xAxis) : 0;
    private float y => yAxis != "" ? Input.GetAxisRaw(yAxis) : 0;
    private float z => zAxis != "" ? Input.GetAxisRaw(zAxis) : 0;

    private Vector3 inputRotation => new Vector3(x, y, z).Scaled(multiplier);
    private Vector3 clampedRotation => allowFastDiagonalRotation ? inputRotation : Vector3.ClampMagnitude(inputRotation, 1);
    private Vector3 absoluteRotation => relativeTo != null ? relativeTo.TransformVector(clampedRotation) : clampedRotation;

    private void Awake() {
        if (target == null && targetCharacter == null) {
            target = transform;
        }
    }

    void Update() {
        if (target != null) {
            target.Rotate(absoluteRotation * speed * Time.deltaTime, Space.World);
        }
    }

    //void FixedUpdate() {
    //    if (targetCharacter != null) {
    //        targetCharacter.Move(absoluteMove * speed * Time.deltaTime);
    //    }
    //}
}
