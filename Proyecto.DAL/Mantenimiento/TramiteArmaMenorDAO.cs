
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TramiteArmaMenorDAO
    {

        SqlCommand cmd = new();

        public List<TramiteArmaMenorDTO> ObtenerTramiteArmaMenors()
        {
            List<TramiteArmaMenorDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TramiteArmasMenoresListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TramiteArmaMenorDTO()
                        {
                            TramiteArmaMenorId = Convert.ToInt32(dr["TramiteArmaMenorId"]),
                            CodigoTramiteArmaMenor = dr["CodigoTramiteArmaMenor"].ToString(),
                            DescTramiteArmaMenor = dr["DescTramiteArmaMenor"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTramiteArmaMenor(TramiteArmaMenorDTO tramiteArmaMenorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TramiteArmasMenoresRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTramiteArmaMenor", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTramiteArmaMenor"].Value = tramiteArmaMenorDTO.DescTramiteArmaMenor;

                    cmd.Parameters.Add("@CodigoTramiteArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTramiteArmaMenor"].Value = tramiteArmaMenorDTO.CodigoTramiteArmaMenor;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tramiteArmaMenorDTO.UsuarioIngresoRegistro;

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

        public TramiteArmaMenorDTO BuscarTramiteArmaMenorID(int Codigo)
        {
            TramiteArmaMenorDTO tramiteArmaMenorDTO = new TramiteArmaMenorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TramiteArmasMenoresEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TramiteArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@TramiteArmaMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tramiteArmaMenorDTO.TramiteArmaMenorId = Convert.ToInt32(dr["TramiteArmaMenorId"]);
                        tramiteArmaMenorDTO.DescTramiteArmaMenor = dr["DescTramiteArmaMenor"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tramiteArmaMenorDTO;
        }

        public string ActualizarTramiteArmaMenor(TramiteArmaMenorDTO tramiteArmaMenorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TramiteArmasMenoresActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TramiteArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@TramiteArmaMenorId"].Value = tramiteArmaMenorDTO.TramiteArmaMenorId;

                    cmd.Parameters.Add("@DescTramiteArmaMenor", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DescTramiteArmaMenor"].Value = tramiteArmaMenorDTO.DescTramiteArmaMenor;

                    cmd.Parameters.Add("@CodigoTramiteArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTramiteArmaMenor"].Value = tramiteArmaMenorDTO.CodigoTramiteArmaMenor;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tramiteArmaMenorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTramiteArmaMenor(TramiteArmaMenorDTO tramiteArmaMenorDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TramiteArmasMenoresEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TramiteArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@TramiteArmaMenorId"].Value = tramiteArmaMenorDTO.TramiteArmaMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tramiteArmaMenorDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
