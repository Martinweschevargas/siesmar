using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FormaContactoAfiliadoDAO
    {

        SqlCommand cmd = new();

        public List<FormaContactoAfiliadoDTO> ObtenerFormaContactoAfiliados()
        {
            List<FormaContactoAfiliadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FormaContactoAfiliadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FormaContactoAfiliadoDTO()
                        {
                            FormaContactoAfiliadoId = Convert.ToInt32(dr["FormaContactoAfiliadoId"]),
                            DescFormaContactoAfiliado = dr["DescFormaContactoAfiliado"].ToString(),
                            CodigoFormaContactoAfiliado = dr["CodigoFormaContactoAfiliado"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFormaContactoAfiliado(FormaContactoAfiliadoDTO formaContactoAfiliadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormaContactoAfiliadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFormaContactoAfiliado", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescFormaContactoAfiliado"].Value = formaContactoAfiliadoDTO.DescFormaContactoAfiliado;

                    cmd.Parameters.Add("@CodigoFormaContactoAfiliado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFormaContactoAfiliado"].Value = formaContactoAfiliadoDTO.CodigoFormaContactoAfiliado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formaContactoAfiliadoDTO.UsuarioIngresoRegistro;

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

        public FormaContactoAfiliadoDTO BuscarFormaContactoAfiliadoID(int Codigo)
        {
            FormaContactoAfiliadoDTO formaContactoAfiliadoDTO = new FormaContactoAfiliadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormaContactoAfiliadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormaContactoAfiliadoId", SqlDbType.Int);
                    cmd.Parameters["@FormaContactoAfiliadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        formaContactoAfiliadoDTO.FormaContactoAfiliadoId = Convert.ToInt32(dr["FormaContactoAfiliadoId"]);
                        formaContactoAfiliadoDTO.DescFormaContactoAfiliado = dr["DescFormaContactoAfiliado"].ToString();
                        formaContactoAfiliadoDTO.CodigoFormaContactoAfiliado = dr["CodigoFormaContactoAfiliado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return formaContactoAfiliadoDTO;
        }

        public string ActualizarFormaContactoAfiliado(FormaContactoAfiliadoDTO formaContactoAfiliadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormaContactoAfiliadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormaContactoAfiliadoId", SqlDbType.Int);
                    cmd.Parameters["@FormaContactoAfiliadoId"].Value = formaContactoAfiliadoDTO.FormaContactoAfiliadoId;

                    cmd.Parameters.Add("@DescFormaContactoAfiliado", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescFormaContactoAfiliado"].Value = formaContactoAfiliadoDTO.DescFormaContactoAfiliado;

                    cmd.Parameters.Add("@CodigoFormaContactoAfiliado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFormaContactoAfiliado"].Value = formaContactoAfiliadoDTO.CodigoFormaContactoAfiliado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formaContactoAfiliadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarFormaContactoAfiliado(FormaContactoAfiliadoDTO formaContactoAfiliadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormaContactoAfiliadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormaContactoAfiliadoId", SqlDbType.Int);
                    cmd.Parameters["@FormaContactoAfiliadoId"].Value = formaContactoAfiliadoDTO.FormaContactoAfiliadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formaContactoAfiliadoDTO.UsuarioIngresoRegistro;

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
