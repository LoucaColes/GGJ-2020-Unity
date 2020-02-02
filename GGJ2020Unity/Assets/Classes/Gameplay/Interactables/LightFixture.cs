using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LightFixture : MonoBehaviour, IInteractable
{
    private Rigidbody rb;
    private InteractableState interactableState = InteractableState.WORKING;
    public InteractableState InteractableState { get => interactableState; set => interactableState = value; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        //Break();
    }
    // Start is called before the first frame update
    void Start()
    {
        interactableState = InteractableState.WORKING;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Break()
    {
        interactableState = InteractableState.BROKE;
        rb.useGravity = true;
    }

    public void Interact()
    {
        print("interacting!");
        interactableState = InteractableState.FIXING;
        rb.AddForce(new Vector3(0, 20000, 20));
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSystem.instance.PlayMetalClashOneShot(transform.position);
    }
}
