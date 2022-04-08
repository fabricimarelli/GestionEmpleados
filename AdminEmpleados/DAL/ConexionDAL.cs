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
        
       
        public bool ejecutarComandoSinRetornoDatos(string strComando)//metodo que le paso por parametro la sentencia SQL para la consulta
        {
            try {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando; //le asigna a Comando la sentencia SQL guardada en la var string strComando
                Comando.Connection = this.EstablecerConexion();//llama al metodo y establece conexion
                Conexion.Open();
                Comando.ExecuteNonQuery();//ejecuta la sentencia sql
                Conexion.Close();

                return true;
            }
            catch {
                return false; 
            }
        }
        //Sobrecarga
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLComando)//sobrecarga porque tiene el mismo nombre que el metodo anterior 
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
