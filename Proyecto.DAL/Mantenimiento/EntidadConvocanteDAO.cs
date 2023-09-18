using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EntidadConvocanteDAO
    {

        SqlCommand cmd = new();

        public List<EntidadConvocanteDTO> ObtenerEntidadConvocantes()
        {
            List<EntidadConvocanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EntidadConvocanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntidadConvocanteDTO()
                        {
                            EntidadConvocanteId = Convert.ToInt32(dr["EntidadConvocanteId"]),
                            DescEntidadConvocante = dr["DescEntidadConvocante"].ToString(),
                            CodigoEntidadConvocante = dr["CodigoEntidadConvocante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEntidadConvocante(EntidadConvocanteDTO entidadConvocanteDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadConvocanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEntidadConvocante", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescEntidadConvocante"].Value = entidadConvocanteDTO.DescEntidadConvocante;

                    cmd.Parameters.Add("@CodigoEntidadConvocante", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoEntidadConvocante"].Value = entidadConvocanteDTO.CodigoEntidadConvocante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadConvocanteDTO.UsuarioIngresoRegistro;

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

        public EntidadConvocanteDTO BuscarEntidadConvocanteID(int Codigo)
        {
            EntidadConvocanteDTO entidadConvocanteDTO = new EntidadConvocanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadConvocanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadConvocanteId", SqlDbType.Int);
                    cmd.Parameters["@EntidadConvocanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entidadConvocanteDTO.EntidadConvocanteId = Convert.ToInt32(dr["EntidadConvocanteId"]);
                        entidadConvocanteDTO.DescEntidadConvocante = dr["DescEntidadConvocante"].ToString();
                        entidadConvocanteDTO.CodigoEntidadConvocante = dr["CodigoEntidadConvocante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entidadConvocanteDTO;
        }

        public string ActualizarEntidadConvocante(EntidadConvocanteDTO entidadConvocanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EntidadConvocanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadConvocanteId", SqlDbType.Int);
                    cmd.Parameters["@EntidadConvocanteId"].Value = entidadConvocanteDTO.EntidadConvocanteId;

                    cmd.Parameters.Add("@DescEntidadConvocante", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEntidadConvocante"].Value = entidadConvocanteDTO.DescEntidadConvocante;

                    cmd.Parameters.Add("@CodigoEntidadConvocante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEntidadConvocante"].Value = entidadConvocanteDTO.CodigoEntidadConvocante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadConvocanteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarEntidadConvocante(EntidadConvocanteDTO entidadConvocanteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadConvocanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadConvocanteId", SqlDbType.Int);
                    cmd.Parameters["@EntidadConvocanteId"].Value = entidadConvocanteDTO.EntidadConvocanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadConvocanteDTO.UsuarioIngresoRegistro;

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
