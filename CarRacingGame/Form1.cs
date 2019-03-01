using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacingGame
{
    public partial class Form1 : Form
    {
        Cars[] CarArray = new Cars[4]; // creates one array of 4 cars objects 
        Punter[] PuntersArray = new Punter[3]; // creates one array of 3 punter objects
        Random MyRandomNumbers = new Random();
        public Form1()
        {
            InitializeComponent();

            settingTheRaceTrack();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cars take starting position
            CarArray[0].CarsStartingPosition();
            CarArray[1].CarsStartingPosition();
            CarArray[2].CarsStartingPosition();
            CarArray[3].CarsStartingPosition();

            //disable race button till the end of the race
            bettingParlor.Enabled = false;

            //start timer
            timer1.Start();
        }

        private void Bets_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                if (PuntersArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    joeBetLabel.Text = PuntersArray[0].MyBetForCar.GetTheDescription();
                }
            }
            else if (bobRadioButton.Checked)
            {
                if (PuntersArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    bobBetLabel.Text = PuntersArray[1].MyBetForCar.GetTheDescription();
                }
            }
            else if (alRadioButton.Checked)
            {
                if (PuntersArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    alBetLabel.Text = PuntersArray[2].MyBetForCar.GetTheDescription();
                }
            }
        }


        private void settingTheRaceTrack()//this funtion is for setting the race track
        {
            joeRadioButton.Checked = true;
            // initialize minimum bet label
            minimumBetLabel.Text = "Minimum Bet : " + numericUpDown1.Minimum.ToString() + " dollars";

            // initialize all 4 elements of the CarArray
            CarArray[0] = new Cars()
            {
                MyPictureBox = Car1,
                CarStartingPosition = Car1.Left,
                TrackLength = pictureBox1.Width - Car1.Width,
                Randomizer = MyRandomNumbers
            };

            CarArray[1] = new Cars()
            {
                MyPictureBox = Car2,
                CarStartingPosition = Car2.Left,
                TrackLength = pictureBox1.Width - Car2.Width,
                Randomizer = MyRandomNumbers
            };

            CarArray[2] = new Cars()
            {
                MyPictureBox = Car3,
                CarStartingPosition = Car3.Left,
                TrackLength = pictureBox1.Width - Car3.Width,
                Randomizer = MyRandomNumbers
            };

            CarArray[3] = new Cars()
            {
                MyPictureBox = Car4,
                CarStartingPosition = Car4.Left,
                TrackLength = pictureBox1.Width - Car4.Width,
                Randomizer = MyRandomNumbers
            };

            //initialize all 3 elements of the GuysArray
            PuntersArray[0] = new Punter()
            {
                PunterName = "Joe",
                MyBetForCar = null,
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };

            PuntersArray[1] = new Punter()
            {
                PunterName = "Bob",
                MyBetForCar = null,
                Cash = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };

            PuntersArray[2] = new Punter()
            {
                PunterName = "Al",
                MyBetForCar = null,
                Cash = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };

            for (int i = 0; i <= 2; i++)
            {
                PuntersArray[i].UpdatingLabels();
                PuntersArray[i].MyBetForCar = new Bet();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (CarArray[i].CarRunning())
                {
                    timer1.Stop();
                    bettingParlor.Enabled = true;
                    i++;
                    MessageBox.Show("Car " + i + " won the race");
                    for (int j = 0; j <= 2; j++)
                    {
                        PuntersArray[j].Collect(i);
                        PuntersArray[j].ClearTheBet();
                    }

                    foreach (Cars car in CarArray)
                    {
                        car.CarsStartingPosition();
                    }
                    break;
                }
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Al";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Cars car in CarArray)
            {
                car.CarsStartingPosition();
            }
            if (joeBetLabel.Text == "BUSTED" && bobBetLabel.Text == "BUSTED" && alBetLabel.Text == "BUSTED")
            {
                settingTheRaceTrack();
                //this part is for assigning the values which is created in punter class
                PuntersArray[0] = new Punter()
                {
                    PunterName = "Joe",
                    MyBetForCar = null,
                    Cash = 50,
                    MyRadioButton = joeRadioButton,
                    MyLabel = joeBetLabel
                };

                PuntersArray[1] = new Punter()
                {
                    PunterName = "Bob",
                    MyBetForCar = null,
                    Cash = 75,
                    MyRadioButton = bobRadioButton,
                    MyLabel = bobBetLabel
                };

                PuntersArray[2] = new Punter()
                {
                    PunterName = "Al",
                    MyBetForCar = null,
                    Cash = 45,
                    MyRadioButton = alRadioButton,
                    MyLabel = alBetLabel
                };

                foreach (Punter punter in PuntersArray)
                {
                    punter.UpdatingLabels();//using the foreach loop for assigning the values of labels for bet
                }
                joeBetLabel.ForeColor = System.Drawing.Color.Black;
                bobBetLabel.ForeColor = System.Drawing.Color.Black;
                alBetLabel.ForeColor = System.Drawing.Color.Black;
                joeRadioButton.Enabled = true;
                bobRadioButton.Enabled = true;
                alRadioButton.Enabled = true;
                numericUpDown1.Value = 1;
                numericUpDown2.Value = 1;

            }
        }
    }
}
