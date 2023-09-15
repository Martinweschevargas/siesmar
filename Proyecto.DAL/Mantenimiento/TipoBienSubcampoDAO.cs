using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoBienSubcampoDAO
    {

        SqlCommand cmd = new();

        public List<TipoBienSubcampoDTO> ObtenerTipoBienSubcampos()
        {
            List<TipoBienSubcampoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoBienSubcampoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoBienSubcampoDTO()
                        {
                            TipoBienSubcampoId = Convert.ToInt32(dr["TipoBienSubcampoId"]),
                            DescTipoBienSubcampo = dr["DescTipoBienSubcampo"].ToString(),
                            CodigoTipoBienSubcampo = dr["CodigoTipoBienSubcampo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoBienSubcampo(TipoBienSubcampoDTO tipoBienSubcampoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienSubcampoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoBienSubcampo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoBienSubcampo"].Value = tipoBienSubcampoDTO.DescTipoBienSubcampo;

                    cmd.Parameters.Add("@CodigoTipoBienSubcampo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoBienSubcampo"].Value = tipoBienSubcampoDTO.CodigoTipoBienSubcampo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBienSubcampoDTO.UsuarioIngresoRegistro;

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

        public TipoBienSubcampoDTO BuscarTipoBienSubcampoID(int Codigo)
        {
            TipoBienSubcampoDTO tipoBienSubcampoDTO = new TipoBienSubcampoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienSubcampoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBienSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienSubcampoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoBienSubcampoDTO.TipoBienSubcampoId = Convert.ToInt32(dr["TipoBienSubcampoId"]);
                        tipoBienSubcampoDTO.DescTipoBienSubcampo = dr["DescTipoBienSubcampo"].ToString();
                        tipoBienSubcampoDTO.CodigoTipoBienSubcampo = dr["CodigoTipoBienSubcampo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoBienSubcampoDTO;
        }

        public string ActualizarTipoBienSubcampo(TipoBienSubcampoDTO tipoBienSubcampoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienSubcampoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBienSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienSubcampoId"].Value = tipoBienSubcampoDTO.TipoBienSubcampoId;

                    cmd.Parameters.Add("@DescTipoBienSubcampo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoBienSubcampo"].Value = tipoBienSubcampoDTO.DescTipoBienSubcampo;

                    cmd.Parameters.Add("@CodigoTipoBienSubcampo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoBienSubcampo"].Value = tipoBienSubcampoDTO.CodigoTipoBienSubcampo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBienSubcampoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoBienSubcampo(TipoBienSubcampoDTO tipoBienSubcampoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienSubcampoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBienSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienSubcampoId"].Value = tipoBienSubcampoDTO.TipoBienSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBienSubcampoDTO.UsuarioIngresoRegistro;

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
