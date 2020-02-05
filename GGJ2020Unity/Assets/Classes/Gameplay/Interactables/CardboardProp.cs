using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardProp : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem dustPS;
    [SerializeField] private Vector3 collapseRotation = new Vector3();
    [SerializeField] private Vector3 fixedRotation = new Vector3();

    [SerializeField] private float rotateSpeed = 1;
    [SerializeField] private float dustDelay = 0.25f;
    [SerializeField] private float reactionRate = 0.25f;

    private InteractableState interactableState = InteractableState.WORKING;
    private bool triggered = false;

    public InteractableState InteractableState { get { return interactableState; } }

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
            if (LevelFlowManager.instance.CurrentFlowState == LevelFlowState.PLAY)
            {
                LevelFlowManager.instance.DecreaseAudienceEngagement(reactionRate);
                AudioSystem.instance.UpdateAudienceSetting(LevelFlowManager.instance.audienceEngagement);
            }
            float distance = Vector3.Distance(transform.localRotation.eulerAngles, collapseRotation);

            if (distance > Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(collapseRotation), rotateSpeed * Time.deltaTime);
            }
            else
            {
                if (!triggered)
                {
                    
                    triggered = true;
                }
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
        triggered = false;
        StartCoroutine(PlayDustPS());
    }


    private IEnumerator PlayDustPS()
    {
        yield return new WaitForSeconds(dustDelay);
        dustPS.gameObject.SetActive(true);
        dustPS.Play();
        AudioSystem.instance.PlayWoodSmashHeavyOneShot(transform.position);
        AudioSystem.instance.PlayBoos();
    }

    public void Interact()
    {
        interactableState = InteractableState.FIXING;
    }
}
