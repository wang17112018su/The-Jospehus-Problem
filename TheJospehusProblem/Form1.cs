using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TheJospehusProblem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int numberOfWarriors;
        List<int> Warriors;

        private void button1_Click(object sender, EventArgs e)
        {
            //Attributes
            label1.Text = "";
            Warriors = new List<int>();
            label1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            //Add the no. of warriors into a Warrior List
            numberOfWarriors = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i <= numberOfWarriors; i++)
            {
                Warriors.Add(i);
            }

            //Keep removing till there is only one element in the list
            while (Warriors.Count() != 1)
            {
                //Total count is even all even item will be remove
                if (Warriors.Count() % 2 == 0)
                {
                    textBox2.Text += Story(Warriors);
                    Battle(Warriors);
                }
                //Total count is odd all even item and 1st item will be remove
                else
                {
                    textBox2.Text += Story(Warriors);
                    Battle(Warriors);
                    Warriors.Remove(Warriors[0]);
                }
            }
            label1.Text = "Warrior " + Warriors[0] + " has survived the Battle";
        }

        //Method to remove the even element in the list
        private static void Battle(List<int> Warriors)
        {
            for (int i = 1; i < Warriors.Count(); i++)
            {
                Warriors.Remove(Warriors[i]);
            }
        }

        //Method to tell the story repeatedly
        private static string Story(List<int> Warriors)
        {
            int i;
            string battleStory = "Sword is given to Warrior " + Warriors[0] + "\n";
            for (i = 1; i < Warriors.Count() - 1; ++i)
            {
                battleStory += "Warrior " + Warriors[--i] + " killed Warrior " + Warriors[++i] + " and passed the sword to Warriors " + Warriors[++i] + "\n";
            }
            if (Warriors.Count() % 2 != 0)
            {
                battleStory += "Warrior " + Warriors[--i] + " killed Warrior " + Warriors[0] + "\nEnd of Battle\n";
            }
            else
            {
                battleStory += "Warrior " + Warriors[--i] + " killed Warrior " + Warriors[++i] + "\nEnd of Battle\n";
            }
            return battleStory;
        }
    }
}
