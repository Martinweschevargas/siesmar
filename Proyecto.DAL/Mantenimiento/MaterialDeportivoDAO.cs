using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MaterialDeportivoDAO
    {

        SqlCommand cmd = new();

        public List<MaterialDeportivoDTO> ObtenerMaterialDeportivos()
        {
            List<MaterialDeportivoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MaterialDeportivoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialDeportivoDTO()
                        {
                            MaterialDeportivoId = Convert.ToInt32(dr["MaterialDeportivoId"]),
                            DescMaterialDeportivo = dr["DescMaterialDeportivo"].ToString(),
                            CodigoMaterialDeportivo = dr["CodigoMaterialDeportivo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMaterialDeportivo(MaterialDeportivoDTO MaterialDeportivoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialDeportivoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
             
                    cmd.Parameters.Add("@DescMaterialDeportivo", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMaterialDeportivo"].Value = MaterialDeportivoDTO.DescMaterialDeportivo;
                    
                    cmd.Parameters.Add("@CodigoMaterialDeportivo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialDeportivo"].Value = MaterialDeportivoDTO.CodigoMaterialDeportivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialDeportivoDTO.UsuarioIngresoRegistro;

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

        public MaterialDeportivoDTO BuscarMaterialDeportivoID(int Codigo)
        {
            MaterialDeportivoDTO MaterialDeportivoDTO = new MaterialDeportivoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialDeportivoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialDeportivoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialDeportivoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        MaterialDeportivoDTO.MaterialDeportivoId = Convert.ToInt32(dr["MaterialDeportivoId"]);
                        MaterialDeportivoDTO.DescMaterialDeportivo = dr["DescMaterialDeportivo"].ToString();
                        MaterialDeportivoDTO.CodigoMaterialDeportivo = dr["CodigoMaterialDeportivo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return MaterialDeportivoDTO;
        }

        public string ActualizarMaterialDeportivo(MaterialDeportivoDTO MaterialDeportivoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialDeportivoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialDeportivoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialDeportivoId"].Value = MaterialDeportivoDTO.MaterialDeportivoId;

                    cmd.Parameters.Add("@DescMaterialDeportivo", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMaterialDeportivo"].Value = MaterialDeportivoDTO.DescMaterialDeportivo;

                    cmd.Parameters.Add("@CodigoMaterialDeportivo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialDeportivo"].Value = MaterialDeportivoDTO.CodigoMaterialDeportivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialDeportivoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMaterialDeportivo(MaterialDeportivoDTO MaterialDeportivoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialDeportivoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialDeportivoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialDeportivoId"].Value = MaterialDeportivoDTO.MaterialDeportivoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialDeportivoDTO.UsuarioIngresoRegistro;

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
