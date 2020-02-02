using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : Singleton<RandomNumber>
{
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        CreateInstance();
        instance = this;
    }

    public int GetRandomValue()
    {
        return random.Next(0, 4);
    }
}
