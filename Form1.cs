using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeAppDemo
{
    public partial class Form1 : Form
    {
        private object txtBarcode;
        private int foreColor;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picBarcode.Image == null)
                return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    picBarcode.Image.Save(saveFileDialog.FileName);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Color forColor = Color.Black;
            Color backColor = Color.Transparent;
            Image img = barcode.Encode(TYPE.UPCA, txtBarcode.Text, foreColor, backColor, (int)(picBarcode.Width * 0.8), (int)(picBarcode.Height * 0.8));
            picBarcode.Image = img;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
