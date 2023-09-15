using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class PoblacionEstudiantilMatriculadosDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PoblacionEstudiantilMatriculadosDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PoblacionEstudiantilMatriculadosDTO> lista = new List<PoblacionEstudiantilMatriculadosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PoblacionEstudiantilMatriculadoListar", conexion);
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
                        lista.Add(new PoblacionEstudiantilMatriculadosDTO()
                        {
                            PoblacionEstudiantilMatriculadoId = Convert.ToInt32(dr["PoblacionEstudiantilMatriculadoId"]),
                            DNIMatriculado = dr["DNIMatriculado"].ToString(),
                            FechaNacimiento = (dr["FechaNacimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            SexoMatriculado = dr["SexoMatriculado"].ToString(),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            GradoEstudio = dr["GradoEstudio"].ToString(),
                            DescSeccionEstudio = dr["DescSeccionEstudio"].ToString(),
                            EspecificacionEstudio = dr["EspecificacionEstudio"].ToString(),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            DescResultadoEjercicioEducativo = dr["DescResultadoEjercicioEducativo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<PoblacionEstudiantilMatriculadosDTO> BienestarVisualizacionPoblacionEstudiantilMatriculado(int CargaId)
        {
            List<PoblacionEstudiantilMatriculadosDTO> lista = new List<PoblacionEstudiantilMatriculadosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionPoblacionEstudiantilMatriculado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PoblacionEstudiantilMatriculadosDTO()
                        {
                            DNIMatriculado = dr["DNIMatriculado"].ToString(),
                            FechaNacimiento = dr["FechaNacimiento"].ToString(),
                            SexoMatriculado = dr["SexoMatriculado"].ToString(),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            DescNivelEstudio = dr["DescNivelEstudio"].ToString(),
                            GradoEstudio = dr["GradoEstudio"].ToString(),
                            DescSeccionEstudio = dr["DescSeccionEstudio"].ToString(),
                            EspecificacionEstudio = dr["EspecificacionEstudio"].ToString(),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            DescResultadoEjercicioEducativo = dr["DescResultadoEjercicioEducativo"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEstudiantilMatriculadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIMatriculado", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIMatriculado"].Value = poblacionEstudiantilMatriculadoDTO.DNIMatriculado;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = poblacionEstudiantilMatriculadoDTO.FechaNacimiento;

                    cmd.Parameters.Add("@SexoMatriculado", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoMatriculado"].Value = poblacionEstudiantilMatriculadoDTO.SexoMatriculado;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = poblacionEstudiantilMatriculadoDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = poblacionEstudiantilMatriculadoDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@GradoEstudio", SqlDbType.VarChar,3);
                    cmd.Parameters["@GradoEstudio"].Value = poblacionEstudiantilMatriculadoDTO.GradoEstudio;

                    cmd.Parameters.Add("@CodigoSeccionEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSeccionEstudio"].Value = poblacionEstudiantilMatriculadoDTO.CodigoSeccionEstudio;

                    cmd.Parameters.Add("@EspecificacionEstudio", SqlDbType.VarChar,100);
                    cmd.Parameters["@EspecificacionEstudio"].Value = poblacionEstudiantilMatriculadoDTO.EspecificacionEstudio;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = poblacionEstudiantilMatriculadoDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@CodigoResultadoEjercicioEducativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoEjercicioEducativo"].Value = poblacionEstudiantilMatriculadoDTO.CodigoResultadoEjercicioEducativo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = poblacionEstudiantilMatriculadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro;

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

        public PoblacionEstudiantilMatriculadosDTO BuscarFormato(int Codigo)
        {
            PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO = new PoblacionEstudiantilMatriculadosDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEstudiantilMatriculadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEstudiantilMatriculadoId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEstudiantilMatriculadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        poblacionEstudiantilMatriculadoDTO.PoblacionEstudiantilMatriculadoId = Convert.ToInt32(dr["PoblacionEstudiantilMatriculadoId"]);
                        poblacionEstudiantilMatriculadoDTO.DNIMatriculado = dr["DNIMatriculado"].ToString();
                        poblacionEstudiantilMatriculadoDTO.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyy-MM-dd");
                        poblacionEstudiantilMatriculadoDTO.SexoMatriculado = dr["SexoMatriculado"].ToString();
                        poblacionEstudiantilMatriculadoDTO.CodigoInstitucionEducativa = dr["CodigoInstitucionEducativa"].ToString();
                        poblacionEstudiantilMatriculadoDTO.CodigoNivelEstudio = dr["CodigoNivelEstudio"].ToString();
                        poblacionEstudiantilMatriculadoDTO.GradoEstudio = dr["GradoEstudio"].ToString();
                        poblacionEstudiantilMatriculadoDTO.CodigoSeccionEstudio = dr["CodigoSeccionEstudio"].ToString();
                        poblacionEstudiantilMatriculadoDTO.EspecificacionEstudio = dr["EspecificacionEstudio"].ToString();
                        poblacionEstudiantilMatriculadoDTO.CodigoCategoriaPago = dr["CodigoCategoriaPago"].ToString();
                        poblacionEstudiantilMatriculadoDTO.CodigoResultadoEjercicioEducativo = dr["CodigoResultadoEjercicioEducativo"].ToString(); ; 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return poblacionEstudiantilMatriculadoDTO;
        }

        public string ActualizaFormato(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PoblacionEstudiantilMatriculadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEstudiantilMatriculadoId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEstudiantilMatriculadoId"].Value = poblacionEstudiantilMatriculadoDTO.PoblacionEstudiantilMatriculadoId;

                    cmd.Parameters.Add("@DNIMatriculado", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIMatriculado"].Value = poblacionEstudiantilMatriculadoDTO.DNIMatriculado;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = poblacionEstudiantilMatriculadoDTO.FechaNacimiento;

                    cmd.Parameters.Add("@SexoMatriculado", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoMatriculado"].Value = poblacionEstudiantilMatriculadoDTO.SexoMatriculado;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = poblacionEstudiantilMatriculadoDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@CodigoNivelEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelEstudio"].Value = poblacionEstudiantilMatriculadoDTO.CodigoNivelEstudio;

                    cmd.Parameters.Add("@GradoEstudio", SqlDbType.VarChar, 3);
                    cmd.Parameters["@GradoEstudio"].Value = poblacionEstudiantilMatriculadoDTO.GradoEstudio;

                    cmd.Parameters.Add("@CodigoSeccionEstudio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSeccionEstudio"].Value = poblacionEstudiantilMatriculadoDTO.CodigoSeccionEstudio;

                    cmd.Parameters.Add("@EspecificacionEstudio", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EspecificacionEstudio"].Value = poblacionEstudiantilMatriculadoDTO.EspecificacionEstudio;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = poblacionEstudiantilMatriculadoDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@CodigoResultadoEjercicioEducativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoEjercicioEducativo"].Value = poblacionEstudiantilMatriculadoDTO.CodigoResultadoEjercicioEducativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEstudiantilMatriculadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEstudiantilMatriculadoId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEstudiantilMatriculadoId"].Value = poblacionEstudiantilMatriculadoDTO.PoblacionEstudiantilMatriculadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO)
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
                    cmd.Parameters["@Formato"].Value = "PoblacionEstudiantilMatriculado";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = poblacionEstudiantilMatriculadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PoblacionEstudiantilMatriculadoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEstudiantilMatriculado", SqlDbType.Structured);
                    cmd.Parameters["@PoblacionEstudiantilMatriculado"].TypeName = "Formato.PoblacionEstudiantilMatriculado";
                    cmd.Parameters["@PoblacionEstudiantilMatriculado"].Value = datos;

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
