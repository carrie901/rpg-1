using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public CursorLockMode LockMode
    {
        get { return _lockMode; }
        set
        {
            _lockMode = value;
            Cursor.lockState = _lockMode;
        }
    }
    [SerializeField] private CursorLockMode _lockMode;

    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            _isVisible = value;
            Cursor.visible = IsVisible;
        }
    }
    [SerializeField] private bool _isVisible;

    private void Awake()
    {
        LockMode = _lockMode;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (IsVisible) return;

        if (CustomUnityUtilities.IsOutsideGameView)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }
#endif

}
