using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cHullAlgo : MonoBehaviour {

	public ParticleSystem fire;
	static int current;
	Light light;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void generateHull()
	{
		GameObject[] police = GameObject.FindGameObjectsWithTag("Police");
		Debug.Log("Hull Points: "+convexHull(police).Length);
		GameObject[] cops = convexHull (police);
		int len = cops.Length;
		float xInc, zInc;


		fire.transform.position = cops [current].transform.position;
		Debug.Log ("i value: " + current+" Position: "+fire.transform.position);
			xInc = (cops [(current + 1) % len].transform.position.x - cops[current].transform.position.x)/10;
			zInc = (cops [(current + 1) % len].transform.position.z - cops[current].transform.position.z)/10;
			for (int j = 0; j < 10; j++) {
				fire.transform.position = fire.transform.position + new Vector3(xInc,0f,zInc);
		}
		current = (current + 1) % len;
	}

	public void catchThug()
	{
		GameObject[] police = GameObject.FindGameObjectsWithTag("Police");
		GameObject[] cops = convexHull (police);
		GameObject[] thugs = GameObject.FindGameObjectsWithTag("Thug");

		foreach (GameObject thug in thugs) {
			light = thug.GetComponentsInChildren<Light> ()[0];
			if (inside (thug, cops)) {
				light.enabled = true;
			}
		}
	}

	public bool inside(GameObject thug, GameObject[] cops)
	{
		float val = 0;
		for (int i = 0; i < cops.Length; i++) {
			float x1 = cops [i].transform.position.x;
			float x2 = cops [(i+1)%cops.Length].transform.position.x;
			float z1 = cops [i].transform.position.z;
			float z2 = cops [(i+1)%cops.Length].transform.position.z;
			float x = thug.transform.position.x;
			float z = thug.transform.position.z;

			val = (z2 - z1) * (x - x2) - (x2 - x1) * (z - z2);


			if (val > 0) {
				Debug.Log ("Value: " + val+"Thug:"+thug.name+"Cops: "+cops[i].name+", "+cops[(i+1)%cops.Length].name);
				return false;
			}
		}
		return true;
	}
		

	int orientation(GameObject p, GameObject q, GameObject r)
	{
		Vector3 pVec = p.GetComponent<Transform>().position;
		Vector3 qVec = q.GetComponent<Transform>().position;
		Vector3 rVec = r.GetComponent<Transform>().position;

		float val = (qVec.z - pVec.z) * (rVec.x - qVec.x) - (qVec.x - pVec.x) * (rVec.z - qVec.z);

		if (val > 0)
			return 1;
		else if (val < 0)
			return 2;
		else
			return 0;
	}

	GameObject[] convexHull(GameObject[] points)
	{
		List<GameObject> hull = new List<GameObject>();

		int minx = 0;
		for (int i = 0; i < points.Length; i++)
		{
			if (points[i].GetComponent<Transform>().position.x < points[minx].GetComponent<Transform>().position.x)
				minx = i;
		}

		int p = minx;
		int q = 0;

		while(true)
		{
			hull.Add(points[p]);
			q = (p + 1) % points.Length;

			for (int i = 0; i < points.Length; i++)
			{
				if (orientation(points[p], points[i], points[q]) == 2)
					q = i;
			}
			p = q;
			if (p == minx)
				break;
		}
		return hull.ToArray();
	}

}
