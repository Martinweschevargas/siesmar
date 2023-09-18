using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzotres
{
    public class BandaMusicoComzotresDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<BandaMusicoComzotresDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<BandaMusicoComzotresDTO> lista = new List<BandaMusicoComzotresDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_BandaMusicoComzotresListar", conexion);
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
                        lista.Add(new BandaMusicoComzotresDTO()
                        {
                            BandaMusicoComzotresId = Convert.ToInt32(dr["BandaMusicoComzotresId"]),
                            DescTipoComision = dr["DescTipoComision"].ToString(),
                            DescEvento = dr["DescEvento"].ToString(),
                            DescGrupoComisionado = dr["DescGrupoComisionado"].ToString(),
                            DescVestimentaUniforme = dr["DescVestimentaUniforme"].ToString(),
                            NombreEvento = dr["NombreEvento"].ToString(),
                            Lugar = dr["Lugar"].ToString(),
                            FechaHoraSalida = Convert.ToDateTime(dr["FechaHoraSalida"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            RequerimientoMovilidad = dr["RequerimientoMovilidad"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(BandaMusicoComzotresDTO bandaMusicoComzotresDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzotresRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoComision", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoComision"].Value = bandaMusicoComzotresDTO.CodigoTipoComision;

                    cmd.Parameters.Add("@CodigoEvento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEvento"].Value = bandaMusicoComzotresDTO.CodigoEvento;

                    cmd.Parameters.Add("@CodigoGrupoComisionado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoComisionado"].Value = bandaMusicoComzotresDTO.CodigoGrupoComisionado;

                    cmd.Parameters.Add("@CodigoVestimentaUniforme", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVestimentaUniforme"].Value = bandaMusicoComzotresDTO.CodigoVestimentaUniforme;

                    cmd.Parameters.Add("@NombreEvento", SqlDbType.VarChar,200);
                    cmd.Parameters["@NombreEvento"].Value = bandaMusicoComzotresDTO.NombreEvento;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,200);
                    cmd.Parameters["@Lugar"].Value = bandaMusicoComzotresDTO.Lugar;

                    cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraSalida"].Value = bandaMusicoComzotresDTO.FechaHoraSalida;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = bandaMusicoComzotresDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = bandaMusicoComzotresDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@RequerimientoMovilidad", SqlDbType.NChar,1);
                    cmd.Parameters["@RequerimientoMovilidad"].Value = bandaMusicoComzotresDTO.RequerimientoMovilidad;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = bandaMusicoComzotresDTO.Observacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = bandaMusicoComzotresDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzotresDTO.UsuarioIngresoRegistro;

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

        public BandaMusicoComzotresDTO BuscarFormato(int Codigo)
        {
            BandaMusicoComzotresDTO bandaMusicoComzotresDTO = new BandaMusicoComzotresDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzotresEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzotresId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoComzotresId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        bandaMusicoComzotresDTO.BandaMusicoComzotresId = Convert.ToInt32(dr["BandaMusicoComzotresId"]);
                        bandaMusicoComzotresDTO.CodigoTipoComision = dr["CodigoTipoComision"].ToString();
                        bandaMusicoComzotresDTO.CodigoEvento = dr["CodigoEvento"].ToString();
                        bandaMusicoComzotresDTO.CodigoGrupoComisionado = dr["CodigoGrupoComisionado"].ToString();
                        bandaMusicoComzotresDTO.CodigoVestimentaUniforme = dr["CodigoVestimentaUniforme"].ToString();
                        bandaMusicoComzotresDTO.NombreEvento = dr["NombreEvento"].ToString();
                        bandaMusicoComzotresDTO.Lugar = dr["Lugar"].ToString();
                        bandaMusicoComzotresDTO.FechaHoraSalida = Convert.ToDateTime(dr["FechaHoraSalida"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bandaMusicoComzotresDTO.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bandaMusicoComzotresDTO.FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bandaMusicoComzotresDTO.RequerimientoMovilidad = dr["RequerimientoMovilidad"].ToString();
                        bandaMusicoComzotresDTO.Observacion = dr["Observacion"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return bandaMusicoComzotresDTO;
        }

        public string ActualizaFormato(BandaMusicoComzotresDTO bandaMusicoComzotresDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzotresActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzotresId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoComzotresId"].Value = bandaMusicoComzotresDTO.BandaMusicoComzotresId;

                    cmd.Parameters.Add("@CodigoTipoComision", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoComision"].Value = bandaMusicoComzotresDTO.CodigoTipoComision;

                    cmd.Parameters.Add("@CodigoEvento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEvento"].Value = bandaMusicoComzotresDTO.CodigoEvento;

                    cmd.Parameters.Add("@CodigoGrupoComisionado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoComisionado"].Value = bandaMusicoComzotresDTO.CodigoGrupoComisionado;

                    cmd.Parameters.Add("@CodigoVestimentaUniforme", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVestimentaUniforme"].Value = bandaMusicoComzotresDTO.CodigoVestimentaUniforme;

                    cmd.Parameters.Add("@NombreEvento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreEvento"].Value = bandaMusicoComzotresDTO.NombreEvento;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Lugar"].Value = bandaMusicoComzotresDTO.Lugar;

                    cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraSalida"].Value = bandaMusicoComzotresDTO.FechaHoraSalida;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = bandaMusicoComzotresDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = bandaMusicoComzotresDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@RequerimientoMovilidad", SqlDbType.NChar, 1);
                    cmd.Parameters["@RequerimientoMovilidad"].Value = bandaMusicoComzotresDTO.RequerimientoMovilidad;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = bandaMusicoComzotresDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzotresDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(BandaMusicoComzotresDTO bandaMusicoComzotresDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzotresEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzotresId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoComzotresId"].Value = bandaMusicoComzotresDTO.BandaMusicoComzotresId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzotresDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(BandaMusicoComzotresDTO bandaMusicoComzotresDTO)
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
                    cmd.Parameters["@Formato"].Value = "BandaMusicoComzotres";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = bandaMusicoComzotresDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzotresDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_BandaMusicoComzotresRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzotres", SqlDbType.Structured);
                    cmd.Parameters["@BandaMusicoComzotres"].TypeName = "Formato.BandaMusicoComzotres";
                    cmd.Parameters["@BandaMusicoComzotres"].Value = datos;

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
