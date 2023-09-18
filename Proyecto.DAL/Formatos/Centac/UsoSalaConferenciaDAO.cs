using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Centac;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Centac
{
    public class UsoSalaConferenciaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<UsoSalaConferenciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<UsoSalaConferenciaDTO> lista = new List<UsoSalaConferenciaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_UsoSalaConferenciaListar", conexion);
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
                        lista.Add(new UsoSalaConferenciaDTO()
                        {
                            UsoSalaConferenciaId = Convert.ToInt32(dr["UsoSalaConferenciaId"]),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            FechaUsoSala = (dr["FechaUsoSala"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TipoConferencia = dr["TipoConferencia"].ToString(),
                            NumeroParticipante = Convert.ToInt32(dr["NumeroParticipante"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(UsoSalaConferenciaDTO usoSalaConferenciaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoSalaConferenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = usoSalaConferenciaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaUsoSala", SqlDbType.Date);
                    cmd.Parameters["@FechaUsoSala"].Value = usoSalaConferenciaDTO.FechaUsoSala;

                    cmd.Parameters.Add("@TipoConferencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@TipoConferencia"].Value = usoSalaConferenciaDTO.TipoConferencia;

                    cmd.Parameters.Add("@NumeroParticipante", SqlDbType.Int);
                    cmd.Parameters["@NumeroParticipante"].Value = usoSalaConferenciaDTO.NumeroParticipante;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = usoSalaConferenciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoSalaConferenciaDTO.UsuarioIngresoRegistro;

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

        public UsoSalaConferenciaDTO BuscarFormato(int Codigo)
        {
            UsoSalaConferenciaDTO usoSalaConferenciaDTO = new UsoSalaConferenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoSalaConferenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoSalaConferenciaId", SqlDbType.Int);
                    cmd.Parameters["@UsoSalaConferenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        usoSalaConferenciaDTO.UsoSalaConferenciaId = Convert.ToInt32(dr["UsoSalaConferenciaId"]);
                        usoSalaConferenciaDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        usoSalaConferenciaDTO.FechaUsoSala = Convert.ToDateTime(dr["FechaUsoSala"]).ToString("yyy-MM-dd");
                        usoSalaConferenciaDTO.TipoConferencia = dr["TipoConferencia"].ToString();
                        usoSalaConferenciaDTO.NumeroParticipante = Convert.ToInt32(dr["NumeroParticipante"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return usoSalaConferenciaDTO;
        }

        public string ActualizaFormato(UsoSalaConferenciaDTO usoSalaConferenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_UsoSalaConferenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoSalaConferenciaId", SqlDbType.Int);
                    cmd.Parameters["@UsoSalaConferenciaId"].Value = usoSalaConferenciaDTO.UsoSalaConferenciaId;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = usoSalaConferenciaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaUsoSala", SqlDbType.Date);
                    cmd.Parameters["@FechaUsoSala"].Value = usoSalaConferenciaDTO.FechaUsoSala;

                    cmd.Parameters.Add("@TipoConferencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@TipoConferencia"].Value = usoSalaConferenciaDTO.TipoConferencia;

                    cmd.Parameters.Add("@NumeroParticipante", SqlDbType.Int);
                    cmd.Parameters["@NumeroParticipante"].Value = usoSalaConferenciaDTO.NumeroParticipante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoSalaConferenciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(UsoSalaConferenciaDTO usoSalaConferenciaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoSalaConferenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoSalaConferenciaId", SqlDbType.Int);
                    cmd.Parameters["@UsoSalaConferenciaId"].Value = usoSalaConferenciaDTO.UsoSalaConferenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoSalaConferenciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(UsoSalaConferenciaDTO usoSalaConferenciaDTO)
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
                    cmd.Parameters["@Formato"].Value = "UsoSalaConferencia";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = usoSalaConferenciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoSalaConferenciaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_UsoSalaConferenciaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoSalaConferencia", SqlDbType.Structured);
                    cmd.Parameters["@UsoSalaConferencia"].TypeName = "Formato.UsoSalaConferencia";
                    cmd.Parameters["@UsoSalaConferencia"].Value = datos;

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
