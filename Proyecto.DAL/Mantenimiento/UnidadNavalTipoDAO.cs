using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadNavalTipoDAO
    {

        SqlCommand cmd = new();

        public List<UnidadNavalTipoDTO> ObtenerUnidadNavalTipos()
        {
            List<UnidadNavalTipoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalTIpoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadNavalTipoDTO()
                        {
                            UnidadNavalTipoId = Convert.ToInt32(dr["UnidadNavalTipoId"]),
                            DescUnidadNavalTipo = dr["DescUnidadNavalTipo"].ToString(),
                            CodigoUnidadNavalTipo = dr["CodigoUnidadNavalTipo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadNavalTipo(UnidadNavalTipoDTO unidadNavalTipoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalTIpoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUnidadNavalTipo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescUnidadNavalTipo"].Value = unidadNavalTipoDTO.DescUnidadNavalTipo;

                    cmd.Parameters.Add("@CodigoUnidadNavalTipo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoUnidadNavalTipo"].Value = unidadNavalTipoDTO.CodigoUnidadNavalTipo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadNavalTipoDTO.UsuarioIngresoRegistro;

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

        public UnidadNavalTipoDTO BuscarUnidadNavalTipoID(int Codigo)
        {
            UnidadNavalTipoDTO unidadNavalTipoDTO = new UnidadNavalTipoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalTIpoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalTipoId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalTipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadNavalTipoDTO.UnidadNavalTipoId = Convert.ToInt32(dr["UnidadNavalTipoId"]);
                        unidadNavalTipoDTO.DescUnidadNavalTipo = dr["DescUnidadNavalTipo"].ToString();
                        unidadNavalTipoDTO.CodigoUnidadNavalTipo = dr["CodigoUnidadNavalTipo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadNavalTipoDTO;
        }

        public string ActualizarUnidadNavalTipo(UnidadNavalTipoDTO unidadNavalTipoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalTIpoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalTipoId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalTipoId"].Value = unidadNavalTipoDTO.UnidadNavalTipoId;

                    cmd.Parameters.Add("@DescUnidadNavalTipo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadNavalTipo"].Value = unidadNavalTipoDTO.DescUnidadNavalTipo;

                    cmd.Parameters.Add("@CodigoUnidadNavalTipo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUnidadNavalTipo"].Value = unidadNavalTipoDTO.CodigoUnidadNavalTipo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadNavalTipoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarUnidadNavalTipo(UnidadNavalTipoDTO unidadNavalTipoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalTIpoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalTipoId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalTipoId"].Value = unidadNavalTipoDTO.UnidadNavalTipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadNavalTipoDTO.UsuarioIngresoRegistro;

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
