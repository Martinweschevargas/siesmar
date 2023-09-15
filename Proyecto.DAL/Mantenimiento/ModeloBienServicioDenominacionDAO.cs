using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModeloBienServicioDenominacionDAO
    {

        SqlCommand cmd = new();

        public List<ModeloBienServicioDenominacionDTO> ObtenerModeloBienServicioDenominacions()
        {
            List<ModeloBienServicioDenominacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioDenominacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModeloBienServicioDenominacionDTO()
                        {
                            ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            CodigoModeloBienServicioDenominacion = dr["CodigoModeloBienServicioDenominacion"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModeloBienServicioDenominacion(ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioDenominacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModeloBienServicioDenominacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModeloBienServicioDenominacion"].Value = modeloBienServicioDenominacionDTO.DescModeloBienServicioDenominacion;

                    cmd.Parameters.Add("@CodigoModeloBienServicioDenominacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModeloBienServicioDenominacion"].Value = modeloBienServicioDenominacionDTO.CodigoModeloBienServicioDenominacion;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = modeloBienServicioDenominacionDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloBienServicioDenominacionDTO.UsuarioIngresoRegistro;

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

        public ModeloBienServicioDenominacionDTO BuscarModeloBienServicioDenominacionID(int Codigo)
        {
            ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO = new ModeloBienServicioDenominacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioDenominacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = Codigo;


                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modeloBienServicioDenominacionDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        modeloBienServicioDenominacionDTO.DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString();
                        modeloBienServicioDenominacionDTO.CodigoModeloBienServicioDenominacion = dr["CodigoModeloBienServicioDenominacion"].ToString();
                        modeloBienServicioDenominacionDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modeloBienServicioDenominacionDTO;
        }

        public string ActualizarModeloBienServicioDenominacion(ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioDenominacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = modeloBienServicioDenominacionDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@DescModeloBienServicioDenominacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModeloBienServicioDenominacion"].Value = modeloBienServicioDenominacionDTO.DescModeloBienServicioDenominacion;

                    cmd.Parameters.Add("@CodigoModeloBienServicioDenominacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModeloBienServicioDenominacion"].Value = modeloBienServicioDenominacionDTO.CodigoModeloBienServicioDenominacion;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = modeloBienServicioDenominacionDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloBienServicioDenominacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarModeloBienServicioDenominacion(ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloBienServicioDenominacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = modeloBienServicioDenominacionDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloBienServicioDenominacionDTO.UsuarioIngresoRegistro;

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