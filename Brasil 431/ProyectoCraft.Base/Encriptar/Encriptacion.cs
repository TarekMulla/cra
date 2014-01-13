using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoCraft.Base.Encriptar
{
    public class Encriptacion
    {
        public static string Encriptar(string strEncriptar, string strKeyPrivada)
        {
            string functionReturnValue = null;
            DESCryptoServiceProvider des = default(DESCryptoServiceProvider);
            byte[] inputByteArray = null;
            MemoryStream ms = default(MemoryStream);
            CryptoStream cs = default(CryptoStream);
            byte[] mIV = { 0x45, 0x32, 0xa5, 0x18, 0x67, 0x58, 0xac, 0xba };
            byte[] mkey = { };

            if (strKeyPrivada == "br>es/8K" || strKeyPrivada == "LAN")
            {
                try
                {
                    if (strKeyPrivada == "LAN") strKeyPrivada = ":jCh6X!\\";
                    mkey = System.Text.Encoding.UTF8.GetBytes(strKeyPrivada.Substring(0, 8));
                    des = new DESCryptoServiceProvider();
                    inputByteArray = Encoding.UTF8.GetBytes(strEncriptar);
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(mkey, mIV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    functionReturnValue = Convert.ToBase64String(ms.ToArray()).Replace("+", "|");
                }
                catch (Exception e)
                {
                    functionReturnValue = "";
                    Log.Log.EscribirLog(e.Message);
                }
                finally
                {
                    des = null;
                    ms = null;
                    cs = null;
                }
            }
            else
            {
                return (new Seguridad.Componente().codificar(strEncriptar));
            }
            return functionReturnValue;
        }

        public static string Encriptar(string strEncriptar)
        {
            string strKeyPrivada = "br>es/8K";
            string functionReturnValue = null;
            DESCryptoServiceProvider des = default(DESCryptoServiceProvider);
            byte[] inputByteArray = null;
            MemoryStream ms = default(MemoryStream);
            CryptoStream cs = default(CryptoStream);
            byte[] mIV = { 0x45, 0x32, 0xa5, 0x18, 0x67, 0x58, 0xac, 0xba };
            byte[] mkey = { };

            if (strKeyPrivada == "br>es/8K" || strKeyPrivada == "LAN")
            {
                try
                {
                    if (strKeyPrivada == "LAN") strKeyPrivada = ":jCh6X!\\";
                    mkey = System.Text.Encoding.UTF8.GetBytes(strKeyPrivada.Substring(0, 8));
                    des = new DESCryptoServiceProvider();
                    inputByteArray = Encoding.UTF8.GetBytes(strEncriptar);
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(mkey, mIV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    functionReturnValue = Convert.ToBase64String(ms.ToArray()).Replace("+", "|");
                }
                catch (Exception e)
                {
                    functionReturnValue = "";
                }
                finally
                {
                    des = null;
                    ms = null;
                    cs = null;
                }
            }
            else
            {
                return (new Seguridad.Componente().codificar(strEncriptar));
            }
            return functionReturnValue;
        }

        public static string Desencriptar(string strDesEncriptar, string strKeyPrivada)
        {
            string functionReturnValue = null;
            byte[] inputByteArray = new byte[strDesEncriptar.Length + 1];
            DESCryptoServiceProvider des = default(DESCryptoServiceProvider);
            MemoryStream ms = default(MemoryStream);
            CryptoStream cs = default(CryptoStream);
            System.Text.Encoding encoding = default(System.Text.Encoding);
            byte[] mIV = { 0x45, 0x32, 0xa5, 0x18, 0x67, 0x58, 0xac, 0xba };
            byte[] mkey = { };

            if (strKeyPrivada == "br>es/8K" || strKeyPrivada == "LAN")
            {
                try
                {
                    if (strKeyPrivada == "LAN") strKeyPrivada = ":jCh6X!\\";
                    mkey = System.Text.Encoding.UTF8.GetBytes(strKeyPrivada.Substring(0, 8));
                    des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(strDesEncriptar.Replace("|", "+"));
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(mkey, mIV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    encoding = System.Text.Encoding.UTF8;
                    functionReturnValue = encoding.GetString(ms.ToArray());
                }
                catch (Exception e)
                {
                    functionReturnValue = "";
                }
                finally
                {
                    des = null;
                    ms = null;
                    cs = null;
                }
            }
            else
            {
                return Seguridad.Componente.decodificar(strDesEncriptar);
            }

            return functionReturnValue;
        }

        public static string Desencriptar(string strDesEncriptar)
        {
            string strKeyPrivada = "br>es/8K";
            string functionReturnValue = null;
            byte[] inputByteArray = new byte[strDesEncriptar.Length + 1];
            DESCryptoServiceProvider des = default(DESCryptoServiceProvider);
            MemoryStream ms = default(MemoryStream);
            CryptoStream cs = default(CryptoStream);
            System.Text.Encoding encoding = default(System.Text.Encoding);
            byte[] mIV = { 0x45, 0x32, 0xa5, 0x18, 0x67, 0x58, 0xac, 0xba };
            byte[] mkey = { };

            if (strKeyPrivada == "br>es/8K" || strKeyPrivada == "LAN")
            {
                try
                {
                    if (strKeyPrivada == "LAN") strKeyPrivada = ":jCh6X!\\";
                    mkey = System.Text.Encoding.UTF8.GetBytes(strKeyPrivada.Substring(0, 8));
                    des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(strDesEncriptar.Replace("|", "+"));
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(mkey, mIV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    encoding = System.Text.Encoding.UTF8;
                    functionReturnValue = encoding.GetString(ms.ToArray());
                }
                catch (Exception e)
                {
                    functionReturnValue = "";
                }
                finally
                {
                    des = null;
                    ms = null;
                    cs = null;
                }
            }
            else
            {
                return Seguridad.Componente.decodificar(strDesEncriptar);
            }

            return functionReturnValue;
        }


    }
}
