using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoMaterialRequerido2NDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoMaterialRequerido2NDTO> ObtenerAlistamientoMaterialRequerido2Ns()
        {
            List<AlistamientoMaterialRequerido2NDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido2NListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialRequerido2NDTO()
                        {
                            AlistamientoMaterialRequerido2NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido2NId"]),
                            Subclasificacion = dr["Subclasificacion"].ToString(),
                            Ponderado2Nivel = Convert.ToDecimal(dr["Ponderado2Nivel"]),
                            Equipo = dr["Equipo"].ToString(),
                            CodigoAlistamientoMaterialRequerido2N = dr["CodigoAlistamientoMaterialRequerido2N"].ToString(),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoMaterialRequerido2N(AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido2NRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Subclasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Subclasificacion"].Value = alistamientoMaterialRequerido2NDTO.Subclasificacion;

                    cmd.Parameters.Add("@Ponderado2Nivel", SqlDbType.Decimal);
                    cmd.Parameters["@Ponderado2Nivel"].Value = alistamientoMaterialRequerido2NDTO.Ponderado2Nivel;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Equipo"].Value = alistamientoMaterialRequerido2NDTO.Equipo;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido1N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido1N"].Value = alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido1N;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequerido2NDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialRequerido2NDTO BuscarAlistamientoMaterialRequerido2NID(int Codigo)
        {
            AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO = new AlistamientoMaterialRequerido2NDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido2NEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido2NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido2NId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMaterialRequerido2NDTO.AlistamientoMaterialRequerido2NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido2NId"]);
                        alistamientoMaterialRequerido2NDTO.Subclasificacion = dr["Subclasificacion"].ToString();
                        alistamientoMaterialRequerido2NDTO.Ponderado2Nivel = Convert.ToDecimal(dr["Ponderado2Nivel"]);
                        alistamientoMaterialRequerido2NDTO.Equipo = dr["Equipo"].ToString();

                        alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido2N = dr["CodigoAlistamientoMaterialRequerido2N"].ToString();
                        alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido1N = dr["CodigoAlistamientoMaterialRequerido1N"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialRequerido2NDTO;
        }

        public string ActualizarAlistamientoMaterialRequerido2N(AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido2NActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido2NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido2NId"].Value = alistamientoMaterialRequerido2NDTO.AlistamientoMaterialRequerido2NId;

                    cmd.Parameters.Add("@Subclasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Subclasificacion"].Value = alistamientoMaterialRequerido2NDTO.Subclasificacion;

                    cmd.Parameters.Add("@Ponderado2Nivel", SqlDbType.Decimal);
                    cmd.Parameters["@Ponderado2Nivel"].Value = alistamientoMaterialRequerido2NDTO.Ponderado2Nivel;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Equipo"].Value = alistamientoMaterialRequerido2NDTO.Equipo;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido1N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido1N"].Value = alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido1N;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequerido2NDTO.UsuarioIngresoRegistro;

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

        public string EliminarAlistamientoMaterialRequerido2N(AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequerido2NEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido2NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido2NId"].Value = alistamientoMaterialRequerido2NDTO.AlistamientoMaterialRequerido2NId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequerido2NDTO.UsuarioIngresoRegistro;

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
