using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class EjercicioTiroArmaMenorComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTiroArmaMenorComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<EjercicioTiroArmaMenorComzocuatroDTO> lista = new List<EjercicioTiroArmaMenorComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioTiroArmaMenorComzocuatroDTO()
                        {
                            EjercicioTiroArmaMenorId = Convert.ToInt32(dr["EjercicioTiroArmaMenorId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            FechaEjercicio = (dr["FechaEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
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

        public string AgregarRegistro(EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTiroArmaMenorComzocuatroDTO.FechaEjercicio;

                    cmd.Parameters.Add("@CodigoTipoArmamento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoArmamento"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoTipoArmamento;

                    cmd.Parameters.Add("@CodigoPosicionTipoArma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPosicionTipoArma"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoPosicionTipoArma;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTiroArmaMenorComzocuatroDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CantidadTiro;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorComzocuatroDTO.UsuarioIngresoRegistro;

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

        public EjercicioTiroArmaMenorComzocuatroDTO BuscarFormato(int Codigo)
        {
            EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO = new EjercicioTiroArmaMenorComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTiroArmaMenorComzocuatroDTO.EjercicioTiroArmaMenorId = Convert.ToInt32(dr["EjercicioTipoArmaMenorId"]);
                        ejercicioTiroArmaMenorComzocuatroDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        ejercicioTiroArmaMenorComzocuatroDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        ejercicioTiroArmaMenorComzocuatroDTO.FechaEjercicio = Convert.ToDateTime(dr["FechaEjercicio"]).ToString("yyy-MM-dd");
                        ejercicioTiroArmaMenorComzocuatroDTO.CodigoTipoArmamento = dr["CodigoTipoArmamento"].ToString();
                        ejercicioTiroArmaMenorComzocuatroDTO.CodigoPosicionTipoArma = dr["CodigoPosicionTipoArma"].ToString();
                        ejercicioTiroArmaMenorComzocuatroDTO.DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]);
                        ejercicioTiroArmaMenorComzocuatroDTO.CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTiroArmaMenorComzocuatroDTO;
        }

        public string ActualizaFormato(EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EjercicioTiroArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTiroArmaMenorId"].Value = ejercicioTiroArmaMenorComzocuatroDTO.EjercicioTiroArmaMenorId;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTiroArmaMenorComzocuatroDTO.FechaEjercicio;

                    cmd.Parameters.Add("@CodigoTipoArmamento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoArmamento"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoTipoArmamento;

                    cmd.Parameters.Add("@CodigoPosicionTipoArma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPosicionTipoArma"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CodigoPosicionTipoArma;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTiroArmaMenorComzocuatroDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTiroArmaMenorComzocuatroDTO.CantidadTiro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTiroArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArEjercicioTiroArmaMenorIdmaMenorId"].Value = ejercicioTiroArmaMenorComzocuatroDTO.EjercicioTiroArmaMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorComzocuatroDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTiroArmaMenorComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@EjercicioTiroArmaMenorComzocuatro"].TypeName = "Formato.EjercicioTiroArmaMenorComzocuatro";
                    cmd.Parameters["@EjercicioTiroArmaMenorComzocuatro"].Value = datos;

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
