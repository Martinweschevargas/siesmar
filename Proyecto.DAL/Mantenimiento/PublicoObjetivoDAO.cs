using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PublicoObjetivoDAO
    {

        SqlCommand cmd = new();

        public List<PublicoObjetivoDTO> ObtenerPublicoObjetivos()
        {
            List<PublicoObjetivoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PublicoObjetivoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PublicoObjetivoDTO()
                        {
                            PublicoObjetivoId = Convert.ToInt32(dr["PublicoObjetivoId"]),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPublicoObjetivo(PublicoObjetivoDTO publicoObjetivoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicoObjetivoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPublicoObjetivo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPublicoObjetivo"].Value = publicoObjetivoDTO.DescPublicoObjetivo;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPublicoObjetivo"].Value = publicoObjetivoDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicoObjetivoDTO.UsuarioIngresoRegistro;

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

        public PublicoObjetivoDTO BuscarPublicoObjetivoID(int Codigo)
        {
            PublicoObjetivoDTO publicoObjetivoDTO = new PublicoObjetivoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicoObjetivoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicoObjetivoId", SqlDbType.Int);
                    cmd.Parameters["@PublicoObjetivoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        publicoObjetivoDTO.PublicoObjetivoId = Convert.ToInt32(dr["PublicoObjetivoId"]);
                        publicoObjetivoDTO.DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString();
                        publicoObjetivoDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return publicoObjetivoDTO;
        }

        public string ActualizarPublicoObjetivo(PublicoObjetivoDTO publicoObjetivoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PublicoObjetivoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicoObjetivoId", SqlDbType.Int);
                    cmd.Parameters["@PublicoObjetivoId"].Value = publicoObjetivoDTO.PublicoObjetivoId;

                    cmd.Parameters.Add("@DescPublicoObjetivo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPublicoObjetivo"].Value = publicoObjetivoDTO.DescPublicoObjetivo;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPublicoObjetivo"].Value = publicoObjetivoDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicoObjetivoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPublicoObjetivo(PublicoObjetivoDTO publicoObjetivoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicoObjetivoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicoObjetivoId", SqlDbType.Int);
                    cmd.Parameters["@PublicoObjetivoId"].Value = publicoObjetivoDTO.PublicoObjetivoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicoObjetivoDTO.UsuarioIngresoRegistro;

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
