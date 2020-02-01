using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCamera : MonoBehaviour
{
    [SerializeField]
    private Transform stageTarget;

    [SerializeField]
    private List<Transform> targets;

    [SerializeField]
    private Vector3 offset;

    Vector3 centre = new Vector3(0, 0, 0);
    int count = 0;

    private void Awake()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // call player manager and get the player count
        if (targets[0] == true)
        {
            transform.position = targets[0].transform.position + offset;
        }
        //transform.LookAt(targets[0]);
        //foreach (var t in targets)
        //{
        //    if (t.gameObject.activeInHierarchy == true)
        //    {
        //    }
        // //   centre += t.transform.position;
        //}
        //Vector3 newPos = centre / count;
        //transform.position = newPos + offset;
        //transform.position = playerTarget[0].transform.position + offset;
    }

    public void AddTarget(Transform newTarget)
    {
        targets.Add(newTarget);
        count++;
    }
    public void RemoveTarget(int pos)
    {
        targets.RemoveAt(pos);
        count--;
    }

}
