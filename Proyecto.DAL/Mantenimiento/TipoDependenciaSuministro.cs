using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoDependenciaSuministroDAO
    {

        SqlCommand cmd = new();

        public List<TipoDependenciaSuministroDTO> ObtenerTipoDependenciaSuministros()
        {
            List<TipoDependenciaSuministroDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoDependenciaSuministroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoDependenciaSuministroDTO()
                        {
                            TipoDependenciaSuministroId = Convert.ToInt32(dr["TipoDependenciaSuministroId"]),
                            DescTipoDependenciaSuministro = dr["DescTipoDependenciaSuministro"].ToString(),
                            CodigoTipoDependenciaSuministro = dr["CodigoTipoDependenciaSuministro"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoDependenciaSuministro(TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDependenciaSuministroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoDependenciaSuministro", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoDependenciaSuministro"].Value = tipoDependenciaSuministroDTO.DescTipoDependenciaSuministro;

                    cmd.Parameters.Add("@CodigoTipoDependenciaSuministro", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoDependenciaSuministro"].Value = tipoDependenciaSuministroDTO.CodigoTipoDependenciaSuministro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoDependenciaSuministroDTO.UsuarioIngresoRegistro;

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

        public TipoDependenciaSuministroDTO BuscarTipoDependenciaSuministroID(int Codigo)
        {
            TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO = new TipoDependenciaSuministroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDependenciaSuministroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDependenciaSuministroId", SqlDbType.Int);
                    cmd.Parameters["@TipoDependenciaSuministroId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoDependenciaSuministroDTO.TipoDependenciaSuministroId = Convert.ToInt32(dr["TipoDependenciaSuministroId"]);
                        tipoDependenciaSuministroDTO.DescTipoDependenciaSuministro = dr["DescTipoDependenciaSuministro"].ToString();
                        tipoDependenciaSuministroDTO.CodigoTipoDependenciaSuministro = dr["CodigoTipoDependenciaSuministro"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoDependenciaSuministroDTO;
        }

        public string ActualizarTipoDependenciaSuministro(TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoDependenciaSuministroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDependenciaSuministroId", SqlDbType.Int);
                    cmd.Parameters["@TipoDependenciaSuministroId"].Value = tipoDependenciaSuministroDTO.TipoDependenciaSuministroId;

                    cmd.Parameters.Add("@DescTipoDependenciaSuministro", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoDependenciaSuministro"].Value = tipoDependenciaSuministroDTO.DescTipoDependenciaSuministro;

                    cmd.Parameters.Add("@CodigoTipoDependenciaSuministro", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoDependenciaSuministro"].Value = tipoDependenciaSuministroDTO.CodigoTipoDependenciaSuministro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoDependenciaSuministroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoDependenciaSuministro(TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoDependenciaSuministroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDependenciaSuministroId", SqlDbType.Int);
                    cmd.Parameters["@TipoDependenciaSuministroId"].Value = tipoDependenciaSuministroDTO.TipoDependenciaSuministroId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoDependenciaSuministroDTO.UsuarioIngresoRegistro;

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
