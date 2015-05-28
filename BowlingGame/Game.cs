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
            ValidateRoll(pins);
            rolls.Add(pins);
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                }
                else
                {
                    score += FramePins(frameIndex);
                }
                frameIndex += 2;
            }
            return score;
        }

        private void ValidateRoll(int pins)
        {
            if (rolls.Count % 2 > 0 && rolls.Count < 20)
            {
                if (rolls[rolls.Count - 1] + pins > 10)
                {
                    throw new ArgumentException("Only 10 pins can be knocked down in a single frame.");
                }
            }
            if (pins > 10)
            {
                throw new ArgumentException("A single roll cannot knock down more than 10 pins.");
            }
        }

        private int FramePins(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private Boolean IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }
    }
}
