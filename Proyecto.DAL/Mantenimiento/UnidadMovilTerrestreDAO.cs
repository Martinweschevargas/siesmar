using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadMovilTerrestreDAO
    {

        SqlCommand cmd = new();

        public List<UnidadMovilTerrestreDTO> ObtenerUnidadMovilTerrestres()
        {
            List<UnidadMovilTerrestreDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadMovilTerrestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadMovilTerrestreDTO()
                        {
                            UnidadMovilTerrestreId = Convert.ToInt32(dr["UnidadMovilTerrestreId"]),
                            PlacaUnidadMovilTerrestre = dr["PlacaUnidadMovilTerrestre"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            DescTipoVehiculoMovil = dr["DescTipoVehiculoMovil"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadMovilTerrestre(UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMovilTerrestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlacaUnidadMovilTerrestre", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PlacaUnidadMovilTerrestre"].Value = UnidadMovilTerrestreDTO.PlacaUnidadMovilTerrestre;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = UnidadMovilTerrestreDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = UnidadMovilTerrestreDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UnidadMovilTerrestreDTO.UsuarioIngresoRegistro;

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

        public UnidadMovilTerrestreDTO BuscarUnidadMovilTerrestreID(int Codigo)
        {
            UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO = new UnidadMovilTerrestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMovilTerrestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadMovilTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMovilTerrestreId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        UnidadMovilTerrestreDTO.UnidadMovilTerrestreId = Convert.ToInt32(dr["UnidadMovilTerrestreId"]);
                        UnidadMovilTerrestreDTO.PlacaUnidadMovilTerrestre = dr["PlacaUnidadMovilTerrestre"].ToString();
                        UnidadMovilTerrestreDTO.MarcaVehiculoId = Convert.ToInt32(dr["MarcaVehiculoId"]);
                        UnidadMovilTerrestreDTO.TipoVehiculoMovilId = Convert.ToInt32(dr["TipoVehiculoMovilId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return UnidadMovilTerrestreDTO;
        }

        public string ActualizarUnidadMovilTerrestre(UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMovilTerrestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadMovilTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMovilTerrestreId"].Value = UnidadMovilTerrestreDTO.UnidadMovilTerrestreId;

                    cmd.Parameters.Add("@PlacaUnidadMovilTerrestre", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PlacaUnidadMovilTerrestre"].Value = UnidadMovilTerrestreDTO.PlacaUnidadMovilTerrestre;

                    cmd.Parameters.Add("@MarcaVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MarcaVehiculoId"].Value = UnidadMovilTerrestreDTO.MarcaVehiculoId;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = UnidadMovilTerrestreDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UnidadMovilTerrestreDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadMovilTerrestre(UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMovilTerrestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadMovilTerrestreId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMovilTerrestreId"].Value = UnidadMovilTerrestreDTO.UnidadMovilTerrestreId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UnidadMovilTerrestreDTO.UsuarioIngresoRegistro;

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
