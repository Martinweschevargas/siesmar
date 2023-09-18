using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ActClimaLaboralEspecificaDAO
    {

        SqlCommand cmd = new();

        public List<ActClimaLaboralEspecificaDTO> ObtenerActClimaLaboralEspecificas()
        {
            List<ActClimaLaboralEspecificaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralEspecificaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActClimaLaboralEspecificaDTO()
                        {
                            ActClimaLaboralEspecificaId = Convert.ToInt32(dr["ActClimaLaboralEspecificaId"]),
                            DescActClimaLaboralEspecifica = dr["DescActClimaLaboralEspecifica"].ToString(),
                            DescActClimaLaboralGeneral = dr["DescActClimaLaboralGeneral"].ToString(),
                            CodigoActClimaLaboralEspecifica = dr["CodigoActClimaLaboralEspecifica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarActClimaLaboralEspecifica(ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralEspecificaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescActClimaLaboralEspecifica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescActClimaLaboralEspecifica"].Value = actClimaLaboralEspecificaDTO.DescActClimaLaboralEspecifica;
                    
                    cmd.Parameters.Add("@CodigoActClimaLaboralEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActClimaLaboralEspecifica"].Value = actClimaLaboralEspecificaDTO.CodigoActClimaLaboralEspecifica;

                    cmd.Parameters.Add("@ActClimaLaboralGeneralId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralGeneralId"].Value = actClimaLaboralEspecificaDTO.ActClimaLaboralGeneralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actClimaLaboralEspecificaDTO.UsuarioIngresoRegistro;

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

        public ActClimaLaboralEspecificaDTO BuscarActClimaLaboralEspecificaID(int Codigo)
        {
            ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO = new ActClimaLaboralEspecificaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralEspecificaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActClimaLaboralEspecificaId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralEspecificaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        actClimaLaboralEspecificaDTO.ActClimaLaboralEspecificaId = Convert.ToInt32(dr["ActClimaLaboralEspecificaId"]);
                        actClimaLaboralEspecificaDTO.DescActClimaLaboralEspecifica = dr["DescActClimaLaboralEspecifica"].ToString();
                        actClimaLaboralEspecificaDTO.CodigoActClimaLaboralEspecifica = dr["CodigoActClimaLaboralEspecifica"].ToString();
                        actClimaLaboralEspecificaDTO.ActClimaLaboralGeneralId = Convert.ToInt32(dr["ActClimaLaboralGeneralId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actClimaLaboralEspecificaDTO;
        }

        public string ActualizarActClimaLaboralEspecifica(ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralEspecificaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActClimaLaboralEspecificaId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralEspecificaId"].Value = actClimaLaboralEspecificaDTO.ActClimaLaboralEspecificaId;

                    cmd.Parameters.Add("@DescActClimaLaboralEspecifica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescActClimaLaboralEspecifica"].Value = actClimaLaboralEspecificaDTO.DescActClimaLaboralEspecifica;

                    cmd.Parameters.Add("@CodigoActClimaLaboralEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActClimaLaboralEspecifica"].Value = actClimaLaboralEspecificaDTO.CodigoActClimaLaboralEspecifica;

                    cmd.Parameters.Add("@ActClimaLaboralGeneralId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralGeneralId"].Value = actClimaLaboralEspecificaDTO.ActClimaLaboralGeneralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actClimaLaboralEspecificaDTO.UsuarioIngresoRegistro;

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

        public string EliminarActClimaLaboralEspecifica(ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralEspecificaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActClimaLaboralEspecificaId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralEspecificaId"].Value = actClimaLaboralEspecificaDTO.ActClimaLaboralEspecificaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actClimaLaboralEspecificaDTO.UsuarioIngresoRegistro;

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
