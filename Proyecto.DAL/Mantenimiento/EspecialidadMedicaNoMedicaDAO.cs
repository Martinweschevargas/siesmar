using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EspecialidadMedicaNoMedicaDAO
    {

        SqlCommand cmd = new();

        public List<EspecialidadMedicaNoMedicaDTO> ObtenerEspecialidadMedicaNoMedicas()
        {
            List<EspecialidadMedicaNoMedicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EspecialidadMedicaNoMedicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EspecialidadMedicaNoMedicaDTO()
                        {
                            EspecialidadMedicaNoMedicaId = Convert.ToInt32(dr["EspecialidadMedicaNoMedicaId"]),
                            DescEspecialidadMedicaNoMedica = dr["DescEspecialidadMedicaNoMedica"].ToString(),
                            CodigoUPS = dr["CodigoUPS"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEspecialidadMedicaNoMedica(EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadMedicaNoMedicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEspecialidadMedicaNoMedica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescEspecialidadMedicaNoMedica"].Value = especialidadMedicaNoMedicaDTO.DescEspecialidadMedicaNoMedica;

                    cmd.Parameters.Add("@CodigoUPS", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUPS"].Value = especialidadMedicaNoMedicaDTO.CodigoUPS;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadMedicaNoMedicaDTO.UsuarioIngresoRegistro;

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

        public EspecialidadMedicaNoMedicaDTO BuscarEspecialidadMedicaNoMedicaID(int Codigo)
        {
            EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO = new EspecialidadMedicaNoMedicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadMedicaNoMedicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadMedicaNoMedicaId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadMedicaNoMedicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        especialidadMedicaNoMedicaDTO.EspecialidadMedicaNoMedicaId = Convert.ToInt32(dr["EspecialidadMedicaNoMedicaId"]);
                        especialidadMedicaNoMedicaDTO.DescEspecialidadMedicaNoMedica = dr["DescEspecialidadMedicaNoMedica"].ToString();
                        especialidadMedicaNoMedicaDTO.CodigoUPS = dr["CodigoUPS"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return especialidadMedicaNoMedicaDTO;
        }

        public string ActualizarEspecialidadMedicaNoMedica(EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadMedicaNoMedicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadMedicaNoMedicaId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadMedicaNoMedicaId"].Value = especialidadMedicaNoMedicaDTO.EspecialidadMedicaNoMedicaId;

                    cmd.Parameters.Add("@DescEspecialidadMedicaNoMedica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescEspecialidadMedicaNoMedica"].Value = especialidadMedicaNoMedicaDTO.DescEspecialidadMedicaNoMedica;

                    cmd.Parameters.Add("@CodigoUPS", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUPS"].Value = especialidadMedicaNoMedicaDTO.CodigoUPS;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadMedicaNoMedicaDTO.UsuarioIngresoRegistro;

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

        public string EliminarEspecialidadMedicaNoMedica(EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadMedicaNoMedicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadMedicaNoMedicaId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadMedicaNoMedicaId"].Value = especialidadMedicaNoMedicaDTO.EspecialidadMedicaNoMedicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadMedicaNoMedicaDTO.UsuarioIngresoRegistro;

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
