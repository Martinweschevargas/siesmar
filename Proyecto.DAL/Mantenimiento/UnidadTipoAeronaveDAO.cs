using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadTipoAeronaveDAO
    {

        SqlCommand cmd = new();

        public List<UnidadTipoAeronaveDTO> ObtenerUnidadTipoAeronaves()
        {
            List<UnidadTipoAeronaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadTipoAeronaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadTipoAeronaveDTO()
                        {
                            UnidadTipoAeronaveId = Convert.ToInt32(dr["UnidadTipoAeronaveId"]),
                            DescUnidadTipoAeronave = dr["DescUnidadTipoAeronave"].ToString(),
                            CodigoUnidadTipoAeronave = dr["CodigoUnidadTipoAeronave"].ToString(),
                            DescTipoAeronave = dr["DescTipoAeronave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadTipoAeronave(UnidadTipoAeronaveDTO unidadTipoAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadTipoAeronaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUnidadTipoAeronave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadTipoAeronave"].Value = unidadTipoAeronaveDTO.DescUnidadTipoAeronave;

                    cmd.Parameters.Add("@CodigoUnidadTipoAeronave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadTipoAeronave"].Value = unidadTipoAeronaveDTO.CodigoUnidadTipoAeronave;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = unidadTipoAeronaveDTO.TipoAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadTipoAeronaveDTO.UsuarioIngresoRegistro;

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

        public UnidadTipoAeronaveDTO BuscarUnidadTipoAeronaveID(int Codigo)
        {
            UnidadTipoAeronaveDTO unidadTipoAeronaveDTO = new UnidadTipoAeronaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadTipoAeronaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadTipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@UnidadTipoAeronaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadTipoAeronaveDTO.UnidadTipoAeronaveId = Convert.ToInt32(dr["UnidadTipoAeronaveId"]);
                        unidadTipoAeronaveDTO.DescUnidadTipoAeronave = dr["DescUnidadTipoAeronave"].ToString();
                        unidadTipoAeronaveDTO.CodigoUnidadTipoAeronave = dr["CodigoUnidadTipoAeronave"].ToString();
                        unidadTipoAeronaveDTO.TipoAeronaveId = Convert.ToInt32(dr["TipoAeronaveId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadTipoAeronaveDTO;
        }

        public string ActualizarUnidadTipoAeronave(UnidadTipoAeronaveDTO unidadTipoAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_UnidadTipoAeronaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadTipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@UnidadTipoAeronaveId"].Value = unidadTipoAeronaveDTO.UnidadTipoAeronaveId;

                    cmd.Parameters.Add("@DescUnidadTipoAeronave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadTipoAeronave"].Value = unidadTipoAeronaveDTO.DescUnidadTipoAeronave;

                    cmd.Parameters.Add("@CodigoUnidadTipoAeronave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadTipoAeronave"].Value = unidadTipoAeronaveDTO.CodigoUnidadTipoAeronave;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = unidadTipoAeronaveDTO.TipoAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadTipoAeronaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadTipoAeronave(UnidadTipoAeronaveDTO unidadTipoAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadTipoAeronaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadTipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@UnidadTipoAeronaveId"].Value = unidadTipoAeronaveDTO.UnidadTipoAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadTipoAeronaveDTO.UsuarioIngresoRegistro;

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
