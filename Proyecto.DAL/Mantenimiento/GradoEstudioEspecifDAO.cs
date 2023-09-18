using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GradoEstudioEspecifDAO
    {

        SqlCommand cmd = new();

        public List<GradoEstudioEspecifDTO> ObtenerGradoEstudioEspecifs()
        {
            List<GradoEstudioEspecifDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioEspecifListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GradoEstudioEspecifDTO()
                        {
                            GradoEstudioEspecifId = Convert.ToInt32(dr["GradoEstudioEspecifId"]),
                            DescGradoEstudioEspecif = dr["DescGradoEstudioEspecif"].ToString(),
                            CodigoGradoEstudioEspecif = dr["CodigoGradoEstudioEspecif"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGradoEstudioEspecif(GradoEstudioEspecifDTO gradoEstudioEspecifDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioEspecifRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGradoEstudioEspecif", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGradoEstudioEspecif"].Value = gradoEstudioEspecifDTO.DescGradoEstudioEspecif;

                    cmd.Parameters.Add("@CodigoGradoEstudioEspecif", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGradoEstudioEspecif"].Value = gradoEstudioEspecifDTO.CodigoGradoEstudioEspecif;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoEstudioEspecifDTO.UsuarioIngresoRegistro;

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

        public GradoEstudioEspecifDTO BuscarGradoEstudioEspecifID(int Codigo)
        {
            GradoEstudioEspecifDTO gradoEstudioEspecifDTO = new GradoEstudioEspecifDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioEspecifEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        gradoEstudioEspecifDTO.GradoEstudioEspecifId = Convert.ToInt32(dr["GradoEstudioEspecifId"]);
                        gradoEstudioEspecifDTO.DescGradoEstudioEspecif = dr["DescGradoEstudioEspecif"].ToString();
                        gradoEstudioEspecifDTO.CodigoGradoEstudioEspecif = dr["CodigoGradoEstudioEspecif"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return gradoEstudioEspecifDTO;
        }

        public string ActualizarGradoEstudioEspecif(GradoEstudioEspecifDTO gradoEstudioEspecifDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioEspecifActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = gradoEstudioEspecifDTO.GradoEstudioEspecifId;

                    cmd.Parameters.Add("@DescGradoEstudioEspecif", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGradoEstudioEspecif"].Value = gradoEstudioEspecifDTO.DescGradoEstudioEspecif;

                    cmd.Parameters.Add("@CodigoGradoEstudioEspecif", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGradoEstudioEspecif"].Value = gradoEstudioEspecifDTO.CodigoGradoEstudioEspecif;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoEstudioEspecifDTO.UsuarioIngresoRegistro;

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

        public string EliminarGradoEstudioEspecif(GradoEstudioEspecifDTO gradoEstudioEspecifDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoEstudioEspecifEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = gradoEstudioEspecifDTO.GradoEstudioEspecifId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoEstudioEspecifDTO.UsuarioIngresoRegistro;

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
