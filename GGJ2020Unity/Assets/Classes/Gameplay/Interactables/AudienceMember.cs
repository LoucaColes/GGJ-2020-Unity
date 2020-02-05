using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody audienceRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break() { }

    public void Interact()
    {
        Debug.Log("Throwing Audience Member");
        audienceRB.constraints = RigidbodyConstraints.None;
        //transform.parent = null;
        audienceRB.AddForce(new Vector3(0, 20000, 20));
        AudioSystem.instance.PlayBoos();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audienceRB.constraints = RigidbodyConstraints.None;
            //transform.parent = null;
            AudioSystem.instance.PlayBoos();
        }
    }
}
