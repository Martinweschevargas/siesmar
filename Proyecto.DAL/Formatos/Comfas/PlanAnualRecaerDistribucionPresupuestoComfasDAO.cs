using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class PlanAnualRecaerDistribucionPresupuestoComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PlanAnualRecaerDistribucionPresupuestoComfasDTO> ObtenerLista()
        {
            List<PlanAnualRecaerDistribucionPresupuestoComfasDTO> lista = new List<PlanAnualRecaerDistribucionPresupuestoComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PlanAnualRecaerDistribucionPresupuestoComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PlanAnualRecaerDistribucionPresupuestoComfasDTO()
                        {
                            PlanAnualRecaerDistribucionPresupuestoId = Convert.ToInt32(dr["PlanAnualRecaerDistribucionPresupuestoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            TotalAsignadoDependencia = Convert.ToInt32(dr["TotalAsignadoDependencia"]),
                            ServicioSimac = Convert.ToDecimal(dr["ServicioSimac"]),
                            ServicioIndustriaPrivada = Convert.ToDecimal(dr["ServicioIndustriaPrivada"]),
                            AdquisicionRepuestos = Convert.ToDecimal(dr["AdquisicionRepuestos"]),
                            Equipos = Convert.ToDecimal(dr["Equipos"]),
                            PorcentajeAvanceEjecucion = Convert.ToDecimal(dr["PorcentajeAvanceEjecucion"]),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerDistribucionPresupuestoComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualRecaerDistribucionPresupuestoId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerDistribucionPresupuestoId"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.PlanAnualRecaerDistribucionPresupuestoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@TotalAsignadoDependencia", SqlDbType.Int);
                    cmd.Parameters["@TotalAsignadoDependencia"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.TotalAsignadoDependencia;

                    cmd.Parameters.Add("@ServicioSimac", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioSimac"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.ServicioSimac;

                    cmd.Parameters.Add("@ServicioIndustriaPrivada", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioIndustriaPrivada"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.ServicioIndustriaPrivada;

                    cmd.Parameters.Add("@AdquisicionRepuestos", SqlDbType.Decimal);
                    cmd.Parameters["@AdquisicionRepuestos"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.AdquisicionRepuestos;

                    cmd.Parameters.Add("@Equipos", SqlDbType.Decimal);
                    cmd.Parameters["@Equipos"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.Equipos;

                    cmd.Parameters.Add("@PorcentajeAvanceEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeAvanceEjecucion"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.PorcentajeAvanceEjecucion;


                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.UsuarioIngresoRegistro;

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

        public PlanAnualRecaerDistribucionPresupuestoComfasDTO BuscarFormato(int Codigo)
        {
            PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO = new PlanAnualRecaerDistribucionPresupuestoComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerDistribucionPresupuestoComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualRecaerDistribucionPresupuestoId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerDistribucionPresupuestoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        planAnualRecaerDistribucionPresupuestoComfasDTO.PlanAnualRecaerDistribucionPresupuestoId = Convert.ToInt32(dr["PlanAnualRecaerDistribucionPresupuestoId"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.TotalAsignadoDependencia = Convert.ToInt32(dr["TotalAsignadoDependencia"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.ServicioSimac = Convert.ToDecimal(dr["ServicioSimac"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.ServicioIndustriaPrivada = Convert.ToDecimal(dr["ServicioIndustriaPrivada"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.AdquisicionRepuestos = Convert.ToDecimal(dr["AdquisicionRepuestos"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.Equipos = Convert.ToDecimal(dr["Equipos"]);
                        planAnualRecaerDistribucionPresupuestoComfasDTO.PorcentajeAvanceEjecucion = Convert.ToDecimal(dr["PorcentajeAvanceEjecucion"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return planAnualRecaerDistribucionPresupuestoComfasDTO;
        }

        public string ActualizaFormato(PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerDistribucionPresupuestoComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PlanAnualRecaerDistribucionPresupuestoId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerDistribucionPresupuestoId"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.PlanAnualRecaerDistribucionPresupuestoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@TotalAsignadoDependencia", SqlDbType.Int);
                    cmd.Parameters["@TotalAsignadoDependencia"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.TotalAsignadoDependencia;

                    cmd.Parameters.Add("@ServicioSimac", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioSimac"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.ServicioSimac;

                    cmd.Parameters.Add("@ServicioIndustriaPrivada", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioIndustriaPrivada"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.ServicioIndustriaPrivada;

                    cmd.Parameters.Add("@AdquisicionRepuestos", SqlDbType.Decimal);
                    cmd.Parameters["@AdquisicionRepuestos"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.AdquisicionRepuestos;

                    cmd.Parameters.Add("@Equipos", SqlDbType.Decimal);
                    cmd.Parameters["@Equipos"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.Equipos;

                    cmd.Parameters.Add("@PorcentajeAvanceEjecucion", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeAvanceEjecucion"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.PorcentajeAvanceEjecucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerDistribucionPresupuestoComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualRecaerDistribucionPresupuestoId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerDistribucionPresupuestoId"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.PlanAnualRecaerDistribucionPresupuestoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualRecaerDistribucionPresupuestoComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<PlanAnualRecaerDistribucionPresupuestoComfasDTO> planAnualRecaerDistribucionPresupuestoComfasDTO)
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
                            foreach (var item in planAnualRecaerDistribucionPresupuestoComfasDTO)
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
