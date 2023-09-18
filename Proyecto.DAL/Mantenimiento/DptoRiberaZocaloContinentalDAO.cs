using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DptoRiberaZocaloContinentalDAO
    {

        SqlCommand cmd = new();

        public List<DptoRiberaZocaloContinentalDTO> ObtenerDptoRiberaZocaloContinentals()
        {
            List<DptoRiberaZocaloContinentalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DptoRiberasZocalosContinentalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DptoRiberaZocaloContinentalDTO()
                        {
                            DptoRiberaZocaloContId = Convert.ToInt32(dr["DptoRiberaZocaloContId"]),
                            CodigoDptoRiberaZocaloCont = dr["CodigoDptoRiberaZocaloCont"].ToString(),
                            DescDptoRiberaZocaloCont = dr["DescDptoRiberaZocaloCont"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDptoRiberaZocaloContinental(DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoRiberasZocalosContinentalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDptoRiberaZocaloCont", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@CodigoDptoRiberaZocaloCont"].Value = dptoRiberaZocaloContinentalDTO.CodigoDptoRiberaZocaloCont;

                    cmd.Parameters.Add("@DescDptoRiberaZocaloCont", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescDptoRiberaZocaloCont"].Value = dptoRiberaZocaloContinentalDTO.DescDptoRiberaZocaloCont;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dptoRiberaZocaloContinentalDTO.UsuarioIngresoRegistro;

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

        public DptoRiberaZocaloContinentalDTO BuscarDptoRiberaZocaloContinentalID(int Codigo)
        {
            DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO = new DptoRiberaZocaloContinentalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoRiberasZocalosContinentalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoRiberaZocaloContId", SqlDbType.Int);
                    cmd.Parameters["@DptoRiberaZocaloContId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        dptoRiberaZocaloContinentalDTO.DptoRiberaZocaloContId = Convert.ToInt32(dr["DptoRiberaZocaloContId"]);
                        dptoRiberaZocaloContinentalDTO.CodigoDptoRiberaZocaloCont = dr["CodigoDptoRiberaZocaloCont"].ToString();
                        dptoRiberaZocaloContinentalDTO.DescDptoRiberaZocaloCont = dr["DescDptoRiberaZocaloCont"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return dptoRiberaZocaloContinentalDTO;
        }

        public string ActualizarDptoRiberaZocaloContinental(DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_DptoRiberasZocalosContinentalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoRiberaZocaloContId", SqlDbType.Int);
                    cmd.Parameters["@DptoRiberaZocaloContId"].Value = dptoRiberaZocaloContinentalDTO.DptoRiberaZocaloContId;

                    cmd.Parameters.Add("@CodigoDptoRiberaZocaloCont", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoDptoRiberaZocaloCont"].Value = dptoRiberaZocaloContinentalDTO.CodigoDptoRiberaZocaloCont;

                    cmd.Parameters.Add("@DescDptoRiberaZocaloCont", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DescDptoRiberaZocaloCont"].Value = dptoRiberaZocaloContinentalDTO.DescDptoRiberaZocaloCont;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dptoRiberaZocaloContinentalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarDptoRiberaZocaloContinental(DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoRiberasZocalosContinentalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoRiberaZocaloContId", SqlDbType.Int);
                    cmd.Parameters["@DptoRiberaZocaloContId"].Value = dptoRiberaZocaloContinentalDTO.DptoRiberaZocaloContId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = dptoRiberaZocaloContinentalDTO.UsuarioIngresoRegistro;

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
