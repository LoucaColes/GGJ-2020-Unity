using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private DOTweenAnimation cameraShake = null;

    public void Shake()
    {
        cameraShake.DORestart();
        cameraShake.DOPlay();
    }
}
