using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

// *********** Space Invaders  ************
// Written by Mike Gold
// Copyright 2001
// ****************************************

namespace SpaceInvaders
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        private const int kNumberOfRows = 5;
        private const int kNumberOfTries = 3;
        private const int kNumberOfShields = 4;

        private long TimerCounter = 0;
        //private long pauseTimerCounter = 0;

        private int TheSpeed = 6;

        private int TheLevel = 0;

        private bool ActiveBullet = false;

        private int _numberOfMen = 3;

        private Lives displayLives;

        private int NumberOfMen
        {
            get
            {
                return _numberOfMen;
            }
            set
            {
                _numberOfMen = value;
                displayLives.setLives(value);
            }
        }
		private Man TheMan = null;
		private Saucer CurrentSaucer = null;
		private bool SaucerStart = false;
		private bool GameGoing = true;
		private Bullet TheBullet = new Bullet(20, 30);
		private Score TheScore = null;
		private HighScore TheHighScore = null;
		private InvaderRow[] InvaderRows = new InvaderRow[6];
		private Shield[] Shields = new Shield[4];
		private InvaderRow TheInvaders = null;
        private Profile profile = null;

        private bool _pause = false;
        private bool pause
        {
            get { return _pause; }
            set
            {
                _pause = value;
                for (int i = 0; i < InvaderRows.Length - 1; i++)
                {
                    InvaderRow row = InvaderRows[i];
                    row.setPause(value);
                }
            }
        }

        private int kSaucerInterval = 400;

		private string CurrentKeyDown = "";
		private string LastKeyDown = "";
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
        private Label label1;
        private Thread oThread = null;

		[DllImport("winmm.dll")]
		public static extern long PlaySound(String lpszName, long hModule, long dwFlags);

        string[] speeds;

		public Form1(string[] array, Profile profile)
		{
            this.profile = profile;
            displayLives = new Lives(ClientRectangle.Left + 190, 50);
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            // reduce flicker

            speeds = array;

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

			InitializeAllGameObjects(true);

			timer1.Start();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void InitializeAllGameObjects(bool bScore)
		{
			InitializeShields();

			InitializeMan();

			if (bScore)
				InitializeScore();

			InitializeInvaderRows(TheLevel);

			CurrentSaucer = new Saucer("saucer0.gif", "saucer1.gif", "saucer2.gif");


			TheScore.GameOver = false;
			GameGoing = true;
			TheSpeed = 6;
		}

		private void InitializeSaucer()
		{
		  CurrentSaucer.Reset();
		  SaucerStart = true;
		}

		private void InitializeMan()
		{
			TheMan = new Man();
            TheMan.setKInterval(speeds[1]);
			TheMan.Position.Y = ClientRectangle.Bottom - 50;
			NumberOfMen = 3;
		}

		private void InitializeScore()
		{
			TheScore = new Score(ClientRectangle.Right - 400, 50);
			TheHighScore = new HighScore(ClientRectangle.Left + 25, 50);
			TheHighScore.Read();
		}

		private void InitializeShields()
		{
			for (int i = 0; i < kNumberOfShields; i++)
			{
			  Shields[i] = new Shield();
			  Shields[i].UpdateBounds();
			  Shields[i].Position.X = (Shields[i].GetBounds().Width + 75) * i + 25;
			  Shields[i].Position.Y = ClientRectangle.Bottom - 
							(Shields[i].GetBounds().Height + 75);
			}
		}

		void InitializeInvaderRows(int level)
		{
          InvaderRows[0] = new InvaderRow(speeds[3], speeds[2], "invader1.gif", "invader1c.gif", 2 + level);
		  InvaderRows[1] = new InvaderRow(speeds[3], speeds[2], "invader2.gif", "invader2c.gif", 3 + level);
		  InvaderRows[2] = new InvaderRow(speeds[3], speeds[2], "invader2.gif", "invader2c.gif", 4 + level);
		  InvaderRows[3] = new InvaderRow(speeds[3], speeds[2], "invader3.gif", "invader3c.gif", 5 + level);
		  InvaderRows[4] = new InvaderRow(speeds[3], speeds[2], "invader3.gif", "invader3c.gif", 6 + level);
		}

		private string m_strCurrentSoundFile = "1.wav";
		public void PlayASound()
		{
			if (m_strCurrentSoundFile.Length > 0)
			{
				PlaySound(Application.StartupPath + "\\" + m_strCurrentSoundFile, 0, 0);
			}
			m_strCurrentSoundFile = "";
			m_nCurrentPriority = 3;
			oThread.Abort();
		}

		int m_nCurrentPriority = 3;
		public void PlaySoundInThread(string wavefile, int priority)
		{
			if (priority <= m_nCurrentPriority)
			{
				m_nCurrentPriority = priority;
				if (oThread != null)
					oThread.Abort();

				m_strCurrentSoundFile = wavefile;
				oThread = new Thread(new ThreadStart(PlayASound));
				oThread.Start();

			}
			
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Restart...";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Exit";
            this.menuItem3.Click += new System.EventHandler(this.Menu_Exit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "\"R\" - Restart | \"P\" - Pause";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(672, 622);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Space Invaders Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new titlescreen());
		}

        //static Timer _pauseTimer;


		private void HandleKeys()
		{
            switch (CurrentKeyDown)
            {
                case "Space":
                    if (!pause)
                    {
                        if (ActiveBullet == false)
                        {
                            TheBullet.Position = TheMan.GetBulletStart();
                            TheBullet.setKInterval(speeds[0]);
                            ActiveBullet = true;
                            PlaySoundInThread("1.wav", 2);
                        }
                    }
                    CurrentKeyDown = LastKeyDown;
                    break;
                case "A":
                    if (!pause)
                    {
                        TheMan.MoveLeft();
                        TheMan.setPause(pause);
                        Invalidate(TheMan.GetBounds());
                        if (timer1.Enabled == false)
                            timer1.Start();
                    }
                    CurrentKeyDown = LastKeyDown;
                    break;
                case "D":
                    if (!pause)
                    {
                        TheMan.MoveRight(ClientRectangle.Right);
                        TheMan.setPause(pause);
                        Invalidate(TheMan.GetBounds());
                        if (timer1.Enabled == false)
                            timer1.Start();
                        CurrentKeyDown = LastKeyDown;
                    }
                    break;
                case "R":
                    if (!pause)
                    {
                        InitializeAllGameObjects(true);
                        TimerCounter = 0;
                        CurrentSaucer.Reset();
                        SaucerStart = false;
                        CurrentKeyDown = LastKeyDown;
                    }
                    break;
                case "P":
                    pause = !pause;
                    CurrentKeyDown = LastKeyDown;
                    break;
                default:
                    break;
            }
		}

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{  
			string result = e.KeyData.ToString();
			CurrentKeyDown = result;
			if (result == "A"  || result == "D")
			{
			  LastKeyDown = result;
			}

//			Invalidate(TheMan.GetBounds());
		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			for (int i = 0; i < kNumberOfShields; i++)
			{
				Shields[i].Draw(g);
			}

//			g.FillRectangle(Brushes.Black, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
			TheMan.Draw(g);
			TheScore.Draw(g);
			TheHighScore.Draw(g);
            displayLives.Draw(g);
			if (ActiveBullet)
			{
			  TheBullet.Draw(g);
			}

			if (SaucerStart)
			{
			  CurrentSaucer.Draw(g);
			}

			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				TheInvaders.Draw(g);
			}

		}

		private int CalculateLargestLastPosition()
		{
			int max = 0;
			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				int nLastPos = TheInvaders.GetLastInvader().Position.X;
				if (nLastPos > max)
					max = nLastPos;
			}

			return max;
		}

		private int CalculateSmallestFirstPosition()
		{
			int min = 50000;

			try
			{
				for (int i = 0; i < kNumberOfRows; i++)
				{
					TheInvaders = InvaderRows[i];
					int nFirstPos = TheInvaders.GetFirstInvader().Position.X;
					if (nFirstPos < min)
						min = nFirstPos;
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}

			return min;

		}

		private void MoveInvaders()
		{
			bool bMoveDown = false;

			for (int i = 0; i < kNumberOfRows; i++)
			{

				TheInvaders = InvaderRows[i];
				TheInvaders.Move();

			}

//			if (InvaderSoundCounter % 5)
				PlaySoundInThread("4.wav", 3);


			if ((CalculateLargestLastPosition()) > ClientRectangle.Width - InvaderRows[4][0].GetWidth())
			{
				TheInvaders.DirectionRight = false;
				SetAllDirections(false);
			}

			if ((CalculateSmallestFirstPosition()) < InvaderRows[4][0].Width/3) 
			{
				TheInvaders.DirectionRight = true;
				SetAllDirections(true);
				for (int i = 0; i < kNumberOfRows; i++)
				{
					bMoveDown = true;
				}
			}

			if (bMoveDown)
			{
				for (int i = 0; i < kNumberOfRows; i++)
				{

					TheInvaders = InvaderRows[i];
					TheInvaders.MoveDown();

				}
			}
		}

		private int TotalNumberOfInvaders()
		{
		  int sum = 0;
			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				sum += TheInvaders.NumberOfLiveInvaders();
			}

			return sum;
		}

		private void MoveInvadersInPlace()
		{
			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				TheInvaders.MoveInPlace();
			}

		}

		private void SetAllDirections(bool bDirection)
		{
				for (int i = 0; i < kNumberOfRows; i++)
				{
					TheInvaders = InvaderRows[i];
				    TheInvaders.DirectionRight = bDirection;
				}

		}

		public int CalcScoreFromRow(int num)
		{
			int nScore = 10;
			switch (num)
			{
				case 0:
					nScore = 30;
					break;
				case 1:
					nScore = 20;
					break;
				case 2:
					nScore = 20;
					break;
				case 3:
					nScore = 10;
					break;
				case 4:
					nScore = 10;
					break;
			}

			return nScore;
		}

		void TestBulletCollision()
		{
			int rowNum = 0;
			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
			    rowNum = i;
				int collisionIndex = TheInvaders.CollisionTest(TheBullet.GetBounds());
			
				if ((collisionIndex >= 0) && ActiveBullet)
				{
					TheInvaders.Invaders[collisionIndex].BeenHit = true;
					TheScore.AddScore(CalcScoreFromRow(rowNum));
					PlaySoundInThread("0.wav", 1);
					
					ActiveBullet = false;
					TheBullet.Reset();
				}

				if (SaucerStart && ActiveBullet && CurrentSaucer.GetBounds().IntersectsWith(TheBullet.GetBounds()))
				{
				   CurrentSaucer.BeenHit = true;
					if (CurrentSaucer.ScoreCalculated == false)
					{
						TheScore.AddScore(CurrentSaucer.CalculateScore());
						CurrentSaucer.ScoreCalculated = true;
						PlaySoundInThread("3.wav", 1);
					}

				}
			}
		}

		void TestForLanding()
		{
			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				if (TheInvaders.AlienHasLanded(ClientRectangle.Bottom))
				{
					TheMan.BeenHit = true;
					PlaySoundInThread("2.wav", 1);
					TheScore.GameOver = true;
					TheHighScore.Write(TheScore.Count);
					GameGoing = false;
				}
			}
		  
		}

		void ResetAllBombCounters()
		{
			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				TheInvaders.ResetBombCounters();
			}
		}

		void TestBombCollision()
		{
			if (TheMan.Died)
			{
			  NumberOfMen --;
				if (NumberOfMen == 0)
				{
					TheHighScore.Write(TheScore.Count);
					TheScore.GameOver = true;
					GameGoing = false;
				}
				else
				{
				  TheMan.Reset();
				  ResetAllBombCounters();
				}
			}

			if (TheMan.BeenHit == true)
				return;

			for (int i = 0; i < kNumberOfRows; i++)
			{
				TheInvaders = InvaderRows[i];
				for (int j = 0; j < TheInvaders.Invaders.Length; j++)
				{
			        for (int k = 0; k < kNumberOfShields; k++)
					{
						bool bulletHole = false;
						if (Shields[k].TestCollision(TheInvaders.Invaders[j].GetBombBounds(), true, out bulletHole))
						{
							TheInvaders.Invaders[j].ResetBombPosition();
							Invalidate(Shields[k].GetBounds());
						}


						if (Shields[k].TestCollision(TheBullet.GetBounds(), false, out bulletHole))
						{
							ActiveBullet = false;
							Invalidate(Shields[k].GetBounds());
							TheBullet.Reset();
						}
					}
				
					if (TheInvaders.Invaders[j].IsBombColliding(TheMan.GetBounds()) )
					{
					  TheMan.BeenHit = true;
					  PlaySoundInThread("2.wav", 1);
					}
				}
			}
		}


		private int nTotalInvaders = 0;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
            HandleKeys();
            if (pause == false)
            {
                TimerCounter++;

                if (GameGoing == false)
                {
                    if (TimerCounter % 6 == 0)
                        MoveInvadersInPlace();
                    Invalidate();
                    return;
                }


                if (TheBullet.Position.Y < 0)
                {
                    ActiveBullet = false;
                }

                if (TimerCounter % kSaucerInterval == 0)
                {
                    InitializeSaucer();
                    PlaySoundInThread("8.wav", 1);
                    SaucerStart = true;
                }

                if (SaucerStart == true)
                {
                    CurrentSaucer.Move();
                    if (CurrentSaucer.GetBounds().Left > ClientRectangle.Right)
                    {
                        SaucerStart = false;
                    }
                }


                if (TimerCounter % TheSpeed == 0)
                {
                    MoveInvaders();

                    nTotalInvaders = TotalNumberOfInvaders();

                    if (nTotalInvaders <= 20)
                    {
                        TheSpeed = 5;
                    }

                    if (nTotalInvaders <= 10)
                    {
                        TheSpeed = 4;
                    }


                    if (nTotalInvaders <= 5)
                    {
                        TheSpeed = 3;
                    }

                    if (nTotalInvaders <= 3)
                    {
                        TheSpeed = 2;
                    }

                    if (nTotalInvaders <= 1)
                    {
                        TheSpeed = 1;
                    }

                    if (nTotalInvaders == 0)
                    {
                        InitializeAllGameObjects(false); // don't initialize score					
                        TheLevel++;
                    }


                }

                TestBulletCollision();
                TestBombCollision();


                Invalidate();
                // move invaders

                // move bullets
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
            //			string result = e.KeyChar.ToString();
            //			Invalidate(TheMan.GetBounds());
		}

		private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			string result = e.KeyData.ToString();
			if (result == "A"  || result == "D")
			{
				LastKeyDown = "";
			}
		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.InitializeAllGameObjects(true);
			TheLevel = 0;
		}

		private void Menu_Exit(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
        /*
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            InitializeAllGameObjects(true);
            TimerCounter = 0;
            CurrentSaucer.Reset();
            SaucerStart = false;
        }

        private void BtnPause_Click(object sender, KeyPressEventArgs e)
        {
            pause = !pause;
        }
        */
    }
}
