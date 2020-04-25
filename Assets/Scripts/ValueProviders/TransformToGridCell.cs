using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class TransformToGridCell : IntVector3Provider
{
    [SerializeField] private Transform grid;
    [SerializeField] private Transform target;

    public override IntVector3 Value => grid.InverseTransformPoint(target.position);
}
