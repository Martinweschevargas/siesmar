using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar
{
    public class AlistamientoRepuestoCriticoComfuinmarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoRepuestoCriticoComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoRepuestoCriticoComfuinmarDTO> lista = new List<AlistamientoRepuestoCriticoComfuinmarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuinmarListar", conexion);
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
                        lista.Add(new AlistamientoRepuestoCriticoComfuinmarDTO()
                        {
                            AlistamientoRepuestoCriticoComfuinmarId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoComfuinmarId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CodigoAlistamientoRepuestoCritico = dr["CodigoAlistamientoRepuestoCritico"].ToString(),
                            NroRepuestoExistente = Convert.ToInt32(dr["NroRepuestoExistente"].ToString()),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuinmarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoRepuestoCriticoComfuinmarDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoRepuestoCritico"].Value = alistamientoRepuestoCriticoComfuinmarDTO.CodigoAlistamientoRepuestoCritico;

                    cmd.Parameters.Add("@NroRepuestoExistente", SqlDbType.Int);
                    cmd.Parameters["@NroRepuestoExistente"].Value = alistamientoRepuestoCriticoComfuinmarDTO.NroRepuestoExistente;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoRepuestoCriticoComfuinmarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuinmarDTO.UsuarioIngresoRegistro;

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

        public AlistamientoRepuestoCriticoComfuinmarDTO BuscarFormato(int Codigo)
        {
            AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO = new AlistamientoRepuestoCriticoComfuinmarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuinmarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoComfuinmarId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuinmarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoRepuestoCriticoComfuinmarDTO.AlistamientoRepuestoCriticoComfuinmarId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoComfuinmarId"]);
                        alistamientoRepuestoCriticoComfuinmarDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoRepuestoCriticoComfuinmarDTO.CodigoAlistamientoRepuestoCritico = dr["CodigoAlistamientoRepuestoCritico"].ToString();
                        alistamientoRepuestoCriticoComfuinmarDTO.NroRepuestoExistente = Convert.ToInt32(dr["NroRepuestoExistente"].ToString());
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoRepuestoCriticoComfuinmarDTO;
        }

        public string ActualizaFormato(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuinmarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoComfuinmarId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuinmarId"].Value = alistamientoRepuestoCriticoComfuinmarDTO.AlistamientoRepuestoCriticoComfuinmarId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoRepuestoCriticoComfuinmarDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoRepuestoCritico"].Value = alistamientoRepuestoCriticoComfuinmarDTO.CodigoAlistamientoRepuestoCritico;

                    cmd.Parameters.Add("@NroRepuestoExistente", SqlDbType.Int);
                    cmd.Parameters["@NroRepuestoExistente"].Value = alistamientoRepuestoCriticoComfuinmarDTO.NroRepuestoExistente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuinmarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuinmarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoComfuinmarId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuinmarId"].Value = alistamientoRepuestoCriticoComfuinmarDTO.AlistamientoRepuestoCriticoComfuinmarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuinmarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoRepuestoCriticoComfuinmar";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoRepuestoCriticoComfuinmarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfuinmarDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfuinmarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoComfuinmar", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuinmar"].TypeName = "Formato.AlistamientoRepuestoCriticoComfuinmar";
                    cmd.Parameters["@AlistamientoRepuestoCriticoComfuinmar"].Value = datos;

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
