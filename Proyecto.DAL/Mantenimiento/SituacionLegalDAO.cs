using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SituacionLegalDAO
    {

        SqlCommand cmd = new();

        public List<SituacionLegalDTO> ObtenerSituacionLegals()
        {
            List<SituacionLegalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SituacionLegalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionLegalDTO()
                        {
                            SituacionLegalId = Convert.ToInt32(dr["SituacionLegalId"]),
                            DescSituacionLegal = dr["DescSituacionLegal"].ToString(),
                            CodigoSituacionLegal = dr["CodigoSituacionLegal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSituacionLegal(SituacionLegalDTO situacionLegalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionLegalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSituacionLegal", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescSituacionLegal"].Value = situacionLegalDTO.DescSituacionLegal;

                    cmd.Parameters.Add("@CodigoSituacionLegal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoSituacionLegal"].Value = situacionLegalDTO.CodigoSituacionLegal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionLegalDTO.UsuarioIngresoRegistro;

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

        public SituacionLegalDTO BuscarSituacionLegalID(int Codigo)
        {
            SituacionLegalDTO situacionLegalDTO = new SituacionLegalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionLegalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionLegalId", SqlDbType.Int);
                    cmd.Parameters["@SituacionLegalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        situacionLegalDTO.SituacionLegalId = Convert.ToInt32(dr["SituacionLegalId"]);
                        situacionLegalDTO.DescSituacionLegal = dr["DescSituacionLegal"].ToString();
                        situacionLegalDTO.CodigoSituacionLegal = dr["CodigoSituacionLegal"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionLegalDTO;
        }

        public string ActualizarSituacionLegal(SituacionLegalDTO situacionLegalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SituacionLegalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionLegalId", SqlDbType.Int);
                    cmd.Parameters["@SituacionLegalId"].Value = situacionLegalDTO.SituacionLegalId;

                    cmd.Parameters.Add("@DescSituacionLegal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSituacionLegal"].Value = situacionLegalDTO.DescSituacionLegal;

                    cmd.Parameters.Add("@CodigoSituacionLegal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSituacionLegal"].Value = situacionLegalDTO.CodigoSituacionLegal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionLegalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSituacionLegal(SituacionLegalDTO situacionLegalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionLegalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionLegalId", SqlDbType.Int);
                    cmd.Parameters["@SituacionLegalId"].Value = situacionLegalDTO.SituacionLegalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionLegalDTO.UsuarioIngresoRegistro;

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
