using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private List<int> rolls = new List<int>();

        public void Roll(int pins)
        {
            if (pins > 10)
            {
                throw new ArgumentException("A single roll cannot knock down more than 10 pins.");
            }
            rolls.Add(pins);
        }

        public int Score()
        {
            int score = 0;
            for (int i = 0; i < rolls.Count; i++)
            {
                score += rolls[i];
            }
            return score;
        }
    }
}
