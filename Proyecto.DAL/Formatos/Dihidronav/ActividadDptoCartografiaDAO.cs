using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class ActividadDptoCartografiaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActividadDptoCartografiaDTO> ObtenerLista(int? CargaId=null)
        {
            List<ActividadDptoCartografiaDTO> lista = new List<ActividadDptoCartografiaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActividadDptoCartografiaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadDptoCartografiaDTO()
                        {
                            ActividadDptoCartografiaId = Convert.ToInt32(dr["ActividadDptoCartografiaId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            Requerimiento = dr["Requerimiento"].ToString(),
                            DescTipoCarta = dr["DescTipoCarta"].ToString(),
                            Proceso = dr["Proceso"].ToString(),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            CodigoNombre = dr["CodigoNombre"].ToString(),
                            Edicion = dr["Edicion"].ToString(),
                            Escala = Convert.ToInt32(dr["Escala"]),
                            SituacionPorcentaje = Convert.ToInt32(dr["SituacionPorcentaje"]),
                            FechaAutorizacionProduccion = (dr["FechaAutorizacionProduccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoCarta = (dr["FechaTerminoCarta"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ActividadDptoCartografiaDTO actividadDptoCartografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDptoCartografiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = actividadDptoCartografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@Requerimiento", SqlDbType.VarChar,50);
                    cmd.Parameters["@Requerimiento"].Value = actividadDptoCartografiaDTO.Requerimiento;

                    cmd.Parameters.Add("@CodigoTipoCarta", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoCarta"].Value = actividadDptoCartografiaDTO.CodigoTipoCarta;

                    cmd.Parameters.Add("@Proceso", SqlDbType.VarChar,20);
                    cmd.Parameters["@Proceso"].Value = actividadDptoCartografiaDTO.Proceso;

                    cmd.Parameters.Add("@Clasificacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@Clasificacion"].Value = actividadDptoCartografiaDTO.Clasificacion;

                    cmd.Parameters.Add("@CodigoNombre", SqlDbType.VarChar,40);
                    cmd.Parameters["@CodigoNombre"].Value = actividadDptoCartografiaDTO.CodigoNombre;

                    cmd.Parameters.Add("@Edicion", SqlDbType.VarChar,40);
                    cmd.Parameters["@Edicion"].Value = actividadDptoCartografiaDTO.Edicion;

                    cmd.Parameters.Add("@Escala", SqlDbType.Int);
                    cmd.Parameters["@Escala"].Value = actividadDptoCartografiaDTO.Escala;

                    cmd.Parameters.Add("@SituacionPorcentaje", SqlDbType.Int);
                    cmd.Parameters["@SituacionPorcentaje"].Value = actividadDptoCartografiaDTO.SituacionPorcentaje;

                    cmd.Parameters.Add("@FechaAutorizacionProduccion", SqlDbType.Date);
                    cmd.Parameters["@FechaAutorizacionProduccion"].Value = actividadDptoCartografiaDTO.FechaAutorizacionProduccion;

                    cmd.Parameters.Add("@FechaTerminoCarta", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoCarta"].Value = actividadDptoCartografiaDTO.FechaTerminoCarta;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = actividadDptoCartografiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDptoCartografiaDTO.UsuarioIngresoRegistro;

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

        public ActividadDptoCartografiaDTO BuscarFormato(int Codigo)
        {
            ActividadDptoCartografiaDTO actividadDptoCartografiaDTO = new ActividadDptoCartografiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDptoCartografiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDptoCartografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDptoCartografiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        actividadDptoCartografiaDTO.ActividadDptoCartografiaId = Convert.ToInt32(dr["ActividadDptoCartografiaId"]);
                        actividadDptoCartografiaDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        actividadDptoCartografiaDTO.Requerimiento = dr["Requerimiento"].ToString();
                        actividadDptoCartografiaDTO.CodigoTipoCarta = dr["CodigoTipoCarta"].ToString();
                        actividadDptoCartografiaDTO.Proceso = dr["Proceso"].ToString();
                        actividadDptoCartografiaDTO.Clasificacion = dr["Clasificacion"].ToString();
                        actividadDptoCartografiaDTO.CodigoNombre = dr["CodigoNombre"].ToString();
                        actividadDptoCartografiaDTO.Edicion = dr["Edicion"].ToString();
                        actividadDptoCartografiaDTO.Escala = Convert.ToInt32(dr["Escala"]);
                        actividadDptoCartografiaDTO.SituacionPorcentaje = Convert.ToInt32(dr["SituacionPorcentaje"]);
                        actividadDptoCartografiaDTO.FechaAutorizacionProduccion = Convert.ToDateTime(dr["FechaAutorizacionProduccion"]).ToString("yyy-MM-dd");
                        actividadDptoCartografiaDTO.FechaTerminoCarta = Convert.ToDateTime(dr["FechaTerminoCarta"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadDptoCartografiaDTO;
        }

        public string ActualizaFormato(ActividadDptoCartografiaDTO actividadDptoCartografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadDptoCartografiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ActividadDptoCartografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDptoCartografiaId"].Value = actividadDptoCartografiaDTO.ActividadDptoCartografiaId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = actividadDptoCartografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@Requerimiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Requerimiento"].Value = actividadDptoCartografiaDTO.Requerimiento;

                    cmd.Parameters.Add("@CodigoTipoCarta", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoCarta"].Value = actividadDptoCartografiaDTO.CodigoTipoCarta;

                    cmd.Parameters.Add("@Proceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Proceso"].Value = actividadDptoCartografiaDTO.Proceso;

                    cmd.Parameters.Add("@Clasificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Clasificacion"].Value = actividadDptoCartografiaDTO.Clasificacion;

                    cmd.Parameters.Add("@CodigoNombre", SqlDbType.VarChar, 40);
                    cmd.Parameters["@CodigoNombre"].Value = actividadDptoCartografiaDTO.CodigoNombre;

                    cmd.Parameters.Add("@Edicion", SqlDbType.VarChar, 40);
                    cmd.Parameters["@Edicion"].Value = actividadDptoCartografiaDTO.Edicion;

                    cmd.Parameters.Add("@Escala", SqlDbType.Int);
                    cmd.Parameters["@Escala"].Value = actividadDptoCartografiaDTO.Escala;

                    cmd.Parameters.Add("@SituacionPorcentaje", SqlDbType.Int);
                    cmd.Parameters["@SituacionPorcentaje"].Value = actividadDptoCartografiaDTO.SituacionPorcentaje;

                    cmd.Parameters.Add("@FechaAutorizacionProduccion", SqlDbType.Date);
                    cmd.Parameters["@FechaAutorizacionProduccion"].Value = actividadDptoCartografiaDTO.FechaAutorizacionProduccion;

                    cmd.Parameters.Add("@FechaTerminoCarta", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoCarta"].Value = actividadDptoCartografiaDTO.FechaTerminoCarta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDptoCartografiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActividadDptoCartografiaDTO actividadDptoCartografiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDptoCartografiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDptoCartografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDptoCartografiaId"].Value = actividadDptoCartografiaDTO.ActividadDptoCartografiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDptoCartografiaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ActividadDptoCartografiaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDptoCartografia", SqlDbType.Structured);
                    cmd.Parameters["@ActividadDptoCartografia"].TypeName = "Formato.ActividadDptoCartografia";
                    cmd.Parameters["@ActividadDptoCartografia"].Value = datos;

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
