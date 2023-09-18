using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ParentescoAfiliadoDAO
    {

        SqlCommand cmd = new();

        public List<ParentescoAfiliadoDTO> ObtenerParentescoAfiliados()
        {
            List<ParentescoAfiliadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ParentescoAfiliadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ParentescoAfiliadoDTO()
                        {
                            CodigoParentescoAfiliado = dr["CodigoParentescoAfiliado"].ToString(),
                            DescParentescoAfiliado = dr["DescParentescoAfiliado"].ToString(),
                         
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarParentescoAfiliado(ParentescoAfiliadoDTO parentescoAfiliadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ParentescoAfiliadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoParentescoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoParentescoAfiliado"].Value = parentescoAfiliadoDTO.CodigoParentescoAfiliado;

                    cmd.Parameters.Add("@DescParentescoAfiliado", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescParentescoAfiliado"].Value = parentescoAfiliadoDTO.DescParentescoAfiliado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = parentescoAfiliadoDTO.UsuarioIngresoRegistro;

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

        public ParentescoAfiliadoDTO BuscarParentescoAfiliadoID(string Codigo)
        {
            ParentescoAfiliadoDTO parentescoAfiliadoDTO = new ParentescoAfiliadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ParentescoAfiliadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoParentescoAfiliado", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoParentescoAfiliado"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        parentescoAfiliadoDTO.CodigoParentescoAfiliado = dr["CodigoParentescoAfiliado"].ToString();
                        parentescoAfiliadoDTO.DescParentescoAfiliado = dr["DescParentescoAfiliado"].ToString();
 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return parentescoAfiliadoDTO;
        }

        public string ActualizarParentescoAfiliado(ParentescoAfiliadoDTO parentescoAfiliadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ParentescoAfiliadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoParentescoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoParentescoAfiliado"].Value = parentescoAfiliadoDTO.CodigoParentescoAfiliado;

                    cmd.Parameters.Add("@DescParentescoAfiliado", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescParentescoAfiliado"].Value = parentescoAfiliadoDTO.DescParentescoAfiliado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = parentescoAfiliadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarParentescoAfiliado(ParentescoAfiliadoDTO parentescoAfiliadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ParentescoAfiliadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoParentescoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoParentescoAfiliado"].Value = parentescoAfiliadoDTO.CodigoParentescoAfiliado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = parentescoAfiliadoDTO.UsuarioIngresoRegistro;

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
