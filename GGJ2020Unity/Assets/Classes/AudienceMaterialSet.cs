using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class AudienceMaterialSet : MonoBehaviour
{
    Material[] availableMats;

    Material[] availableDarkMats;

    SkinnedMeshRenderer smr;
    Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        // get channels 
        //0,1,2,4
        smr = GetComponent<SkinnedMeshRenderer>();

        mats = smr.materials;
        mats[0] = availableMats[RandomNumber.instance.GetRandomValue()];
        mats[4] = availableMats[RandomNumber.instance.GetRandomValue()];
        mats[1] = availableDarkMats[RandomNumber.instance.GetRandomValue()];
        mats[2] = availableDarkMats[RandomNumber.instance.GetRandomValue()];

    }
}
