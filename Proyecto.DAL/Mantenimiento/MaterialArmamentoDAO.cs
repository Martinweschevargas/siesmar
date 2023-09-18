using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MaterialArmamentoDAO
    {

        SqlCommand cmd = new();

        public List<MaterialArmamentoDTO> ObtenerMaterialArmamentos()
        {
            List<MaterialArmamentoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MaterialArmamentoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialArmamentoDTO()
                        {
                            MaterialArmamentoId = Convert.ToInt32(dr["MaterialArmamentoId"]),
                            DescMaterialArmamento = dr["DescMaterialArmamento"].ToString(),
                            CalibreMaterialArmamento = dr["CalibreMaterialArmamento"].ToString(),
                            CodigoMaterialArmamento = dr["CodigoMaterialArmamento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMaterialArmamento(MaterialArmamentoDTO materialArmamentoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialArmamentoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMaterialArmamento", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescMaterialArmamento"].Value = materialArmamentoDTO.DescMaterialArmamento;

                    cmd.Parameters.Add("@CalibreMaterialArmamento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CalibreMaterialArmamento"].Value = materialArmamentoDTO.CalibreMaterialArmamento;

                    cmd.Parameters.Add("@CodigoMaterialArmamento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialArmamento"].Value = materialArmamentoDTO.CodigoMaterialArmamento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialArmamentoDTO.UsuarioIngresoRegistro;

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

        public MaterialArmamentoDTO BuscarMaterialArmamentoID(int Codigo)
        {
            MaterialArmamentoDTO materialArmamentoDTO = new MaterialArmamentoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialArmamentoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialArmamentoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        materialArmamentoDTO.MaterialArmamentoId = Convert.ToInt32(dr["MaterialArmamentoId"]);
                        materialArmamentoDTO.DescMaterialArmamento = dr["DescMaterialArmamento"].ToString();
                        materialArmamentoDTO.CalibreMaterialArmamento = dr["CalibreMaterialArmamento"].ToString();
                        materialArmamentoDTO.CodigoMaterialArmamento = dr["CodigoMaterialArmamento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return materialArmamentoDTO;
        }

        public string ActualizarMaterialArmamento(MaterialArmamentoDTO materialArmamentoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialArmamentoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialArmamentoId"].Value = materialArmamentoDTO.MaterialArmamentoId;

                    cmd.Parameters.Add("@DescMaterialArmamento", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescMaterialArmamento"].Value = materialArmamentoDTO.DescMaterialArmamento;

                    cmd.Parameters.Add("@CalibreMaterialArmamento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CalibreMaterialArmamento"].Value = materialArmamentoDTO.CalibreMaterialArmamento;

                    cmd.Parameters.Add("@CodigoMaterialArmamento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialArmamento"].Value = materialArmamentoDTO.CodigoMaterialArmamento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialArmamentoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMaterialArmamento(MaterialArmamentoDTO materialArmamentoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialArmamentoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialArmamentoId"].Value = materialArmamentoDTO.MaterialArmamentoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialArmamentoDTO.UsuarioIngresoRegistro;

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
