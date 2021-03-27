using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() => GetData()).ContinueWith(x=>
            {
                dataGridView1.DataSource = x.Result;
                MessageBox.Show("完了");
            },context);
        }

        private List<DTO> GetData()
        {
            var result = new List<DTO>();
            for (int i =0;i<5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO("ID" + i, "name" + i));
            }
            return result;
        }

    }
}
