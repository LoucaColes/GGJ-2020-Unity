using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiCannon : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem confetti;

    [SerializeField, Range(0, 20)] private float cooldown = 5;

    private bool canInteract = true;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = true;
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canInteract)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                canInteract = true;
            }
        }
    }

    public void Break() { }

    public void Interact()
    {
        if (canInteract)
        {
            confetti.gameObject.SetActive(true);
            confetti.Play();
            timer = cooldown;
            canInteract = false;
            AudioSystem.instance.PlayConfettiOneShot(transform.position);
        }
        Debug.Log("Increase Audience Reaction");
    }
}
