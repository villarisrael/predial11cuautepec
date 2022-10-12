using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Predial10.Resources.CODE
{
    class Conexion_a_BD
    {
        static MySqlConnection Conex = new MySqlConnection();
        static string CadenaDeConexion = Predial10.Properties.Settings.Default.predialchicoConnectionString; 
        //static string CadenaDeConexion = "Server=localhost;" + "Database=predialchico;" + "UID=root;" + "Password=root;";
        static MySqlCommand Comando = new MySqlCommand();
        static MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        static BindingSource Bind = new BindingSource();

        /// <summary>
        /// Metodo que inicia la conexion a la Base de Datos
        /// </summary>
        public static void Conectar()
        {
            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();
            }
            catch (Exception EX)
            {
            }
        }

        /// <summary>
        /// Metodo que desconecta la Base de Datos
        /// </summary>
        public static void Desconectar()
        {
            try
            {
                Conex.Close();
               // Conex.Dispose();
            }
            catch (Exception err)
            { 
            }
        }

        /// <summary>
        /// Metodo que regresa una tabla con los resultados de la consulta
        /// </summary>
        /// <param name="campos">nombre de los campos</param>
        /// <param name="tabla">nombre de la tabla</param>
        /// <param name="orden">nombre de la columna en donde se ordenaran los resultados</param>
        /// <returns></returns>
        public static DataTable Consultasql(string campos, string tabla, string orden)
        {
            string Comando = "select " + campos + " from " + tabla + " order by " + orden + "";
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);
            return  table;
        }

        public static DataTable Consultasql(string campos, string tabla)
        {
            string Comando = "select " + campos + " from " + tabla + ";";
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);
            return table;
        }

        public static DataTable Consulta(string SQL)
        {
            string Comando = SQL;
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);
            return table;
        }
        public static DataTable Consultas(string SQL1)
        {
            string Comando = SQL1;
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);
            return table;
        }

        public static DataTable Consultasqlpagina(string campos, string tabla, string orden, string _limit)
        {
            string Comando = "select " + campos + " from " + tabla + " order by " + orden +  " limit "+ _limit + " ;";
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);
            return table;
        }

        public static DataTable consultaTable(string txtSql)
        {
            string Comando = txtSql;
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);
            return table;
        }
        
        public static BindingSource Bin
        {
            get
            {
                return Bind;
            }
        }

        /// <summary>
        /// Metodo para insertar datos a la  base de datos
        /// </summary>
        /// <param name="consulta">Consulta en SQL para la insercion de datos</param>
        public static void insertar(string consulta)
        {                     
            Comando.CommandText = consulta;
            Comando.Connection = Conex;
            Comando.ExecuteNonQuery();            
        }

        public static void Ejecutar(string consulta)
        {
            Comando.CommandText = consulta;
            Comando.Connection = Conex;
            Comando.ExecuteNonQuery();
        }

        public static string obtenercampo(string consulta)
        {
            try
            {
                Conectar();
            }
            catch
            {
            }
            string Comando = consulta;
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataTable table = new DataTable();
            Adaptador.Fill(table);

            var results = from myRow in table.AsEnumerable()

                          select myRow;
            DataView view = results.AsDataView();

            try
            {
                return view[0][0].ToString();
            }
            catch
            {
                return "";
            }
            Desconectar();
            return "";
        }

        public static byte[] obtenerimagen(string consulta)
        {
            try
            {
                Conectar();
            }
            catch
            {
            }
           
            
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, Conex);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    byte[] avatarByte = (byte[])reader["logo"];
                    return avatarByte;
                }
            }
           
            catch
            {
                return null;
            }

            try
            {
                Desconectar();
            }

            catch (Exception e)
            {
                return null;
            }

            return null;
        }
    }
}
