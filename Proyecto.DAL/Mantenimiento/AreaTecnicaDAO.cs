
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AreaTecnicaDAO
    {

        SqlCommand cmd = new();

        public List<AreaTecnicaDTO> ObtenerAreaTecnicas()
        {
            List<AreaTecnicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AreaTecnicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AreaTecnicaDTO()
                        {
                            AreaTecnicaId = Convert.ToInt32(dr["AreaTecnicaId"]),
                            DescAreaTecnica = dr["DescAreaTecnica"].ToString(),
                            CodigoAreaTecnica = dr["CodigoAreaTecnica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAreaTecnica(AreaTecnicaDTO areaTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaTecnicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAreaTecnica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescAreaTecnica"].Value = areaTecnicaDTO.DescAreaTecnica;

                    cmd.Parameters.Add("@CodigoAreaTecnica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoAreaTecnica"].Value = areaTecnicaDTO.CodigoAreaTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaTecnicaDTO.UsuarioIngresoRegistro;

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

        public AreaTecnicaDTO BuscarAreaTecnicaID(int Codigo)
        {
            AreaTecnicaDTO areaTecnicaDTO = new AreaTecnicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaTecnicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@AreaTecnicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        areaTecnicaDTO.AreaTecnicaId = Convert.ToInt32(dr["AreaTecnicaId"]);
                        areaTecnicaDTO.DescAreaTecnica = dr["DescAreaTecnica"].ToString();
                        areaTecnicaDTO.CodigoAreaTecnica = dr["CodigoAreaTecnica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return areaTecnicaDTO;
        }

        public string ActualizarAreaTecnica(AreaTecnicaDTO areaTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AreaTecnicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@AreaTecnicaId"].Value = areaTecnicaDTO.AreaTecnicaId;

                    cmd.Parameters.Add("@DescAreaTecnica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAreaTecnica"].Value = areaTecnicaDTO.DescAreaTecnica;

                    cmd.Parameters.Add("@CodigoAreaTecnica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAreaTecnica"].Value = areaTecnicaDTO.CodigoAreaTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaTecnicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarAreaTecnica(AreaTecnicaDTO areaTecnicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaTecnicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@AreaTecnicaId"].Value = areaTecnicaDTO.AreaTecnicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaTecnicaDTO.UsuarioIngresoRegistro;

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
