using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    private float start;
    private bool isSpawned;
    private int ctr;

	// Use this for initialization
	void Start () {
        GameObject sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere1.transform.position = new Vector3(0, 1, 0);

        GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere2.transform.position = new Vector3(0, 2, -1);

        start = Time.time;

        isSpawned = false;

        ctr = 0;
    }
	
	// Update is called once per frame
	void Update () {
        ctr++;
        if((Time.time - start) >= 1 && (Time.time - start) <= 2)
            // Debug.Log("Time: "+ (Time.time - start)+" Frames: "+ctr+" Rate:"+ (1.0f / Time.deltaTime));
        if ((Time.time - start) >= 1 && isSpawned == false)
        {
            
            isSpawned = true;
            GameObject sphere3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere3.transform.position = new Vector3(0, 3, -2);
        }
    }
}
