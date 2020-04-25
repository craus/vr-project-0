using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public static class XRInput
{
    private static List<XRNodeState> m_nodeStates = new List<XRNodeState>();

    public static List<XRNodeState> nodeStates {
        get {
            InputTracking.GetNodeStates(m_nodeStates);
            return m_nodeStates;
        }
    }

    public static XRNodeState head {
        get {
            return nodeStates.FirstOrDefault(s => s.nodeType == XRNode.Head);
        }
    }

    public static XRNodeState leftHand {
        get {
            return nodeStates.FirstOrDefault(s => s.nodeType == XRNode.LeftHand);
        }
    }

    public static XRNodeState node(XRNode node) {
        return nodeStates.FirstOrDefault(s => s.nodeType == node);
    }

    public static XRNodeState rightHand {
        get {
            return nodeStates.FirstOrDefault(s => s.nodeType == XRNode.RightHand);
        }
    }
}
