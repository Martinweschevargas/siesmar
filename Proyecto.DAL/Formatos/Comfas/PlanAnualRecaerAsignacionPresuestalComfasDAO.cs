using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class PlanAnualRecaerAsignacionPresuestalComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PlanAnualRecaerAsignacionPresuestalComfasDTO> ObtenerLista()
        {
            List<PlanAnualRecaerAsignacionPresuestalComfasDTO> lista = new List<PlanAnualRecaerAsignacionPresuestalComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PlanAnualRecaerAsignacionPresuestalComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PlanAnualRecaerAsignacionPresuestalComfasDTO()
                        {
                            PlanAnualRecaerAsignacionPresuestalId = Convert.ToInt32(dr["PlanAnualRecaerAsignacionPresuestalId"]),
                            AsignadoProgramaAnual = Convert.ToDecimal(dr["AsignadoProgramaAnual"]),
                            Bienes = Convert.ToDecimal(dr["Bienes"]),
                            Servicios = Convert.ToDecimal(dr["Servicios"]),
                            AsignadoAnual = Convert.ToDecimal(dr["AsignadoAnual"]),
                            GastosBienes = Convert.ToDecimal(dr["GastosBienes"]),
                            GastosServicios = Convert.ToDecimal(dr["GastosServicios"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerAsignacionPresuestalComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsignadoProgramaAnual", SqlDbType.Decimal);
                    cmd.Parameters["@AsignadoProgramaAnual"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.AsignadoProgramaAnual;

                    cmd.Parameters.Add("@Bienes", SqlDbType.Decimal);
                    cmd.Parameters["@Bienes"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.Bienes;

                    cmd.Parameters.Add("@Servicios", SqlDbType.Decimal);
                    cmd.Parameters["@Servicios"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.Servicios;

                    cmd.Parameters.Add("@AsignadoAnual", SqlDbType.Decimal);
                    cmd.Parameters["@AsignadoAnual"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.AsignadoAnual;

                    cmd.Parameters.Add("@GastosBienes", SqlDbType.Decimal);
                    cmd.Parameters["@GastosBienes"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.GastosBienes;

                    cmd.Parameters.Add("@GastosServicios", SqlDbType.Decimal);
                    cmd.Parameters["@GastosServicios"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.GastosServicios;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.UsuarioIngresoRegistro;

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

        public PlanAnualRecaerAsignacionPresuestalComfasDTO BuscarFormato(int Codigo)
        {
            PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO = new PlanAnualRecaerAsignacionPresuestalComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerAsignacionPresuestalComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualRecaerAsignacionPresuestalId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerAsignacionPresuestalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        planAnualRecaerAsignacionPresuestalComfasDTO.PlanAnualRecaerAsignacionPresuestalId = Convert.ToInt32(dr["PlanAnualRecaerAsignacionPresuestalId"]);
                        planAnualRecaerAsignacionPresuestalComfasDTO.AsignadoProgramaAnual = Convert.ToDecimal(dr["AsignadoProgramaAnual"]);
                        planAnualRecaerAsignacionPresuestalComfasDTO.Bienes = Convert.ToDecimal(dr["Bienes"]);
                        planAnualRecaerAsignacionPresuestalComfasDTO.Servicios = Convert.ToDecimal(dr["Servicios"]);
                        planAnualRecaerAsignacionPresuestalComfasDTO.AsignadoAnual = Convert.ToDecimal(dr["AsignadoAnual"]);
                        planAnualRecaerAsignacionPresuestalComfasDTO.GastosBienes = Convert.ToDecimal(dr["GastosBienes"]);
                        planAnualRecaerAsignacionPresuestalComfasDTO.GastosServicios = Convert.ToDecimal(dr["GastosServicios"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return planAnualRecaerAsignacionPresuestalComfasDTO;
        }

        public string ActualizaFormato(PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerAsignacionPresuestalComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PlanAnualRecaerAsignacionPresuestalId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerAsignacionPresuestalId"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.PlanAnualRecaerAsignacionPresuestalId;

                    cmd.Parameters.Add("@AsignadoProgramaAnual", SqlDbType.Decimal);
                    cmd.Parameters["@AsignadoProgramaAnual"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.AsignadoProgramaAnual;

                    cmd.Parameters.Add("@Bienes", SqlDbType.Decimal);
                    cmd.Parameters["@Bienes"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.Bienes;

                    cmd.Parameters.Add("@Servicios", SqlDbType.Decimal);
                    cmd.Parameters["@Servicios"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.Servicios;

                    cmd.Parameters.Add("@AsignadoAnual", SqlDbType.Decimal);
                    cmd.Parameters["@AsignadoAnual"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.AsignadoAnual;

                    cmd.Parameters.Add("@GastosBienes", SqlDbType.Decimal);
                    cmd.Parameters["@GastosBienes"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.GastosBienes;

                    cmd.Parameters.Add("@GastosServicios", SqlDbType.Decimal);
                    cmd.Parameters["@GastosServicios"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.GastosServicios;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PlanAnualRecaerAsignacionPresuestalComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlanAnualRecaerAsignacionPresuestalId", SqlDbType.Int);
                    cmd.Parameters["@PlanAnualRecaerAsignacionPresuestalId"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.PlanAnualRecaerAsignacionPresuestalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = planAnualRecaerAsignacionPresuestalComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<PlanAnualRecaerAsignacionPresuestalComfasDTO> planAnualRecaerAsignacionPresuestalComfasDTO)
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
                            foreach (var item in planAnualRecaerAsignacionPresuestalComfasDTO)
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
