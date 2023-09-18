using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirciten
{
    public class PoblacionCentroIntruccionTNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PoblacionCentroIntruccionTNavalDTO> ObtenerLista(int? CargaId = null)
        {
            List<PoblacionCentroIntruccionTNavalDTO> lista = new List<PoblacionCentroIntruccionTNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PoblacionCentroIntruccionTNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PoblacionCentroIntruccionTNavalDTO()
                        {
                            PoblacionCentroIntruccionTNavalId = Convert.ToInt32(dr["PoblacionCentroIntruccionTNavalId"]),
                            DNIIntruccionTNaval = dr["DNIIntruccionTNaval"].ToString(),
                            GeneroIntruccionTNaval = dr["GeneroIntruccionTNaval"].ToString(),
                            FechaNacimientoIntruccionTNaval = (dr["FechaNacimientoIntruccionTNaval"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarNacimiento = dr["LugarNacimiento"].ToString(),
                            LugarDomicilio = dr["LugarDomicilio"].ToString(),
                            FechaIngresoIntruccionTNaval = (dr["FechaIngresoIntruccionTNaval"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            AnoAcademico = dr["AnoAcademico"].ToString(),
                            SemestreAcademico = dr["SemestreAcademico"].ToString(),
                            IndiceRendimientoIRAS = Convert.ToInt32(dr["IndiceRendimientoIRAS"]),
                            NotaCaracterMilitar = Convert.ToInt32(dr["NotaCaracterMilitar"]),
                            NotaFormacionFisica = Convert.ToInt32(dr["NotaFormacionFisica"]),
                            NotaConductaIntruccionTNaval = Convert.ToInt32(dr["NotaConductaIntruccionTNaval"]),
                            ResultadoTerminoTrimestre = dr["ResultadoTerminoTrimestre"].ToString(),
                            DescCausalBaja = dr["DescCausalBaja"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionCentroIntruccionTNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIIntruccionTNaval", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.DNIIntruccionTNaval;

                    cmd.Parameters.Add("@GeneroIntruccionTNaval", SqlDbType.VarChar,10);
                    cmd.Parameters["@GeneroIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.GeneroIntruccionTNaval;

                    cmd.Parameters.Add("@FechaNacimientoIntruccionTNaval", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.FechaNacimientoIntruccionTNaval;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.NChar, 10);
                    cmd.Parameters["@LugarNacimiento"].Value = poblacionCentroIntruccionTNavalDTO.LugarNacimiento;

                    cmd.Parameters.Add("@LugarDomicilio", SqlDbType.NChar, 10);
                    cmd.Parameters["@LugarDomicilio"].Value = poblacionCentroIntruccionTNavalDTO.LugarDomicilio;

                    cmd.Parameters.Add("@FechaIngresoIntruccionTNaval", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.FechaIngresoIntruccionTNaval;

                    cmd.Parameters.Add("@AnoAcademico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AnoAcademico"].Value = poblacionCentroIntruccionTNavalDTO.AnoAcademico;

                    cmd.Parameters.Add("@SemestreAcademico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SemestreAcademico"].Value = poblacionCentroIntruccionTNavalDTO.SemestreAcademico;

                    cmd.Parameters.Add("@IndiceRendimientoIRAS", SqlDbType.Int);
                    cmd.Parameters["@IndiceRendimientoIRAS"].Value = poblacionCentroIntruccionTNavalDTO.IndiceRendimientoIRAS;

                    cmd.Parameters.Add("@NotaCaracterMilitar", SqlDbType.Int);
                    cmd.Parameters["@NotaCaracterMilitar"].Value = poblacionCentroIntruccionTNavalDTO.NotaCaracterMilitar;

                    cmd.Parameters.Add("@NotaFormacionFisica", SqlDbType.Int);
                    cmd.Parameters["@NotaFormacionFisica"].Value = poblacionCentroIntruccionTNavalDTO.NotaFormacionFisica;

                    cmd.Parameters.Add("@NotaConductaIntruccionTNaval", SqlDbType.Int);
                    cmd.Parameters["@NotaConductaIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.NotaConductaIntruccionTNaval;

                    cmd.Parameters.Add("@ResultadoTerminoTrimestre", SqlDbType.VarChar,15);
                    cmd.Parameters["@ResultadoTerminoTrimestre"].Value = poblacionCentroIntruccionTNavalDTO.ResultadoTerminoTrimestre;

                    cmd.Parameters.Add("@CodigoCausalBaja", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCausalBaja"].Value = poblacionCentroIntruccionTNavalDTO.CodigoCausalBaja;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = poblacionCentroIntruccionTNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionCentroIntruccionTNavalDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public PoblacionCentroIntruccionTNavalDTO BuscarFormato(int Codigo)
        {
            PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO = new PoblacionCentroIntruccionTNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionCentroIntruccionTNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionCentroIntruccionTNavalId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionCentroIntruccionTNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows) 
                    {
                        poblacionCentroIntruccionTNavalDTO.PoblacionCentroIntruccionTNavalId = Convert.ToInt32(dr["PoblacionCentroIntruccionTNavalId"]);
                        poblacionCentroIntruccionTNavalDTO.DNIIntruccionTNaval = dr["DNIIntruccionTNaval"].ToString();
                        poblacionCentroIntruccionTNavalDTO.GeneroIntruccionTNaval = Regex.Replace(dr["GeneroIntruccionTNaval"].ToString(), @"\s", "");
                        poblacionCentroIntruccionTNavalDTO.FechaNacimientoIntruccionTNaval = Convert.ToDateTime(dr["FechaNacimientoIntruccionTNaval"]).ToString("yyy-MM-dd");
                        poblacionCentroIntruccionTNavalDTO.LugarNacimiento = dr["LugarNacimiento"].ToString();
                        poblacionCentroIntruccionTNavalDTO.LugarDomicilio = dr["LugarDomicilio"].ToString();
                        poblacionCentroIntruccionTNavalDTO.FechaIngresoIntruccionTNaval = Convert.ToDateTime(dr["FechaIngresoIntruccionTNaval"]).ToString("yyy-MM-dd");
                        poblacionCentroIntruccionTNavalDTO.AnoAcademico = dr["AnoAcademico"].ToString();
                        poblacionCentroIntruccionTNavalDTO.SemestreAcademico = dr["SemestreAcademico"].ToString();
                        poblacionCentroIntruccionTNavalDTO.IndiceRendimientoIRAS = Convert.ToInt32(dr["IndiceRendimientoIRAS"]);
                        poblacionCentroIntruccionTNavalDTO.NotaCaracterMilitar = Convert.ToInt32(dr["NotaCaracterMilitar"]);
                        poblacionCentroIntruccionTNavalDTO.NotaFormacionFisica = Convert.ToInt32(dr["NotaFormacionFisica"]);
                        poblacionCentroIntruccionTNavalDTO.NotaConductaIntruccionTNaval = Convert.ToInt32(dr["NotaConductaIntruccionTNaval"]);
                        poblacionCentroIntruccionTNavalDTO.ResultadoTerminoTrimestre = dr["ResultadoTerminoTrimestre"].ToString();
                        poblacionCentroIntruccionTNavalDTO.CodigoCausalBaja = dr["CodigoCausalBaja"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return poblacionCentroIntruccionTNavalDTO;
        }

        public string ActualizaFormato(PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PoblacionCentroIntruccionTNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionCentroIntruccionTNavalId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionCentroIntruccionTNavalId"].Value = poblacionCentroIntruccionTNavalDTO.PoblacionCentroIntruccionTNavalId;

                    cmd.Parameters.Add("@DNIIntruccionTNaval", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.DNIIntruccionTNaval;

                    cmd.Parameters.Add("@GeneroIntruccionTNaval", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GeneroIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.GeneroIntruccionTNaval;

                    cmd.Parameters.Add("@FechaNacimientoIntruccionTNaval", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.FechaNacimientoIntruccionTNaval;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.NChar, 10);
                    cmd.Parameters["@LugarNacimiento"].Value = poblacionCentroIntruccionTNavalDTO.LugarNacimiento;

                    cmd.Parameters.Add("@LugarDomicilio", SqlDbType.NChar, 10);
                    cmd.Parameters["@LugarDomicilio"].Value = poblacionCentroIntruccionTNavalDTO.LugarDomicilio;

                    cmd.Parameters.Add("@FechaIngresoIntruccionTNaval", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.FechaIngresoIntruccionTNaval;

                    cmd.Parameters.Add("@AnoAcademico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AnoAcademico"].Value = poblacionCentroIntruccionTNavalDTO.AnoAcademico;

                    cmd.Parameters.Add("@SemestreAcademico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SemestreAcademico"].Value = poblacionCentroIntruccionTNavalDTO.SemestreAcademico;

                    cmd.Parameters.Add("@IndiceRendimientoIRAS", SqlDbType.Int);
                    cmd.Parameters["@IndiceRendimientoIRAS"].Value = poblacionCentroIntruccionTNavalDTO.IndiceRendimientoIRAS;

                    cmd.Parameters.Add("@NotaCaracterMilitar", SqlDbType.Int);
                    cmd.Parameters["@NotaCaracterMilitar"].Value = poblacionCentroIntruccionTNavalDTO.NotaCaracterMilitar;

                    cmd.Parameters.Add("@NotaFormacionFisica", SqlDbType.Int);
                    cmd.Parameters["@NotaFormacionFisica"].Value = poblacionCentroIntruccionTNavalDTO.NotaFormacionFisica;

                    cmd.Parameters.Add("@NotaConductaIntruccionTNaval", SqlDbType.Int);
                    cmd.Parameters["@NotaConductaIntruccionTNaval"].Value = poblacionCentroIntruccionTNavalDTO.NotaConductaIntruccionTNaval;

                    cmd.Parameters.Add("@ResultadoTerminoTrimestre", SqlDbType.VarChar, 15);
                    cmd.Parameters["@ResultadoTerminoTrimestre"].Value = poblacionCentroIntruccionTNavalDTO.ResultadoTerminoTrimestre;

                    cmd.Parameters.Add("@CodigoCausalBaja", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalBaja"].Value = poblacionCentroIntruccionTNavalDTO.CodigoCausalBaja;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionCentroIntruccionTNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionCentroIntruccionTNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionCentroIntruccionTNavalId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionCentroIntruccionTNavalId"].Value = poblacionCentroIntruccionTNavalDTO.PoblacionCentroIntruccionTNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionCentroIntruccionTNavalDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_PoblacionCentroIntruccionTNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionCentroIntruccionTNaval", SqlDbType.Structured);
                    cmd.Parameters["@PoblacionCentroIntruccionTNaval"].TypeName = "Formato.PoblacionCentroIntruccionTNaval";
                    cmd.Parameters["@PoblacionCentroIntruccionTNaval"].Value = datos;

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
    }
}
