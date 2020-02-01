using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVolume : MonoBehaviour
{
    [SerializeField]
    private Transform playerSpawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        // if the player has fallen through the floor, the goofer
        if (other.gameObject.layer == 10)
        {
            // then bring them back to the spawn position
            other.gameObject.transform.position = playerSpawnTransform.position;
        }
    }
}
