using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PartidaDAO
    {

        SqlCommand cmd = new();

        public List<PartidaDTO> ObtenerPartidas()
        {
            List<PartidaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PartidaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PartidaDTO()
                        {
                            PartidaId = Convert.ToInt32(dr["PartidaId"]),
                            DescPartida = dr["DescPartida"].ToString(),
                            CodigoPartida = dr["CodigoPartida"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPartida(PartidaDTO partidaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PartidaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPartida", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPartida"].Value = partidaDTO.DescPartida;

                    cmd.Parameters.Add("@CodigoPartida", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPartida"].Value = partidaDTO.CodigoPartida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = partidaDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();
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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public PartidaDTO BuscarPartidaID(int Codigo)
        {
            PartidaDTO partidaDTO = new PartidaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PartidaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PartidaId", SqlDbType.Int);
                    cmd.Parameters["@PartidaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        partidaDTO.PartidaId = Convert.ToInt32(dr["PartidaId"]);
                        partidaDTO.DescPartida = dr["DescPartida"].ToString();
                        partidaDTO.CodigoPartida = dr["CodigoPartida"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return partidaDTO;
        }

        public string ActualizarPartida(PartidaDTO partidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PartidaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PartidaId", SqlDbType.Int);
                    cmd.Parameters["@PartidaId"].Value = partidaDTO.PartidaId;

                    cmd.Parameters.Add("@DescPartida", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPartida"].Value = partidaDTO.DescPartida;

                    cmd.Parameters.Add("@CodigoPartida", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPartida"].Value = partidaDTO.CodigoPartida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = partidaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPartida(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PartidaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PartidaId", SqlDbType.Int);
                    cmd.Parameters["@PartidaId"].Value = Codigo;
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
