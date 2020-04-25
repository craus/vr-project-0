using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Endo
{
    public class GameObjectActiveCondition : BoolValueProvider
    {
        public override bool Value => gameObject.activeInHierarchy;
    }
}
