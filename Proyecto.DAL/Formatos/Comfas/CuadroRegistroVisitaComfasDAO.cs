using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class CuadroRegistroVisitaComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CuadroRegistroVisitaComfasDTO> ObtenerLista()
        {
            List<CuadroRegistroVisitaComfasDTO> lista = new List<CuadroRegistroVisitaComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CuadroRegistroVisitaComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CuadroRegistroVisitaComfasDTO()
                        {
                            CuadroRegistroVisitaComfasId = Convert.ToInt32(dr["CuadroRegistroVisitaComfasId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaVisita = (dr["FechaVisita"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraIngreso = dr["HoraIngreso"].ToString(),
                            HoraSalida = dr["HoraSalida"].ToString(),
                            DNIVisitante = Convert.ToInt32(dr["DNIVisitante"]),
                            PasaporteVisitante = Convert.ToInt32(dr["PasaporteVisitante"]),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescClaseVisita = dr["DescClaseVisita"].ToString(),
                            MotivoViaje = dr["MotivoViaje"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroRegistroVisitaComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = cuadroRegistroVisitaComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaVisita", SqlDbType.Date);
                    cmd.Parameters["@FechaVisita"].Value = cuadroRegistroVisitaComfasDTO.FechaVisita;

                    cmd.Parameters.Add("@HoraIngreso", SqlDbType.Time);
                    cmd.Parameters["@HoraIngreso"].Value = cuadroRegistroVisitaComfasDTO.HoraIngreso;

                    cmd.Parameters.Add("@HoraSalida", SqlDbType.Time);
                    cmd.Parameters["@HoraSalida"].Value = cuadroRegistroVisitaComfasDTO.HoraSalida;

                    cmd.Parameters.Add("@DNIVisitante", SqlDbType.Int);
                    cmd.Parameters["@DNIVisitante"].Value = cuadroRegistroVisitaComfasDTO.DNIVisitante;

                    cmd.Parameters.Add("@PasaporteVisitante", SqlDbType.Int);
                    cmd.Parameters["@PasaporteVisitante"].Value = cuadroRegistroVisitaComfasDTO.PasaporteVisitante;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = cuadroRegistroVisitaComfasDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@ClaseVisitaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVisitaId"].Value = cuadroRegistroVisitaComfasDTO.ClaseVisitaId;

                    cmd.Parameters.Add("@MotivoViaje", SqlDbType.VarChar,100);
                    cmd.Parameters["@MotivoViaje"].Value = cuadroRegistroVisitaComfasDTO.MotivoViaje;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroRegistroVisitaComfasDTO.UsuarioIngresoRegistro;

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

        public CuadroRegistroVisitaComfasDTO BuscarFormato(int Codigo)
        {
            CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO = new CuadroRegistroVisitaComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroRegistroVisitaComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroRegistroVisitaComfasId", SqlDbType.Int);
                    cmd.Parameters["@CuadroRegistroVisitaComfasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cuadroRegistroVisitaComfasDTO.CuadroRegistroVisitaComfasId = Convert.ToInt32(dr["CuadroRegistroVisitaComfasId"]);
                        cuadroRegistroVisitaComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        cuadroRegistroVisitaComfasDTO.FechaVisita = Convert.ToDateTime(dr["FechaVisita"]).ToString("yyy-MM-dd");
                        cuadroRegistroVisitaComfasDTO.HoraIngreso = dr["HoraIngreso"].ToString();
                        cuadroRegistroVisitaComfasDTO.HoraSalida = dr["HoraSalida"].ToString();
                        cuadroRegistroVisitaComfasDTO.DNIVisitante = Convert.ToInt32(dr["DNIVisitante"]);
                        cuadroRegistroVisitaComfasDTO.PasaporteVisitante = Convert.ToInt32(dr["PasaporteVisitante"]);
                        cuadroRegistroVisitaComfasDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        cuadroRegistroVisitaComfasDTO.ClaseVisitaId = Convert.ToInt32(dr["ClaseVisitaId"]);
                        cuadroRegistroVisitaComfasDTO.MotivoViaje = dr["MotivoViaje"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cuadroRegistroVisitaComfasDTO;
        }

        public string ActualizaFormato(CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CuadroRegistroVisitaComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CuadroRegistroVisitaComfasId", SqlDbType.Int);
                    cmd.Parameters["@CuadroRegistroVisitaComfasId"].Value = cuadroRegistroVisitaComfasDTO.CuadroRegistroVisitaComfasId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = cuadroRegistroVisitaComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaVisita", SqlDbType.Date);
                    cmd.Parameters["@FechaVisita"].Value = cuadroRegistroVisitaComfasDTO.FechaVisita;

                    cmd.Parameters.Add("@HoraIngreso", SqlDbType.Time);
                    cmd.Parameters["@HoraIngreso"].Value = cuadroRegistroVisitaComfasDTO.HoraIngreso;

                    cmd.Parameters.Add("@HoraSalida", SqlDbType.Time);
                    cmd.Parameters["@HoraSalida"].Value = cuadroRegistroVisitaComfasDTO.HoraSalida;

                    cmd.Parameters.Add("@DNIVisitante", SqlDbType.Int);
                    cmd.Parameters["@DNIVisitante"].Value = cuadroRegistroVisitaComfasDTO.DNIVisitante;

                    cmd.Parameters.Add("@PasaporteVisitante", SqlDbType.Int);
                    cmd.Parameters["@PasaporteVisitante"].Value = cuadroRegistroVisitaComfasDTO.PasaporteVisitante;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = cuadroRegistroVisitaComfasDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@ClaseVisitaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVisitaId"].Value = cuadroRegistroVisitaComfasDTO.ClaseVisitaId;

                    cmd.Parameters.Add("@MotivoViaje", SqlDbType.VarChar,100);
                    cmd.Parameters["@MotivoViaje"].Value = cuadroRegistroVisitaComfasDTO.MotivoViaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroRegistroVisitaComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroRegistroVisitaComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroRegistroVisitaComfasId", SqlDbType.Int);
                    cmd.Parameters["@CuadroRegistroVisitaComfasId"].Value = cuadroRegistroVisitaComfasDTO.CuadroRegistroVisitaComfasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroRegistroVisitaComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<CuadroRegistroVisitaComfasDTO> cuadroRegistroVisitaComfasDTO)
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
                            foreach (var item in cuadroRegistroVisitaComfasDTO)
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
