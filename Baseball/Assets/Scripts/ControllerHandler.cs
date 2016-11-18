using UnityEngine;
using System.Collections;

public class ControllerHandler : MonoBehaviour {


    public GameObject bat;

	// Use this for initialization
	void Start () {
        bat.GetComponent<Transform>().position = transform.position;
        GetComponent<FixedJoint>().connectedBody = bat.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
