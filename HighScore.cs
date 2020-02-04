using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace SpaceInvaders
{
	/// <summary>
	/// Summary description for HighScore.
	/// </summary>
	public class HighScore : Score
	{
		public HighScore(int x, int y) : base(x, y)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void Draw(Graphics g)
		{
				g.DrawString("High Score: " + Count.ToString(), MyFont, Brushes.RoyalBlue, Position.X, Position.Y, new StringFormat());
		}

		public void Write(string name, int theScore)
		{
            StreamReader sr = new StreamReader("highscore.txt");
            List<string> topFiveValues = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                topFiveValues[i] = sr.ReadLine();
            }
            topFiveValues.Add(theScore.ToString() + "," + name + DateTime.Today.ToString("MM/dd/yyyy"));
            for (int i = 0; i < topFiveValues.Count - 1; i++) 
            { 
                int min_idx = i; 
                for (int j = i + 1; j < topFiveValues.Count; j++)
                {
                    if (int.Parse(topFiveValues[j].Split(',')[0]) < int.Parse(topFiveValues[min_idx].Split(',')[0]))
                        min_idx = j;
                }
                string temp = topFiveValues[min_idx]; 
                topFiveValues[min_idx] = topFiveValues[i]; 
                topFiveValues[i] = temp; 
            }
            topFiveValues.RemoveAt(5);
           
			    
			/*Count = Convert.ToInt32(score);
			sr.Close();
			if (Count < theScore)
			{
				Count = theScore;
				StreamWriter sw = new StreamWriter("highscore.txt", false);
				sw.WriteLine(Count.ToString());
				sw.Close();
			}*/
		}

        public void ReadOne()
        {
            if (File.Exists("highscore.txt"))
	        {
	            StreamReader sr = new StreamReader("highscore.txt");
	            string score = sr.ReadLine();
	            Count = Convert.ToInt32(score.Split(',')[0]);
	            sr.Close();
	        }
        }

        public string[] ReadAll()
        {
            string[] rv = new string[5];
            StreamReader sr = new StreamReader("highscore.txt");
            for (int i = 0; i < 5; i++)
            {
                rv[i] = sr.ReadLine();
            }
            return rv;
        }   
	}
}
