using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MotivoViajeDAO
    {

        SqlCommand cmd = new();

        public List<MotivoViajeDTO> ObtenerMotivoViajes()
        {
            List<MotivoViajeDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MotivoViajeListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MotivoViajeDTO()
                        {
                            MotivoViajeId = Convert.ToInt32(dr["MotivoViajeId"]),
                            DescMotivoViaje = dr["DescMotivoViaje"].ToString(),
                            CodigoMotivoViaje = dr["CodigoMotivoViaje"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMotivoViaje(MotivoViajeDTO motivoViajeDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoViajeRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMotivoViaje", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMotivoViaje"].Value = motivoViajeDTO.DescMotivoViaje;

                    cmd.Parameters.Add("@CodigoMotivoViaje", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMotivoViaje"].Value = motivoViajeDTO.CodigoMotivoViaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoViajeDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public MotivoViajeDTO BuscarMotivoViajeID(int Codigo)
        {
            MotivoViajeDTO motivoViajeDTO = new MotivoViajeDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoViajeEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoViajeId", SqlDbType.Int);
                    cmd.Parameters["@MotivoViajeId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        motivoViajeDTO.MotivoViajeId = Convert.ToInt32(dr["MotivoViajeId"]);
                        motivoViajeDTO.DescMotivoViaje = dr["DescMotivoViaje"].ToString();
                        motivoViajeDTO.CodigoMotivoViaje = dr["CodigoMotivoViaje"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return motivoViajeDTO;
        }

        public string ActualizarMotivoViaje(MotivoViajeDTO motivoViajeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MotivoViajeActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoViajeId", SqlDbType.Int);
                    cmd.Parameters["@MotivoViajeId"].Value = motivoViajeDTO.MotivoViajeId;

                    cmd.Parameters.Add("@DescMotivoViaje", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMotivoViaje"].Value = motivoViajeDTO.DescMotivoViaje;

                    cmd.Parameters.Add("@CodigoMotivoViaje", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMotivoViaje"].Value = motivoViajeDTO.CodigoMotivoViaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoViajeDTO.UsuarioIngresoRegistro;

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

        public bool EliminarMotivoViaje(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoViajeEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoViajeId", SqlDbType.Int);
                    cmd.Parameters["@MotivoViajeId"].Value = Codigo;
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
