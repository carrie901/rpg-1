using UnityEngine;
using UnityEditor;

public static class CustomEditorStyles 
{
    public static GUIStyle CustomFoldoutStyle
    {
        get
        {
            GUIStyle style = EditorStyles.foldout;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.LowerLeft;
            return style;
        }
    }

}
