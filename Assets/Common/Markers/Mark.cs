using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Endo
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Endo/Mark")]
    public class Mark : ScriptableObject
    {
        public IEnumerable<Component> objects => FindObjectsOfType<Marker>().Where(m => m.mark == this);
    }
}