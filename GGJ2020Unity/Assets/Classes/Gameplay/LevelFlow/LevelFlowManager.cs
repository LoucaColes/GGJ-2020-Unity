using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlowManager : Singleton<LevelFlowManager>
{
    const float MAX_AUDIENCE_ENGAGEMENT = 100f;

    [Header("Flow States")]
    [SerializeField] private LevelFlowState initialFlowState = LevelFlowState.PLAYERSELECT;

    [Header("State Settings (in seconds)")]
    [SerializeField, Range(-1, 60)] private float playerSelectTime = -1f;
    [SerializeField, Range(-1, 60)] private float setUpTime = -1f;
    [SerializeField, Range(-1, 60)] private float playTime = 60f;
    [SerializeField, Range(-1, 60)] private float audienceReactionTime = 30f;
    [SerializeField, Range(-1, 60)] private float creditsTime = 30f;
    [SerializeField, Range(-1, 60)] private float reviewTime = -1f;

    [Header("Camera Stuff")]
    [SerializeField] private CameraSwitcher cameraSwitcher = null;

    [SerializeField] private NewsPaper newsPaper;

    [SerializeField] private GameObject[] actors;

    private LevelFlowState currentFlowState = LevelFlowState.PLAYERSELECT;
    private LevelFlowState nextFlowState = LevelFlowState.PLAYERSELECT;
    private float timer = 0;
    private bool timerActive = false;

    public LevelFlowState CurrentFlowState { get { return currentFlowState; } }
    public CameraSwitcher CameraSwitcher { get { return cameraSwitcher; } }

    public float audienceEngagement = 50f;

    private bool triggered = false;

    private int id = 0;

    private void Awake()
    {
        CreateInstance();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeFlowState(initialFlowState);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;

            if (currentFlowState == LevelFlowState.PLAY)
            {
                int intTimer = Mathf.RoundToInt(timer);

                if (intTimer % 15 == 0)
                {
                    if (!triggered)
                    {
                        id++;
                        if (id > 4)
                        {
                            id = 2;
                        }
                        AudioSystem.instance.UpdateMusicSetting(id);
                        triggered = true;
                    }
                }
                else
                {
                    triggered = false;
                }
            }

            if (timer < 0)
            {
                timerActive = false;
                ChangeFlowState(nextFlowState);
            }
        }
    }

    public void ChangeFlowState(LevelFlowState _newFlowState)
    {
        currentFlowState = _newFlowState;

        switch (currentFlowState)
        {
            case LevelFlowState.PLAYERSELECT:
                AudioSystem.instance.UpdateMusicSetting(1);
                StartTimer(playerSelectTime);
                for (int i = 0; i < actors.Length; i++)
                {
                    actors[i].SetActive(false);
                }
                break;
            case LevelFlowState.SETUP:
                StartTimer(setUpTime);
                break;
            case LevelFlowState.PLAY:
                AudioSystem.instance.UpdateMusicSetting(2);
                for (int i = 0; i < actors.Length; i++)
                {
                    if (actors[i].activeInHierarchy == false)
                    {
                        actors[i].SetActive(true);
                    }
                }
                id = 2;
                StartTimer(playTime);
                break;
            case LevelFlowState.AUDIENCEREACTION:
                if (audienceEngagement >= 50)
                {
                    AudioSystem.instance.UpdateMusicSetting(3);
                }
                else
                {
                    AudioSystem.instance.UpdateMusicSetting(2);
                }
                if (cameraSwitcher)
                {
                    cameraSwitcher.SwitchCameras();
                }
                StartTimer(audienceReactionTime);
                break;
            case LevelFlowState.CREDITS:
                
                if (cameraSwitcher)
                {
                    cameraSwitcher.SwitchCameras();
                }
                StartTimer(creditsTime);
                break;
            case LevelFlowState.REVIEW:
                StartTimer(reviewTime);
                break;
            default:
                Debug.LogError("Louca hasn't implemented the switch cases");
                break;
        }
    }

    private void StartTimer(float _time)
    {
        if (_time > 0)
        {
            SetNextState();

            timer = _time;

            timerActive = true;
        }
        else if (currentFlowState == LevelFlowState.PLAYERSELECT )
        {
            // if any player input for the 'begin' button is detected, jump to the next stage

        }
        else if (currentFlowState == LevelFlowState.REVIEW)
        {
            if (newsPaper)
            {
                newsPaper.gameObject.SetActive(true);
            }
        }
        else
        {
            SetNextState();
            ChangeFlowState(nextFlowState);
        }
    }

    private void SetNextState()
    {
        int currentState = (int)currentFlowState;

        currentState++;
        if (currentState >= (int)LevelFlowState.MAX)
        {
            currentState = 0;
        }

        nextFlowState = (LevelFlowState)currentState;
    }
    public float GetTimeToIntermission()
    {
        return timer;
    }
    public void IncreaseAudienceEngagement(float amount)
    {
        if (audienceEngagement + amount >= MAX_AUDIENCE_ENGAGEMENT)
        {
            audienceEngagement = MAX_AUDIENCE_ENGAGEMENT;
        }
        else
        {
            audienceEngagement += amount;
        }
    }
    public void DecreaseAudienceEngagement(float amount)
    {
        if (audienceEngagement - amount <= 0)
        {
            audienceEngagement = 0;
        }
        else
        {
            audienceEngagement -= amount;
        }
    }
}
