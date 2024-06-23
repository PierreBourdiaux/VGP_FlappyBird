using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraControlleur : MonoBehaviour
{
    public static CameraControlleur Instance;

    public Camera cam;

    void Awake()
    {
        Instance = this;
    }

    public void Shake(float duration, float magnitude)
    {
        cam.DOShakePosition(duration, magnitude);
    }

    
}
