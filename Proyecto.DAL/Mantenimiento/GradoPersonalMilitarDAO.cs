using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GradoPersonalMilitarDAO
    {

        SqlCommand cmd = new();

        public List<GradoPersonalMilitarDTO> ObtenerGradoPersonalMilitars()
        {
            List<GradoPersonalMilitarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalMilitarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new GradoPersonalMilitarDTO()
                        {
                            GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]),
                            DescGrado = dr["DescGrado"].ToString(),
                            Abreviatura = dr["Abreviatura"].ToString(),
                            CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString(),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGradoPersonalMilitar(GradoPersonalMilitarDTO gradoPersonalMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrado"].Value = gradoPersonalMilitarDTO.DescGrado;

                    cmd.Parameters.Add("@Abreviatura", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Abreviatura"].Value = gradoPersonalMilitarDTO.Abreviatura;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = gradoPersonalMilitarDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = gradoPersonalMilitarDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoPersonalMilitarDTO.UsuarioIngresoRegistro;

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

        public GradoPersonalMilitarDTO BuscarGradoPersonalMilitarID(int Codigo)
        {
            GradoPersonalMilitarDTO gradoPersonalMilitarDTO = new GradoPersonalMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        gradoPersonalMilitarDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        gradoPersonalMilitarDTO.DescGrado = dr["DescGrado"].ToString();
                        gradoPersonalMilitarDTO.Abreviatura = dr["Abreviatura"].ToString();
                        gradoPersonalMilitarDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        gradoPersonalMilitarDTO.CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return gradoPersonalMilitarDTO;
        }

        public string ActualizarGradoPersonalMilitar(GradoPersonalMilitarDTO gradoPersonalMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = gradoPersonalMilitarDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@DescGrado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrado"].Value = gradoPersonalMilitarDTO.DescGrado;

                    cmd.Parameters.Add("@Abreviatura", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Abreviatura"].Value = gradoPersonalMilitarDTO.Abreviatura;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = gradoPersonalMilitarDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = gradoPersonalMilitarDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoPersonalMilitarDTO.UsuarioIngresoRegistro;

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

        public string EliminarGradoPersonalMilitar(GradoPersonalMilitarDTO gradoPersonalMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoPersonalMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = gradoPersonalMilitarDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoPersonalMilitarDTO.UsuarioIngresoRegistro;

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
