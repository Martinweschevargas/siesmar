using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PublicidadEsnaDAO
    {

        SqlCommand cmd = new();

        public List<PublicidadEsnaDTO> ObtenerPublicidadEsnas()
        {
            List<PublicidadEsnaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PublicidadEsnaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PublicidadEsnaDTO()
                        {
                            PublicidadEsnaId = Convert.ToInt32(dr["PublicidadEsnaId"]),
                            DescPublicidadEsna = dr["DescPublicidadEsna"].ToString(),
                            CodigoPublicidadEsna = dr["CodigoPublicidadEsna"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPublicidadEsna(PublicidadEsnaDTO publicidadEsnaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicidadEsnaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPublicidadEsna", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPublicidadEsna"].Value = publicidadEsnaDTO.DescPublicidadEsna;

                    cmd.Parameters.Add("@CodigoPublicidadEsna", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPublicidadEsna"].Value = publicidadEsnaDTO.CodigoPublicidadEsna;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicidadEsnaDTO.UsuarioIngresoRegistro;

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

        public PublicidadEsnaDTO BuscarPublicidadEsnaID(int Codigo)
        {
            PublicidadEsnaDTO publicidadEsnaDTO = new PublicidadEsnaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicidadEsnaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicidadEsnaId", SqlDbType.Int);
                    cmd.Parameters["@PublicidadEsnaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        publicidadEsnaDTO.PublicidadEsnaId = Convert.ToInt32(dr["PublicidadEsnaId"]);
                        publicidadEsnaDTO.DescPublicidadEsna = dr["DescPublicidadEsna"].ToString();
                        publicidadEsnaDTO.CodigoPublicidadEsna = dr["CodigoPublicidadEsna"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return publicidadEsnaDTO;
        }

        public string ActualizarPublicidadEsna(PublicidadEsnaDTO publicidadEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicidadEsnaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicidadEsnaId", SqlDbType.Int);
                    cmd.Parameters["@PublicidadEsnaId"].Value = publicidadEsnaDTO.PublicidadEsnaId;

                    cmd.Parameters.Add("@DescPublicidadEsna", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPublicidadEsna"].Value = publicidadEsnaDTO.DescPublicidadEsna;

                    cmd.Parameters.Add("@CodigoPublicidadEsna", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPublicidadEsna"].Value = publicidadEsnaDTO.CodigoPublicidadEsna;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicidadEsnaDTO.UsuarioIngresoRegistro;

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

        public string EliminarPublicidadEsna(PublicidadEsnaDTO publicidadEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PublicidadEsnaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicidadEsnaId", SqlDbType.Int);
                    cmd.Parameters["@PublicidadEsnaId"].Value = publicidadEsnaDTO.PublicidadEsnaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicidadEsnaDTO.UsuarioIngresoRegistro;

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
