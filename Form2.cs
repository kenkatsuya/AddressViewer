using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Address_visualCSharp_perfectMaster
{
    public partial class Form2 : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader rd;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = 
                @"Data Source = (LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename=C:\Users\Katsuya\Documents\adres.mdf;" +
                "Integrated Security = True;" +
                "Connect Timeout = 30";

            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO[dbo].[addressTable] VALUES(" +
                "'" + textBox1.Text + "'," +
                "N'" + textBox2.Text + "'," +
                "N'" + textBox3.Text + "'," +
                "N'" + textBox4.Text + "')";

            rd = cmd.ExecuteReader();
            rd.Close();
            cn.Close();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
