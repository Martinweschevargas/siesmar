using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MaterialRecreativoDAO
    {

        SqlCommand cmd = new();

        public List<MaterialRecreativoDTO> ObtenerMaterialRecreativos()
        {
            List<MaterialRecreativoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MaterialRecreativoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialRecreativoDTO()
                        {
                            MaterialRecreativoId = Convert.ToInt32(dr["MaterialRecreativoId"]),
                            DescMaterialRecreativo = dr["DescMaterialRecreativo"].ToString(),
                            CodigoMaterialRecreativo = dr["CodigoMaterialRecreativo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMaterialRecreativo(MaterialRecreativoDTO MaterialRecreativoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRecreativoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
           
                    cmd.Parameters.Add("@DescMaterialRecreativo", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMaterialRecreativo"].Value = MaterialRecreativoDTO.DescMaterialRecreativo;
                  
                    cmd.Parameters.Add("@CodigoMaterialRecreativo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialRecreativo"].Value = MaterialRecreativoDTO.CodigoMaterialRecreativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialRecreativoDTO.UsuarioIngresoRegistro;

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

        public MaterialRecreativoDTO BuscarMaterialRecreativoID(int Codigo)
        {
            MaterialRecreativoDTO MaterialRecreativoDTO = new MaterialRecreativoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRecreativoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRecreativoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRecreativoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        MaterialRecreativoDTO.MaterialRecreativoId = Convert.ToInt32(dr["MaterialRecreativoId"]);
                        MaterialRecreativoDTO.DescMaterialRecreativo = dr["DescMaterialRecreativo"].ToString();
                        MaterialRecreativoDTO.CodigoMaterialRecreativo = dr["CodigoMaterialRecreativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return MaterialRecreativoDTO;
        }

        public string ActualizarMaterialRecreativo(MaterialRecreativoDTO MaterialRecreativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRecreativoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRecreativoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRecreativoId"].Value = MaterialRecreativoDTO.MaterialRecreativoId;

                    cmd.Parameters.Add("@DescMaterialRecreativo", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMaterialRecreativo"].Value = MaterialRecreativoDTO.DescMaterialRecreativo;

                    cmd.Parameters.Add("@CodigoMaterialRecreativo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialRecreativo"].Value = MaterialRecreativoDTO.CodigoMaterialRecreativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialRecreativoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMaterialRecreativo(MaterialRecreativoDTO MaterialRecreativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRecreativoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRecreativoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRecreativoId"].Value = MaterialRecreativoDTO.MaterialRecreativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialRecreativoDTO.UsuarioIngresoRegistro;

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
