using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CanalDenunciaDAO
    {

        SqlCommand cmd = new();

        public List<CanalDenunciaDTO> ObtenerCanalDenuncias()
        {
            List<CanalDenunciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CanalDenunciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CanalDenunciaDTO()
                        {
                            CanalDenunciaId = Convert.ToInt32(dr["CanalDenunciaId"]),
                            DescCanalDenuncia = dr["DescCanalDenuncia"].ToString(),
                            CodigoCanalDenuncia = dr["CodigoCanalDenuncia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCanalDenuncia(CanalDenunciaDTO canalDenunciaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CanalDenunciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCanalDenuncia", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescCanalDenuncia"].Value = canalDenunciaDTO.DescCanalDenuncia;

                    cmd.Parameters.Add("@CodigoCanalDenuncia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoCanalDenuncia"].Value = canalDenunciaDTO.CodigoCanalDenuncia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = canalDenunciaDTO.UsuarioIngresoRegistro;

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

        public CanalDenunciaDTO BuscarCanalDenunciaID(int Codigo)
        {
            CanalDenunciaDTO canalDenunciaDTO = new CanalDenunciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CanalDenunciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CanalDenunciaId", SqlDbType.Int);
                    cmd.Parameters["@CanalDenunciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        canalDenunciaDTO.CanalDenunciaId = Convert.ToInt32(dr["CanalDenunciaId"]);
                        canalDenunciaDTO.DescCanalDenuncia = dr["DescCanalDenuncia"].ToString();
                        canalDenunciaDTO.CodigoCanalDenuncia = dr["CodigoCanalDenuncia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return canalDenunciaDTO;
        }

        public string ActualizarCanalDenuncia(CanalDenunciaDTO canalDenunciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CanalDenunciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CanalDenunciaId", SqlDbType.Int);
                    cmd.Parameters["@CanalDenunciaId"].Value = canalDenunciaDTO.CanalDenunciaId;

                    cmd.Parameters.Add("@DescCanalDenuncia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCanalDenuncia"].Value = canalDenunciaDTO.DescCanalDenuncia;

                    cmd.Parameters.Add("@CodigoCanalDenuncia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCanalDenuncia"].Value = canalDenunciaDTO.CodigoCanalDenuncia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = canalDenunciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCanalDenuncia(CanalDenunciaDTO canalDenunciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CanalDenunciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CanalDenunciaId", SqlDbType.Int);
                    cmd.Parameters["@CanalDenunciaId"].Value = canalDenunciaDTO.CanalDenunciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = canalDenunciaDTO.UsuarioIngresoRegistro;

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
