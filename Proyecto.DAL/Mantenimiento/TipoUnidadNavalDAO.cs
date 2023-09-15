using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoUnidadNavalDAO
    {

        SqlCommand cmd = new();

        public List<TipoUnidadNavalDTO> ObtenerTipoUnidadNavals()
        {
            List<TipoUnidadNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoUnidadNavalDTO()
                        {
                            TipoUnidadNavalId = Convert.ToInt32(dr["TipoUnidadNavalId"]),
                            DescTipoUnidadNaval = dr["DescTipoUnidadNaval"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoUnidadNaval(TipoUnidadNavalDTO tipoUnidadNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoUnidadNaval", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoUnidadNaval"].Value = tipoUnidadNavalDTO.DescTipoUnidadNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoUnidadNavalDTO.UsuarioIngresoRegistro;

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

        public TipoUnidadNavalDTO BuscarTipoUnidadNavalID(int Codigo)
        {
            TipoUnidadNavalDTO tipoUnidadNavalDTO = new TipoUnidadNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoUnidadNavalDTO.TipoUnidadNavalId = Convert.ToInt32(dr["TipoUnidadNavalId"]);
                        tipoUnidadNavalDTO.DescTipoUnidadNaval = dr["DescTipoUnidadNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoUnidadNavalDTO;
        }

        public string ActualizarTipoUnidadNaval(TipoUnidadNavalDTO tipoUnidadNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalId"].Value = tipoUnidadNavalDTO.TipoUnidadNavalId;

                    cmd.Parameters.Add("@DescTipoUnidadNaval", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoUnidadNaval"].Value = tipoUnidadNavalDTO.DescTipoUnidadNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoUnidadNavalDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarTipoUnidadNaval(TipoUnidadNavalDTO tipoUnidadNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalId"].Value = tipoUnidadNavalDTO.TipoUnidadNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoUnidadNavalDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

    }
}
