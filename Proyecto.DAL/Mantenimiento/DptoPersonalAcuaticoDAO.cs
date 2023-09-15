using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DptoPersonalAcuaticoDAO
    {

        SqlCommand cmd = new();

        public List<DptoPersonalAcuaticoDTO> ObtenerDptoPersonalAcuaticos()
        {
            List<DptoPersonalAcuaticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DptoPersonalAcuaticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DptoPersonalAcuaticoDTO()
                        {
                            DptoPersonalAcuaticoId = Convert.ToInt32(dr["DptoPersonalAcuaticoId"]),
                            Codigo = dr["Codigo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDptoPersonalAcuatico(DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoPersonalAcuaticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@Codigo"].Value = dptoPersonalAcuaticoDTO.Codigo;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Descripcion"].Value = dptoPersonalAcuaticoDTO.Descripcion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dptoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

        public DptoPersonalAcuaticoDTO BuscarDptoPersonalAcuaticoID(int Codigo)
        {
            DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO = new DptoPersonalAcuaticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoPersonalAcuaticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@DptoPersonalAcuaticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        dptoPersonalAcuaticoDTO.DptoPersonalAcuaticoId = Convert.ToInt32(dr["DptoPersonalAcuaticoId"]);
                        dptoPersonalAcuaticoDTO.Codigo = dr["Codigo"].ToString();
                        dptoPersonalAcuaticoDTO.Descripcion = dr["Descripcion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return dptoPersonalAcuaticoDTO;
        }

        public string ActualizarDptoPersonalAcuatico(DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_DptoPersonalAcuaticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@DptoPersonalAcuaticoId"].Value = dptoPersonalAcuaticoDTO.DptoPersonalAcuaticoId;

                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Codigo"].Value = dptoPersonalAcuaticoDTO.Codigo;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Descripcion"].Value = dptoPersonalAcuaticoDTO.Descripcion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dptoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarDptoPersonalAcuatico(DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoPersonalAcuaticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@DptoPersonalAcuaticoId"].Value = dptoPersonalAcuaticoDTO.DptoPersonalAcuaticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dptoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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
