using UnityEngine;

[System.Serializable]
public class MovementSpeed
{
    public virtual float Percentage
    {
        get {  return _percentage; }
        set
        {
            _percentage = value;
            numeric = _percentage / 100;
        }
    }
    [SerializeField] private float _percentage = 100f;

    public virtual float Numeric
    {
        get {  return numeric; }
        set
        {
            numeric = value;
            _percentage = numeric * 100;
        }
    }
    [SerializeField] private float numeric = 1f;

#if UNITY_EDITOR
    public bool showInInspector = true;
#endif

}
