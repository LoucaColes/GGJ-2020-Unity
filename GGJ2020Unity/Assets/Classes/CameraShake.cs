using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : Singleton<CameraShake>
{
    [SerializeField] private DOTweenAnimation cameraShake = null;

    private void Awake()
    {
        CreateInstance();

        instance = this;
    }

    public void Shake()
    {
        cameraShake.DORestart();
        cameraShake.DOPlay();
    }
}
