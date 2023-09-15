using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoSituacionBienDAO
    {

        SqlCommand cmd = new();

        public List<TipoSituacionBienDTO> ObtenerTipoSituacionBiens()
        {
            List<TipoSituacionBienDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionBienesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoSituacionBienDTO()
                        {
                            TipoSituacionBienId = Convert.ToInt32(dr["TipoSituacionBienId"]),
                            DescTipoSituacionBien = dr["DescTipoSituacionBien"].ToString(),
                            CodigoTipoSituacionBien = dr["CodigoTipoSituacionBien"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoSituacionBien(TipoSituacionBienDTO tipoSituacionBienDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionBienesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoSituacionBien", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoSituacionBien"].Value = tipoSituacionBienDTO.DescTipoSituacionBien;

                    cmd.Parameters.Add("@CodigoTipoSituacionBien", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoSituacionBien"].Value = tipoSituacionBienDTO.CodigoTipoSituacionBien;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSituacionBienDTO.UsuarioIngresoRegistro;

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

        public TipoSituacionBienDTO BuscarTipoSituacionBienID(int Codigo)
        {
            TipoSituacionBienDTO tipoSituacionBienDTO = new TipoSituacionBienDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionBienesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSituacionBienId", SqlDbType.Int);
                    cmd.Parameters["@TipoSituacionBienId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoSituacionBienDTO.TipoSituacionBienId = Convert.ToInt32(dr["TipoSituacionBienId"]);
                        tipoSituacionBienDTO.DescTipoSituacionBien = dr["DescTipoSituacionBien"].ToString();
                        tipoSituacionBienDTO.CodigoTipoSituacionBien = dr["CodigoTipoSituacionBien"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoSituacionBienDTO;
        }

        public string ActualizarTipoSituacionBien(TipoSituacionBienDTO tipoSituacionBienDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionBienesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSituacionBienId", SqlDbType.Int);
                    cmd.Parameters["@TipoSituacionBienId"].Value = tipoSituacionBienDTO.TipoSituacionBienId;

                    cmd.Parameters.Add("@DescTipoSituacionBien", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoSituacionBien"].Value = tipoSituacionBienDTO.DescTipoSituacionBien;

                    cmd.Parameters.Add("@CodigoTipoSituacionBien", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoSituacionBien"].Value = tipoSituacionBienDTO.CodigoTipoSituacionBien;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSituacionBienDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoSituacionBien(TipoSituacionBienDTO tipoSituacionBienDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionBienesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSituacionBienId", SqlDbType.Int);
                    cmd.Parameters["@TipoSituacionBienId"].Value = tipoSituacionBienDTO.TipoSituacionBienId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSituacionBienDTO.UsuarioIngresoRegistro;

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
