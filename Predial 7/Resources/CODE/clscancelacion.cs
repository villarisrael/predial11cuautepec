using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Predial10.Resources.CODE
{
    class clscancelacion
    {
        DataTable TBL_Consulta2 = new DataTable();
       
        string TCAJA = "";
       
        string Fecha_Inicial = "";

        string Fecha_Final = "";
        string Clave_Catastral = "";
        ArchivoSql archivox = new ArchivoSql();

        public clscancelacion()
        {

        }
        public clscancelacion(string OFICINA, string CAJA,  string recibo)
        {
            string serie = Conexion_a_BD.obtenercampo("select serie from predialchico.cajas where cod_ofi='" + OFICINA + "' and id_caja='" + CAJA + "'");

            Conexion_a_BD.Conectar();
            TBL_Consulta2 = Conexion_a_BD.Consultasql("fecha_inicial, fecha_final, catastral", "recibomaestro WHERE folio= '" + recibo + "' AND SERIE='" + serie + "'");
            Conexion_a_BD.Desconectar();
            var resultado = from myRow in TBL_Consulta2.AsEnumerable() select myRow;
            try
            {
                DataView view = resultado.AsDataView();
                Fecha_Inicial = view[0]["fecha_inicial"].ToString();
                Fecha_Final = view[0]["fecha_final"].ToString();
                Clave_Catastral = view[0]["catastral"].ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("recibo no encontrado");
            }

            try
            {

                Predial10.Facturacion.frmcierre.cierra(Clave_Catastral, DateTime.Parse(Fecha_Inicial));

                string cadenacancelacion = "update recibomaestro set Cancelado='C' WHERE folio=" + recibo + " and serie='" + serie + "';";

                Conexion_a_BD.Conectar();
                Conexion_a_BD.insertar(cadenacancelacion);

                if (TCAJA == "Remota")
                {
                    archivox.Guardar(cadenacancelacion, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                }

                if (Predial10.Properties.Settings.Default.grabarencobroexpress == "si")
                {
                    string cadenacancelacion1 = "use cobroexpress; update recibomaestro set Cancelado='C' WHERE folio=" + recibo + " and serie ='" + serie + "' and catastral<>'' ;use predialchico;";


                    if (TCAJA == "Remota")
                    {
                        archivox.Guardar(cadenacancelacion1, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                    }

                    Conexion_a_BD.Ejecutar(cadenacancelacion1);
                }


                Conexion_a_BD.Desconectar();
                MessageBox.Show("El folio " + recibo  + " fue cancelado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string cadenacancelacion2 = "UPDATE usuario SET UltimoPagoP = '" + Convert.ToDateTime(Fecha_Inicial).ToString("yyyy-MM-dd") + "' WHERE clave_predial='" + Clave_Catastral + "'";
                //CAMBIA LA FECHA DEL ULTIMO PAGO AL CANCELAR EL RECIBO
                Conexion_a_BD.Conectar();
                Conexion_a_BD.insertar(cadenacancelacion2);
                Conexion_a_BD.Desconectar();

                if (TCAJA == "Remota")
                {
                    archivox.Guardar(cadenacancelacion2, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                }


                Facturacion.frmcierre.cierra(Clave_Catastral, Convert.ToDateTime(Fecha_Inicial));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        public void borrar(string OFICINA, string CAJA, string recibo)
        {
             string serie = Conexion_a_BD.obtenercampo("select serie from predialchico.cajas where cod_ofi='" + OFICINA + "' and id_caja='" + CAJA + "'");
            string id="0";
            Conexion_a_BD.Conectar();
            TBL_Consulta2 = Conexion_a_BD.Consultasql("idReciboMaestro,fecha_inicial, fecha_final", "recibomaestro WHERE folio= '" + recibo + "' AND SERIE='" + serie + "'");
            Conexion_a_BD.Desconectar();
            var resultado = from myRow in TBL_Consulta2.AsEnumerable() select myRow;
            try
            {
                DataView view = resultado.AsDataView();
               id = view[0]["idReciboMaestro"].ToString();
               
            }
            catch (Exception x)
            {
                MessageBox.Show("recibo no encontrado");
            }

            try
            {
                string cadenacancelacion = "delete from recibomaestro where idReciboMaestro =" + id + ";";
                string cadenacancelacion20 = "delete from reciboesclavo where recibo =" + recibo + " AND SERIE='" +serie + "'  ;";

                Conexion_a_BD.Conectar();
                Conexion_a_BD.insertar(cadenacancelacion);

                Conexion_a_BD.Ejecutar(cadenacancelacion20);

                if (TCAJA == "Remota")
                {
                    archivox.Guardar(cadenacancelacion, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                    archivox.Guardar(cadenacancelacion20, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                }

                if (Predial10.Properties.Settings.Default.grabarencobroexpress == "si")
                {
                    string cadenacancelacion1 = "use cobroexpress; delete from recibomaestro   WHERE folio=" + recibo + " and serie ='" + serie + "' and catastral<>'' ;use predialchico;";
                    string cadenacancelacion21 = "use cobroexpress; delete from reciboesclavo   WHERE recibo=" + recibo + " and serie ='" + serie + "' and catastral<>'';use predialchico;";

                    if (TCAJA == "Remota")
                    {
                        archivox.Guardar(cadenacancelacion1, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                        archivox.Guardar(cadenacancelacion21, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                    }

                    Conexion_a_BD.Ejecutar(cadenacancelacion1);
                    Conexion_a_BD.Ejecutar(cadenacancelacion21);
                }



                Conexion_a_BD.Desconectar();
                MessageBox.Show("El folio " + recibo + " fue borrado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }


    }

   
}
