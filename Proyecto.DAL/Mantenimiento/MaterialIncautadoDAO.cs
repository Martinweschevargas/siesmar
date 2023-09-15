using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MaterialIncautadoDAO
    {

        SqlCommand cmd = new();

        public List<MaterialIncautadoDTO> ObtenerMaterialIncautados()
        {
            List<MaterialIncautadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MaterialIncautadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialIncautadoDTO()
                        {
                            MaterialIncautadoId = Convert.ToInt32(dr["MaterialIncautadoId"]),
                            DescMaterialIncautado = dr["DescMaterialIncautado"].ToString(),
                            CodigoMaterialIncautado = dr["CodigoMaterialIncautado"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMaterialIncautado(MaterialIncautadoDTO MaterialIncautadoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialIncautadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMaterialIncautado", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescMaterialIncautado"].Value = MaterialIncautadoDTO.DescMaterialIncautado;

                    cmd.Parameters.Add("@CodigoMaterialIncautado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialIncautado"].Value = MaterialIncautadoDTO.CodigoMaterialIncautado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialIncautadoDTO.UsuarioIngresoRegistro;

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

        public MaterialIncautadoDTO BuscarMaterialIncautadoID(int Codigo)
        {
            MaterialIncautadoDTO MaterialIncautadoDTO = new MaterialIncautadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialIncautadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialIncautadoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialIncautadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        MaterialIncautadoDTO.MaterialIncautadoId = Convert.ToInt32(dr["MaterialIncautadoId"]);
                        MaterialIncautadoDTO.DescMaterialIncautado = dr["DescMaterialIncautado"].ToString();
                        MaterialIncautadoDTO.CodigoMaterialIncautado = dr["CodigoMaterialIncautado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return MaterialIncautadoDTO;
        }

        public string ActualizarMaterialIncautado(MaterialIncautadoDTO MaterialIncautadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialIncautadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialIncautadoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialIncautadoId"].Value = MaterialIncautadoDTO.MaterialIncautadoId;

                    cmd.Parameters.Add("@DescMaterialIncautado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DescMaterialIncautado"].Value = MaterialIncautadoDTO.DescMaterialIncautado;

                    cmd.Parameters.Add("@CodigoMaterialIncautado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialIncautado"].Value = MaterialIncautadoDTO.CodigoMaterialIncautado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialIncautadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMaterialIncautado(MaterialIncautadoDTO MaterialIncautadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialIncautadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialIncautadoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialIncautadoId"].Value = MaterialIncautadoDTO.MaterialIncautadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialIncautadoDTO.UsuarioIngresoRegistro;

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
