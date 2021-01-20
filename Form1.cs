using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //borderless form 
            this.SetStyle(ControlStyles.ResizeRedraw,true);
             
        }

        //move borderless form
        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x48)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int night = CheckOut.Value.Day - CheckIn.Value.Day;

            string Price = PCrncy.selectedValue.ToString();
            string Curncy = CCrncy.selectedValue.ToString();

            

            //string Channel = ViewChannel.selectedValue.ToString(); 

            if ((night == 0) || (night <= 0))
                MessageBox.Show("please check date is correct", "attention", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            else if (String.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("please enter Price ", "attention", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow Row = (DataGridViewRow)Listofreservations.Rows[0].Clone();

                Row.Cells[0].Value = ViewChannel.selectedValue.ToString();
                Row.Cells[1].Value = chosProperty.selectedValue.ToString();
                Row.Cells[2].Value = CheckIn.Value.ToShortDateString();
                Row.Cells[3].Value = CheckOut.Value.ToShortDateString();
                if (night > 1)
                {
                    Row.Cells[4].Value = night + " nights ";
                }else { Row.Cells[4].Value = night + " night "; }


               

                //Color temp = System.Drawing.ColorTranslator.FromHtml("#FFCC66");

                
                
                //string Status = "Upcoming";
                
                
                if ( StatueS.selectedIndex == 0)
                {
                    Row.Cells[5].Style.ForeColor = System.Drawing.ColorTranslator.FromHtml("#EFC94C");
                }
                else if (StatueS.selectedIndex == 1)
                {
                    Row.Cells[5].Style.ForeColor = System.Drawing.ColorTranslator.FromHtml("#45B29D");
                }
                else if (StatueS.selectedIndex == 2)
                {
                    Row.Cells[5].Style.ForeColor = System.Drawing.ColorTranslator.FromHtml("#DF5A49");
                }

                Row.Cells[5].Value = StatueS.selectedValue.ToString(); 
                Row.Cells[6].Value = txtPrice.Text + " " + Price;
                Row.Cells[7].Value = txtCommition.Text + " " + Curncy;

                Listofreservations.Rows.Add(Row);
            }
            
        }

        private void BTNremove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.Listofreservations.SelectedRows)
            {
                Listofreservations.Rows.RemoveAt(item.Index);
            }
        }


        private void AddReervationbtn_Click(object sender, EventArgs e)
        {

            AddReervation.Show();

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void AddReervation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Listofreservations_MouseMove(object sender, MouseEventArgs e)
        {
            AddReervation.Hide();
        }

        

        private void CheckIn_onValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStatus_onItemSelected(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        
    }
}
