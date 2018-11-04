using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GraphingManager : MonoBehaviour {

	int counter = 0;
	string[] data;
	//public string val = "chw_water";

	private const short MAX_NUMBER_GRAPHS = 8;
	GraphElement[] graphs;	
	GameObject[] graphPrefab;
	public GameObject graphTemplate;

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


	Vector2 mouseLocation;

	// Use this for initialization
	void Start () {

		graphs = new GraphElement[MAX_NUMBER_GRAPHS];
		graphPrefab = new GameObject[MAX_NUMBER_GRAPHS];


		data = (Resources.Load ("data") as TextAsset).text.Split('\n');


		for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {

			graphs[graph] = new GraphElement(getNameOf(graph));
										
			graphPrefab[graph] = Instantiate(graphTemplate) as GameObject; 
			graphPrefab[graph].GetComponent<Transform>().parent = GameObject.Find("Canvas").GetComponent<Transform>();				
			graphPrefab[graph].GetComponent<RectTransform>().position = new Vector2(graphs[graph].positionX, graphs[graph].positionY);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (Input.GetMouseButtonDown(0))
		{
			for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {
	 	
                mouseLocation = Input.mousePosition;
				graphs[graph].over = false;
							
				float xMin = graphs[graph].positionX;
				float xMax = graphs[graph].positionX + graphs[graph].width;
				float yMin = graphs[graph].positionY;
				float yMax = graphs[graph].positionY + graphs[graph].height;
				
                if (clickOn(xMin, xMax, yMin, yMax, mouseLocation, new Vector2(graphs[graph].positionX, graphs[graph].positionY) ))
            	{
					graphs[graph].over = true;	 
				}                   
			}
		}

		if (Input.GetMouseButton(0))
        {
			Vector2 newMouseLocation = Input.mousePosition;		
			for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++)
			{
                		   
				if (graphs[graph].over)
                {
                   	graphs[graph].positionX += -(mouseLocation.x - newMouseLocation.x);
					graphs[graph].positionY += -(mouseLocation.y - newMouseLocation.y);
                }      
			}       
            mouseLocation = newMouseLocation;
        }
			
		for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {
			graphPrefab[graph].GetComponent<RectTransform>().position = new Vector2(graphs[graph].positionX, graphs[graph].positionY);
		 	graphPrefab[graph].GetComponent<RectTransform>().position = new Vector2(graphs[graph].width, graphs[graph].height);

		}
		
	}
    //CHECKS IF CLICK IS WITHIN GIVEN BOUNDS
    public bool clickOn(float xMin, float xMax, float yMin, float yMax, Vector2 mousePosition, Vector2 otherPosition)
    {
        if (mousePosition.x + xMin < otherPosition.x && mousePosition.x + xMax > otherPosition.x) if (mousePosition.y + yMin < otherPosition.y && mousePosition.y + yMax > otherPosition.y) return true;
        return false;
    }

	   public string getNameOf(int value){
        switch (value)
        {
            case 0:
                return "Total";
            case 1:
                return "KL";
            case 2:
                return "COB";
            case 3:
                return "SE1";
            case 4:
                return "SE2";
            case 5:
                return "SSB";
            case 6:
                return "SSM";
            case 7:
                return "SAAC";
            case 8:
                return "Total Sun Power";
        }
		return "";
    }
	
}
