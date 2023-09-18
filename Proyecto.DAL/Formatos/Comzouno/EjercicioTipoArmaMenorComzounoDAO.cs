using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzouno
{
    public class EjercicioTipoArmaMenorComzounoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTipoArmaMenorComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EjercicioTipoArmaMenorComzounoDTO> lista = new List<EjercicioTipoArmaMenorComzounoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComzounoListar", conexion);
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
                        lista.Add(new EjercicioTipoArmaMenorComzounoDTO()
                        {
                            EjercicioTipoArmaMenorComzounoId = Convert.ToInt32(dr["EjercicioTipoArmaMenorComzounoId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            FechaEjercicioTipo = (dr["FechaEjercicioTipo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoArmamento = dr["DescTipoArmamento"].ToString(),
                            DescPosicionTipoArma = dr["DescPosicionTipoArma"].ToString(),
                            DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]),
                            CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComzounoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@FechaEjercicioTipo", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicioTipo"].Value = ejercicioTipoArmaMenorComzounoDTO.FechaEjercicioTipo;

                    cmd.Parameters.Add("@CodigoTipoArmamento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoArmamento"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoTipoArmamento;

                    cmd.Parameters.Add("@CodigoPosicionTipoArma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPosicionTipoArma"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoPosicionTipoArma;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTipoArmaMenorComzounoDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTipoArmaMenorComzounoDTO.CantidadTiro;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ejercicioTipoArmaMenorComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro;

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

        public EjercicioTipoArmaMenorComzounoDTO BuscarFormato(int Codigo)
        {
            EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO = new EjercicioTipoArmaMenorComzounoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComzounoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComzounoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorComzounoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTipoArmaMenorComzounoDTO.EjercicioTipoArmaMenorComzounoId = Convert.ToInt32(dr["EjercicioTipoArmaMenorComzounoId"]);
                        ejercicioTipoArmaMenorComzounoDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        ejercicioTipoArmaMenorComzounoDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        ejercicioTipoArmaMenorComzounoDTO.FechaEjercicioTipo = Convert.ToDateTime(dr["FechaEjercicioTipo"]).ToString("yyy-MM-dd");
                        ejercicioTipoArmaMenorComzounoDTO.CodigoTipoArmamento = dr["CodigoTipoArmamento"].ToString();
                        ejercicioTipoArmaMenorComzounoDTO.CodigoPosicionTipoArma = dr["CodigoPosicionTipoArma"].ToString();
                        ejercicioTipoArmaMenorComzounoDTO.DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]);
                        ejercicioTipoArmaMenorComzounoDTO.CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTipoArmaMenorComzounoDTO;
        }

        public string ActualizaFormato(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComzounoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComzounoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorComzounoId"].Value = ejercicioTipoArmaMenorComzounoDTO.EjercicioTipoArmaMenorComzounoId;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@FechaEjercicioTipo", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicioTipo"].Value = ejercicioTipoArmaMenorComzounoDTO.FechaEjercicioTipo;

                    cmd.Parameters.Add("@CodigoTipoArmamento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoArmamento"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoTipoArmamento;

                    cmd.Parameters.Add("@CodigoPosicionTipoArma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPosicionTipoArma"].Value = ejercicioTipoArmaMenorComzounoDTO.CodigoPosicionTipoArma;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTipoArmaMenorComzounoDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTipoArmaMenorComzounoDTO.CantidadTiro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComzounoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComzounoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorComzounoId"].Value = ejercicioTipoArmaMenorComzounoDTO.EjercicioTipoArmaMenorComzounoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO)
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
                    cmd.Parameters["@Formato"].Value = "EjercicioTipoArmaMenorComzouno";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ejercicioTipoArmaMenorComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComzounoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorComzouno", SqlDbType.Structured);
                    cmd.Parameters["@EjercicioTipoArmaMenorComzouno"].TypeName = "Formato.EjercicioTipoArmaMenorComzouno";
                    cmd.Parameters["@EjercicioTipoArmaMenorComzouno"].Value = datos;

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
