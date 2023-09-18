using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EspecialidadGenericaDAO
    {

        SqlCommand cmd = new();

        public List<EspecialidadGenericaDTO> ObtenerEspecialidadGenericas()
        {
            List<EspecialidadGenericaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGenericaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EspecialidadGenericaDTO()
                        {
                            EspecialidadGenericaId = Convert.ToInt32(dr["EspecialidadGenericaId"]),
                            DescEspecialidadGenerica = dr["DescEspecialidadGenerica"].ToString(),
                            CodigoEspecialidadGenerica = dr["CodigoEspecialidadGenerica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEspecialidadGenerica(EspecialidadGenericaDTO EspecialidadGenericaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGenericaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEspecialidadGenerica", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescEspecialidadGenerica"].Value = EspecialidadGenericaDTO.DescEspecialidadGenerica;

                    cmd.Parameters.Add("@CodigoEspecialidadGenerica", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoEspecialidadGenerica"].Value = EspecialidadGenericaDTO.CodigoEspecialidadGenerica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EspecialidadGenericaDTO.UsuarioIngresoRegistro;

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

        public EspecialidadGenericaDTO BuscarEspecialidadGenericaID(int Codigo)
        {
            EspecialidadGenericaDTO EspecialidadGenericaDTO = new EspecialidadGenericaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGenericaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGenericaId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        EspecialidadGenericaDTO.EspecialidadGenericaId = Convert.ToInt32(dr["EspecialidadGenericaId"]);
                        EspecialidadGenericaDTO.DescEspecialidadGenerica = dr["DescEspecialidadGenerica"].ToString();
                        EspecialidadGenericaDTO.CodigoEspecialidadGenerica = dr["CodigoEspecialidadGenerica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return EspecialidadGenericaDTO;
        }

        public string ActualizarEspecialidadGenerica(EspecialidadGenericaDTO EspecialidadGenericaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGenericaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGenericaId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaId"].Value = EspecialidadGenericaDTO.EspecialidadGenericaId;

                    cmd.Parameters.Add("@DescEspecialidadGenerica", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescEspecialidadGenerica"].Value = EspecialidadGenericaDTO.DescEspecialidadGenerica;

                    cmd.Parameters.Add("@CodigoEspecialidadGenerica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEspecialidadGenerica"].Value = EspecialidadGenericaDTO.CodigoEspecialidadGenerica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EspecialidadGenericaDTO.UsuarioIngresoRegistro;

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

        public string EliminarEspecialidadGenerica(EspecialidadGenericaDTO EspecialidadGenericaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadGenericaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadGenericaId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaId"].Value = EspecialidadGenericaDTO.EspecialidadGenericaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EspecialidadGenericaDTO.UsuarioIngresoRegistro;

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
