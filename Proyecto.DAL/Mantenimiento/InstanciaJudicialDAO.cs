using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InstanciaJudicialDAO
    {

        SqlCommand cmd = new();

        public List<InstanciaJudicialDTO> ObtenerInstanciaJudicials()
        {
            List<InstanciaJudicialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InstanciasJudicialesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InstanciaJudicialDTO()
                        {
                            InstanciaJudicialId = Convert.ToInt32(dr["InstanciaJudicialId"]),
                            DescInstanciaJudicial = dr["DescInstanciaJudicial"].ToString(),
                            CodigoInstanciaJudicial = dr["CodigoInstanciaJudicial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInstanciaJudicial(InstanciaJudicialDTO instanciaJudicialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstanciasJudicialesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInstanciaJudicial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInstanciaJudicial"].Value = instanciaJudicialDTO.DescInstanciaJudicial;

                    cmd.Parameters.Add("@CodigoInstanciaJudicial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoInstanciaJudicial"].Value = instanciaJudicialDTO.CodigoInstanciaJudicial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = instanciaJudicialDTO.UsuarioIngresoRegistro;

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

        public InstanciaJudicialDTO BuscarInstanciaJudicialID(int Codigo)
        {
            InstanciaJudicialDTO instanciaJudicialDTO = new InstanciaJudicialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstanciasJudicialesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstanciaJudicialId", SqlDbType.Int);
                    cmd.Parameters["@InstanciaJudicialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        instanciaJudicialDTO.InstanciaJudicialId = Convert.ToInt32(dr["InstanciaJudicialId"]);
                        instanciaJudicialDTO.DescInstanciaJudicial = dr["DescInstanciaJudicial"].ToString();
                        instanciaJudicialDTO.CodigoInstanciaJudicial = dr["CodigoInstanciaJudicial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return instanciaJudicialDTO;
        }

        public string ActualizarInstanciaJudicial(InstanciaJudicialDTO instanciaJudicialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstanciasJudicialesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstanciaJudicialId", SqlDbType.Int);
                    cmd.Parameters["@InstanciaJudicialId"].Value = instanciaJudicialDTO.InstanciaJudicialId;

                    cmd.Parameters.Add("@DescInstanciaJudicial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInstanciaJudicial"].Value = instanciaJudicialDTO.DescInstanciaJudicial;

                    cmd.Parameters.Add("@CodigoInstanciaJudicial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstanciaJudicial"].Value = instanciaJudicialDTO.CodigoInstanciaJudicial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = instanciaJudicialDTO.UsuarioIngresoRegistro;

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

        public string EliminarInstanciaJudicial(InstanciaJudicialDTO instanciaJudicialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstanciasJudicialesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstanciaJudicialId", SqlDbType.Int);
                    cmd.Parameters["@InstanciaJudicialId"].Value = instanciaJudicialDTO.InstanciaJudicialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = instanciaJudicialDTO.UsuarioIngresoRegistro;

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
