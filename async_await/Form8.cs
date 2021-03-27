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
    public partial class Form8 : Form
    {
        System.Threading.CancellationTokenSource _token;
        private Database2 database = new Database2();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _token = new System.Threading.CancellationTokenSource();
                dataGridView1.DataSource = await Task.Run(() => database.GetData(_token.Token), _token.Token);
                MessageBox.Show("完了");
            }
            catch(OperationCanceledException o)
            {
                MessageBox.Show("キャンセル");
            }
            finally
            {
                _token.Dispose();
                _token = null;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _token?.Cancel();
        }
    }
}
