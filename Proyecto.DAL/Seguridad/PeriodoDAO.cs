using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class PeriodoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<PeriodoDTO> ObtenerPeriodos()
        {
            List<PeriodoDTO> lista = new List<PeriodoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_PeriodoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new PeriodoDTO()
                        {
                            PeriodoId = Convert.ToInt32(dr["PeriodoId"]),
                            Nombre = dr["NombrePeriodo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPeriodo(PeriodoDTO periodoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PeriodoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Nombre"].Value = periodoDTO.Nombre;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = periodoDTO.UsuarioIngresoRegistro;

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

        public PeriodoDTO BuscarPeriodoID(int PeriodoId)
        {
            PeriodoDTO PeriodoDTO = new PeriodoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PeriodoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDPeriodo = new SqlParameter();
                    pIDPeriodo.ParameterName = "@PeriodoId";
                    pIDPeriodo.SqlDbType = SqlDbType.Int;
                    pIDPeriodo.Value = PeriodoId;

                    cmd.Parameters.Add(pIDPeriodo);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        PeriodoDTO.PeriodoId = Convert.ToInt32(dr["PeriodoId"]);
                        PeriodoDTO.Nombre = dr["Nombre"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PeriodoDTO;
        }

        public string ActualizarPeriodo(PeriodoDTO periodoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PeriodoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pPeriodoId = new SqlParameter();
                    pPeriodoId.ParameterName = "@PeriodoId";
                    pPeriodoId.SqlDbType = SqlDbType.Int;
                    pPeriodoId.Value = periodoDTO.PeriodoId;

                    SqlParameter pPeriodo = new SqlParameter();
                    pPeriodo.ParameterName = "@Nombre";
                    pPeriodo.SqlDbType = SqlDbType.VarChar;
                    pPeriodo.Size = 80;
                    pPeriodo.Value = periodoDTO.Nombre;

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = "192.168.1.24";

                    cmd.Parameters.Add(pPeriodoId);
                    cmd.Parameters.Add(pPeriodo);
                    cmd.Parameters.Add(pIP);

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

        public bool EliminarPeriodo(int PeriodoId)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PeriodoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pPeriodoId = new SqlParameter();
                    pPeriodoId.ParameterName = "@PeriodoId";
                    pPeriodoId.SqlDbType = SqlDbType.Int;
                    pPeriodoId.Value = PeriodoId;

                    cmd.Parameters.Add(pPeriodoId);
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
