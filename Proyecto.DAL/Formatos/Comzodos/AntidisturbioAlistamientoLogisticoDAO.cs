
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzodos
{
    public class AntidisturbioAlistamientoLogisticoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AntidisturbioAlistamientoLogisticoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AntidisturbioAlistamientoLogisticoDTO> lista = new List<AntidisturbioAlistamientoLogisticoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AntidisturbioAlistamientoLogisticoListar", conexion);
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
                        lista.Add(new AntidisturbioAlistamientoLogisticoDTO()
                        {
                            AntidisturbioAlistamientoLogisticoId = Convert.ToInt32(dr["AntidisturbioAlistamientoLogisticoId"]),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            MaterialRequerido = Convert.ToInt32(dr["MaterialRequerido"]),
                            MaterialAsignado = Convert.ToInt32(dr["MaterialAsignado"]),
                            DescCondicionAlistamientoLogistico = dr["DescCondicionAlistamientoLogistico"].ToString(),
                            ObservacionAlistamientoLogistico = dr["ObservacionAlistamientoLogistico"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AntidisturbioAlistamientoLogisticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDescripcionMaterial", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDescripcionMaterial"].Value = antidisturbioAlistamientoLogisticoDTO.CodigoDescripcionMaterial;

                    cmd.Parameters.Add("@MaterialRequerido", SqlDbType.Int);
                    cmd.Parameters["@MaterialRequerido"].Value = antidisturbioAlistamientoLogisticoDTO.MaterialRequerido;

                    cmd.Parameters.Add("@MaterialAsignado", SqlDbType.Int);
                    cmd.Parameters["@MaterialAsignado"].Value = antidisturbioAlistamientoLogisticoDTO.MaterialAsignado;

                    cmd.Parameters.Add("@CodigoCondicionAlistamientoLogistico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCondicionAlistamientoLogistico"].Value = antidisturbioAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico;

                    cmd.Parameters.Add("@ObservacionAlistamientoLogistico", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionAlistamientoLogistico"].Value = antidisturbioAlistamientoLogisticoDTO.ObservacionAlistamientoLogistico;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = antidisturbioAlistamientoLogisticoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar,100);
                    cmd.Parameters["@Usuario"].Value = antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar,50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar,50);
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

        public AntidisturbioAlistamientoLogisticoDTO BuscarFormato(int Codigo)
        {
            AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO = new AntidisturbioAlistamientoLogisticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AntidisturbioAlistamientoLogisticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AntidisturbioAlistamientoLogisticoId", SqlDbType.Int);
                    cmd.Parameters["@AntidisturbioAlistamientoLogisticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        antidisturbioAlistamientoLogisticoDTO.AntidisturbioAlistamientoLogisticoId = Convert.ToInt32(dr["AntidisturbioAlistamientoLogisticoId"]);
                        antidisturbioAlistamientoLogisticoDTO.CodigoDescripcionMaterial = dr["CodigoDescripcionMaterial"].ToString();
                        antidisturbioAlistamientoLogisticoDTO.MaterialRequerido = Convert.ToInt32(dr["MaterialRequerido"]);
                        antidisturbioAlistamientoLogisticoDTO.MaterialAsignado = Convert.ToInt32(dr["MaterialAsignado"]);
                        antidisturbioAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico = dr["CodigoCondicionAlistamientoLogistico"].ToString();
                        antidisturbioAlistamientoLogisticoDTO.ObservacionAlistamientoLogistico = dr["ObservacionAlistamientoLogistico"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return antidisturbioAlistamientoLogisticoDTO;
        }

        public string ActualizaFormato(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AntidisturbioAlistamientoLogisticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AntidisturbioAlistamientoLogisticoId", SqlDbType.Int);
                    cmd.Parameters["@AntidisturbioAlistamientoLogisticoId"].Value = antidisturbioAlistamientoLogisticoDTO.AntidisturbioAlistamientoLogisticoId;

                    cmd.Parameters.Add("@CodigoDescripcionMaterial", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDescripcionMaterial"].Value = antidisturbioAlistamientoLogisticoDTO.CodigoDescripcionMaterial;

                    cmd.Parameters.Add("@MaterialRequerido", SqlDbType.Int);
                    cmd.Parameters["@MaterialRequerido"].Value = antidisturbioAlistamientoLogisticoDTO.MaterialRequerido;

                    cmd.Parameters.Add("@MaterialAsignado", SqlDbType.Int);
                    cmd.Parameters["@MaterialAsignado"].Value = antidisturbioAlistamientoLogisticoDTO.MaterialAsignado;

                    cmd.Parameters.Add("@CodigoCondicionAlistamientoLogistico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCondicionAlistamientoLogistico"].Value = antidisturbioAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico;

                    cmd.Parameters.Add("@ObservacionAlistamientoLogistico", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionAlistamientoLogistico"].Value = antidisturbioAlistamientoLogisticoDTO.ObservacionAlistamientoLogistico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AntidisturbioAlistamientoLogisticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AntidisturbioAlistamientoLogisticoId", SqlDbType.Int);
                    cmd.Parameters["@AntidisturbioAlistamientoLogisticoId"].Value = antidisturbioAlistamientoLogisticoDTO.AntidisturbioAlistamientoLogisticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO)
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
                    cmd.Parameters["@Formato"].Value = "AntidisturbioAlistamientoLogistico";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = antidisturbioAlistamientoLogisticoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AntidisturbioAlistamientoLogisticoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AntidisturbioAlistamientoLogistico", SqlDbType.Structured);
                    cmd.Parameters["@AntidisturbioAlistamientoLogistico"].TypeName = "Formato.AntidisturbioAlistamientoLogistico";
                    cmd.Parameters["@AntidisturbioAlistamientoLogistico"].Value = datos;

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
