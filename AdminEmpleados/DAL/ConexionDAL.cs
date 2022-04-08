using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdminEmpleados.DAL
{
    class ConexionDAL
    {
        private string CadenaConexion = "Data Source=LENOVO-FABRIZIO\\SQLEXPRESS; Initial Catalog=dbSistemaGestionEmpleados; Integrated Security =True";
        SqlConnection Conexion;
        public SqlConnection EstablecerConexion()//metodo de la clase para realizar la conexion
        {
            this.Conexion = new SqlConnection(this.CadenaConexion);//instancia asignada al objeto conexion
            return this.Conexion; 
        }
        public bool PruebaConectar(string strComando)//metodo de la clase conexionDAL que me indica el resultado de la conexion
        {
            try {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando; //"insert Departamentos (departamento) values ('programacion')";
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;
            }
            catch {
                return false; 
            }
        }
    }
}
