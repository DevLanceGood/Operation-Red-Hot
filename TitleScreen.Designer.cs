namespace SpaceInvaders
{
    partial class titlescreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(titlescreen));
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.top5Display = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.bulletSpeedInput = new System.Windows.Forms.ComboBox();
            this.firerateInput = new System.Windows.Forms.ComboBox();
            this.playerSpeedInput = new System.Windows.Forms.ComboBox();
            this.alienColorInput = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.selectProfileLabel = new System.Windows.Forms.TextBox();
            this.selectProfileInput = new System.Windows.Forms.ComboBox();
            this.createProfileInput = new System.Windows.Forms.TextBox();
            this.createProfileLabel = new System.Windows.Forms.TextBox();
            this.createProfileSubmit = new System.Windows.Forms.Button();
            this.updateSettingsSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(495, 321);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(147, 46);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(166, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 46);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Space Invaders";
            // 
            // top5Display
            // 
            this.top5Display.BackColor = System.Drawing.Color.Black;
            this.top5Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.top5Display.ForeColor = System.Drawing.Color.White;
            this.top5Display.Location = new System.Drawing.Point(12, 166);
            this.top5Display.Name = "top5Display";
            this.top5Display.Size = new System.Drawing.Size(229, 155);
            this.top5Display.TabIndex = 2;
            this.top5Display.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(12, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Top 5 Highest Scores";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(495, 92);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(147, 21);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Bullet Speed";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(495, 153);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(147, 21);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "Player Speed";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Black;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(495, 209);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(174, 21);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "Alien\'s Firerate";
            // 
            // bulletSpeedInput
            // 
            this.bulletSpeedInput.DisplayMember = "0";
            this.bulletSpeedInput.FormattingEnabled = true;
            this.bulletSpeedInput.Items.AddRange(new object[] {
            "Fast",
            "Medium",
            "Slow"});
            this.bulletSpeedInput.Location = new System.Drawing.Point(495, 126);
            this.bulletSpeedInput.Name = "bulletSpeedInput";
            this.bulletSpeedInput.Size = new System.Drawing.Size(147, 21);
            this.bulletSpeedInput.TabIndex = 7;
            this.bulletSpeedInput.ValueMember = "0";
            // 
            // firerateInput
            // 
            this.firerateInput.FormattingEnabled = true;
            this.firerateInput.Items.AddRange(new object[] {
            "Fast",
            "Medium",
            "Slow"});
            this.firerateInput.Location = new System.Drawing.Point(495, 238);
            this.firerateInput.Name = "firerateInput";
            this.firerateInput.Size = new System.Drawing.Size(147, 21);
            this.firerateInput.TabIndex = 8;
            // 
            // playerSpeedInput
            // 
            this.playerSpeedInput.FormattingEnabled = true;
            this.playerSpeedInput.Items.AddRange(new object[] {
            "Fast",
            "medium",
            "Slow"});
            this.playerSpeedInput.Location = new System.Drawing.Point(495, 182);
            this.playerSpeedInput.Name = "playerSpeedInput";
            this.playerSpeedInput.Size = new System.Drawing.Size(147, 21);
            this.playerSpeedInput.TabIndex = 9;
            // 
            // alienColorInput
            // 
            this.alienColorInput.FormattingEnabled = true;
            this.alienColorInput.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.alienColorInput.Location = new System.Drawing.Point(495, 294);
            this.alienColorInput.Name = "alienColorInput";
            this.alienColorInput.Size = new System.Drawing.Size(147, 21);
            this.alienColorInput.TabIndex = 11;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Black;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(495, 265);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(174, 21);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "Alien Colors";
            // 
            // selectProfileLabel
            // 
            this.selectProfileLabel.BackColor = System.Drawing.Color.Black;
            this.selectProfileLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectProfileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.selectProfileLabel.ForeColor = System.Drawing.Color.White;
            this.selectProfileLabel.Location = new System.Drawing.Point(278, 92);
            this.selectProfileLabel.Name = "selectProfileLabel";
            this.selectProfileLabel.Size = new System.Drawing.Size(147, 21);
            this.selectProfileLabel.TabIndex = 12;
            this.selectProfileLabel.Text = "Select Profile";
            // 
            // selectProfileInput
            // 
            this.selectProfileInput.DisplayMember = "0";
            this.selectProfileInput.FormattingEnabled = true;
            this.selectProfileInput.Location = new System.Drawing.Point(278, 126);
            this.selectProfileInput.Name = "selectProfileInput";
            this.selectProfileInput.Size = new System.Drawing.Size(147, 21);
            this.selectProfileInput.TabIndex = 13;
            this.selectProfileInput.ValueMember = "0";
            this.selectProfileInput.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // createProfileInput
            // 
            this.createProfileInput.Location = new System.Drawing.Point(278, 183);
            this.createProfileInput.Name = "createProfileInput";
            this.createProfileInput.Size = new System.Drawing.Size(147, 20);
            this.createProfileInput.TabIndex = 14;
            // 
            // createProfileLabel
            // 
            this.createProfileLabel.BackColor = System.Drawing.Color.Black;
            this.createProfileLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.createProfileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.createProfileLabel.ForeColor = System.Drawing.Color.White;
            this.createProfileLabel.Location = new System.Drawing.Point(278, 153);
            this.createProfileLabel.Name = "createProfileLabel";
            this.createProfileLabel.Size = new System.Drawing.Size(147, 21);
            this.createProfileLabel.TabIndex = 15;
            this.createProfileLabel.Text = "Create Profile";
            // 
            // createProfileSubmit
            // 
            this.createProfileSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("createProfileSubmit.BackgroundImage")));
            this.createProfileSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createProfileSubmit.ForeColor = System.Drawing.Color.White;
            this.createProfileSubmit.Location = new System.Drawing.Point(278, 213);
            this.createProfileSubmit.Name = "createProfileSubmit";
            this.createProfileSubmit.Size = new System.Drawing.Size(147, 46);
            this.createProfileSubmit.TabIndex = 16;
            this.createProfileSubmit.Text = "Create";
            this.createProfileSubmit.UseVisualStyleBackColor = true;
            this.createProfileSubmit.Click += new System.EventHandler(this.CreateProfileSubmit_Click);
            // 
            // updateSettingsSubmit
            // 
            this.updateSettingsSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateSettingsSubmit.BackgroundImage")));
            this.updateSettingsSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.updateSettingsSubmit.ForeColor = System.Drawing.Color.White;
            this.updateSettingsSubmit.Location = new System.Drawing.Point(278, 153);
            this.updateSettingsSubmit.Name = "updateSettingsSubmit";
            this.updateSettingsSubmit.Size = new System.Drawing.Size(147, 46);
            this.updateSettingsSubmit.TabIndex = 17;
            this.updateSettingsSubmit.Text = "Update Settings";
            this.updateSettingsSubmit.UseVisualStyleBackColor = true;
            this.updateSettingsSubmit.Click += new System.EventHandler(this.UpdateSettingsSubmit_Click);
            // 
            // titlescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(672, 643);
            this.Controls.Add(this.updateSettingsSubmit);
            this.Controls.Add(this.createProfileSubmit);
            this.Controls.Add(this.createProfileLabel);
            this.Controls.Add(this.createProfileInput);
            this.Controls.Add(this.selectProfileInput);
            this.Controls.Add(this.selectProfileLabel);
            this.Controls.Add(this.alienColorInput);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.playerSpeedInput);
            this.Controls.Add(this.firerateInput);
            this.Controls.Add(this.bulletSpeedInput);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.top5Display);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.Name = "titlescreen";
            this.Text = "titlescreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox top5Display;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox bulletSpeedInput;
        private System.Windows.Forms.ComboBox firerateInput;
        private System.Windows.Forms.ComboBox playerSpeedInput;
        private System.Windows.Forms.ComboBox alienColorInput;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox selectProfileLabel;
        private System.Windows.Forms.ComboBox selectProfileInput;
        private System.Windows.Forms.TextBox createProfileInput;
        private System.Windows.Forms.TextBox createProfileLabel;
        private System.Windows.Forms.Button createProfileSubmit;
        private System.Windows.Forms.Button updateSettingsSubmit;
    }
}