using System.Collections.Generic;

public class Stats : IStats {

    private IJointsHelper jh;

    public Stats(IJointsHelper jointsHelper) {
        jh = jointsHelper;
    }

    public Joints sum(List<Joints> jL){
        Joints ret = new Joints();
        foreach (Joints j in jL){
            ret = jh.add(ret, j);
        }
        return ret;
    }

    public Joints average(List<Joints> jL) {
        return jh.div(sum(jL), jL.Count);
    }

    public Joints range(List<Joints> jL){
        (var min, var max) = (jL[0].Clone(), jL[0].Clone());
        foreach (var j in jL) {
            (min, max) = jh.minMax(min, max, j);
        }
        return jh.sub(max, min);
    }

    public Joints variance(List<Joints> jL){
        var ave = average(jL);
        var num = new List<Joints>();
        foreach (var j in jL){
            num.Add(jh.pow(jh.sub(j, ave),2));
        }
        return jh.div(sum(num), jL.Count -1);
    }
    
}