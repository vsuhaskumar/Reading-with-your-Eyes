﻿using EyeXFramework;
using System.Runtime.Serialization;
using System.Windows.Forms;
using WMPLib;
using System;

namespace GazeAwareForms
{
    public partial class Page4 : Form
    {
        public Page4()
        {
            InitializeComponent();
            var wordDelay = 305;
            var pageDelay = 1200;
            DoubleBuffered = true;

            Program.EyeXHost.Connect(behaviorMap);

            //  behaviorMap1.Add(panel3, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = 500 });

            behaviorMap.Add(label1, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label2, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label3, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label4, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label5, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label6, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label7, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label8, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label9, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label10, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });
            behaviorMap.Add(label11, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = wordDelay });


            behaviorMap.Add(button1, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = pageDelay });
            behaviorMap.Add(button2, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = pageDelay });
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnGaze(object sender, GazeAwareEventArgs e)
        {

            var label = sender as Label;
            var button = sender as Button;


            var audioURL = "..\\ReadingWithYourEyes\\AudioFiles\\";
            WindowsMediaPlayer myplayer = new WMPLib.WindowsMediaPlayer();


            if (label != null)
            {
                if (e.HasGaze == true)
                {
                    label.ForeColor = System.Drawing.Color.Red;
                    label.BackColor = System.Drawing.Color.Yellow;

                    myplayer.URL = audioURL + label.Text.ToLower() + ".mp3";
                    myplayer.controls.play();
                }
                else
                {
                    label.ForeColor = System.Drawing.Color.Black;
                    label.BackColor = System.Drawing.Color.White;
                    this.BackColor = System.Drawing.Color.White;
                }

            }

            if (button != null)
            {
                if (button.Text == "Back")
                {
                    if (e.HasGaze == true)
                    {
                        button1_Click(sender, e);
                    }
                }
                else if (button.Text == "Next")
                {
                    if (e.HasGaze == true)
                    {
                        button2_Click(sender, e);
                    }
                }

            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            Page3 form = new Page3();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            End form = new End();
            this.Hide();
            form.Show();
        }
    }
}
