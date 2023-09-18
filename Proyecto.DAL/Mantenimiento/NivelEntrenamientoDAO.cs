using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class NivelEntrenamientoDAO
    {

        SqlCommand cmd = new();

        public List<NivelEntrenamientoDTO> ObtenerNivelEntrenamientos()
        {
            List<NivelEntrenamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_NivelEntrenamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NivelEntrenamientoDTO()
                        {
                            NivelEntrenamientoId = Convert.ToInt32(dr["NivelEntrenamientoId"]),
                            DescNivelEntrenamiento = dr["DescNivelEntrenamiento"].ToString(),
                            CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarNivelEntrenamiento(NivelEntrenamientoDTO nivelEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelEntrenamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescNivelEntrenamiento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescNivelEntrenamiento"].Value = nivelEntrenamientoDTO.DescNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = nivelEntrenamientoDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelEntrenamientoDTO.UsuarioIngresoRegistro;

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

        public NivelEntrenamientoDTO BuscarNivelEntrenamientoID(int Codigo)
        {
            NivelEntrenamientoDTO nivelEntrenamientoDTO = new NivelEntrenamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelEntrenamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        nivelEntrenamientoDTO.NivelEntrenamientoId = Convert.ToInt32(dr["NivelEntrenamientoId"]);
                        nivelEntrenamientoDTO.DescNivelEntrenamiento = dr["DescNivelEntrenamiento"].ToString();
                        nivelEntrenamientoDTO.CodigoNivelEntrenamiento = dr["CodigoNivelEntrenamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return nivelEntrenamientoDTO;
        }

        public string ActualizarNivelEntrenamiento(NivelEntrenamientoDTO nivelEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelEntrenamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelEntrenamientoId"].Value = nivelEntrenamientoDTO.NivelEntrenamientoId;

                    cmd.Parameters.Add("@DescNivelEntrenamiento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescNivelEntrenamiento"].Value = nivelEntrenamientoDTO.DescNivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoNivelEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEntrenamiento"].Value = nivelEntrenamientoDTO.CodigoNivelEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelEntrenamientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarNivelEntrenamiento(NivelEntrenamientoDTO nivelEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelEntrenamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelEntrenamientoId"].Value = nivelEntrenamientoDTO.NivelEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelEntrenamientoDTO.UsuarioIngresoRegistro;

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
