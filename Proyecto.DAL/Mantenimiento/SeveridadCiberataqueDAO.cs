using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SeveridadCiberataqueDAO
    {

        SqlCommand cmd = new();

        public List<SeveridadCiberataqueDTO> ObtenerSeveridadCiberataques()
        {
            List<SeveridadCiberataqueDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SeveridadCiberataqueListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SeveridadCiberataqueDTO()
                        {
                            SeveridadCiberataqueId = Convert.ToInt32(dr["SeveridadCiberataqueId"]),
                            DescSeveridadCiberataque = dr["DescSeveridadCiberataque"].ToString(),
                            CodigoSeveridadCiberataque = dr["CodigoSeveridadCiberataque"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSeveridadCiberataque(SeveridadCiberataqueDTO severidadCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeveridadCiberataqueRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSeveridadCiberataque", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescSeveridadCiberataque"].Value = severidadCiberataqueDTO.DescSeveridadCiberataque;

                    cmd.Parameters.Add("@CodigoSeveridadCiberataque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSeveridadCiberataque"].Value = severidadCiberataqueDTO.CodigoSeveridadCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = severidadCiberataqueDTO.UsuarioIngresoRegistro;

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

        public SeveridadCiberataqueDTO BuscarSeveridadCiberataqueID(int Codigo)
        {
            SeveridadCiberataqueDTO severidadCiberataqueDTO = new SeveridadCiberataqueDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeveridadCiberataqueEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SeveridadCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@SeveridadCiberataqueId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        severidadCiberataqueDTO.SeveridadCiberataqueId = Convert.ToInt32(dr["SeveridadCiberataqueId"]);
                        severidadCiberataqueDTO.DescSeveridadCiberataque = dr["DescSeveridadCiberataque"].ToString();
                        severidadCiberataqueDTO.CodigoSeveridadCiberataque = dr["CodigoSeveridadCiberataque"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return severidadCiberataqueDTO;
        }

        public string ActualizarSeveridadCiberataque(SeveridadCiberataqueDTO severidadCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeveridadCiberataqueActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SeveridadCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@SeveridadCiberataqueId"].Value = severidadCiberataqueDTO.SeveridadCiberataqueId;

                    cmd.Parameters.Add("@DescSeveridadCiberataque", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescSeveridadCiberataque"].Value = severidadCiberataqueDTO.DescSeveridadCiberataque;

                    cmd.Parameters.Add("@CodigoSeveridadCiberataque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSeveridadCiberataque"].Value = severidadCiberataqueDTO.CodigoSeveridadCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = severidadCiberataqueDTO.UsuarioIngresoRegistro;

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

        public string EliminarSeveridadCiberataque(SeveridadCiberataqueDTO severidadCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeveridadCiberataqueEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SeveridadCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@SeveridadCiberataqueId"].Value = severidadCiberataqueDTO.SeveridadCiberataqueId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = severidadCiberataqueDTO.UsuarioIngresoRegistro;

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
