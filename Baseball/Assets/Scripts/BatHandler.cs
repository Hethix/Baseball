using UnityEngine;
using System.Collections;

public class BatHandler : MonoBehaviour {

    public Transform controllerPosition;

    private Vector3 previousPosition;
    private Vector3 velocity;

	// Use this for initialization
	void Start () {
        previousPosition = transform.position;
        transform.position = controllerPosition.position;
        transform.SetParent(controllerPosition);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Velocity of bat: " + velocity + " " + "Velocity magnitude: " + col.relativeVelocity.magnitude); //This will give a number which decides how much vibration we should use
        col.rigidbody.AddRelativeForce(velocity);
    }
}
