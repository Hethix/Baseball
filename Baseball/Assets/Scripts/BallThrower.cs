using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

    private float ballVelocity;
    public GameObject baseball;
    private GameObject ballClone;

    private bool ballSpawned;
    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        ballVelocity = 5.0f;
        ballSpawned = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (!ballSpawned && Input.GetKeyDown(KeyCode.A)) //Needs to be a button on the controller!!! Will implement when I have the Vive.
        {
            ballSpawned = true;
            coroutine = SpawnTimer(1.0f);
            StartCoroutine(coroutine);
            ballClone = (GameObject) Instantiate(baseball, transform.position, transform.rotation);
            ballClone.GetComponent<Rigidbody>().velocity = transform.up * ballVelocity;
            Debug.Log("Ball spawned");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ballClone.GetComponent<Rigidbody>().velocity = transform.forward * ballVelocity;
            ballClone.GetComponent<BallHandler>().ballBeenHit = true;
            Debug.Log("I Hit the ball");
        }
    }

    
    private IEnumerator SpawnTimer(float time)
    {
        Debug.Log("Started SpawnTimer");
        yield return new WaitForSeconds(time);
        ballSpawned = false;
    } 
}
