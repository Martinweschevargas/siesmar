using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GradoPersonalDAO
    {

        SqlCommand cmd = new();

        public List<GradoPersonalDTO> ObtenerGradoPersonals()
        {
            List<GradoPersonalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GradoPersonalDTO()
                        {
                            GradoPersonalId = Convert.ToInt32(dr["GradoPersonalId"]),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString(),
                            CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGradoPersonal(GradoPersonalDTO gradoPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGradoPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGradoPersonal"].Value = gradoPersonalDTO.DescGradoPersonal;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = gradoPersonalDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = gradoPersonalDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoPersonalDTO.UsuarioIngresoRegistro;

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

        public GradoPersonalDTO BuscarGradoPersonalID(int Codigo)
        {
            GradoPersonalDTO gradoPersonalDTO = new GradoPersonalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = Codigo;


                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        gradoPersonalDTO.GradoPersonalId = Convert.ToInt32(dr["GradoPersonalId"]);
                        gradoPersonalDTO.DescGradoPersonal = dr["DescGradoPersonal"].ToString();
                        gradoPersonalDTO.CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString();
                        gradoPersonalDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return gradoPersonalDTO;
        }

        public string ActualizarGradoPersonal(GradoPersonalDTO gradoPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = gradoPersonalDTO.GradoPersonalId;

                    cmd.Parameters.Add("@DescGradoPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGradoPersonal"].Value = gradoPersonalDTO.DescGradoPersonal;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = gradoPersonalDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = gradoPersonalDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoPersonalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarGradoPersonal(GradoPersonalDTO gradoPersonalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = gradoPersonalDTO.GradoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoPersonalDTO.UsuarioIngresoRegistro;

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
