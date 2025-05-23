﻿using System.Collections;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;

    [SerializeField] private bool isPouring = false;
    [SerializeField] private Stream currentStream = null;

    private void Update()
    {
        //Debug.Log(CalculaterPourAngle());
        bool pourCheck = CalculaterPourAngle() < pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        print("Start");
        currentStream = CreateStream();
        currentStream.Begin();

    }

    private void EndPour()
    {
        print("End");
        currentStream.End();
        currentStream = null;
    }

    private float CalculaterPourAngle()
    {
        //return transform.forward.y * Mathf.Rad2Deg;
        //return (transform.forward.x + transform.forward.y) * Mathf.Rad2Deg;
        return (transform.rotation.z) * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}