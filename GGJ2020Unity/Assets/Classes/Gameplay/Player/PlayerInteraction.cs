using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInput playerIP = null;

    [SerializeField, Range(1, 10)] private float radius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIP.Interact)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            for (int index = 0; index < colliders.Length; index++)
            {
                IInteractable interactable = colliders[index].GetComponent<IInteractable>();

                if (interactable != null)
                {
                    interactable.Interact();
                    AudioSystem.instance.PlayRepairFastOneShot(transform.position);
                    break;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
