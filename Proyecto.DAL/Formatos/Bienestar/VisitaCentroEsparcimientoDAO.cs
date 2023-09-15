using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class VisitaCentroEsparcimientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<VisitaCentroEsparcimientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<VisitaCentroEsparcimientoDTO> lista = new List<VisitaCentroEsparcimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_VisitaCentroEsparcimientoListar", conexion);
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
                        lista.Add(new VisitaCentroEsparcimientoDTO()
                        {
                            VisitaCentroEsparcimientoId = Convert.ToInt32(dr["VisitaCentroEsparcimientoId"]),
                            FechaVisitaCentro = (dr["FechaVisitaCentro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIUsuario = dr["DNIUsuario"].ToString(),
                            DescUsuarioCentroEsparcimiento = dr["DescUsuarioCentroEsparcimiento"].ToString(),
                            DescClubEsparcimiento = dr["DescClubEsparcimiento"].ToString(),
                            NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]),
                            NumeroInvitados = Convert.ToInt32(dr["NumeroInvitados"]),
                            MontoFacturado = Convert.ToDecimal(dr["MontoFacturado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<VisitaCentroEsparcimientoDTO> BienestarVisualizacionVisitaCentroEsparcimiento(int CargaId)
        {
            List<VisitaCentroEsparcimientoDTO> lista = new List<VisitaCentroEsparcimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionVisitaCentroEsparcimiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VisitaCentroEsparcimientoDTO()
                        {
                            FechaVisitaCentro = dr["FechaVisitaCentro"].ToString(),
                            DNIUsuario = dr["DNIUsuario"].ToString(),
                            DescUsuarioCentroEsparcimiento = dr["DescUsuarioCentroEsparcimiento"].ToString(),
                            DescClubEsparcimiento = dr["DescClubEsparcimiento"].ToString(),
                            NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]),
                            NumeroInvitados = Convert.ToInt32(dr["NumeroInvitados"]),
                            MontoFacturado = Convert.ToDecimal(dr["MontoFacturado"]),

                        });
                    }
                }
            }
            return lista;
        }


        public List<VisitaCentroEsparcimientoDTO> TotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio(int para1, int para2)
        {
            List<VisitaCentroEsparcimientoDTO> lista = new List<VisitaCentroEsparcimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarTotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@usuario", SqlDbType.Int);
                cmd.Parameters["@usuario"].Value = para1;

                cmd.Parameters.Add("@anio", SqlDbType.Int);
                cmd.Parameters["@anio"].Value = para2;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VisitaCentroEsparcimientoDTO()
                        {
                            Mes = dr["Mes"].ToString(),
                            CentroEsparcimiento = dr["CentroEsparcimiento"].ToString(),
                            TipoUsuario = dr["TipoUsuario"].ToString(),
                            Visitas = dr["Visitas"].ToString(),
                           
                        });
                    }
                }
            }
            return lista;
        }


        public string AgregarRegistro(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaCentroEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaVisitaCentro", SqlDbType.Date);
                    cmd.Parameters["@FechaVisitaCentro"].Value = visitaCentroEsparcimientoDTO.FechaVisitaCentro;

                    cmd.Parameters.Add("@DNIUsuario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIUsuario"].Value = visitaCentroEsparcimientoDTO.DNIUsuario;

                    cmd.Parameters.Add("@CodigoUsuarioCentroEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUsuarioCentroEsparcimiento"].Value = visitaCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoClubEsparcimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoClubEsparcimiento"].Value = visitaCentroEsparcimientoDTO.CodigoClubEsparcimiento;

                    cmd.Parameters.Add("@NumeroHoras", SqlDbType.Int);
                    cmd.Parameters["@NumeroHoras"].Value = visitaCentroEsparcimientoDTO.NumeroHoras;

                    cmd.Parameters.Add("@NumeroInvitados", SqlDbType.Int);
                    cmd.Parameters["@NumeroInvitados"].Value = visitaCentroEsparcimientoDTO.NumeroInvitados;

                    cmd.Parameters.Add("@MontoFacturado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoFacturado"].Value = visitaCentroEsparcimientoDTO.MontoFacturado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = visitaCentroEsparcimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public VisitaCentroEsparcimientoDTO BuscarFormato(int Codigo)
        {
            VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO = new VisitaCentroEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaCentroEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@VisitaCentroEsparcimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        visitaCentroEsparcimientoDTO.VisitaCentroEsparcimientoId = Convert.ToInt32(dr["VisitaCentroEsparcimientoId"]);
                        visitaCentroEsparcimientoDTO.FechaVisitaCentro = Convert.ToDateTime(dr["FechaVisitaCentro"]).ToString("yyy-MM-dd");
                        visitaCentroEsparcimientoDTO.DNIUsuario = dr["DNIUsuario"].ToString();
                        visitaCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento = dr["CodigoUsuarioCentroEsparcimiento"].ToString();
                        visitaCentroEsparcimientoDTO.CodigoClubEsparcimiento = dr["CodigoClubEsparcimiento"].ToString();
                        visitaCentroEsparcimientoDTO.NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]);
                        visitaCentroEsparcimientoDTO.NumeroInvitados = Convert.ToInt32(dr["NumeroInvitados"]);
                        visitaCentroEsparcimientoDTO.MontoFacturado = Convert.ToDecimal(dr["MontoFacturado"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return visitaCentroEsparcimientoDTO;
        }

        public string ActualizaFormato(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VisitaCentroEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@VisitaCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@VisitaCentroEsparcimientoId"].Value = visitaCentroEsparcimientoDTO.VisitaCentroEsparcimientoId;

                    cmd.Parameters.Add("@FechaVisitaCentro", SqlDbType.Date);
                    cmd.Parameters["@FechaVisitaCentro"].Value = visitaCentroEsparcimientoDTO.FechaVisitaCentro;

                    cmd.Parameters.Add("@DNIUsuario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIUsuario"].Value = visitaCentroEsparcimientoDTO.DNIUsuario;


                    cmd.Parameters.Add("@CodigoUsuarioCentroEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUsuarioCentroEsparcimiento"].Value = visitaCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoClubEsparcimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoClubEsparcimiento"].Value = visitaCentroEsparcimientoDTO.CodigoClubEsparcimiento;

                    cmd.Parameters.Add("@NumeroHoras", SqlDbType.Int);
                    cmd.Parameters["@NumeroHoras"].Value = visitaCentroEsparcimientoDTO.NumeroHoras;

                    cmd.Parameters.Add("@NumeroInvitados", SqlDbType.Int);
                    cmd.Parameters["@NumeroInvitados"].Value = visitaCentroEsparcimientoDTO.NumeroInvitados;

                    cmd.Parameters.Add("@MontoFacturado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoFacturado"].Value = visitaCentroEsparcimientoDTO.MontoFacturado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaCentroEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@VisitaCentroEsparcimientoId"].Value = visitaCentroEsparcimientoDTO.VisitaCentroEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO)
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
                    cmd.Parameters["@Formato"].Value = "VisitaCentroEsparcimiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = visitaCentroEsparcimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_VisitaCentroEsparcimientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaCentroEsparcimiento", SqlDbType.Structured);
                    cmd.Parameters["@VisitaCentroEsparcimiento"].TypeName = "Formato.VisitaCentroEsparcimiento";
                    cmd.Parameters["@VisitaCentroEsparcimiento"].Value = datos;

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
