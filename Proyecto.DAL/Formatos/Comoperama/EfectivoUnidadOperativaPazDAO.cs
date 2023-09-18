using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperama
{
    public class EfectivoUnidadOperativaPazDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EfectivoUnidadOperativaPazDTO> ObtenerLista(int? CargaId = null)
        {
            List<EfectivoUnidadOperativaPazDTO> lista = new List<EfectivoUnidadOperativaPazDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EfectivoUnidadOperativaPazListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                cmd.Parameters["@CargoId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EfectivoUnidadOperativaPazDTO()
                        {
                            EfectivoUnidadOperativaPazId = Convert.ToInt32(dr["EfectivoUnidadOperativaPazId"]),
                            CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString(),
                            CodigoDependencia = dr["CodigoDependencia"].ToString(),
                            CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString(),
                            NumeroEfectivosRequeridos = Convert.ToInt32(dr["NumeroEfectivosRequeridos"]),
                            NumeroEfectivosAsignados = Convert.ToInt32(dr["NumeroEfectivosAsignados"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoUnidadOperativaPazRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = efectivoUnidadOperativaPazDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = efectivoUnidadOperativaPazDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = efectivoUnidadOperativaPazDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@NumeroEfectivosRequeridos", SqlDbType.Int);
                    cmd.Parameters["@NumeroEfectivosRequeridos"].Value = efectivoUnidadOperativaPazDTO.NumeroEfectivosRequeridos;

                    cmd.Parameters.Add("@NumeroEfectivosAsignados", SqlDbType.Int);
                    cmd.Parameters["@NumeroEfectivosAsignados"].Value = efectivoUnidadOperativaPazDTO.NumeroEfectivosAsignados;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = efectivoUnidadOperativaPazDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoUnidadOperativaPazDTO.UsuarioIngresoRegistro;

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

        public EfectivoUnidadOperativaPazDTO BuscarFormato(int Codigo)
        {
            EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO = new EfectivoUnidadOperativaPazDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoUnidadOperativaPazEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoUnidadOperativaPazId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoUnidadOperativaPazId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        efectivoUnidadOperativaPazDTO.EfectivoUnidadOperativaPazId = Convert.ToInt32(dr["EfectivoUnidadOperativaPazId"]);
                        efectivoUnidadOperativaPazDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        efectivoUnidadOperativaPazDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        efectivoUnidadOperativaPazDTO.CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString();
                        efectivoUnidadOperativaPazDTO.NumeroEfectivosRequeridos = Convert.ToInt32(dr["NumeroEfectivosRequeridos"]);
                        efectivoUnidadOperativaPazDTO.NumeroEfectivosAsignados = Convert.ToInt32(dr["NumeroEfectivosAsignados"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return efectivoUnidadOperativaPazDTO;
        }

        public string ActualizaFormato(EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EfectivoUnidadOperativaPazActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EfectivoUnidadOperativaPazId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoUnidadOperativaPazId"].Value = efectivoUnidadOperativaPazDTO.EfectivoUnidadOperativaPazId;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = efectivoUnidadOperativaPazDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = efectivoUnidadOperativaPazDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = efectivoUnidadOperativaPazDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@NumeroEfectivosRequeridos", SqlDbType.Int);
                    cmd.Parameters["@NumeroEfectivosRequeridos"].Value = efectivoUnidadOperativaPazDTO.NumeroEfectivosRequeridos;

                    cmd.Parameters.Add("@NumeroEfectivosAsignados", SqlDbType.Int);
                    cmd.Parameters["@NumeroEfectivosAsignados"].Value = efectivoUnidadOperativaPazDTO.NumeroEfectivosAsignados;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoUnidadOperativaPazDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoUnidadOperativaPazEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoUnidadOperativaPazId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoUnidadOperativaPazId"].Value = efectivoUnidadOperativaPazDTO.EfectivoUnidadOperativaPazId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoUnidadOperativaPazDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EfectivoUnidadOperativaPazRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoUnidadOperativaPaz", SqlDbType.Structured);
                    cmd.Parameters["@EfectivoUnidadOperativaPaz"].TypeName = "Formato.EfectivoUnidadOperativaPaz";
                    cmd.Parameters["@EfectivoUnidadOperativaPaz"].Value = datos;

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
