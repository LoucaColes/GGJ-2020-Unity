using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioSystem : Singleton<AudioSystem>
{
    [Header("Glass")]
    [SerializeField] private StudioEventEmitter glassEE;

    [FMODUnity.EventRef]
    public string[] glassSmash;

    [Header("Wood")]
    [SerializeField] private StudioEventEmitter woodEE;

    [FMODUnity.EventRef]
    public string[] woodSmash;

    [Header("Repair")]
    [SerializeField] private StudioEventEmitter repairEE;

    [FMODUnity.EventRef]
    public string[] repair;

    [Header("Robot Beeps")]
    [SerializeField] private StudioEventEmitter robotBeepsEE;

    [FMODUnity.EventRef]
    public string[] robotBeeps;

    [Header("Single SFX")]
    [SerializeField] private StudioEventEmitter footstepsEE;

    [SerializeField] private StudioEventEmitter curtainsEE;

    [SerializeField] private StudioEventEmitter pullyEE;

    [SerializeField] private StudioEventEmitter spotlightEE;

    [SerializeField] private StudioEventEmitter uiClicksEE;

    [SerializeField] private StudioEventEmitter metalClashEE;

    [SerializeField] private StudioEventEmitter audienceEE;

    [SerializeField, Range(0, 100)] private float testAudienceValue = 50;


    // Start is called before the first frame update
    void Start()
    {
        CreateInstance();

        instance = this;

        audienceEE.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayGlassSmashOneShot(Vector3.zero);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayGlassSmashLightOneShot(Vector3.zero);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PlayGlassSmashLightOneShot(Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateAudienceSetting(20f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateAudienceSetting(80f);
        }
    }

    #region Glass
    public void PlayGlassSmashOneShot(Vector3 _location)
    {
        glassEE.transform.position = _location;
        int index = Random.Range(0, glassSmash.Length - 1);
        glassEE.Event = glassSmash[index];
        glassEE.Play();
    }

    public void PlayGlassSmashHeavyOneShot(Vector3 _location)
    {
        glassEE.transform.position = _location;
        glassEE.Event = glassSmash[0];
        glassEE.Play();
    }

    public void PlayGlassSmashLightOneShot(Vector3 _location)
    {
        glassEE.transform.position = _location;
        glassEE.Event = glassSmash[1];
        glassEE.Play();
    }
    #endregion

    #region Wood
    public void PlayWoodSmashOneShot(Vector3 _location)
    {
        woodEE.transform.position = _location;
        int index = Random.Range(0, woodSmash.Length - 1);
        woodEE.Event = woodSmash[index];
        woodEE.Play();
    }

    public void PlayWoodSmashHeavyOneShot(Vector3 _location)
    {
        woodEE.transform.position = _location;
        woodEE.Event = woodSmash[0];
        woodEE.Play();
    }

    public void PlayWoodSmashLightOneShot(Vector3 _location)
    {
        woodEE.transform.position = _location;
        woodEE.Event = woodSmash[1];
        woodEE.Play();
    }
    #endregion

    #region Repair
    public void PlayRandRepairOneShot(Vector3 _location)
    {
        repairEE.transform.position = _location;
        int index = Random.Range(0, repair.Length - 1);
        repairEE.Event = repair[index];
        repairEE.Play();
    }

    public void PlayRepairFastOneShot(Vector3 _location)
    {
        repairEE.transform.position = _location;
        repairEE.Event = repair[0];
        repairEE.Play();
    }

    public void PlayRepairOneShot(Vector3 _location)
    {
        repairEE.transform.position = _location;
        repairEE.Event = repair[1];
        repairEE.Play();
    }
    #endregion

    #region RobotBeeps
    public void PlayRandRobotBeepOneShot(Vector3 _location)
    {
        robotBeepsEE.transform.position = _location;
        int index = Random.Range(0, robotBeeps.Length - 1);
        robotBeepsEE.Event = robotBeeps[index];
        robotBeepsEE.Play();
    }

    public void PlayRobotBeepAOneShot(Vector3 _location)
    {
        robotBeepsEE.transform.position = _location;
        robotBeepsEE.Event = robotBeeps[0];
        robotBeepsEE.Play();
    }

    public void PlayRobotBeepBOneShot(Vector3 _location)
    {
        robotBeepsEE.transform.position = _location;
        robotBeepsEE.Event = robotBeeps[1];
        robotBeepsEE.Play();
    }
    #endregion

    public void PlayFootstepsOneShot(Vector3 _location)
    {
        footstepsEE.transform.position = _location;
        footstepsEE.Play();
    }

    public void PlayCurtainsOneShot(Vector3 _location)
    {
        curtainsEE.transform.position = _location;
        curtainsEE.Play();
    }

    public void PlayPullyOneShot(Vector3 _location)
    {
        pullyEE.transform.position = _location;
        pullyEE.Play();
    }

    public void PlaySpotlightOneShot(Vector3 _location)
    {
        spotlightEE.transform.position = _location;
        spotlightEE.Play();
    }

    public void PlayUIClicksOneShot(Vector3 _location)
    {
        uiClicksEE.transform.position = _location;
        uiClicksEE.Play();
    }

    public void PlayMetalClashOneShot(Vector3 _location)
    {
        metalClashEE.transform.position = _location;
        metalClashEE.Play();
    }

    public void UpdateAudienceSetting(float setting)
    {
        audienceEE.SetParameter("Audiance_Reaction", setting);
    }
}
