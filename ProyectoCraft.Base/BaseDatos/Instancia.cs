using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Base.BaseDatos
{
    public class Instancia
    {
        private static Instancia Lainstancia;
        private string _strconn;

        // El Constructor debe ser privado
        private Instancia(string Ruta)
        {
            string strPathIni = null;
            System.IO.StreamReader objStream = default(System.IO.StreamReader);
            string strLinea = null;
            // Dim strCadenaConexion As String
            //strPathIni = Encriptar.Encriptacion.Desencriptar(Adicional.Valor_Config(Ruta), "br>es/8K");

            //string enc = Encriptar.Encriptacion.Encriptar(Ruta);
            
            //strPathIni = Encriptar.Encriptacion.Desencriptar(Ruta, "br>es/8K");

            //objStream = new System.IO.StreamReader(strPathIni);
            //strLinea = objStream.ReadLine();
            //if ((strLinea != null)) _strconn = Encriptar.Encriptacion.Desencriptar(strLinea, "br>es/8K");
            //objStream.Close();

            //_strconn = strPathIni;
            _strconn = Ruta;
        }


        public static string GetStrCon(string Ruta)
        {
            if (Lainstancia == null) Lainstancia = new Instancia(Ruta);
            return Lainstancia._strconn;
        }

    }
}
