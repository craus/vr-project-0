﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.XR;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class XRNodeStateExtensions
{
    public static string ExtToString(this XRNodeState s) {
        return s.nodeType.ToString();
    }

    public static Vector3 Position(this XRNodeState s) {
        Vector3 result;
        s.TryGetPosition(out result);
        return result;
    }

    public static Quaternion Rotation(this XRNodeState s) {
        Quaternion result;
        s.TryGetRotation(out result);
        return result;
    }
}