using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TramiteGestionPatrimonialDAO
    {

        SqlCommand cmd = new();

        public List<TramiteGestionPatrimonialDTO> ObtenerTramiteGestionPatrimonials()
        {
            List<TramiteGestionPatrimonialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TramiteGestionPatrimonialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TramiteGestionPatrimonialDTO()
                        {
                            TramiteGestionPatrimonialId = Convert.ToInt32(dr["TramiteGestionPatrimonialId"]),
                            DescTramiteGestionPatrimonial = dr["DescTramiteGestionPatrimonial"].ToString(),
                            CodigoTramiteGestionPatrimonial = dr["CodigoTramiteGestionPatrimonial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTramiteGestionPatrimonial(TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TramiteGestionPatrimonialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTramiteGestionPatrimonial", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTramiteGestionPatrimonial"].Value = tramiteGestionPatrimonialDTO.DescTramiteGestionPatrimonial;

                    cmd.Parameters.Add("@CodigoTramiteGestionPatrimonial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTramiteGestionPatrimonial"].Value = tramiteGestionPatrimonialDTO.CodigoTramiteGestionPatrimonial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tramiteGestionPatrimonialDTO.UsuarioIngresoRegistro;

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

        public TramiteGestionPatrimonialDTO BuscarTramiteGestionPatrimonialID(int Codigo)
        {
            TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO = new TramiteGestionPatrimonialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TramiteGestionPatrimonialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TramiteGestionPatrimonialId", SqlDbType.Int);
                    cmd.Parameters["@TramiteGestionPatrimonialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tramiteGestionPatrimonialDTO.TramiteGestionPatrimonialId = Convert.ToInt32(dr["TramiteGestionPatrimonialId"]);
                        tramiteGestionPatrimonialDTO.DescTramiteGestionPatrimonial = dr["DescTramiteGestionPatrimonial"].ToString();
                        tramiteGestionPatrimonialDTO.CodigoTramiteGestionPatrimonial = dr["CodigoTramiteGestionPatrimonial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tramiteGestionPatrimonialDTO;
        }

        public string ActualizarTramiteGestionPatrimonial(TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TramiteGestionPatrimonialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TramiteGestionPatrimonialId", SqlDbType.Int);
                    cmd.Parameters["@TramiteGestionPatrimonialId"].Value = tramiteGestionPatrimonialDTO.TramiteGestionPatrimonialId;

                    cmd.Parameters.Add("@DescTramiteGestionPatrimonial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTramiteGestionPatrimonial"].Value = tramiteGestionPatrimonialDTO.DescTramiteGestionPatrimonial;

                    cmd.Parameters.Add("@CodigoTramiteGestionPatrimonial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTramiteGestionPatrimonial"].Value = tramiteGestionPatrimonialDTO.CodigoTramiteGestionPatrimonial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tramiteGestionPatrimonialDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTramiteGestionPatrimonial(TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TramiteGestionPatrimonialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TramiteGestionPatrimonialId", SqlDbType.Int);
                    cmd.Parameters["@TramiteGestionPatrimonialId"].Value = tramiteGestionPatrimonialDTO.TramiteGestionPatrimonialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tramiteGestionPatrimonialDTO.UsuarioIngresoRegistro;

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
