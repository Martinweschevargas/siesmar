using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AmenazaSeguridadNacionalDAO
    {

        SqlCommand cmd = new();

        public List<AmenazaSeguridadNacionalDTO> ObtenerAmenazaSeguridadNacionals()
        {
            List<AmenazaSeguridadNacionalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AmenazaSeguridadNacionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AmenazaSeguridadNacionalDTO()
                        {
                            AmenazaSeguridadNacionalId = Convert.ToInt32(dr["AmenazaSeguridadNacionalId"]),
                            DescAmenazaSeguridadNacional = dr["DescAmenazaSeguridadNacional"].ToString(),
                            CodigoAmenazaSeguridadNacional = dr["CodigoAmenazaSeguridadNacional"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmenazaSeguridadNacionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAmenazaSeguridadNacional", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescAmenazaSeguridadNacional"].Value = AmenazaSeguridadNacionalDTO.DescAmenazaSeguridadNacional;
                   
                    cmd.Parameters.Add("@CodigoAmenazaSeguridadNacional", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoAmenazaSeguridadNacional"].Value = AmenazaSeguridadNacionalDTO.CodigoAmenazaSeguridadNacional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AmenazaSeguridadNacionalDTO.UsuarioIngresoRegistro;

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

        public AmenazaSeguridadNacionalDTO BuscarAmenazaSeguridadNacionalID(int Codigo)
        {
            AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO = new AmenazaSeguridadNacionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmenazaSeguridadNacionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AmenazaSeguridadNacionalId", SqlDbType.Int);
                    cmd.Parameters["@AmenazaSeguridadNacionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AmenazaSeguridadNacionalDTO.AmenazaSeguridadNacionalId = Convert.ToInt32(dr["AmenazaSeguridadNacionalId"]);
                        AmenazaSeguridadNacionalDTO.DescAmenazaSeguridadNacional = dr["DescAmenazaSeguridadNacional"].ToString();
                        AmenazaSeguridadNacionalDTO.CodigoAmenazaSeguridadNacional = dr["CodigoAmenazaSeguridadNacional"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AmenazaSeguridadNacionalDTO;
        }

        public string ActualizarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmenazaSeguridadNacionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AmenazaSeguridadNacionalId", SqlDbType.Int);
                    cmd.Parameters["@AmenazaSeguridadNacionalId"].Value = AmenazaSeguridadNacionalDTO.AmenazaSeguridadNacionalId;

                    cmd.Parameters.Add("@DescAmenazaSeguridadNacional", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescAmenazaSeguridadNacional"].Value = AmenazaSeguridadNacionalDTO.DescAmenazaSeguridadNacional;

                    cmd.Parameters.Add("@CodigoAmenazaSeguridadNacional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAmenazaSeguridadNacional"].Value = AmenazaSeguridadNacionalDTO.CodigoAmenazaSeguridadNacional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AmenazaSeguridadNacionalDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmenazaSeguridadNacionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AmenazaSeguridadNacionalId", SqlDbType.Int);
                    cmd.Parameters["@AmenazaSeguridadNacionalId"].Value = AmenazaSeguridadNacionalDTO.AmenazaSeguridadNacionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AmenazaSeguridadNacionalDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

    }
}
