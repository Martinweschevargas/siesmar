using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CoeficientePonderadoARCDAO
    {

        SqlCommand cmd = new();

        public List<CoeficientePonderadoARCDTO> ObtenerCoeficientePonderadoARCs()
        {
            List<CoeficientePonderadoARCDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoARCListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CoeficientePonderadoARCDTO()
                        {
                            CoeficientePonderadoARCId = Convert.ToInt32(dr["CoeficientePonderadoARCId"]),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            CLM = Convert.ToInt32(dr["CLM"]),
                            FM = Convert.ToInt32(dr["FM"]),
                            CM = Convert.ToInt32(dr["CM"]),
                            FT = Convert.ToInt32(dr["FT"]),
                            AUX = Convert.ToInt32(dr["AUX"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCoeficientePonderadoARC(CoeficientePonderadoARCDTO coeficientePonderadoARCDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoARCRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadIntrinseca", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CapacidadIntrinseca"].Value = coeficientePonderadoARCDTO.CapacidadIntrinseca;

                    cmd.Parameters.Add("@CLM", SqlDbType.Int);
                    cmd.Parameters["@CLM"].Value = coeficientePonderadoARCDTO.CLM;

                    cmd.Parameters.Add("@FM", SqlDbType.Int);
                    cmd.Parameters["@FM"].Value = coeficientePonderadoARCDTO.FM;

                    cmd.Parameters.Add("@CM", SqlDbType.Int);
                    cmd.Parameters["@CM"].Value = coeficientePonderadoARCDTO.CM;

                    cmd.Parameters.Add("@FT", SqlDbType.Int);
                    cmd.Parameters["@FT"].Value = coeficientePonderadoARCDTO.FT;

                    cmd.Parameters.Add("@AUX", SqlDbType.Int);
                    cmd.Parameters["@AUX"].Value = coeficientePonderadoARCDTO.AUX;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoARCDTO.UsuarioIngresoRegistro;

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

        public CoeficientePonderadoARCDTO BuscarCoeficientePonderadoARCID(int Codigo)
        {
            CoeficientePonderadoARCDTO coeficientePonderadoARCDTO = new CoeficientePonderadoARCDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoARCEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoARCId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoARCId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        coeficientePonderadoARCDTO.CoeficientePonderadoARCId = Convert.ToInt32(dr["CoeficientePonderadoARCId"]);
                        coeficientePonderadoARCDTO.CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString();
                        coeficientePonderadoARCDTO.CLM = Convert.ToInt32(dr["CLM"]);
                        coeficientePonderadoARCDTO.FM = Convert.ToInt32(dr["FM"]);
                        coeficientePonderadoARCDTO.CM = Convert.ToInt32(dr["CM"]);
                        coeficientePonderadoARCDTO.FT = Convert.ToInt32(dr["FT"]);
                        coeficientePonderadoARCDTO.AUX = Convert.ToInt32(dr["AUX"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return coeficientePonderadoARCDTO;
        }

        public string ActualizarCoeficientePonderadoARC(CoeficientePonderadoARCDTO coeficientePonderadoARCDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoARCActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoARCId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoARCId"].Value = coeficientePonderadoARCDTO.CoeficientePonderadoARCId;

                    cmd.Parameters.Add("@CapacidadIntrinseca", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CapacidadIntrinseca"].Value = coeficientePonderadoARCDTO.CapacidadIntrinseca;

                    cmd.Parameters.Add("@CLM", SqlDbType.Int);
                    cmd.Parameters["@CLM"].Value = coeficientePonderadoARCDTO.CLM;

                    cmd.Parameters.Add("@FM", SqlDbType.Int);
                    cmd.Parameters["@FM"].Value = coeficientePonderadoARCDTO.FM;

                    cmd.Parameters.Add("@CM", SqlDbType.Int);
                    cmd.Parameters["@CM"].Value = coeficientePonderadoARCDTO.CM;

                    cmd.Parameters.Add("@FT", SqlDbType.Int);
                    cmd.Parameters["@FT"].Value = coeficientePonderadoARCDTO.FT;

                    cmd.Parameters.Add("@AUX", SqlDbType.Int);
                    cmd.Parameters["@AUX"].Value = coeficientePonderadoARCDTO.AUX;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoARCDTO.UsuarioIngresoRegistro;

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

        public string EliminarCoeficientePonderadoARC(CoeficientePonderadoARCDTO coeficientePonderadoARCDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoARCEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoARCId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoARCId"].Value = coeficientePonderadoARCDTO.CoeficientePonderadoARCId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoARCDTO.UsuarioIngresoRegistro;

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
