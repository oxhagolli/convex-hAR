using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] police = GameObject.FindGameObjectsWithTag("Jiggles");
        Debug.Log(convexHull(police).Length);
	}
	
	// Update is called once per frame
	void Update () {
		
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
        foreach (GameObject p in points)
        {
            foreach (GameObject q in points)
            {
                if (p == q)
                    continue;
                bool valid = true;

                foreach (GameObject r in points)
                {
                    if (r == p || r == q)
                        continue;
                    if (orientation(p, q, r) == 2)
                        valid = false;
                }

                if (valid)
                    hull.Add(p);
            }
        }
        return hull.ToArray();
    }

}
