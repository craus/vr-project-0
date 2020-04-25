using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Endo
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private bool once;

        public UnityEvent activate;

        [ReadOnly] [SerializeField] private bool triggered;

        [ContextMenu("Run")]
        public void Run()
        {
            if (!once || !triggered)
            {
                triggered = true;
                activate.Invoke();
            }
        }
    }
}
