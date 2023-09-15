using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoLubricanteDAO
    {

        SqlCommand cmd = new();

        public List<TipoLubricanteDTO> ObtenerTipoLubricantes()
        {
            List<TipoLubricanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoLubricanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoLubricanteDTO()
                        {
                            TipoLubricanteId = Convert.ToInt32(dr["TipoLubricanteId"]),
                            DescTipoLubricante = dr["DescTipoLubricante"].ToString(),
                            CodigoTipoLubricante = dr["CodigoTipoLubricante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoLubricante(TipoLubricanteDTO tipoLubricanteDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoLubricanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoLubricante", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoLubricante"].Value = tipoLubricanteDTO.DescTipoLubricante;

                    cmd.Parameters.Add("@CodigoTipoLubricante", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoLubricante"].Value = tipoLubricanteDTO.CodigoTipoLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoLubricanteDTO.UsuarioIngresoRegistro;

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

        public TipoLubricanteDTO BuscarTipoLubricanteID(int Codigo)
        {
            TipoLubricanteDTO tipoLubricanteDTO = new TipoLubricanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoLubricanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@TipoLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoLubricanteDTO.TipoLubricanteId = Convert.ToInt32(dr["TipoLubricanteId"]);
                        tipoLubricanteDTO.DescTipoLubricante = dr["DescTipoLubricante"].ToString();
                        tipoLubricanteDTO.CodigoTipoLubricante = dr["CodigoTipoLubricante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoLubricanteDTO;
        }

        public string ActualizarTipoLubricante(TipoLubricanteDTO tipoLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoLubricanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@TipoLubricanteId"].Value = tipoLubricanteDTO.TipoLubricanteId;

                    cmd.Parameters.Add("@DescTipoLubricante", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoLubricante"].Value = tipoLubricanteDTO.DescTipoLubricante;

                    cmd.Parameters.Add("@CodigoTipoLubricante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoLubricante"].Value = tipoLubricanteDTO.CodigoTipoLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoLubricanteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoLubricante(TipoLubricanteDTO tipoLubricanteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoLubricanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@TipoLubricanteId"].Value = tipoLubricanteDTO.TipoLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoLubricanteDTO.UsuarioIngresoRegistro;

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
