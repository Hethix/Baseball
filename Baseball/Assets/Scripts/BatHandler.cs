using UnityEngine;
using System.Collections;

public class BatHandler : MonoBehaviour {

    //public GameObject controllerPosition;

    private Vector3 previousPosition;
    private Vector3 velocity;
    public GameObject lastBall;

    public SteamVR_TrackedObject controller;

    public bool haptic1;
    public bool haptic2;
    private IEnumerator coroutine;
    private bool vibrate;
    private ushort vibrateAmount;

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
        vibrateAmount = 2000;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        if (vibrate)
        {
            SteamVR_Controller.Input((int)controller.index).TriggerHapticPulse(vibrateAmount);
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "ball")
        {
            lastBall = col.gameObject;
            Vector3 collisionNormal = col.contacts[0].normal;
            collisionNormal = -collisionNormal.normalized;
            lastBall.GetComponent<Rigidbody>().AddForce((velocity + collisionNormal) * 100.0f);

            //Detecting how much vibration we should give
            if(col.relativeVelocity.magnitude > 10.0f)
            {
                vibrateAmount = 3999;
            } else if(col.relativeVelocity.magnitude < 2.0f)
            {
                vibrateAmount = 1333;
            } else
            {
                vibrateAmount = 2666;
            }

            //The two vibrate methods 1: Vive controller vibration
            if (haptic1)
            {
                vibrate = true;
                coroutine = VibrateTimer(0.05f);
                StartCoroutine(coroutine);
            }
            else if (haptic2) //2: Haptuator
            {
                //Doo high fidel vibration here
            }
            Debug.Log("Velocity of bat: " + velocity + " " + "Velocity magnitude: " + col.relativeVelocity.magnitude); //This will give a number which decides how much vibration we should use
        }
    }

    private IEnumerator VibrateTimer(float time)
    {
        yield return new WaitForSeconds(time);
        vibrate = false;
    }

    
}
