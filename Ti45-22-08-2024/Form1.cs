using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            strSql = "insert into tblAgenda (nome, telefone) values ('Marcos','11986566715')";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

           
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro adicionado");
            lblMensagem.Text = "Registro adicionado";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            strSql = "update tblAgenda set nome='Marcos Cozatti', telefone='11223344' where id=8";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            sqlCon.Open();
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro atualizado");
            lblMensagem.Text = "Registro atualizado";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o registro?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Operação cancelada");
            }
            else
            {
                strSql = "delete from tblAgenda where id=8";
                sqlCon = new SqlConnection(strCon);
                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro apagado");
                lblMensagem.Text = "Registro apagado";
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
