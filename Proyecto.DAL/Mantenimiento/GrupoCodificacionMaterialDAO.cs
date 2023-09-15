using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoCodificacionMaterialDAO
    {

        SqlCommand cmd = new();

        public List<GrupoCodificacionMaterialDTO> ObtenerGrupoCodificacionMaterials()
        {
            List<GrupoCodificacionMaterialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoCodificacionMaterialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoCodificacionMaterialDTO()
                        {
                            GrupoCodificacionMaterialId = Convert.ToInt32(dr["GrupoCodificacionMaterialId"]),
                            DescGrupoCodificacionMaterial = dr["DescGrupoCodificacionMaterial"].ToString(),
                            CodigoGrupoCodificacionMaterial = dr["CodigoGrupoCodificacionMaterial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoCodificacionMaterial(GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoCodificacionMaterialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoCodificacionMaterial", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGrupoCodificacionMaterial"].Value = grupoCodificacionMaterialDTO.DescGrupoCodificacionMaterial;

                    cmd.Parameters.Add("@CodigoGrupoCodificacionMaterial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGrupoCodificacionMaterial"].Value = grupoCodificacionMaterialDTO.CodigoGrupoCodificacionMaterial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoCodificacionMaterialDTO.UsuarioIngresoRegistro;

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

        public GrupoCodificacionMaterialDTO BuscarGrupoCodificacionMaterialID(int Codigo)
        {
            GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO = new GrupoCodificacionMaterialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoCodificacionMaterialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoCodificacionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@GrupoCodificacionMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoCodificacionMaterialDTO.GrupoCodificacionMaterialId = Convert.ToInt32(dr["GrupoCodificacionMaterialId"]);
                        grupoCodificacionMaterialDTO.DescGrupoCodificacionMaterial = dr["DescGrupoCodificacionMaterial"].ToString();
                        grupoCodificacionMaterialDTO.CodigoGrupoCodificacionMaterial = dr["CodigoGrupoCodificacionMaterial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoCodificacionMaterialDTO;
        }

        public string ActualizarGrupoCodificacionMaterial(GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GrupoCodificacionMaterialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoCodificacionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@GrupoCodificacionMaterialId"].Value = grupoCodificacionMaterialDTO.GrupoCodificacionMaterialId;

                    cmd.Parameters.Add("@DescGrupoCodificacionMaterial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoCodificacionMaterial"].Value = grupoCodificacionMaterialDTO.DescGrupoCodificacionMaterial;

                    cmd.Parameters.Add("@CodigoGrupoCodificacionMaterial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoCodificacionMaterial"].Value = grupoCodificacionMaterialDTO.CodigoGrupoCodificacionMaterial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoCodificacionMaterialDTO.UsuarioIngresoRegistro;

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

        public bool EliminarGrupoCodificacionMaterial(GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoCodificacionMaterialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoCodificacionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@GrupoCodificacionMaterialId"].Value = grupoCodificacionMaterialDTO.GrupoCodificacionMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoCodificacionMaterialDTO.UsuarioIngresoRegistro;

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
