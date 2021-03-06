using Xunit;
using Moq;
using Leap;
using System.Collections.Generic;
using System.Linq;

public class jointsHelper_test {

    [Fact] public void Add() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_j1 = hg.newJoints();
        var dat_j2 = hg.newJoints();

        var exp_j = hg.newJoints();

        var mock_vh = new Mock<IVectorHelper>();
        mock_vh.Setup(m => m.addList( dat_j1.pinky  , dat_j2.pinky  )).Returns( exp_j.pinky  );
        mock_vh.Setup(m => m.addList( dat_j1.ring   , dat_j2.ring   )).Returns( exp_j.ring   );
        mock_vh.Setup(m => m.addList( dat_j1.middle , dat_j2.middle )).Returns( exp_j.middle );
        mock_vh.Setup(m => m.addList( dat_j1.index  , dat_j2.index  )).Returns( exp_j.index  );
        mock_vh.Setup(m => m.addList( dat_j1.thumb  , dat_j2.thumb  )).Returns( exp_j.thumb  );
        mock_vh.Setup(m => m   .add( dat_j1.palm   , dat_j2.palm   )).Returns( exp_j.palm   );

        JointsHelper jh = new JointsHelper(mock_vh.Object);
        var act_j = jh.add(dat_j1, dat_j2);

        mock_vh.Verify(m => m.addList( dat_j1.pinky  , dat_j2.pinky  ), Times.Once());
        mock_vh.Verify(m => m.addList( dat_j1.ring   , dat_j2.ring   ), Times.Once());
        mock_vh.Verify(m => m.addList( dat_j1.middle , dat_j2.middle ), Times.Once());
        mock_vh.Verify(m => m.addList( dat_j1.index  , dat_j2.index  ), Times.Once());
        mock_vh.Verify(m => m.addList( dat_j1.thumb  , dat_j2.thumb  ), Times.Once());
        mock_vh.Verify(m => m   .add( dat_j1.palm   , dat_j2.palm   ), Times.Once());

