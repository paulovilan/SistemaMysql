using SistemaMysql.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaMysql.DAO;

namespace SistemaMysql.Model
{
    public class UsuarioModel
    {
        UsuarioDAO dao = new UsuarioDAO();

        public Usuarios Login(Usuarios dado)
        {
            try
            {
                return dao.Login(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
