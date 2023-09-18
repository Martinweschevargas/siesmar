using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Centac;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Centac
{
    public class EntrenamientoInstruccionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EntrenamientoInstruccionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EntrenamientoInstruccionDTO> lista = new List<EntrenamientoInstruccionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EntrenamientoInstruccionListar", conexion);
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
                        lista.Add(new EntrenamientoInstruccionDTO()
                        {
                            EntrenamientoInstruccionId = Convert.ToInt32(dr["EntrenamientoInstruccionId"]),
                            FechaEntrenamiento = (dr["FechaEntrenamiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DuracionHoras = Convert.ToInt32(dr["DuracionHoras"]),
                            NumeroParticipantes = Convert.ToInt32(dr["NumeroParticipantes"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntrenamientoInstruccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaEntrenamiento", SqlDbType.Date);
                    cmd.Parameters["@FechaEntrenamiento"].Value = entrenamientoInstruccionDTO.FechaEntrenamiento;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = entrenamientoInstruccionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@DuracionHoras", SqlDbType.Int);
                    cmd.Parameters["@DuracionHoras"].Value = entrenamientoInstruccionDTO.DuracionHoras;

                    cmd.Parameters.Add("@NumeroParticipantes", SqlDbType.Int);
                    cmd.Parameters["@NumeroParticipantes"].Value = entrenamientoInstruccionDTO.NumeroParticipantes;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = entrenamientoInstruccionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoInstruccionDTO.UsuarioIngresoRegistro;

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

        public EntrenamientoInstruccionDTO BuscarFormato(int Codigo)
        {
            EntrenamientoInstruccionDTO entrenamientoInstruccionDTO = new EntrenamientoInstruccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntrenamientoInstruccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoInstruccionId", SqlDbType.Int);
                    cmd.Parameters["@EntrenamientoInstruccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entrenamientoInstruccionDTO.EntrenamientoInstruccionId = Convert.ToInt32(dr["EntrenamientoInstruccionId"]);
                        entrenamientoInstruccionDTO.FechaEntrenamiento = Convert.ToDateTime(dr["FechaEntrenamiento"]).ToString("yyy-MM-dd");
                        entrenamientoInstruccionDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        entrenamientoInstruccionDTO.DuracionHoras = Convert.ToInt32(dr["DuracionHoras"]);
                        entrenamientoInstruccionDTO.NumeroParticipantes = Convert.ToInt32(dr["NumeroParticipantes"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entrenamientoInstruccionDTO;
        }

        public string ActualizaFormato(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EntrenamientoInstruccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EntrenamientoInstruccionId", SqlDbType.Int);
                    cmd.Parameters["@EntrenamientoInstruccionId"].Value = entrenamientoInstruccionDTO.EntrenamientoInstruccionId;

                    cmd.Parameters.Add("@FechaEntrenamiento", SqlDbType.Date);
                    cmd.Parameters["@FechaEntrenamiento"].Value = entrenamientoInstruccionDTO.FechaEntrenamiento;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = entrenamientoInstruccionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@DuracionHoras", SqlDbType.Int);
                    cmd.Parameters["@DuracionHoras"].Value = entrenamientoInstruccionDTO.DuracionHoras;

                    cmd.Parameters.Add("@NumeroParticipantes", SqlDbType.Int);
                    cmd.Parameters["@NumeroParticipantes"].Value = entrenamientoInstruccionDTO.NumeroParticipantes;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoInstruccionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntrenamientoInstruccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoInstruccionId", SqlDbType.Int);
                    cmd.Parameters["@EntrenamientoInstruccionId"].Value = entrenamientoInstruccionDTO.EntrenamientoInstruccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoInstruccionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO)
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
                    cmd.Parameters["@Formato"].Value = "EntrenamientoInstruccion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = entrenamientoInstruccionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoInstruccionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EntrenamientoInstruccionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoInstruccion", SqlDbType.Structured);
                    cmd.Parameters["@EntrenamientoInstruccion"].TypeName = "Formato.EntrenamientoInstruccion";
                    cmd.Parameters["@EntrenamientoInstruccion"].Value = datos;

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
