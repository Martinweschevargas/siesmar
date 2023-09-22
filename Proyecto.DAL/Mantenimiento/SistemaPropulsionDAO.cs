using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SistemaPropulsionDAO
    {

        SqlCommand cmd = new();

        public List<SistemaPropulsionDTO> ObtenerSistemaPropulsions()
        {
            List<SistemaPropulsionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SistemaPropulsionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SistemaPropulsionDTO()
                        {
                            SistemaPropulsionId = Convert.ToInt32(dr["SistemaPropulsionId"]),
                            CodigoSistemaPropulsion = dr["CodigoSistemaPropulsion"].ToString(),
                            DescSistemaPropulsion = dr["DescSistemaPropulsion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSistemaPropulsion(SistemaPropulsionDTO sistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPropulsionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPropulsion"].Value = sistemaPropulsionDTO.CodigoSistemaPropulsion;

                    cmd.Parameters.Add("@DescSistemaPropulsion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSistemaPropulsion"].Value = sistemaPropulsionDTO.DescSistemaPropulsion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaPropulsionDTO.UsuarioIngresoRegistro;

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

        public SistemaPropulsionDTO BuscarSistemaPropulsionID(int Codigo)
        {
            SistemaPropulsionDTO sistemaPropulsionDTO = new SistemaPropulsionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPropulsionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaPropulsionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        sistemaPropulsionDTO.SistemaPropulsionId = Convert.ToInt32(dr["SistemaPropulsionId"]);
                        sistemaPropulsionDTO.CodigoSistemaPropulsion = dr["CodigoSistemaPropulsion"].ToString();
                        sistemaPropulsionDTO.DescSistemaPropulsion = dr["DescSistemaPropulsion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return sistemaPropulsionDTO;
        }

        public string ActualizarSistemaPropulsion(SistemaPropulsionDTO sistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPropulsionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaPropulsionId"].Value = sistemaPropulsionDTO.SistemaPropulsionId;

                    cmd.Parameters.Add("@CodigoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPropulsion"].Value = sistemaPropulsionDTO.CodigoSistemaPropulsion;

                    cmd.Parameters.Add("@DescSistemaPropulsion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSistemaPropulsion"].Value = sistemaPropulsionDTO.DescSistemaPropulsion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaPropulsionDTO.UsuarioIngresoRegistro;

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

        public string EliminarSistemaPropulsion(SistemaPropulsionDTO sistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaPropulsionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaPropulsionId"].Value = sistemaPropulsionDTO.SistemaPropulsionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaPropulsionDTO.UsuarioIngresoRegistro;

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
