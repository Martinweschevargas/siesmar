
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SituacionPersonalSolicitanteDAO
    {

        SqlCommand cmd = new();

        public List<SituacionPersonalSolicitanteDTO> ObtenerSituacionPersonalSolicitantes()
        {
            List<SituacionPersonalSolicitanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalSolicitanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionPersonalSolicitanteDTO()
                        {
                            SituacionPersonalSolId = Convert.ToInt32(dr["SituacionPersonalSolId"]),
                            DescSituacionPersonalSol = dr["DescSituacionPersonalSol"].ToString(),
                            CodigoSituacionPersonalSol = dr["CodigoSituacionPersonalSol"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSituacionPersonalSolicitante(SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalSolicitanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSituacionPersonalSol", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescSituacionPersonalSol"].Value = situacionPersonalSolicitanteDTO.DescSituacionPersonalSol;

                    cmd.Parameters.Add("@CodigoSituacionPersonalSol", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalSol"].Value = situacionPersonalSolicitanteDTO.CodigoSituacionPersonalSol;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionPersonalSolicitanteDTO.UsuarioIngresoRegistro;

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

        public SituacionPersonalSolicitanteDTO BuscarSituacionPersonalSolicitanteID(int Codigo)
        {
            SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO = new SituacionPersonalSolicitanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalSolicitanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionPersonalSolId", SqlDbType.Int);
                    cmd.Parameters["@SituacionPersonalSolId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        situacionPersonalSolicitanteDTO.SituacionPersonalSolId = Convert.ToInt32(dr["SituacionPersonalSolId"]);
                        situacionPersonalSolicitanteDTO.DescSituacionPersonalSol = dr["DescSituacionPersonalSol"].ToString();
                        situacionPersonalSolicitanteDTO.CodigoSituacionPersonalSol = dr["CodigoSituacionPersonalSol"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionPersonalSolicitanteDTO;
        }

        public string ActualizarSituacionPersonalSolicitante(SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalSolicitanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionPersonalSolId", SqlDbType.Int);
                    cmd.Parameters["@SituacionPersonalSolId"].Value = situacionPersonalSolicitanteDTO.SituacionPersonalSolId;

                    cmd.Parameters.Add("@DescSituacionPersonalSol", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSituacionPersonalSol"].Value = situacionPersonalSolicitanteDTO.DescSituacionPersonalSol;

                    cmd.Parameters.Add("@CodigoSituacionPersonalSol", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSituacionPersonalSol"].Value = situacionPersonalSolicitanteDTO.CodigoSituacionPersonalSol;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionPersonalSolicitanteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSituacionPersonalSolicitante(SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalSolicitanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionPersonalSolId", SqlDbType.Int);
                    cmd.Parameters["@SituacionPersonalSolId"].Value = situacionPersonalSolicitanteDTO.SituacionPersonalSolId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionPersonalSolicitanteDTO.UsuarioIngresoRegistro;

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
