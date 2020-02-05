using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceInvaders
{
	/// <summary>
	/// Summary description for Bullet.
	/// </summary>
	public class Bullet : GameObject
	{
		const int kBulletInterval = 20;
        public int BulletInterval = kBulletInterval;

        public void setKInterval(string speed)
        {
            speed = speed.ToLower();
            if (speed == null || speed == "slow" || speed == "")
            {
                BulletInterval = 20;
            }
            else if (speed == "medium")
            {
                BulletInterval = 30;
            }
            else if (speed == "fast")
            {
                BulletInterval = 40;
            }
        }

        public Bullet(int x, int y)
		{
			ImageBounds.Width = 5;
			ImageBounds.Height = 15;
			Position.X = x;
			Position.Y = y;
		}

		public void Reset()
		{
			if (Form1.ActiveForm != null)
			{
				Position.Y = Form1.ActiveForm.ClientRectangle.Bottom;
				MovingBounds.Y = Position.Y;
			}

			BulletInterval = kBulletInterval;
		}

        /*
		public void Slow()
		{
//		  BulletInterval = 3;
		}
        */


		public override void Draw(Graphics g)
		{
			UpdateBounds();
			g.FillRectangle(Brushes.Chartreuse , MovingBounds);
			Position.Y -= BulletInterval / 2; // Yeah we dont need sanic
		}

	}
}
