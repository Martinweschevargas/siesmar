using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dipermar
{
    public class DesarrolloAccionesClimaLaboralDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DesarrolloAccionesClimaLaboralDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<DesarrolloAccionesClimaLaboralDTO> lista = new List<DesarrolloAccionesClimaLaboralDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DesarrolloAccionesClimaLaboralListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DesarrolloAccionesClimaLaboralDTO()
                        {
                            DesarrolloAccionClimaLaboralId = Convert.ToInt32(dr["DesarrolloAccionClimaLaboralId"]),
                            DescActClimaLaboralGeneral = dr["DescActClimaLaboralGeneral"].ToString(),
                            DescActClimaLaboralEspecifica = dr["DescActClimaLaboralEspecifica"].ToString(),
                            TematicaActividad = dr["TematicaActividad"].ToString(),
                            LugarActividad = dr["LugarActividad"].ToString(),
                            FechaInicioActividad = (dr["FechaInicioActividad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoActividad = (dr["FechaTerminoActividad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NroHorasActividad = Convert.ToInt32(dr["NroHorasActividad"]),
                            NumeroPersonalSuperior = Convert.ToInt32(dr["NumeroPersonalSuperior"]),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            NroPersonalSubalterno = Convert.ToInt32(dr["NroPersonalSubalterno"]),
                            NroPersonalMarineria = Convert.ToInt32(dr["NroPersonalMarineria"]),
                            NroPersonalCivil = Convert.ToInt32(dr["NroPersonalCivil"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DesarrolloAccionesClimaLaboralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoActClimaLaboralGeneral", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoActClimaLaboralGeneral"].Value = desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralGeneral;

                    cmd.Parameters.Add("@CodigoActClimaLaboralEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActClimaLaboralEspecifica"].Value = desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralEspecifica;

                    cmd.Parameters.Add("@TematicaActividad", SqlDbType.VarChar,100);
                    cmd.Parameters["@TematicaActividad"].Value = desarrolloAccionesClimaLaboralDTO.TematicaActividad;

                    cmd.Parameters.Add("@LugarActividad", SqlDbType.VarChar,50);
                    cmd.Parameters["@LugarActividad"].Value = desarrolloAccionesClimaLaboralDTO.LugarActividad;

                    cmd.Parameters.Add("@FechaInicioActividad", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioActividad"].Value = desarrolloAccionesClimaLaboralDTO.FechaInicioActividad;

                    cmd.Parameters.Add("@FechaTerminoActividad", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoActividad"].Value = desarrolloAccionesClimaLaboralDTO.FechaTerminoActividad;

                    cmd.Parameters.Add("@NroHorasActividad", SqlDbType.Int);
                    cmd.Parameters["@NroHorasActividad"].Value = desarrolloAccionesClimaLaboralDTO.NroHorasActividad;

                    cmd.Parameters.Add("@NumeroPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalSuperior"].Value = desarrolloAccionesClimaLaboralDTO.NumeroPersonalSuperior;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = desarrolloAccionesClimaLaboralDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NroPersonalSubalterno", SqlDbType.Int);
                    cmd.Parameters["@NroPersonalSubalterno"].Value = desarrolloAccionesClimaLaboralDTO.NroPersonalSubalterno;

                    cmd.Parameters.Add("@NroPersonalMarineria", SqlDbType.Int);
                    cmd.Parameters["@NroPersonalMarineria"].Value = desarrolloAccionesClimaLaboralDTO.NroPersonalMarineria;

                    cmd.Parameters.Add("@NroPersonalCivil", SqlDbType.Int);
                    cmd.Parameters["@NroPersonalCivil"].Value = desarrolloAccionesClimaLaboralDTO.NroPersonalCivil;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = desarrolloAccionesClimaLaboralDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public DesarrolloAccionesClimaLaboralDTO BuscarFormato(int Codigo)
        {
            DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO = new DesarrolloAccionesClimaLaboralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DesarrolloAccionesClimaLaboralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DesarrolloAccionClimaLaboralId", SqlDbType.Int);
                    cmd.Parameters["@DesarrolloAccionClimaLaboralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        desarrolloAccionesClimaLaboralDTO.DesarrolloAccionClimaLaboralId = Convert.ToInt32(dr["DesarrolloAccionClimaLaboralId"]);
                        desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralGeneral = dr["CodigoActClimaLaboralGeneral"].ToString();
                        desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralEspecifica = dr["CodigoActClimaLaboralEspecifica"].ToString();
                        desarrolloAccionesClimaLaboralDTO.TematicaActividad = dr["TematicaActividad"].ToString();
                        desarrolloAccionesClimaLaboralDTO.LugarActividad = dr["LugarActividad"].ToString();
                        desarrolloAccionesClimaLaboralDTO.FechaInicioActividad = Convert.ToDateTime(dr["FechaInicioActividad"]).ToString("yyy-MM-dd");
                        desarrolloAccionesClimaLaboralDTO.FechaTerminoActividad = Convert.ToDateTime(dr["FechaTerminoActividad"]).ToString("yyy-MM-dd");
                        desarrolloAccionesClimaLaboralDTO.NroHorasActividad = Convert.ToInt32(dr["NroHorasActividad"]);
                        desarrolloAccionesClimaLaboralDTO.NumeroPersonalSuperior = Convert.ToInt32(dr["NumeroPersonalSuperior"]);
                        desarrolloAccionesClimaLaboralDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        desarrolloAccionesClimaLaboralDTO.NroPersonalSubalterno = Convert.ToInt32(dr["NroPersonalSubalterno"]);
                        desarrolloAccionesClimaLaboralDTO.NroPersonalMarineria = Convert.ToInt32(dr["NroPersonalMarineria"]);
                        desarrolloAccionesClimaLaboralDTO.NroPersonalCivil = Convert.ToInt32(dr["NroPersonalCivil"]); 
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return desarrolloAccionesClimaLaboralDTO;
        }

        public string ActualizaFormato(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DesarrolloAccionesClimaLaboralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DesarrolloAccionClimaLaboralId", SqlDbType.Int);
                    cmd.Parameters["@DesarrolloAccionClimaLaboralId"].Value = desarrolloAccionesClimaLaboralDTO.DesarrolloAccionClimaLaboralId;

                    cmd.Parameters.Add("@CodigoActClimaLaboralGeneral", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoActClimaLaboralGeneral"].Value = desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralGeneral;

                    cmd.Parameters.Add("@CodigoActClimaLaboralEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActClimaLaboralEspecifica"].Value = desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralEspecifica;

                    cmd.Parameters.Add("@TematicaActividad", SqlDbType.VarChar, 100);
                    cmd.Parameters["@TematicaActividad"].Value = desarrolloAccionesClimaLaboralDTO.TematicaActividad;

                    cmd.Parameters.Add("@LugarActividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@LugarActividad"].Value = desarrolloAccionesClimaLaboralDTO.LugarActividad;

                    cmd.Parameters.Add("@FechaInicioActividad", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioActividad"].Value = desarrolloAccionesClimaLaboralDTO.FechaInicioActividad;

                    cmd.Parameters.Add("@FechaTerminoActividad", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoActividad"].Value = desarrolloAccionesClimaLaboralDTO.FechaTerminoActividad;

                    cmd.Parameters.Add("@NroHorasActividad", SqlDbType.Int);
                    cmd.Parameters["@NroHorasActividad"].Value = desarrolloAccionesClimaLaboralDTO.NroHorasActividad;

                    cmd.Parameters.Add("@NumeroPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalSuperior"].Value = desarrolloAccionesClimaLaboralDTO.NumeroPersonalSuperior;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = desarrolloAccionesClimaLaboralDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NroPersonalSubalterno", SqlDbType.Int);
                    cmd.Parameters["@NroPersonalSubalterno"].Value = desarrolloAccionesClimaLaboralDTO.NroPersonalSubalterno;

                    cmd.Parameters.Add("@NroPersonalMarineria", SqlDbType.Int);
                    cmd.Parameters["@NroPersonalMarineria"].Value = desarrolloAccionesClimaLaboralDTO.NroPersonalMarineria;

                    cmd.Parameters.Add("@NroPersonalCivil", SqlDbType.Int);
                    cmd.Parameters["@NroPersonalCivil"].Value = desarrolloAccionesClimaLaboralDTO.NroPersonalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DesarrolloAccionesClimaLaboralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DesarrolloAccionClimaLaboralId", SqlDbType.Int);
                    cmd.Parameters["@DesarrolloAccionClimaLaboralId"].Value = desarrolloAccionesClimaLaboralDTO.DesarrolloAccionClimaLaboralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "DesarrolloAccionesClimaLaboral";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = desarrolloAccionesClimaLaboralDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_DesarrolloAccionesClimaLaboralRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DesarrolloAccionesClimaLaboral", SqlDbType.Structured);
                    cmd.Parameters["@DesarrolloAccionesClimaLaboral"].TypeName = "Formato.DesarrolloAccionesClimaLaboral";
                    cmd.Parameters["@DesarrolloAccionesClimaLaboral"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
