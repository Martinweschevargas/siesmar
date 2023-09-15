using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPersonalAcuaticoDAO
    {

        SqlCommand cmd = new();

        public List<TipoPersonalAcuaticoDTO> ObtenerTipoPersonalAcuaticos()
        {
            List<TipoPersonalAcuaticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalAcuaticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPersonalAcuaticoDTO()
                        {
                            TipoPersonalAcuaticoId = Convert.ToInt32(dr["TipoPersonalAcuaticoId"]),
                            DescTipoPersonalAcuatico = dr["DescTipoPersonalAcuatico"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPersonalAcuatico(TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalAcuaticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPersonalAcuatico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoPersonalAcuatico"].Value = tipoPersonalAcuaticoDTO.DescTipoPersonalAcuatico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

        public TipoPersonalAcuaticoDTO BuscarTipoPersonalAcuaticoID(int Codigo)
        {
            TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO = new TipoPersonalAcuaticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalAcuaticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalAcuaticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoPersonalAcuaticoDTO.TipoPersonalAcuaticoId = Convert.ToInt32(dr["TipoPersonalAcuaticoId"]);
                        tipoPersonalAcuaticoDTO.DescTipoPersonalAcuatico = dr["DescTipoPersonalAcuatico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPersonalAcuaticoDTO;
        }

        public string ActualizarTipoPersonalAcuatico(TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalAcuaticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalAcuaticoId"].Value = tipoPersonalAcuaticoDTO.TipoPersonalAcuaticoId;

                    cmd.Parameters.Add("@DescTipoPersonalAcuatico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoPersonalAcuatico"].Value = tipoPersonalAcuaticoDTO.DescTipoPersonalAcuatico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPersonalAcuatico(TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalAcuaticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalAcuaticoId"].Value = tipoPersonalAcuaticoDTO.TipoPersonalAcuaticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPersonalAcuaticoDTO.UsuarioIngresoRegistro;

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

    }
}
