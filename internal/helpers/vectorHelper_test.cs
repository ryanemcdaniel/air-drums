using Xunit;
using Leap;

public class vectorHelper_test{

    [Fact]
    public void Substract_Passes(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector(); 
        Vector v2 = dg.newVector();

        Vector exp = new Vector{
            x = v1.x - v2.x,
            y = v1.y - v2.y,
            z = v1.z - v2.z
        };

        VectorHelper v = new VectorHelper();
        Vector act = v.subtract(v1, v2);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Data_Vec_Velocity_Passes(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector(); 
        Vector v2 = dg.newVector();
        float frameRate = dg.newFloat(100);

        Vector exp = new Vector{
            x = (v1.x - v2.x) / frameRate,
            y = (v1.y - v2.y) / frameRate,
            z = (v1.z - v2.z) / frameRate
        };

        VectorHelper vec = new VectorHelper();
        Vector act = vec.velocity(v1, v2, frameRate);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Data_Vec_Average_Passes(){
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] vL = dg.newVectorList(len);

        Vector exp = new Vector(0,0,0);
        for(int i = 0; i < len; i++){
            exp.x += vL[i].x;
            exp.y += vL[i].y;
            exp.z += vL[i].z;
        }
        exp.x /= (float) len;
        exp.y /= (float) len;
        exp.z /= (float) len;

        VectorHelper vh = new VectorHelper();
        Vector act = vh.average(vL);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Data_Vec_Lowest_Passes(){
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] input = dg.newVectorList(len);
        
        Vector exp = input[0];
        foreach (Vector v in input) {
            if(v.y < exp.y){
                exp.x = v.x;
                exp.y = v.y;
                exp.z = v.z;
            }
        }

        VectorHelper vh = new VectorHelper();
        Vector act = vh.lowest(input);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Data_Vec_Greater_Passes(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector();
        Vector v2 = dg.newVector();
        float[] f1 = v1.ToFloatArray();
        float[] f2 = v2.ToFloatArray();
        char[] mode = {'x', 'y', 'z'};
        bool[] act = new bool[3];
        VectorHelper vh = new VectorHelper();
        for(int i = 0; i < act.Length; i++) act[i] = vh.greater(v1, v2, mode[i]);
        for(int i = 0; i < act.Length; i++) Assert.Equal(f1[i] > f2[i], act[i]);
    }
    
}