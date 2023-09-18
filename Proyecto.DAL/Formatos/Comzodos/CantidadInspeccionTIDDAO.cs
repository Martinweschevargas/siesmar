using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzodos
{
    public class CantidadInspeccionTIDDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CantidadInspeccionTIDDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<CantidadInspeccionTIDDTO> lista = new List<CantidadInspeccionTIDDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CantidadInspeccionTIDListar", conexion);
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
                        lista.Add(new CantidadInspeccionTIDDTO()
                        {
                            CantidadInspeccionTIDId = Convert.ToInt32(dr["CantidadInspeccionTIDId"]),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            FechaHoraInicio = dr["FechaHoraInicio"].ToString(),
                            FechaHoraTermino = dr["FechaHoraTermino"].ToString(),
                            EfectivoParticipante = Convert.ToInt32(dr["EfectivoParticipante"]),
                            EfectivoUnidadCanina = Convert.ToInt32(dr["EfectivoUnidadCanina"]),
                            ObservacionInspeccionTID = dr["ObservacionInspeccionTID"].ToString(),
                            ComisionPorMes = Convert.ToInt32(dr["ComisionPorMes"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CantidadInspeccionTIDRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = cantidadInspeccionTIDDTO.FechaSolicitud;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = cantidadInspeccionTIDDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = cantidadInspeccionTIDDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = cantidadInspeccionTIDDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = cantidadInspeccionTIDDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@EfectivoParticipante", SqlDbType.Int);
                    cmd.Parameters["@EfectivoParticipante"].Value = cantidadInspeccionTIDDTO.EfectivoParticipante;

                    cmd.Parameters.Add("@EfectivoUnidadCanina", SqlDbType.Int);
                    cmd.Parameters["@EfectivoUnidadCanina"].Value = cantidadInspeccionTIDDTO.EfectivoUnidadCanina;

                    cmd.Parameters.Add("@ObservacionInspeccionTID", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionInspeccionTID"].Value = cantidadInspeccionTIDDTO.ObservacionInspeccionTID;

                    cmd.Parameters.Add("@ComisionPorMes", SqlDbType.Int);
                    cmd.Parameters["@ComisionPorMes"].Value = cantidadInspeccionTIDDTO.ComisionPorMes;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = cantidadInspeccionTIDDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cantidadInspeccionTIDDTO.UsuarioIngresoRegistro;

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

        public CantidadInspeccionTIDDTO BuscarFormato(int Codigo)
        {
            CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO = new CantidadInspeccionTIDDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CantidadInspeccionTIDEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CantidadInspeccionTIDId", SqlDbType.Int);
                    cmd.Parameters["@CantidadInspeccionTIDId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cantidadInspeccionTIDDTO.CantidadInspeccionTIDId = Convert.ToInt32(dr["CantidadInspeccionTIDId"]);
                        cantidadInspeccionTIDDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        cantidadInspeccionTIDDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        cantidadInspeccionTIDDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        cantidadInspeccionTIDDTO.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyy-MM-dd HH:mm:ss");
                        cantidadInspeccionTIDDTO.FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyy-MM-dd HH:mm:ss");
                        cantidadInspeccionTIDDTO.EfectivoParticipante = Convert.ToInt32(dr["EfectivoParticipante"]);
                        cantidadInspeccionTIDDTO.EfectivoUnidadCanina = Convert.ToInt32(dr["EfectivoUnidadCanina"]);
                        cantidadInspeccionTIDDTO.ObservacionInspeccionTID = dr["ObservacionInspeccionTID"].ToString();
                        cantidadInspeccionTIDDTO.ComisionPorMes = Convert.ToInt32(dr["ComisionPorMes"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cantidadInspeccionTIDDTO;
        }

        public string ActualizaFormato(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CantidadInspeccionTIDActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CantidadInspeccionTIDId", SqlDbType.Int);
                    cmd.Parameters["@CantidadInspeccionTIDId"].Value = cantidadInspeccionTIDDTO.CantidadInspeccionTIDId;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = cantidadInspeccionTIDDTO.FechaSolicitud;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = cantidadInspeccionTIDDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = cantidadInspeccionTIDDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = cantidadInspeccionTIDDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = cantidadInspeccionTIDDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@EfectivoParticipante", SqlDbType.Int);
                    cmd.Parameters["@EfectivoParticipante"].Value = cantidadInspeccionTIDDTO.EfectivoParticipante;

                    cmd.Parameters.Add("@EfectivoUnidadCanina", SqlDbType.Int);
                    cmd.Parameters["@EfectivoUnidadCanina"].Value = cantidadInspeccionTIDDTO.EfectivoUnidadCanina;

                    cmd.Parameters.Add("@ObservacionInspeccionTID", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionInspeccionTID"].Value = cantidadInspeccionTIDDTO.ObservacionInspeccionTID;

                    cmd.Parameters.Add("@ComisionPorMes", SqlDbType.Int);
                    cmd.Parameters["@ComisionPorMes"].Value = cantidadInspeccionTIDDTO.ComisionPorMes;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cantidadInspeccionTIDDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CantidadInspeccionTIDEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CantidadInspeccionTIDId", SqlDbType.Int);
                    cmd.Parameters["@CantidadInspeccionTIDId"].Value = cantidadInspeccionTIDDTO.CantidadInspeccionTIDId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cantidadInspeccionTIDDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO)
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
                    cmd.Parameters["@Formato"].Value = "CantidadInspeccionTID";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = cantidadInspeccionTIDDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cantidadInspeccionTIDDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CantidadInspeccionTIDRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CantidadInspeccionTID", SqlDbType.Structured);
                    cmd.Parameters["@CantidadInspeccionTID"].TypeName = "Formato.CantidadInspeccionTID";
                    cmd.Parameters["@CantidadInspeccionTID"].Value = datos;

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
