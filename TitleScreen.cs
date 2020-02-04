using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class titlescreen : Form
    {
        private ProfileHandler profileHandler = new ProfileHandler();
        private Profile _selectedProfile = null;
        private Profile selectedProfile
        {
            get { return _selectedProfile; }
            set
            {
                _selectedProfile = value;
                Console.WriteLine(value);
                if (value != null)
                {
                    updateSettingsSubmit.Show();
                }
                else
                {
                    updateSettingsSubmit.Hide();
                }
            }
        }
        private List<Profile> profiles = null;
        private bool _showCreateForm = false;
        private bool showCreateForm
        {
            get { return _showCreateForm; }
            set
            {
                _showCreateForm = value;
                if (value)
                {
                    createProfileInput.Show();
                    createProfileLabel.Show();
                    createProfileSubmit.Show();
                }
                else
                {
                    createProfileInput.Hide();
                    createProfileLabel.Hide();
                    createProfileSubmit.Hide();
                }
            }
        }
        public titlescreen()
        {
            InitializeComponent();
            profiles = profileHandler.getProfilesList();
            selectedProfile = null;
            foreach (Profile profile in profiles)
            {
                selectProfileInput.Items.Add(profile.id);
            }
            selectProfileInput.Items.Add("Create Profile");
            showCreateForm = false;
            setGameOptions("Medium", "Medium", "Medium", "Red");
            selectProfileInput.SelectedIndex = 0;

        }

        private int getIndexOfOption(string option, string[] options)
        {
            for (int i=0; i<options.Length; i++)
            {
                if (option.ToLower() == options[i].ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        private void setGameOptions(string bullet, string player, string firerate, string color)
        {
            string[] speeds = new string[] { "Fast", "Medium", "Slow" };
            string[] colors = new string[] { "Red", "Green", "Blue" };
            bulletSpeedInput.SelectedIndex = getIndexOfOption(bullet, speeds);
            playerSpeedInput.SelectedIndex = getIndexOfOption(player, speeds);
            firerateInput.SelectedIndex = getIndexOfOption(firerate, speeds);
            alienColorInput.SelectedIndex = getIndexOfOption(color, colors);
        }

        private void setGameOptions(Profile profile)
        {
            setGameOptions(profile.bulletSpeed, profile.playerSpeed, profile.alienFirerate, profile.alienColor);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // grabs the speed of bullet, player, and firerate of the bombs. Array order is, {bullet speed, player speed, bomb firerate, alien color}
            string[] speeds = new string[4] {bulletSpeedInput.Text, playerSpeedInput.Text, firerateInput.Text, alienColorInput.Text};
            
            //create the game window, (speeds) gets sent to Form1 so it can access the data
            Form1 game = new Form1(speeds, selectedProfile);

            //hide the title screen
            this.Hide();
            //display the game window
            game.ShowDialog();
            //close the title screen
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = selectProfileInput.SelectedItem.ToString();
            int optionsLength = selectProfileInput.Items.Count;
            int itemIndex = selectProfileInput.SelectedIndex;
            if (itemIndex == optionsLength - 1 || optionsLength == 0) // If this is the create option, show create form.
            {
                showCreateForm = true;
                selectedProfile = null;
                setGameOptions("Medium", "Medium", "Medium", "Red");
            }
            else if (profileHandler.profileExists(itemName)) // If valid profile is selected
            {
                string id = itemName;
                selectedProfile = profileHandler.getProfileFromID(id);
                showCreateForm = false;
                setGameOptions(selectedProfile);
            }
        }
        private void setDropdownToID(string id)
        {
            selectProfileInput.Items.Clear();
            int newIndex = 0;
            for (int i = 0; i < profiles.Count; i++)
            {
                Profile profile = profiles[i];
                selectProfileInput.Items.Add(profile.id);
                if (profile.id == id)
                {
                    newIndex = i;
                }
            }
            selectProfileInput.Items.Add("Create Profile");
            selectProfileInput.SelectedIndex = newIndex;
        }
        private void CreateProfileSubmit_Click(object sender, EventArgs e)
        {
            string id = createProfileInput.Text;
            if (showCreateForm && !profileHandler.profileExists(id))
            {
                string bullet   = bulletSpeedInput.SelectedItem.ToString();
                string player   = playerSpeedInput.SelectedItem.ToString();
                string firerate = firerateInput.SelectedItem.ToString();
                string color    = alienColorInput.SelectedItem.ToString();
                selectedProfile = new Profile(id, bullet, player, firerate, color);
                showCreateForm = false;
                profileHandler.createNewProfile(selectedProfile);
                setDropdownToID(id);
            }
        }

        private void UpdateSettingsSubmit_Click(object sender, EventArgs e)
        {
            string id = createProfileInput.Text;
            if (selectedProfile != null)
            {
                string bullet   = bulletSpeedInput.SelectedItem.ToString();
                string player   = playerSpeedInput.SelectedItem.ToString();
                string firerate = firerateInput.SelectedItem.ToString();
                string color    = alienColorInput.SelectedItem.ToString();
                profileHandler.editProfile(id, bullet, player, firerate, color);
            }
        }
    }
}
