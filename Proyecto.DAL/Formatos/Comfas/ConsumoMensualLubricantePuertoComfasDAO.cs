using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class ConsumoMensualLubricantePuertoComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsumoMensualLubricantePuertoComfasDTO> ObtenerLista()
        {
            List<ConsumoMensualLubricantePuertoComfasDTO> lista = new List<ConsumoMensualLubricantePuertoComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricantePuertoComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ConsumoMensualLubricantePuertoComfasDTO()
                        {
                            ConsumoMensualLubricantePuertoId = Convert.ToInt32(dr["ConsumoMensualLubricantePuertoId"]),
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

        public string AgregarRegistro(ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricantePuertoComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = consumoMensualLubricantePuertoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = consumoMensualLubricantePuertoComfasDTO.MesId;

                    cmd.Parameters.Add("@LubricanteMotores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteMotores"].Value = consumoMensualLubricantePuertoComfasDTO.LubricanteMotores;

                    cmd.Parameters.Add("@LubricanteReductores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteReductores"].Value = consumoMensualLubricantePuertoComfasDTO.LubricanteReductores;

                    cmd.Parameters.Add("@TotalMensual", SqlDbType.Int);
                    cmd.Parameters["@TotalMensual"].Value = consumoMensualLubricantePuertoComfasDTO.TotalMensual;

                    cmd.Parameters.Add("@TotalAnual", SqlDbType.Int);
                    cmd.Parameters["@TotalAnual"].Value = consumoMensualLubricantePuertoComfasDTO.TotalAnual;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualLubricantePuertoComfasDTO.UsuarioIngresoRegistro;

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

        public ConsumoMensualLubricantePuertoComfasDTO BuscarFormato(int Codigo)
        {
            ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO = new ConsumoMensualLubricantePuertoComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricantePuertoComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoMensualLubricantePuertoId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualLubricantePuertoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        consumoMensualLubricantePuertoComfasDTO.ConsumoMensualLubricantePuertoId = Convert.ToInt32(dr["ConsumoMensualLubricantePuertoId"]);
                        consumoMensualLubricantePuertoComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        consumoMensualLubricantePuertoComfasDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        consumoMensualLubricantePuertoComfasDTO.LubricanteMotores = Convert.ToInt32(dr["LubricanteMotores"]);
                        consumoMensualLubricantePuertoComfasDTO.LubricanteReductores = Convert.ToInt32(dr["LubricanteReductores"]);
                        consumoMensualLubricantePuertoComfasDTO.TotalMensual = Convert.ToInt32(dr["TotalMensual"]);
                        consumoMensualLubricantePuertoComfasDTO.TotalAnual = Convert.ToInt32(dr["TotalAnual"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consumoMensualLubricantePuertoComfasDTO;
        }

        public string ActualizaFormato(ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricantePuertoComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConsumoMensualLubricantePuertoId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualLubricantePuertoId"].Value = consumoMensualLubricantePuertoComfasDTO.ConsumoMensualLubricantePuertoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = consumoMensualLubricantePuertoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = consumoMensualLubricantePuertoComfasDTO.MesId;

                    cmd.Parameters.Add("@LubricanteMotores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteMotores"].Value = consumoMensualLubricantePuertoComfasDTO.LubricanteMotores;

                    cmd.Parameters.Add("@LubricanteReductores", SqlDbType.Int);
                    cmd.Parameters["@LubricanteReductores"].Value = consumoMensualLubricantePuertoComfasDTO.LubricanteReductores;

                    cmd.Parameters.Add("@TotalMensual", SqlDbType.Int);
                    cmd.Parameters["@TotalMensual"].Value = consumoMensualLubricantePuertoComfasDTO.TotalMensual;

                    cmd.Parameters.Add("@TotalAnual", SqlDbType.Int);
                    cmd.Parameters["@TotalAnual"].Value = consumoMensualLubricantePuertoComfasDTO.TotalAnual;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualLubricantePuertoComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoMensualLubricantePuertoComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoMensualLubricantePuertoId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoMensualLubricantePuertoId"].Value = consumoMensualLubricantePuertoComfasDTO.ConsumoMensualLubricantePuertoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoMensualLubricantePuertoComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ConsumoMensualLubricantePuertoComfasDTO> consumoMensualLubricantePuertoComfasDTO)
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
                            foreach (var item in consumoMensualLubricantePuertoComfasDTO)
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
