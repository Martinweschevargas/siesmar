using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoMaterialDAO
    {

        SqlCommand cmd = new();

        public List<TipoMaterialDTO> ObtenerTipoMaterials()
        {
            List<TipoMaterialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoMaterialDTO()
                        {
                            TipoMaterialId = Convert.ToInt32(dr["TipoMaterialId"]),
                            DescTipoMaterial = dr["DescTipoMaterial"].ToString(),
                            CodigoTipoMaterial = dr["CodigoTipoMaterial"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoMaterial(TipoMaterialDTO tipoMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoMaterial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoMaterial"].Value = tipoMaterialDTO.DescTipoMaterial;

                    cmd.Parameters.Add("@CodigoTipoMaterial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoMaterial"].Value = tipoMaterialDTO.CodigoTipoMaterial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMaterialDTO.UsuarioIngresoRegistro;

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

        public TipoMaterialDTO BuscarTipoMaterialID(int Codigo)
        {
            TipoMaterialDTO tipoMaterialDTO = new TipoMaterialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoMaterialDTO.TipoMaterialId = Convert.ToInt32(dr["TipoMaterialId"]);
                        tipoMaterialDTO.DescTipoMaterial = dr["DescTipoMaterial"].ToString();
                        tipoMaterialDTO.CodigoTipoMaterial = dr["CodigoTipoMaterial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoMaterialDTO;
        }

        public string ActualizarTipoMaterial(TipoMaterialDTO tipoMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialId"].Value = tipoMaterialDTO.TipoMaterialId;

                    cmd.Parameters.Add("@DescTipoMaterial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoMaterial"].Value = tipoMaterialDTO.DescTipoMaterial;

                    cmd.Parameters.Add("@CodigoTipoMaterial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoMaterial"].Value = tipoMaterialDTO.CodigoTipoMaterial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMaterialDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoMaterial(TipoMaterialDTO tipoMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialId"].Value = tipoMaterialDTO.TipoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMaterialDTO.UsuarioIngresoRegistro;

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
