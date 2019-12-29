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
    public partial class Form2 : Form
    { 
        public string System_path = System.IO.Directory.GetCurrentDirectory();
        public string JVM_argument = "-Xms4G -Xmx4G -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M";
        public Form2()
        {
            InitializeComponent();
            default_set();
            JVM.Text = JVM_argument;
        }

        public void default_set()
        {
            string line;
            string[] splin = new string[] { "==" };
            string[] data = new string[4];
            try
            {
                using (StreamReader Sr = new StreamReader(Path.Combine("Core", "infor.cryp")))
                {
                    int counter = 0;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        data = line.Split(new string[] { "==" }, StringSplitOptions.None);
                        counter++;
                        if(counter == 1)
                        {
                            System_path = data[1];
                        }
                        else if(counter == 2)
                        {
                            JVM_argument = data[1];
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                using (StreamWriter Sw = new StreamWriter(Path.Combine("Core", "infor.cryp"))) 
                {
                    Sw.WriteLine("Path==" + System_path);
                    Sw.WriteLine("JVM_Setting==" + JVM_argument);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_file();
            this.Visible = false;
        }
        private void save_file()
        {
            JVM_argument = JVM.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter Sw = new StreamWriter(Path.Combine("Core", "infor.cryp"));
            Sw.WriteLine("Path==" + System_path);
            Sw.WriteLine("JVM_Setting==" + JVM_argument);
            Sw.Close();
        }
    }
}
