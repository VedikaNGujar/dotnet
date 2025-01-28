using System;

namespace AmericanTenPinBowling.BL
{
    public abstract class Frame
    {
        public int FirstBowl { get; set; }
        public int SecondBowl { get; set; }
        public int TotalScore { get; set; }
        public int FrameScore => FirstBowl + SecondBowl;

        public Frame(int FirstBowl, int SecondBowl)
        {
            this.FirstBowl = FirstBowl;
            this.SecondBowl = SecondBowl;
        }
    }

    public class Strike : Frame
    {
        public Strike() : base(10, 0) { }
    }

    public class Spare : Frame
    {
        public Spare(int FirstBowl) : base(FirstBowl, 10 - FirstBowl) { }
    }

    public class OpenFrame : Frame
    {
        public OpenFrame(int FirstBowl, int SecondBowl) : base(FirstBowl, SecondBowl) { }
    }

    public class FinalFrame : Frame
    {
        public int ThirdBowl { get; set; }
        public FinalFrame(int FirstBowl, int SecondBowl, int ThirdBowl) :
            base(FirstBowl, SecondBowl)
        {
            if (FirstBowl + SecondBowl >= 10)
                this.ThirdBowl = ThirdBowl;
        }
    }
}
