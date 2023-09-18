using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DescripcionMaterialDAO
    {

        SqlCommand cmd = new();

        public List<DescripcionMaterialDTO> ObtenerDescripcionMaterials()
        {
            List<DescripcionMaterialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DescripcionMaterialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DescripcionMaterialDTO()
                        {
                            DescripcionMaterialId = Convert.ToInt32(dr["DescripcionMaterialId"]),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            CodigoDescripcionMaterial = dr["CodigoDescripcionMaterial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDescripcionMaterial(DescripcionMaterialDTO DescripcionMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DescripcionMaterialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Clasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Clasificacion"].Value = DescripcionMaterialDTO.Clasificacion;

                    cmd.Parameters.Add("@CodigoDescripcionMaterial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDescripcionMaterial"].Value = DescripcionMaterialDTO.CodigoDescripcionMaterial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DescripcionMaterialDTO.UsuarioIngresoRegistro;

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

        public DescripcionMaterialDTO BuscarDescripcionMaterialID(int Codigo)
        {
            DescripcionMaterialDTO DescripcionMaterialDTO = new DescripcionMaterialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DescripcionMaterialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        DescripcionMaterialDTO.DescripcionMaterialId = Convert.ToInt32(dr["DescripcionMaterialId"]);
                        DescripcionMaterialDTO.Clasificacion = dr["Clasificacion"].ToString();
                        DescripcionMaterialDTO.CodigoDescripcionMaterial = dr["CodigoDescripcionMaterial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return DescripcionMaterialDTO;
        }

        public string ActualizarDescripcionMaterial(DescripcionMaterialDTO DescripcionMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DescripcionMaterialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = DescripcionMaterialDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Clasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Clasificacion"].Value = DescripcionMaterialDTO.Clasificacion;

                    cmd.Parameters.Add("@CodigoDescripcionMaterial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDescripcionMaterial"].Value = DescripcionMaterialDTO.CodigoDescripcionMaterial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DescripcionMaterialDTO.UsuarioIngresoRegistro;

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

        public string EliminarDescripcionMaterial(DescripcionMaterialDTO DescripcionMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DescripcionMaterialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = DescripcionMaterialDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DescripcionMaterialDTO.UsuarioIngresoRegistro;

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
