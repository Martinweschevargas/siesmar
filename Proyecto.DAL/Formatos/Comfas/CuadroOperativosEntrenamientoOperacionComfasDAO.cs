using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class CuadroOperativosEntrenamientoOperacionComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CuadroOperativosEntrenamientoOperacionComfasDTO> ObtenerLista()
        {
            List<CuadroOperativosEntrenamientoOperacionComfasDTO> lista = new List<CuadroOperativosEntrenamientoOperacionComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CuadroOperativosEntrenamientoOperacionComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CuadroOperativosEntrenamientoOperacionComfasDTO()
                        {
                            CuadroOperativoEntrenamientoOperacionId = Convert.ToInt32(dr["CuadroOperativoEntrenamientoOperacionId"]),
                            Fecha = (dr["Fecha"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraInicio = dr["HoraInicio"].ToString(),
                            HoraTermino = dr["HoraTermino"].ToString(),
                            Evento = dr["Evento"].ToString(),
                            OCEConductorControl = dr["OCEConductorControl"].ToString(),
                            UnidadAeronaveParticipante = dr["UnidadAeronaveParticipante"].ToString(),
                            Area = dr["Area"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroOperativosEntrenamientoOperacionComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.Fecha;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraTermino", SqlDbType.Time);
                    cmd.Parameters["@HoraTermino"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.HoraTermino;

                    cmd.Parameters.Add("@Evento", SqlDbType.VarChar,1);
                    cmd.Parameters["@Evento"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.Evento;

                    cmd.Parameters.Add("@OCEConductorControl", SqlDbType.VarChar,10);
                    cmd.Parameters["@OCEConductorControl"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.OCEConductorControl;

                    cmd.Parameters.Add("@UnidadAeronaveParticipante", SqlDbType.VarChar,50);
                    cmd.Parameters["@UnidadAeronaveParticipante"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.UnidadAeronaveParticipante;

                    cmd.Parameters.Add("@Area", SqlDbType.VarChar,50);
                    cmd.Parameters["@Area"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.Area;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.UsuarioIngresoRegistro;

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

        public CuadroOperativosEntrenamientoOperacionComfasDTO BuscarFormato(int Codigo)
        {
            CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO = new CuadroOperativosEntrenamientoOperacionComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroOperativosEntrenamientoOperacionComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroOperativoEntrenamientoOperacionId", SqlDbType.Int);
                    cmd.Parameters["@CuadroOperativoEntrenamientoOperacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cuadroOperativosEntrenamientoOperacionComfasDTO.CuadroOperativoEntrenamientoOperacionId = Convert.ToInt32(dr["CuadroOperativoEntrenamientoOperacionId"]);
                        cuadroOperativosEntrenamientoOperacionComfasDTO.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("yyy-MM-dd");
                        cuadroOperativosEntrenamientoOperacionComfasDTO.HoraInicio = dr["HoraInicio"].ToString();
                        cuadroOperativosEntrenamientoOperacionComfasDTO.HoraTermino = dr["HoraTermino"].ToString();
                        cuadroOperativosEntrenamientoOperacionComfasDTO.Evento = dr["Evento"].ToString();
                        cuadroOperativosEntrenamientoOperacionComfasDTO.OCEConductorControl = dr["OCEConductorControl"].ToString();
                        cuadroOperativosEntrenamientoOperacionComfasDTO.UnidadAeronaveParticipante = dr["UnidadAeronaveParticipante"].ToString();
                        cuadroOperativosEntrenamientoOperacionComfasDTO.Area = dr["Area"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cuadroOperativosEntrenamientoOperacionComfasDTO;
        }

        public string ActualizaFormato(CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CuadroOperativosEntrenamientoOperacionComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CuadroOperativoEntrenamientoOperacionId", SqlDbType.Int);
                    cmd.Parameters["@CuadroOperativoEntrenamientoOperacionId"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.CuadroOperativoEntrenamientoOperacionId;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.Fecha;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraTermino", SqlDbType.Time);
                    cmd.Parameters["@HoraTermino"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.HoraTermino;

                    cmd.Parameters.Add("@Evento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@Evento"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.Evento;

                    cmd.Parameters.Add("@OCEConductorControl", SqlDbType.VarChar, 10);
                    cmd.Parameters["@OCEConductorControl"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.OCEConductorControl;

                    cmd.Parameters.Add("@UnidadAeronaveParticipante", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UnidadAeronaveParticipante"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.UnidadAeronaveParticipante;

                    cmd.Parameters.Add("@Area", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Area"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.Area;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroOperativosEntrenamientoOperacionComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroOperativoEntrenamientoOperacionId", SqlDbType.Int);
                    cmd.Parameters["@CuadroOperativoEntrenamientoOperacionId"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.CuadroOperativoEntrenamientoOperacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroOperativosEntrenamientoOperacionComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<CuadroOperativosEntrenamientoOperacionComfasDTO> cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conexion;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Formato.EstudiosInvestigacionHistoricaNaval " +
                            " (NombreInvestigacion, TipoEstudioInvestigacionId, FechaInicioInvestigacion, " +
                            "FechaTerminoInvestigacion, ResponsableInvestigacion, SolicitanteInvestigacion, " +
                            "UsuarioIngresoRegistro, FechaIngresoRegistro, NroIpRegistro, NroMacRegistro, " +
                            "UsuarioBaseDatos, CodigoIngreso, Año, Mes, Dia) values (@NombreInvestigacion, " +
                            "@TipoEstudioInvestigacionId, @FechaInicioInvestigacion, @FechaTerminoInvestigacion, " +
                            "@ResponsableInvestigacion, @SolicitanteInvestigacion, @Usuario, GETDATE(), @IP, @MAC, " +
                            "@UsuarioDB, 0, @YEAR, @MES, @DIA)";
                        cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                        cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@MAC", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@UsuarioDB", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                        cmd.Parameters.Add("@MES", SqlDbType.Int);
                        cmd.Parameters.Add("@DIA", SqlDbType.Int);
                        try
                        {
                            foreach (var item in cuadroOperativosEntrenamientoOperacionComfasDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreTemaEstudioInvestigacion;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoEstudioInvestigacionIds;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicio);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTermino);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.Responsable;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.Solicitante;
                                cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();

                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            respuesta = true;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();                    
                            throw;
                        }
                        finally
                        {
                            conexion.Close();
                        }
                    }
                }
            }
            return respuesta;
        }
    }
}
