using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class TrabajoRestauracionConservacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<TrabajoRestauracionConservacionDTO> ObtenerLista()
        {
            List<TrabajoRestauracionConservacionDTO> lista = new List<TrabajoRestauracionConservacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_TrabajoRestauracionConservacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TrabajoRestauracionConservacionDTO()
                        {
                            TrabajoRestauracionId = Convert.ToInt32(dr["TrabajoRestauracionId"]),
                            DescTrabajoRealizadoBienHistorico = dr["DescTrabajoRealizadoBienHistorico"].ToString(),
                            NroTrabajo = Convert.ToInt32(dr["NroTrabajo"]),
                            NroPiezaTratada = Convert.ToInt32(dr["NroPiezaTratada"]),
                            NroPersonaRealizanTrabajo = Convert.ToInt32(dr["NroPersonaRealizanTrabajo"]),
                            FechaInicioTrabajoRestConserv = (dr["FechaInicioTrabajoRestConserv"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoTrabajoRestConserv = (dr["FechaTerminoTrabajoRestConserv"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EncargadoTrabajoRestConserv = dr["EncargadoTrabajoRestConserv"].ToString(),
                            DescripcionTrabajoRealizado = dr["DescripcionTrabajoRealizado"].ToString(),
                            InversionTrabajoRestConserv = Convert.ToDecimal(dr["InversionTrabajoRestConserv"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_TrabajoRestauracionConservacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRealizadoBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRealizadoBienHistoricoId"].Value = trabajoRestauracionConservacionDTO.TrabajoRealizadoBienHistoricoId;

                    cmd.Parameters.Add("@NroTrabajo", SqlDbType.Int);
                    cmd.Parameters["@NroTrabajo"].Value = trabajoRestauracionConservacionDTO.NroTrabajo;

                    cmd.Parameters.Add("@NroPiezaTratada", SqlDbType.Int);
                    cmd.Parameters["@NroPiezaTratada"].Value = trabajoRestauracionConservacionDTO.NroPiezaTratada;

                    cmd.Parameters.Add("@NroPersonaRealizanTrabajo", SqlDbType.Int);
                    cmd.Parameters["@NroPersonaRealizanTrabajo"].Value = trabajoRestauracionConservacionDTO.NroPersonaRealizanTrabajo;

                    cmd.Parameters.Add("@FechaInicioTrabajoRestConserv", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.FechaInicioTrabajoRestConserv;

                    cmd.Parameters.Add("@FechaTerminoTrabajoRestConserv", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.FechaTerminoTrabajoRestConserv;

                    cmd.Parameters.Add("@EncargadoTrabajoRestConserv", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EncargadoTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.EncargadoTrabajoRestConserv;

                    cmd.Parameters.Add("@DescripcionTrabajoRealizado", SqlDbType.VarChar,50);
                    cmd.Parameters["@DescripcionTrabajoRealizado"].Value = trabajoRestauracionConservacionDTO.DescripcionTrabajoRealizado;

                    cmd.Parameters.Add("@InversionTrabajoRestConserv", SqlDbType.Decimal);
                    cmd.Parameters["@InversionTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.InversionTrabajoRestConserv;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoRestauracionConservacionDTO.UsuarioIngresoRegistro;

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

        public TrabajoRestauracionConservacionDTO BuscarFormato(int Codigo)
        {
            TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO = new TrabajoRestauracionConservacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TrabajoRestauracionConservacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRestauracionId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRestauracionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        trabajoRestauracionConservacionDTO.TrabajoRestauracionId = Convert.ToInt32(dr["TrabajoRestauracionId"]);
                        trabajoRestauracionConservacionDTO.TrabajoRealizadoBienHistoricoId = Convert.ToInt32(dr["TrabajoRealizadoBienHistoricoId"]);
                        trabajoRestauracionConservacionDTO.NroTrabajo = Convert.ToInt32(dr["NroTrabajo"]);
                        trabajoRestauracionConservacionDTO.NroPiezaTratada = Convert.ToInt32(dr["NroPiezaTratada"]);
                        trabajoRestauracionConservacionDTO.NroPersonaRealizanTrabajo = Convert.ToInt32(dr["NroPersonaRealizanTrabajo"]);
                        trabajoRestauracionConservacionDTO.FechaInicioTrabajoRestConserv = Convert.ToDateTime(dr["FechaInicioTrabajoRestConserv"]).ToString("yyy-MM-dd");
                        trabajoRestauracionConservacionDTO.FechaTerminoTrabajoRestConserv = Convert.ToDateTime(dr["FechaTerminoTrabajoRestConserv"]).ToString("yyy-MM-dd");
                        trabajoRestauracionConservacionDTO.EncargadoTrabajoRestConserv = dr["EncargadoTrabajoRestConserv"].ToString();
                        trabajoRestauracionConservacionDTO.DescripcionTrabajoRealizado = dr["DescripcionTrabajoRealizado"].ToString();
                        trabajoRestauracionConservacionDTO.InversionTrabajoRestConserv = Convert.ToDecimal(dr["InversionTrabajoRestConserv"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return trabajoRestauracionConservacionDTO;
        }

        public string ActualizaFormato(TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_TrabajoRestauracionConservacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRestauracionId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRestauracionId"].Value = trabajoRestauracionConservacionDTO.TrabajoRestauracionId;

                    cmd.Parameters.Add("@TrabajoRealizadoBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRealizadoBienHistoricoId"].Value = trabajoRestauracionConservacionDTO.TrabajoRealizadoBienHistoricoId;

                    cmd.Parameters.Add("@NroTrabajo", SqlDbType.Int);
                    cmd.Parameters["@NroTrabajo"].Value = trabajoRestauracionConservacionDTO.NroTrabajo;

                    cmd.Parameters.Add("@NroPiezaTratada", SqlDbType.Int);
                    cmd.Parameters["@NroPiezaTratada"].Value = trabajoRestauracionConservacionDTO.NroPiezaTratada;

                    cmd.Parameters.Add("@NroPersonaRealizanTrabajo", SqlDbType.Int);
                    cmd.Parameters["@NroPersonaRealizanTrabajo"].Value = trabajoRestauracionConservacionDTO.NroPersonaRealizanTrabajo;

                    cmd.Parameters.Add("@FechaInicioTrabajoRestConserv", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.FechaInicioTrabajoRestConserv;

                    cmd.Parameters.Add("@FechaTerminoTrabajoRestConserv", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.FechaTerminoTrabajoRestConserv;

                    cmd.Parameters.Add("@EncargadoTrabajoRestConserv", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EncargadoTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.EncargadoTrabajoRestConserv;

                    cmd.Parameters.Add("@DescripcionTrabajoRealizado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescripcionTrabajoRealizado"].Value = trabajoRestauracionConservacionDTO.DescripcionTrabajoRealizado;

                    cmd.Parameters.Add("@InversionTrabajoRestConserv", SqlDbType.Decimal);
                    cmd.Parameters["@InversionTrabajoRestConserv"].Value = trabajoRestauracionConservacionDTO.InversionTrabajoRestConserv;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoRestauracionConservacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TrabajoRestauracionConservacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRestauracionId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoRestauracionId"].Value = trabajoRestauracionConservacionDTO.TrabajoRestauracionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoRestauracionConservacionDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_TrabajoRestauracionConservacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoRestauracionConservacion", SqlDbType.Structured);
                    cmd.Parameters["@TrabajoRestauracionConservacion"].TypeName = "Formato.TrabajoRestauracionConservacion";
                    cmd.Parameters["@TrabajoRestauracionConservacion"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                    cmd.Parameters["@R_Mes"].Value = DateTime.Now.Month.ToString();

                    cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                    cmd.Parameters["@R_Anio"].Value = DateTime.Now.Year.ToString();

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
