using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDictionary : MonoBehaviour
{
    public static Dictionary<string, Vector3> Data = new Dictionary<string, Vector3>
    {
        {
            "E2", new Vector3(-5.79f, -3.3f, -5.4f)
        }
    };
}
