using UnityEngine;

[System.Serializable]
public class HumanoidCurrentMovementSpeed : CurrentMovementSpeed
{

    public float VerticalMovementSpeedModifier
    {
        get { return _verticalMovementSpeedModifier; }
        set { _verticalMovementSpeedModifier = value; }
    }
    [SerializeField] private float _verticalMovementSpeedModifier = 1f;

    public float HorizontalMovementSpeedModifier
    {
        get { return _horizontalMovementSpeedModifier; }
        set { _horizontalMovementSpeedModifier = value; }
    }
    [SerializeField] private float _horizontalMovementSpeedModifier = 1f;

    public float StrafeMovementSpeedModifier
    {
        get { return _strafeMovementSpeedModifier; }
        set { _strafeMovementSpeedModifier = value; }
    }
    [SerializeField] private float _strafeMovementSpeedModifier =  1f;

#if UNITY_EDITOR
    public bool showModifiers = true;
#endif

}
