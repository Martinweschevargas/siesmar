using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DireccionTecnicaDAO
    {

        SqlCommand cmd = new();

        public List<DireccionTecnicaDTO> ObtenerDireccionTecnicas()
        {
            List<DireccionTecnicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DireccionesTecnicasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DireccionTecnicaDTO()
                        {
                            DireccionTecnicaId = Convert.ToInt32(dr["DireccionTecnicaId"]),
                            DescDireccionTecnica = dr["DescDireccionTecnica"].ToString(),
                            CodigoDireccionTecnica = dr["CodigoDireccionTecnica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDireccionTecnica(DireccionTecnicaDTO direccionTecnicaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DireccionesTecnicasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDireccionTecnica", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescDireccionTecnica"].Value = direccionTecnicaDTO.DescDireccionTecnica;

                    cmd.Parameters.Add("@CodigoDireccionTecnica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoDireccionTecnica"].Value = direccionTecnicaDTO.CodigoDireccionTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = direccionTecnicaDTO.UsuarioIngresoRegistro;

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

        public DireccionTecnicaDTO BuscarDireccionTecnicaID(int Codigo)
        {
            DireccionTecnicaDTO direccionTecnicaDTO = new DireccionTecnicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DireccionesTecnicasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DireccionTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@DireccionTecnicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        direccionTecnicaDTO.DireccionTecnicaId = Convert.ToInt32(dr["DireccionTecnicaId"]);
                        direccionTecnicaDTO.DescDireccionTecnica = dr["DescDireccionTecnica"].ToString();
                        direccionTecnicaDTO.CodigoDireccionTecnica = dr["CodigoDireccionTecnica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return direccionTecnicaDTO;
        }

        public string ActualizarDireccionTecnica(DireccionTecnicaDTO direccionTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_DireccionesTecnicasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DireccionTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@DireccionTecnicaId"].Value = direccionTecnicaDTO.DireccionTecnicaId;

                    cmd.Parameters.Add("@DescDireccionTecnica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDireccionTecnica"].Value = direccionTecnicaDTO.DescDireccionTecnica;

                    cmd.Parameters.Add("@CodigoDireccionTecnica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDireccionTecnica"].Value = direccionTecnicaDTO.CodigoDireccionTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = direccionTecnicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarDireccionTecnica(DireccionTecnicaDTO direccionTecnicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DireccionesTecnicasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DireccionTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@DireccionTecnicaId"].Value = direccionTecnicaDTO.DireccionTecnicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = direccionTecnicaDTO.UsuarioIngresoRegistro;

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
