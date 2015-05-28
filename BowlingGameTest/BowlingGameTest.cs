using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTest
{
    [TestClass]
    public class BowlingGameTest
    {
        private Game g;

        [TestInitialize]
        public void Initialize()
        {
            g = new Game();
        }

        [TestMethod]
        public void TestRollAllGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void TestRollAllOnesGame()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A single roll cannot knock down more than 10 pins.")]
        public void TestRollGreaterThanTenThrowsException()
        {
            g.Roll(11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Only 10 pins can be knocked down in a single frame.")]
        public void TestFrameRollsMoreThanTenPinsThrowsException()
        {
            RollMany(2, 9);
        }

        [TestMethod]
        public void TestRollSingleSpare()
        {
            RollMany(2, 5);
            g.Roll(1);
            RollMany(17, 0);
            Assert.AreEqual(12, g.Score());
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }
    }
}
