using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class ConsumoMensualLubricanteNavegacionComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsumoMensualLubricanteNavegacionComfasDTO> ObtenerLista()
        {
            List<ConsumoMensualLubricanteNavegacionComfasDTO> lista = new List<ConsumoMensualLubricanteNavegacionComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricanteNavegacionComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ConsumoMensualLubricanteNavegacionComfasDTO()
                        {
                            ConsumoMensualLubricanteNavegacionId = Convert.ToInt32(dr["ConsumoMensualLubricanteNavegacionId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescMes = dr["DescMes"].ToString(),
                            LubricanteMotores = Convert.ToInt32(dr["LubricanteMotores"]),
                            LubricanteReductores = Convert.ToInt32(dr["LubricanteReductores"]),
                            TotalMensual = Convert.ToInt32(dr["TotalMensual"]),
                            TotalAnual = Convert.ToInt32(dr["TotalAnual"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricanteNavegacionComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = consumoMensualLubricanteNavegacionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = consumoMensualLubricanteNavegacionComfasDTO.MesId;

                    cmd.Parameters.Add("@LubricanteMotores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteMotores"].Value = consumoMensualLubricanteNavegacionComfasDTO.LubricanteMotores;

                    cmd.Parameters.Add("@LubricanteReductores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteReductores"].Value = consumoMensualLubricanteNavegacionComfasDTO.LubricanteReductores;

                    cmd.Parameters.Add("@TotalMensual", SqlDbType.Int);
                    cmd.Parameters["@TotalMensual"].Value = consumoMensualLubricanteNavegacionComfasDTO.TotalMensual;

                    cmd.Parameters.Add("@TotalAnual", SqlDbType.Int);
                    cmd.Parameters["@TotalAnual"].Value = consumoMensualLubricanteNavegacionComfasDTO.TotalAnual;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualLubricanteNavegacionComfasDTO.UsuarioIngresoRegistro;

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

        public ConsumoMensualLubricanteNavegacionComfasDTO BuscarFormato(int Codigo)
        {
            ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO = new ConsumoMensualLubricanteNavegacionComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricanteNavegacionComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoMensualLubricanteNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualLubricanteNavegacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        consumoMensualLubricanteNavegacionComfasDTO.ConsumoMensualLubricanteNavegacionId = Convert.ToInt32(dr["ConsumoMensualLubricanteNavegacionId"]);
                        consumoMensualLubricanteNavegacionComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        consumoMensualLubricanteNavegacionComfasDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        consumoMensualLubricanteNavegacionComfasDTO.LubricanteMotores = Convert.ToInt32(dr["LubricanteMotores"]);
                        consumoMensualLubricanteNavegacionComfasDTO.LubricanteReductores = Convert.ToInt32(dr["LubricanteReductores"]);
                        consumoMensualLubricanteNavegacionComfasDTO.TotalMensual = Convert.ToInt32(dr["TotalMensual"]);
                        consumoMensualLubricanteNavegacionComfasDTO.TotalAnual = Convert.ToInt32(dr["TotalAnual"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consumoMensualLubricanteNavegacionComfasDTO;
        }

        public string ActualizaFormato(ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricanteNavegacionComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConsumoMensualLubricanteNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualLubricanteNavegacionId"].Value = consumoMensualLubricanteNavegacionComfasDTO.ConsumoMensualLubricanteNavegacionId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = consumoMensualLubricanteNavegacionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = consumoMensualLubricanteNavegacionComfasDTO.MesId;

                    cmd.Parameters.Add("@LubricanteMotores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteMotores"].Value = consumoMensualLubricanteNavegacionComfasDTO.LubricanteMotores;

                    cmd.Parameters.Add("@LubricanteReductores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteReductores"].Value = consumoMensualLubricanteNavegacionComfasDTO.LubricanteReductores;

                    cmd.Parameters.Add("@TotalMensual", SqlDbType.Int);
                    cmd.Parameters["@TotalMensual"].Value = consumoMensualLubricanteNavegacionComfasDTO.TotalMensual;

                    cmd.Parameters.Add("@TotalAnual", SqlDbType.Int);
                    cmd.Parameters["@TotalAnual"].Value = consumoMensualLubricanteNavegacionComfasDTO.TotalAnual;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualLubricanteNavegacionComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricanteNavegacionComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoMensualLubricanteNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualLubricanteNavegacionId"].Value = consumoMensualLubricanteNavegacionComfasDTO.ConsumoMensualLubricanteNavegacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualLubricanteNavegacionComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ConsumoMensualLubricanteNavegacionComfasDTO> consumoMensualLubricanteNavegacionComfasDTO)
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
                            foreach (var item in consumoMensualLubricanteNavegacionComfasDTO)
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
