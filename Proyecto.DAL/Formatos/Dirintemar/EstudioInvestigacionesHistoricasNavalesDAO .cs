using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class EstudioInvestigacionesHistoricasNavalesDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EstudioInvestigacionesHistoricasNavalesDTO> ObtenerLista()
        {
            List<EstudioInvestigacionesHistoricasNavalesDTO> lista = new List<EstudioInvestigacionesHistoricasNavalesDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstudioInvestigacionesHistoricasNavalesDTO()
                        {
                            EstudioInvestigacionHistNavalId = Convert.ToInt32(dr["EstudioInvestigacionHistNavalId"]),
                            NombreTemaEstudioInvestigacion = dr["NombreInvestigacion"].ToString(),
                            TipoEstudioInvestigacionId = Convert.ToInt32(dr["TipoEstudioInvestigacionId"]),
                            DescTipoEstudioInvestigacion = dr["DescTipoEstudioInvestigacion"].ToString(),
                            FechaInicio = (dr["FechaInicioInvestigacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTerminoInvestigacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Responsable = dr["ResponsableInvestigacion"].ToString(),
                            Solicitante = dr["SolicitanteInvestigacion"].ToString(),
                            CodigoCargo = Convert.ToInt32(dr["CodigoCargo"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EstudioInvestigacionesHistoricasNavalesDTO estudioInvestigacionesHistoricasNavalesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@NombreInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.NombreTemaEstudioInvestigacion;

                    cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioInvestigacionId"].Value = estudioInvestigacionesHistoricasNavalesDTO.TipoEstudioInvestigacionId;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaTerminoInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.FechaTermino;

                    cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@ResponsableInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.Responsable;

                    cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@SolicitanteInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.Solicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioInvestigacionesHistoricasNavalesDTO.UsuarioIngresoRegistro;

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

        public EstudioInvestigacionesHistoricasNavalesDTO BuscarFormato(int Codigo)
        {
            EstudioInvestigacionesHistoricasNavalesDTO estudioInvestigacionesHistoricasNavalesDTO = new EstudioInvestigacionesHistoricasNavalesDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioInvestigacionHistNavalId", SqlDbType.Int);
                    cmd.Parameters["@EstudioInvestigacionHistNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        estudioInvestigacionesHistoricasNavalesDTO.EstudioInvestigacionHistNavalId = Convert.ToInt32(dr["EstudioInvestigacionHistNavalId"]);
                        estudioInvestigacionesHistoricasNavalesDTO.NombreTemaEstudioInvestigacion = dr["NombreInvestigacion"].ToString();
                        estudioInvestigacionesHistoricasNavalesDTO.TipoEstudioInvestigacionId = Convert.ToInt32(dr["TipoEstudioInvestigacionId"]);
                        estudioInvestigacionesHistoricasNavalesDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        estudioInvestigacionesHistoricasNavalesDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        estudioInvestigacionesHistoricasNavalesDTO.Responsable = dr["ResponsableInvestigacion"].ToString();
                        estudioInvestigacionesHistoricasNavalesDTO.Solicitante = dr["SolicitanteInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estudioInvestigacionesHistoricasNavalesDTO;
        }

        public string ActualizaFormato(EstudioInvestigacionesHistoricasNavalesDTO estudioInvestigacionesHistoricasNavalesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioInvestigacionHistNavalId", SqlDbType.Int);
                    cmd.Parameters["@EstudioInvestigacionHistNavalId"].Value = estudioInvestigacionesHistoricasNavalesDTO.EstudioInvestigacionHistNavalId;

                    cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@NombreInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.NombreTemaEstudioInvestigacion;

                    cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioInvestigacionId"].Value = estudioInvestigacionesHistoricasNavalesDTO.TipoEstudioInvestigacionId;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.FechaTermino;

                    cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@ResponsableInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.Responsable;

                    cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@SolicitanteInvestigacion"].Value = estudioInvestigacionesHistoricasNavalesDTO.Solicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioInvestigacionesHistoricasNavalesDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EstudioInvestigacionesHistoricasNavalesDTO estudioInvestigacionesHistoricasNavalesDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioInvestigacionHistNavalId", SqlDbType.Int);
                    cmd.Parameters["@EstudioInvestigacionHistNavalId"].Value = estudioInvestigacionesHistoricasNavalesDTO.EstudioInvestigacionHistNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioInvestigacionesHistoricasNavalesDTO.UsuarioIngresoRegistro;

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

                    cmd.Parameters.Add("@EstudiosInvestigacionHistoricaNaval", SqlDbType.Structured);
                    cmd.Parameters["@EstudiosInvestigacionHistoricaNaval"].TypeName = "Formato.EstudiosInvestigacionHistoricaNaval";
                    cmd.Parameters["@EstudiosInvestigacionHistoricaNaval"].Value = datos;

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