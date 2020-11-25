using Leap;

public class Joints {

    public Joints(){
        pinky       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        ring        =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        middle      =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        index       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        thumb       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        palm        =   new Vector();
        frameRate   =   0;
    }

    public Joints(
        Vector[]    in1,
        Vector[]    in2,
        Vector[]    in3,
        Vector[]    in4,
        Vector[]    in5,
        Vector      in6,
        float       in7
    ){
        pinky   =   in1;
        ring    =   in2;
        middle  =   in3;
        index   =   in4;
        thumb   =   in5;
        palm    =   in6;
        frameRate=  in7;
    }

    public Vector[] pinky;
    public Vector[] ring;
    public Vector[] middle;
    public Vector[] index;
    public Vector[] thumb;
    public Vector   palm;
    public float    frameRate;
}