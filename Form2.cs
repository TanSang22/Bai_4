using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap4
{
    public partial class Form2 : Form
    {
        public delegate void ThongTin (String a,String b,String c);
        public event ThongTin TruyenThongTin;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public Form2(string ms, string hoTen, string luong) : this()
        {
            txtHoTen.Text = ms;
            txtMS.Text = hoTen;
            TxtLuong.Text = luong;
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            string ms = txtMS.Text;
            string hoTen = txtHoTen.Text;
            string luong = TxtLuong.Text;
            TruyenThongTin?.Invoke(ms, hoTen, luong);
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close ();
        }
    }
}
