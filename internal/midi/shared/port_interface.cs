

public interface IPort {
    public void sendMIDI(byte[] midiCode);
    
    public void playNote();

    public void playNote2();

    public void play();

    public void pause();
    public void closePort();
}