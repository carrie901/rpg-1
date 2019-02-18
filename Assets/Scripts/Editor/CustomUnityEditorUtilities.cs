using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CustomUnityEditorUtilities
{
    public static int TAB_SIZE = 20;    // pixel size of 4 spaces?

    public static void HIndent(int indentLevel, Action action)
    {
        GUILayout.Space(indentLevel * TAB_SIZE);
        action();
    }

    public static bool EndChangeCheck()
    {
        if (Application.isPlaying)
            return false;

        var check = EditorGUI.EndChangeCheck();
        if (check)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            return true;
        }
        else
            return false;
    }
}
