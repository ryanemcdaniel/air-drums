using System.Collections.Concurrent;
using System.Collections.Generic;
using Global;
using System;

public class Proc_MIDI : IProc {

    private IPort p;
    private ConcurrentQueue<int> commandStream;
    private List<int> noteIDs;
    private List<int> noteOnTimes;
    private Commands comTable;
    private int curID;

    public Proc_MIDI(IPort port, ConcurrentQueue<int> inStream, List<int> noteOn, List<int> timing, Commands commands) {
        p = port;
        commandStream = inStream;
        noteIDs = noteOn;
        noteOnTimes = timing;
        comTable = commands;
    }

    public void Pipeline() {
        if (commandStream.TryDequeue(out curID)) {
            var command = comTable.LookUp(curID);
            if (command == null) {
                Console.Error.WriteLine("error: proc data dispatch midi command null");
                goto wait;
            }

            Console.WriteLine(command[0] + " " + command[1] + " " + command[2]);
            
            if (p.IsCodeNoteOn(command)) {
                noteIDs.Add(curID);
                noteOnTimes.Add(CMD.MIDI_WAIT);
            }

            p.SendMIDI(command);
        }

        wait:   
        System.Threading.Thread.Sleep(10);

        for (int i = 0; i < noteOnTimes.Count; i++) {
            if(noteOnTimes[i]-- == 0) {
                p.SendNoteOff(comTable.LookUp(noteIDs[i]));
                noteIDs.RemoveAt(i);
            }
        }
        noteOnTimes.RemoveAll(time => time <= -1);
    }
}