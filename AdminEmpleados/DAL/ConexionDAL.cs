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
        
        /*Metodo INSERT, DELETE, UPDATE*/
        public bool ejecutarComandoSinRetornoDatos(string strComando)//metodo de la clase conexionDAL que me indica el resultado de la conexion
        {
            try {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando; 
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
        //Sobrecarga
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLComando)//sobrecarga porque tiene el mismo nombre que el metodo anterior y le pasamos otro argumento
        {
            try
            {
                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }


        /*SELECT (retorno de datos)*/
        public DataSet EjecutarSentencia(SqlCommand sqlComando)//metodo para ejecutar sentencias tipo select
        {
            DataSet DS = new DataSet();//DS para adpatar la informacion
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;//utilizo el comando
                Conexion.Open();//abro la conexion
                Adaptador.Fill(DS);//lleno el adaptador
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }
    }
}
