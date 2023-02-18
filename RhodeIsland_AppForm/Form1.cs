using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RhodeIsland_AppForm
{
    public partial class Priestess : Form
    {
        string UInput = "";
        string PictureLocation = "";
        string FactionLocation = "";
        string ClassLocation = "";
        string SubclassLocation = "";
        string INF = "";
        public Priestess()
        {
            InitializeComponent();
            ReadData.ReadFile();
            OperatorNumbers.Text = ReadData.NumberOps.ToString();
            timer1.Interval = 1000;
        }
   
        private void Input_Name_KeyDown(object sender, KeyEventArgs e)
        {
            UInput = Input_Name.Text;
            UInput.ToLower();          
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Start();
                ReadData rd = new ReadData();
                rd.SearchOperator(UInput);
                if (rd.FoundOperator == false)
                {
                    MessageBox.Show("No Data can be found of: " + UInput);
                }
                else
                {
                    
                    TextBox(sender, e);
                    ImageLocation(sender, e);
                       
                    if (File.Exists(PictureLocation))
                    {
                        OperatorPicture.BackgroundImage = Image.FromFile(PictureLocation);
                    }              
                    if (File.Exists(FactionLocation))
                    {
                        Faction.Image = Image.FromFile(FactionLocation);
                    }
                    INFRate.Image = Image.FromFile(INF);
                    OpClassPic.Image = Image.FromFile(ClassLocation);
                    SubClassPic.Image = Image.FromFile(SubclassLocation);
                   
                }
            }
            
        }
        public void UpdateDatabase(object sender, KeyEventArgs e)
        {
          
        }
        private void TextBox(object sender, KeyEventArgs e)
        {
            Op_Name.Text = CompileInformation.Name;
            Profession.Text = CompileInformation.Profession;
            SubProfession.Text = CompileInformation.SubProfession;
            Nation_Text.Text = CompileInformation.Faction;
            OPERATORID.Text = CompileInformation.PrehabKey;
            Nation_Text.Text = CompileInformation.NationID;
            Rarity_text.Text = CompileInformation.Sec_Class;
            SquadText.Text = CompileInformation.Squad;
            Clinical.Text = CompileInformation.Clinical;
        }
        private void ImageLocation(object sender, KeyEventArgs e)
        {
            PictureLocation = @"C:\Users\karin\source\repos\RhodeIsland_AppForm\RhodeIsland_AppForm\bin\Debug\OpPictures\" + CompileInformation.PrehabKey + ".png";
            FactionLocation = @"C:\Users\karin\source\repos\RhodeIsland_AppForm\RhodeIsland_AppForm\bin\Debug\FactionPictures\" + "logo_" + CompileInformation.NationID + ".png";
            ClassLocation = @"C:\Users\karin\source\repos\RhodeIsland_AppForm\RhodeIsland_AppForm\bin\Debug\ClassPictures\" + "class_" + CompileInformation.Profession + ".png";
            SubclassLocation = @"C:\Users\karin\source\repos\RhodeIsland_AppForm\RhodeIsland_AppForm\bin\Debug\SubClassPictures\" + "sub_" + CompileInformation.SubProfession + "_icon.png";
            INF = @"C:\Users\karin\source\repos\RhodeIsland_AppForm\RhodeIsland_AppForm\bin\Debug\priesstess_icon\Status_Monitor.gif";
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update the Operator Database","Update Operator Database", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Make sure you connected to the internet \n Updating Operator's Database...");
                    UpdateFiles.UpdateOperator("ArknightDataBase");
                    if(UpdateFiles.IfSuccess == true)
                    {
                        MessageBox.Show("Update Complete: Update Operator Profiles if necessary");
                    }
                    else
                    {
                        MessageBox.Show("Updated Failed: Check your internet connection");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void Priestess_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(88, 101);
            INFmonitor.Text = randomNumber.ToString();
        }

        private void Button_Profile_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update the Operator's Profile?", "Update Profile", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Make sure you connected to the internet \n Updating Operator's Profiles...");
                    UpdateFiles.UpdateOperator("UrlOperateProfile");
                    if (UpdateFiles.IfSuccess == true)
                    {
                        MessageBox.Show("Update Complete: Update Operator Databae if necessary");
                    }
                    else
                    {
                        MessageBox.Show("Updated Failed: Check your internet connection");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by @Kritzkingvoid \n @Kengxxiao for the Extracted JSON files \n @Aceship for the image files ", "Credits");
               
        }
    }
}
    