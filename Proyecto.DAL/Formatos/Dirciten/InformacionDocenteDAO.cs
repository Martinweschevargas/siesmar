using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirciten
{
    public class InformacionDocenteDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InformacionDocenteDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<InformacionDocenteDTO> lista = new List<InformacionDocenteDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InformacionDocenteListar", conexion);
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
                        lista.Add(new InformacionDocenteDTO()
                        {
                            InformacionDocenteId = Convert.ToInt32(dr["InformacionDocenteId"]),
                            DNIDocenteDirciten = dr["DNIDocenteDirciten"].ToString(),
                            TipoDocenteDirciten = dr["TipoDocenteDirciten"].ToString(),
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

        public string AgregarRegistro(InformacionDocenteDTO informacionDocenteDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformacionDocenteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIDocenteDirciten", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIDocenteDirciten"].Value = informacionDocenteDTO.DNIDocenteDirciten;

                    cmd.Parameters.Add("@TipoDocenteDirciten", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoDocenteDirciten"].Value = informacionDocenteDTO.TipoDocenteDirciten;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = informacionDocenteDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = informacionDocenteDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DedicacionDocente"].Value = informacionDocenteDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = informacionDocenteDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = informacionDocenteDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = informacionDocenteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informacionDocenteDTO.UsuarioIngresoRegistro;

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

        public InformacionDocenteDTO BuscarFormato(int Codigo)
        {
            InformacionDocenteDTO informacionDocenteDTO = new InformacionDocenteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformacionDocenteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformacionDocenteId", SqlDbType.Int);
                    cmd.Parameters["@InformacionDocenteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        informacionDocenteDTO.InformacionDocenteId = Convert.ToInt32(dr["InformacionDocenteId"]);
                        informacionDocenteDTO.DNIDocenteDirciten = dr["DNIDocenteDirciten"].ToString();
                        informacionDocenteDTO.TipoDocenteDirciten = dr["TipoDocenteDirciten"].ToString();
                        informacionDocenteDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                        informacionDocenteDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString();
                        informacionDocenteDTO.DedicacionDocente = dr["DedicacionDocente"].ToString();
                        informacionDocenteDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString();
                        informacionDocenteDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return informacionDocenteDTO;
        }

        public string ActualizaFormato(InformacionDocenteDTO informacionDocenteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InformacionDocenteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformacionDocenteId", SqlDbType.Int);
                    cmd.Parameters["@InformacionDocenteId"].Value = informacionDocenteDTO.InformacionDocenteId;

                    cmd.Parameters.Add("@DNIDocenteDirciten", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIDocenteDirciten"].Value = informacionDocenteDTO.DNIDocenteDirciten;

                    cmd.Parameters.Add("@TipoDocenteDirciten", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoDocenteDirciten"].Value = informacionDocenteDTO.TipoDocenteDirciten;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = informacionDocenteDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = informacionDocenteDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@DedicacionDocente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DedicacionDocente"].Value = informacionDocenteDTO.DedicacionDocente;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = informacionDocenteDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = informacionDocenteDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informacionDocenteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InformacionDocenteDTO informacionDocenteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformacionDocenteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformacionDocenteId", SqlDbType.Int);
                    cmd.Parameters["@InformacionDocenteId"].Value = informacionDocenteDTO.InformacionDocenteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informacionDocenteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(InformacionDocenteDTO informacionDocenteDTO)
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
                    cmd.Parameters["@Formato"].Value = "informacionDocente";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = informacionDocenteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informacionDocenteDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InformacionDocenteRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformacionDocente", SqlDbType.Structured);
                    cmd.Parameters["@InformacionDocente"].TypeName = "Formato.InformacionDocente";
                    cmd.Parameters["@InformacionDocente"].Value = datos;

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


