using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras = new GameObject[0];

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCamerasActive();
    }

    public void SwitchCameras()
    {
        currentIndex++;
        if (currentIndex >= cameras.Length)
        {
            currentIndex = 0;
        }
        SetCamerasActive();
    }

    private void SetCamerasActive()
    {
        for (int index = 0; index < cameras.Length; index++)
        {
            cameras[index].SetActive(index == currentIndex);
        }
    }
}
