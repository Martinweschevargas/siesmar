using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CoeficientePonderadoAMUCCMMDAO
    {

        SqlCommand cmd = new();

        public List<CoeficientePonderadoAMUCCMMDTO> ObtenerCoeficientePonderadoAMUCCMMs()
        {
            List<CoeficientePonderadoAMUCCMMDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUCCMMListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CoeficientePonderadoAMUCCMMDTO()
                        {
                            CoeficientePonderadoAMUCCMMId = Convert.ToInt32(dr["CoeficientePonderadoAMUCCMMId"]),
                            Municion = dr["Municion"].ToString(),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]),
                            ExistenciaMunicion = Convert.ToInt32(dr["ExistenciaMunicion"]),
                            MunicionRequerida = Convert.ToInt32(dr["MunicionRequerida"]),
                            TotalPorcentaje = Convert.ToInt32(dr["TotalPorcentaje"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCoeficientePonderadoAMUCCMM(CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUCCMMRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Municion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Municion"].Value = coeficientePonderadoAMUCCMMDTO.Municion;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoAMUCCMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@ExistenciaMunicion", SqlDbType.Int);
                    cmd.Parameters["@ExistenciaMunicion"].Value = coeficientePonderadoAMUCCMMDTO.ExistenciaMunicion;

                    cmd.Parameters.Add("@MunicionRequerida", SqlDbType.Int);
                    cmd.Parameters["@MunicionRequerida"].Value = coeficientePonderadoAMUCCMMDTO.MunicionRequerida;

                    cmd.Parameters.Add("@TotalPorcentaje", SqlDbType.Int);
                    cmd.Parameters["@TotalPorcentaje"].Value = coeficientePonderadoAMUCCMMDTO.TotalPorcentaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoAMUCCMMDTO.UsuarioIngresoRegistro;

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

        public CoeficientePonderadoAMUCCMMDTO BuscarCoeficientePonderadoAMUCCMMID(int Codigo)
        {
            CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO = new CoeficientePonderadoAMUCCMMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUCCMMEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoAMUCCMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoAMUCCMMId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        coeficientePonderadoAMUCCMMDTO.CoeficientePonderadoAMUCCMMId = Convert.ToInt32(dr["CoeficientePonderadoAMUCCMMId"]);
                        coeficientePonderadoAMUCCMMDTO.Municion = dr["Municion"].ToString();
                        coeficientePonderadoAMUCCMMDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]);
                        coeficientePonderadoAMUCCMMDTO.ExistenciaMunicion = Convert.ToInt32(dr["ExistenciaMunicion"]);
                        coeficientePonderadoAMUCCMMDTO.MunicionRequerida = Convert.ToInt32(dr["MunicionRequerida"]);
                        coeficientePonderadoAMUCCMMDTO.TotalPorcentaje = Convert.ToInt32(dr["TotalPorcentaje"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return coeficientePonderadoAMUCCMMDTO;
        }

        public string ActualizarCoeficientePonderadoAMUCCMM(CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUCCMMActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoAMUCCMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoAMUCCMMId"].Value = coeficientePonderadoAMUCCMMDTO.CoeficientePonderadoAMUCCMMId;

                    cmd.Parameters.Add("@Municion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Municion"].Value = coeficientePonderadoAMUCCMMDTO.Municion;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoAMUCCMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@ExistenciaMunicion", SqlDbType.Int);
                    cmd.Parameters["@ExistenciaMunicion"].Value = coeficientePonderadoAMUCCMMDTO.ExistenciaMunicion;

                    cmd.Parameters.Add("@MunicionRequerida", SqlDbType.Int);
                    cmd.Parameters["@MunicionRequerida"].Value = coeficientePonderadoAMUCCMMDTO.MunicionRequerida;

                    cmd.Parameters.Add("@TotalPorcentaje", SqlDbType.Int);
                    cmd.Parameters["@TotalPorcentaje"].Value = coeficientePonderadoAMUCCMMDTO.TotalPorcentaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoAMUCCMMDTO.UsuarioIngresoRegistro;

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

        public string EliminarCoeficientePonderadoAMUCCMM(CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUCCMMEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoAMUCCMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoAMUCCMMId"].Value = coeficientePonderadoAMUCCMMDTO.CoeficientePonderadoAMUCCMMId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoAMUCCMMDTO.UsuarioIngresoRegistro;

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
