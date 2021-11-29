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
    public partial class Form1 : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader rd;
        private string cnstr =
            @"Data Source = (LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=C:\Users\Katsuya\Documents\adres.mdf;"+
            "Integrated Security = True;"+
            "Connect Timeout = 30";
           

        public Form1()
        {
            InitializeComponent();
        }

        private void addressTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.addressTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.adresDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'adresDataSet.addressTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.addressTableTableAdapter.Fill(this.adresDataSet.addressTable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[addressTable]";

            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add(
                    String.Format("[{0}] {1,-10} {2,-20}  [TEL]{3}",
                    rd["ID"], rd["Name"], rd["Address"], rd["TEL"]));
            }

            rd.Close();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[addressTable]" +
                "WHERE ID='" + textBox1.Text + "'";

            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add(
                    String.Format("[{0}] {1,-10} {2,-20}  [TEL]{3}",
                    rd["ID"], rd["Name"], rd["Address"], rd["TEL"]));
            }

            rd.Close();
            cn.Close();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[addressTable]" +
                "WHERE Address　LIKE　N'%" + textBox2.Text + "%'";　//日本語を使うときはプレフィックスのNを付ける

            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add(
                    String.Format("[{0}] {1,-10} {2,-20}  [TEL]{3}",
                    rd["ID"], rd["Name"], rd["Address"], rd["TEL"]));
            }

            rd.Close();
            cn.Close();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
        }
    }
}
