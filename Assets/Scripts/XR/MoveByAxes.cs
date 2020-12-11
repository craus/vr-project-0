using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveByAxes : MonoBehaviour
{
    public string xAxis;
    public string yAxis;
    public string zAxis;

    public Vector3 multiplier = Vector3.one;

    public Transform target;
    public CharacterController targetCharacter;
    public Transform relativeTo;

    public bool ignoreVerticalMovement = false;
    public bool allowFastDiagonalMovement = false;

    public float speed = 1;

    private float x => xAxis != "" ? Input.GetAxisRaw(xAxis) : 0;
    private float y => yAxis != "" ? Input.GetAxisRaw(yAxis) : 0;
    private float z => zAxis != "" ? Input.GetAxisRaw(zAxis) : 0;

    private Vector3 inputMove => new Vector3(x, y, z).Scaled(multiplier);
    private Vector3 clampedMove => allowFastDiagonalMovement ? inputMove : Vector3.ClampMagnitude(inputMove, 1);
    private Vector3 absoluteMove => relativeTo != null ? relativeTo.TransformVector(clampedMove) : clampedMove;
    private Vector3 finalMove => ignoreVerticalMovement ? absoluteMove.Change(y: 0).normalized * absoluteMove.magnitude : absoluteMove;

    private void Awake() {
        if (target == null && targetCharacter == null) {
            target = transform;
        }
    }

    void Update() {
        if (target != null) {
            target.Translate(finalMove * speed * Time.deltaTime, Space.World);
        }
    }

    void FixedUpdate() {
        if (targetCharacter != null) {
            targetCharacter.Move(finalMove * speed * Time.fixedDeltaTime);
        }
    }
}
