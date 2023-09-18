using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperpac
{
    public class EfectivoAccionMilitarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EfectivoAccionMilitarDTO> ObtenerLista()
        {
            List<EfectivoAccionMilitarDTO> lista = new List<EfectivoAccionMilitarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EfectivoAccionMilitarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EfectivoAccionMilitarDTO()
                        {
                            EfectivoAccionMilitarId = Convert.ToInt32(dr["EfectivoAccionMilitarId"]),
                            DescComandanciaNaval = dr["DescComandanciaNaval"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            UnidadParticipante = dr["UnidadParticipante"].ToString(),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString(),
                            ObservacionesEfectivoAccionMilitar = dr["ObservacionesEfectivoAccionMilitar"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EfectivoAccionMilitarDTO efectivoAccionMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoAccionMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaNavalId"].Value = efectivoAccionMilitarDTO.ComandanciaNavalId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = efectivoAccionMilitarDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@UnidadParticipante", SqlDbType.VarChar,20);
                    cmd.Parameters["@UnidadParticipante"].Value = efectivoAccionMilitarDTO.UnidadParticipante;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = efectivoAccionMilitarDTO.GradoPersonalId;

                    cmd.Parameters.Add("@ObservacionesEfectivoAccionMilitar", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionesEfectivoAccionMilitar"].Value = efectivoAccionMilitarDTO.ObservacionesEfectivoAccionMilitar;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoAccionMilitarDTO.UsuarioIngresoRegistro;

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

        public EfectivoAccionMilitarDTO BuscarFormato(int Codigo)
        {
            EfectivoAccionMilitarDTO efectivoAccionMilitarDTO = new EfectivoAccionMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoAccionMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoAccionMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoAccionMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        efectivoAccionMilitarDTO.EfectivoAccionMilitarId = Convert.ToInt32(dr["EfectivoAccionMilitarId"]);
                        efectivoAccionMilitarDTO.ComandanciaNavalId = Convert.ToInt32(dr["ComandanciaNavalId"]);
                        efectivoAccionMilitarDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        efectivoAccionMilitarDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        efectivoAccionMilitarDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        efectivoAccionMilitarDTO.UnidadParticipante = dr["UnidadParticipante"].ToString();
                        efectivoAccionMilitarDTO.GradoPersonalId = Convert.ToInt32(dr["GradoPersonalId"]);
                        efectivoAccionMilitarDTO.ObservacionesEfectivoAccionMilitar = dr["ObservacionesEfectivoAccionMilitar"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return efectivoAccionMilitarDTO;
        }

        public string ActualizaFormato(EfectivoAccionMilitarDTO efectivoAccionMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EfectivoAccionMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EfectivoAccionMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoAccionMilitarId"].Value = efectivoAccionMilitarDTO.EfectivoAccionMilitarId;

                    cmd.Parameters.Add("@ComandanciaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaNavalId"].Value = efectivoAccionMilitarDTO.ComandanciaNavalId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = efectivoAccionMilitarDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@UnidadParticipante", SqlDbType.VarChar,20);
                    cmd.Parameters["@UnidadParticipante"].Value = efectivoAccionMilitarDTO.UnidadParticipante;

                    cmd.Parameters.Add("@GradoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalId"].Value = efectivoAccionMilitarDTO.GradoPersonalId;

                    cmd.Parameters.Add("@ObservacionesEfectivoAccionMilitar", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionesEfectivoAccionMilitar"].Value = efectivoAccionMilitarDTO.ObservacionesEfectivoAccionMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoAccionMilitarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EfectivoAccionMilitarDTO efectivoAccionMilitarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoAccionMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoAccionMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoAccionMilitarId"].Value = efectivoAccionMilitarDTO.EfectivoAccionMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoAccionMilitarDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EfectivoAccionMilitarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoAccionMilitar", SqlDbType.Structured);
                    cmd.Parameters["@EfectivoAccionMilitar"].TypeName = "Formato.EfectivoAccionMilitar";
                    cmd.Parameters["@EfectivoAccionMilitar"].Value = datos;

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
