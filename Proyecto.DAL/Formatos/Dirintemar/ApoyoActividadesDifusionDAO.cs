using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class ApoyoActividadesDifusionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ApoyoActividadesDifusionDTO> ObtenerLista()
        {
            List<ApoyoActividadesDifusionDTO> lista = new List<ApoyoActividadesDifusionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ApoyoActividadesDifusionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ApoyoActividadesDifusionDTO()
                        {
                            ApoyoActividadDifusionId = Convert.ToInt32(dr["ApoyoActividadDifusionId"]),
                            DescTipoActividadDifusion = dr["DescTipoActividadDifusion"].ToString(),
                            NombreApoyoActividadDifusion = dr["NombreApoyoActividadDifusion"].ToString(),
                            LugarApoyoActividadDifusion = dr["LugarApoyoActividadDifusion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescDirigidoA = dr["DescDirigidoA"].ToString(),
                            InicioApoyoActividadDifusion = (dr["InicioApoyoActividadDifusion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TerminoApoyoActividadDifusion = (dr["TerminoApoyoActividadDifusion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            InversionApoyoActividadDifusion = Convert.ToInt32(dr["InversionApoyoActividadDifusion"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ApoyoActividadesDifusionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoActividadDifusion", SqlDbType.Int);
                    cmd.Parameters["@CodigoTipoActividadDifusion"].Value = apoyoActividadesDifusionDTO.CodigoTipoActividadDifusion;

                    cmd.Parameters.Add("@NombreApoyoActividadDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombreApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.NombreApoyoActividadDifusion;

                    cmd.Parameters.Add("@LugarApoyoActividadDifusion", SqlDbType.VarChar,80);
                    cmd.Parameters["@LugarApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.LugarApoyoActividadDifusion;

                    cmd.Parameters.Add("@DepartamentoUbigeo", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeo"].Value = apoyoActividadesDifusionDTO.DepartamentoUbigeo;

                    cmd.Parameters.Add("@DirigidoAId", SqlDbType.Int);
                    cmd.Parameters["@DirigidoAId"].Value = apoyoActividadesDifusionDTO.DirigidoAId;

                    cmd.Parameters.Add("@InicioApoyoActividadDifusion", SqlDbType.Date);
                    cmd.Parameters["@InicioApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.InicioApoyoActividadDifusion;

                    cmd.Parameters.Add("@TerminoApoyoActividadDifusion", SqlDbType.Date);
                    cmd.Parameters["@TerminoApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.TerminoApoyoActividadDifusion;

                    cmd.Parameters.Add("@InversionApoyoActividadDifusion", SqlDbType.Int);
                    cmd.Parameters["@InversionApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.InversionApoyoActividadDifusion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoActividadesDifusionDTO.UsuarioIngresoRegistro;

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

        public ApoyoActividadesDifusionDTO BuscarFormato(int Codigo)
        {
            ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO = new ApoyoActividadesDifusionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoActividadesDifusionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoActividadDifusionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        apoyoActividadesDifusionDTO.ApoyoActividadDifusionId = Convert.ToInt32(dr["ApoyoActividadDifusionId"]);
                        apoyoActividadesDifusionDTO.CodigoTipoActividadDifusion = dr["CodigoTipoActividadDifusion"].ToString();
                        apoyoActividadesDifusionDTO.NombreApoyoActividadDifusion = dr["NombreApoyoActividadDifusion"].ToString();
                        apoyoActividadesDifusionDTO.LugarApoyoActividadDifusion = dr["LugarApoyoActividadDifusion"].ToString();
                        apoyoActividadesDifusionDTO.DepartamentoUbigeo = dr["DepartamentoUbigeo"].ToString();
                        apoyoActividadesDifusionDTO.DirigidoAId = Convert.ToInt32(dr["DirigidoAId"]);
                        apoyoActividadesDifusionDTO.InicioApoyoActividadDifusion = Convert.ToDateTime(dr["InicioApoyoActividadDifusion"]).ToString("yyy-MM-dd");
                        apoyoActividadesDifusionDTO.TerminoApoyoActividadDifusion = Convert.ToDateTime(dr["TerminoApoyoActividadDifusion"]).ToString("yyy-MM-dd");
                        apoyoActividadesDifusionDTO.InversionApoyoActividadDifusion = Convert.ToInt32(dr["InversionApoyoActividadDifusion"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return apoyoActividadesDifusionDTO;
        }

        public string ActualizaFormato(ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ApoyoActividadesDifusionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoActividadDifusionId"].Value = apoyoActividadesDifusionDTO.ApoyoActividadDifusionId;

                    cmd.Parameters.Add("@CodigoTipoActividadDifusion", SqlDbType.Int);
                    cmd.Parameters["@CodigoTipoActividadDifusion"].Value = apoyoActividadesDifusionDTO.CodigoTipoActividadDifusion;

                    cmd.Parameters.Add("@NombreApoyoActividadDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombreApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.NombreApoyoActividadDifusion;

                    cmd.Parameters.Add("@LugarApoyoActividadDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@LugarApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.LugarApoyoActividadDifusion;

                    cmd.Parameters.Add("@DepartamentoUbigeo", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeo"].Value = apoyoActividadesDifusionDTO.DepartamentoUbigeo;

                    cmd.Parameters.Add("@DirigidoAId", SqlDbType.Int);
                    cmd.Parameters["@DirigidoAId"].Value = apoyoActividadesDifusionDTO.DirigidoAId;

                    cmd.Parameters.Add("@InicioApoyoActividadDifusion", SqlDbType.Date);
                    cmd.Parameters["@InicioApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.InicioApoyoActividadDifusion;

                    cmd.Parameters.Add("@TerminoApoyoActividadDifusion", SqlDbType.Date);
                    cmd.Parameters["@TerminoApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.TerminoApoyoActividadDifusion;

                    cmd.Parameters.Add("@InversionApoyoActividadDifusion", SqlDbType.Int);
                    cmd.Parameters["@InversionApoyoActividadDifusion"].Value = apoyoActividadesDifusionDTO.InversionApoyoActividadDifusion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoActividadesDifusionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoActividadesDifusionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoActividadDifusionId"].Value = apoyoActividadesDifusionDTO.ApoyoActividadDifusionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoActividadesDifusionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ApoyoActividadesDifusionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoActividadesDifusion", SqlDbType.Structured);
                    cmd.Parameters["@ApoyoActividadesDifusion"].TypeName = "Formato.ApoyoActividadesDifusion";
                    cmd.Parameters["@ApoyoActividadesDifusion"].Value = datos;

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
