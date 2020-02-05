using System;
using System.Drawing;
using System.IO;

namespace SpaceInvaders
{
    /// <summary>
    /// Summary description for HighScore.
    /// </summary>
    public class Lives
    {
        private int lives = 0;
        public Point Position = new Point(0, 0);
        public Font MyFont = new Font("Compact", 20.0f, GraphicsUnit.Pixel);
        public Lives(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public void Draw(Graphics g)
        {
            if (lives > 0)
            {
                g.DrawString("Lives: " + lives, MyFont, Brushes.RoyalBlue, Position.X, Position.Y, new StringFormat());
            }
        }

        public void setLives(int count)
        {
            lives = count;
        }

    }
}
