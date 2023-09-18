using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoAcuerdoDAO
    {

        SqlCommand cmd = new();

        public List<TipoAcuerdoDTO> ObtenerTipoAcuerdos()
        {
            List<TipoAcuerdoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoAcuerdoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoAcuerdoDTO()
                        {
                            TipoAcuerdoId = Convert.ToInt32(dr["TipoAcuerdoId"]),
                            DescTipoAcuerdo = dr["DescTipoAcuerdo"].ToString(),
                            CodigoTipoAcuerdo = dr["CodigoTipoAcuerdo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoAcuerdo(TipoAcuerdoDTO tipoAcuerdoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAcuerdoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoAcuerdo", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoAcuerdo"].Value = tipoAcuerdoDTO.DescTipoAcuerdo;

                    cmd.Parameters.Add("@CodigoTipoAcuerdo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAcuerdo"].Value = tipoAcuerdoDTO.CodigoTipoAcuerdo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAcuerdoDTO.UsuarioIngresoRegistro;

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

        public TipoAcuerdoDTO BuscarTipoAcuerdoID(int Codigo)
        {
            TipoAcuerdoDTO tipoAcuerdoDTO = new TipoAcuerdoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAcuerdoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAcuerdoId", SqlDbType.Int);
                    cmd.Parameters["@TipoAcuerdoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoAcuerdoDTO.TipoAcuerdoId = Convert.ToInt32(dr["TipoAcuerdoId"]);
                        tipoAcuerdoDTO.DescTipoAcuerdo = dr["DescTipoAcuerdo"].ToString();
                        tipoAcuerdoDTO.CodigoTipoAcuerdo = dr["CodigoTipoAcuerdo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoAcuerdoDTO;
        }

        public string ActualizarTipoAcuerdo(TipoAcuerdoDTO tipoAcuerdoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAcuerdoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAcuerdoId", SqlDbType.Int);
                    cmd.Parameters["@TipoAcuerdoId"].Value = tipoAcuerdoDTO.TipoAcuerdoId;

                    cmd.Parameters.Add("@DescTipoAcuerdo", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescTipoAcuerdo"].Value = tipoAcuerdoDTO.DescTipoAcuerdo;

                    cmd.Parameters.Add("@CodigoTipoAcuerdo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAcuerdo"].Value = tipoAcuerdoDTO.CodigoTipoAcuerdo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAcuerdoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoAcuerdo(TipoAcuerdoDTO tipoAcuerdoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAcuerdoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAcuerdoId", SqlDbType.Int);
                    cmd.Parameters["@TipoAcuerdoId"].Value = tipoAcuerdoDTO.TipoAcuerdoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAcuerdoDTO.UsuarioIngresoRegistro;

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
