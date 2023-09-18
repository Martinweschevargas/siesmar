using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class VerificacionFichaTecnicaDAO
    {

        SqlCommand cmd = new();

        public List<VerificacionFichaTecnicaDTO> ObtenerVerificacionFichaTecnicas()
        {
            List<VerificacionFichaTecnicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_VerificacionFichaTecnicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VerificacionFichaTecnicaDTO()
                        {
                            VerificacionFichaTecnicaId = Convert.ToInt32(dr["VerificacionFichaTecnicaId"]),
                            DescVerificacionFichaTecnica = dr["DescVerificacionFichaTecnica"].ToString(),
                            CodigoVerificacionFichaTecnica = dr["CodigoVerificacionFichaTecnica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarVerificacionFichaTecnica(VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VerificacionFichaTecnicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescVerificacionFichaTecnica", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescVerificacionFichaTecnica"].Value = verificacionFichaTecnicaDTO.DescVerificacionFichaTecnica;

                    cmd.Parameters.Add("@CodigoVerificacionFichaTecnica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoVerificacionFichaTecnica"].Value = verificacionFichaTecnicaDTO.CodigoVerificacionFichaTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = verificacionFichaTecnicaDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public VerificacionFichaTecnicaDTO BuscarVerificacionFichaTecnicaID(int Codigo)
        {
            VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO = new VerificacionFichaTecnicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VerificacionFichaTecnicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VerificacionFichaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@VerificacionFichaTecnicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        verificacionFichaTecnicaDTO.VerificacionFichaTecnicaId = Convert.ToInt32(dr["VerificacionFichaTecnicaId"]);
                        verificacionFichaTecnicaDTO.DescVerificacionFichaTecnica = dr["DescVerificacionFichaTecnica"].ToString();
                        verificacionFichaTecnicaDTO.CodigoVerificacionFichaTecnica = dr["CodigoVerificacionFichaTecnica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return verificacionFichaTecnicaDTO;
        }

        public string ActualizarVerificacionFichaTecnica(VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_VerificacionFichaTecnicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VerificacionFichaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@VerificacionFichaTecnicaId"].Value = verificacionFichaTecnicaDTO.VerificacionFichaTecnicaId;

                    cmd.Parameters.Add("@DescVerificacionFichaTecnica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescVerificacionFichaTecnica"].Value = verificacionFichaTecnicaDTO.DescVerificacionFichaTecnica;

                    cmd.Parameters.Add("@CodigoVerificacionFichaTecnica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoVerificacionFichaTecnica"].Value = verificacionFichaTecnicaDTO.CodigoVerificacionFichaTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = verificacionFichaTecnicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarVerificacionFichaTecnica(VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VerificacionFichaTecnicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VerificacionFichaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@VerificacionFichaTecnicaId"].Value = verificacionFichaTecnicaDTO.VerificacionFichaTecnicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = verificacionFichaTecnicaDTO.UsuarioIngresoRegistro;

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
