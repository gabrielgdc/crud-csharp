using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Crud
{
    public partial class Lista : Form
    {

        string connectionString = @"Server=localhost;Database=barboate;username=root;psw=;persistsecurityinfo=false;SslMode=none";
        public Lista()
        {
            InitializeComponent();

        }

        private void Lista_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM bar";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();

            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
    }
}
