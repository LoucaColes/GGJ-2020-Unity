using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class AudienceMaterialSet : MonoBehaviour
{
    public Material[] availableMats;

    public Material[] availableDarkMats;

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
}
