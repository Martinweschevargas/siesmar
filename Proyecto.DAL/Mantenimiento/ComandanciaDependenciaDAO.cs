using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ComandanciaDependenciaDAO
    {

        SqlCommand cmd = new();

        public List<ComandanciaDependenciaDTO> ObtenerComandanciaDependencias()
        {
            List<ComandanciaDependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ComandanciaDependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ComandanciaDependenciaDTO()
                        {
                            ComandanciaDependenciaId = Convert.ToInt32(dr["ComandanciaDependenciaId"]),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarComandanciaDependencia(ComandanciaDependenciaDTO comandanciaDependenciaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescComandanciaDependencia", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescComandanciaDependencia"].Value = comandanciaDependenciaDTO.DescComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = comandanciaDependenciaDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comandanciaDependenciaDTO.UsuarioIngresoRegistro;

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

        public ComandanciaDependenciaDTO BuscarComandanciaDependenciaID(int Codigo)
        {
            ComandanciaDependenciaDTO comandanciaDependenciaDTO = new ComandanciaDependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaDependenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        comandanciaDependenciaDTO.ComandanciaDependenciaId = Convert.ToInt32(dr["ComandanciaDependenciaId"]);
                        comandanciaDependenciaDTO.DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString();
                        comandanciaDependenciaDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return comandanciaDependenciaDTO;
        }

        public string ActualizarComandanciaDependencia(ComandanciaDependenciaDTO comandanciaDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaDependenciaId"].Value = comandanciaDependenciaDTO.ComandanciaDependenciaId;

                    cmd.Parameters.Add("@DescComandanciaDependencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescComandanciaDependencia"].Value = comandanciaDependenciaDTO.DescComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = comandanciaDependenciaDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comandanciaDependenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarComandanciaDependencia(ComandanciaDependenciaDTO comandanciaDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaDependenciaId"].Value = comandanciaDependenciaDTO.ComandanciaDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comandanciaDependenciaDTO.UsuarioIngresoRegistro;

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
