using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dincydet
{
    public class ArchivoPersonalCienciaTecnologiaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoPersonalCienciaTecnologiaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoPersonalCienciaTecnologiaDTO> lista = new List<ArchivoPersonalCienciaTecnologiaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoPersonalCienciaTecnologiaListar", conexion);
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
                        lista.Add(new ArchivoPersonalCienciaTecnologiaDTO()
                        {
                            ArchivoPersonalCienciaTecnologiaId = Convert.ToInt32(dr["ArchivoPersonalCienciaTecnologiaId"]),
                            DNIPersonalCT = dr["DNIPersonalCT"].ToString(),
                            AniosTrabajoPersonalCT = Convert.ToInt32(dr["AniosTrabajoPersonalCT"]),
                            SexoPersonalCT = dr["SexoPersonalCT"].ToString(),
                            DescFormacionAcademica = dr["DescFormacionAcademica"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescTituloProfesionalObtenido = dr["DescTituloProfesionalObtenido"].ToString(),
                            NaturalezaTrabajoPersonalCT = dr["NaturalezaTrabajoPersonalCT"].ToString(),
                            EspecializacionPersonaCT = dr["EspecializacionPersonaCT"].ToString(),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            DedicacionTiempoPersonalCT = dr["DedicacionTiempoPersonalCT"].ToString(),
                            ParticipacionProgramas = dr["ParticipacionProgramas"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCTecnologiaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCienciaTecnologiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalCT", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonalCT"].Value = archivoPersonalCTecnologiaDTO.DNIPersonalCT;

                    cmd.Parameters.Add("@AniosTrabajoPersonalCT", SqlDbType.VarChar, 2);
                    cmd.Parameters["@AniosTrabajoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.AniosTrabajoPersonalCT;

                    cmd.Parameters.Add("@SexoPersonalCT", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.SexoPersonalCT;

                    cmd.Parameters.Add("@CodigoFormacionAcademica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFormacionAcademica"].Value = archivoPersonalCTecnologiaDTO.CodigoFormacionAcademica;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = archivoPersonalCTecnologiaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoTituloProfesionalObtenido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTituloProfesionalObtenido"].Value = archivoPersonalCTecnologiaDTO.CodigoTituloProfesionalObtenido;

                        cmd.Parameters.Add("@NaturalezaTrabajoPersonalCT", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NaturalezaTrabajoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.NaturalezaTrabajoPersonalCT;

                    cmd.Parameters.Add("@EspecializacionPersonaCT", SqlDbType.VarChar, 1);
                    cmd.Parameters["@EspecializacionPersonaCT"].Value = archivoPersonalCTecnologiaDTO.EspecializacionPersonaCT;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoPersonalCTecnologiaDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@DedicacionTiempoPersonalCT", SqlDbType.VarChar, 2);
                    cmd.Parameters["@DedicacionTiempoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.DedicacionTiempoPersonalCT;

                    cmd.Parameters.Add("@ParticipacionProgramas", SqlDbType.VarChar, 1);
                    cmd.Parameters["@ParticipacionProgramas"].Value = archivoPersonalCTecnologiaDTO.ParticipacionProgramas;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoPersonalCTecnologiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTecnologiaDTO.UsuarioIngresoRegistro;

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

        public ArchivoPersonalCienciaTecnologiaDTO BuscarFormato(int Codigo)
        {
            ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCTecnologiaDTO = new ArchivoPersonalCienciaTecnologiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCienciaTecnologiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCienciaTecnologiaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPersonalCienciaTecnologiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        archivoPersonalCTecnologiaDTO.ArchivoPersonalCienciaTecnologiaId = Convert.ToInt32(dr["ArchivoPersonalCienciaTecnologiaId"]);
                        archivoPersonalCTecnologiaDTO.DNIPersonalCT = dr["DNIPersonalCT"].ToString();
                        archivoPersonalCTecnologiaDTO.AniosTrabajoPersonalCT = Convert.ToInt32(dr["AniosTrabajoPersonalCT"]);
                        archivoPersonalCTecnologiaDTO.SexoPersonalCT = Regex.Replace(dr["SexoPersonalCT"].ToString(), @"\s", "");
                        archivoPersonalCTecnologiaDTO.CodigoFormacionAcademica = dr["CodigoFormacionAcademica"].ToString();
                        archivoPersonalCTecnologiaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        archivoPersonalCTecnologiaDTO.CodigoTituloProfesionalObtenido = dr["CodigoTituloProfesionalObtenido"].ToString();
                        archivoPersonalCTecnologiaDTO.NaturalezaTrabajoPersonalCT = dr["NaturalezaTrabajoPersonalCT"].ToString();
                        archivoPersonalCTecnologiaDTO.EspecializacionPersonaCT = dr["EspecializacionPersonaCT"].ToString();
                        archivoPersonalCTecnologiaDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                        archivoPersonalCTecnologiaDTO.DedicacionTiempoPersonalCT = dr["DedicacionTiempoPersonalCT"].ToString();
                        archivoPersonalCTecnologiaDTO.ParticipacionProgramas = dr["ParticipacionProgramas"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoPersonalCTecnologiaDTO;
        }

        public string ActualizaFormato(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCTecnologiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCienciaTecnologiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCienciaTecnologiaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPersonalCienciaTecnologiaId"].Value = archivoPersonalCTecnologiaDTO.ArchivoPersonalCienciaTecnologiaId;

                    cmd.Parameters.Add("@DNIPersonalCT", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonalCT"].Value = archivoPersonalCTecnologiaDTO.DNIPersonalCT;

                    cmd.Parameters.Add("@AniosTrabajoPersonalCT", SqlDbType.VarChar, 2);
                    cmd.Parameters["@AniosTrabajoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.AniosTrabajoPersonalCT;

                    cmd.Parameters.Add("@SexoPersonalCT", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.SexoPersonalCT;

                    cmd.Parameters.Add("@CodigoFormacionAcademica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFormacionAcademica"].Value = archivoPersonalCTecnologiaDTO.CodigoFormacionAcademica;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = archivoPersonalCTecnologiaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoTituloProfesionalObtenido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTituloProfesionalObtenido"].Value = archivoPersonalCTecnologiaDTO.CodigoTituloProfesionalObtenido;

                    cmd.Parameters.Add("@NaturalezaTrabajoPersonalCT", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NaturalezaTrabajoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.NaturalezaTrabajoPersonalCT;

                    cmd.Parameters.Add("@EspecializacionPersonaCT", SqlDbType.VarChar, 1);
                    cmd.Parameters["@EspecializacionPersonaCT"].Value = archivoPersonalCTecnologiaDTO.EspecializacionPersonaCT;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaCT"].Value = archivoPersonalCTecnologiaDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@DedicacionTiempoPersonalCT", SqlDbType.VarChar, 2);
                    cmd.Parameters["@DedicacionTiempoPersonalCT"].Value = archivoPersonalCTecnologiaDTO.DedicacionTiempoPersonalCT;

                    cmd.Parameters.Add("@ParticipacionProgramas", SqlDbType.VarChar, 1);
                    cmd.Parameters["@ParticipacionProgramas"].Value = archivoPersonalCTecnologiaDTO.ParticipacionProgramas;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTecnologiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCTecnologiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoPersonalCienciaTecnologiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCienciaTecnologiaId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoPersonalCienciaTecnologiaId"].Value= archivoPersonalCTecnologiaDTO.ArchivoPersonalCienciaTecnologiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTecnologiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCTecnologiaDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoPersonalCienciaTecnologia";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoPersonalCTecnologiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoPersonalCTecnologiaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoPersonalCienciaTecnologiaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoPersonalCienciaTecnologia", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoPersonalCienciaTecnologia"].TypeName = "Formato.ArchivoPersonalCienciaTecnologia";
                    cmd.Parameters["@ArchivoPersonalCienciaTecnologia"].Value = datos;

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
