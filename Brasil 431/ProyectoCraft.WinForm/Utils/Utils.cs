using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Parametros;
using System.Reflection;

namespace ProyectoCraft.WinForm.Utils
{
    public  static class Utils
    {

        public static clsItemParametro ObtenerPrimerItem()
        {
            clsItemParametro item = new clsItemParametro();
            item.Id = 0;
            item.Nombre = "Seleccione...";

            return item;
        }

        public static void CargaComboBoxParametros(clsParametrosInfo lista, ComboBoxEdit combo )
        {           
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.Add(ObtenerPrimerItem());

            foreach (var list in lista.Items)
            {
                coll.Add(list);
            }
            combo.SelectedIndex = 0;
        }

        public static void CargaCombo(IList<object> lista, ComboBoxEdit combo )
        {
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.Add(ObtenerPrimerItem());

            foreach (var list in lista)
            {
                coll.Add(list);
            }
            combo.SelectedIndex = 0;
        }
        
        public static void CargaComboBoxEnumDias(ComboBoxEdit combo)
        {
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.Add(ObtenerPrimerItem());
            foreach (string dia in Enum.GetNames(typeof(Entidades.Enums.Enums.Dias)))
            {                
                coll.Add(dia);                                
            }
            combo.SelectedIndex = 0;
            
        }
        public static void CargaComboBoxEnumJornada(ComboBoxEdit combo)
        {
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.Add(ObtenerPrimerItem());
            foreach (string jornada in Enum.GetNames(typeof(Entidades.Enums.Enums.Jornadas)))
            {
                coll.Add(jornada);
            }
            combo.SelectedIndex = 0;           
        }


        public static void SincronizaComboGlosa(ComboBoxEdit ComboBox, string Nombre)
        {
            string TextoCompara = "";
            ComboBox.SelectedIndex = 0;
            for (int i = 0; i < ComboBox.Properties.Items.Count; i++)
            {
                TextoCompara = ComboBox.Properties.Items[i].ToString().ToUpper();
                TextoCompara = TextoCompara.Trim();
                Nombre = Nombre.ToUpper();
                Nombre = Nombre.Trim();
                if (TextoCompara == Nombre)
                {
                    ComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public static bool ValidaRut(string txtRUT)
        {
            bool error = false;

            txtRUT = txtRUT.ToUpper();
            txtRUT = txtRUT.Replace(".", "");
            if (!txtRUT.Contains("-"))
            {
                error = true;
            }
            else
            {
                string[] ruts = txtRUT.Split('-');
                if (ruts[0].Length > 0)
                {
                    string digito = digitoVerificador(Convert.ToInt64(ruts[0]));
                    string rutFull = ruts[0] + "-" + digito;

                    if (rutFull != txtRUT.Trim())
                    {
                        error = true;
                    }
                }
                else
                {
                    error = true;
                }
            }

            return error;
        }


            private static string digitoVerificador(Int64 rut)
        {
          Int64 Digito;
          int Contador;
          Int64 Multiplo;
          Int64 Acumulador;
          string RutDigito;

          Contador = 2;
          Acumulador = 0;

          while (rut != 0)
          {
          Multiplo = (rut % 10) * Contador;
          Acumulador = Acumulador + Multiplo;
          rut = rut/10;
          Contador = Contador + 1;
          if (Contador == 8)
                {
                 Contador = 2;
                }

          }

          Digito = 11 - (Acumulador % 11);
          RutDigito = Digito.ToString().Trim();
          if (Digito == 10 )
          {
                RutDigito = "K";
          }
          if (Digito == 11)
          {
                RutDigito = "0";
          }
          return (RutDigito);
          }

          }

}
