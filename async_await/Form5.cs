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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await Task.Run(()=> GetData());
            MessageBox.Show("完了");
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
