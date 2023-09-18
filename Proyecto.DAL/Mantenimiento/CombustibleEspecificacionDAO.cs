using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CombustibleEspecificacionDAO
    {

        SqlCommand cmd = new();

        public List<CombustibleEspecificacionDTO> ObtenerCombustibleEspecificacions()
        {
            List<CombustibleEspecificacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CombustibleEspecificacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CombustibleEspecificacionDTO()
                        {
                            CombustibleEspecificacionId = Convert.ToInt32(dr["CombustibleEspecificacionId"]),
                            DescCombustibleEspecificacion = dr["DescCombustibleEspecificacion"].ToString(),
                            CodigoCombustibleEspecificacion = dr["CodigoCombustibleEspecificacion"].ToString(),
                            DescClaseCombustible = dr["DescClaseCombustible"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCombustibleEspecificacion(CombustibleEspecificacionDTO CombustibleEspecificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CombustibleEspecificacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCombustibleEspecificacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCombustibleEspecificacion"].Value = CombustibleEspecificacionDTO.DescCombustibleEspecificacion;

                    cmd.Parameters.Add("@CodigoCombustibleEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCombustibleEspecificacion"].Value = CombustibleEspecificacionDTO.CodigoCombustibleEspecificacion;

                    cmd.Parameters.Add("@ClaseCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ClaseCombustibleId"].Value = CombustibleEspecificacionDTO.ClaseCombustibleId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CombustibleEspecificacionDTO.UsuarioIngresoRegistro;

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

        public CombustibleEspecificacionDTO BuscarCombustibleEspecificacionID(int Codigo)
        {
            CombustibleEspecificacionDTO CombustibleEspecificacionDTO = new CombustibleEspecificacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CombustibleEspecificacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CombustibleEspecificacionId", SqlDbType.Int);
                    cmd.Parameters["@CombustibleEspecificacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CombustibleEspecificacionDTO.CombustibleEspecificacionId = Convert.ToInt32(dr["CombustibleEspecificacionId"]);
                        CombustibleEspecificacionDTO.DescCombustibleEspecificacion = dr["DescCombustibleEspecificacion"].ToString();
                        CombustibleEspecificacionDTO.CodigoCombustibleEspecificacion = dr["CodigoCombustibleEspecificacion"].ToString();
                        CombustibleEspecificacionDTO.ClaseCombustibleId = Convert.ToInt32(dr["ClaseCombustibleId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CombustibleEspecificacionDTO;
        }

        public string ActualizarCombustibleEspecificacion(CombustibleEspecificacionDTO CombustibleEspecificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_CombustibleEspecificacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CombustibleEspecificacionId", SqlDbType.Int);
                    cmd.Parameters["@CombustibleEspecificacionId"].Value = CombustibleEspecificacionDTO.CombustibleEspecificacionId;

                    cmd.Parameters.Add("@DescCombustibleEspecificacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCombustibleEspecificacion"].Value = CombustibleEspecificacionDTO.DescCombustibleEspecificacion;

                    cmd.Parameters.Add("@CodigoCombustibleEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCombustibleEspecificacion"].Value = CombustibleEspecificacionDTO.CodigoCombustibleEspecificacion;

                    cmd.Parameters.Add("@ClaseCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ClaseCombustibleId"].Value = CombustibleEspecificacionDTO.ClaseCombustibleId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CombustibleEspecificacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarCombustibleEspecificacion(CombustibleEspecificacionDTO CombustibleEspecificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CombustibleEspecificacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CombustibleEspecificacionId", SqlDbType.Int);
                    cmd.Parameters["@CombustibleEspecificacionId"].Value = CombustibleEspecificacionDTO.CombustibleEspecificacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CombustibleEspecificacionDTO.UsuarioIngresoRegistro;

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
