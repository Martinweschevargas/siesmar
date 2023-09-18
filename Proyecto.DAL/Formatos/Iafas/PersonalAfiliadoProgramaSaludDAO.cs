using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Iafas;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Iafas
{
    public class PersonalAfiliadoProgramaSaludDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PersonalAfiliadoProgramaSaludDTO> ObtenerLista(int? CargaId = null)
        {
            List<PersonalAfiliadoProgramaSaludDTO> lista = new List<PersonalAfiliadoProgramaSaludDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PersonalAfiliadoProgramaSaludListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalAfiliadoProgramaSaludDTO()
                        {
                            PersonalAfiliadoProgramaSaludId = Convert.ToInt32(dr["PersonalAfiliadoProgramaSaludId"]),
                            DocumentoAfiliado = dr["DocumentoAfiliado"].ToString(),
                            SexoPersonalAfiliado = dr["SexoPersonalAfiliado"].ToString(),
                            DescSituacionPersonalNaval = dr["MotivoDesafiliacion"].ToString(),
                            FechaAfiliacion = (dr["FechaAfiliacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescParentescoAfiliado = dr["DescParentescoAfiliado"].ToString(),
                            DescTipoAfiliacion = dr["DescTipoAfiliacion"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            MantieneAfiliado = dr["MantieneAfiliado"].ToString(),
                            FechaDesafiliacion = (dr["FechaDesafiliacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            MotivoDesafiliacion = dr["MotivoDesafiliacion"].ToString(),
                            DescFormaContactoAfiliado = dr["DescFormaContactoAfiliado"].ToString(),
                            ActivacionSeguroOncologico = dr["ActivacionSeguroOncologico"].ToString(),
                            ActivacionSeguroSegundaCapa = dr["ActivacionSeguroSegundaCapa"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalAfiliadoProgramaSaludRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoAfiliado", SqlDbType.VarChar,8);
                    cmd.Parameters["@DocumentoAfiliado"].Value = personalAfiliadoProgramaSaludDTO.DocumentoAfiliado;

                    cmd.Parameters.Add("@SexoPersonalAfiliado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonalAfiliado"].Value = personalAfiliadoProgramaSaludDTO.SexoPersonalAfiliado;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = personalAfiliadoProgramaSaludDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@FechaAfiliacion", SqlDbType.Date);
                    cmd.Parameters["@FechaAfiliacion"].Value = personalAfiliadoProgramaSaludDTO.FechaAfiliacion;

                    cmd.Parameters.Add("@CodigoParentescoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoParentescoAfiliado"].Value = personalAfiliadoProgramaSaludDTO.CodigoParentescoAfiliado;

                    cmd.Parameters.Add("@CodigoTipoAfiliacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAfiliacion"].Value = personalAfiliadoProgramaSaludDTO.CodigoTipoAfiliacion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = personalAfiliadoProgramaSaludDTO.DistritoUbigeo;


                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = personalAfiliadoProgramaSaludDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@MantieneAfiliado", SqlDbType.VarChar, 1);
                    cmd.Parameters["@MantieneAfiliado"].Value = personalAfiliadoProgramaSaludDTO.MantieneAfiliado;

                    cmd.Parameters.Add("@FechaDesafiliacion", SqlDbType.Date);
                    cmd.Parameters["@FechaDesafiliacion"].Value = personalAfiliadoProgramaSaludDTO.FechaDesafiliacion;

                    cmd.Parameters.Add("@MotivoDesafiliacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@MotivoDesafiliacion"].Value = personalAfiliadoProgramaSaludDTO.MotivoDesafiliacion;

                    cmd.Parameters.Add("@CodigoFormaContactoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFormaContactoAfiliado"].Value = personalAfiliadoProgramaSaludDTO.CodigoFormaContactoAfiliado;

                    cmd.Parameters.Add("@ActivacionSeguroOncologico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ActivacionSeguroOncologico"].Value = personalAfiliadoProgramaSaludDTO.ActivacionSeguroOncologico;

                    cmd.Parameters.Add("@ActivacionSeguroSegundaCapa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ActivacionSeguroSegundaCapa"].Value = personalAfiliadoProgramaSaludDTO.ActivacionSeguroSegundaCapa;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalAfiliadoProgramaSaludDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalAfiliadoProgramaSaludDTO.UsuarioIngresoRegistro;

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

        public PersonalAfiliadoProgramaSaludDTO BuscarFormato(int Codigo)
        {
            PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO = new PersonalAfiliadoProgramaSaludDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalAfiliadoProgramaSaludEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalAfiliadoProgramaSaludId", SqlDbType.Int);
                    cmd.Parameters["@PersonalAfiliadoProgramaSaludId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        personalAfiliadoProgramaSaludDTO.PersonalAfiliadoProgramaSaludId = Convert.ToInt32(dr["PersonalAfiliadoProgramaSaludId"]);
                        personalAfiliadoProgramaSaludDTO.DocumentoAfiliado = dr["DocumentoAfiliado"].ToString();
                        personalAfiliadoProgramaSaludDTO.SexoPersonalAfiliado = dr["SexoPersonalAfiliado"].ToString();
                        personalAfiliadoProgramaSaludDTO.CodigoSituacionPersonalNaval = dr["CodigoSituacionPersonalNaval"].ToString();
                        personalAfiliadoProgramaSaludDTO.FechaAfiliacion = Convert.ToDateTime(dr["FechaAfiliacion"]).ToString("yyy-MM-dd");
                        personalAfiliadoProgramaSaludDTO.CodigoParentescoAfiliado = dr["CodigoParentescoAfiliado"].ToString();
                        personalAfiliadoProgramaSaludDTO.CodigoTipoAfiliacion = dr["CodigoTipoAfiliacion"].ToString();
                        personalAfiliadoProgramaSaludDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        personalAfiliadoProgramaSaludDTO.ProvinciaUbigeo = dr["DistritoUbigeo"].ToString();
                        personalAfiliadoProgramaSaludDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        personalAfiliadoProgramaSaludDTO.MantieneAfiliado = dr["MantieneAfiliado"].ToString();
                        personalAfiliadoProgramaSaludDTO.FechaDesafiliacion = Convert.ToDateTime(dr["FechaDesafiliacion"]).ToString("yyy-MM-dd");
                        personalAfiliadoProgramaSaludDTO.MotivoDesafiliacion = dr["MotivoDesafiliacion"].ToString();
                        personalAfiliadoProgramaSaludDTO.CodigoFormaContactoAfiliado = dr["CodigoFormaContactoAfiliado"].ToString();
                        personalAfiliadoProgramaSaludDTO.ActivacionSeguroOncologico = dr["ActivacionSeguroOncologico"].ToString();
                        personalAfiliadoProgramaSaludDTO.ActivacionSeguroSegundaCapa = dr["ActivacionSeguroSegundaCapa"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personalAfiliadoProgramaSaludDTO;
        }

        public string ActualizaFormato(PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalAfiliadoProgramaSaludActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PersonalAfiliadoProgramaSaludId", SqlDbType.Int);
                    cmd.Parameters["@PersonalAfiliadoProgramaSaludId"].Value = personalAfiliadoProgramaSaludDTO.PersonalAfiliadoProgramaSaludId;

                    cmd.Parameters.Add("@DocumentoAfiliado", SqlDbType.VarChar,8);
                    cmd.Parameters["@DocumentoAfiliado"].Value = personalAfiliadoProgramaSaludDTO.DocumentoAfiliado;

                    cmd.Parameters.Add("@SexoPersonalAfiliado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonalAfiliado"].Value = personalAfiliadoProgramaSaludDTO.SexoPersonalAfiliado;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = personalAfiliadoProgramaSaludDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@FechaAfiliacion", SqlDbType.Date);
                    cmd.Parameters["@FechaAfiliacion"].Value = personalAfiliadoProgramaSaludDTO.FechaAfiliacion;

                    cmd.Parameters.Add("@CodigoParentescoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoParentescoAfiliado"].Value = personalAfiliadoProgramaSaludDTO.CodigoParentescoAfiliado;

                    cmd.Parameters.Add("@CodigoTipoAfiliacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAfiliacion"].Value = personalAfiliadoProgramaSaludDTO.CodigoTipoAfiliacion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = personalAfiliadoProgramaSaludDTO.DistritoUbigeo;


                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = personalAfiliadoProgramaSaludDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@MantieneAfiliado", SqlDbType.VarChar, 1);
                    cmd.Parameters["@MantieneAfiliado"].Value = personalAfiliadoProgramaSaludDTO.MantieneAfiliado;

                    cmd.Parameters.Add("@FechaDesafiliacion", SqlDbType.Date);
                    cmd.Parameters["@FechaDesafiliacion"].Value = personalAfiliadoProgramaSaludDTO.FechaDesafiliacion;

                    cmd.Parameters.Add("@MotivoDesafiliacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@MotivoDesafiliacion"].Value = personalAfiliadoProgramaSaludDTO.MotivoDesafiliacion;

                    cmd.Parameters.Add("@CodigoFormaContactoAfiliado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFormaContactoAfiliado"].Value = personalAfiliadoProgramaSaludDTO.CodigoFormaContactoAfiliado;

                    cmd.Parameters.Add("@ActivacionSeguroOncologico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ActivacionSeguroOncologico"].Value = personalAfiliadoProgramaSaludDTO.ActivacionSeguroOncologico;

                    cmd.Parameters.Add("@ActivacionSeguroSegundaCapa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ActivacionSeguroSegundaCapa"].Value = personalAfiliadoProgramaSaludDTO.ActivacionSeguroSegundaCapa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalAfiliadoProgramaSaludDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalAfiliadoProgramaSaludEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalAfiliadoProgramaSaludId", SqlDbType.Int);
                    cmd.Parameters["@PersonalAfiliadoProgramaSaludId"].Value = personalAfiliadoProgramaSaludDTO.PersonalAfiliadoProgramaSaludId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalAfiliadoProgramaSaludDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalAfiliadoProgramaSalud", SqlDbType.Structured);
                    cmd.Parameters["@PersonalAfiliadoProgramaSalud"].TypeName = "Formato.PersonalAfiliadoProgramaSalud";
                    cmd.Parameters["@PersonalAfiliadoProgramaSalud"].Value = datos;

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
