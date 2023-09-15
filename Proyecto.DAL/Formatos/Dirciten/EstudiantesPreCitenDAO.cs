using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirciten
{
    public class EstudiantesPreCitenDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EstudiantesPreCitenDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EstudiantesPreCitenDTO> lista = new List<EstudiantesPreCitenDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EstudiantePreCitenListar", conexion);
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
                        lista.Add(new EstudiantesPreCitenDTO()
                        {
                            EstudiantePreCitenId = Convert.ToInt32(dr["EstudiantePreCitenId"]),
                            DNIEstudiantePreCiten = dr["DNIEstudiantePreCiten"].ToString(),
                            GeneroEstudiantePreCiten = dr["GeneroEstudiantePreCiten"].ToString(),
                            FechaNacimiento = (dr["FechaNacimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarDomicilio = dr["DescDistrito"].ToString(),
                            TipoColegioProcedencia = dr["TipoColegioProcedencia"].ToString(),
                            ColegioProcedencia = dr["ColegioProcedencia"].ToString(),
                            LugarColegio = dr["DescDistrito"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EstudiantesPreCitenDTO estudiantesPreCitenDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudiantePreCitenRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIEstudiantePreCiten", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIEstudiantePreCiten"].Value = estudiantesPreCitenDTO.DNIEstudiantePreCiten;

                    cmd.Parameters.Add("@GeneroEstudiantePreCiten", SqlDbType.VarChar,10);
                    cmd.Parameters["@GeneroEstudiantePreCiten"].Value = estudiantesPreCitenDTO.GeneroEstudiantePreCiten;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = estudiantesPreCitenDTO.FechaNacimiento;

                    cmd.Parameters.Add("@DistritoUbigeoDomicilio", SqlDbType.VarChar, 30);
                    cmd.Parameters["@DistritoUbigeoDomicilio"].Value = estudiantesPreCitenDTO.LugarDomicilio;

                    cmd.Parameters.Add("@TipoColegioProcedencia", SqlDbType.VarChar, 30);
                    cmd.Parameters["@TipoColegioProcedencia"].Value = estudiantesPreCitenDTO.TipoColegioProcedencia;

                    cmd.Parameters.Add("@ColegioProcedencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColegioProcedencia"].Value = estudiantesPreCitenDTO.ColegioProcedencia;

                    cmd.Parameters.Add("@DistritoUbigeoColegio", SqlDbType.VarChar, 30);
                    cmd.Parameters["@DistritoUbigeoColegio"].Value = estudiantesPreCitenDTO.LugarColegio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudiantesPreCitenDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudiantesPreCitenDTO.UsuarioIngresoRegistro;

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

        public EstudiantesPreCitenDTO BuscarFormato(int Codigo)
        {
            EstudiantesPreCitenDTO estudiantesPreCitenDTO = new EstudiantesPreCitenDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudiantePreCitenEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudiantePreCitenId", SqlDbType.Int);
                    cmd.Parameters["@EstudiantePreCitenId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        estudiantesPreCitenDTO.EstudiantePreCitenId = Convert.ToInt32(dr["EstudiantePreCitenId"]);
                        estudiantesPreCitenDTO.DNIEstudiantePreCiten =dr["DNIEstudiantePreCiten"].ToString();
                        estudiantesPreCitenDTO.GeneroEstudiantePreCiten = Regex.Replace(dr["GeneroEstudiantePreCiten"].ToString(), @"\s", "");
                        estudiantesPreCitenDTO.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyy-MM-dd");
                        estudiantesPreCitenDTO.LugarDomicilio = dr["DistritoUbigeoDomicilio"].ToString();
                        estudiantesPreCitenDTO.TipoColegioProcedencia = dr["TipoColegioProcedencia"].ToString();
                        estudiantesPreCitenDTO.ColegioProcedencia = dr["ColegioProcedencia"].ToString();
                        estudiantesPreCitenDTO.LugarColegio = dr["DistritoUbigeoColegio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estudiantesPreCitenDTO;
        }

        public string ActualizaFormato(EstudiantesPreCitenDTO estudiantesPreCitenDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EstudiantePreCitenActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudiantePreCitenId", SqlDbType.Int);
                    cmd.Parameters["@EstudiantePreCitenId"].Value = estudiantesPreCitenDTO.EstudiantePreCitenId;

                    cmd.Parameters.Add("@DNIEstudiantePreCiten", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIEstudiantePreCiten"].Value = estudiantesPreCitenDTO.DNIEstudiantePreCiten;

                    cmd.Parameters.Add("@GeneroEstudiantePreCiten", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GeneroEstudiantePreCiten"].Value = estudiantesPreCitenDTO.GeneroEstudiantePreCiten;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = estudiantesPreCitenDTO.FechaNacimiento;

                    cmd.Parameters.Add("@DistritoUbigeoDomicilio", SqlDbType.VarChar, 30);
                    cmd.Parameters["@DistritoUbigeoDomicilio"].Value = estudiantesPreCitenDTO.LugarDomicilio;

                    cmd.Parameters.Add("@TipoColegioProcedencia", SqlDbType.VarChar, 30);
                    cmd.Parameters["@TipoColegioProcedencia"].Value = estudiantesPreCitenDTO.TipoColegioProcedencia;

                    cmd.Parameters.Add("@ColegioProcedencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColegioProcedencia"].Value = estudiantesPreCitenDTO.ColegioProcedencia;

                    cmd.Parameters.Add("@DistritoUbigeoColegio", SqlDbType.VarChar, 30);
                    cmd.Parameters["@DistritoUbigeoColegio"].Value = estudiantesPreCitenDTO.LugarColegio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudiantesPreCitenDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EstudiantesPreCitenDTO estudiantesPreCitenDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudiantePreCitenEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudiantePreCitenId", SqlDbType.Int);
                    cmd.Parameters["@EstudiantePreCitenId"].Value = estudiantesPreCitenDTO.EstudiantePreCitenId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudiantesPreCitenDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EstudiantesPreCitenDTO estudiantesPreCitenDTO)
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
                    cmd.Parameters["@Formato"].Value = "EstudiantePreCiten";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudiantesPreCitenDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudiantesPreCitenDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EstudiantePreCitenRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudiantePreCiten", SqlDbType.Structured);
                    cmd.Parameters["@EstudiantePreCiten"].TypeName = "Formato.EstudiantePreCiten";
                    cmd.Parameters["@EstudiantePreCiten"].Value = datos;

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
