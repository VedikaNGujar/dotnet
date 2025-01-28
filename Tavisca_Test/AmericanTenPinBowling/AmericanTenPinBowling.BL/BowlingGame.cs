using System.Collections.Generic;
using System.Linq;

namespace AmericanTenPinBowling.BL
{
    public class BowlingGame
    {
        public readonly List<Frame> ListOfFrames = new List<Frame>(10);
        public int FinalScore => ListOfFrames.LastOrDefault().TotalScore;

        public void Strike()
        {
            var frame = new Strike();
            ListOfFrames.Add(frame);
            CalculateScoreAfterEachBowl(frame);
        }

        public void Spare(int pinsBowledOut)
        {
            var frame = new Spare(pinsBowledOut);
            ListOfFrames.Add(frame);
            CalculateScoreAfterEachBowl(frame);
        }

        public void OpenFrame(int firstBowl, int secondBowl)
        {
            var frame = new OpenFrame(firstBowl, secondBowl);
            ListOfFrames.Add(frame);
            CalculateScoreAfterEachBowl(frame);
        }

        public void FinalFrame(int firstBowl, int secondBowl, int thirdBowl)
        {
            var frame = new FinalFrame(firstBowl, secondBowl, thirdBowl);
            ListOfFrames.Add(frame);
            CalculateScoreAfterEachBowl(frame);
        }


        /// <summary>
        /// Calculates Score after all bowling is done
        /// that is when game ends
        /// </summary>
        /// <returns></returns>
        public int CalculateScoreAfterGameEnds()
        {
            int totalScore = 0;
            var frame = ListOfFrames;
            for (int i = 0; i < 10; i++)
            {
                if (frame[i] is Strike)
                {
                    int bonus = 0;

                    if (frame[i + 1] is Strike && frame[i + 2] is Strike) bonus = 10;
                    if (frame[i + 1] is Strike) bonus = frame[i + 2].FirstBowl;

                    totalScore = totalScore + frame[i].FrameScore + frame[i + 1].FrameScore + bonus;
                }
                else if (frame[i] is Spare)
                {
                    totalScore = totalScore + frame[i].FrameScore + frame[i + 1].FirstBowl;
                }
                else
                {
                    if (frame[i] is FinalFrame)
                    {
                        var f = frame[i] as FinalFrame;

                        totalScore += frame[i].FrameScore + f.ThirdBowl;
                    }
                    else
                    {
                        totalScore += frame[i].FrameScore;
                    }

                }

            }

            return totalScore;
        }


        /// <summary>
        /// Calculates score after each bowl
        /// </summary>
        /// <param name="frame"></param>
        private void CalculateScoreAfterEachBowl(Frame frame)
        {
            int frameId = ListOfFrames.IndexOf(frame);

            if (frameId == 0)
                ListOfFrames[frameId].TotalScore = ListOfFrames[frameId].FrameScore;
            else if (frameId <= 9)
            {
                if (ListOfFrames[frameId - 1] is Strike)
                {
                    if (frameId - 2 >= 0 && ListOfFrames[frameId - 2] is Strike)
                    {
                        ListOfFrames[frameId - 2].TotalScore += ListOfFrames[frameId].FirstBowl;
                        ListOfFrames[frameId - 1].TotalScore = ListOfFrames[frameId - 2].TotalScore + ListOfFrames[frameId - 1].FrameScore + ListOfFrames[frameId].FrameScore;
                    }
                    else
                    {
                        ListOfFrames[frameId - 1].TotalScore += ListOfFrames[frameId].FrameScore;
                    }
                }
                else if (ListOfFrames[frameId - 1] is Spare)
                {
                    ListOfFrames[frameId - 1].TotalScore += ListOfFrames[frameId].FirstBowl;
                }

                ListOfFrames[frameId].TotalScore = ListOfFrames[frameId - 1].TotalScore + ListOfFrames[frameId].FrameScore;
            }
            if (frame is FinalFrame)
            {
                var f = frame as FinalFrame;
                ListOfFrames[frameId].TotalScore += f.ThirdBowl;
            }
        }

    }
}
