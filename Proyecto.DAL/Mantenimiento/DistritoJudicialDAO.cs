using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DistritoJudicialDAO
    {

        SqlCommand cmd = new();

        public List<DistritoJudicialDTO> ObtenerDistritoJudiciales()
        {
            List<DistritoJudicialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DistritosJudicialesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DistritoJudicialDTO()
                        {
                            DistritoJudicialId = Convert.ToInt32(dr["DistritoJudicialId"]),
                            DescDistritoJudicial = dr["DescDistritoJudicial"].ToString(),
                            CodigoDistritoJudicial = dr["CodigoDistritoJudicial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDistritoJudicial(DistritoJudicialDTO distritoJudicialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DistritosJudicialesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDistritoJudicial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescDistritoJudicial"].Value = distritoJudicialDTO.DescDistritoJudicial;

                    cmd.Parameters.Add("@CodigoDistritoJudicial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoDistritoJudicial"].Value = distritoJudicialDTO.CodigoDistritoJudicial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distritoJudicialDTO.UsuarioIngresoRegistro;

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

        public DistritoJudicialDTO BuscarDistritoJudicialID(int Codigo)
        {
            DistritoJudicialDTO distritoJudicialDTO = new DistritoJudicialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DistritosJudicialesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDDistritoJudicial = new SqlParameter();
                    pIDDistritoJudicial.ParameterName = "@DistritoJudicialId";
                    pIDDistritoJudicial.SqlDbType = SqlDbType.Int;
                    pIDDistritoJudicial.Value = Codigo;

                    cmd.Parameters.Add(pIDDistritoJudicial);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        distritoJudicialDTO.DistritoJudicialId = Convert.ToInt32(dr["DistritoJudicialId"]);
                        distritoJudicialDTO.DescDistritoJudicial = dr["DescDistritoJudicial"].ToString();
                        distritoJudicialDTO.CodigoDistritoJudicial = dr["CodigoDistritoJudicial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return distritoJudicialDTO;
        }

        public string ActualizarDistritoJudicial(DistritoJudicialDTO distritoJudicialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DistritosJudicialesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pCodigo = new SqlParameter();
                    pCodigo.ParameterName = "@DistritoJudicialId";
                    pCodigo.SqlDbType = SqlDbType.Int;
                    pCodigo.Value = distritoJudicialDTO.DistritoJudicialId;

                    SqlParameter pDistritoJudicial = new SqlParameter();
                    pDistritoJudicial.ParameterName = "@DescDistritoJudicial";
                    pDistritoJudicial.SqlDbType = SqlDbType.VarChar;
                    pDistritoJudicial.Size = 80;
                    pDistritoJudicial.Value = distritoJudicialDTO.DescDistritoJudicial;

                    SqlParameter pCodigoDistritoJudicial = new SqlParameter();
                    pCodigoDistritoJudicial.ParameterName = "@CodigoDistritoJudicial";
                    pCodigoDistritoJudicial.SqlDbType = SqlDbType.VarChar;
                    pCodigoDistritoJudicial.Size = 80;
                    pCodigoDistritoJudicial.Value = distritoJudicialDTO.CodigoDistritoJudicial;

                    SqlParameter pUsuario = new SqlParameter();
                    pUsuario.ParameterName = "@Usuario";
                    pUsuario.SqlDbType = SqlDbType.VarChar;
                    pUsuario.Size = 80;
                    pUsuario.Value = distritoJudicialDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add(pCodigo);
                    cmd.Parameters.Add(pDistritoJudicial);
                    cmd.Parameters.Add(pCodigoDistritoJudicial);
                    cmd.Parameters.Add(pUsuario);

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

        public bool EliminarDistritoJudicial(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DistritosJudicialesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pCodigo = new SqlParameter();
                    pCodigo.ParameterName = "@DistritoJudicialId";
                    pCodigo.SqlDbType = SqlDbType.Int;
                    pCodigo.Value = Codigo;

                    cmd.Parameters.Add(pCodigo);
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

