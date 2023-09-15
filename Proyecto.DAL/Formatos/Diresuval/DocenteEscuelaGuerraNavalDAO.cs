using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresuval;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresuval
{
    public class DocenteEscuelaGuerraNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DocenteEscuelaGuerraNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<DocenteEscuelaGuerraNavalDTO> lista = new List<DocenteEscuelaGuerraNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DocenteEscuelaGuerraNavalListar", conexion);
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
                        lista.Add(new DocenteEscuelaGuerraNavalDTO()
                        {
                            DocenteEscuelaGuerraNavalId = Convert.ToInt32(dr["DocenteEscuelaGuerraNavalId"]),
                            DNIDocenteEscuela = dr["DNIDocenteEscuela"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            DescRegimenLaboral = dr["DescRegimenLaboral"].ToString(),
                            DedicacionDocente = dr["DedicacionDocente"].ToString(),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteEscuelaGuerraNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIDocenteEscuela", SqlDbType.Int);
                    cmd.Parameters["@DNIDocenteEscuela"].Value = docenteEscuelaGuerraNavalDTO.DNIDocenteEscuela;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = docenteEscuelaGuerraNavalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docenteEscuelaGuerraNavalDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = docenteEscuelaGuerraNavalDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar,50);
                    cmd.Parameters["@DedicacionDocente"].Value = docenteEscuelaGuerraNavalDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = docenteEscuelaGuerraNavalDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = docenteEscuelaGuerraNavalDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docenteEscuelaGuerraNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro;

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

        public DocenteEscuelaGuerraNavalDTO BuscarFormato(int Codigo)
        {
            DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO = new DocenteEscuelaGuerraNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteEscuelaGuerraNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteEscuelaGuerraNavalId", SqlDbType.Int);
                    cmd.Parameters["@DocenteEscuelaGuerraNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        docenteEscuelaGuerraNavalDTO.DocenteEscuelaGuerraNavalId = Convert.ToInt32(dr["DocenteEscuelaGuerraNavalId"]);
                        docenteEscuelaGuerraNavalDTO.DNIDocenteEscuela = dr["DNIDocenteEscuela"].ToString();
                        docenteEscuelaGuerraNavalDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        docenteEscuelaGuerraNavalDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                        docenteEscuelaGuerraNavalDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString();
                        docenteEscuelaGuerraNavalDTO.DedicacionDocente = dr["DedicacionDocente"].ToString();
                        docenteEscuelaGuerraNavalDTO.CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString();
                        docenteEscuelaGuerraNavalDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return docenteEscuelaGuerraNavalDTO;
        }

        public string ActualizaFormato(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocenteEscuelaGuerraNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DocenteEscuelaGuerraNavalId", SqlDbType.Int);
                    cmd.Parameters["@DocenteEscuelaGuerraNavalId"].Value = docenteEscuelaGuerraNavalDTO.DocenteEscuelaGuerraNavalId;

                    cmd.Parameters.Add("@DNIDocenteEscuela", SqlDbType.Int);
                    cmd.Parameters["@DNIDocenteEscuela"].Value = docenteEscuelaGuerraNavalDTO.DNIDocenteEscuela;


                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = docenteEscuelaGuerraNavalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = docenteEscuelaGuerraNavalDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = docenteEscuelaGuerraNavalDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DedicacionDocente"].Value = docenteEscuelaGuerraNavalDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = docenteEscuelaGuerraNavalDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = docenteEscuelaGuerraNavalDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocenteEscuelaGuerraNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteEscuelaGuerraNavalId", SqlDbType.Int);
                    cmd.Parameters["@DocenteEscuelaGuerraNavalId"].Value = docenteEscuelaGuerraNavalDTO.DocenteEscuelaGuerraNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO)
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
                    cmd.Parameters["@Formato"].Value = "DocenteEscuelaGuerraNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docenteEscuelaGuerraNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DocenteEscuelaGuerraNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteEscuelaGuerraNaval", SqlDbType.Structured);
                    cmd.Parameters["@DocenteEscuelaGuerraNaval"].TypeName = "Formato.DocenteEscuelaGuerraNaval";
                    cmd.Parameters["@DocenteEscuelaGuerraNaval"].Value = datos;

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
