using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CenterRing))]
public class CenterRingEditor : Editor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add Point"))
        {
            CenterRing center = FindObjectOfType<CenterRing>();
            center.AddPoint();
        }
        if (GUILayout.Button("Remove Point"))
        {
            CenterRing center = FindObjectOfType<CenterRing>();
            center.RemovePoint();
        }
    }


}
