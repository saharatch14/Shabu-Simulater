using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Matsuri;

public class PlayerController : MonoBehaviour
{
    //public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("QuitTime", "The application last closed at: " + System.DateTime.Now);
    }
}
