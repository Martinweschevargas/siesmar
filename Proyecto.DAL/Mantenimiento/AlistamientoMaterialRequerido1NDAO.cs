using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoMaterialRequerido1NDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoMaterialRequerido1NDTO> ObtenerAlistamientoMaterialRequerido1Ns()
        {
            List<AlistamientoMaterialRequerido1NDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido1NListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialRequerido1NDTO()
                        {
                            AlistamientoMaterialRequerido1NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido1NId"]),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            Ponderado1N = Convert.ToDecimal(dr["Ponderado1N"]),
                            CodigoAlistamientoMaterialRequerido1N = dr["CodigoAlistamientoMaterialRequerido1N"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido1NRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadIntrinseca", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacidadIntrinseca"].Value = AlistamientoMaterialRequerido1NDTO.CapacidadIntrinseca;

                    cmd.Parameters.Add("@Ponderado1N", SqlDbType.Decimal);
                    cmd.Parameters["@Ponderado1N"].Value = AlistamientoMaterialRequerido1NDTO.Ponderado1N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido1N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido1N"].Value = AlistamientoMaterialRequerido1NDTO.CodigoAlistamientoMaterialRequerido1N;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoMaterialRequerido1NDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialRequerido1NDTO BuscarAlistamientoMaterialRequerido1NID(int Codigo)
        {
            AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO = new AlistamientoMaterialRequerido1NDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido1NEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido1NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido1NId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AlistamientoMaterialRequerido1NDTO.AlistamientoMaterialRequerido1NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido1NId"]);
                        AlistamientoMaterialRequerido1NDTO.CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString();
                        AlistamientoMaterialRequerido1NDTO.Ponderado1N = Convert.ToDecimal(dr["Ponderado1N"]);
                        AlistamientoMaterialRequerido1NDTO.CodigoAlistamientoMaterialRequerido1N = dr["CodigoAlistamientoMaterialRequerido1N"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AlistamientoMaterialRequerido1NDTO;
        }

        public string ActualizarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido1NActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido1NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido1NId"].Value = AlistamientoMaterialRequerido1NDTO.AlistamientoMaterialRequerido1NId;

                    cmd.Parameters.Add("@CapacidadIntrinseca", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacidadIntrinseca"].Value = AlistamientoMaterialRequerido1NDTO.CapacidadIntrinseca;

                    cmd.Parameters.Add("@Ponderado1N", SqlDbType.Decimal);
                    cmd.Parameters["@Ponderado1N"].Value = AlistamientoMaterialRequerido1NDTO.Ponderado1N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido1N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido1N"].Value = AlistamientoMaterialRequerido1NDTO.CodigoAlistamientoMaterialRequerido1N;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoMaterialRequerido1NDTO.UsuarioIngresoRegistro;

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

        public string EliminarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido1NEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido1NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido1NId"].Value = AlistamientoMaterialRequerido1NDTO.AlistamientoMaterialRequerido1NId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoMaterialRequerido1NDTO.UsuarioIngresoRegistro;

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
