using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MotivoEmergenciaDAO
    {

        SqlCommand cmd = new();

        public List<MotivoEmergenciaDTO> ObtenerMotivoEmergencias()
        {
            List<MotivoEmergenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MotivoEmergenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MotivoEmergenciaDTO()
                        {
                            MotivoEmergenciaId = Convert.ToInt32(dr["MotivoEmergenciaId"]),
                            DescMotivoEmergencia = dr["DescMotivoEmergencia"].ToString(),
                            CodigoMotivoEmergencia = dr["CodigoMotivoEmergencia"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMotivoEmergencia(MotivoEmergenciaDTO motivoEmergenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoEmergenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMotivoEmergencia", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescMotivoEmergencia"].Value = motivoEmergenciaDTO.DescMotivoEmergencia;

                    cmd.Parameters.Add("@CodigoMotivoEmergencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMotivoEmergencia"].Value = motivoEmergenciaDTO.CodigoMotivoEmergencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoEmergenciaDTO.UsuarioIngresoRegistro;

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

        public MotivoEmergenciaDTO BuscarMotivoEmergenciaID(int Codigo)
        {
            MotivoEmergenciaDTO motivoEmergenciaDTO = new MotivoEmergenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoEmergenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoEmergenciaId", SqlDbType.Int);
                    cmd.Parameters["@MotivoEmergenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        motivoEmergenciaDTO.MotivoEmergenciaId = Convert.ToInt32(dr["MotivoEmergenciaId"]);
                        motivoEmergenciaDTO.DescMotivoEmergencia = dr["DescMotivoEmergencia"].ToString();
                        motivoEmergenciaDTO.CodigoMotivoEmergencia = dr["CodigoMotivoEmergencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return motivoEmergenciaDTO;
        }

        public string ActualizarMotivoEmergencia(MotivoEmergenciaDTO motivoEmergenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoEmergenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoEmergenciaId", SqlDbType.Int);
                    cmd.Parameters["@MotivoEmergenciaId"].Value = motivoEmergenciaDTO.MotivoEmergenciaId;

                    cmd.Parameters.Add("@DescMotivoEmergencia", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescMotivoEmergencia"].Value = motivoEmergenciaDTO.DescMotivoEmergencia;

                    cmd.Parameters.Add("@CodigoMotivoEmergencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMotivoEmergencia"].Value = motivoEmergenciaDTO.CodigoMotivoEmergencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoEmergenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarMotivoEmergencia(MotivoEmergenciaDTO motivoEmergenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoEmergenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoEmergenciaId", SqlDbType.Int);
                    cmd.Parameters["@MotivoEmergenciaId"].Value = motivoEmergenciaDTO.MotivoEmergenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoEmergenciaDTO.UsuarioIngresoRegistro;

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
