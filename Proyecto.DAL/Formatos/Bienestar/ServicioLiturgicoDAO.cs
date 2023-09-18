using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class ServicioLiturgicoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioLiturgicoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioLiturgicoDTO> lista = new List<ServicioLiturgicoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioLiturgicoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioLiturgicoDTO()
                        {
                            ServicioLiturgicoId = Convert.ToInt32(dr["ServicioLiturgicoId"]),
                            FechaServicioLiturgico = (dr["FechaServicioLiturgico"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            DescServicioReligioso = dr["DescServicioReligioso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<ServicioLiturgicoDTO> BienestarVisualizacionServicioLiturgico(int CargaId)
        {
            List<ServicioLiturgicoDTO> lista = new List<ServicioLiturgicoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionServicioLiturgico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioLiturgicoDTO()
                        {
                            FechaServicioLiturgico = dr["FechaServicioLiturgico"].ToString(),
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            DescServicioReligioso = dr["DescServicioReligioso"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioLiturgicoDTO servicioLiturgicoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioLiturgicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaServicioLiturgico", SqlDbType.Date);
                    cmd.Parameters["@FechaServicioLiturgico"].Value = servicioLiturgicoDTO.FechaServicioLiturgico;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = servicioLiturgicoDTO.DNISolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = servicioLiturgicoDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = servicioLiturgicoDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioLiturgicoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = servicioLiturgicoDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = servicioLiturgicoDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@CodigoServicioReligioso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoServicioReligioso"].Value = servicioLiturgicoDTO.CodigoServicioReligioso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioLiturgicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLiturgicoDTO.UsuarioIngresoRegistro;

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

        public ServicioLiturgicoDTO BuscarFormato(int Codigo)
        {
            ServicioLiturgicoDTO servicioLiturgicoDTO = new ServicioLiturgicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioLiturgicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLiturgicoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLiturgicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        servicioLiturgicoDTO.ServicioLiturgicoId = Convert.ToInt32(dr["ServicioLiturgicoId"]);
                        servicioLiturgicoDTO.FechaServicioLiturgico = Convert.ToDateTime(dr["FechaServicioLiturgico"]).ToString("yyy-MM-dd");
                        servicioLiturgicoDTO.DNISolicitante = dr["DNISolicitante"].ToString();
                        servicioLiturgicoDTO.CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString();
                        servicioLiturgicoDTO.CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString();
                        servicioLiturgicoDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        servicioLiturgicoDTO.CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString();
                        servicioLiturgicoDTO.CodigoCategoriaPago = dr["CodigoCategoriaPago"].ToString();
                        servicioLiturgicoDTO.CodigoServicioReligioso = dr["CodigoServicioReligioso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioLiturgicoDTO;
        }

        public string ActualizaFormato(ServicioLiturgicoDTO servicioLiturgicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioLiturgicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioLiturgicoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLiturgicoId"].Value = servicioLiturgicoDTO.ServicioLiturgicoId;

                    cmd.Parameters.Add("@FechaServicioLiturgico", SqlDbType.Date);
                    cmd.Parameters["@FechaServicioLiturgico"].Value = servicioLiturgicoDTO.FechaServicioLiturgico;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = servicioLiturgicoDTO.DNISolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = servicioLiturgicoDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = servicioLiturgicoDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioLiturgicoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = servicioLiturgicoDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = servicioLiturgicoDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@CodigoServicioReligioso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoServicioReligioso"].Value = servicioLiturgicoDTO.CodigoServicioReligioso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLiturgicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioLiturgicoDTO servicioLiturgicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioLiturgicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLiturgicoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLiturgicoId"].Value = servicioLiturgicoDTO.ServicioLiturgicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLiturgicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioLiturgicoDTO servicioLiturgicoDTO)
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
                    cmd.Parameters["@Formato"].Value = "ServicioLiturgico";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioLiturgicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLiturgicoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioLiturgicoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLiturgico", SqlDbType.Structured);
                    cmd.Parameters["@ServicioLiturgico"].TypeName = "Formato.ServicioLiturgico";
                    cmd.Parameters["@ServicioLiturgico"].Value = datos;

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
