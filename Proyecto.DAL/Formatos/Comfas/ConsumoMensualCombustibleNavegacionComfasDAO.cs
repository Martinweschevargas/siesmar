using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class ConsumoMensualCombustibleNavegacionComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsumoMensualCombustibleNavegacionComfasDTO> ObtenerLista()
        {
            List<ConsumoMensualCombustibleNavegacionComfasDTO> lista = new List<ConsumoMensualCombustibleNavegacionComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsumoMensualCombustibleNavegacionComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ConsumoMensualCombustibleNavegacionComfasDTO()
                        {
                            ConsumoMensualCombustibleNavegacionId = Convert.ToInt32(dr["ConsumoMensualCombustibleNavegacionId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescMes = dr["DescMes"].ToString(),
                            TotalMensual = Convert.ToInt32(dr["TotalMensual"]),
                            TotalAnual = Convert.ToInt32(dr["TotalAnual"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualCombustibleNavegacionComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = consumoMensualCombustibleNavegacionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = consumoMensualCombustibleNavegacionComfasDTO.MesId;

                    cmd.Parameters.Add("@TotalMensual", SqlDbType.Int);
                    cmd.Parameters["@TotalMensual"].Value = consumoMensualCombustibleNavegacionComfasDTO.TotalMensual;

                    cmd.Parameters.Add("@TotalAnual", SqlDbType.Int);
                    cmd.Parameters["@TotalAnual"].Value = consumoMensualCombustibleNavegacionComfasDTO.TotalAnual;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualCombustibleNavegacionComfasDTO.UsuarioIngresoRegistro;

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

        public ConsumoMensualCombustibleNavegacionComfasDTO BuscarFormato(int Codigo)
        {
            ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO = new ConsumoMensualCombustibleNavegacionComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualCombustibleNavegacionComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoMensualCombustibleNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualCombustibleNavegacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        consumoMensualCombustibleNavegacionComfasDTO.ConsumoMensualCombustibleNavegacionId = Convert.ToInt32(dr["ConsumoMensualCombustibleNavegacionId"]);
                        consumoMensualCombustibleNavegacionComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        consumoMensualCombustibleNavegacionComfasDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        consumoMensualCombustibleNavegacionComfasDTO.TotalMensual = Convert.ToInt32(dr["TotalMensual"]);
                        consumoMensualCombustibleNavegacionComfasDTO.TotalAnual = Convert.ToInt32(dr["TotalAnual"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consumoMensualCombustibleNavegacionComfasDTO;
        }

        public string ActualizaFormato(ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsumoMensualCombustibleNavegacionComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConsumoMensualCombustibleNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualCombustibleNavegacionId"].Value = consumoMensualCombustibleNavegacionComfasDTO.ConsumoMensualCombustibleNavegacionId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = consumoMensualCombustibleNavegacionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = consumoMensualCombustibleNavegacionComfasDTO.MesId;

                    cmd.Parameters.Add("@TotalMensual", SqlDbType.Int);
                    cmd.Parameters["@TotalMensual"].Value = consumoMensualCombustibleNavegacionComfasDTO.TotalMensual;

                    cmd.Parameters.Add("@TotalAnual", SqlDbType.Int);
                    cmd.Parameters["@TotalAnual"].Value = consumoMensualCombustibleNavegacionComfasDTO.TotalAnual;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualCombustibleNavegacionComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualCombustibleNavegacionComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoMensualCombustibleNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualCombustibleNavegacionId"].Value = consumoMensualCombustibleNavegacionComfasDTO.ConsumoMensualCombustibleNavegacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualCombustibleNavegacionComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ConsumoMensualCombustibleNavegacionComfasDTO> consumoMensualCombustibleNavegacionComfasDTO)
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
                            foreach (var item in consumoMensualCombustibleNavegacionComfasDTO)
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
