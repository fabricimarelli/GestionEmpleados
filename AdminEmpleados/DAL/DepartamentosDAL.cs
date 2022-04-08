using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AdminEmpleados.BLL;

namespace AdminEmpleados.DAL
{
    class DepartamentosDAL
    {
        ConexionDAL conexion;
        public DepartamentosDAL()//construcor=metodo con el mismo nombre que la clase
        {
            conexion = new ConexionDAL();
        }

        public bool Agregar(DepartamentoBLL oDepartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("insert Departamentos values(@Departamento) ");
            SQLComando.Parameters.Add("@Departamento",SqlDbType.VarChar).Value = oDepartamentosBLL.Departamento;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);

            // return conexion.ejecutarComandoSinRetornoDatos("insert Departamentos (departamento) values ('"+oDepartamentosBLL.Departamento +"')");
        }

        public bool Eliminar(DepartamentoBLL oDepartamentosBLL)
        {

            SqlCommand SQLComando = new SqlCommand("delete from Departamentos where ID=@DepartamentoID");
            SQLComando.Parameters.Add("@DepartamentoID",SqlDbType.Int).Value=oDepartamentosBLL.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
            //conexion.ejecutarComandoSinRetornoDatos("delete from Departamentos where ID="+ oDepartamentosBLL.ID);

            //return 1;
        }

        public bool Modificar(DepartamentoBLL oDepartamentosBLL)
        {

            SqlCommand SQLComando = new SqlCommand("update departamentos set departamento=@Departamento where ID=@DepartamentoID");
            //conexion.ejecutarComandoSinRetornoDatos("update Departamentos set departamento='"+oDepartamentosBLL.Departamento+"' "+"where ID="+ oDepartamentosBLL.ID);
            SQLComando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = oDepartamentosBLL.Departamento;
            SQLComando.Parameters.Add("@DepartamentoID", SqlDbType.Int).Value = oDepartamentosBLL.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
            //return 1;
        }

        public DataSet MostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("select * from Departamentos");
            return conexion.EjecutarSentencia(sentencia);
        }

    }
}
