using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModeloEquipoSatelitalDAO
    {

        SqlCommand cmd = new();

        public List<ModeloEquipoSatelitalDTO> ObtenerModeloEquipoSatelitals()
        {
            List<ModeloEquipoSatelitalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModeloEquipoSatelitalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModeloEquipoSatelitalDTO()
                        {
                            ModeloEquipoSatelitalId = Convert.ToInt32(dr["ModeloEquipoSatelitalId"]),
                            DescModeloEquipoSatelital = dr["DescModeloEquipoSatelital"].ToString(),
                            CodigoModeloEquipoSatelital = dr["CodigoModeloEquipoSatelital"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModeloEquipoSatelital(ModeloEquipoSatelitalDTO modeloEquipoSatelitalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquipoSatelitalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModeloEquipoSatelital", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescModeloEquipoSatelital"].Value = modeloEquipoSatelitalDTO.DescModeloEquipoSatelital;

                    cmd.Parameters.Add("@CodigoModeloEquipoSatelital", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoModeloEquipoSatelital"].Value = modeloEquipoSatelitalDTO.CodigoModeloEquipoSatelital;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloEquipoSatelitalDTO.UsuarioIngresoRegistro;

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

        public ModeloEquipoSatelitalDTO BuscarModeloEquipoSatelitalID(int Codigo)
        {
            ModeloEquipoSatelitalDTO modeloEquipoSatelitalDTO = new ModeloEquipoSatelitalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquipoSatelitalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoSatelitalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modeloEquipoSatelitalDTO.ModeloEquipoSatelitalId = Convert.ToInt32(dr["ModeloEquipoSatelitalId"]);
                        modeloEquipoSatelitalDTO.DescModeloEquipoSatelital = dr["DescModeloEquipoSatelital"].ToString();
                        modeloEquipoSatelitalDTO.CodigoModeloEquipoSatelital = dr["CodigoModeloEquipoSatelital"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modeloEquipoSatelitalDTO;
        }

        public string ActualizarModeloEquipoSatelital(ModeloEquipoSatelitalDTO modeloEquipoSatelitalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquipoSatelitalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoSatelitalId"].Value = modeloEquipoSatelitalDTO.ModeloEquipoSatelitalId;

                    cmd.Parameters.Add("@DescModeloEquipoSatelital", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModeloEquipoSatelital"].Value = modeloEquipoSatelitalDTO.DescModeloEquipoSatelital;

                    cmd.Parameters.Add("@CodigoModeloEquipoSatelital", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModeloEquipoSatelital"].Value = modeloEquipoSatelitalDTO.CodigoModeloEquipoSatelital;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloEquipoSatelitalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarModeloEquipoSatelital(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquipoSatelitalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoSatelitalId"].Value = Codigo;
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
