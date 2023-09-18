using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CoeficientePonderadoAMUFFMMDAO
    {

        SqlCommand cmd = new();

        public List<CoeficientePonderadoAMUFFMMDTO> ObtenerCoeficientePonderadoAMUFFMMs()
        {
            List<CoeficientePonderadoAMUFFMMDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUFFMMListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CoeficientePonderadoAMUFFMMDTO()
                        {
                            CoeficientePonderadoAMUFFMMId = Convert.ToInt32(dr["CoeficientePonderadoAMUFFMMId"]),
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

        public string AgregarCoeficientePonderadoAMUFFMM(CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUFFMMRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Municion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Municion"].Value = coeficientePonderadoAMUFFMMDTO.Municion;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoAMUFFMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@ExistenciaMunicion", SqlDbType.Int);
                    cmd.Parameters["@ExistenciaMunicion"].Value = coeficientePonderadoAMUFFMMDTO.ExistenciaMunicion;

                    cmd.Parameters.Add("@MunicionRequerida", SqlDbType.Int);
                    cmd.Parameters["@MunicionRequerida"].Value = coeficientePonderadoAMUFFMMDTO.MunicionRequerida;

                    cmd.Parameters.Add("@TotalPorcentaje", SqlDbType.Int);
                    cmd.Parameters["@TotalPorcentaje"].Value = coeficientePonderadoAMUFFMMDTO.TotalPorcentaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoAMUFFMMDTO.UsuarioIngresoRegistro;

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

        public CoeficientePonderadoAMUFFMMDTO BuscarCoeficientePonderadoAMUFFMMID(int Codigo)
        {
            CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO = new CoeficientePonderadoAMUFFMMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUFFMMEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoAMUFFMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoAMUFFMMId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        coeficientePonderadoAMUFFMMDTO.CoeficientePonderadoAMUFFMMId = Convert.ToInt32(dr["CoeficientePonderadoAMUFFMMId"]);
                        coeficientePonderadoAMUFFMMDTO.Municion = dr["Municion"].ToString();
                        coeficientePonderadoAMUFFMMDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]);
                        coeficientePonderadoAMUFFMMDTO.ExistenciaMunicion = Convert.ToInt32(dr["ExistenciaMunicion"]);
                        coeficientePonderadoAMUFFMMDTO.MunicionRequerida = Convert.ToInt32(dr["MunicionRequerida"]);
                        coeficientePonderadoAMUFFMMDTO.TotalPorcentaje = Convert.ToInt32(dr["TotalPorcentaje"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return coeficientePonderadoAMUFFMMDTO;
        }

        public string ActualizarCoeficientePonderadoAMUFFMM(CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUFFMMActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoAMUFFMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoAMUFFMMId"].Value = coeficientePonderadoAMUFFMMDTO.CoeficientePonderadoAMUFFMMId;

                    cmd.Parameters.Add("@Municion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Municion"].Value = coeficientePonderadoAMUFFMMDTO.Municion;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = coeficientePonderadoAMUFFMMDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@ExistenciaMunicion", SqlDbType.Int);
                    cmd.Parameters["@ExistenciaMunicion"].Value = coeficientePonderadoAMUFFMMDTO.ExistenciaMunicion;

                    cmd.Parameters.Add("@MunicionRequerida", SqlDbType.Int);
                    cmd.Parameters["@MunicionRequerida"].Value = coeficientePonderadoAMUFFMMDTO.MunicionRequerida;

                    cmd.Parameters.Add("@TotalPorcentaje", SqlDbType.Int);
                    cmd.Parameters["@TotalPorcentaje"].Value = coeficientePonderadoAMUFFMMDTO.TotalPorcentaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoAMUFFMMDTO.UsuarioIngresoRegistro;

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

        public string EliminarCoeficientePonderadoAMUFFMM(CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CoeficientePonderadoAMUFFMMEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CoeficientePonderadoAMUFFMMId", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderadoAMUFFMMId"].Value = coeficientePonderadoAMUFFMMDTO.CoeficientePonderadoAMUFFMMId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = coeficientePonderadoAMUFFMMDTO.UsuarioIngresoRegistro;

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
