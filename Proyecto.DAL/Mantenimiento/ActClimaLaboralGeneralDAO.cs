using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ActClimaLaboralGeneralDAO
    {

        SqlCommand cmd = new();

        public List<ActClimaLaboralGeneralDTO> ObtenerActClimaLaboralGenerales()
        {
            List<ActClimaLaboralGeneralDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralGeneralListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActClimaLaboralGeneralDTO()
                        {
                            ActClimaLaboralGeneralId = Convert.ToInt32(dr["ActClimaLaboralGeneralId"]),
                            DescActClimaLaboralGeneral = dr["DescActClimaLaboralGeneral"].ToString(),
                            CodigoActClimaLaboralGeneral = dr["CodigoActClimaLaboralGeneral"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralGeneralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescActClimaLaboralGeneral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescActClimaLaboralGeneral"].Value = ActClimaLaboralGeneralDTO.DescActClimaLaboralGeneral;  
                    
                    cmd.Parameters.Add("@CodigoActClimaLaboralGeneral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActClimaLaboralGeneral"].Value = ActClimaLaboralGeneralDTO.CodigoActClimaLaboralGeneral;
                
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActClimaLaboralGeneralDTO.UsuarioIngresoRegistro;

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

        public ActClimaLaboralGeneralDTO BuscarActClimaLaboralGeneralID(int Codigo)
        {
            ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO = new ActClimaLaboralGeneralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralGeneralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActClimaLaboralGeneralId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralGeneralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ActClimaLaboralGeneralDTO.ActClimaLaboralGeneralId = Convert.ToInt32(dr["ActClimaLaboralGeneralId"]);
                        ActClimaLaboralGeneralDTO.DescActClimaLaboralGeneral = dr["DescActClimaLaboralGeneral"].ToString();
                        ActClimaLaboralGeneralDTO.CodigoActClimaLaboralGeneral = dr["CodigoActClimaLaboralGeneral"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ActClimaLaboralGeneralDTO;
        }

        public string ActualizarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralGeneralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActClimaLaboralGeneralId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralGeneralId"].Value = ActClimaLaboralGeneralDTO.ActClimaLaboralGeneralId;

                    cmd.Parameters.Add("@DescActClimaLaboralGeneral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescActClimaLaboralGeneral"].Value = ActClimaLaboralGeneralDTO.DescActClimaLaboralGeneral;

                    cmd.Parameters.Add("@CodigoActClimaLaboralGeneral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActClimaLaboralGeneral"].Value = ActClimaLaboralGeneralDTO.CodigoActClimaLaboralGeneral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActClimaLaboralGeneralDTO.UsuarioIngresoRegistro;

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

        public string EliminarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActClimaLaboralGeneralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActClimaLaboralGeneralId", SqlDbType.Int);
                    cmd.Parameters["@ActClimaLaboralGeneralId"].Value = ActClimaLaboralGeneralDTO.ActClimaLaboralGeneralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActClimaLaboralGeneralDTO.UsuarioIngresoRegistro;

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
