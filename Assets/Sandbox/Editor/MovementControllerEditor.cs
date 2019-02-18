using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{

    PlayerController playerController;

    private void OnEnable()
    {
        playerController = (PlayerController)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        if (playerController.CurrentMovementSpeed == null) playerController.CurrentMovementSpeed = new PlayerCurrentMovementSpeed();

        EditorGUI.indentLevel++;
        playerController.CurrentMovementSpeed.showInInspector = EditorGUILayout.Foldout(playerController.CurrentMovementSpeed.showInInspector, "Current Movement Speed");
        if (playerController.CurrentMovementSpeed.showInInspector)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.FloatField("Percentage", playerController.CurrentMovementSpeed.Percentage);
            EditorGUILayout.FloatField("Numeric", playerController.CurrentMovementSpeed.Numeric);

            if (playerController.CurrentMovementSpeed.BaseMovementSpeed == null) playerController.CurrentMovementSpeed.BaseMovementSpeed = new MovementSpeed();

            playerController.CurrentMovementSpeed.BaseMovementSpeed.showInInspector = EditorGUILayout.Foldout(playerController.CurrentMovementSpeed.BaseMovementSpeed.showInInspector, "Base Movement Speed");
            if (playerController.CurrentMovementSpeed.BaseMovementSpeed.showInInspector)
            {
                EditorGUI.indentLevel++;
                    playerController.CurrentMovementSpeed.BaseMovementSpeed.Percentage = EditorGUILayout.FloatField("Percentage", playerController.CurrentMovementSpeed.BaseMovementSpeed.Percentage);
                    playerController.CurrentMovementSpeed.BaseMovementSpeed.Numeric = EditorGUILayout.FloatField("Numeric", playerController.CurrentMovementSpeed.BaseMovementSpeed.Numeric);
                EditorGUI.indentLevel--;
            }

            playerController.CurrentMovementSpeed.showModifiers = EditorGUILayout.Foldout(playerController.CurrentMovementSpeed.showModifiers, "Modifiers");
            if (playerController.CurrentMovementSpeed.showModifiers)
            {
                EditorGUI.indentLevel++;
                    playerController.CurrentMovementSpeed.VerticalMovementSpeedModifier = EditorGUILayout.FloatField("Vertical Modifier", playerController.CurrentMovementSpeed.VerticalMovementSpeedModifier);
                    playerController.CurrentMovementSpeed.HorizontalMovementSpeedModifier = EditorGUILayout.FloatField("Horizontal Modifier", playerController.CurrentMovementSpeed.HorizontalMovementSpeedModifier);
                    playerController.CurrentMovementSpeed.StrafeMovementSpeedModifier = EditorGUILayout.FloatField("Strafe Modifier", playerController.CurrentMovementSpeed.StrafeMovementSpeedModifier);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }
        EditorGUI.indentLevel--;

        Repaint();
        CustomUnityEditorUtilities.EndChangeCheck();
    }
}