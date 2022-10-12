using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Predial10.Resources.CODE
{
    public class ArchivoSql
    {
       /// <summary>
       /// Método que genera un archivo sql 
       /// para importar la base de datos de una caja externa al servidor
       /// </summary>
       /// <param name="cadena">Cadena de texto que se insertara en el archivo</param>
       /// <param name="oficina">Codigo de la oficina</param>
       /// <param name="caja">Codigo de la caja</param>
       /// <param name="fecha">fecha en que se genera el archivo</param>
        public void Guardar(string cadena, string oficina, string caja, string fecha)
        {
            string Nombre_Archivo = "";
            Nombre_Archivo = oficina + caja + fecha;

            DirectoryInfo DIR = new DirectoryInfo("C:\\Importacion");
            //Crea el directorio
            if (!DIR.Exists)
            {
                DIR.Create();
            }           

            //Crea el archivo para agregar los comandos sql
             if (File.Exists("C:\\Importacion\\"+Nombre_Archivo+".sql"))
               {
                    using (StreamWriter sw =  File.AppendText("C:\\Importacion\\"+Nombre_Archivo+".sql"))
                    {   
                        sw.WriteLine(cadena);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText("C:\\Importacion\\"+Nombre_Archivo+".sql"))
                    {
                        sw.WriteLine("USE PREDIALCHICO;");
                        sw.WriteLine(cadena);                        
                        sw.Close();
                    }
                }
            }           
        }
    }

