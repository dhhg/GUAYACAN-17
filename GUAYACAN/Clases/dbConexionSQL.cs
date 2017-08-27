using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace GUAYACAN
{
    class dbConexionSQL
    {
        public SqlConnection cn; //variable para establecer conexion
        private SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        private SqlCommand comando;
        public string Error { get; set; }

        private string cadena;

        public string Cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }

        //constructor sin parametros

        public dbConexionSQL()
        {
            Cadena = "";
        }

        //constructor con parametros.

        public dbConexionSQL(string valor)
        {
            Cadena = valor;
            Conectar();
        }

        private void Conectar()
        {
            cn = new SqlConnection(this.cadena);
        }

        //Consultar

        public bool Consultar(string sqlQuery, string Tabla)
        {
            bool HayError = false;
            try
            {
                ds.Tables.Clear();
                da = new SqlDataAdapter(sqlQuery, this.cn);
                cmb = new SqlCommandBuilder(da);
                da.Fill(ds, Tabla);
            }
            catch (Exception ex)
            {
                HayError = true;
                this.Error = ex.ToString();
            }
            
            return HayError;
        }

        //eliminar

        public bool Eliminar(string tabla, string condicion)
        {
            bool HayError = false;

            try
            {
                cn.Open();
                string sql = "delete " + tabla.ToString() + " where " + condicion.ToString();
                comando = new SqlCommand(sql, this.cn);
                int i = comando.ExecuteNonQuery();
                cn.Close();
                if (i > 0)
                    HayError = false;
                else
                    HayError = true;
            }
            catch (Exception ex)
            {
                HayError = true;
                this.Error = ex.ToString();
            }

            return HayError;
        }

        //actualizar

        public bool Actualizar(string tabla, string campos, string condicion)
        {
            bool HayError=false;
            try
            {
                cn.Open();
                string sql = "update " + tabla.ToString() + " set " + campos.ToString() + " where " + condicion.ToString();
                comando = new SqlCommand(sql, this.cn);
                int i = comando.ExecuteNonQuery();
                cn.Close();
                if (i > 0)
                    HayError = false;
                else
                    HayError = true;
            }
            catch (Exception ex)
            {
                HayError = true;
                this.Error = ex.ToString();
            }

            return HayError;
        }

        //inserter

        public bool Insertar(string sql)
        {
            bool HayError = false;
            try
            {
                cn.Open();
                comando = new SqlCommand(sql, this.cn);
                int i = comando.ExecuteNonQuery();
                cn.Close();
                
                if (i > 0)
                    HayError = false;
                else
                    HayError = true;

            }
            catch (Exception ex)
            {
                HayError = true;
                this.Error = ex.ToString();
            }

            return HayError;
        }

        public void Desconectar()
        {
            cn.Close();
        }
    }
}
