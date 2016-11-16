using UnityEngine;
using System.Collections;

public class BallThrower2 : MonoBehaviour
{
    SteamVR_Controller.Device device;
    public SteamVR_TrackedObject controller;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) //Needs to be a button on the controller!!! Will implement when I have the Vive.
        {
            Debug.Log("Trigger Pressed");
        }
    }
}