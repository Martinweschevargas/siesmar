using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CoeficientePonderadoACLFFMMDAO
    {

        SqlCommand cmd = new();

        public List<CoeficientePonderadoACLFFMMDTO> ObtenerCoeficientePonderadoACLFFMMs()
        {
            List<CoeficientePonderadoACLFFMMDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLFFMMListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CoeficientePonderadoACLFFMMDTO()
                        {
                            CoeficientePonderadoACLFFMMId = Convert.ToInt32(dr["CoeficientePonderadoACLFFMMId"]),
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

        public string AgregarCoeficientePonderadoACLFFMM(CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLFFMMRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CombustibleLubricante"].Value = coeficientePonderadoACLFFMMDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoACLFFMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CLExistente", SqlDbType.Int);
                    cmd.Parameters["@CLExistente"].Value = coeficientePonderadoACLFFMMDTO.CLExistente;

                    cmd.Parameters.Add("@CLRequerido", SqlDbType.Int);
                    cmd.Parameters["@CLRequerido"].Value = coeficientePonderadoACLFFMMDTO.CLRequerido;

                    cmd.Parameters.Add("@Total", SqlDbType.Int);
                    cmd.Parameters["@Total"].Value = coeficientePonderadoACLFFMMDTO.Total;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoACLFFMMDTO.UsuarioIngresoRegistro;

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

        public CoeficientePonderadoACLFFMMDTO BuscarCoeficientePonderadoACLFFMMID(int Codigo)
        {
            CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO = new CoeficientePonderadoACLFFMMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLFFMMEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoACLFFMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoACLFFMMId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        coeficientePonderadoACLFFMMDTO.CoeficientePonderadoACLFFMMId = Convert.ToInt32(dr["CoeficientePonderadoACLFFMMId"]);
                        coeficientePonderadoACLFFMMDTO.CombustibleLubricante = dr["CombustibleLubricante"].ToString();
                        coeficientePonderadoACLFFMMDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]);
                        coeficientePonderadoACLFFMMDTO.CLExistente = Convert.ToInt32(dr["CLExistente"]);
                        coeficientePonderadoACLFFMMDTO.CLRequerido = Convert.ToInt32(dr["CLRequerido"]);
                        coeficientePonderadoACLFFMMDTO.Total = Convert.ToInt32(dr["Total"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return coeficientePonderadoACLFFMMDTO;
        }

        public string ActualizarCoeficientePonderadoACLFFMM(CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLFFMMActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoACLFFMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoACLFFMMId"].Value = coeficientePonderadoACLFFMMDTO.CoeficientePonderadoACLFFMMId;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CombustibleLubricante"].Value = coeficientePonderadoACLFFMMDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoACLFFMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CLExistente", SqlDbType.Int);
                    cmd.Parameters["@CLExistente"].Value = coeficientePonderadoACLFFMMDTO.CLExistente;

                    cmd.Parameters.Add("@CLRequerido", SqlDbType.Int);
                    cmd.Parameters["@CLRequerido"].Value = coeficientePonderadoACLFFMMDTO.CLRequerido;

                    cmd.Parameters.Add("@Total", SqlDbType.Int);
                    cmd.Parameters["@Total"].Value = coeficientePonderadoACLFFMMDTO.Total;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoACLFFMMDTO.UsuarioIngresoRegistro;

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

        public string EliminarCoeficientePonderadoACLFFMM(CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoACLFFMMEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoACLFFMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoACLFFMMId"].Value = coeficientePonderadoACLFFMMDTO.CoeficientePonderadoACLFFMMId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoACLFFMMDTO.UsuarioIngresoRegistro;

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
