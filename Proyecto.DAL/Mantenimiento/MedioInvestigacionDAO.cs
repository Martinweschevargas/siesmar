using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MedioInvestigacionDAO
    {

        SqlCommand cmd = new();

        public List<MedioInvestigacionDTO> ObtenerMedioInvestigacions()
        {
            List<MedioInvestigacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MedioInvestigacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MedioInvestigacionDTO()
                        {
                            MedioInvestigacionId = Convert.ToInt32(dr["MedioInvestigacionId"]),
                            DescMedioInvestigacion = dr["DescMedioInvestigacion"].ToString(),
                            CodigoMedioInvestigacion = dr["CodigoMedioInvestigacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMedioInvestigacion(MedioInvestigacionDTO medioInvestigacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioInvestigacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMedioInvestigacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMedioInvestigacion"].Value = medioInvestigacionDTO.DescMedioInvestigacion;

                    cmd.Parameters.Add("@CodigoMedioInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMedioInvestigacion"].Value = medioInvestigacionDTO.CodigoMedioInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = medioInvestigacionDTO.UsuarioIngresoRegistro;

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

        public MedioInvestigacionDTO BuscarMedioInvestigacionID(int Codigo)
        {
            MedioInvestigacionDTO medioInvestigacionDTO = new MedioInvestigacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioInvestigacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@MedioInvestigacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        medioInvestigacionDTO.MedioInvestigacionId = Convert.ToInt32(dr["MedioInvestigacionId"]);
                        medioInvestigacionDTO.DescMedioInvestigacion = dr["DescMedioInvestigacion"].ToString();
                        medioInvestigacionDTO.CodigoMedioInvestigacion = dr["CodigoMedioInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return medioInvestigacionDTO;
        }

        public string ActualizarMedioInvestigacion(MedioInvestigacionDTO medioInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioInvestigacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@MedioInvestigacionId"].Value = medioInvestigacionDTO.MedioInvestigacionId;

                    cmd.Parameters.Add("@DescMedioInvestigacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMedioInvestigacion"].Value = medioInvestigacionDTO.DescMedioInvestigacion;

                    cmd.Parameters.Add("@CodigoMedioInvestigacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMedioInvestigacion"].Value = medioInvestigacionDTO.CodigoMedioInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = medioInvestigacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarMedioInvestigacion(MedioInvestigacionDTO medioInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioInvestigacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@MedioInvestigacionId"].Value = medioInvestigacionDTO.MedioInvestigacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = medioInvestigacionDTO.UsuarioIngresoRegistro;

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
