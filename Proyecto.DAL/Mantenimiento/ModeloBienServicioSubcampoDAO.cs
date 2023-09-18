using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModeloBienServicioSubcampoDAO
    {

        SqlCommand cmd = new();

        public List<ModeloBienServicioSubcampoDTO> ObtenerModeloBienServicioSubcampos()
        {
            List<ModeloBienServicioSubcampoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioSubcampoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModeloBienServicioSubcampoDTO()
                        {
                            ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            CodigoModeloBienServicioSubcampo = dr["CodigoModeloBienServicioSubcampo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModeloBienServicioSubcampo(ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioSubcampoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModeloBienServicioSubcampo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescModeloBienServicioSubcampo"].Value = modeloBienServicioSubcampoDTO.DescModeloBienServicioSubcampo;

                    cmd.Parameters.Add("@CodigoModeloBienServicioSubcampo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoModeloBienServicioSubcampo"].Value = modeloBienServicioSubcampoDTO.CodigoModeloBienServicioSubcampo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloBienServicioSubcampoDTO.UsuarioIngresoRegistro;

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

        public ModeloBienServicioSubcampoDTO BuscarModeloBienServicioSubcampoID(int Codigo)
        {
            ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO = new ModeloBienServicioSubcampoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioSubcampoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modeloBienServicioSubcampoDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        modeloBienServicioSubcampoDTO.DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString();
                        modeloBienServicioSubcampoDTO.CodigoModeloBienServicioSubcampo = dr["CodigoModeloBienServicioSubcampo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modeloBienServicioSubcampoDTO;
        }

        public string ActualizarModeloBienServicioSubcampo(ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioSubcampoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = modeloBienServicioSubcampoDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@DescModeloBienServicioSubcampo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModeloBienServicioSubcampo"].Value = modeloBienServicioSubcampoDTO.DescModeloBienServicioSubcampo;

                    cmd.Parameters.Add("@CodigoModeloBienServicioSubcampo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModeloBienServicioSubcampo"].Value = modeloBienServicioSubcampoDTO.CodigoModeloBienServicioSubcampo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloBienServicioSubcampoDTO.UsuarioIngresoRegistro;

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

        public string EliminarModeloBienServicioSubcampo(ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioSubcampoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = modeloBienServicioSubcampoDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloBienServicioSubcampoDTO.UsuarioIngresoRegistro;

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
