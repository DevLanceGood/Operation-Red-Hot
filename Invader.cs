using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceInvaders
{
    /// <summary>
    /// Summary description for Invader.
    /// </summary>
    public class Invader : GameObject
    {
        private Image OtherImage = null;

        private const int kBombInterval = 200;

        public Bomb TheBomb = new Bomb(0, 0);

        private bool ActiveBomb = false;

        public bool BeenHit = false;

        public int CountExplosion = 0;

        public bool Died = false;

        private int rseed = (int)DateTime.Now.Ticks;
        private Random RandomNumber = null;


        public bool DirectionRight = true;

        private const int kInterval = 10;
        private long Counter = 0;

        public Invader(string bombSpeed, string i1, string i2) : base(i1)
        {

            setBombSpeed = bombSpeed;
            //
            // TODO: Add constructor logic here
            //
            OtherImage = Image.FromFile(i2);
            Color color = Color.Black;
            byte r = color.R;
            Bitmap bmp = new Bitmap(OtherImage);
            Bitmap bmp2 = new Bitmap(TheImage);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color gotcolor = bmp.GetPixel(x, y);
                    gotcolor = Color.FromArgb(r, gotcolor.G, gotcolor.B);
                    bmp.SetPixel(x, y, gotcolor);
                }
            }
            for (int x = 0; x < bmp2.Width; x++)
            {
                for (int y = 0; y < bmp2.Height; y++)
                {
                    Color gotcolor = bmp2.GetPixel(x, y);
                    gotcolor = Color.FromArgb(r, gotcolor.G, gotcolor.B);
                    bmp2.SetPixel(x, y, gotcolor);
                }
            }

            OtherImage = bmp;

            TheImage = bmp2;


            RandomNumber = new Random(rseed);

            Position.X = 20;
            Position.Y = 10;
            UpdateBounds();
        }

        string setBombSpeed;
        public override void Draw(Graphics g)
        {
            TheBomb.setKInterval(setBombSpeed);

            UpdateBounds();

            if (BeenHit)
            {
                DrawExplosion(g);
                return;
            }

            if (Counter % 2 == 0)
                g.DrawImage(TheImage, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);
            else
                g.DrawImage(OtherImage, MovingBounds, 0, 0, ImageBounds.Width, ImageBounds.Height, GraphicsUnit.Pixel);

            if (ActiveBomb)
            {
                TheBomb.Draw(g);
                if (Form1.ActiveForm != null)
                {
                    if (TheBomb.Position.Y > Form1.ActiveForm.ClientRectangle.Height)
                    {
                        ActiveBomb = false;
                    }
                }
            }


            if ((ActiveBomb == false) && (Counter % kBombInterval == 0))
            {
                ActiveBomb = true;
                TheBomb.Position.X = MovingBounds.X + MovingBounds.Width / 2;
                TheBomb.Position.Y = MovingBounds.Y + 5;
            }

        }

        public void SlowBomb()
        {
            //		  TheBomb.TheBombInterval = 2;
        }


        public void ResetBombPosition()
        {
            TheBomb.Position.X = MovingBounds.X + MovingBounds.Width / 2;
            TheBomb.ResetBomb(MovingBounds.Y + 5);
        }

        public void SetCounter(long lCount)
        {
            Counter = lCount;
        }

        public void DrawExplosion(Graphics g)
        {

            if (Died)
                return;

            CountExplosion++;
            if (CountExplosion < 15)
            {
                for (int i = 0; i < 50; i++)
                {
                    int xval = RandomNumber.Next(MovingBounds.Width);
                    int yval = RandomNumber.Next(MovingBounds.Height);
                    xval += Position.X;
                    yval += Position.Y;
                    g.DrawLine(Pens.White, xval, yval, xval, yval + 1);
                }
            }
            else
            {
                Died = true;
            }
        }

        public void Move()
        {
            if (BeenHit)
                return;

            if (DirectionRight)
            {
                Position.X += kInterval;
            }
            else
            {
                Position.X -= kInterval;
            }

            Counter++;
        }

        public void MoveInPlace()
        {
            Counter++;
        }

        public Rectangle GetBombBounds()
        {
            return TheBomb.GetBounds();
        }

        public bool IsBombColliding(Rectangle r)
        {
            if (ActiveBomb && TheBomb.GetBounds().IntersectsWith(r))
            {
                return true;
            }

            return false;
        }

    }
}
