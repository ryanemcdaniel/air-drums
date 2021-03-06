﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using Global;


namespace air_drums
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            NoteOffTime.Text = "centi-sec";

    
        }
        private void OpenConfig(object sender, System.EventArgs e)
        {
            string text;
            var MIDIwords = new List<string[]>();
            string[] MIDIlines;
            OpenFileDialog openFileDialog = new OpenFileDialog();
			if(openFileDialog.ShowDialog() == true)
				text = File.ReadAllText(openFileDialog.FileName);
            else
            {
                text = " ";
            }
            MIDIlines = text.Split("\n");

            for(int i=0; i<MIDIlines.Length-1;i++)
            {
                 MIDIwords.Add(MIDIlines[i].Split(" "));
            }
       
        }
        private void SaveConfig(object sender, System.EventArgs e)
        {
           Console.WriteLine("save config");

        }
        private void DefaultSetup(object sender, System.EventArgs e)
        {
              GBL.DONE_EDITING = true; 

              this.Close();


        }
        private void SubmitSetup(object sender, System.EventArgs e)
        {

                    CMD.LEFT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command1.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_1.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_1.Text, 2));
                
                    CMD.LEFT_TAP_QUAD_2[0] = Convert.ToByte(Convert.ToInt32(command2.Text, 2));
                    CMD.LEFT_TAP_QUAD_2[1] = Convert.ToByte(Convert.ToInt32(data1_2.Text, 2));
                    CMD.LEFT_TAP_QUAD_2[2] = Convert.ToByte(Convert.ToInt32(data2_2.Text, 2));

                    CMD.LEFT_TAP_QUAD_3[0] = Convert.ToByte(Convert.ToInt32(command3.Text, 2));
                    CMD.LEFT_TAP_QUAD_3[1] = Convert.ToByte(Convert.ToInt32(data1_3.Text, 2));
                    CMD.LEFT_TAP_QUAD_3[2] = Convert.ToByte(Convert.ToInt32(data2_3.Text, 2));

                    CMD.LEFT_TAP_QUAD_4[0] = Convert.ToByte(Convert.ToInt32(command4.Text, 2));
                    CMD.LEFT_TAP_QUAD_4[1] = Convert.ToByte(Convert.ToInt32(data1_4.Text, 2));
                    CMD.LEFT_TAP_QUAD_4[2] = Convert.ToByte(Convert.ToInt32(data2_4.Text, 2));

                    CMD.RIGHT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_5.Text, 2));

                    CMD.RIGHT_TAP_QUAD_2[0] = Convert.ToByte(Convert.ToInt32(command6.Text, 2));
                    CMD.RIGHT_TAP_QUAD_2[1] = Convert.ToByte(Convert.ToInt32(data1_6.Text, 2));
                    CMD.RIGHT_TAP_QUAD_2[2] = Convert.ToByte(Convert.ToInt32(data2_6.Text, 2));

                    CMD.RIGHT_TAP_QUAD_3[0] = Convert.ToByte(Convert.ToInt32(command5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_3[1] = Convert.ToByte(Convert.ToInt32(data1_7.Text, 2));
                    CMD.RIGHT_TAP_QUAD_3[2] = Convert.ToByte(Convert.ToInt32(data2_7.Text, 2));

                
                    CMD.RIGHT_TAP_QUAD_4[0] = Convert.ToByte(Convert.ToInt32(command5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_4[1] = Convert.ToByte(Convert.ToInt32(data1_8.Text, 2));
                    CMD.RIGHT_TAP_QUAD_4[2] = Convert.ToByte(Convert.ToInt32(data2_8.Text, 2));

                    GBL.DONE_EDITING = true; 

                    this.Close();



        }
        private void DogFriendlyClick(object sender, System.EventArgs e)
        {

            if(DogFriendlyCheckBox.IsChecked == true)
            {
                GBL.DOG_FRIENDLY = true;
            }
            else
            {
                 GBL.DOG_FRIENDLY = false;
        
            }

        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
            
                if(sender == NoteOffTime)
                {
                    CMD.MIDI_WAIT = Int32.Parse(NoteOffTime.Text);
                    
                }
                
            }
        }
    }
}

