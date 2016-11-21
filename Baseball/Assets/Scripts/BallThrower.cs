using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

    private float ballVelocity;
    public GameObject baseball;
    private GameObject ballClone;
  
    private bool ballSpawned;
    private IEnumerator coroutine;

    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device;
   

    // Use this for initialization
    void Start () {
        //controller = GetComponent<SteamVR_TrackedObject>();
        ballVelocity = 6.2f;
        ballSpawned = false;
    }

    // Update is called once per frame
    void Update ()
    {
           device = SteamVR_Controller.Input((int)controller.index);

        if (!ballSpawned && device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
                          
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
