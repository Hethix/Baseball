using UnityEngine;
using System.Collections;

public class BallHandler : MonoBehaviour {

    public bool ballBeenHit;
    private IEnumerator coroutine;
    public GameObject ballThrower;

    // Use this for initialization
    void Start () {
        ballBeenHit = false;

        coroutine = DestroyBall(1.0f);
        StartCoroutine(coroutine);

    }

    // Update is called once per frame
    void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        //ballBeenHit = true;
        Debug.Log("Velocity magnitude: " + col.relativeVelocity.magnitude); //This will give a number which decides how much vibration we should use
    }

    private IEnumerator DestroyBall(float time)
    {
        Debug.Log("Started DestroyBalll");
        yield return new WaitForSeconds(time);
        if (ballBeenHit)
        {
            yield return new WaitForSeconds(time * 5);
            ballThrower = GameObject.Find("BallSpawnPoint");
            ballThrower.GetComponent<Tracker>().distance = Vector3.Distance(ballThrower.GetComponent<Transform>().position, transform.position);
            Debug.Log("Trying to destroy it now");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Trying to destroy it now");
            Destroy(gameObject);
        }
    }
}
