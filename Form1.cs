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
    public partial class Form1 : Form
    {
        Lista lista = new Lista();
        string connectionString = @"Server=localhost;Database=barboate;username=root;psw=;persistsecurityinfo=false;SslMode=none";
        bool novo;

        public Form1()
        {
            InitializeComponent();
            AutoComplete();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtBar.Enabled = false;
            txtCidade.Enabled = false;
            txtCont.Enabled = false;
            txtFb.Enabled = false;
            txtInsta.Enabled = false;
            txtEmail.Enabled = false;
            txtObs.Enabled = false;
            mskTel.Enabled = false;
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            tsbExcluir.Enabled = false;
            tsbId.Enabled = false;
            tsbBuscar.Enabled = false;
            txtBar.Enabled = true;
            txtCidade.Enabled = true;
            txtCont.Enabled = true;
            txtFb.Enabled = true;
            txtInsta.Enabled = true;
            txtEmail.Enabled = true;
            txtObs.Enabled = true;
            mskTel.Enabled = true;
            txtBar.Focus();
            novo = true;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (novo == true)
            {
                string sql = "INSERT INTO bar (bar, cidade, contato, telefone, facebook, instagram, email, observacao) " +
                             "VALUES (@Bar, @Cidade, @Contato, @Telefone, @Instagram, @Facebook, @Email, @Observacao)";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Bar", txtBar.Text);
                cmd.Parameters.AddWithValue("@Cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("@Contato", txtCont.Text);
                cmd.Parameters.AddWithValue("@Telefone", mskTel.Text);
                cmd.Parameters.AddWithValue("@Instagram", txtInsta.Text);
                cmd.Parameters.AddWithValue("@Facebook", txtFb.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Observacao", txtObs.Text);
                cmd.CommandType = CommandType.Text;
                con.Open();

                    try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro cadastrado :^)");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            } else
            {
                string sql = "UPDATE bar SET bar=@Bar, cidade=@Cidade, contato=@Contato, telefone=@Telefone, instagram=@Instagram, facebook=@Facebook, email=@Email, observacao=@Observacao WHERE bar=@Id";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", tsbId.Text);
                cmd.Parameters.AddWithValue("@Bar", txtBar.Text);
                cmd.Parameters.AddWithValue("@Cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("@Contato", txtCont.Text);
                cmd.Parameters.AddWithValue("@Telefone", mskTel.Text);
                cmd.Parameters.AddWithValue("@Instagram", txtInsta.Text);
                cmd.Parameters.AddWithValue("@Facebook", txtFb.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Observacao", txtObs.Text);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro atualizado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            tsbNovo.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtBar.Enabled = false;
            txtCidade.Enabled = false;
            txtCont.Enabled = false;
            txtFb.Enabled = false;
            txtInsta.Enabled = false;
            txtEmail.Enabled = false;
            txtObs.Enabled = false;
            mskTel.Enabled = false;

            tsbId.Text = "";
            txtBar.Text = "";
            txtCidade.Text = "";
            txtCont.Text = "";
            txtEmail.Text = "";
            txtFb.Text = "";
            txtInsta.Text = "";
            txtObs.Text = "";
            mskTel.Text = "";

            AutoComplete();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtBar.Enabled = false;
            txtCidade.Enabled = false;
            txtCont.Enabled = false;
            txtFb.Enabled = false;
            txtInsta.Enabled = false;
            txtEmail.Enabled = false;
            txtObs.Enabled = false;
            mskTel.Enabled = false;

            tsbId.Text = "";
            txtBar.Text = "";
            txtCidade.Text = "";
            txtCont.Text = "";
            txtEmail.Text = "";
            txtFb.Text = "";
            txtInsta.Text = "";
            txtObs.Text = "";
            mskTel.Text = "";
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Quer mesmo excluir esse registro ?", "Excluir", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM bar WHERE bar=@Bar; ALTER TABLE bar AUTO_INCREMENT = 1;";
                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Bar", tsbId.Text);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro excluído");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }

                tsbNovo.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbId.Enabled = true;
                tsbBuscar.Enabled = true;
                txtBar.Enabled = false;
                txtCidade.Enabled = false;
                txtCont.Enabled = false;
                txtFb.Enabled = false;
                txtInsta.Enabled = false;
                txtEmail.Enabled = false;
                txtObs.Enabled = false;
                mskTel.Enabled = false;

                tsbId.Text = "";
                txtBar.Text = "";
                txtCidade.Text = "";
                txtCont.Text = "";
                txtEmail.Text = "";
                txtFb.Text = "";
                txtInsta.Text = "";
                txtObs.Text = "";
                mskTel.Text = "";
            }
            else if (result == DialogResult.No)
            {
                
            }

            AutoComplete();
            lblId.Text = "ID: ";

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM bar WHERE bar = @Bar";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Bar", tsbId.Text);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tsbNovo.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbExcluir.Enabled = true;

                    tsbId.Enabled = false;
                    tsbBuscar.Enabled = false;

                    txtBar.Enabled = true;
                    txtCidade.Enabled = true;
                    txtCont.Enabled = true;
                    txtEmail.Enabled = true;
                    txtInsta.Enabled = true;
                    txtFb.Enabled = true;
                    mskTel.Enabled = true;
                    txtObs.Enabled = true;
                    txtBar.Focus();

                    lblId.Text = "ID: " + reader[0].ToString();
                    txtBar.Text = reader[1].ToString();
                    txtCidade.Text = reader[2].ToString();
                    txtCont.Text = reader[3].ToString();
                    mskTel.Text = reader[4].ToString();
                    txtFb.Text = reader[5].ToString();
                    txtInsta.Text = reader[6].ToString();
                    txtEmail.Text = reader[7].ToString();
                    txtObs.Text = reader[8].ToString();
                    novo = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());

            }
            finally
            {
                con.Close();
            }

            tsbId.Text = txtBar.Text;
        }

        void AutoComplete()
        {
            tsbId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tsbId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string sql = "SELECT * FROM bar";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string bar = reader[1].ToString();
                    coll.Add(bar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            tsbId.AutoCompleteCustomSource = coll;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista.IsDisposed == true)
                {
                    lista = new Lista();
                }
                lista.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());  
            }
        
        }
    }
}
