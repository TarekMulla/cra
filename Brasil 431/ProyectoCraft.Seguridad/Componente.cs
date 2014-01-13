using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Seguridad
{
    [System.Security.Permissions.StrongNameIdentityPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, PublicKey = Comun.PublicKey)]
    public sealed class Componente
    {
        [System.Security.Permissions.StrongNameIdentityPermissionAttribute(System.Security.Permissions.SecurityAction.PermitOnly, PublicKey = Comun.PublicKey)]
        public string codificar(string strACodificar)
        {
            DateTime Fecha = System.DateTime.Now.AddHours(-4);
            int _XOR = Fecha.Month + Fecha.Day;

            byte[] _bytEntrada = Encoding.UTF8.GetBytes(strACodificar);

            for (int _intPos = 0; _intPos < _bytEntrada.Length; _intPos++)
                _bytEntrada[_intPos] = Convert.ToByte(_XOR ^ Convert.ToInt32(_bytEntrada[_intPos]));

            return Convert.ToBase64String(_bytEntrada).Replace("+", "|");

        }

        [System.Security.Permissions.StrongNameIdentityPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, PublicKey = Seguridad.Comun.PublicKey)]
        public static string decodificar(string strADecodificar)
        {
            DateTime Fecha = System.DateTime.Now.AddHours(-4);
            int _XOR = Fecha.Month + Fecha.Day;

            byte[] _bytEntrada = Convert.FromBase64String(strADecodificar.Replace("|", "+"));

            for (int _intPos = 0; _intPos < _bytEntrada.Length; _intPos++)
                _bytEntrada[_intPos] = Convert.ToByte(_XOR ^ Convert.ToInt32(_bytEntrada[_intPos]));

            return Encoding.UTF8.GetString(_bytEntrada);

        }

        [System.Security.Permissions.StrongNameIdentityPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, PublicKey = Seguridad.Comun.PublicKey)]
        public static string decodificar(string strADecodificar, int llave)
        {
            byte[] _bytEntrada = Convert.FromBase64String(strADecodificar.Replace("|", "+"));

            for (int _intPos = 0; _intPos < _bytEntrada.Length; _intPos++)
                _bytEntrada[_intPos] = Convert.ToByte(llave ^ Convert.ToInt32(_bytEntrada[_intPos]));

            return Encoding.UTF8.GetString(_bytEntrada);

        }

    }
}
