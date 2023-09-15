using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SancionDisciplinariaNavalDAO
    {

        SqlCommand cmd = new();

        public List<SancionDisciplinariaNavalDTO> ObtenerSancionDisciplinariaNavals()
        {
            List<SancionDisciplinariaNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SancionDisciplinariaNavalDTO()
                        {
                            SancionDisciplinariaNavalId = Convert.ToInt32(dr["SancionDisciplinariaNavalId"]),
                            DescSancionDisciplinariaNaval = dr["DescSancionDisciplinariaNaval"].ToString(),
                            CodigoSancionDisciplinariaNaval = dr["CodigoSancionDisciplinariaNaval"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSancionDisciplinariaNaval(SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSancionDisciplinariaNaval", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescSancionDisciplinariaNaval"].Value = sancionDisciplinariaNavalDTO.DescSancionDisciplinariaNaval;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaNaval", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoSancionDisciplinariaNaval"].Value = sancionDisciplinariaNavalDTO.CodigoSancionDisciplinariaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sancionDisciplinariaNavalDTO.UsuarioIngresoRegistro;

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

        public SancionDisciplinariaNavalDTO BuscarSancionDisciplinariaNavalID(int Codigo)
        {
            SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO = new SancionDisciplinariaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SancionDisciplinariaNavalId", SqlDbType.Int);
                    cmd.Parameters["@SancionDisciplinariaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        sancionDisciplinariaNavalDTO.SancionDisciplinariaNavalId = Convert.ToInt32(dr["SancionDisciplinariaNavalId"]);
                        sancionDisciplinariaNavalDTO.DescSancionDisciplinariaNaval = dr["DescSancionDisciplinariaNaval"].ToString();
                        sancionDisciplinariaNavalDTO.CodigoSancionDisciplinariaNaval = dr["CodigoSancionDisciplinariaNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return sancionDisciplinariaNavalDTO;
        }

        public string ActualizarSancionDisciplinariaNaval(SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SancionDisciplinariaNavalId", SqlDbType.Int);
                    cmd.Parameters["@SancionDisciplinariaNavalId"].Value = sancionDisciplinariaNavalDTO.SancionDisciplinariaNavalId;

                    cmd.Parameters.Add("@DescSancionDisciplinariaNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSancionDisciplinariaNaval"].Value = sancionDisciplinariaNavalDTO.DescSancionDisciplinariaNaval;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaNaval", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSancionDisciplinariaNaval"].Value = sancionDisciplinariaNavalDTO.CodigoSancionDisciplinariaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sancionDisciplinariaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSancionDisciplinariaNaval(SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SancionDisciplinariaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SancionDisciplinariaNavalId", SqlDbType.Int);
                    cmd.Parameters["@SancionDisciplinariaNavalId"].Value = sancionDisciplinariaNavalDTO.SancionDisciplinariaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = sancionDisciplinariaNavalDTO.UsuarioIngresoRegistro;

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
