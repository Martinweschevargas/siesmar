using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ipecamar
{
    public class DenunciaAnticorrupcionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DenunciaAnticorrupcionDTO> ObtenerLista(int? CargaId=null)
        {
            List<DenunciaAnticorrupcionDTO> lista = new List<DenunciaAnticorrupcionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DenunciaAnticorrupcionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DenunciaAnticorrupcionDTO()
                        {
                            DenunciaAnticorrupcionId = Convert.ToInt32(dr["DenunciaAnticorrupcionId"]),
                            FechaRegistroDenuncAntic = (dr["FechaRegistroDenuncAntic"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescCanalDenuncia = dr["DescCanalDenuncia"].ToString(),
                            EvaluacionRequisitoDenuncAntic = dr["EvaluacionRequisitoDenuncAntic"].ToString(),
                            SituacionActualDenuncAntic = dr["SituacionActualDenuncAntic"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DenunciaAnticorrupcionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaRegistroDenuncAntic", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroDenuncAntic"].Value = denunciaAnticorrupcionDTO.FechaRegistroDenuncAntic;

                    cmd.Parameters.Add("@CodigoCanalDenuncia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCanalDenuncia"].Value = denunciaAnticorrupcionDTO.CodigoCanalDenuncia;

                    cmd.Parameters.Add("@EvaluacionRequisitoDenuncAntic", SqlDbType.VarChar,10);
                    cmd.Parameters["@EvaluacionRequisitoDenuncAntic"].Value = denunciaAnticorrupcionDTO.EvaluacionRequisitoDenuncAntic;

                    cmd.Parameters.Add("@SituacionActualDenuncAntic", SqlDbType.VarChar,30);
                    cmd.Parameters["@SituacionActualDenuncAntic"].Value = denunciaAnticorrupcionDTO.SituacionActualDenuncAntic;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = denunciaAnticorrupcionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denunciaAnticorrupcionDTO.UsuarioIngresoRegistro;

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

        public DenunciaAnticorrupcionDTO BuscarFormato(int Codigo)
        {
            DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO = new DenunciaAnticorrupcionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DenunciaAnticorrupcionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenunciaAnticorrupcionId", SqlDbType.Int);
                    cmd.Parameters["@DenunciaAnticorrupcionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        denunciaAnticorrupcionDTO.DenunciaAnticorrupcionId = Convert.ToInt32(dr["DenunciaAnticorrupcionId"]);
                        denunciaAnticorrupcionDTO.FechaRegistroDenuncAntic = Convert.ToDateTime(dr["FechaRegistroDenuncAntic"]).ToString("yyy-MM-dd");
                        denunciaAnticorrupcionDTO.CodigoCanalDenuncia = dr["CodigoCanalDenuncia"].ToString();
                        denunciaAnticorrupcionDTO.EvaluacionRequisitoDenuncAntic = dr["EvaluacionRequisitoDenuncAntic"].ToString();
                        denunciaAnticorrupcionDTO.SituacionActualDenuncAntic = dr["SituacionActualDenuncAntic"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return denunciaAnticorrupcionDTO;
        }

        public string ActualizaFormato(DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DenunciaAnticorrupcionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenunciaAnticorrupcionId", SqlDbType.Int);
                    cmd.Parameters["@DenunciaAnticorrupcionId"].Value = denunciaAnticorrupcionDTO.DenunciaAnticorrupcionId;

                    cmd.Parameters.Add("@FechaRegistroDenuncAntic", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistroDenuncAntic"].Value = denunciaAnticorrupcionDTO.FechaRegistroDenuncAntic;

                    cmd.Parameters.Add("@CodigoCanalDenuncia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCanalDenuncia"].Value = denunciaAnticorrupcionDTO.CodigoCanalDenuncia;

                    cmd.Parameters.Add("@EvaluacionRequisitoDenuncAntic", SqlDbType.VarChar, 10);
                    cmd.Parameters["@EvaluacionRequisitoDenuncAntic"].Value = denunciaAnticorrupcionDTO.EvaluacionRequisitoDenuncAntic;

                    cmd.Parameters.Add("@SituacionActualDenuncAntic", SqlDbType.VarChar, 30);
                    cmd.Parameters["@SituacionActualDenuncAntic"].Value = denunciaAnticorrupcionDTO.SituacionActualDenuncAntic;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denunciaAnticorrupcionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DenunciaAnticorrupcionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenunciaAnticorrupcionId", SqlDbType.Int);
                    cmd.Parameters["@DenunciaAnticorrupcionId"].Value = denunciaAnticorrupcionDTO.DenunciaAnticorrupcionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denunciaAnticorrupcionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DenunciaAnticorrupcionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenunciaAnticorrupcion", SqlDbType.Structured);
                    cmd.Parameters["@DenunciaAnticorrupcion"].TypeName = "Formato.DenunciaAnticorrupcion";
                    cmd.Parameters["@DenunciaAnticorrupcion"].Value = datos;

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
