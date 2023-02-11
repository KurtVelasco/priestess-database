using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhodeIsland_AppForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadData.ReadFile();
        }
   
        private void Input_Name_KeyDown(object sender, KeyEventArgs e)
        {
              string UInput = Input_Name.Text;

                if (e.KeyCode == Keys.Enter)
                {
                    ReadData.SearchOperator(UInput);

                    MessageBox.Show("Hello " + UInput);
                    Data_Display.Text = CompileInformation.Name;
    

                }
            
        }


    }
}
    