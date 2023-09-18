using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TituloProfesionalObtenidoDAO
    {

        SqlCommand cmd = new();

        public List<TituloProfesionalObtenidoDTO> ObtenerTituloProfesionalObtenidos()
        {
            List<TituloProfesionalObtenidoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TituloProfesionalObtenidoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TituloProfesionalObtenidoDTO()
                        {
                            TituloProfesionalObtenidoId = Convert.ToInt32(dr["TituloProfesionalObtenidoId"]),
                            DescTituloProfesionalObtenido = dr["DescTituloProfesionalObtenido"].ToString(),
                            CodigoTituloProfesionalObtenido = dr["CodigoTituloProfesionalObtenido"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTituloProfesionalObtenido(TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TituloProfesionalObtenidoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTituloProfesionalObtenido", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTituloProfesionalObtenido"].Value = tituloProfesionalObtenidoDTO.DescTituloProfesionalObtenido;

                    cmd.Parameters.Add("@CodigoTituloProfesionalObtenido", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTituloProfesionalObtenido"].Value = tituloProfesionalObtenidoDTO.CodigoTituloProfesionalObtenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tituloProfesionalObtenidoDTO.UsuarioIngresoRegistro;

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

        public TituloProfesionalObtenidoDTO BuscarTituloProfesionalObtenidoID(int Codigo)
        {
            TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO = new TituloProfesionalObtenidoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TituloProfesionalObtenidoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TituloProfesionalObtenidoId", SqlDbType.Int);
                    cmd.Parameters["@TituloProfesionalObtenidoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tituloProfesionalObtenidoDTO.TituloProfesionalObtenidoId = Convert.ToInt32(dr["TituloProfesionalObtenidoId"]);
                        tituloProfesionalObtenidoDTO.DescTituloProfesionalObtenido = dr["DescTituloProfesionalObtenido"].ToString();
                        tituloProfesionalObtenidoDTO.CodigoTituloProfesionalObtenido = dr["CodigoTituloProfesionalObtenido"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tituloProfesionalObtenidoDTO;
        }

        public string ActualizarTituloProfesionalObtenido(TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TituloProfesionalObtenidoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TituloProfesionalObtenidoId", SqlDbType.Int);
                    cmd.Parameters["@TituloProfesionalObtenidoId"].Value = tituloProfesionalObtenidoDTO.TituloProfesionalObtenidoId;

                    cmd.Parameters.Add("@DescTituloProfesionalObtenido", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTituloProfesionalObtenido"].Value = tituloProfesionalObtenidoDTO.DescTituloProfesionalObtenido;

                    cmd.Parameters.Add("@CodigoTituloProfesionalObtenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTituloProfesionalObtenido"].Value = tituloProfesionalObtenidoDTO.CodigoTituloProfesionalObtenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tituloProfesionalObtenidoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTituloProfesionalObtenido(TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TituloProfesionalObtenidoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TituloProfesionalObtenidoId", SqlDbType.Int);
                    cmd.Parameters["@TituloProfesionalObtenidoId"].Value = tituloProfesionalObtenidoDTO.TituloProfesionalObtenidoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tituloProfesionalObtenidoDTO.UsuarioIngresoRegistro;

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
