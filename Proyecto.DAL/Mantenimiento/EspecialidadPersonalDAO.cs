using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EspecialidadPersonalDAO
    {

        SqlCommand cmd = new();

        public List<EspecialidadPersonalDTO> ObtenerEspecialidadPersonals()
        {
            List<EspecialidadPersonalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPersonalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EspecialidadPersonalDTO()
                        {
                            EspecialidadPersonalId = Convert.ToInt32(dr["EspecialidadPersonalId"]),
                            DescEspecialidadPersonal = dr["DescEspecialidadPersonal"].ToString(),
                            CodigoEspecialidadPersonal = dr["CodigoEspecialidadPersonal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEspecialidadPersonal(EspecialidadPersonalDTO especialidadPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPersonalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEspecialidadPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescEspecialidadPersonal"].Value = especialidadPersonalDTO.DescEspecialidadPersonal;

                    cmd.Parameters.Add("@CodigoEspecialidadPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoEspecialidadPersonal"].Value = especialidadPersonalDTO.CodigoEspecialidadPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadPersonalDTO.UsuarioIngresoRegistro;

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

        public EspecialidadPersonalDTO BuscarEspecialidadPersonalID(int Codigo)
        {
            EspecialidadPersonalDTO especialidadPersonalDTO = new EspecialidadPersonalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPersonalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        especialidadPersonalDTO.EspecialidadPersonalId = Convert.ToInt32(dr["EspecialidadPersonalId"]);
                        especialidadPersonalDTO.DescEspecialidadPersonal = dr["DescEspecialidadPersonal"].ToString();
                        especialidadPersonalDTO.CodigoEspecialidadPersonal = dr["CodigoEspecialidadPersonal"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return especialidadPersonalDTO;
        }

        public string ActualizarEspecialidadPersonal(EspecialidadPersonalDTO especialidadPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPersonalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadPersonalId"].Value = especialidadPersonalDTO.EspecialidadPersonalId;

                    cmd.Parameters.Add("@DescEspecialidadPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEspecialidadPersonal"].Value = especialidadPersonalDTO.DescEspecialidadPersonal;

                    cmd.Parameters.Add("@CodigoEspecialidadPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEspecialidadPersonal"].Value = especialidadPersonalDTO.CodigoEspecialidadPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadPersonalDTO.UsuarioIngresoRegistro;

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

        public string EliminarEspecialidadPersonal(EspecialidadPersonalDTO especialidadPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPersonalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadPersonalId"].Value = especialidadPersonalDTO.EspecialidadPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadPersonalDTO.UsuarioIngresoRegistro;

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
