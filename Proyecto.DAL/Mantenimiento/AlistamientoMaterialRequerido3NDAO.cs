using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoMaterialRequerido3NDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoMaterialRequerido3NDTO> ObtenerAlistamientoMaterialRequerido3Ns()
        {
            List<AlistamientoMaterialRequerido3NDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido3NListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialRequerido3NDTO()
                        {
                            AlistamientoMaterialRequerido3NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido3NId"]),
                            CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString(),
                            Subclasificacion = dr["Subclasificacion"].ToString(),
                            Ponderado3Nivel = Convert.ToDecimal(dr["Ponderado3Nivel"]),
                            Subclasificacion2N = dr["Subclasificacion"].ToString(),
                            CodigoAlistamientoMaterialRequerido2N = dr["CodigoAlistamientoMaterialRequerido2N"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoMaterialRequerido3N(AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido3NRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Subclasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Subclasificacion"].Value = alistamientoMaterialRequerido3NDTO.Subclasificacion;

                    cmd.Parameters.Add("@Ponderado3Nivel", SqlDbType.Decimal);
                    cmd.Parameters["@Ponderado3Nivel"].Value = alistamientoMaterialRequerido3NDTO.Ponderado3Nivel;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequerido3NDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialRequerido3NDTO BuscarAlistamientoMaterialRequerido3NID(int Codigo)
        {
            AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO = new AlistamientoMaterialRequerido3NDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido3NEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMaterialRequerido3NDTO.AlistamientoMaterialRequerido3NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido3NId"]);
                        alistamientoMaterialRequerido3NDTO.Subclasificacion = dr["Subclasificacion"].ToString();
                        alistamientoMaterialRequerido3NDTO.Ponderado3Nivel = Convert.ToDecimal(dr["Ponderado3Nivel"]);
                        alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString();
                        alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido2N = dr["CodigoAlistamientoMaterialRequerido2N"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialRequerido3NDTO;
        }

        public string ActualizarAlistamientoMaterialRequerido3N(AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido3NActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = alistamientoMaterialRequerido3NDTO.AlistamientoMaterialRequerido3NId;

                    cmd.Parameters.Add("@Subclasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Subclasificacion"].Value = alistamientoMaterialRequerido3NDTO.Subclasificacion;

                    cmd.Parameters.Add("@Ponderado3Nivel", SqlDbType.Decimal);
                    cmd.Parameters["@Ponderado3Nivel"].Value = alistamientoMaterialRequerido3NDTO.Ponderado3Nivel;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequerido3NDTO.UsuarioIngresoRegistro;

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

        public string EliminarAlistamientoMaterialRequerido3N(AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido3NEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = alistamientoMaterialRequerido3NDTO.AlistamientoMaterialRequerido3NId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequerido3NDTO.UsuarioIngresoRegistro;

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


    }
}
