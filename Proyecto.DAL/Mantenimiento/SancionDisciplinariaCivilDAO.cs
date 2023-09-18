using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SancionDisciplinariaCivilDAO
    {

        SqlCommand cmd = new();

        public List<SancionDisciplinariaCivilDTO> ObtenerSancionDisciplinariaCivils()
        {
            List<SancionDisciplinariaCivilDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SancionDisciplinariaCivilDTO()
                        {
                            SancionDisciplinariaCivilId = Convert.ToInt32(dr["SancionDisciplinariaCivilId"]),
                            DescSancionDisciplinariaCivil = dr["DescSancionDisciplinariaCivil"].ToString(),
                            CodigoSancionDisciplinariaCivil = dr["CodigoSancionDisciplinariaCivil"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSancionDisciplinariaCivil(SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSancionDisciplinariaCivil", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescSancionDisciplinariaCivil"].Value = sancionDisciplinariaCivilDTO.DescSancionDisciplinariaCivil;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaCivil", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoSancionDisciplinariaCivil"].Value = sancionDisciplinariaCivilDTO.CodigoSancionDisciplinariaCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sancionDisciplinariaCivilDTO.UsuarioIngresoRegistro;

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

        public SancionDisciplinariaCivilDTO BuscarSancionDisciplinariaCivilID(int Codigo)
        {
            SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO = new SancionDisciplinariaCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SancionDisciplinariaCivilId", SqlDbType.Int);
                    cmd.Parameters["@SancionDisciplinariaCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        sancionDisciplinariaCivilDTO.SancionDisciplinariaCivilId = Convert.ToInt32(dr["SancionDisciplinariaCivilId"]);
                        sancionDisciplinariaCivilDTO.DescSancionDisciplinariaCivil = dr["DescSancionDisciplinariaCivil"].ToString();
                        sancionDisciplinariaCivilDTO.CodigoSancionDisciplinariaCivil = dr["CodigoSancionDisciplinariaCivil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return sancionDisciplinariaCivilDTO;
        }

        public string ActualizarSancionDisciplinariaCivil(SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SancionDisciplinariaCivilId", SqlDbType.Int);
                    cmd.Parameters["@SancionDisciplinariaCivilId"].Value = sancionDisciplinariaCivilDTO.SancionDisciplinariaCivilId;

                    cmd.Parameters.Add("@DescSancionDisciplinariaCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSancionDisciplinariaCivil"].Value = sancionDisciplinariaCivilDTO.DescSancionDisciplinariaCivil;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaCivil", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSancionDisciplinariaCivil"].Value = sancionDisciplinariaCivilDTO.CodigoSancionDisciplinariaCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sancionDisciplinariaCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSancionDisciplinariaCivil(SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SancionDisciplinariaCivilId", SqlDbType.Int);
                    cmd.Parameters["@SancionDisciplinariaCivilId"].Value = sancionDisciplinariaCivilDTO.SancionDisciplinariaCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sancionDisciplinariaCivilDTO.UsuarioIngresoRegistro;

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
