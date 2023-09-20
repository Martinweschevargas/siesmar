using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SistemaCombustibleLubricanteDAO
    {

        SqlCommand cmd = new();

        public List<SistemaCombustibleLubricanteDTO> ObtenerSistemaCombustibleLubricantes()
        {
            List<SistemaCombustibleLubricanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SistemaCombustibleLubricanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SistemaCombustibleLubricanteDTO()
                        {
                            SistemaCombustibleLubricanteId = Convert.ToInt32(dr["SistemaCombustibleLubricanteId"]),
                            CodigoSistemaCombustibleLubricante = dr["CodigoSistemaCombustibleLubricante"].ToString(),
                            DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaCombustibleLubricanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoSistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaCombustibleLubricante"].Value = sistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@DescSistemaCombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaCombustibleLubricante"].Value = sistemaCombustibleLubricanteDTO.DescSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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

        public SistemaCombustibleLubricanteDTO BuscarSistemaCombustibleLubricanteID(int Codigo)
        {
            SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO = new SistemaCombustibleLubricanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaCombustibleLubricanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        sistemaCombustibleLubricanteDTO.SistemaCombustibleLubricanteId = Convert.ToInt32(dr["SistemaCombustibleLubricanteId"]);
                        sistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = dr["CodigoSistemaCombustibleLubricante"].ToString();
                        sistemaCombustibleLubricanteDTO.DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return sistemaCombustibleLubricanteDTO;
        }

        public string ActualizarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaCombustibleLubricanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = sistemaCombustibleLubricanteDTO.SistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@CodigoSistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaCombustibleLubricante"].Value = sistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@DescSistemaCombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaCombustibleLubricante"].Value = sistemaCombustibleLubricanteDTO.DescSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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

        public string EliminarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaCombustibleLubricanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = sistemaCombustibleLubricanteDTO.SistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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
