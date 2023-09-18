using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SituacionExpedienteTecnicoDAO
    {

        SqlCommand cmd = new();

        public List<SituacionExpedienteTecnicoDTO> ObtenerSituacionExpedienteTecnicos()
        {
            List<SituacionExpedienteTecnicoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SituacionExpedienteTecnicoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionExpedienteTecnicoDTO()
                        {
                            SituacionExpedienteTecnicoId = Convert.ToInt32(dr["SituacionExpedienteTecnicoId"]),
                            DescSituacionExpedienteTecnico = dr["DescSituacionExpedienteTecnico"].ToString(),
                            CodigoSituacionExpedienteTecnico = dr["CodigoSituacionExpedienteTecnico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSituacionExpedienteTecnico(SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionExpedienteTecnicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSituacionExpedienteTecnico", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescSituacionExpedienteTecnico"].Value = situacionExpedienteTecnicoDTO.DescSituacionExpedienteTecnico;

                    cmd.Parameters.Add("@CodigoSituacionExpedienteTecnico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoSituacionExpedienteTecnico"].Value = situacionExpedienteTecnicoDTO.CodigoSituacionExpedienteTecnico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionExpedienteTecnicoDTO.UsuarioIngresoRegistro;

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

        public SituacionExpedienteTecnicoDTO BuscarSituacionExpedienteTecnicoID(int Codigo)
        {
            SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO = new SituacionExpedienteTecnicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionExpedienteTecnicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionExpedienteTecnicoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionExpedienteTecnicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        situacionExpedienteTecnicoDTO.SituacionExpedienteTecnicoId = Convert.ToInt32(dr["SituacionExpedienteTecnicoId"]);
                        situacionExpedienteTecnicoDTO.DescSituacionExpedienteTecnico = dr["DescSituacionExpedienteTecnico"].ToString();
                        situacionExpedienteTecnicoDTO.CodigoSituacionExpedienteTecnico = dr["CodigoSituacionExpedienteTecnico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionExpedienteTecnicoDTO;
        }

        public string ActualizarSituacionExpedienteTecnico(SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SituacionExpedienteTecnicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionExpedienteTecnicoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionExpedienteTecnicoId"].Value = situacionExpedienteTecnicoDTO.SituacionExpedienteTecnicoId;

                    cmd.Parameters.Add("@DescSituacionExpedienteTecnico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSituacionExpedienteTecnico"].Value = situacionExpedienteTecnicoDTO.DescSituacionExpedienteTecnico;

                    cmd.Parameters.Add("@CodigoSituacionExpedienteTecnico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSituacionExpedienteTecnico"].Value = situacionExpedienteTecnicoDTO.CodigoSituacionExpedienteTecnico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionExpedienteTecnicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSituacionExpedienteTecnico(SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionExpedienteTecnicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionExpedienteTecnicoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionExpedienteTecnicoId"].Value = situacionExpedienteTecnicoDTO.SituacionExpedienteTecnicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionExpedienteTecnicoDTO.UsuarioIngresoRegistro;

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
