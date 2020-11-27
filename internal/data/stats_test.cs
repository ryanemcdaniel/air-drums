using Xunit;

using Moq;
using System.Collections.Generic;
using System.Linq;

public class stats_test {
    
    [Fact]
    public void Sum(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);
        
        Joints exp_sum = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        for (int i = 0; i < dat_len; i++){
            mock_jh.Setup(m => m
            .add(It.IsAny<Joints>(), dat_jL[i]))
            .Returns(exp_sum);
        }

        Stats s = new Stats(mock_jh.Object);
        Joints act_sum = s.sum(dat_jL);

        mock_jh.Verify(m => m.add(It.IsAny<Joints>(), It.IsAny<Joints>()), Times.Exactly(dat_len));
        test.jointsEqual(exp_sum, act_sum);
    }

    [Fact]
    public void Average(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);

        Joints exp_ave = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        for (int i = 0; i < dat_len; i++){
            mock_jh.Setup(m => m
            .add(It.IsAny<Joints>(), dat_jL[i]))
            .Returns(exp_ave);
        }
        mock_jh.Setup(m => m
        .div(exp_ave, dat_len))
        .Returns(exp_ave);
        
        Stats s = new Stats(mock_jh.Object);
        Joints act_ave = s.average(dat_jL);
        
        mock_jh.Verify(m => m.add(It.IsAny<Joints>(), It.IsAny<Joints>()), Times.Exactly(dat_len));
        mock_jh.Verify(m => m.div(exp_ave, dat_len), Times.Once());
        test.jointsEqual(exp_ave, act_ave);
    }

    [Fact]
    public void Range(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);

        Joints exp_range = hg.newJoints();
        Joints exp_min = hg.newJoints();
        Joints exp_max = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        foreach (var j in dat_jL) {
            mock_jh.Setup(m => m.minMax(It.IsAny<Joints>(), It.IsAny<Joints>(), j)).Returns((exp_min, exp_max));
        }
        mock_jh.Setup(m => m.sub(exp_max, exp_min)).Returns(exp_range);

        Stats s = new Stats(mock_jh.Object);
        Joints act_range = s.range(dat_jL);

        foreach (var j in dat_jL) {
            mock_jh.Verify(m => m.minMax(It.IsAny<Joints>(), It.IsAny<Joints>(), j), Times.Once());
        }
        mock_jh.Verify(m => m.sub(exp_max, exp_min), Times.Once());
        test.jointsEqual(exp_range, act_range);
    }
}