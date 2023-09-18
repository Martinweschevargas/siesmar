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
    public class PatenteInvestigacionDesarrolloDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PatenteInvestigacionDesarrolloDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PatenteInvestigacionDesarrolloDTO> lista = new List<PatenteInvestigacionDesarrolloDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PatenteInvestigacionDesarrolloListar", conexion);
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
                        lista.Add(new PatenteInvestigacionDesarrolloDTO()
                        {
                            PatenteInvestigacionDesarrolloId = Convert.ToInt32(dr["PatenteInvestigacionDesarrolloId"]),
                            DenominacionPatenteInvestigacion = dr["DenominacionPatenteInvestigacion"].ToString(),
                            EstadoPatenteInvestigacion = dr["EstadoPatenteInvestigacion"].ToString(),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PatenteInvestigacionDesarrolloRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionPatenteInvestigacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@DenominacionPatenteInvestigacion"].Value = patenteInvestigacionDesarrolloDTO.DenominacionPatenteInvestigacion;

                    cmd.Parameters.Add("@EstadoPatenteInvestigacion", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EstadoPatenteInvestigacion"].Value = patenteInvestigacionDesarrolloDTO.EstadoPatenteInvestigacion;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaCT"].Value = patenteInvestigacionDesarrolloDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = patenteInvestigacionDesarrolloDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro;

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

        public PatenteInvestigacionDesarrolloDTO BuscarFormato(int Codigo)
        {
            PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO = new PatenteInvestigacionDesarrolloDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PatenteInvestigacionDesarrolloEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatenteInvestigacionDesarrolloId", SqlDbType.Int);
                    cmd.Parameters["@PatenteInvestigacionDesarrolloId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        patenteInvestigacionDesarrolloDTO.PatenteInvestigacionDesarrolloId = Convert.ToInt32(dr["PatenteInvestigacionDesarrolloId"]);
                        patenteInvestigacionDesarrolloDTO.DenominacionPatenteInvestigacion = dr["DenominacionPatenteInvestigacion"].ToString();
                        patenteInvestigacionDesarrolloDTO.EstadoPatenteInvestigacion = Regex.Replace(dr["EstadoPatenteInvestigacion"].ToString(), @"\s", "");
                        patenteInvestigacionDesarrolloDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return patenteInvestigacionDesarrolloDTO;
        }

        public string ActualizaFormato(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PatenteInvestigacionDesarrolloActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatenteInvestigacionDesarrolloId", SqlDbType.Int);
                    cmd.Parameters["@PatenteInvestigacionDesarrolloId"].Value = patenteInvestigacionDesarrolloDTO.PatenteInvestigacionDesarrolloId;

                    cmd.Parameters.Add("@DenominacionPatenteInvestigacion", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@DenominacionPatenteInvestigacion"].Value = patenteInvestigacionDesarrolloDTO.DenominacionPatenteInvestigacion;

                    cmd.Parameters.Add("@EstadoPatenteInvestigacion", SqlDbType.NChar, 15);
                    cmd.Parameters["@EstadoPatenteInvestigacion"].Value = patenteInvestigacionDesarrolloDTO.EstadoPatenteInvestigacion;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaCT"].Value = patenteInvestigacionDesarrolloDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PatenteInvestigacionDesarrolloEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatenteInvestigacionDesarrolloId", SqlDbType.Int);
                    cmd.Parameters["@PatenteInvestigacionDesarrolloId"].Value= patenteInvestigacionDesarrolloDTO.PatenteInvestigacionDesarrolloId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO)
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
                    cmd.Parameters["@Formato"].Value = "PatenteInvestigacionDesarrollo";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = patenteInvestigacionDesarrolloDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PatenteInvestigacionDesarrolloRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatenteInvestigacionDesarrollo", SqlDbType.Structured);
                    cmd.Parameters["@PatenteInvestigacionDesarrollo"].TypeName = "Formato.PatenteInvestigacionDesarrollo";
                    cmd.Parameters["@PatenteInvestigacionDesarrollo"].Value = datos;

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
