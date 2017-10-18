using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialValidationSamsumg
{
    public class Series
    {
        public static string _serieHP,_seriaSamsung;
        public static string _Msg;
        ConectarSQL conexion = new ConectarSQL();
        public Series() { }
        public bool validarCantidadSeries(string _SerieSamsung, string _SerieHP)
        {                            
            try
            {
                 string query = " SELECT SS_SN FROM test WHERE SS_SN = '" + _SerieSamsung + "' AND HP_SN = '" + _SerieHP + "'";
                 var tabla = conexion.Consultasql(query);
                string valor = tabla.Rows[0]["SS_SN"].ToString();
                int filas = tabla.Rows.Count;
                      // Se necesita verificar la coneccion a BDF  
                      
                //elimina    
                if (filas > 0)
                {                  
                    limpia();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception msgError)
            {
                _Msg = msgError.ToString();              
                return false;
            }          
        }
        public void ValidaSeries(string SS , string SHp)
        {
            if (SS == SHp)
            {
                MessageBox.Show("SERIE SAMSUMG EXISTENTE EN DB");
            }
            else
            {
                MessageBox.Show("NO EXISTE SERIE SS");
            }

        }

        public void limpia()
        {
            _seriaSamsung ="";
            _serieHP = "";
        }
    }
}
