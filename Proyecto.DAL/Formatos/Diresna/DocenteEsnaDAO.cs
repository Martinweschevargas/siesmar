using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresna
{
    public class DocenteEsnaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DocenteEsnaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<DocenteEsnaDTO> lista = new List<DocenteEsnaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DocenteEsnaListar", conexion);
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
                        lista.Add(new DocenteEsnaDTO()
                        {
                            DocenteEsnaId = Convert.ToInt32(dr["DocenteEsnaId"]),
                            DNIDocenteEsna = dr["DNIDocenteEsna"].ToString(),
                            TipoDocente = dr["TipoDocente"].ToString(),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            DescRegimenLaboral = dr["DescRegimenLaboral"].ToString(),
                            DedicacionDocente = dr["DedicacionDocente"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            ExperienciaDocente = Convert.ToInt32(dr["ExperienciaDocente"]),
                            ExperienciaDocenteMarina = Convert.ToInt32(dr["ExperienciaDocenteMarina"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DocenteEsnaDTO docenteEsnaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocenteEsnaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIDocenteEsna", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIDocenteEsna"].Value = docenteEsnaDTO.DNIDocenteEsna;

                    cmd.Parameters.Add("@TipoDocente", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoDocente"].Value = docenteEsnaDTO.TipoDocente;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docenteEsnaDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = docenteEsnaDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar,50);
                    cmd.Parameters["@DedicacionDocente"].Value = docenteEsnaDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = docenteEsnaDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = docenteEsnaDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@ExperienciaDocente", SqlDbType.Int);
                    cmd.Parameters["@ExperienciaDocente"].Value = docenteEsnaDTO.ExperienciaDocente;

                    cmd.Parameters.Add("@ExperienciaDocenteMarina", SqlDbType.Int);
                    cmd.Parameters["@ExperienciaDocenteMarina"].Value = docenteEsnaDTO.ExperienciaDocenteMarina;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docenteEsnaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEsnaDTO.UsuarioIngresoRegistro;

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

        public DocenteEsnaDTO BuscarFormato(int Codigo)
        {
            DocenteEsnaDTO docenteEsnaDTO = new DocenteEsnaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteEsnaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteEsnaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteEsnaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        docenteEsnaDTO.DocenteEsnaId = Convert.ToInt32(dr["DocenteEsnaId"]);
                        docenteEsnaDTO.DNIDocenteEsna = dr["DNIDocenteEsna"].ToString();
                        docenteEsnaDTO.TipoDocente = dr["TipoDocente"].ToString();
                        docenteEsnaDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                        docenteEsnaDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaborar"].ToString();
                        docenteEsnaDTO.DedicacionDocente = dr["DedicacionDocente"].ToString();
                        docenteEsnaDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString();
                        docenteEsnaDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();
                        docenteEsnaDTO.ExperienciaDocente = Convert.ToInt32(dr["ExperienciaDocente"]);
                        docenteEsnaDTO.ExperienciaDocenteMarina = Convert.ToInt32(dr["ExperienciaDocenteMarina"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return docenteEsnaDTO;
        }

        public string ActualizaFormato(DocenteEsnaDTO docenteEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocenteEsnaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DocenteEsnaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteEsnaId"].Value = docenteEsnaDTO.DocenteEsnaId;

                    cmd.Parameters.Add("@DNIDocenteEsna", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIDocenteEsna"].Value = docenteEsnaDTO.DNIDocenteEsna;

                    cmd.Parameters.Add("@TipoDocente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoDocente"].Value = docenteEsnaDTO.TipoDocente;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docenteEsnaDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = docenteEsnaDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DedicacionDocente"].Value = docenteEsnaDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = docenteEsnaDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = docenteEsnaDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@ExperienciaDocente", SqlDbType.Int);
                    cmd.Parameters["@ExperienciaDocente"].Value = docenteEsnaDTO.ExperienciaDocente;

                    cmd.Parameters.Add("@ExperienciaDocenteMarina", SqlDbType.Int);
                    cmd.Parameters["@ExperienciaDocenteMarina"].Value = docenteEsnaDTO.ExperienciaDocenteMarina;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEsnaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DocenteEsnaDTO docenteEsnaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteEsnaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteEsnaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteEsnaId"].Value = docenteEsnaDTO.DocenteEsnaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEsnaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(DocenteEsnaDTO docenteEsnaDTO)
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
                    cmd.Parameters["@Formato"].Value = "DocenteEsna";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docenteEsnaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEsnaDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha )
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_DocenteEsnaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteEsna", SqlDbType.Structured);
                    cmd.Parameters["@DocenteEsna"].TypeName = "Formato.DocenteEsna";
                    cmd.Parameters["@DocenteEsna"].Value = datos;

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

