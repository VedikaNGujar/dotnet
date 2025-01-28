using AmericanTenPinBowling.BL;
using System;

namespace AmericanTenPinBowling
{
    class Program
    {
        static void Main(string[] args)
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

            foreach (var frame in game.ListOfFrames)
                Console.WriteLine($"--------------{frame.TotalScore}--------------");

            
            Console.ReadLine();
        }
    }
}
