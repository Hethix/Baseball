using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Tracker : MonoBehaviour {

    private string filename;
    public float distance;
    private float newDistance;

    private StreamWriter file;

    // Use this for initialization
    void Start () {

        distance = 0f;
        newDistance = 0f;

        filename = System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        if (File.Exists(filename + ".txt"))
        {
            Debug.Log("SHIT EXIST");
            return;
        }

        file = File.CreateText(filename + ".txt");

    }
	
	// Update is called once per frame
	void Update () {

        if(distance != newDistance)
        {
            newDistance = distance;
            file.WriteLine(distance.ToString());
        }
	}


    void OnApplicationQuit()
    {
        file.Close();
    }
}
