using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CursorManager))]
public class CursorManagerEditor : Editor
{
    private CursorManager cursorManager;

    private void OnEnable()
    {
        cursorManager = (CursorManager)target;
    }

    public override void OnInspectorGUI()
    {
        cursorManager.LockMode = (CursorLockMode)EditorGUILayout.EnumPopup("Lock Mode", cursorManager.LockMode);
        cursorManager.IsVisible = EditorGUILayout.Toggle("Is Visible", cursorManager.IsVisible);
    }
}
