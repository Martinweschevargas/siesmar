using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class ActividadCulturalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActividadCulturalDTO> ObtenerLista()
        {
            List<ActividadCulturalDTO> lista = new List<ActividadCulturalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActividadCulturalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadCulturalDTO()
                        {
                            ActividadCulturalId = Convert.ToInt32(dr["ActividadCulturalId"]),
                            NombreActividadCultural = dr["NombreActividadCultural"].ToString(),
                            DescTipoActividadCultural = dr["DescTipoActividadCultural"].ToString(),
                            FechaInicioActCultural = (dr["FechaInicioActCultural"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoActCultural = (dr["FechaTerminoActCultural"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarActCultural = dr["LugarActCultural"].ToString(),
                            AuspiciadoresActCultural = dr["AuspiciadoresActCultural"].ToString(),
                            NParticipantesActCultural = Convert.ToInt32(dr["NParticipantesActCultural"]),
                            InversionActCultural = Convert.ToDecimal(dr["InversionActCultural"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ActividadCulturalDTO actividadCulturalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadCulturalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreActividadCultural", SqlDbType.VarChar, 250);
                    cmd.Parameters["@NombreActividadCultural"].Value = actividadCulturalDTO.NombreActividadCultural;

                    cmd.Parameters.Add("@TipoActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadCulturalId"].Value = actividadCulturalDTO.TipoActividadCulturalId;

                    cmd.Parameters.Add("@FechaInicioActCultural", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioActCultural"].Value = actividadCulturalDTO.FechaInicioActCultural;

                    cmd.Parameters.Add("@FechaTerminoActCultural", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoActCultural"].Value = actividadCulturalDTO.FechaTerminoActCultural;

                    cmd.Parameters.Add("@LugarActCultural", SqlDbType.VarChar, 250);
                    cmd.Parameters["@LugarActCultural"].Value = actividadCulturalDTO.LugarActCultural;

                    cmd.Parameters.Add("@AuspiciadoresActCultural", SqlDbType.VarChar, 250);
                    cmd.Parameters["@AuspiciadoresActCultural"].Value = actividadCulturalDTO.AuspiciadoresActCultural;

                    cmd.Parameters.Add("@NParticipantesActCultural", SqlDbType.Int);
                    cmd.Parameters["@NParticipantesActCultural"].Value = actividadCulturalDTO.NParticipantesActCultural;

                    cmd.Parameters.Add("@InversionActCultural", SqlDbType.Decimal);
                    cmd.Parameters["@InversionActCultural"].Value = actividadCulturalDTO.InversionActCultural;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadCulturalDTO.UsuarioIngresoRegistro;

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

        public ActividadCulturalDTO BuscarFormato(int Codigo)
        {
            ActividadCulturalDTO actividadCulturalDTO = new ActividadCulturalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadCulturalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@ActividadCulturalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        actividadCulturalDTO.ActividadCulturalId = Convert.ToInt32(dr["ActividadCulturalId"]);
                        actividadCulturalDTO.NombreActividadCultural = dr["NombreActividadCultural"].ToString();
                        actividadCulturalDTO.TipoActividadCulturalId = Convert.ToInt32(dr["TipoActividadCulturalId"]);
                        actividadCulturalDTO.FechaInicioActCultural = Convert.ToDateTime(dr["FechaInicioActCultural"]).ToString("yyy-MM-dd");
                        actividadCulturalDTO.FechaTerminoActCultural = Convert.ToDateTime(dr["FechaTerminoActCultural"]).ToString("yyy-MM-dd");
                        actividadCulturalDTO.LugarActCultural = dr["LugarActCultural"].ToString();
                        actividadCulturalDTO.AuspiciadoresActCultural = dr["AuspiciadoresActCultural"].ToString();
                        actividadCulturalDTO.NParticipantesActCultural = Convert.ToInt32(dr["NParticipantesActCultural"]);
                        actividadCulturalDTO.InversionActCultural = Convert.ToDecimal(dr["InversionActCultural"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadCulturalDTO;
        }

        public string ActualizaFormato(ActividadCulturalDTO actividadCulturalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadCulturalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@ActividadCulturalId"].Value = actividadCulturalDTO.ActividadCulturalId;

                    cmd.Parameters.Add("@NombreActividadCultural", SqlDbType.VarChar, 250);
                    cmd.Parameters["@NombreActividadCultural"].Value = actividadCulturalDTO.NombreActividadCultural;

                    cmd.Parameters.Add("@TipoActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadCulturalId"].Value = actividadCulturalDTO.TipoActividadCulturalId;

                    cmd.Parameters.Add("@FechaInicioActCultural", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioActCultural"].Value = actividadCulturalDTO.FechaInicioActCultural;

                    cmd.Parameters.Add("@FechaTerminoActCultural", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoActCultural"].Value = actividadCulturalDTO.FechaTerminoActCultural;

                    cmd.Parameters.Add("@LugarActCultural", SqlDbType.VarChar, 250);
                    cmd.Parameters["@LugarActCultural"].Value = actividadCulturalDTO.LugarActCultural;

                    cmd.Parameters.Add("@AuspiciadoresActCultural", SqlDbType.VarChar, 250);
                    cmd.Parameters["@AuspiciadoresActCultural"].Value = actividadCulturalDTO.AuspiciadoresActCultural;

                    cmd.Parameters.Add("@NParticipantesActCultural", SqlDbType.Int);
                    cmd.Parameters["@NParticipantesActCultural"].Value = actividadCulturalDTO.NParticipantesActCultural;

                    cmd.Parameters.Add("@InversionActCultural", SqlDbType.Decimal);
                    cmd.Parameters["@InversionActCultural"].Value = actividadCulturalDTO.InversionActCultural;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadCulturalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActividadCulturalDTO actividadCulturalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadCulturalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@ActividadCulturalId"].Value = actividadCulturalDTO.ActividadCulturalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadCulturalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ActividadCulturalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadCultural", SqlDbType.Structured);
                    cmd.Parameters["@ActividadCultural"].TypeName = "Formato.ActividadCultural";
                    cmd.Parameters["@ActividadCultural"].Value = datos;

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
