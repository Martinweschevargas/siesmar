using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SistemaMunicionDAO
    {

        SqlCommand cmd = new();

        public List<SistemaMunicionDTO> ObtenerSistemaMunicions()
        {
            List<SistemaMunicionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SistemaMunicionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SistemaMunicionDTO()
                        {
                            SistemaMunicionId = Convert.ToInt32(dr["SistemaMunicionId"]),
                            CodigoSistemaMunicion = dr["CodigoSistemaMunicion"].ToString(),
                            DescSistemaMunicion = dr["DescSistemaMunicion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaMunicionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoSistemaMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaMunicion"].Value = sistemaMunicionDTO.CodigoSistemaMunicion;

                    cmd.Parameters.Add("@DescSistemaMunicion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaMunicion"].Value = sistemaMunicionDTO.DescSistemaMunicion;            

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaMunicionDTO.UsuarioIngresoRegistro;

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

        public SistemaMunicionDTO BuscarSistemaMunicionID(int Codigo)
        {
            SistemaMunicionDTO sistemaMunicionDTO = new SistemaMunicionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaMunicionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        sistemaMunicionDTO.SistemaMunicionId = Convert.ToInt32(dr["SistemaMunicionId"]);
                        sistemaMunicionDTO.CodigoSistemaMunicion = dr["CodigoSistemaMunicion"].ToString();
                        sistemaMunicionDTO.DescSistemaMunicion = dr["DescSistemaMunicion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return sistemaMunicionDTO;
        }

        public string ActualizarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaMunicionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = sistemaMunicionDTO.SistemaMunicionId;

                    cmd.Parameters.Add("@CodigoSistemaMunicion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CodigoSistemaMunicion"].Value = sistemaMunicionDTO.CodigoSistemaMunicion;


                    cmd.Parameters.Add("@DescSistemaMunicion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaMunicion"].Value = sistemaMunicionDTO.DescSistemaMunicion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaMunicionDTO.UsuarioIngresoRegistro;

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

        public string EliminarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaMunicionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = sistemaMunicionDTO.SistemaMunicionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaMunicionDTO.UsuarioIngresoRegistro;

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
