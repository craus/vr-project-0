//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR;

//public class MoveByAxe : MonoBehaviour
//{
//    public string xAxis;
//    public string yAxis;

//    public Transform target;
//    public Transform relativeTo;

//    public Vector3 direction;

//    private Vector3 absoluteDirection => relativeTo != null ? relativeTo.TransformDirection(direction) : direction;

//    public bool ignoreVerticalMovement = false;

//    public float speed = 1;

//    public float value => Input.GetAxisRaw(axe);

//    private void Awake() {
//        if (target == null) {
//            target = transform;
//        }
//    }

//    void Update() {
//        if (relativeTo == null) {
//            target.Translate(direction * value * speed * Time.deltaTime, Space.World);
//        } else {
//            target.Translate( * value * speed * Time.deltaTime, Space.World);
//        }
//    }
//}
