using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class ComisionAudiovisualDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ComisionAudiovisualDTO> ObtenerLista(int? CargaId = null)
        {
            List<ComisionAudiovisualDTO> lista = new List<ComisionAudiovisualDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ComisionAudiovisualListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ComisionAudiovisualDTO()
                        {
                            ComisionAudiovisualId = Convert.ToInt32(dr["ComisionAudiovisualId"]),
                            FechaComisionAudiovisual = (dr["FechaComisionAudiovisual"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescPersonalComision = dr["DescPersonalComision"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            Motivo = dr["Motivo"].ToString(),
                            DescComision = dr["DescComision"].ToString(),
                            Costo = Convert.ToDecimal(dr["Costo"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ComisionAudiovisualDTO comisionAudiovisualDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ComisionAudiovisualRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaComisionAudiovisual", SqlDbType.Date);
                    cmd.Parameters["@FechaComisionAudiovisual"].Value = comisionAudiovisualDTO.FechaComisionAudiovisual;

                    cmd.Parameters.Add("@CodigoPersonalComision ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalComision "].Value = comisionAudiovisualDTO.CodigoPersonalComision;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = comisionAudiovisualDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Motivo"].Value = comisionAudiovisualDTO.Motivo;

                    cmd.Parameters.Add("@CodigoComision", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComision"].Value = comisionAudiovisualDTO.CodigoComision;

                    cmd.Parameters.Add("@Costo", SqlDbType.Decimal);
                    cmd.Parameters["@Costo"].Value = comisionAudiovisualDTO.Costo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = comisionAudiovisualDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comisionAudiovisualDTO.UsuarioIngresoRegistro;

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

        public ComisionAudiovisualDTO BuscarFormato(int Codigo)
        {
            ComisionAudiovisualDTO comisionAudiovisualDTO = new ComisionAudiovisualDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ComisionAudiovisualEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComisionAudiovisualId", SqlDbType.Int);
                    cmd.Parameters["@ComisionAudiovisualId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        comisionAudiovisualDTO.ComisionAudiovisualId = Convert.ToInt32(dr["ComisionAudiovisualId"]);
                        comisionAudiovisualDTO.FechaComisionAudiovisual = Convert.ToDateTime(dr["FechaComisionAudiovisual"]).ToString("yyy-MM-dd");
                        comisionAudiovisualDTO.CodigoPersonalComision = dr["CodigoPersonalComision"].ToString();
                        comisionAudiovisualDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        comisionAudiovisualDTO.Motivo = dr["Motivo"].ToString();
                        comisionAudiovisualDTO.CodigoComision = dr["CodigoComision"].ToString();
                        comisionAudiovisualDTO.Costo = Convert.ToDecimal(dr["Costo"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return comisionAudiovisualDTO;
        }

        public string ActualizaFormato(ComisionAudiovisualDTO comisionAudiovisualDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ComisionAudiovisualActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ComisionAudiovisualId", SqlDbType.Int);
                    cmd.Parameters["@ComisionAudiovisualId"].Value = comisionAudiovisualDTO.ComisionAudiovisualId;

                    cmd.Parameters.Add("@FechaComisionAudiovisual", SqlDbType.Date);
                    cmd.Parameters["@FechaComisionAudiovisual"].Value = comisionAudiovisualDTO.FechaComisionAudiovisual;

                    cmd.Parameters.Add("@CodigoPersonalComision ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalComision "].Value = comisionAudiovisualDTO.CodigoPersonalComision;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = comisionAudiovisualDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Motivo"].Value = comisionAudiovisualDTO.Motivo;

                    cmd.Parameters.Add("@CodigoComision", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComision"].Value = comisionAudiovisualDTO.CodigoComision;

                    cmd.Parameters.Add("@Costo", SqlDbType.Decimal);
                    cmd.Parameters["@Costo"].Value = comisionAudiovisualDTO.Costo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comisionAudiovisualDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ComisionAudiovisualDTO comisionAudiovisualDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ComisionAudiovisualEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComisionAudiovisualId", SqlDbType.Int);
                    cmd.Parameters["@ComisionAudiovisualId"].Value = comisionAudiovisualDTO.ComisionAudiovisualId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comisionAudiovisualDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ComisionAudiovisualRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComisionAudiovisual", SqlDbType.Structured);
                    cmd.Parameters["@ComisionAudiovisual"].TypeName = "Formato.ComisionAudiovisual";
                    cmd.Parameters["@ComisionAudiovisual"].Value = datos;

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