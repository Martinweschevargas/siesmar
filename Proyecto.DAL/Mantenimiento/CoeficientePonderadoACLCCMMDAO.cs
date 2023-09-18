using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CoeficientePonderadoACLCCMMDAO
    {

        SqlCommand cmd = new();

        public List<CoeficientePonderadoACLCCMMDTO> ObtenerCoeficientePonderadoACLCCMMs()
        {
            List<CoeficientePonderadoACLCCMMDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLCCMMListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CoeficientePonderadoACLCCMMDTO()
                        {
                            CoeficientePonderadoACLCCMMId = Convert.ToInt32(dr["CoeficientePonderadoACLCCMMId"]),
                            CombustibleLubricante = dr["CombustibleLubricante"].ToString(),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]),
                            CLExistente = Convert.ToInt32(dr["CLExistente"]),
                            CLRequerido = Convert.ToInt32(dr["CLRequerido"]),
                            Total = Convert.ToInt32(dr["Total"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCoeficientePonderadoACLCCMM(CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLCCMMRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CombustibleLubricante"].Value = coeficientePonderadoACLCCMMDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoACLCCMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CLExistente", SqlDbType.Int);
                    cmd.Parameters["@CLExistente"].Value = coeficientePonderadoACLCCMMDTO.CLExistente;

                    cmd.Parameters.Add("@CLRequerido", SqlDbType.Int);
                    cmd.Parameters["@CLRequerido"].Value = coeficientePonderadoACLCCMMDTO.CLRequerido;

                    cmd.Parameters.Add("@Total", SqlDbType.Int);
                    cmd.Parameters["@Total"].Value = coeficientePonderadoACLCCMMDTO.Total;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoACLCCMMDTO.UsuarioIngresoRegistro;

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

        public CoeficientePonderadoACLCCMMDTO BuscarCoeficientePonderadoACLCCMMID(int Codigo)
        {
            CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO = new CoeficientePonderadoACLCCMMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLCCMMEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoACLCCMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoACLCCMMId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        coeficientePonderadoACLCCMMDTO.CoeficientePonderadoACLCCMMId = Convert.ToInt32(dr["CoeficientePonderadoACLCCMMId"]);
                        coeficientePonderadoACLCCMMDTO.CombustibleLubricante = dr["CombustibleLubricante"].ToString();
                        coeficientePonderadoACLCCMMDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]);
                        coeficientePonderadoACLCCMMDTO.CLExistente = Convert.ToInt32(dr["CLExistente"]);
                        coeficientePonderadoACLCCMMDTO.CLRequerido = Convert.ToInt32(dr["CLRequerido"]);
                        coeficientePonderadoACLCCMMDTO.Total = Convert.ToInt32(dr["Total"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return coeficientePonderadoACLCCMMDTO;
        }

        public string ActualizarCoeficientePonderadoACLCCMM(CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLCCMMActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoACLCCMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoACLCCMMId"].Value = coeficientePonderadoACLCCMMDTO.CoeficientePonderadoACLCCMMId;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CombustibleLubricante"].Value = coeficientePonderadoACLCCMMDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoACLCCMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CLExistente", SqlDbType.Int);
                    cmd.Parameters["@CLExistente"].Value = coeficientePonderadoACLCCMMDTO.CLExistente;

                    cmd.Parameters.Add("@CLRequerido", SqlDbType.Int);
                    cmd.Parameters["@CLRequerido"].Value = coeficientePonderadoACLCCMMDTO.CLRequerido;

                    cmd.Parameters.Add("@Total", SqlDbType.Int);
                    cmd.Parameters["@Total"].Value = coeficientePonderadoACLCCMMDTO.Total;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoACLCCMMDTO.UsuarioIngresoRegistro;

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

        public string EliminarCoeficientePonderadoACLCCMM(CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLCCMMEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoACLCCMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoACLCCMMId"].Value = coeficientePonderadoACLCCMMDTO.CoeficientePonderadoACLCCMMId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoACLCCMMDTO.UsuarioIngresoRegistro;

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
