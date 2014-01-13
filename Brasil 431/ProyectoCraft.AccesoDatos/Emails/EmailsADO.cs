using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Emails;

namespace ProyectoCraft.AccesoDatos.Emails
{
    public static class EmailsADO
    {
        public static PlantillaEmail ObtenerPlantillaPorTipo(Entidades.Enums.Enums.EmailTipoPlantilla tipo)
        {
            PlantillaEmail email = null;
            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_EMAIL_PLANTILLA_POR_TIPO");
                objParams[0].Value = tipo;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_EMAIL_PLANTILLA_POR_TIPO", objParams);
                while (objReader.Read())
                {
                    email = new PlantillaEmail();
                    email.Id = Convert.ToInt64(objReader["Id"]);
                    email.TipoEmail = (Entidades.Enums.Enums.EmailTipoPlantilla)Convert.ToInt16(objReader["IdTipoEmail"]);
                    email.TextoPlantilla = objReader["Descripcion"].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
                BaseDatos.CerrarConexion();
            }
            return email;
        }

         

    }
}
