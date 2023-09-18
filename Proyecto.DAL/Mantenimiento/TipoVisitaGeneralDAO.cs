
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoVisitaGeneralDAO
    {

        SqlCommand cmd = new();

        public List<TipoVisitaGeneralDTO> ObtenerTipoVisitaGenerals()
        {
            List<TipoVisitaGeneralDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoVisitaGeneralListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoVisitaGeneralDTO()
                        {
                            TipoVisitaGeneralId = Convert.ToInt32(dr["TipoVisitaGeneralId"]),
                            DescTipoVisitaGeneral = dr["DescTipoVisitaGeneral"].ToString(),
                            CodigoTipoVisitaGeneral = dr["CodigoTipoVisitaGeneral"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoVisitaGeneral(TipoVisitaGeneralDTO tipoVisitaGeneralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVisitaGeneralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoVisitaGeneral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoVisitaGeneral"].Value = tipoVisitaGeneralDTO.DescTipoVisitaGeneral;

                    cmd.Parameters.Add("@CodigoTipoVisitaGeneral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoVisitaGeneral"].Value = tipoVisitaGeneralDTO.CodigoTipoVisitaGeneral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVisitaGeneralDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public TipoVisitaGeneralDTO BuscarTipoVisitaGeneralID(int Codigo)
        {
            TipoVisitaGeneralDTO tipoVisitaGeneralDTO = new TipoVisitaGeneralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVisitaGeneralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVisitaGeneralId", SqlDbType.Int);
                    cmd.Parameters["@TipoVisitaGeneralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoVisitaGeneralDTO.TipoVisitaGeneralId = Convert.ToInt32(dr["TipoVisitaGeneralId"]);
                        tipoVisitaGeneralDTO.DescTipoVisitaGeneral = dr["DescTipoVisitaGeneral"].ToString();
                        tipoVisitaGeneralDTO.CodigoTipoVisitaGeneral = dr["CodigoTipoVisitaGeneral"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoVisitaGeneralDTO;
        }

        public string ActualizarTipoVisitaGeneral(TipoVisitaGeneralDTO tipoVisitaGeneralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoVisitaGeneralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVisitaGeneralId", SqlDbType.Int);
                    cmd.Parameters["@TipoVisitaGeneralId"].Value = tipoVisitaGeneralDTO.TipoVisitaGeneralId;

                    cmd.Parameters.Add("@DescTipoVisitaGeneral", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoVisitaGeneral"].Value = tipoVisitaGeneralDTO.DescTipoVisitaGeneral;

                    cmd.Parameters.Add("@CodigoTipoVisitaGeneral", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoVisitaGeneral"].Value = tipoVisitaGeneralDTO.CodigoTipoVisitaGeneral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVisitaGeneralDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarTipoVisitaGeneral(TipoVisitaGeneralDTO tipoVisitaGeneralDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVisitaGeneralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVisitaGeneralId", SqlDbType.Int);
                    cmd.Parameters["@TipoVisitaGeneralId"].Value = tipoVisitaGeneralDTO.TipoVisitaGeneralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVisitaGeneralDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
