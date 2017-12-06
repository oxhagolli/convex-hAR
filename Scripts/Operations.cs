using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Operations : MonoBehaviour {
	//public GameObject ARcamera;
	//public Text text;
	public GameObject[] policemen;


	int gen;
	MeshRenderer meshRenderer;
	Light light;

	// Use this for initialization
	void Start () {
		gen = 0;
		foreach (GameObject police in policemen) {
			gen = Random.Range (0, 2);
			meshRenderer = police.GetComponentsInChildren<MeshRenderer> ()[0];
				meshRenderer.enabled = false;
			police.tag = "Unassigned";
		}

	}
	
	// Update is called once per frame
	void Update () {
		//ARcamera.transform.Translate (-1f, 1f, f);
	}

	public void spawnPolice()
	{
		


		foreach (GameObject police in policemen) {
			gen = Random.Range (0, 2);
			meshRenderer = police.GetComponentsInChildren<MeshRenderer> ()[0];
			if (gen == 1) {
				meshRenderer.enabled = true;
				police.tag = "Police";
			} else {
				meshRenderer.enabled = false;
				police.tag = "Unassigned";
			}
		}

		GameObject[] thugs = GameObject.FindGameObjectsWithTag("Thug");
		foreach (GameObject thug in thugs) {
			light = thug.GetComponentsInChildren<Light> ()[0];
			light.enabled = false;
		}
	}
		

	public void Up()
	{
		Camera.main.transform.Translate (Vector3.up*10);
	}

	public void Down()
	{
		Camera.main.transform.Translate (Vector3.up*-10);
	}

	public void Left()
	{
		Camera.main.transform.Translate (Vector3.right*-10);
	}

	public void Right()
	{
		Camera.main.transform.Translate (Vector3.right*10);
	}

	public void ZoomIn()
	{
		Camera.main.transform.Translate (Vector3.forward*10);
	}

	public void ZoomOut()
	{
		Camera.main.transform.Translate (Vector3.forward*-10);
	}
		
}
