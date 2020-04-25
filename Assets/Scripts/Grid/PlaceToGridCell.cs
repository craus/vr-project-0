using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class PlaceToGridCell : MonoBehaviour
{
    [SerializeField] private IntVector3Provider cellProvider;

    public void Update() {
        transform.localPosition = cellProvider.Value; 
    }
}
