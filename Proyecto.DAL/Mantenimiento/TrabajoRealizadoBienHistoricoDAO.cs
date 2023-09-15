
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TrabajoRealizadoBienHistoricoDAO
    {

        SqlCommand cmd = new();

        public List<TrabajoRealizadoBienHistoricoDTO> ObtenerTrabajoRealizadoBienHistoricos()
        {
            List<TrabajoRealizadoBienHistoricoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TrabajosRealizadosBienHistoricoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TrabajoRealizadoBienHistoricoDTO()
                        {
                            TrabajoRealizadoBienHistoricoId = Convert.ToInt32(dr["TrabajoRealizadoBienHistoricoId"]),
                            DescTrabajoRealizadoBienHistorico = dr["DescTrabajoRealizadoBienHistorico"].ToString(),
                            CodigoTrabajoRealizadoBienHistorico = dr["CodigoTrabajoRealizadoBienHistorico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTrabajoRealizadoBienHistorico(TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajosRealizadosBienHistoricoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTrabajoRealizadoBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTrabajoRealizadoBienHistorico"].Value = trabajoRealizadoBienHistoricoDTO.DescTrabajoRealizadoBienHistorico;

                    cmd.Parameters.Add("@CodigoTrabajoRealizadoBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTrabajoRealizadoBienHistorico"].Value = trabajoRealizadoBienHistoricoDTO.CodigoTrabajoRealizadoBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoRealizadoBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public TrabajoRealizadoBienHistoricoDTO BuscarTrabajoRealizadoBienHistoricoID(int Codigo)
        {
            TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO = new TrabajoRealizadoBienHistoricoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajosRealizadosBienHistoricoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRealizadoBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRealizadoBienHistoricoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        trabajoRealizadoBienHistoricoDTO.TrabajoRealizadoBienHistoricoId = Convert.ToInt32(dr["TrabajoRealizadoBienHistoricoId"]);
                        trabajoRealizadoBienHistoricoDTO.DescTrabajoRealizadoBienHistorico = dr["DescTrabajoRealizadoBienHistorico"].ToString();
                        trabajoRealizadoBienHistoricoDTO.CodigoTrabajoRealizadoBienHistorico = dr["CodigoTrabajoRealizadoBienHistorico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return trabajoRealizadoBienHistoricoDTO;
        }

        public string ActualizarTrabajoRealizadoBienHistorico(TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TrabajosRealizadosBienHistoricoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRealizadoBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRealizadoBienHistoricoId"].Value = trabajoRealizadoBienHistoricoDTO.TrabajoRealizadoBienHistoricoId;

                    cmd.Parameters.Add("@DescTrabajoRealizadoBienHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTrabajoRealizadoBienHistorico"].Value = trabajoRealizadoBienHistoricoDTO.DescTrabajoRealizadoBienHistorico;

                    cmd.Parameters.Add("@CodigoTrabajoRealizadoBienHistorico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTrabajoRealizadoBienHistorico"].Value = trabajoRealizadoBienHistoricoDTO.CodigoTrabajoRealizadoBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoRealizadoBienHistoricoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarTrabajoRealizadoBienHistorico(TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajosRealizadosBienHistoricoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRealizadoBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRealizadoBienHistoricoId"].Value = trabajoRealizadoBienHistoricoDTO.TrabajoRealizadoBienHistoricoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoRealizadoBienHistoricoDTO.UsuarioIngresoRegistro;

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
