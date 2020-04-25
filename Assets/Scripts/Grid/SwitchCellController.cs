using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class SwitchCellController : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private IntVector3Provider cellProvider;

    public void Update() {
        if (Input.GetKeyDown(key)) {
            Grid.instance.SwitchCell(cellProvider.Value);
        }
    }
}
