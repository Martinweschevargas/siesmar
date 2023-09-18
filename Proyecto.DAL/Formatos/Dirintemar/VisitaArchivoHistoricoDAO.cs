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
    public class VisitaArchivoHistoricoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<VisitaArchivoHistoricoDTO> ObtenerLista()
        {
            List<VisitaArchivoHistoricoDTO> lista = new List<VisitaArchivoHistoricoDTO>();
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_VisitaArchivoHistoricoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new VisitaArchivoHistoricoDTO()
                        {
                            VisitaArchivoHistoricoId = Convert.ToInt32(dr["VisitaArchivoHistoricoId"]),
                            FechaVisitaArchivoHistorico = (dr["FechaVisitaArchivoHistorico"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            VisitanteArchivoHistorico = dr["VisitanteArchivoHistorico"].ToString(),
                            DocIdentidadVisita = dr["DocIdentidadVisita"].ToString(),
                            DescTipoVisitaGeneral = dr["DescTipoVisitaGeneral"].ToString(),
                            EntidadVisita = dr["EntidadVisita"].ToString(),
                            TemaArchivoHistorico = dr["TemaArchivoHistorico"].ToString(),
                            NacionalidadVisitante = dr["NacionalidadVisitante"].ToString()

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VisitaArchivoHistoricoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaVisitaArchivoHistorico", SqlDbType.Date);
                    cmd.Parameters["@FechaVisitaArchivoHistorico"].Value = visitaArchivoHistoricoDTO.FechaVisitaArchivoHistorico;

                    cmd.Parameters.Add("@VisitanteArchivoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@VisitanteArchivoHistorico"].Value = visitaArchivoHistoricoDTO.VisitanteArchivoHistorico;

                    cmd.Parameters.Add("@DocIdentidadVisita", SqlDbType.NChar,8);
                    cmd.Parameters["@DocIdentidadVisita"].Value = visitaArchivoHistoricoDTO.DocIdentidadVisita;

                    cmd.Parameters.Add("@TipoVisitaGeneralId", SqlDbType.Int);
                    cmd.Parameters["@TipoVisitaGeneralId"].Value = visitaArchivoHistoricoDTO.TipoVisitaGeneralId;

                    cmd.Parameters.Add("@EntidadVisita", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EntidadVisita"].Value = visitaArchivoHistoricoDTO.EntidadVisita;

                    cmd.Parameters.Add("@TemaArchivoHistorico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@TemaArchivoHistorico"].Value = visitaArchivoHistoricoDTO.TemaArchivoHistorico;

                    cmd.Parameters.Add("@NacionalidadVisitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NacionalidadVisitante"].Value = visitaArchivoHistoricoDTO.NacionalidadVisitante;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaArchivoHistoricoDTO.UsuarioIngresoRegistro;

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

        public VisitaArchivoHistoricoDTO BuscarFormato(int Codigo)
        {
            VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO = new VisitaArchivoHistoricoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaArchivoHistoricoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaArchivoHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@VisitaArchivoHistoricoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        visitaArchivoHistoricoDTO.VisitaArchivoHistoricoId = Convert.ToInt32(dr["VisitaArchivoHistoricoId"]);
                        visitaArchivoHistoricoDTO.FechaVisitaArchivoHistorico = Convert.ToDateTime(dr["FechaVisitaArchivoHistorico"]).ToString("yyy-MM-dd");
                        visitaArchivoHistoricoDTO.VisitanteArchivoHistorico = dr["VisitanteArchivoHistorico"].ToString();
                        visitaArchivoHistoricoDTO.DocIdentidadVisita = dr["DocIdentidadVisita"].ToString();
                        visitaArchivoHistoricoDTO.TipoVisitaGeneralId = Convert.ToInt32(dr["TipoVisitaGeneralId"]);
                        visitaArchivoHistoricoDTO.EntidadVisita = dr["EntidadVisita"].ToString();
                        visitaArchivoHistoricoDTO.TemaArchivoHistorico = dr["TemaArchivoHistorico"].ToString();
                        visitaArchivoHistoricoDTO.NacionalidadVisitante = dr["NacionalidadVisitante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return visitaArchivoHistoricoDTO;
        }

        public string ActualizaFormato(VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VisitaArchivoHistoricoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaArchivoHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@VisitaArchivoHistoricoId"].Value = visitaArchivoHistoricoDTO.VisitaArchivoHistoricoId;


                    cmd.Parameters.Add("@FechaVisitaArchivoHistorico", SqlDbType.Date);
                    cmd.Parameters["@FechaVisitaArchivoHistorico"].Value = visitaArchivoHistoricoDTO.FechaVisitaArchivoHistorico;

                    cmd.Parameters.Add("@VisitanteArchivoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@VisitanteArchivoHistorico"].Value = visitaArchivoHistoricoDTO.VisitanteArchivoHistorico;

                    cmd.Parameters.Add("@DocIdentidadVisita", SqlDbType.NChar, 8);
                    cmd.Parameters["@DocIdentidadVisita"].Value = visitaArchivoHistoricoDTO.DocIdentidadVisita;

                    cmd.Parameters.Add("@TipoVisitaGeneralId", SqlDbType.Int);
                    cmd.Parameters["@TipoVisitaGeneralId"].Value = visitaArchivoHistoricoDTO.TipoVisitaGeneralId;

                    cmd.Parameters.Add("@EntidadVisita", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EntidadVisita"].Value = visitaArchivoHistoricoDTO.EntidadVisita;

                    cmd.Parameters.Add("@TemaArchivoHistorico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@TemaArchivoHistorico"].Value = visitaArchivoHistoricoDTO.TemaArchivoHistorico;

                    cmd.Parameters.Add("@NacionalidadVisitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NacionalidadVisitante"].Value = visitaArchivoHistoricoDTO.NacionalidadVisitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaArchivoHistoricoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;       
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarFormato(VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaArchivoHistoricoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaArchivoHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@VisitaArchivoHistoricoId"].Value = visitaArchivoHistoricoDTO.VisitaArchivoHistoricoId;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaArchivoHistoricoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_VisitaArchivoHistoricoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaArchivoHistorico", SqlDbType.Structured);
                    cmd.Parameters["@VisitaArchivoHistorico"].TypeName = "Formato.VisitaArchivoHistorico";
                    cmd.Parameters["@VisitaArchivoHistorico"].Value = datos;

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
