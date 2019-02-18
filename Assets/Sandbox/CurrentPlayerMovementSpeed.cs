using UnityEngine;

[System.Serializable]
public class PlayerCurrentMovementSpeed : HumanoidCurrentMovementSpeed
{
    public override float Percentage
    {
        get
        {
            if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
                return base.Percentage = VerticalMovementSpeedModifier * BaseMovementSpeed.Percentage;
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
                return base.Percentage = HorizontalMovementSpeedModifier * BaseMovementSpeed.Percentage;
            if (Input.GetAxis("Strafe") > 0 || Input.GetAxis("Strafe") < 0)
                return base.Percentage = StrafeMovementSpeedModifier * BaseMovementSpeed.Percentage;
            else
                return base.Percentage;
        }
    }

    public override float Numeric
    {
        get
        {
            if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
                return base.Numeric = VerticalMovementSpeedModifier * BaseMovementSpeed.Numeric;
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
                return base.Numeric = HorizontalMovementSpeedModifier * BaseMovementSpeed.Numeric;
            if (Input.GetAxis("Strafe") > 0 || Input.GetAxis("Strafe") < 0)
                return base.Numeric = StrafeMovementSpeedModifier * BaseMovementSpeed.Numeric;
            else
                return base.Percentage;
        }
    } 
}
