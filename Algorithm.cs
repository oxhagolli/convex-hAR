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
