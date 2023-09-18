using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EstadoOperativoDAO
    {

        SqlCommand cmd = new();

        public List<EstadoOperativoDTO> ObtenerEstadoOperativos()
        {
            List<EstadoOperativoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EstadoOperativoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstadoOperativoDTO()
                        {
                            EstadoOperativoId = Convert.ToInt32(dr["EstadoOperativoId"]),
                            DescEstadoOperativo = dr["DescEstadoOperativo"].ToString(),
                            CodigoEstadoOperativo = dr["CodigoEstadoOperativo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEstadoOperativo(EstadoOperativoDTO estadoOperativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoOperativoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEstadoOperativo", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescEstadoOperativo"].Value = estadoOperativoDTO.DescEstadoOperativo;

                    cmd.Parameters.Add("@CodigoEstadoOperativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoOperativo"].Value = estadoOperativoDTO.CodigoEstadoOperativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoOperativoDTO.UsuarioIngresoRegistro;

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

        public EstadoOperativoDTO BuscarEstadoOperativoID(int Codigo)
        {
            EstadoOperativoDTO estadoOperativoDTO = new EstadoOperativoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoOperativoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoOperativoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoOperativoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        estadoOperativoDTO.EstadoOperativoId = Convert.ToInt32(dr["EstadoOperativoId"]);
                        estadoOperativoDTO.DescEstadoOperativo = dr["DescEstadoOperativo"].ToString();
                        estadoOperativoDTO.CodigoEstadoOperativo = dr["CodigoEstadoOperativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estadoOperativoDTO;
        }

        public string ActualizarEstadoOperativo(EstadoOperativoDTO estadoOperativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoOperativoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoOperativoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoOperativoId"].Value = estadoOperativoDTO.EstadoOperativoId;

                    cmd.Parameters.Add("@DescEstadoOperativo", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescEstadoOperativo"].Value = estadoOperativoDTO.DescEstadoOperativo;

                    cmd.Parameters.Add("@CodigoEstadoOperativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoOperativo"].Value = estadoOperativoDTO.CodigoEstadoOperativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoOperativoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEstadoOperativo(EstadoOperativoDTO estadoOperativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstadoOperativoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstadoOperativoId", SqlDbType.Int);
                    cmd.Parameters["@EstadoOperativoId"].Value = estadoOperativoDTO.EstadoOperativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estadoOperativoDTO.UsuarioIngresoRegistro;

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
