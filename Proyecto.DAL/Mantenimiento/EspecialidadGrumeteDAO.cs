using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EspecialidadGrumeteDAO
    {

        SqlCommand cmd = new();

        public List<EspecialidadGrumeteDTO> ObtenerEspecialidadGrumetes()
        {
            List<EspecialidadGrumeteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGrumeteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EspecialidadGrumeteDTO()
                        {
                            EspecialidadGrumeteId = Convert.ToInt32(dr["EspecialidadGrumeteId"]),
                            DescEspecialidadGrumete = dr["DescEspecialidadGrumete"].ToString(),
                            CodigoEspecialidadGrumete = dr["CodigoEspecialidadGrumete"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEspecialidadGrumete(EspecialidadGrumeteDTO especialidadGrumeteDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGrumeteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEspecialidadGrumete", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescEspecialidadGrumete"].Value = especialidadGrumeteDTO.DescEspecialidadGrumete;

                    cmd.Parameters.Add("@CodigoEspecialidadGrumete", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoEspecialidadGrumete"].Value = especialidadGrumeteDTO.CodigoEspecialidadGrumete;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadGrumeteDTO.UsuarioIngresoRegistro;

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

        public EspecialidadGrumeteDTO BuscarEspecialidadGrumeteID(int Codigo)
        {
            EspecialidadGrumeteDTO especialidadGrumeteDTO = new EspecialidadGrumeteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGrumeteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGrumeteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        especialidadGrumeteDTO.EspecialidadGrumeteId = Convert.ToInt32(dr["EspecialidadGrumeteId"]);
                        especialidadGrumeteDTO.DescEspecialidadGrumete = dr["DescEspecialidadGrumete"].ToString();
                        especialidadGrumeteDTO.CodigoEspecialidadGrumete = dr["CodigoEspecialidadGrumete"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return especialidadGrumeteDTO;
        }

        public string ActualizarEspecialidadGrumete(EspecialidadGrumeteDTO especialidadGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGrumeteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGrumeteId"].Value = especialidadGrumeteDTO.EspecialidadGrumeteId;

                    cmd.Parameters.Add("@DescEspecialidadGrumete", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEspecialidadGrumete"].Value = especialidadGrumeteDTO.DescEspecialidadGrumete;

                    cmd.Parameters.Add("@CodigoEspecialidadGrumete", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEspecialidadGrumete"].Value = especialidadGrumeteDTO.CodigoEspecialidadGrumete;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadGrumeteDTO.UsuarioIngresoRegistro;

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

        public string EliminarEspecialidadGrumete(EspecialidadGrumeteDTO especialidadGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGrumeteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGrumeteId"].Value = especialidadGrumeteDTO.EspecialidadGrumeteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadGrumeteDTO.UsuarioIngresoRegistro;

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
