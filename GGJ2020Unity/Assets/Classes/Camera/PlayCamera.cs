using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCamera : MonoBehaviour
{
    [SerializeField]
    private Transform stageTarget;

    [SerializeField]
    private Transform playerTarget;

    [SerializeField]
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerTarget);
        transform.position = playerTarget.transform.position + offset;
    }
}
