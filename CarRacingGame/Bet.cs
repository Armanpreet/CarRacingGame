using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingGame
{
    public class Bet
    {
        public int Amount; //The amount of cash that was bet
        public int Car; //The number of the car the bet is on
        public Punter Punter; //the Punter who placed the bet

        public string GetTheDescription()
        {
            string description = "";
            description = this.Punter.PunterName + " bets " + this.Amount + " dollars on Car #" + Car;
            return description;
        }

        public int PayOut(int winner)
        {
            if (Car == winner)
            {
                return this.Amount;
            }
            else
            {
                return -this.Amount;
            }
        }
    }
}
