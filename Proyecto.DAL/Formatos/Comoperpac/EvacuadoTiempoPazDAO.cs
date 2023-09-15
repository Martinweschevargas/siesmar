using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperpac
{
    public class EvacuadoTiempoPazDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvacuadoTiempoPazDTO> ObtenerLista()
        {
            List<EvacuadoTiempoPazDTO> lista = new List<EvacuadoTiempoPazDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvacuadoTiempoPazListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvacuadoTiempoPazDTO()
                        {
                            EvacuadoTiempoPazId = Convert.ToInt32(dr["EvacuadoTiempoPazId"]),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString(),
                            DescTipoBaja = dr["DescTipoBaja"].ToString(),
                            MotivoEvacuadoTiempoPaz = dr["MotivoEvacuadoTiempoPaz"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvacuadoTiempoPazDTO evacuadoTiempoPazDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvacuadoTiempoPazRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = evacuadoTiempoPazDTO.ZonaNavalId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = evacuadoTiempoPazDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = evacuadoTiempoPazDTO.GradoPersonalId;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = evacuadoTiempoPazDTO.TipoBajaId;

                    cmd.Parameters.Add("@MotivoEvacuadoTiempoPaz", SqlDbType.VarChar,500);
                    cmd.Parameters["@MotivoEvacuadoTiempoPaz"].Value = evacuadoTiempoPazDTO.MotivoEvacuadoTiempoPaz;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evacuadoTiempoPazDTO.UsuarioIngresoRegistro;

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

        public EvacuadoTiempoPazDTO BuscarFormato(int Codigo)
        {
            EvacuadoTiempoPazDTO evacuadoTiempoPazDTO = new EvacuadoTiempoPazDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvacuadoTiempoPazEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvacuadoTiempoPazId", SqlDbType.Int);
                    cmd.Parameters["@EvacuadoTiempoPazId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evacuadoTiempoPazDTO.EvacuadoTiempoPazId = Convert.ToInt32(dr["EvacuadoTiempoPazId"]);
                        evacuadoTiempoPazDTO.ZonaNavalId = Convert.ToInt32(dr["ZonaNavalId"]);
                        evacuadoTiempoPazDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        evacuadoTiempoPazDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        evacuadoTiempoPazDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        evacuadoTiempoPazDTO.GradoPersonalId = Convert.ToInt32(dr["GradoPersonalId"]);
                        evacuadoTiempoPazDTO.TipoBajaId = Convert.ToInt32(dr["TipoBajaId"]);
                        evacuadoTiempoPazDTO.MotivoEvacuadoTiempoPaz = dr["MotivoEvacuadoTiempoPaz"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evacuadoTiempoPazDTO;
        }

        public string ActualizaFormato(EvacuadoTiempoPazDTO evacuadoTiempoPazDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvacuadoTiempoPazActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvacuadoTiempoPazId", SqlDbType.Int);
                    cmd.Parameters["@EvacuadoTiempoPazId"].Value = evacuadoTiempoPazDTO.EvacuadoTiempoPazId;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = evacuadoTiempoPazDTO.ZonaNavalId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = evacuadoTiempoPazDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = evacuadoTiempoPazDTO.GradoPersonalId;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = evacuadoTiempoPazDTO.TipoBajaId;

                    cmd.Parameters.Add("@MotivoEvacuadoTiempoPaz", SqlDbType.VarChar,500);
                    cmd.Parameters["@MotivoEvacuadoTiempoPaz"].Value = evacuadoTiempoPazDTO.MotivoEvacuadoTiempoPaz;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evacuadoTiempoPazDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvacuadoTiempoPazDTO evacuadoTiempoPazDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvacuadoTiempoPazEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvacuadoTiempoPazId", SqlDbType.Int);
                    cmd.Parameters["@EvacuadoTiempoPazId"].Value = evacuadoTiempoPazDTO.EvacuadoTiempoPazId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evacuadoTiempoPazDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvacuadoTiempoPazRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvacuadoTiempoPaz", SqlDbType.Structured);
                    cmd.Parameters["@EvacuadoTiempoPaz"].TypeName = "Formato.EvacuadoTiempoPaz";
                    cmd.Parameters["@EvacuadoTiempoPaz"].Value = datos;

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
