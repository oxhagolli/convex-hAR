using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    private float currentTime;
    private float startTime;
    private float rotVal;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime = Time.time - startTime;
        if (Time.deltaTime * 18 <= 360)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * 18);
        }
	}
}
