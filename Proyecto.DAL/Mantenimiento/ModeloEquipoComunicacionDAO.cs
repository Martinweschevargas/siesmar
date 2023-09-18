using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModeloEquipoComunicacionDAO
    {

        SqlCommand cmd = new();

        public List<ModeloEquipoComunicacionDTO> ObtenerModeloEquipoComunicacions()
        {
            List<ModeloEquipoComunicacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModeloEquiposComunicacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModeloEquipoComunicacionDTO()
                        {
                            ModeloEquipoComunicacionId = Convert.ToInt32(dr["ModeloEquipoComunicacionId"]),
                            DescModeloEquipoComunicacion = dr["DescModeloEquipoComunicacion"].ToString(),
                            CodigoModeloEquipoComunicacion = dr["CodigoModeloEquipoComunicacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModeloEquipoComunicacion(ModeloEquipoComunicacionDTO modeloEquipoComunicacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquiposComunicacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModeloEquipoComunicacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescModeloEquipoComunicacion"].Value = modeloEquipoComunicacionDTO.DescModeloEquipoComunicacion;

                    cmd.Parameters.Add("@CodigoModeloEquipoComunicacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoModeloEquipoComunicacion"].Value = modeloEquipoComunicacionDTO.CodigoModeloEquipoComunicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloEquipoComunicacionDTO.UsuarioIngresoRegistro;

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

        public ModeloEquipoComunicacionDTO BuscarModeloEquipoComunicacionID(int Codigo)
        {
            ModeloEquipoComunicacionDTO modeloEquipoComunicacionDTO = new ModeloEquipoComunicacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquiposComunicacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoComunicacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modeloEquipoComunicacionDTO.ModeloEquipoComunicacionId = Convert.ToInt32(dr["ModeloEquipoComunicacionId"]);
                        modeloEquipoComunicacionDTO.DescModeloEquipoComunicacion = dr["DescModeloEquipoComunicacion"].ToString();
                        modeloEquipoComunicacionDTO.CodigoModeloEquipoComunicacion = dr["CodigoModeloEquipoComunicacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modeloEquipoComunicacionDTO;
        }

        public string ActualizarModeloEquipoComunicacion(ModeloEquipoComunicacionDTO modeloEquipoComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquiposComunicacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoComunicacionId"].Value = modeloEquipoComunicacionDTO.ModeloEquipoComunicacionId;

                    cmd.Parameters.Add("@DescModeloEquipoComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModeloEquipoComunicacion"].Value = modeloEquipoComunicacionDTO.DescModeloEquipoComunicacion;

                    cmd.Parameters.Add("@CodigoModeloEquipoComunicacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModeloEquipoComunicacion"].Value = modeloEquipoComunicacionDTO.CodigoModeloEquipoComunicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modeloEquipoComunicacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarModeloEquipoComunicacion(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModeloEquiposComunicacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoComunicacionId"].Value = Codigo;
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
