using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperpac
{
    public class BajaTiempoPazDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<BajaTiempoPazDTO> ObtenerLista()
        {
            List<BajaTiempoPazDTO> lista = new List<BajaTiempoPazDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_BajaTiempoPazListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new BajaTiempoPazDTO()
                        {
                            BajaTiempoPazId = Convert.ToInt32(dr["BajaTiempoPazId"]),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString(),
                            DescTipoBaja = dr["DescTipoBaja"].ToString(),
                            MotivoBajaTiempoPaz = dr["MotivoBajaTiempoPaz"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(BajaTiempoPazDTO bajaTiempoPazDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BajaTiempoPazRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = bajaTiempoPazDTO.ZonaNavalId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = bajaTiempoPazDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = bajaTiempoPazDTO.GradoPersonalId;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = bajaTiempoPazDTO.TipoBajaId;

                    cmd.Parameters.Add("@MotivoBajaTiempoPaz", SqlDbType.VarChar,500);
                    cmd.Parameters["@MotivoBajaTiempoPaz"].Value = bajaTiempoPazDTO.MotivoBajaTiempoPaz;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bajaTiempoPazDTO.UsuarioIngresoRegistro;

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

        public BajaTiempoPazDTO BuscarFormato(int Codigo)
        {
            BajaTiempoPazDTO bajaTiempoPazDTO = new BajaTiempoPazDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BajaTiempoPazEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BajaTiempoPazId", SqlDbType.Int);
                    cmd.Parameters["@BajaTiempoPazId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        bajaTiempoPazDTO.BajaTiempoPazId = Convert.ToInt32(dr["BajaTiempoPazId"]);
                        bajaTiempoPazDTO.ZonaNavalId = Convert.ToInt32(dr["ZonaNavalId"]);
                        bajaTiempoPazDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        bajaTiempoPazDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        bajaTiempoPazDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        bajaTiempoPazDTO.GradoPersonalId = Convert.ToInt32(dr["GradoPersonalId"]);
                        bajaTiempoPazDTO.TipoBajaId = Convert.ToInt32(dr["TipoBajaId"]);
                        bajaTiempoPazDTO.MotivoBajaTiempoPaz = dr["MotivoBajaTiempoPaz"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return bajaTiempoPazDTO;
        }

        public string ActualizaFormato(BajaTiempoPazDTO bajaTiempoPazDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_BajaTiempoPazActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@BajaTiempoPazId", SqlDbType.Int);
                    cmd.Parameters["@BajaTiempoPazId"].Value = bajaTiempoPazDTO.BajaTiempoPazId;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = bajaTiempoPazDTO.ZonaNavalId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = bajaTiempoPazDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = bajaTiempoPazDTO.GradoPersonalId;

                    cmd.Parameters.Add("@TipoBajaId", SqlDbType.Int);
                    cmd.Parameters["@TipoBajaId"].Value = bajaTiempoPazDTO.TipoBajaId;

                    cmd.Parameters.Add("@MotivoBajaTiempoPaz", SqlDbType.VarChar,500);
                    cmd.Parameters["@MotivoBajaTiempoPaz"].Value = bajaTiempoPazDTO.MotivoBajaTiempoPaz;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bajaTiempoPazDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(BajaTiempoPazDTO bajaTiempoPazDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BajaTiempoPazEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BajaTiempoPazId", SqlDbType.Int);
                    cmd.Parameters["@BajaTiempoPazId"].Value = bajaTiempoPazDTO.BajaTiempoPazId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bajaTiempoPazDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_BajaTiempoPazRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BajaTiempoPaz", SqlDbType.Structured);
                    cmd.Parameters["@BajaTiempoPaz"].TypeName = "Formato.BajaTiempoPaz";
                    cmd.Parameters["@BajaTiempoPaz"].Value = datos;

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
