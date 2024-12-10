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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?",  
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question              
           );
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
             
              
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn đóng ứng dụng không?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.TruyenThongTin += (ms, hoTen, luong) =>
            {
                DGV1.Rows.Add(ms, hoTen, luong);
            };
            form2.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DGV1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = DGV1.SelectedRows[0];
            string currentMS = selectedRow.Cells[1].Value.ToString();
            string currentHoTen = selectedRow.Cells[0].Value.ToString();
            string currentLuong = selectedRow.Cells[2].Value.ToString();

            Form2 form2 = new Form2 (currentMS, currentHoTen, currentLuong);
            form2.TruyenThongTin += (ms, hoTen, luong) =>
            {
                selectedRow.Cells[0].Value = ms;
                selectedRow.Cells[1].Value = hoTen;
                selectedRow.Cells[2].Value = luong;
            };
            form2.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DGV1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataGridViewRow row in DGV1.SelectedRows)
            {
                DGV1.Rows.RemoveAt(row.Index);
            }
        }
    }
    }

