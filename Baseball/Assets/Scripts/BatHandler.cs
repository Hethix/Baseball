using UnityEngine;
using System.Collections;

public class BatHandler : MonoBehaviour {

    public Transform controllerPosition;

	// Use this for initialization
	void Start () {
        transform.position = controllerPosition.position;
        transform.SetParent(controllerPosition);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Velocity magnitude: " + col.relativeVelocity.magnitude); //This will give a number which decides how much vibration we should use
    }
}
