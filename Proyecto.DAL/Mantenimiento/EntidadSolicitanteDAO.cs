using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EntidadSolicitanteDAO
    {

        SqlCommand cmd = new();

        public List<EntidadSolicitanteDTO> ObtenerEntidadSolicitantes()
        {
            List<EntidadSolicitanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EntidadSolicitanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntidadSolicitanteDTO()
                        {
                            EntidadSolicitanteId = Convert.ToInt32(dr["EntidadSolicitanteId"]),
                            DescEntidadSolicitante = dr["DescEntidadSolicitante"].ToString(),
                            CodigoEntidadSolicitante = dr["CodigoEntidadSolicitante"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEntidadSolicitante(EntidadSolicitanteDTO entidadSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadSolicitanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEntidadSolicitante", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescEntidadSolicitante"].Value = entidadSolicitanteDTO.DescEntidadSolicitante;

                    cmd.Parameters.Add("@CodigoEntidadSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadSolicitante"].Value = entidadSolicitanteDTO.CodigoEntidadSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadSolicitanteDTO.UsuarioIngresoRegistro;

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

        public EntidadSolicitanteDTO BuscarEntidadSolicitanteID(int Codigo)
        {
            EntidadSolicitanteDTO entidadSolicitanteDTO = new EntidadSolicitanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadSolicitanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@EntidadSolicitanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entidadSolicitanteDTO.EntidadSolicitanteId = Convert.ToInt32(dr["EntidadSolicitanteId"]);
                        entidadSolicitanteDTO.DescEntidadSolicitante = dr["DescEntidadSolicitante"].ToString();
                        entidadSolicitanteDTO.CodigoEntidadSolicitante = dr["CodigoEntidadSolicitante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entidadSolicitanteDTO;
        }

        public string ActualizarEntidadSolicitante(EntidadSolicitanteDTO entidadSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadSolicitanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@EntidadSolicitanteId"].Value = entidadSolicitanteDTO.EntidadSolicitanteId;

                    cmd.Parameters.Add("@DescEntidadSolicitante", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescEntidadSolicitante"].Value = entidadSolicitanteDTO.DescEntidadSolicitante;

                    cmd.Parameters.Add("@CodigoEntidadSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadSolicitante"].Value = entidadSolicitanteDTO.CodigoEntidadSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadSolicitanteDTO.UsuarioIngresoRegistro;

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

        public string EliminarEntidadSolicitante(EntidadSolicitanteDTO entidadSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadSolicitanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@EntidadSolicitanteId"].Value = entidadSolicitanteDTO.EntidadSolicitanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadSolicitanteDTO.UsuarioIngresoRegistro;

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
