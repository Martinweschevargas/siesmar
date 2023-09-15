using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class SiniestroAcuaticoActivacionRadiobalizaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SiniestroAcuaticoActivacionRadiobalizaDTO> ObtenerLista()
        {
            List<SiniestroAcuaticoActivacionRadiobalizaDTO> lista = new List<SiniestroAcuaticoActivacionRadiobalizaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SiniestroAcuaticoActivacionRadiobalizaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SiniestroAcuaticoActivacionRadiobalizaDTO()
                        {
                            SiniestroAcuaticoActivacionRadiobalizaId = Convert.ToInt32(dr["SiniestroAcuaticoActivacionRadiobalizaId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraSiniestro = dr["HoraSiniestro"].ToString(),
                            FechaSiniestro = (dr["FechaSiniestro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NombreNaveSiniestro = dr["NombreNaveSiniestro"].ToString(),
                            MatriculaNaveSiniestro = dr["MatriculaNaveSiniestro"].ToString(),
                            ABEdad = Convert.ToInt32(dr["ABEdad"]),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoSiniestro = dr["DescTipoSiniestro"].ToString(),
                            CuentaRadiobaliza = dr["CuentaRadiobaliza"].ToString(),
                            ActivoRadiobaliza = dr["ActivoRadiobaliza"].ToString(),
                            TipoActivacionRadiobaliza = dr["TipoActivacionRadiobaliza"].ToString(),
                            DescTipoRadiobaliza = dr["DescTipoRadiobaliza"].ToString(),
                            CodigoHexadecimal = dr["CodigoHexadecimal"].ToString(),
                            ActivoPlanBusqueda = dr["ActivoPlanBusqueda"].ToString(),
                            MNReferenciaActivacion = dr["MNReferenciaActivacion"].ToString(),
                            MNReferenciaDesactiva = dr["MNReferenciaDesactiva"].ToString(),
                            TiempoDuracionHoras = Convert.ToInt32(dr["TiempoDuracionHoras"]),
                            LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString(),
                            LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString(),
                            DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                            PersonasRescatadasVida = Convert.ToInt32(dr["PersonasRescatadasVida"]),
                            PersonasFallecidas = Convert.ToInt32(dr["PersonasFallecidas"]),
                            PersonasDesaparecida = Convert.ToInt32(dr["PersonasDesaparecida"]),
                            TotalPersonas = Convert.ToInt32(dr["TotalPersonas"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            UnidadesParticulares = dr["UnidadesParticulares"].ToString(),
                            ResumenCaso = dr["ResumenCaso"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SiniestroAcuaticoActivacionRadiobalizaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                  
                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraSiniestro", SqlDbType.Time);
                    cmd.Parameters["@HoraSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.HoraSiniestro;

                    cmd.Parameters.Add("@FechaSiniestro", SqlDbType.Date);
                    cmd.Parameters["@FechaSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.FechaSiniestro;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoNaveId;

                    cmd.Parameters.Add("@NombreNaveSiniestro", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNaveSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.NombreNaveSiniestro;

                    cmd.Parameters.Add("@MatriculaNaveSiniestro", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNaveSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.MatriculaNaveSiniestro;

                    cmd.Parameters.Add("@ABEdad", SqlDbType.Int);
                    cmd.Parameters["@ABEdad"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ABEdad;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@CuentaRadiobaliza", SqlDbType.NChar,1);
                    cmd.Parameters["@CuentaRadiobaliza"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.CuentaRadiobaliza;

                    cmd.Parameters.Add("@ActivoRadiobaliza", SqlDbType.NChar,1);
                    cmd.Parameters["@ActivoRadiobaliza"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ActivoRadiobaliza;

                    cmd.Parameters.Add("@TipoActivacionRadiobaliza", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoActivacionRadiobaliza"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoActivacionRadiobaliza;

                    cmd.Parameters.Add("@TipoRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@TipoRadiobalizaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoRadiobalizaId;

                    cmd.Parameters.Add("@CodigoHexadecimal", SqlDbType.VarChar,10);
                    cmd.Parameters["@CodigoHexadecimal"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.CodigoHexadecimal;

                    cmd.Parameters.Add("@ActivoPlanBusqueda", SqlDbType.NChar,1);
                    cmd.Parameters["@ActivoPlanBusqueda"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ActivoPlanBusqueda;

                    cmd.Parameters.Add("@MNReferenciaActivacion", SqlDbType.VarChar,10);
                    cmd.Parameters["@MNReferenciaActivacion"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaActivacion;

                    cmd.Parameters.Add("@MNReferenciaDesactiva", SqlDbType.VarChar, 10);
                    cmd.Parameters["@MNReferenciaDesactiva"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaDesactiva;

                    cmd.Parameters.Add("@TiempoDuracionHoras", SqlDbType.Int);
                    cmd.Parameters["@TiempoDuracionHoras"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TiempoDuracionHoras;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@PersonasRescatadasVida", SqlDbType.Int);
                    cmd.Parameters["@PersonasRescatadasVida"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PersonasRescatadasVida;

                    cmd.Parameters.Add("@PersonasFallecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasFallecidas"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PersonasFallecidas;

                    cmd.Parameters.Add("@PersonasDesaparecida", SqlDbType.Int);
                    cmd.Parameters["@PersonasDesaparecida"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PersonasDesaparecida;

                    cmd.Parameters.Add("@TotalPersonas", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonas"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TotalPersonas;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UnidadNavalId;

                    cmd.Parameters.Add("@UnidadesParticulares", SqlDbType.VarChar,20);
                    cmd.Parameters["@UnidadesParticulares"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UnidadesParticulares;

                    cmd.Parameters.Add("@ResumenCaso", SqlDbType.VarChar,100);
                    cmd.Parameters["@ResumenCaso"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ResumenCaso;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UsuarioIngresoRegistro;

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

        public SiniestroAcuaticoActivacionRadiobalizaDTO BuscarFormato(int Codigo)
        {
            SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO = new SiniestroAcuaticoActivacionRadiobalizaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SiniestroAcuaticoActivacionRadiobalizaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SiniestroAcuaticoActivacionRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@SiniestroAcuaticoActivacionRadiobalizaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        siniestroAcuaticoActivacionRadiobalizaDTO.SiniestroAcuaticoActivacionRadiobalizaId = Convert.ToInt32(dr["SiniestroAcuaticoActivacionRadiobalizaId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.HoraSiniestro = dr["HoraSiniestro"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.FechaSiniestro = Convert.ToDateTime(dr["FechaSiniestro"]).ToString("yyy-MM-dd");
                        siniestroAcuaticoActivacionRadiobalizaDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.NombreNaveSiniestro = dr["NombreNaveSiniestro"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.MatriculaNaveSiniestro = dr["MatriculaNaveSiniestro"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.ABEdad = Convert.ToInt32(dr["ABEdad"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.TipoSiniestroId = Convert.ToInt32(dr["TipoSiniestroId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.CuentaRadiobaliza = dr["CuentaRadiobaliza"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.ActivoRadiobaliza = dr["ActivoRadiobaliza"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.TipoActivacionRadiobaliza = dr["TipoActivacionRadiobaliza"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.TipoRadiobalizaId = Convert.ToInt32(dr["TipoRadiobalizaId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.CodigoHexadecimal = dr["CodigoHexadecimal"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.ActivoPlanBusqueda = dr["ActivoPlanBusqueda"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaActivacion = dr["MNReferenciaActivacion"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaDesactiva = dr["MNReferenciaDesactiva"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.TiempoDuracionHoras = Convert.ToInt32(dr["TiempoDuracionHoras"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.PersonasRescatadasVida = Convert.ToInt32(dr["PersonasRescatadasVida"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.PersonasFallecidas = Convert.ToInt32(dr["PersonasFallecidas"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.PersonasDesaparecida = Convert.ToInt32(dr["PersonasDesaparecida"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.TotalPersonas = Convert.ToInt32(dr["TotalPersonas"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        siniestroAcuaticoActivacionRadiobalizaDTO.UnidadesParticulares = dr["UnidadesParticulares"].ToString();
                        siniestroAcuaticoActivacionRadiobalizaDTO.ResumenCaso = dr["ResumenCaso"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return siniestroAcuaticoActivacionRadiobalizaDTO;
        }

        public string ActualizaFormato(SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SiniestroAcuaticoActivacionRadiobalizaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SiniestroAcuaticoActivacionRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@SiniestroAcuaticoActivacionRadiobalizaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.SiniestroAcuaticoActivacionRadiobalizaId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraSiniestro", SqlDbType.Time);
                    cmd.Parameters["@HoraSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.HoraSiniestro;

                    cmd.Parameters.Add("@FechaSiniestro", SqlDbType.Date);
                    cmd.Parameters["@FechaSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.FechaSiniestro;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoNaveId;

                    cmd.Parameters.Add("@NombreNaveSiniestro", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNaveSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.NombreNaveSiniestro;

                    cmd.Parameters.Add("@MatriculaNaveSiniestro", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNaveSiniestro"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.MatriculaNaveSiniestro;

                    cmd.Parameters.Add("@ABEdad", SqlDbType.Int);
                    cmd.Parameters["@ABEdad"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ABEdad;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@CuentaRadiobaliza", SqlDbType.NChar, 1);
                    cmd.Parameters["@CuentaRadiobaliza"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.CuentaRadiobaliza;

                    cmd.Parameters.Add("@ActivoRadiobaliza", SqlDbType.NChar, 1);
                    cmd.Parameters["@ActivoRadiobaliza"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ActivoRadiobaliza;

                    cmd.Parameters.Add("@TipoActivacionRadiobaliza", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoActivacionRadiobaliza"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoActivacionRadiobaliza;

                    cmd.Parameters.Add("@TipoRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@TipoRadiobalizaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TipoRadiobalizaId;

                    cmd.Parameters.Add("@CodigoHexadecimal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoHexadecimal"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.CodigoHexadecimal;

                    cmd.Parameters.Add("@ActivoPlanBusqueda", SqlDbType.NChar, 1);
                    cmd.Parameters["@ActivoPlanBusqueda"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ActivoPlanBusqueda;

                    cmd.Parameters.Add("@MNReferenciaActivacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@MNReferenciaActivacion"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaActivacion;

                    cmd.Parameters.Add("@MNReferenciaDesactiva", SqlDbType.VarChar, 10);
                    cmd.Parameters["@MNReferenciaDesactiva"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaDesactiva;

                    cmd.Parameters.Add("@TiempoDuracionHoras", SqlDbType.Int);
                    cmd.Parameters["@TiempoDuracionHoras"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TiempoDuracionHoras;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@PersonasRescatadasVida", SqlDbType.Int);
                    cmd.Parameters["@PersonasRescatadasVida"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PersonasRescatadasVida;

                    cmd.Parameters.Add("@PersonasFallecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasFallecidas"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PersonasFallecidas;

                    cmd.Parameters.Add("@PersonasDesaparecida", SqlDbType.Int);
                    cmd.Parameters["@PersonasDesaparecida"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.PersonasDesaparecida;

                    cmd.Parameters.Add("@TotalPersonas", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonas"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.TotalPersonas;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UnidadNavalId;

                    cmd.Parameters.Add("@UnidadesParticulares", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UnidadesParticulares"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UnidadesParticulares;

                    cmd.Parameters.Add("@ResumenCaso", SqlDbType.VarChar, 100);
                    cmd.Parameters["@ResumenCaso"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.ResumenCaso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SiniestroAcuaticoActivacionRadiobalizaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SiniestroAcuaticoActivacionRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@SiniestroAcuaticoActivacionRadiobalizaId"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.SiniestroAcuaticoActivacionRadiobalizaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = siniestroAcuaticoActivacionRadiobalizaDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<SiniestroAcuaticoActivacionRadiobalizaDTO> siniestroAcuaticoActivacionRadiobalizaDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conexion;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Formato.EstudiosInvestigacionHistoricaNaval " +
                            " (NombreInvestigacion, TipoEstudioInvestigacionId, FechaInicioInvestigacion, " +
                            "FechaTerminoInvestigacion, ResponsableInvestigacion, SolicitanteInvestigacion, " +
                            "UsuarioIngresoRegistro, FechaIngresoRegistro, NroIpRegistro, NroMacRegistro, " +
                            "UsuarioBaseDatos, CodigoIngreso, Año, Mes, Dia) values (@NombreInvestigacion, " +
                            "@TipoEstudioInvestigacionId, @FechaInicioInvestigacion, @FechaTerminoInvestigacion, " +
                            "@ResponsableInvestigacion, @SolicitanteInvestigacion, @Usuario, GETDATE(), @IP, @MAC, " +
                            "@UsuarioDB, 0, @YEAR, @MES, @DIA)";
                        cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                        cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@MAC", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@UsuarioDB", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                        cmd.Parameters.Add("@MES", SqlDbType.Int);
                        cmd.Parameters.Add("@DIA", SqlDbType.Int);
                        try
                        {
                            foreach (var item in siniestroAcuaticoActivacionRadiobalizaDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreTemaEstudioInvestigacion;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoEstudioInvestigacionIds;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicio);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTermino);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.Responsable;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.Solicitante;
                                cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            respuesta = true;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();                    
                            throw;
                        }
                        finally
                        {
                            conexion.Close();
                        }
                    }
                }
            }
            return respuesta;
        }
    }
}
