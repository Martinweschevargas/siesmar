using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MaterialRepBienHistoricoDAO
    {

        SqlCommand cmd = new();

        public List<MaterialRepBienHistoricoDTO> ObtenerMaterialRepBienHistoricos()
        {
            List<MaterialRepBienHistoricoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MaterialRepBienHistoricoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialRepBienHistoricoDTO()
                        {
                            MaterialRepBienHistoricoId = Convert.ToInt32(dr["MaterialRepBienHistoricoId"]),
                            DescMaterialRepBienHistorico = dr["DescMaterialRepBienHistorico"].ToString(),
                            CodigoMaterialRepBienHistorico = dr["CodigoMaterialRepBienHistorico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMaterialRepBienHistorico(MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRepBienHistoricoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMaterialRepBienHistorico", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMaterialRepBienHistorico"].Value = materialRepBienHistoricoDTO.DescMaterialRepBienHistorico;

                    cmd.Parameters.Add("@CodigoMaterialRepBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMaterialRepBienHistorico"].Value = materialRepBienHistoricoDTO.CodigoMaterialRepBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRepBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public MaterialRepBienHistoricoDTO BuscarMaterialRepBienHistoricoID(int Codigo)
        {
            MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO = new MaterialRepBienHistoricoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRepBienHistoricoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRepBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRepBienHistoricoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        materialRepBienHistoricoDTO.MaterialRepBienHistoricoId = Convert.ToInt32(dr["MaterialRepBienHistoricoId"]);
                        materialRepBienHistoricoDTO.DescMaterialRepBienHistorico = dr["DescMaterialRepBienHistorico"].ToString();
                        materialRepBienHistoricoDTO.CodigoMaterialRepBienHistorico = dr["CodigoMaterialRepBienHistorico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return materialRepBienHistoricoDTO;
        }

        public string ActualizarMaterialRepBienHistorico(MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRepBienHistoricoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRepBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRepBienHistoricoId"].Value = materialRepBienHistoricoDTO.MaterialRepBienHistoricoId;

                    cmd.Parameters.Add("@DescMaterialRepBienHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMaterialRepBienHistorico"].Value = materialRepBienHistoricoDTO.DescMaterialRepBienHistorico;

                    cmd.Parameters.Add("@CodigoMaterialRepBienHistorico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialRepBienHistorico"].Value = materialRepBienHistoricoDTO.CodigoMaterialRepBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRepBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarMaterialRepBienHistorico(MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialRepBienHistoricoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRepBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRepBienHistoricoId"].Value = materialRepBienHistoricoDTO.MaterialRepBienHistoricoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRepBienHistoricoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
