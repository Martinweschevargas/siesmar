using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dircapen;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dircapen
{
    public class DocentesCapacitacionPerfeccionamientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DocentesCapacitacionPerfeccionamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<DocentesCapacitacionPerfeccionamientoDTO> lista = new List<DocentesCapacitacionPerfeccionamientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DocenteCapacitacionPerfeccionamientoListar", conexion);
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
                        lista.Add(new DocentesCapacitacionPerfeccionamientoDTO()
                        {
                            DocenteCapacitacionPerfeccionamientoId = Convert.ToInt32(dr["DocenteCapacitacionPerfeccionamientoId"]),
                            DNIDocente = dr["DNIDocente"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            DescRegimenLaboral = dr["DescRegimenLaboral"].ToString(),
                            DedicacionDocente = dr["DedicacionDocente"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteCapacitacionPerfeccionamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIDocente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIDocente"].Value = docentesCapacitacionPerfecDTO.DNIDocente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = docentesCapacitacionPerfecDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docentesCapacitacionPerfecDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = docentesCapacitacionPerfecDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar,250);
                    cmd.Parameters["@DedicacionDocente"].Value = docentesCapacitacionPerfecDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = docentesCapacitacionPerfecDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = docentesCapacitacionPerfecDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docentesCapacitacionPerfecDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro;

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

        public DocentesCapacitacionPerfeccionamientoDTO BuscarFormato(int Codigo)
        {
            DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO = new DocentesCapacitacionPerfeccionamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteCapacitacionPerfeccionamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteCapacitacionPerfeccionamientoId", SqlDbType.Int);
                    cmd.Parameters["@DocenteCapacitacionPerfeccionamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        docentesCapacitacionPerfecDTO.DocenteCapacitacionPerfeccionamientoId = Convert.ToInt32(dr["DocenteCapacitacionPerfeccionamientoId"]);
                        docentesCapacitacionPerfecDTO.DNIDocente = dr["DNIDocente"].ToString();
                        docentesCapacitacionPerfecDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        docentesCapacitacionPerfecDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                        docentesCapacitacionPerfecDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString();
                        docentesCapacitacionPerfecDTO.DedicacionDocente = dr["DedicacionDocente"].ToString();
                        docentesCapacitacionPerfecDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString();
                        docentesCapacitacionPerfecDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return docentesCapacitacionPerfecDTO;
        }

        public string ActualizaFormato(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocenteCapacitacionPerfeccionamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DocenteCapacitacionPerfeccionamientoId", SqlDbType.Int);
                    cmd.Parameters["@DocenteCapacitacionPerfeccionamientoId"].Value = docentesCapacitacionPerfecDTO.DocenteCapacitacionPerfeccionamientoId;

                    cmd.Parameters.Add("@DNIDocente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIDocente"].Value = docentesCapacitacionPerfecDTO.DNIDocente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = docentesCapacitacionPerfecDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docentesCapacitacionPerfecDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = docentesCapacitacionPerfecDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar, 250);
                    cmd.Parameters["@DedicacionDocente"].Value = docentesCapacitacionPerfecDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = docentesCapacitacionPerfecDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = docentesCapacitacionPerfecDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteCapacitacionPerfeccionamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteCapacitacionPerfeccionamientoId", SqlDbType.Int);
                    cmd.Parameters["@DocenteCapacitacionPerfeccionamientoId"].Value = docentesCapacitacionPerfecDTO.DocenteCapacitacionPerfeccionamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO)
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
                    cmd.Parameters["@Formato"].Value = "DocenteCapacitacionPerfeccionamiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docentesCapacitacionPerfecDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DocenteCapacitacionPerfeccionamientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteCapacitacionPerfeccionamiento", SqlDbType.Structured);
                    cmd.Parameters["@DocenteCapacitacionPerfeccionamiento"].TypeName = "Formato.DocenteCapacitacionPerfeccionamiento";
                    cmd.Parameters["@DocenteCapacitacionPerfeccionamiento"].Value = datos;

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