using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresprom
{
    public class Docente2daEspecializacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<Docente2daEspecializacionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<Docente2daEspecializacionDTO> lista = new List<Docente2daEspecializacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_Docente2daEspecializacionListar", conexion);
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
                        lista.Add(new Docente2daEspecializacionDTO()
                        {
                            Docente2daEspecializacionId = Convert.ToInt32(dr["Docente2daEspecializacionId"]),
                            DNIPersonalDocente = Convert.ToInt32(dr["DNIPersonalDocente"]),
                            TipoPersonalDocente = dr["TipoPersonalDocente"].ToString(),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            DescRegimenLaboral = dr["DescRegimenLaboral"].ToString(),
                            DedicacionTiempoDocente = dr["DedicacionTiempoDocente"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(Docente2daEspecializacionDTO docente2daEspecializacionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_Docente2daEspecializacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalDocente", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonalDocente"].Value = docente2daEspecializacionDTO.DNIPersonalDocente;

                    cmd.Parameters.Add("@TipoPersonalDocente", SqlDbType.VarChar,260);
                    cmd.Parameters["@TipoPersonalDocente"].Value = docente2daEspecializacionDTO.TipoPersonalDocente;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente "].Value = docente2daEspecializacionDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral "].Value = docente2daEspecializacionDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionTiempoDocente", SqlDbType.VarChar,50);
                    cmd.Parameters["@DedicacionTiempoDocente"].Value = docente2daEspecializacionDTO.DedicacionTiempoDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio "].Value = docente2daEspecializacionDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad "].Value = docente2daEspecializacionDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docente2daEspecializacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docente2daEspecializacionDTO.UsuarioIngresoRegistro;

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

        public Docente2daEspecializacionDTO BuscarFormato(int Codigo)
        {
            Docente2daEspecializacionDTO docente2daEspecializacionDTO = new Docente2daEspecializacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_Docente2daEspecializacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Docente2daEspecializacionId", SqlDbType.Int);
                    cmd.Parameters["@Docente2daEspecializacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        docente2daEspecializacionDTO.Docente2daEspecializacionId = Convert.ToInt32(dr["Docente2daEspecializacionId"]);
                        docente2daEspecializacionDTO.DNIPersonalDocente = Convert.ToInt32(dr["DNIPersonalDocente"]);
                        docente2daEspecializacionDTO.TipoPersonalDocente = dr["TipoPersonalDocente"].ToString();
                        docente2daEspecializacionDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                        docente2daEspecializacionDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString();
                        docente2daEspecializacionDTO.DedicacionTiempoDocente = dr["DedicacionTiempoDocente"].ToString();
                        docente2daEspecializacionDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString();
                        docente2daEspecializacionDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return docente2daEspecializacionDTO;
        }

        public string ActualizaFormato(Docente2daEspecializacionDTO docente2daEspecializacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_Docente2daEspecializacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Docente2daEspecializacionId", SqlDbType.Int);
                    cmd.Parameters["@Docente2daEspecializacionId"].Value = docente2daEspecializacionDTO.Docente2daEspecializacionId;

                    cmd.Parameters.Add("@DNIPersonalDocente", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonalDocente"].Value = docente2daEspecializacionDTO.DNIPersonalDocente;

                    cmd.Parameters.Add("@TipoPersonalDocente", SqlDbType.VarChar, 260);
                    cmd.Parameters["@TipoPersonalDocente"].Value = docente2daEspecializacionDTO.TipoPersonalDocente;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente "].Value = docente2daEspecializacionDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral "].Value = docente2daEspecializacionDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionTiempoDocente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DedicacionTiempoDocente"].Value = docente2daEspecializacionDTO.DedicacionTiempoDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio "].Value = docente2daEspecializacionDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad "].Value = docente2daEspecializacionDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docente2daEspecializacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(Docente2daEspecializacionDTO docente2daEspecializacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_Docente2daEspecializacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Docente2daEspecializacionId", SqlDbType.Int);
                    cmd.Parameters["@Docente2daEspecializacionId"].Value = docente2daEspecializacionDTO.Docente2daEspecializacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docente2daEspecializacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(Docente2daEspecializacionDTO docente2daEspecializacionDTO)
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
                    cmd.Parameters["@Formato"].Value = "Docente2daEspecializacion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = docente2daEspecializacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = docente2daEspecializacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_Docente2daEspecializacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Docente2daEspecializacion", SqlDbType.Structured);
                    cmd.Parameters["@Docente2daEspecializacion"].TypeName = "Formato.Docente2daEspecializacion";
                    cmd.Parameters["@Docente2daEspecializacion"].Value = datos;

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
