using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

    private float ballVelocity;
    public GameObject baseball;
    private GameObject ballClone;
  
    private bool ballSpawned;
    private IEnumerator coroutine;

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;


    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
        ballVelocity = 8.0f;
        ballSpawned = false;
    }

    // Update is called once per frame
    void Update ()
    {
        

        if (!ballSpawned && device.GetPress(triggerButton) ) //Needs to be a button on the controller!!! Will implement when I have the Vive.
        {
            Debug.Log("Trigger Pressed");
                
            coroutine = SpawnTimer(1.0f);
            StartCoroutine(coroutine);
            ballClone = (GameObject) Instantiate(baseball, transform.position, transform.rotation);
            ballClone.GetComponent<Rigidbody>().velocity = transform.up * ballVelocity;
            ballSpawned = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ballClone.GetComponent<Rigidbody>().velocity = transform.forward * ballVelocity;
            ballClone.GetComponent<BallHandler>().ballBeenHit = true;
        }
    }

    
    private IEnumerator SpawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        ballSpawned = false;
    }
}
