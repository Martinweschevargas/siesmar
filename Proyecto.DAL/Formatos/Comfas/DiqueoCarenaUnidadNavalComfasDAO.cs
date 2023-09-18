using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class DiqueoCarenaUnidadNavalComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DiqueoCarenaUnidadNavalComfasDTO> ObtenerLista()
        {
            List<DiqueoCarenaUnidadNavalComfasDTO> lista = new List<DiqueoCarenaUnidadNavalComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DiqueoCarenaUnidadNavalComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DiqueoCarenaUnidadNavalComfasDTO()
                        {
                            DiqueoCarenaUnidadNavalId = Convert.ToInt32(dr["DiqueoCarenaUnidadNavalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaIngresoUltimoDiqueo = (dr["FechaIngresoUltimoDiqueo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaSalidaUltimoDiqueo = (dr["FechaSalidaUltimoDiqueo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaIngresoProximoDiqueo = (dr["FechaIngresoProximoDiqueo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaSalidaProximoDiqueo = (dr["FechaSalidaProximoDiqueo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            PrioridadProximoDiqueo = (dr["PrioridadProximoDiqueo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Lugar = dr["Lugar"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DiqueoCarenaUnidadNavalComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = diqueoCarenaUnidadNavalComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaIngresoUltimoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoUltimoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaIngresoUltimoDiqueo;

                    cmd.Parameters.Add("@FechaSalidaUltimoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaSalidaUltimoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaSalidaUltimoDiqueo;

                    cmd.Parameters.Add("@FechaIngresoProximoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoProximoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaIngresoProximoDiqueo;

                    cmd.Parameters.Add("@FechaSalidaProximoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaSalidaProximoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaSalidaProximoDiqueo;

                    cmd.Parameters.Add("@PrioridadProximoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@PrioridadProximoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.PrioridadProximoDiqueo;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,50);
                    cmd.Parameters["@Lugar"].Value = diqueoCarenaUnidadNavalComfasDTO.Lugar;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,100);
                    cmd.Parameters["@Observaciones"].Value = diqueoCarenaUnidadNavalComfasDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = diqueoCarenaUnidadNavalComfasDTO.UsuarioIngresoRegistro;

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

        public DiqueoCarenaUnidadNavalComfasDTO BuscarFormato(int Codigo)
        {
            DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO = new DiqueoCarenaUnidadNavalComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DiqueoCarenaUnidadNavalComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DiqueoCarenaUnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@DiqueoCarenaUnidadNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        diqueoCarenaUnidadNavalComfasDTO.DiqueoCarenaUnidadNavalId = Convert.ToInt32(dr["DiqueoCarenaUnidadNavalId"]);
                        diqueoCarenaUnidadNavalComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        diqueoCarenaUnidadNavalComfasDTO.FechaIngresoUltimoDiqueo = Convert.ToDateTime(dr["FechaIngresoUltimoDiqueo"]).ToString("yyy-MM-dd");
                        diqueoCarenaUnidadNavalComfasDTO.FechaSalidaUltimoDiqueo = Convert.ToDateTime(dr["FechaSalidaUltimoDiqueo"]).ToString("yyy-MM-dd");
                        diqueoCarenaUnidadNavalComfasDTO.FechaIngresoProximoDiqueo = Convert.ToDateTime(dr["FechaIngresoProximoDiqueo"]).ToString("yyy-MM-dd");
                        diqueoCarenaUnidadNavalComfasDTO.FechaSalidaProximoDiqueo = Convert.ToDateTime(dr["FechaSalidaProximoDiqueo"]).ToString("yyy-MM-dd");
                        diqueoCarenaUnidadNavalComfasDTO.PrioridadProximoDiqueo = Convert.ToDateTime(dr["PrioridadProximoDiqueo"]).ToString("yyy-MM-dd");
                        diqueoCarenaUnidadNavalComfasDTO.Lugar = dr["Lugar"].ToString();
                        diqueoCarenaUnidadNavalComfasDTO.Observaciones = dr["Observaciones"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return diqueoCarenaUnidadNavalComfasDTO;
        }

        public string ActualizaFormato(DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DiqueoCarenaUnidadNavalComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DiqueoCarenaUnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@DiqueoCarenaUnidadNavalId"].Value = diqueoCarenaUnidadNavalComfasDTO.DiqueoCarenaUnidadNavalId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = diqueoCarenaUnidadNavalComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaIngresoUltimoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoUltimoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaIngresoUltimoDiqueo;

                    cmd.Parameters.Add("@FechaSalidaUltimoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaSalidaUltimoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaSalidaUltimoDiqueo;

                    cmd.Parameters.Add("@FechaIngresoProximoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoProximoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaIngresoProximoDiqueo;

                    cmd.Parameters.Add("@FechaSalidaProximoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@FechaSalidaProximoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.FechaSalidaProximoDiqueo;

                    cmd.Parameters.Add("@PrioridadProximoDiqueo", SqlDbType.Date);
                    cmd.Parameters["@PrioridadProximoDiqueo"].Value = diqueoCarenaUnidadNavalComfasDTO.PrioridadProximoDiqueo;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,50);
                    cmd.Parameters["@Lugar"].Value = diqueoCarenaUnidadNavalComfasDTO.Lugar;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,100);
                    cmd.Parameters["@Observaciones"].Value = diqueoCarenaUnidadNavalComfasDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = diqueoCarenaUnidadNavalComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DiqueoCarenaUnidadNavalComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DiqueoCarenaUnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@DiqueoCarenaUnidadNavalId"].Value = diqueoCarenaUnidadNavalComfasDTO.DiqueoCarenaUnidadNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = diqueoCarenaUnidadNavalComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<DiqueoCarenaUnidadNavalComfasDTO> diqueoCarenaUnidadNavalComfasDTO)
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
                            foreach (var item in diqueoCarenaUnidadNavalComfasDTO)
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
