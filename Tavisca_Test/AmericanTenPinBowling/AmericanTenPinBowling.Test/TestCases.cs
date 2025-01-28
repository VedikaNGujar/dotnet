using AmericanTenPinBowling.BL;
using Xunit;

namespace AmericanTenPinBowling.Test
{
    public class TestCases
    {

        [Fact]
        public void Game_Mix_1()
        {
            BowlingGame game = new BowlingGame();
            game.Strike();
            game.Spare(9);
            game.Spare(5);
            game.OpenFrame(7, 2);
            game.Strike();
            game.Strike();
            game.Strike();
            game.OpenFrame(9, 0);
            game.Spare(8);
            game.FinalFrame(9, 1, 10);

            int endGame = game.CalculateScoreAfterGameEnds();
            Assert.Equal(187, game.FinalScore);
            Assert.Equal(187, endGame);

        }

        [Fact]
        public void Game_Mix_2()
        {
            BowlingGame game = new BowlingGame();
            game.Strike();
            game.Spare(8);
            game.Spare(9);
            game.OpenFrame(8, 0);
            game.Strike();
            game.Strike();
            game.Spare(9);
            game.Spare(9);
            game.Strike();
            game.FinalFrame(10, 9, 1);
            int endGame = game.CalculateScoreAfterGameEnds();

            Assert.Equal(202, game.FinalScore);
            Assert.Equal(202, endGame);

        }

        [Fact]
        public void Game_Mix_3()
        {
            BowlingGame game = new BowlingGame();
            game.Spare(7);
            game.Strike();
            game.Strike();
            game.OpenFrame(8, 1);
            game.Spare(9);
            game.OpenFrame(8, 1);
            game.Strike();
            game.Spare(9);
            game.Spare(8);
            game.FinalFrame(6, 1, 0);
            int endGame = game.CalculateScoreAfterGameEnds();

            Assert.Equal(164, game.FinalScore);
            Assert.Equal(164, endGame);

        }

        [Fact]
        public void Game_Mix_4()
        {
            BowlingGame game = new BowlingGame();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Spare(6);
            game.FinalFrame(10, 10, 10);
            int endGame = game.CalculateScoreAfterGameEnds();

            Assert.Equal(276, game.FinalScore);
            Assert.Equal(276, endGame);

        }

        [Fact]
        public void Game_Mix_AllStrikes()
        {
            BowlingGame game = new BowlingGame();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.Strike();
            game.FinalFrame(10, 10, 10);
            int endGame = game.CalculateScoreAfterGameEnds();

            Assert.Equal(300, game.FinalScore);
            Assert.Equal(300, endGame);

        }

        [Fact]
        public void Game_All_Zeros()
        {
            BowlingGame game = new BowlingGame();
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.OpenFrame(0, 0);
            game.FinalFrame(0, 0, 0);
            int endGame = game.CalculateScoreAfterGameEnds();

            Assert.Equal(0, game.FinalScore);
            Assert.Equal(0, endGame);
        }
    }
}
