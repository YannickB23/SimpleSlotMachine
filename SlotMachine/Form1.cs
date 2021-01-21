using System;
using System.Windows.Forms;

namespace SlotMachine
{
    public partial class frmSlot : Form
    {
        public frmSlot()
        {
            InitializeComponent();
        }
        decimal totalInserted = 0.00m;
        decimal totalWon = 0.00m;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            decimal amountWon = 0.00m;
            decimal amountInserted = 0.00m;

            if (decimal.TryParse(txtAmountInserted.Text, out amountInserted) && amountInserted > 0)
            {
            Random rnd = new Random();
            int pic_1 = rnd.Next(0, 3);
            int pic_2 = rnd.Next(0, 3);
            int pic_3 = rnd.Next(0, 3);

            pic1.Image = imgFruit.Images[pic_1];
            pic2.Image = imgFruit.Images[pic_2];
            pic3.Image = imgFruit.Images[pic_3];

                totalInserted += amountInserted;
                totalWon += amountWon = GetWinningAmount(pic_1, pic_2, pic_3, amountInserted);
            }
        }
        private decimal GetWinningAmount(int p1, int p2, int p3, decimal amountInserted)
        {
            if (p1 == p2 && p2 == p3)
            {
                return amountInserted * 3;
            }
            else if (p1 == p2 || p2 == p3 || p1 == p3)
            {
                return amountInserted * 2;
            }
            return -amountInserted;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total inserted = {totalInserted}".ToString() + 
                            $"\nTotal won = {totalWon}".ToString());
        }
    }
}
