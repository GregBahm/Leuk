using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A19Group : MonoBehaviour
{
    [SerializeField]
    private Transform barA;
    [SerializeField]
    private Transform barB;

    [SerializeField]
    private float maxAngle;

    private float startRot;
    private float endRot;

    private float startMiniRot;
    private float endMiniRot;

    public void DoUpdate(float param)
    {
        float zRot = Mathf.SmoothStep(endRot, startRot, param);
        transform.localRotation = Quaternion.Euler(0, 0, zRot);

        float miniRot = Mathf.SmoothStep(endMiniRot, startMiniRot, param);
        barA.localRotation = Quaternion.Euler(0, 0, miniRot);
        barB.localRotation = Quaternion.Euler(0, 0, -miniRot);
    }

    public void UpdateTarget()
    {
        startRot = endRot;
        endRot = endRot + UnityEngine.Random.Range(-30, 30);

        startMiniRot = endMiniRot;
        endMiniRot = UnityEngine.Random.Range(-maxAngle, maxAngle);
    }

}
