using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacingGame
{
    public class Punter
    {
        public string PunterName; //the punter's name
        public Bet MyBetForCar; //an istance of Bet that has his bet
        public int Cash; //how much cash he has

        //punter's control on the form

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdatingLabels()
        {
            MyRadioButton.Text = PunterName + " has " + Cash + " Dollars";
            MyLabel.Text = PunterName + " hasn't place a bet";

            if (Cash == 0)//Code When bettor has no money to bet then it gets destroy
            {
                MyLabel.Text = String.Format("BUSTED");
                MyLabel.ForeColor = System.Drawing.Color.Red;
                MyRadioButton.Enabled = false;
            }

        }

        public void ClearTheBet()
        {
            MyBetForCar.Amount = 0;
            MyBetForCar.Car = 0;
            MyBetForCar.Punter = this;
        }

        public bool PlaceBet(int BetAmount, int CarToWin)
        {
            if (Cash >= BetAmount)
            {
                MyBetForCar.Amount = BetAmount;
                MyBetForCar.Car = CarToWin;
                MyBetForCar.Punter = this;
                return true;
            }
            else return false;
        }

        public void Collect(int winner)
        {
            Cash += MyBetForCar.PayOut(winner);
            this.UpdatingLabels();
        }
    }
}
