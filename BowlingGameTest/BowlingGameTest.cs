using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTest
{
    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void TestRollAllGutterGame()
        {
            Game g = new Game();
            for (int i = 0; i < 20; i++)
            {
                g.Roll(0);
            }
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void TestRollAllOnesGame()
        {
            Game g = new Game();
            for (int i = 0; i < 20; i++)
            {
                g.Roll(1);
            }
            Assert.AreEqual(20, g.Score());
        }
    }
}
