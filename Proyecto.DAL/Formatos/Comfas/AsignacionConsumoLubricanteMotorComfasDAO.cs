using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class AsignacionConsumoLubricanteMotorComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AsignacionConsumoLubricanteMotorComfasDTO> ObtenerLista()
        {
            List<AsignacionConsumoLubricanteMotorComfasDTO> lista = new List<AsignacionConsumoLubricanteMotorComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AsignacionConsumoLubricanteMotorComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AsignacionConsumoLubricanteMotorComfasDTO()
                        {
                            AsignacionConsumoLubricanteMotorId = Convert.ToInt32(dr["AsignacionConsumoLubricanteMotorId"]),
                            AnioAsignacion = Convert.ToInt32(dr["AnioAsignacion"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CapacidadMaximaAlmacen = Convert.ToInt32(dr["CapacidadMaximaAlmacen"]),
                            Asignado = Convert.ToInt32(dr["Asignado"]),
                            ConsumoTotalAnualPuerto = Convert.ToInt32(dr["ConsumoTotalAnualPuerto"]),
                            ConsumoTotalAnualNavegacion = Convert.ToInt32(dr["ConsumoTotalAnualNavegacion"]),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AsignacionConsumoLubricanteMotorComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioAsignacion", SqlDbType.Int);
                    cmd.Parameters["@AnioAsignacion"].Value = asignacionConsumoLubricanteMotorComfasDTO.AnioAsignacion;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = asignacionConsumoLubricanteMotorComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CapacidadMaximaAlmacen", SqlDbType.Int);
                    cmd.Parameters["@CapacidadMaximaAlmacen"].Value = asignacionConsumoLubricanteMotorComfasDTO.CapacidadMaximaAlmacen;

                    cmd.Parameters.Add("@Asignado", SqlDbType.Int);
                    cmd.Parameters["@Asignado"].Value = asignacionConsumoLubricanteMotorComfasDTO.Asignado;

                    cmd.Parameters.Add("@ConsumoTotalAnualPuerto", SqlDbType.Int);
                    cmd.Parameters["@ConsumoTotalAnualPuerto"].Value = asignacionConsumoLubricanteMotorComfasDTO.ConsumoTotalAnualPuerto;

                    cmd.Parameters.Add("@ConsumoTotalAnualNavegacion", SqlDbType.Int);
                    cmd.Parameters["@ConsumoTotalAnualNavegacion"].Value = asignacionConsumoLubricanteMotorComfasDTO.ConsumoTotalAnualNavegacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = asignacionConsumoLubricanteMotorComfasDTO.UsuarioIngresoRegistro;

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

        public AsignacionConsumoLubricanteMotorComfasDTO BuscarFormato(int Codigo)
        {
            AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO = new AsignacionConsumoLubricanteMotorComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AsignacionConsumoLubricanteMotorComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsignacionConsumoLubricanteMotorId", SqlDbType.Int);
                    cmd.Parameters["@AsignacionConsumoLubricanteMotorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        asignacionConsumoLubricanteMotorComfasDTO.AsignacionConsumoLubricanteMotorId = Convert.ToInt32(dr["AsignacionConsumoLubricanteMotorId"]);
                        asignacionConsumoLubricanteMotorComfasDTO.AnioAsignacion = Convert.ToInt32(dr["AnioAsignacion"]);
                        asignacionConsumoLubricanteMotorComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        asignacionConsumoLubricanteMotorComfasDTO.CapacidadMaximaAlmacen = Convert.ToInt32(dr["CapacidadMaximaAlmacen"]);
                        asignacionConsumoLubricanteMotorComfasDTO.Asignado = Convert.ToInt32(dr["Asignado"]);
                        asignacionConsumoLubricanteMotorComfasDTO.ConsumoTotalAnualPuerto = Convert.ToInt32(dr["ConsumoTotalAnualPuerto"]);
                        asignacionConsumoLubricanteMotorComfasDTO.ConsumoTotalAnualNavegacion = Convert.ToInt32(dr["ConsumoTotalAnualNavegacion"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return asignacionConsumoLubricanteMotorComfasDTO;
        }

        public string ActualizaFormato(AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AsignacionConsumoLubricanteMotorComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AsignacionConsumoLubricanteMotorId", SqlDbType.Int);
                    cmd.Parameters["@AsignacionConsumoLubricanteMotorId"].Value = asignacionConsumoLubricanteMotorComfasDTO.AsignacionConsumoLubricanteMotorId;

                    cmd.Parameters.Add("@AnioAsignacion", SqlDbType.Int);
                    cmd.Parameters["@AnioAsignacion"].Value = asignacionConsumoLubricanteMotorComfasDTO.AnioAsignacion;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = asignacionConsumoLubricanteMotorComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CapacidadMaximaAlmacen", SqlDbType.Int);
                    cmd.Parameters["@CapacidadMaximaAlmacen"].Value = asignacionConsumoLubricanteMotorComfasDTO.CapacidadMaximaAlmacen;

                    cmd.Parameters.Add("@Asignado", SqlDbType.Int);
                    cmd.Parameters["@Asignado"].Value = asignacionConsumoLubricanteMotorComfasDTO.Asignado;

                    cmd.Parameters.Add("@ConsumoTotalAnualPuerto", SqlDbType.Int);
                    cmd.Parameters["@ConsumoTotalAnualPuerto"].Value = asignacionConsumoLubricanteMotorComfasDTO.ConsumoTotalAnualPuerto;

                    cmd.Parameters.Add("@ConsumoTotalAnualNavegacion", SqlDbType.Int);
                    cmd.Parameters["@ConsumoTotalAnualNavegacion"].Value = asignacionConsumoLubricanteMotorComfasDTO.ConsumoTotalAnualNavegacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = asignacionConsumoLubricanteMotorComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AsignacionConsumoLubricanteMotorComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsignacionConsumoLubricanteMotorId", SqlDbType.Int);
                    cmd.Parameters["@AsignacionConsumoLubricanteMotorId"].Value = asignacionConsumoLubricanteMotorComfasDTO.AsignacionConsumoLubricanteMotorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = asignacionConsumoLubricanteMotorComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AsignacionConsumoLubricanteMotorComfasDTO> asignacionConsumoLubricanteMotorComfasDTO)
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
                            foreach (var item in asignacionConsumoLubricanteMotorComfasDTO)
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
