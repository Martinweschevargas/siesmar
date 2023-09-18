using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ObjetoContratacionDAO
    {

        SqlCommand cmd = new();

        public List<ObjetoContratacionDTO> ObtenerObjetoContratacions()
        {
            List<ObjetoContratacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ObjetoContratacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ObjetoContratacionDTO()
                        {
                            ObjetoContratacionId = Convert.ToInt32(dr["ObjetoContratacionId"]),
                            DescObjetoContratacion = dr["DescObjetoContratacion"].ToString(),
                            CodigoObjetoContratacion = dr["CodigoObjetoContratacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarObjetoContratacion(ObjetoContratacionDTO objetoContratacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ObjetoContratacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescObjetoContratacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescObjetoContratacion"].Value = objetoContratacionDTO.DescObjetoContratacion;

                    cmd.Parameters.Add("@CodigoObjetoContratacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoObjetoContratacion"].Value = objetoContratacionDTO.CodigoObjetoContratacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = objetoContratacionDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ObjetoContratacionDTO BuscarObjetoContratacionID(int Codigo)
        {
            ObjetoContratacionDTO objetoContratacionDTO = new ObjetoContratacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ObjetoContratacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ObjetoContratacionId", SqlDbType.Int);
                    cmd.Parameters["@ObjetoContratacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        objetoContratacionDTO.ObjetoContratacionId = Convert.ToInt32(dr["ObjetoContratacionId"]);
                        objetoContratacionDTO.DescObjetoContratacion = dr["DescObjetoContratacion"].ToString();
                        objetoContratacionDTO.CodigoObjetoContratacion = dr["CodigoObjetoContratacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return objetoContratacionDTO;
        }

        public string ActualizarObjetoContratacion(ObjetoContratacionDTO objetoContratacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ObjetoContratacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ObjetoContratacionId", SqlDbType.Int);
                    cmd.Parameters["@ObjetoContratacionId"].Value = objetoContratacionDTO.ObjetoContratacionId;

                    cmd.Parameters.Add("@DescObjetoContratacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescObjetoContratacion"].Value = objetoContratacionDTO.DescObjetoContratacion;

                    cmd.Parameters.Add("@CodigoObjetoContratacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoObjetoContratacion"].Value = objetoContratacionDTO.CodigoObjetoContratacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = objetoContratacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarObjetoContratacion(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ObjetoContratacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ObjetoContratacionId", SqlDbType.Int);
                    cmd.Parameters["@ObjetoContratacionId"].Value = Codigo;
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
