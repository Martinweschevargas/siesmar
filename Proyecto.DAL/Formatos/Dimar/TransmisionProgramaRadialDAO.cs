using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class TransmisionProgramaRadialDAO
    {

        SqlCommand cmd = new SqlCommand();


        public List<TransmisionProgramaRadialDTO> ObtenerLista(int? CargaId = null)
        {
            List<TransmisionProgramaRadialDTO> lista = new List<TransmisionProgramaRadialDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_TransmisionProgramaRadialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TransmisionProgramaRadialDTO()
                        {
                            TransmisionProgramaRadialId = Convert.ToInt32(dr["TransmisionProgramaRadialId"]),
                            FechaTransmision = (dr["FechaTransmision"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoInformacionEmitida = dr["TipoInformacionEmitidaId"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            Reproducciones = Convert.ToInt32(dr["Reproducciones"]),
                            Oyentes = Convert.ToInt32(dr["Oyentes"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(TransmisionProgramaRadialDTO transmisionProgramaRadialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TransmisionProgramaRadialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaTransmision", SqlDbType.Date);
                    cmd.Parameters["@FechaTransmision"].Value = transmisionProgramaRadialDTO.FechaTransmision;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = transmisionProgramaRadialDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = transmisionProgramaRadialDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Reproducciones", SqlDbType.Int);
                    cmd.Parameters["@Reproducciones"].Value = transmisionProgramaRadialDTO.Reproducciones;

                    cmd.Parameters.Add("@Oyentes", SqlDbType.Int);
                    cmd.Parameters["@Oyentes"].Value = transmisionProgramaRadialDTO.Oyentes;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = transmisionProgramaRadialDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = transmisionProgramaRadialDTO.UsuarioIngresoRegistro;

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

        public TransmisionProgramaRadialDTO BuscarFormato(int Codigo)
        {
            TransmisionProgramaRadialDTO transmisionProgramaRadialDTO = new TransmisionProgramaRadialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TransmisionProgramaRadialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransmisionProgramaRadialId", SqlDbType.Int);
                    cmd.Parameters["@TransmisionProgramaRadialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        transmisionProgramaRadialDTO.TransmisionProgramaRadialId = Convert.ToInt32(dr["TransmisionProgramaRadialId"]);
                        transmisionProgramaRadialDTO.FechaTransmision = Convert.ToDateTime(dr["FechaTransmision"]).ToString("yyy-MM-dd");
                        transmisionProgramaRadialDTO.CodigoTipoInformacionEmitida = dr["CodigoTipoInformacionEmitida"].ToString();
                        transmisionProgramaRadialDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                        transmisionProgramaRadialDTO.Reproducciones = Convert.ToInt32(dr["Reproducciones"]);
                        transmisionProgramaRadialDTO.Oyentes = Convert.ToInt32(dr["Oyentes"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return transmisionProgramaRadialDTO;
        }

        public string ActualizaFormato(TransmisionProgramaRadialDTO transmisionProgramaRadialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_TransmisionProgramaRadialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@TransmisionProgramaRadialId", SqlDbType.Int);
                    cmd.Parameters["@TransmisionProgramaRadialId"].Value = transmisionProgramaRadialDTO.TransmisionProgramaRadialId;

                    cmd.Parameters.Add("@FechaTransmision", SqlDbType.Date);
                    cmd.Parameters["@FechaTransmision"].Value = transmisionProgramaRadialDTO.FechaTransmision;

                    cmd.Parameters.Add("@CodigoTipoInformacionEmitida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacionEmitida "].Value = transmisionProgramaRadialDTO.CodigoTipoInformacionEmitida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = transmisionProgramaRadialDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Reproducciones", SqlDbType.Int);
                    cmd.Parameters["@Reproducciones"].Value = transmisionProgramaRadialDTO.Reproducciones;

                    cmd.Parameters.Add("@Oyentes", SqlDbType.Int);
                    cmd.Parameters["@Oyentes"].Value = transmisionProgramaRadialDTO.Oyentes;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = transmisionProgramaRadialDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(TransmisionProgramaRadialDTO transmisionProgramaRadialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TransmisionProgramaRadialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransmisionProgramaRadialId", SqlDbType.Int);
                    cmd.Parameters["@TransmisionProgramaRadialId"].Value = transmisionProgramaRadialDTO.TransmisionProgramaRadialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = transmisionProgramaRadialDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_TransmisionProgramaRadialRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransmisionProgramaRadial", SqlDbType.Structured);
                    cmd.Parameters["@TransmisionProgramaRadial"].TypeName = "Formato.TransmisionProgramaRadial";
                    cmd.Parameters["@TransmisionProgramaRadial"].Value = datos;

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



