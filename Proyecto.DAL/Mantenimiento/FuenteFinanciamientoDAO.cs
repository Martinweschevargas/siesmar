using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FuenteFinanciamientoDAO
    {

        SqlCommand cmd = new();

        public List<FuenteFinanciamientoDTO> ObtenerFuenteFinanciamientos()
        {
            List<FuenteFinanciamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FuenteFinanciamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FuenteFinanciamientoDTO()
                        {
                            FuenteFinanciamientoId = Convert.ToInt32(dr["FuenteFinanciamientoId"]),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFuenteFinanciamiento(FuenteFinanciamientoDTO fuenteFinanciamientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FuenteFinanciamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFuenteFinanciamiento", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescFuenteFinanciamiento"].Value = fuenteFinanciamientoDTO.DescFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = fuenteFinanciamientoDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = fuenteFinanciamientoDTO.UsuarioIngresoRegistro;

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

        public FuenteFinanciamientoDTO BuscarFuenteFinanciamientoID(int Codigo)
        {
            FuenteFinanciamientoDTO fuenteFinanciamientoDTO = new FuenteFinanciamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FuenteFinanciamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FuenteFinanciamientoId", SqlDbType.Int);
                    cmd.Parameters["@FuenteFinanciamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        fuenteFinanciamientoDTO.FuenteFinanciamientoId = Convert.ToInt32(dr["FuenteFinanciamientoId"]);
                        fuenteFinanciamientoDTO.DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString();
                        fuenteFinanciamientoDTO.CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return fuenteFinanciamientoDTO;
        }

        public string ActualizarFuenteFinanciamiento(FuenteFinanciamientoDTO fuenteFinanciamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_FuenteFinanciamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FuenteFinanciamientoId", SqlDbType.Int);
                    cmd.Parameters["@FuenteFinanciamientoId"].Value = fuenteFinanciamientoDTO.FuenteFinanciamientoId;

                    cmd.Parameters.Add("@DescFuenteFinanciamiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFuenteFinanciamiento"].Value = fuenteFinanciamientoDTO.DescFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = fuenteFinanciamientoDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = fuenteFinanciamientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarFuenteFinanciamiento(FuenteFinanciamientoDTO fuenteFinanciamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FuenteFinanciamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FuenteFinanciamientoId", SqlDbType.Int);
                    cmd.Parameters["@FuenteFinanciamientoId"].Value = fuenteFinanciamientoDTO.FuenteFinanciamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = fuenteFinanciamientoDTO.UsuarioIngresoRegistro;

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
