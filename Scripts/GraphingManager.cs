using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GraphingManager : MonoBehaviour {

	int counter = 0;
	string[] data;
	//public string val = "chw_water";

	GraphElement[] graphs = new GraphElement[20];	
	
	public GameObject graphPrefab;

	//Time Variable Here
	private const short CHW_TOTAL = 1;
	private const short HW_TOTAL = 2;
	private const short HW_KL = 3;
	private const short CHW_KL = 4;
	private const short HW_COB = 5;
	private const short CHW_COB = 6;
	private const short HW_SE1 = 7;
	private const short CHW_SE1 = 8;
	private const short HW_SE2 = 9;
	private const short CHW_SE2 = 10;
	private const short HW_SSB = 11;
	private const short CHW_SSB = 12;
	private const short HW_SSM = 13;
	private const short CHW_SSM = 14;
	private const short HW_SAAC = 15;
	private const short CHW_SAAC = 16;
	private const short Total_Sunpower_Kwh = 17;
	private const short MAX_NUMBER_GRAPHS = 20;


	// Use this for initialization
	void Start () {
		data = (Resources.Load ("data") as TextAsset).text.Split('\n');


		for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {

			//graphs[graph] = new GraphElement

		}
	}
	
	// Update is called once per frame
	void Update () {
		//read new line csv and plot 
		//print (data[counter++]);
		
		for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {
			


		}


		//createNode(data[counter++].Split[','])
		// "10,20,30,40,50"
		// ==>
		// { "10", "20", "30", 40, 50}
		// data[4] = "40";
	}
	void createNode() {
		
    }

    void connectNodes() {
 
    }
}
