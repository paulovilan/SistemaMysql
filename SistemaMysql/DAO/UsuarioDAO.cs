using MySql.Data.MySqlClient;
using SistemaMysql.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMysql.DAO
{
    public class UsuarioDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();

        public Usuarios Login(Usuarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND senha = @senha", con.con);
                sql.Parameters.AddWithValue("@usuario", dado.Usuario);
                sql.Parameters.AddWithValue("@senha", dado.Senha);
                MySqlDataReader dr;
                dr = sql.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                }
                else
                {
                    dado.Usuario = null;
                    dado.Senha = null;
                }
                return dado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
