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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(GetData); //,new DTO("",""));
        }

        private void GetData(object o)
        {
            //var dto = o as DTO;
            //if(dto == null)
            //{
            //    return;
            //}

            var result = new List<DTO>();
            for (int i =0;i<5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO("ID" + i, "name" + i));
            }

            //UIスレッドに戻す
            this.Invoke((Action)delegate(){
                dataGridView1.DataSource = result;
            });
        }

    }
}
