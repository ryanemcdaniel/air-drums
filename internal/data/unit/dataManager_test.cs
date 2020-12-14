using Xunit;
using Moq;
using Leap;

public class dataManager_test {
    
    [Fact] public void Extract_Single(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_f = hg.newFrame();
        dat_f.Hands[0].IsLeft = false;
        dat_f.Hands[1].IsLeft = true;

        var mock_l = new Mock<IQueues>();
        mock_l.Setup(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond));

        var dm = new DataManager(mock_l.Object, true);

        dm.Extract(dat_f);

        mock_l.Verify(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond), Times.Once());
    }

    [Fact] public void Extract_Multiple(){

        Assert.True(false);
    }

    [Fact] public void Extract_GetsCorrectHands(){
        Assert.True(false);
    }

    [Fact] public void Extract_Clears() {
        Assert.True(false);
    }
}