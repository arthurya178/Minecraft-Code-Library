using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Mod
{
    public partial class Form3 : Form 
    {
        int login = 0;
        protected string PCU = "XxBFfmlcQFyl24J9d5+8xOHZ7ETjCjBSg9J3eFKSrWmmX86Z7B2Jou1fPNEaWzEN6284tuai7NyelZ8NZJThWQ==";
        protected string[] Account = new string[] { "pandora1301", "midori" };
        protected string[] Password = new string[] { "cp6971", "Cocktail" };
        public Form3()
        {
            InitializeComponent();
        }
        public bool acc_pw_check()
        {
            for(int i = 0;i < Account.Length;i++)
            {
                if(textBox1.Text == Account[i])
                {
                    if(textBox2.Text == Password[i])
                    {
                        login = i;
                        return true;
                    }
                }
            }
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if(acc_pw_check())
                {
                    using (StreamWriter Sw = new StreamWriter(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Core", "SF.cryp")))
                    {
                        long time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                        time += 604800;
                        //time += 150;
                        Sw.WriteLine("PCU::" + PCU);
                        Sw.WriteLine("account::" + Account[login]);
                        Sw.WriteLine("TCU::" + time);
                        MessageBox.Show("Succesful extend your licence for 7 day!!!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Account or password", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
            }
            else
            {
                MessageBox.Show("Make sure you have read the EULA!!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
