using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB = null;
    [SerializeField] private PlayerInput playerIP = null;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 0.15f;

    private Vector3 movementDirection = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector3(playerIP.Horizontal, 0, playerIP.Vertical);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movementDirection), rotateSpeed);
    }

    private void FixedUpdate()
    {
        playerRB.velocity += movementDirection * moveSpeed * Time.deltaTime;
    }
}
