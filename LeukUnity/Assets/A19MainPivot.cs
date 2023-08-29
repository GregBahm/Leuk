using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A19MainPivot : MonoBehaviour
{
    [SerializeField]
    private A19Group groupA;

    [SerializeField]
    private A19Group groupB;

    [SerializeField]
    private float beatDuration;
    [SerializeField]
    private float beatTransitionRamp;
    [SerializeField]
    private Vector2 rect;

    private Vector2 pointA;

    private Vector2 pointB;


    private float currentBeatDuration;

    private void Update()
    {
        UpdateBeatDuration();
        UpdateArt();
    }

    private void UpdateArt()
    {
        float param = currentBeatDuration / beatDuration;
        param = Mathf.Pow(param, beatTransitionRamp);
        float x = Mathf.SmoothStep(pointB.x, pointA.x, param);
        float y = Mathf.SmoothStep(pointB.y, pointA.y, param);
        transform.position = new Vector3(x, y, 0);
        groupA.DoUpdate(param);
        groupB.DoUpdate(param);
    }

    private void UpdateBeatDuration()
    {
        if (currentBeatDuration > 0)
        {
            currentBeatDuration -= Time.deltaTime;
        }
        else
        {
            currentBeatDuration = beatDuration;
            pointA = pointB;
            pointB = GetTargetScreenPos();
            groupA.UpdateTarget();
            groupB.UpdateTarget();
        }
    }

    private Vector2 GetTargetScreenPos()
    {
        float randX = UnityEngine.Random.Range(-1f, 1f);
        float randY = UnityEngine.Random.Range(-1f, 1f);
        return new Vector2(randX * rect.x, randY * rect.y);
    }
}
