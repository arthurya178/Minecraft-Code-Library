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
using System.Diagnostics;

namespace Minecraft_Mod
{
    public partial class Form1 : Form
    {
        public object[] Version = new object[] { "[Pandora]Einstan" , "[Pandora]Tesla" };
        public string[] Forge_V = new string[] { "forge-14.23.5.2796", "1.1------------------6.2" };
        public string Path_loc = System.IO.Directory.GetCurrentDirectory();

        static Form2 form2;
        Class1 json = new Class1();
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
            comboBox1.Items.AddRange(Version);
            
        }

        protected bool Safe_Check()
        {
            string PCU = "XxBFfmlcQFyl24J9d5+8xOHZ7ETjCjBSg9J3eFKSrWmmX86Z7B2Jou1fPNEaWzEN6284tuai7NyelZ8NZJThWQ==";
            bool check_PCU = false, check_TCU = false;
            try
            {
                using (StreamReader Sr = new StreamReader(Path.Combine("Core", "SF.cryp")))
                {
                    string line;
                    string[] date = new string[10];
                    int counter = 0;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        date = line.Split(new string[] { "::" }, StringSplitOptions.None);
                        counter++;
                        if (counter == 1)
                        {
                            check_PCU = (date[1] == PCU);
                        }
                        else if (counter == 3)
                        { 
                            check_TCU = (int.Parse(date[1]) > DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Please Login!!!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if(check_TCU && check_PCU)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please Update your licence!!!!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = Path_loc;
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            form2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Choose Modpack")
            {
                label2.Text = "--ModPack-- " + comboBox1.Text;
                pictureBox1.Image = Image.FromFile(Path.Combine(Path_loc, "lib", comboBox1.Text, "mod.jpg"));
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Visible = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool check_licence = Safe_Check();
            if (check_licence)
            {
                int ver = 0;
                for (int i = 0; i < Forge_V.Length; i++)
                {
                    if (Version[i].ToString() == comboBox1.Text)
                        ver = i;
                }
                json.Create_Launcher_Profile(comboBox1.Text, form2.JVM_argument, Path.Combine(form2.System_path,"Core","CoreFile"), Forge_V[ver]);
                try
                {
                    Process.Start(form2.System_path + "\\Core\\minecraftLauncher.exe");
                }
                catch(Exception ex)
                { 
                }
            }
            else
            {

            }

        }


    }
}
