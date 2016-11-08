using UnityEngine;
using System.Collections;

public class BallThrow : MonoBehaviour {

    private float ballVelocity;
    public GameObject baseball;
    private GameObject ballClone;

    private bool ballSpawned;
    private bool ballBeenHit;
    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        ballVelocity = 5.0f;
        ballSpawned = false;

        coroutine = DestroyBall(4.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (!ballSpawned && Input.GetKeyDown(KeyCode.A)) //Needs to be a button on the controller!!! Will implement when I have the Vive.
        {
            ballSpawned = true;
            ballBeenHit = false;
            ballClone = (GameObject) Instantiate(baseball, transform.position, transform.rotation);
            ballClone.GetComponent<Rigidbody>().velocity = transform.up * ballVelocity;
            Debug.Log("Ball spawned");
            StartCoroutine(coroutine);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ballBeenHit = true;
            ballClone.GetComponent<Rigidbody>().velocity = transform.forward * ballVelocity;
            Debug.Log("I Hit the ball");
        }
    }


    private IEnumerator DestroyBall(float time)
    {
        Debug.Log("Started DestroyBalll");
        yield return new WaitForSeconds(time);
        if (ballBeenHit)
        {
            Debug.Log("I am not destroying the ball");
        }
        else
        {
            Debug.Log("Trying to destroy it now");
            ballSpawned = false;
            Destroy(ballClone);
        }
    }
}
