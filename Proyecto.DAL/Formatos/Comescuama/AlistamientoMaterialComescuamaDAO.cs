using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescuama
{
    public class AlistamientoMaterialComescuamaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMaterialComescuamaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoMaterialComescuamaDTO> lista = new List<AlistamientoMaterialComescuamaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComescuamaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialComescuamaDTO()
                        {
                            AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]),
                            DescUnidadComescuama = dr["DescUnidadComescuama"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            Ponderado1N = dr["Ponderado1N"].ToString(),
                            Subclasificacion2N = dr["Subclasificacion2N"].ToString(),
                            Ponderado2Nivel = dr["Ponderado2Nivel"].ToString(),
                            Subclasificacion3N = dr["Subclasificacion"].ToString(),
                            Ponderado3Nivel = dr["Ponderado3Nivel"].ToString(),
                            Requerido = dr["Requerido"].ToString(),
                            Operativo = dr["Operativo"].ToString(),
                            PorcentajeOperatividad = dr["PorcentajeOperatividad"].ToString(),
                            PonderadoFuncional = Convert.ToDecimal(dr["PonderadoFuncional"]),
                            NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComescuamaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadComescuama", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadComescuama"].Value = alistamientoMaterialComescuamaDTO.CodigoUnidadComescuama;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = alistamientoMaterialComescuamaDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequeridoComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequeridoComescuama"].Value = alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama;

                    cmd.Parameters.Add("@PonderadoFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PonderadoFuncional"].Value = alistamientoMaterialComescuamaDTO.PonderadoFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialComescuamaDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMaterialComescuamaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public AlistamientoMaterialComescuamaDTO BuscarFormato(int Codigo)
        {
            AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO = new AlistamientoMaterialComescuamaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComescuamaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoMaterialComescuamaDTO.AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]);
                        alistamientoMaterialComescuamaDTO.CodigoUnidadComescuama = dr["CodigoUnidadComescuama"].ToString();
                        alistamientoMaterialComescuamaDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString();
                        alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama = dr["CodigoAlistamientoMaterialRequeridoComescuama"].ToString();
                        alistamientoMaterialComescuamaDTO.PonderadoFuncional = Convert.ToDecimal(dr["PonderadoFuncional"]);
                        alistamientoMaterialComescuamaDTO.NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialComescuamaDTO;
        }

        public string ActualizaFormato(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComescuamaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialComescuamaDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@CodigoUnidadComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadComescuama"].Value = alistamientoMaterialComescuamaDTO.CodigoUnidadComescuama;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = alistamientoMaterialComescuamaDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequeridoComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequeridoComescuama"].Value = alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama;

                    cmd.Parameters.Add("@PonderadoFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PonderadoFuncional"].Value = alistamientoMaterialComescuamaDTO.PonderadoFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialComescuamaDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComescuamaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialComescuamaDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "AlistamientoMaterialComescuama";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMaterialComescuamaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComescuamaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialComescuama", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMaterialComescuama"].TypeName = "Formato.AlistamientoMaterialComescuama";
                    cmd.Parameters["@AlistamientoMaterialComescuama"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
