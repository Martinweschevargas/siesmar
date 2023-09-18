using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FaseProyectoDAO
    {

        SqlCommand cmd = new();

        public List<FaseProyectoDTO> ObtenerFaseProyectos()
        {
            List<FaseProyectoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FaseProyectoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FaseProyectoDTO()
                        {
                            FaseProyectoId = Convert.ToInt32(dr["FaseProyectoId"]),
                            DescFaseProyecto = dr["DescFaseProyecto"].ToString(),
                            CodigoFaseProyecto = dr["CodigoFaseProyecto"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFaseProyecto(FaseProyectoDTO faseProyectoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseProyectoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFaseProyecto", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescFaseProyecto"].Value = faseProyectoDTO.DescFaseProyecto;

                    cmd.Parameters.Add("@CodigoFaseProyecto", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoFaseProyecto"].Value = faseProyectoDTO.CodigoFaseProyecto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = faseProyectoDTO.UsuarioIngresoRegistro;

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

        public FaseProyectoDTO BuscarFaseProyectoID(int Codigo)
        {
            FaseProyectoDTO faseProyectoDTO = new FaseProyectoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseProyectoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FaseProyectoId", SqlDbType.Int);
                    cmd.Parameters["@FaseProyectoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        faseProyectoDTO.FaseProyectoId = Convert.ToInt32(dr["FaseProyectoId"]);
                        faseProyectoDTO.DescFaseProyecto = dr["DescFaseProyecto"].ToString();
                        faseProyectoDTO.CodigoFaseProyecto = dr["CodigoFaseProyecto"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return faseProyectoDTO;
        }

        public string ActualizarFaseProyecto(FaseProyectoDTO faseProyectoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_FaseProyectoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FaseProyectoId", SqlDbType.Int);
                    cmd.Parameters["@FaseProyectoId"].Value = faseProyectoDTO.FaseProyectoId;

                    cmd.Parameters.Add("@DescFaseProyecto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFaseProyecto"].Value = faseProyectoDTO.DescFaseProyecto;

                    cmd.Parameters.Add("@CodigoFaseProyecto", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFaseProyecto"].Value = faseProyectoDTO.CodigoFaseProyecto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = faseProyectoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFaseProyecto(FaseProyectoDTO faseProyectoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseProyectoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FaseProyectoId", SqlDbType.Int);
                    cmd.Parameters["@FaseProyectoId"].Value = faseProyectoDTO.FaseProyectoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = faseProyectoDTO.UsuarioIngresoRegistro;

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
