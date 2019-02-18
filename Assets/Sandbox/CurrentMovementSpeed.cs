[System.Serializable]
public abstract class CurrentMovementSpeed : MovementSpeed
{
    public MovementSpeed BaseMovementSpeed;

    public override float Percentage
    {
        get
        {
            base.Percentage = 0;
            base.Numeric = 0;
            return base.Numeric;
        }
    }

    public override float Numeric
    {
        get
        {
            base.Numeric = 0;
            base.Percentage = 0;
            return base.Numeric;
        }
    }
}
