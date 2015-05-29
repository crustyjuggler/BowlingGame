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
            RollSpare();
            g.Roll(1);
            RollMany(17, 0);
            Assert.AreEqual(12, g.Score());
        }

        [TestMethod]
        public void TestRollTwoSpares()
        {
            RollSpare();
            RollSpare();
            g.Roll(1);
            RollMany(15, 0);
            Assert.AreEqual(27, g.Score());
        }

        [TestMethod]
        public void TestRollSpareInFinalFrame()
        {
            RollMany(18, 0);
            RollSpare();
            g.Roll(1);
            Assert.AreEqual(11, g.Score());
        }

        [TestMethod]
        public void TestRollSingleStrike()
        {
            RollStrike();
            RollMany(2, 1);
            RollMany(16, 0);
            Assert.AreEqual(14, g.Score());
        }

        [TestMethod]
        public void TestRollTwoStrikes()
        {
            RollStrike();
            RollStrike();
            RollMany(2, 1);
            RollMany(14, 0);
            Assert.AreEqual(35, g.Score());
        }

        [TestMethod]
        public void TestRollStrikeInFinalFrame()
        {
            RollMany(18, 0);
            RollStrike();
            RollMany(2, 1);
            Assert.AreEqual(12, g.Score());
        }

        [TestMethod]
        public void TestRollPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, g.Score());
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void RollSpare()
        {
            RollMany(2, 5);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }
    }
}
