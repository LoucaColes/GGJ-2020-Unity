using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : Singleton<InteractableManager>
{
    [SerializeField] private CardboardProp[] cardboardProps;

    [SerializeField] private LightFixture[] lightFixtures;

    [SerializeField] private float playTime = 60f;
    [SerializeField, Range(1, 15)] private int disasterRate = 5;

    private float timer = 0;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        CreateInstance();

        instance = this;
    }

    private void Update()
    {
        if (LevelFlowManager.instance.CurrentFlowState == LevelFlowState.PLAY)
        {
            timer += Time.deltaTime;

            int timerRounded = Mathf.FloorToInt(timer);

            if (timerRounded % disasterRate == 0)
            {
                if (!triggered)
                {
                    for (int index = 0; index < PlayerManager.instance.PlayerCount + 3; index++)
                    {
                        TriggerDisaster();
                    }

                }
            }
            else
            {
                triggered = false;
            }
        }
    }

    private void TriggerDisaster()
    {
        Debug.Log("Trigger Disaster!");
        int type = Random.Range(0, 4);
        switch (type)
        {
            case 0:
                BreakCardboardProps();
                triggered = true;
                break;
                case 1:
                BreakLightFixture();
                triggered = true;
                break;
                //case 2:
                //case 3:
                //case 4:
                //default:
                //    BreakCardboardProps();
                //    triggered = true;
                //    break;
        }
    }

    private void BreakCardboardProps()
    {
        Debug.Log("Breaking Cardboard");
        int index = Random.Range(0, cardboardProps.Length);

        if (cardboardProps[index].InteractableState == InteractableState.WORKING)
        {
            cardboardProps[index].Break();
        }
    }
    private void BreakLightFixture()
    {
        Debug.Log("Breaking light");
        int index = Random.Range(0, lightFixtures.Length);

        if (lightFixtures[index].InteractableState == InteractableState.WORKING)
        {
            lightFixtures[index].Break();
        }
    }
}
