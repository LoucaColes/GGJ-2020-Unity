using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class AudienceMaterialSet : MonoBehaviour
{
    public Material[] availableMats;

    public Material[] availableDarkMats;

    public Material[] faceMaterials;

    // I no likey
    private bool hasUpdatedFace = false;

    //SkinnedMeshRenderer smr;
    // Start is called before the first frame update
    void Start()
    {
        // get channels 
        //0,1,2,4
        //smr = GetComponent<SkinnedMeshRenderer>();

        Material[] mats = GetComponent<SkinnedMeshRenderer>().materials;
        mats[0] = availableMats[RandomNumber.instance.GetRandomValue()];
        mats[4] = availableMats[RandomNumber.instance.GetRandomValue()];
        mats[1] = availableDarkMats[RandomNumber.instance.GetRandomValue()];
        mats[2] = availableDarkMats[RandomNumber.instance.GetRandomValue()];

        GetComponent<SkinnedMeshRenderer>().materials = mats;
        print("materials set");
    }

    private void Update()
    {
        if (LevelFlowManager.instance.CurrentFlowState == LevelFlowState.AUDIENCEREACTION
            && hasUpdatedFace == false)
        {
            SetRobotFaceState();
            hasUpdatedFace = true;
        }
    }

    public void SetRobotFaceState()
    {
        float audienceReaction = LevelFlowManager.instance.audienceEngagement;

        Material[] mats = GetComponent<SkinnedMeshRenderer>().materials;
        mats[3] = faceMaterials[RandomNumber.instance.GetRandomValue()];

        if (audienceReaction >= 0 && audienceReaction < 25f)
        {
            mats[3] = faceMaterials[0];

        }
        if (audienceReaction >= 25 && audienceReaction < 50f)
        {
            mats[3] = faceMaterials[1];

        }
        if (audienceReaction >= 50 && audienceReaction < 75f)
        {
            mats[3] = faceMaterials[2];

        }
        // love
        if (audienceReaction >= 75f)
        {
            mats[3] = faceMaterials[3];

        }
        GetComponent<SkinnedMeshRenderer>().materials = mats;
    }
}
