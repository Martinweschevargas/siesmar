using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diperadmon
{
    public class PersonalMilitarRetiroBajaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PersonalMilitarRetiroBajaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PersonalMilitarRetiroBajaDTO> lista = new List<PersonalMilitarRetiroBajaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PersonalMilitarRetiroBajaListar", conexion);
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
                        lista.Add(new PersonalMilitarRetiroBajaDTO()
                        {
                            PersonalMilitarRetiroBajaId = Convert.ToInt32(dr["PersonalMilitarRetiroBajaId"]),
                            DNIPMilitarRetBaja = dr["DNIPMilitarRetBaja"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            SexoPMilitarRetBaja = dr["SexoPMilitarRetBaja"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            DescMotivoBajaPersonal = dr["DescMotivoBajaPersonal"].ToString(),
                            FechaIngresoInsPMilitarRetBaja = (dr["FechaIngresoInsPMilitarRetBaja"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRetiroPMilitarRetBaja = (dr["FechaRetiroPMilitarRetBaja"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalMilitarRetiroBajaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPMilitarRetBaja", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.DNIPMilitarRetBaja;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = personalMilitarRetiroBajaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SexoPMilitarRetBaja", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.SexoPMilitarRetBaja;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = personalMilitarRetiroBajaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoMotivoBajaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoBajaPersonal"].Value = personalMilitarRetiroBajaDTO.CodigoMotivoBajaPersonal;

                    cmd.Parameters.Add("@FechaIngresoInsPMilitarRetBaja", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInsPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.FechaIngresoInsPMilitarRetBaja;

                    cmd.Parameters.Add("@FechaRetiroPMilitarRetBaja", SqlDbType.Date);
                    cmd.Parameters["@FechaRetiroPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.FechaRetiroPMilitarRetBaja;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalMilitarRetiroBajaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarRetiroBajaDTO.UsuarioIngresoRegistro;

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

        public PersonalMilitarRetiroBajaDTO BuscarFormato(int Codigo)
        {
            PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO = new PersonalMilitarRetiroBajaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalMilitarRetiroBajaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarRetiroBajaId", SqlDbType.Int);
                    cmd.Parameters["@PersonalMilitarRetiroBajaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        personalMilitarRetiroBajaDTO.PersonalMilitarRetiroBajaId = Convert.ToInt32(dr["PersonalMilitarRetiroBajaId"]);
                        personalMilitarRetiroBajaDTO.DNIPMilitarRetBaja = dr["DNIPMilitarRetBaja"].ToString();
                        personalMilitarRetiroBajaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        personalMilitarRetiroBajaDTO.SexoPMilitarRetBaja = dr["SexoPMilitarRetBaja"].ToString();
                        personalMilitarRetiroBajaDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        personalMilitarRetiroBajaDTO.CodigoMotivoBajaPersonal = dr["CodigoMotivoBajaPersonal"].ToString();
                        personalMilitarRetiroBajaDTO.FechaIngresoInsPMilitarRetBaja = Convert.ToDateTime(dr["FechaIngresoInsPMilitarRetBaja"]).ToString("yyy-MM-dd");
                        personalMilitarRetiroBajaDTO.FechaRetiroPMilitarRetBaja = Convert.ToDateTime(dr["FechaRetiroPMilitarRetBaja"]).ToString("yyy-MM-dd");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personalMilitarRetiroBajaDTO;
        }

        public string ActualizaFormato(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalMilitarRetiroBajaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarRetiroBajaId", SqlDbType.Int);
                    cmd.Parameters["@PersonalMilitarRetiroBajaId"].Value = personalMilitarRetiroBajaDTO.PersonalMilitarRetiroBajaId;

                    cmd.Parameters.Add("@DNIPMilitarRetBaja", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.DNIPMilitarRetBaja;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = personalMilitarRetiroBajaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SexoPMilitarRetBaja", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.SexoPMilitarRetBaja;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = personalMilitarRetiroBajaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoMotivoBajaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoBajaPersonal"].Value = personalMilitarRetiroBajaDTO.CodigoMotivoBajaPersonal;

                    cmd.Parameters.Add("@FechaIngresoInsPMilitarRetBaja", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInsPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.FechaIngresoInsPMilitarRetBaja;

                    cmd.Parameters.Add("@FechaRetiroPMilitarRetBaja", SqlDbType.Date);
                    cmd.Parameters["@FechaRetiroPMilitarRetBaja"].Value = personalMilitarRetiroBajaDTO.FechaRetiroPMilitarRetBaja;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarRetiroBajaDTO.UsuarioIngresoRegistro;

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


        public bool EliminarFormato(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalMilitarRetiroBajaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarRetiroBajaId", SqlDbType.Int);
                    cmd.Parameters["@PersonalMilitarRetiroBajaId"].Value = personalMilitarRetiroBajaDTO.PersonalMilitarRetiroBajaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarRetiroBajaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO)
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
                    cmd.Parameters["@Formato"].Value = "PersonalMilitarRetiroBaja";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalMilitarRetiroBajaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarRetiroBajaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PersonalMilitarRetiroBajaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarRetiroBaja", SqlDbType.Structured);
                    cmd.Parameters["@PersonalMilitarRetiroBaja"].TypeName = "Formato.PersonalMilitarRetiroBaja";
                    cmd.Parameters["@PersonalMilitarRetiroBaja"].Value = datos;

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
