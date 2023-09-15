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
                            DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO capitaniaDTO)
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

                    cmd.Parameters.Add("@DescSistemaCombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaCombustibleLubricante"].Value = capitaniaDTO.DescSistemaCombustibleLubricante;            

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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
            SistemaCombustibleLubricanteDTO capitaniaDTO = new SistemaCombustibleLubricanteDTO();
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
                        capitaniaDTO.SistemaCombustibleLubricanteId = Convert.ToInt32(dr["SistemaCombustibleLubricanteId"]);
                        capitaniaDTO.DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capitaniaDTO;
        }

        public string ActualizarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO capitaniaDTO)
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
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = capitaniaDTO.SistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@DescSistemaCombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaCombustibleLubricante"].Value = capitaniaDTO.DescSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public string EliminarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO capitaniaDTO)
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
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = capitaniaDTO.SistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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
