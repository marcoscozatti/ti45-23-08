using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ti45_22_08_2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = null;
        private string strCon = @"Data Source=.\bdsenac;Initial Catalog=ti45-22-08-24;
                                Persist Security Info=True;User ID=sa;Password=senac2016;";
                                
        private string strSql = string.Empty;
       
        SqlDataAdapter da = null;
        
        private void btnInserir_Click(object sender, EventArgs e)
        {
            strSql = "insert into tblAgenda (nome, telefone) values ('" + txtNome.Text +"','" + txtTelefone.Text + "')";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

           
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro adicionado");
            lblMensagem.Text = "Registro adicionado";

            atualizagrid();
            limpadados();

        }

        private void limpadados()
        {
            txtID.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            strSql = "update tblAgenda set nome='" + txtNome.Text + "', telefone='" + txtTelefone.Text + "' where id=" + txtID.Text;
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            sqlCon.Open();
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro atualizado");
            lblMensagem.Text = "Registro atualizado";

            atualizagrid();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o registro?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Operação cancelada");
            }
            else
            {
                strSql = "delete from tblAgenda where id=" + txtID.Text;
                sqlCon = new SqlConnection(strCon);
                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro apagado");
                lblMensagem.Text = "Registro apagado";
            }

            atualizagrid();
            limpadados();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizagrid();


        }

     
        private void atualizagrid()
        {
         
            string strSql = "SELECT * FROM tblAgenda";

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(strSql, sqlCon);
                    DataTable dt = new DataTable();

                    // Preenche o DataTable com os dados
                    da.Fill(dt);

                    // Atribui o DataTable como fonte de dados para o DataGridView
                    dg.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a grade: " + ex.Message);
            }

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dg.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dg.CurrentRow.Cells[1].Value.ToString();
            txtTelefone.Text = dg.CurrentRow.Cells[2].Value.ToString();

        }
    }
}
