using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SistemaPensionDAO
    {

        SqlCommand cmd = new();

        public List<SistemaPensionDTO> ObtenerSistemaPensions()
        {
            List<SistemaPensionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SistemaPensionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SistemaPensionDTO()
                        {
                            SistemaPensionId = Convert.ToInt32(dr["SistemaPensionId"]),
                            DescSistemaPension = dr["DescSistemaPension"].ToString(),
                            CodigoSistemaPension = dr["CodigoSistemaPension"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSistemaPension(SistemaPensionDTO sistemaPensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPensionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSistemaPension", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescSistemaPension"].Value = sistemaPensionDTO.DescSistemaPension;

                    cmd.Parameters.Add("@CodigoSistemaPension", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoSistemaPension"].Value = sistemaPensionDTO.CodigoSistemaPension;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaPensionDTO.UsuarioIngresoRegistro;

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

        public SistemaPensionDTO BuscarSistemaPensionID(int Codigo)
        {
            SistemaPensionDTO sistemaPensionDTO = new SistemaPensionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPensionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaPensionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaPensionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        sistemaPensionDTO.SistemaPensionId = Convert.ToInt32(dr["SistemaPensionId"]);
                        sistemaPensionDTO.DescSistemaPension = dr["DescSistemaPension"].ToString();
                        sistemaPensionDTO.CodigoSistemaPension = dr["CodigoSistemaPension"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return sistemaPensionDTO;
        }

        public string ActualizarSistemaPension(SistemaPensionDTO sistemaPensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPensionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaPensionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaPensionId"].Value = sistemaPensionDTO.SistemaPensionId;

                    cmd.Parameters.Add("@DescSistemaPension", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSistemaPension"].Value = sistemaPensionDTO.DescSistemaPension;

                    cmd.Parameters.Add("@CodigoSistemaPension", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSistemaPension"].Value = sistemaPensionDTO.CodigoSistemaPension;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaPensionDTO.UsuarioIngresoRegistro;

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

        public string EliminarSistemaPension(SistemaPensionDTO sistemaPensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPensionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaPensionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaPensionId"].Value = sistemaPensionDTO.SistemaPensionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaPensionDTO.UsuarioIngresoRegistro;

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
