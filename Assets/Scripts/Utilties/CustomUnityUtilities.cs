using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomUnityUtilities
{
    public static bool IsOutsideGameView
    {
        get
        {
            var view = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            return view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1;
        }
    }

    public static Camera CachedMainCamera
    {
        get
        {
            if (_cachedMainCamera == null)
                _cachedMainCamera = Camera.main;

            return _cachedMainCamera;
        }
    }
    private static Camera _cachedMainCamera;
}
