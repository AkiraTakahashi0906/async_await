﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async_await
{
    public partial class Form7 : Form
    {
        private Database database = new Database();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await Task.Run(() => database.GetData());
            if (database.IsCancel)
            {
                MessageBox.Show("キャンセル");
            }
            else
            {
                MessageBox.Show("完了");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            database.Cancel();
        }
    }
}
