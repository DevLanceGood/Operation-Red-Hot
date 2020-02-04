using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceInvaders
{
	/// <summary>
	/// Summary description for Bomb.
	/// </summary>
	public class Bomb : GameObject
	{
		public const int kBombInterval = 5;
		public int TheBombInterval = kBombInterval;
        private bool pause = false;

        public void setKInterval(string speed)
        {
            speed = speed.ToLower();
            if (speed == null || speed == "slow" || speed == "")
            {
                TheBombInterval = 5;
            }
            else if (speed == "medium")
            {
                TheBombInterval = 10;
            }
            else if (speed == "fast")
            {
                TheBombInterval = 15;
            }
        }

        public void manualySetK(int speed)
        {
            TheBombInterval = speed;
        }

        public Bomb(int x, int y)
		{
			ImageBounds.Width = 5;
			ImageBounds.Height = 15;
			Position.X = x;
			Position.Y = y;
		}

        public void setPause(bool pause)
        {
            this.pause = pause;
        }

        public override void Draw(Graphics g)
		{
			UpdateBounds();
			g.FillRectangle(Brushes.White , MovingBounds);
			Position.Y += TheBombInterval;
		}

		public void ResetBomb(int yPos)
		{
		  Position.Y = yPos;
		  TheBombInterval = kBombInterval;
		  UpdateBounds();
		}
	}
}
