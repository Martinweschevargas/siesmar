using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirciten
{
    public class EgresoPromocionesDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EgresoPromocionesDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EgresoPromocionesDTO> lista = new List<EgresoPromocionesDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EgresoPromocionDircitenListar", conexion);
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
                        lista.Add(new EgresoPromocionesDTO()
                        {
                            EgresoPromocionId = Convert.ToInt32(dr["EgresoPromocionDircitenId"]),
                            DNIEgresoPromocion = dr["DNIEgresoPromocion"].ToString(),
                            GeneroEgresoPromocion = dr["GeneroEgresoPromocion"].ToString(),
                            FechaResolIngreso = (dr["FechaResolIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaResolEgreso = (dr["FechaResolEgreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EgresoPromocionesDTO egresoPromocionesDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDircitenRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIEgresoPromocion", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIEgresoPromocion"].Value = egresoPromocionesDTO.DNIEgresoPromocion;

                    cmd.Parameters.Add("@GeneroEgresoPromocion", SqlDbType.VarChar,10);
                    cmd.Parameters["@GeneroEgresoPromocion"].Value = egresoPromocionesDTO.GeneroEgresoPromocion;

                    cmd.Parameters.Add("@FechaResolIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolIngreso"].Value = egresoPromocionesDTO.FechaResolIngreso;

                    cmd.Parameters.Add("@FechaResolEgreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolEgreso"].Value = egresoPromocionesDTO.FechaResolEgreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = egresoPromocionesDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDTO.UsuarioIngresoRegistro;

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

        public EgresoPromocionesDTO BuscarFormato(int Codigo)
        {
            EgresoPromocionesDTO egresoPromocionesDTO = new EgresoPromocionesDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDircitenEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionDircitenId", SqlDbType.Int);
                    cmd.Parameters["@EgresoPromocionDircitenId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        egresoPromocionesDTO.EgresoPromocionId = Convert.ToInt32(dr["EgresoPromocionDircitenId"]);
                        egresoPromocionesDTO.DNIEgresoPromocion = dr["DNIEgresoPromocion"].ToString();
                        egresoPromocionesDTO.GeneroEgresoPromocion = Regex.Replace(dr["GeneroEgresoPromocion"].ToString(), @"\s", "");
                        egresoPromocionesDTO.FechaResolIngreso = Convert.ToDateTime(dr["FechaResolIngreso"]).ToString("yyy-MM-dd");
                        egresoPromocionesDTO.FechaResolEgreso = Convert.ToDateTime(dr["FechaResolEgreso"]).ToString("yyy-MM-dd");
                    }
                    

                }
            }
            catch (Exception)
            {
                throw;
            }
            return egresoPromocionesDTO;
        }

        public string ActualizaFormato(EgresoPromocionesDTO egresoPromocionesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDircitenActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionDircitenId", SqlDbType.Int);
                    cmd.Parameters["@EgresoPromocionDircitenId"].Value = egresoPromocionesDTO.EgresoPromocionId;

                    cmd.Parameters.Add("@DNIEgresoPromocion", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIEgresoPromocion"].Value = egresoPromocionesDTO.DNIEgresoPromocion;

                    cmd.Parameters.Add("@GeneroEgresoPromocion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GeneroEgresoPromocion"].Value = egresoPromocionesDTO.GeneroEgresoPromocion;

                    cmd.Parameters.Add("@FechaResolIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolIngreso"].Value = egresoPromocionesDTO.FechaResolIngreso;

                    cmd.Parameters.Add("@FechaResolEgreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolEgreso"].Value = egresoPromocionesDTO.FechaResolEgreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EgresoPromocionesDTO egresoPromocionesDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDircitenEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionId", SqlDbType.Int);
                    cmd.Parameters["@EgresoPromocionId"].Value = egresoPromocionesDTO.EgresoPromocionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EgresoPromocionesDTO egresoPromocionesDTO)
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
                    cmd.Parameters["@Formato"].Value = "EgresoPromocionDirciten";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = egresoPromocionesDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EgresoPromocionDircitenRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionDirciten", SqlDbType.Structured);
                    cmd.Parameters["@EgresoPromocionDirciten"].TypeName = "Formato.EgresoPromocionDirciten";
                    cmd.Parameters["@EgresoPromocionDirciten"].Value = datos;

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

