using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class PerfilProfesionalSistemaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PerfilProfesionalSistemaDTO> ObtenerLista(int? CargaId = null)
        {
            List<PerfilProfesionalSistemaDTO> lista = new List<PerfilProfesionalSistemaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PerfilProfesionalSistemaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PerfilProfesionalSistemaDTO()
                        {
                            PerfilProfesionalSistemaId = Convert.ToInt32(dr["PerfilProfesionalSistemaId"]),
                            DNIProfesionaleSistema = dr["DNIProfesionaleSistema"].ToString(),
                            TipoPersonalProfesional = dr["TipoPersonalProfesional"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            NivelEspecializacionSistema = dr["NivelEspecializacionSistema"].ToString(),
                            DescPerfilProfesional = dr["DescPerfilProfesional"].ToString(),
                            AnioExperienciaSistema = Convert.ToInt32(dr["AnioExperienciaSistema"]),
                            TiempoServicioInstitucion = Convert.ToInt32(dr["TiempoServicioInstitucion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PerfilProfesionalSistemaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIProfesionaleSistema", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DNIProfesionaleSistema"].Value = perfilProfesionalSistemaDTO.DNIProfesionaleSistema;

                    cmd.Parameters.Add("@TipoPersonalProfesional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPersonalProfesional"].Value = perfilProfesionalSistemaDTO.TipoPersonalProfesional;

                    cmd.Parameters.Add("@CodigoPerfilProfesional ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = perfilProfesionalSistemaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NivelEspecializacionSistema", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelEspecializacionSistema"].Value = perfilProfesionalSistemaDTO.NivelEspecializacionSistema;

                    cmd.Parameters.Add("@CodigoPerfilProfesional ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoPerfilProfesional "].Value = perfilProfesionalSistemaDTO.CodigoPerfilProfesional;

                    cmd.Parameters.Add("@AnioExperienciaSistema", SqlDbType.Int);
                    cmd.Parameters["@AnioExperienciaSistema"].Value = perfilProfesionalSistemaDTO.AnioExperienciaSistema;

                    cmd.Parameters.Add("@TiempoServicioInstitucion", SqlDbType.Int);
                    cmd.Parameters["@TiempoServicioInstitucion"].Value = perfilProfesionalSistemaDTO.TiempoServicioInstitucion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = perfilProfesionalSistemaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = perfilProfesionalSistemaDTO.UsuarioIngresoRegistro;

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

        public PerfilProfesionalSistemaDTO BuscarFormato(int Codigo)
        {
            PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO = new PerfilProfesionalSistemaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PerfilProfesionalSistemaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PerfilProfesionalSistemaId", SqlDbType.Int);
                    cmd.Parameters["@PerfilProfesionalSistemaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        perfilProfesionalSistemaDTO.PerfilProfesionalSistemaId = Convert.ToInt32(dr["PerfilProfesionalSistemaId"]);
                        perfilProfesionalSistemaDTO.DNIProfesionaleSistema = dr["DNIProfesionaleSistema"].ToString();
                        perfilProfesionalSistemaDTO.TipoPersonalProfesional = dr["TipoPersonalProfesional"].ToString();
                        perfilProfesionalSistemaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar "].ToString();
                        perfilProfesionalSistemaDTO.NivelEspecializacionSistema = dr["NivelEspecializacionSistema"].ToString();
                        perfilProfesionalSistemaDTO.CodigoPerfilProfesional = dr["CodigoPerfilProfesional "].ToString();
                        perfilProfesionalSistemaDTO.AnioExperienciaSistema = Convert.ToInt32(dr["AnioExperienciaSistema"]);
                        perfilProfesionalSistemaDTO.TiempoServicioInstitucion = Convert.ToInt32(dr["TiempoServicioInstitucion"]); 
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return perfilProfesionalSistemaDTO;
        }

        public string ActualizaFormato(PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PerfilProfesionalSistemaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PerfilProfesionalSistemaId", SqlDbType.Int);
                    cmd.Parameters["@PerfilProfesionalSistemaId"].Value = perfilProfesionalSistemaDTO.PerfilProfesionalSistemaId;

                    cmd.Parameters.Add("@DNIProfesionaleSistema", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DNIProfesionaleSistema"].Value = perfilProfesionalSistemaDTO.DNIProfesionaleSistema;

                    cmd.Parameters.Add("@TipoPersonalProfesional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPersonalProfesional"].Value = perfilProfesionalSistemaDTO.TipoPersonalProfesional;

                    cmd.Parameters.Add("@CodigoPerfilProfesional ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = perfilProfesionalSistemaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NivelEspecializacionSistema", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelEspecializacionSistema"].Value = perfilProfesionalSistemaDTO.NivelEspecializacionSistema;

                    cmd.Parameters.Add("@CodigoPerfilProfesional ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPerfilProfesional "].Value = perfilProfesionalSistemaDTO.CodigoPerfilProfesional;

                    cmd.Parameters.Add("@AnioExperienciaSistema", SqlDbType.Int);
                    cmd.Parameters["@AnioExperienciaSistema"].Value = perfilProfesionalSistemaDTO.AnioExperienciaSistema;

                    cmd.Parameters.Add("@TiempoServicioInstitucion", SqlDbType.Int);
                    cmd.Parameters["@TiempoServicioInstitucion"].Value = perfilProfesionalSistemaDTO.TiempoServicioInstitucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = perfilProfesionalSistemaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PerfilProfesionalSistemaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PerfilProfesionalSistemaId", SqlDbType.Int);
                    cmd.Parameters["@PerfilProfesionalSistemaId"].Value = perfilProfesionalSistemaDTO.PerfilProfesionalSistemaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = perfilProfesionalSistemaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PerfilProfesionalSistemaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PerfilProfesionalSistema", SqlDbType.Structured);
                    cmd.Parameters["@PerfilProfesionalSistema"].TypeName = "Formato.PerfilProfesionalSistema";
                    cmd.Parameters["@PerfilProfesionalSistema"].Value = datos;

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