        test.jointsEqual(exp_j, act_j);
    }

    [Fact] public void Sub() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_j1 = hg.newJoints();
        var dat_j2 = hg.newJoints();

        var exp_j = hg.newJoints();

        var mock_vh = new Mock<IVectorHelper>();
        mock_vh.Setup(m => m.subList(dat_j1.pinky,   dat_j2.pinky)).Returns(exp_j.pinky);
        mock_vh.Setup(m => m.subList(dat_j1.ring,    dat_j2.ring)).Returns(exp_j.ring);
        mock_vh.Setup(m => m.subList(dat_j1.middle,  dat_j2.middle)).Returns(exp_j.middle);
        mock_vh.Setup(m => m.subList(dat_j1.index,   dat_j2.index)).Returns(exp_j.index);
        mock_vh.Setup(m => m.subList(dat_j1.thumb,   dat_j2.thumb)).Returns(exp_j.thumb);
        mock_vh.Setup(m => m.sub(   dat_j1.palm,    dat_j2.palm)).Returns(exp_j.palm);

        JointsHelper jh = new JointsHelper(mock_vh.Object);
        var act_j = jh.sub(dat_j1, dat_j2);

        mock_vh.Verify(m => m.subList(dat_j1.pinky, dat_j2.pinky), Times.Once());
        mock_vh.Verify(m => m.subList(dat_j1.ring, dat_j2.ring), Times.Once());
        mock_vh.Verify(m => m.subList(dat_j1.middle, dat_j2.middle), Times.Once());
        mock_vh.Verify(m => m.subList(dat_j1.index, dat_j2.index), Times.Once());
        mock_vh.Verify(m => m.subList(dat_j1.thumb, dat_j2.thumb), Times.Once());
        mock_vh.Verify(m => m.sub(dat_j1.palm, dat_j2.palm), Times.Once());

        test.jointsEqual(exp_j, act_j);
    }

    [Fact] public void Div_Int() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_j1 = hg.newJoints();
        var dat_f = dg.newInt(100);

        var exp_j = hg.newJoints();

        var mock_vh = new Mock<IVectorHelper>();
        mock_vh.Setup(m => m.divList(dat_j1.pinky,   dat_f)).Returns(exp_j.pinky);
        mock_vh.Setup(m => m.divList(dat_j1.ring,    dat_f)).Returns(exp_j.ring);
        mock_vh.Setup(m => m.divList(dat_j1.middle,  dat_f)).Returns(exp_j.middle);
        mock_vh.Setup(m => m.divList(dat_j1.index,   dat_f)).Returns(exp_j.index);
        mock_vh.Setup(m => m.divList(dat_j1.thumb,   dat_f)).Returns(exp_j.thumb);
        mock_vh.Setup(m => m.div(   dat_j1.palm,    dat_f)).Returns(exp_j.palm);

        JointsHelper jh = new JointsHelper(mock_vh.Object);
        var act_j = jh.div(dat_j1, dat_f);

        mock_vh.Verify(m => m.divList(dat_j1.pinky,  dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.ring,   dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.middle, dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.index,  dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.thumb,  dat_f), Times.Once());
        mock_vh.Verify(m => m.div(dat_j1.palm,      dat_f), Times.Once());

        test.jointsEqual(exp_j, act_j);
    }

    [Fact] public void Div_Float() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_j1 = hg.newJoints();
        var dat_f = dg.newFloat(100);

        var exp_j = hg.newJoints();

        var mock_vh = new Mock<IVectorHelper>();
        mock_vh.Setup(m => m.divList(dat_j1.pinky,   dat_f)).Returns(exp_j.pinky);
        mock_vh.Setup(m => m.divList(dat_j1.ring,    dat_f)).Returns(exp_j.ring);
        mock_vh.Setup(m => m.divList(dat_j1.middle,  dat_f)).Returns(exp_j.middle);
        mock_vh.Setup(m => m.divList(dat_j1.index,   dat_f)).Returns(exp_j.index);
        mock_vh.Setup(m => m.divList(dat_j1.thumb,   dat_f)).Returns(exp_j.thumb);
        mock_vh.Setup(m => m.div(   dat_j1.palm,    dat_f)).Returns(exp_j.palm);

        JointsHelper jh = new JointsHelper(mock_vh.Object);
        var act_j = jh.div(dat_j1, dat_f);

        mock_vh.Verify(m => m.divList(dat_j1.pinky,  dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.ring,   dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.middle, dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.index,  dat_f), Times.Once());
        mock_vh.Verify(m => m.divList(dat_j1.thumb,  dat_f), Times.Once());
        mock_vh.Verify(m => m.div(dat_j1.palm,      dat_f), Times.Once());

        test.jointsEqual(exp_j, act_j);
    }

    [Fact] public void Pow() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_j1 = hg.newJoints();
        var exp_j = hg.newJoints();
        var mock_vh = new Mock<IVectorHelper>();
        mock_vh.Setup(m => m.powList(dat_j1.pinky, 2)).Returns(exp_j.pinky);
        mock_vh.Setup(m => m.powList(dat_j1.ring,  2)).Returns(exp_j.ring);
        mock_vh.Setup(m => m.powList(dat_j1.middle,2)).Returns(exp_j.middle);
        mock_vh.Setup(m => m.powList(dat_j1.index, 2)).Returns(exp_j.index);
        mock_vh.Setup(m => m.powList(dat_j1.thumb, 2)).Returns(exp_j.thumb);
        mock_vh.Setup(m => m.pow( dat_j1.palm, 2)).Returns(exp_j.palm);

        JointsHelper jh = new JointsHelper(mock_vh.Object);
        var act_j = jh.pow(dat_j1, 2);

        mock_vh.Verify(m => m.powList(dat_j1.pinky, 2),Times.Once());
        mock_vh.Verify(m => m.powList(dat_j1.ring,  2),Times.Once());
        mock_vh.Verify(m => m.powList(dat_j1.middle,2),Times.Once());
        mock_vh.Verify(m => m.powList(dat_j1.index, 2),Times.Once());
        mock_vh.Verify(m => m.powList(dat_j1.thumb, 2),Times.Once());
        mock_vh.Verify(m => m.pow( dat_j1.palm, 2),Times.Once());
        test.jointsEqual(act_j,exp_j);
    }

    [Fact] public void LowestJoint() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Hand dat_hand = hg.newHand(hg.newFingerList());

        Vector exp_joint = new Vector(-1, -1, -1);
        dat_hand.Fingers[4].bones[3].NextJoint = exp_joint;

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Vector act_joint = jh.lowestJoint(dat_hand);
    }

    [Fact] public void MinMax() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        (Joints min, Joints max, Joints j) dat;
        dat.j = hg.newJoints();
        dat.min = new Joints(dg.newMinVectors(5), dg.newMinVectors(5), dg.newMinVectors(5), dg.newMinVectors(5), 
        dg.newMinVectors(5), dg.newMinVector(), dg.newFloat(100));
        dat.max = new Joints(dg.newZeroVectors(5), dg.newZeroVectors(5), dg.newZeroVectors(5), dg.newZeroVectors(5), 
        dg.newZeroVectors(5), dg.newZeroVector(), dg.newFloat(100));

        (Joints min, Joints max) exp;
        exp.min = dat.min;
        exp.max = dat.j;

        var vH = new VectorHelper();
        var jH = new JointsHelper(vH);

        var act = jH.minMax(dat.min, dat.max, dat.j);
        test.jointsEqual(exp.min, act.min);
        test.jointsEqual(exp.max, act.max);
    }

    [Fact] public void FingerToVectors() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Finger inp_finger = hg.newFinger(dg.newVectors(5));
        
        Vector[] exp_vL = new Vector[]{
            inp_finger.bones[0].PrevJoint,
            inp_finger.bones[1].PrevJoint,
            inp_finger.bones[2].PrevJoint,
            inp_finger.bones[3].PrevJoint,
            inp_finger.bones[3].NextJoint,
        };

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Vector[] act_vL = jh.fingerToVectors(inp_finger);

        test.vectorsEqual(exp_vL, act_vL);
    }

    [Fact] public void HandToJoints() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        List<Vector[]> dat_vL = new List<Vector[]>(){
            dg.newVectors(5),
            dg.newVectors(5),
            dg.newVectors(5),
            dg.newVectors(5),
            dg.newVectors(5),
        };
        List<Finger> dat_fL = hg.newFingerList(dat_vL);
        Hand dat_hand = hg.newHand(dat_fL);

        Joints exp_joints = new Joints{
            pinky   = dat_vL[0],
            ring    = dat_vL[1],
            middle  = dat_vL[2],
            index   = dat_vL[3],
            thumb   = dat_vL[4],
            palm    = dat_hand.PalmPosition
        };

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Joints act_joints = jh.handToJoints(dat_hand);

        test.jointsEqual(exp_joints, act_joints);
    }

    [Fact] public void greaterEqual() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        
        var dat_j1 = hg.newJoints();
        var dat_f = dg.newFloat(100);
        var exp_j = hg.newJoints();
        var mock_vh = new Mock<IVectorHelper>();
        
        Assert.True(false);
    }

    [Fact] public void greaterEqualList() {
        Assert.True(false);
    }
}