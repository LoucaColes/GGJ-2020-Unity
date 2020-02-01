using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardProp : MonoBehaviour, IInteractable
{
    [SerializeField] private Vector3 collapseRotation = new Vector3();
    [SerializeField] private Vector3 fixedRotation = new Vector3();

    [SerializeField] private float rotateSpeed = 1;

    private InteractableState interactableState = InteractableState.WORKING;

    // Start is called before the first frame update
    void Start()
    {
        interactableState = InteractableState.WORKING;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactableState == InteractableState.BROKE)
        {
            float distance = Vector3.Distance(transform.localRotation.eulerAngles, collapseRotation);

            if (distance > Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(collapseRotation), rotateSpeed * Time.deltaTime);
            }

        }
        else if (interactableState == InteractableState.FIXING)
        {
            float distance = Vector3.Distance(transform.localRotation.eulerAngles, fixedRotation);

            if (distance > Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(fixedRotation), rotateSpeed * Time.deltaTime);
            }
            else
            {
                interactableState = InteractableState.WORKING;
            }
        }
    }

    public void Break()
    {
        interactableState = InteractableState.BROKE;
    }

    public void Interact()
    {
        interactableState = InteractableState.FIXING;
    }
}
