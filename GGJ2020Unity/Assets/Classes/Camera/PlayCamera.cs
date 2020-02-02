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
    private Vector3 velocity;
    public float smoothTime = 1f;
    Camera cam;
    public float minZoom = 40f;
    public float maxZoom = 80f;
    public float zoomLimiter = 50f;
    private void Awake()
    {
        offset = transform.position;
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        //if (targets.Count == 0)
        //    return;
        MoveCamera();
        //ZoomCamera();
    }
    private void ZoomCamera()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = newZoom;
    }
    private void MoveCamera()
    {
        Vector3 centrePoint = GetCentrePoint();
        Vector3 newPos = centrePoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].gameObject.activeInHierarchy)
            {
                bounds.Encapsulate(targets[i].position);
            }
        }
        return bounds.size.z;
    }
    Vector3 GetCentrePoint()
    {
        //if (targets.Count == 1)
        //{
        //    return targets[0].position;
        //}

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].gameObject.activeInHierarchy)
            {
                bounds.Encapsulate(targets[i].position);
            }
            //bounds.Encapsulate(targets[i].position);

        }
        return bounds.center;
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
