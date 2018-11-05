using System;

public class GraphElement
{   
    public bool over; //for dragging
    public float positionX;
    public float positionY;
    public float width;
    public float height;
    public string graphTitle;
    public string xAxisName;
    string yAxisName;
    float xAxisMax;
    public float yAxisMax;
    public float[] points; 
    int numOfPoints = 30;
    const int positionMin = 0;
    const int positionMax = 1500;
    const int heightMax = 1000;
    const int heightMin = 300;
    Random r = new Random();
    
    public GraphElement(string graphTitle,string yName = "Value", string xName = "Time"){
        numOfPoints = GraphingManager.MAX_NUMBER_POINTS;
        this.positionX = r.Next(positionMin,positionMax);
        this.positionY = r.Next(positionMin,positionMax);
        this.width = r.Next(heightMin,heightMax);
        this.height = r.Next(heightMin,heightMax);
        this.xAxisName = "Time";
        this.yAxisName = "Values";
        this.graphTitle = graphTitle;  
        
        points = new float[numOfPoints];
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i] = 100f;                            
        } 
    }

    public float[] addPoint(float val){
        for(int i = 0; i < numOfPoints - 1; i++)
        {
            points[i] = points[i+1];
        }
        points[numOfPoints - 1] = val;
        
        if(val > yAxisMax) 
        {
            yAxisMax = val;             
        }
        points[numOfPoints - 1 ] *= height / yAxisMax ;

        return points;            
    }
}