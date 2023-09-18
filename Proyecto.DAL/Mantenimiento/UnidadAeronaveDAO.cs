using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadAeronaveDAO
    {

        SqlCommand cmd = new();

        public List<UnidadAeronaveDTO> ObtenerUnidadAeronaves()
        {
            List<UnidadAeronaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadAeronaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadAeronaveDTO()
                        {
                            UnidadAeronaveId = Convert.ToInt32(dr["UnidadAeronaveId"]),
                            DescUnidadAeronave = dr["DescUnidadAeronave"].ToString(),
                            CodigoUnidadAeronave = dr["CodigoUnidadAeronave"].ToString(),
                            DescTipoAeronave = dr["DescTipoAeronave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadAeronave(UnidadAeronaveDTO unidadAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadAeronaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUnidadAeronave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadAeronave"].Value = unidadAeronaveDTO.DescUnidadAeronave;

                    cmd.Parameters.Add("@CodigoUnidadAeronave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadAeronave"].Value = unidadAeronaveDTO.CodigoUnidadAeronave;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = unidadAeronaveDTO.TipoAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadAeronaveDTO.UsuarioIngresoRegistro;

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

        public UnidadAeronaveDTO BuscarUnidadAeronaveID(int Codigo)
        {
            UnidadAeronaveDTO unidadAeronaveDTO = new UnidadAeronaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadAeronaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@UnidadAeronaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadAeronaveDTO.UnidadAeronaveId = Convert.ToInt32(dr["UnidadAeronaveId"]);
                        unidadAeronaveDTO.DescUnidadAeronave = dr["DescUnidadAeronave"].ToString();
                        unidadAeronaveDTO.CodigoUnidadAeronave = dr["CodigoUnidadAeronave"].ToString();
                        unidadAeronaveDTO.TipoAeronaveId = Convert.ToInt32(dr["TipoAeronaveId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadAeronaveDTO;
        }

        public string ActualizarUnidadAeronave(UnidadAeronaveDTO unidadAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_UnidadAeronaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@UnidadAeronaveId"].Value = unidadAeronaveDTO.UnidadAeronaveId;

                    cmd.Parameters.Add("@DescUnidadAeronave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadAeronave"].Value = unidadAeronaveDTO.DescUnidadAeronave;

                    cmd.Parameters.Add("@CodigoUnidadAeronave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadAeronave"].Value = unidadAeronaveDTO.CodigoUnidadAeronave;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = unidadAeronaveDTO.TipoAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadAeronaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadAeronave(UnidadAeronaveDTO unidadAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadAeronaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@UnidadAeronaveId"].Value = unidadAeronaveDTO.UnidadAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadAeronaveDTO.UsuarioIngresoRegistro;

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
