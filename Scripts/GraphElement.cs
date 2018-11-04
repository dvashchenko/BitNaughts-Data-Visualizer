public class GraphElement
{   
    string xAxisName;
    string yAxisName;
    int xAxisMax;
    int yAxisMax;
    int numberOfXPoints;
    int numOfPoints; 

    public GraphElement(string xName, string yName){
        this.xAxisName = xName;
        this.yAxisName = yName;
        
    }

    public GraphElement(string xName, string yName, int xMax, int yMax){
    //    this.xAxisMax = xName;
    //    this.yAxisMax = yName;
        this.xAxisMax = xMax;
        this.yAxisMax = yMax;
        this.numOfPoints = (xMax/15);
        float[] points = new float[numOfPoints]; 
    }

    public int createNode(int val){
        numberOfXPoints ++;
        if(val > yAxisMax) {
            yAxisMax = val;             
        }
        
        points[numberOfXPoints%numOfPoints] = val;
        
        return yAxisMax;            
    }
    
    public void createLine(){

    }
}