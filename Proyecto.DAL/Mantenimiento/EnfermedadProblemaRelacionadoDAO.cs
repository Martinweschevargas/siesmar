using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EnfermedadProblemaRelacionadoDAO
    {

        SqlCommand cmd = new();

        public List<EnfermedadProblemaRelacionadoDTO> ObtenerEnfermedadProblemaRelacionados()
        {
            List<EnfermedadProblemaRelacionadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EnfermedadProblemaRelacionadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EnfermedadProblemaRelacionadoDTO()
                        {
                            EnfermedadProblemaRelacionadoId = Convert.ToInt32(dr["EnfermedadProblemaRelacionadoId"]),
                            DescEnfermedadProblemaRelacionado = dr["DescEnfermedadProblemaRelacionado"].ToString(),
                            CodigoEnfermedadProblemaRelacionado = dr["CodigoEnfermedadProblemaRelacionado"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEnfermedadProblemaRelacionado(EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EnfermedadProblemaRelacionadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEnfermedadProblemaRelacionado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescEnfermedadProblemaRelacionado"].Value = enfermedadProblemaRelacionadoDTO.DescEnfermedadProblemaRelacionado;

                    cmd.Parameters.Add("@CodigoEnfermedadProblemaRelacionado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEnfermedadProblemaRelacionado"].Value = enfermedadProblemaRelacionadoDTO.CodigoEnfermedadProblemaRelacionado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = enfermedadProblemaRelacionadoDTO.UsuarioIngresoRegistro;

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

        public EnfermedadProblemaRelacionadoDTO BuscarEnfermedadProblemaRelacionadoID(int Codigo)
        {
            EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO = new EnfermedadProblemaRelacionadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EnfermedadProblemaRelacionadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EnfermedadProblemaRelacionadoId", SqlDbType.Int);
                    cmd.Parameters["@EnfermedadProblemaRelacionadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        enfermedadProblemaRelacionadoDTO.EnfermedadProblemaRelacionadoId = Convert.ToInt32(dr["EnfermedadProblemaRelacionadoId"]);
                        enfermedadProblemaRelacionadoDTO.DescEnfermedadProblemaRelacionado = dr["DescEnfermedadProblemaRelacionado"].ToString();
                        enfermedadProblemaRelacionadoDTO.CodigoEnfermedadProblemaRelacionado = dr["CodigoEnfermedadProblemaRelacionado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return enfermedadProblemaRelacionadoDTO;
        }

        public string ActualizarEnfermedadProblemaRelacionado(EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EnfermedadProblemaRelacionadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EnfermedadProblemaRelacionadoId", SqlDbType.Int);
                    cmd.Parameters["@EnfermedadProblemaRelacionadoId"].Value = enfermedadProblemaRelacionadoDTO.EnfermedadProblemaRelacionadoId;

                    cmd.Parameters.Add("@DescEnfermedadProblemaRelacionado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescEnfermedadProblemaRelacionado"].Value = enfermedadProblemaRelacionadoDTO.DescEnfermedadProblemaRelacionado;

                    cmd.Parameters.Add("@CodigoEnfermedadProblemaRelacionado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEnfermedadProblemaRelacionado"].Value = enfermedadProblemaRelacionadoDTO.CodigoEnfermedadProblemaRelacionado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = enfermedadProblemaRelacionadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEnfermedadProblemaRelacionado(EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EnfermedadProblemaRelacionadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EnfermedadProblemaRelacionadoId", SqlDbType.Int);
                    cmd.Parameters["@EnfermedadProblemaRelacionadoId"].Value = enfermedadProblemaRelacionadoDTO.EnfermedadProblemaRelacionadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = enfermedadProblemaRelacionadoDTO.UsuarioIngresoRegistro;

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
