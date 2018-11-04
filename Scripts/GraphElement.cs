using System;

public class GraphElement
{   
    public bool over; //for dragging
    public float positionX;
    public float positionY;
    public float width;
    public float height;
    string graphTitle;
    string xAxisName;
    string yAxisName;
    int xAxisMax;
    int yAxisMax;
    int numberOfXPoints;
    float[] points; 
    const int numOfPoints = 50;
    const int positionMin = 0;
    const int positionMax = 1500;
    const int heightMax = 1000;
    const int heightMin = 300;
    Random r = new Random();
    
    public GraphElement(){
        this.xAxisName = "Time";
        this.yAxisName = "Value";
        this.positionX = r.Next(positionMin, positionMax);
        this.positionY = r.Next(positionMin, positionMax);
        this.height = r.Next(heightMin, heightMax);
        this.width = r.Next(heightMin, heightMax);
        float[] points = new float[numOfPoints];
    }

    public GraphElement(string graphTitle,string yName = "Value", string xName = "Time"){
        this.xAxisName = xName;
        this.yAxisName = yName;
        this.graphTitle = graphTitle;   
        this.positionX = r.Next(positionMin, positionMax);
        this.positionY = r.Next(positionMin, positionMax);
        this.height = r.Next(heightMin, heightMax);
        this.width = r.Next(heightMin, heightMax);
        float[] points = new float[numOfPoints];
    }

    public GraphElement(string xName, string yName, int xMax, int yMax){
        this.xAxisName = xName;
        this.yAxisName = yName;
        this.xAxisMax = xMax;
        this.yAxisMax = yMax;
        float[] points = new float[numOfPoints]; 
    }

    public float[] addPoint(int val){
        points[numberOfXPoints++ % numOfPoints] = val;

        if(val > yAxisMax) {
            yAxisMax = val;             
        }   
        return points;            
    }
}