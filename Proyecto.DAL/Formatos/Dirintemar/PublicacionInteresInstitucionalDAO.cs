using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class PublicacionInteresInstitucionalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PublicacionInteresInstitucionalDTO> ObtenerLista()
        {
            List<PublicacionInteresInstitucionalDTO> lista = new List<PublicacionInteresInstitucionalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PublicacionInteresInstitucionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PublicacionInteresInstitucionalDTO()
                        {
                            PublicacionInteresInstitucionalId = Convert.ToInt32(dr["PublicacionInteresInstitucionalId"]),
                            DescTipoPublicacion = dr["DescTipoPublicacion"].ToString(),
                            DenominacionTemaPublicacion = dr["DenominacionTemaPublicacion"].ToString(),
                            NroPublicacion = dr["NroPublicacion"].ToString(),
                            FechaPublicacion = (dr["FechaPublicacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroEjemplaresPublicados = Convert.ToInt32(dr["NumeroEjemplaresPublicados"]),
                            NroSuscriptores = Convert.ToInt32(dr["NroSuscriptores"]),
                            PromotorPublicaciones = dr["PromotorPublicaciones"].ToString(),
                            ResponsablePublicacion = dr["ResponsablePublicacion"].ToString(),
                            InversionPublicacion = Convert.ToDecimal(dr["InversionPublicacion"]),
                        });
                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PublicacionInteresInstitucionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPublicacionId", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPublicacionId"].Value = publicacionInteresInstitucionalDTO.TipoPublicacionId;

                    cmd.Parameters.Add("@DenominacionTemaPublicacion", SqlDbType.VarChar, 60);
                    cmd.Parameters["@DenominacionTemaPublicacion"].Value = publicacionInteresInstitucionalDTO.DenominacionTemaPublicacion;

                    cmd.Parameters.Add("@NroPublicacion", SqlDbType.VarChar,10);
                    cmd.Parameters["@NroPublicacion"].Value = publicacionInteresInstitucionalDTO.NroPublicacion;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaPublicacion"].Value = publicacionInteresInstitucionalDTO.FechaPublicacion;

                    cmd.Parameters.Add("@NumeroEjemplaresPublicados", SqlDbType.Int, 6);
                    cmd.Parameters["@NumeroEjemplaresPublicados"].Value = publicacionInteresInstitucionalDTO.NumeroEjemplaresPublicados;

                    cmd.Parameters.Add("@NroSuscriptores", SqlDbType.Int, 6);
                    cmd.Parameters["@NroSuscriptores"].Value = publicacionInteresInstitucionalDTO.NroSuscriptores;

                    cmd.Parameters.Add("@PromotorPublicaciones", SqlDbType.VarChar,60);
                    cmd.Parameters["@PromotorPublicaciones"].Value = publicacionInteresInstitucionalDTO.PromotorPublicaciones;

                    cmd.Parameters.Add("@ResponsablePublicacion", SqlDbType.VarChar, 60);
                    cmd.Parameters["@ResponsablePublicacion"].Value = publicacionInteresInstitucionalDTO.ResponsablePublicacion;

                    cmd.Parameters.Add("@InversionPublicacion", SqlDbType.Decimal);
                    cmd.Parameters["@InversionPublicacion"].Value = publicacionInteresInstitucionalDTO.InversionPublicacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicacionInteresInstitucionalDTO.UsuarioIngresoRegistro;

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

        public PublicacionInteresInstitucionalDTO BuscarFormato(int Codigo)
        {
            PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO = new PublicacionInteresInstitucionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PublicacionInteresInstitucionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicacionInteresInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@PublicacionInteresInstitucionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        publicacionInteresInstitucionalDTO.PublicacionInteresInstitucionalId = Convert.ToInt32(dr["PublicacionInteresInstitucionalId"]);
                        publicacionInteresInstitucionalDTO.TipoPublicacionId = Convert.ToInt32(dr["TipoPublicacionId"]);
                        publicacionInteresInstitucionalDTO.DenominacionTemaPublicacion = dr["DenominacionTemaPublicacion"].ToString();
                        publicacionInteresInstitucionalDTO.NroPublicacion = dr["NroPublicacion"].ToString();
                        publicacionInteresInstitucionalDTO.FechaPublicacion = Convert.ToDateTime(dr["FechaPublicacion"]).ToString("yyy-MM-dd");
                        publicacionInteresInstitucionalDTO.NumeroEjemplaresPublicados = Convert.ToInt32(dr["NumeroEjemplaresPublicados"]);
                        publicacionInteresInstitucionalDTO.NroSuscriptores = Convert.ToInt32(dr["NroSuscriptores"]);
                        publicacionInteresInstitucionalDTO.PromotorPublicaciones = dr["PromotorPublicaciones"].ToString();
                        publicacionInteresInstitucionalDTO.ResponsablePublicacion = dr["ResponsablePublicacion"].ToString();
                        publicacionInteresInstitucionalDTO.InversionPublicacion = Convert.ToDecimal(dr["InversionPublicacion"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return publicacionInteresInstitucionalDTO;
        }

        public string ActualizaFormato(PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PublicacionInteresInstitucionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicacionInteresInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@PublicacionInteresInstitucionalId"].Value = publicacionInteresInstitucionalDTO.PublicacionInteresInstitucionalId;

                    cmd.Parameters.Add("@TipoPublicacionId", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPublicacionId"].Value = publicacionInteresInstitucionalDTO.TipoPublicacionId;

                    cmd.Parameters.Add("@DenominacionTemaPublicacion", SqlDbType.VarChar, 60);
                    cmd.Parameters["@DenominacionTemaPublicacion"].Value = publicacionInteresInstitucionalDTO.DenominacionTemaPublicacion;

                    cmd.Parameters.Add("@NroPublicacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@NroPublicacion"].Value = publicacionInteresInstitucionalDTO.NroPublicacion;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaPublicacion"].Value = publicacionInteresInstitucionalDTO.FechaPublicacion;

                    cmd.Parameters.Add("@NumeroEjemplaresPublicados", SqlDbType.Int, 6);
                    cmd.Parameters["@NumeroEjemplaresPublicados"].Value = publicacionInteresInstitucionalDTO.NumeroEjemplaresPublicados;

                    cmd.Parameters.Add("@NroSuscriptores", SqlDbType.Int, 6);
                    cmd.Parameters["@NroSuscriptores"].Value = publicacionInteresInstitucionalDTO.NroSuscriptores;

                    cmd.Parameters.Add("@PromotorPublicaciones", SqlDbType.VarChar, 60);
                    cmd.Parameters["@PromotorPublicaciones"].Value = publicacionInteresInstitucionalDTO.PromotorPublicaciones;

                    cmd.Parameters.Add("@ResponsablePublicacion", SqlDbType.VarChar, 60);
                    cmd.Parameters["@ResponsablePublicacion"].Value = publicacionInteresInstitucionalDTO.ResponsablePublicacion;

                    cmd.Parameters.Add("@InversionPublicacion", SqlDbType.Decimal);
                    cmd.Parameters["@InversionPublicacion"].Value = publicacionInteresInstitucionalDTO.InversionPublicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicacionInteresInstitucionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PublicacionInteresInstitucionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicacionInteresInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@PublicacionInteresInstitucionalId"].Value = publicacionInteresInstitucionalDTO.PublicacionInteresInstitucionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = publicacionInteresInstitucionalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PublicacionInteresInstitucionalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PublicacionInteresInstitucional", SqlDbType.Structured);
                    cmd.Parameters["@PublicacionInteresInstitucional"].TypeName = "Formato.PublicacionInteresInstitucional";
                    cmd.Parameters["@PublicacionInteresInstitucional"].Value = datos;

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
