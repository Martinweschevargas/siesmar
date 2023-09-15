using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirciten
{
    public class PostulanteCitenDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PostulanteCitenDTO> ObtenerLista(int? CargaId = null)
        {
            List<PostulanteCitenDTO> lista = new List<PostulanteCitenDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PostulanteCitenListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PostulanteCitenDTO()
                        {
                            PostulanteCitenId = Convert.ToInt32(dr["PostulanteCitenId"]),
                            DNIPostulanteCiten = dr["DNIPostulanteCiten"].ToString(),
                            GeneroPostulanteCiten = dr["GeneroPostulanteCiten"].ToString(),
                            FechaNacimientoPostulanteCiten = (dr["FechaNacimientoPostulanteCiten"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarNacimiento = dr["LugarNacimiento"].ToString(),
                            ProcedenciaPostulanteCiten = dr["ProcedenciaPostulanteCiten"].ToString(),
                            TipoColegioProveniente = dr["TipoColegioProveniente"].ToString(),
                            ColegioProcedencia = dr["ColegioProcedencia"].ToString(),
                            LugarColegio = dr["LugarColegio"].ToString(),
                            PadresEntidadMilitar = dr["PadresEntidadMilitar"].ToString(),
                            ModalidadIngreso = dr["ModalidadIngreso"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString(),
                            LugarPostulacion = dr["LugarPostulacion"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            SituacionIngreso = dr["SituacionIngreso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PostulanteCitenDTO postulanteCitenDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteCitenRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPostulanteCiten", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIPostulanteCiten"].Value = postulanteCitenDTO.DNIPostulanteCiten;

                    cmd.Parameters.Add("@GeneroPostulanteCiten", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GeneroPostulanteCiten"].Value = postulanteCitenDTO.GeneroPostulanteCiten;

                    cmd.Parameters.Add("@FechaNacimientoPostulanteCiten", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPostulanteCiten"].Value = postulanteCitenDTO.FechaNacimientoPostulanteCiten;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@LugarNacimiento"].Value = postulanteCitenDTO.LugarNacimiento;

                    cmd.Parameters.Add("@ProcedenciaPostulanteCiten", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ProcedenciaPostulanteCiten"].Value = postulanteCitenDTO.ProcedenciaPostulanteCiten;

                    cmd.Parameters.Add("@TipoColegioProveniente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoColegioProveniente"].Value = postulanteCitenDTO.TipoColegioProveniente;

                    cmd.Parameters.Add("@ColegioProcedencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColegioProcedencia"].Value = postulanteCitenDTO.ColegioProcedencia;

                    cmd.Parameters.Add("@LugarColegio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@LugarColegio"].Value = postulanteCitenDTO.LugarColegio;

                    cmd.Parameters.Add("@PadresEntidadMilitar", SqlDbType.NChar, 1);
                    cmd.Parameters["@PadresEntidadMilitar"].Value = postulanteCitenDTO.PadresEntidadMilitar;

                    cmd.Parameters.Add("@ModalidadIngreso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ModalidadIngreso"].Value = postulanteCitenDTO.ModalidadIngreso;

                    cmd.Parameters.Add("@TipoPreparacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoPreparacion"].Value = postulanteCitenDTO.TipoPreparacion;

                    cmd.Parameters.Add("@LugarPostulacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@LugarPostulacion"].Value = postulanteCitenDTO.LugarPostulacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = postulanteCitenDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@SituacionIngreso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionIngreso"].Value = postulanteCitenDTO.SituacionIngreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = postulanteCitenDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteCitenDTO.UsuarioIngresoRegistro;

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

        public PostulanteCitenDTO BuscarFormato(int Codigo)
        {
            PostulanteCitenDTO postulanteCitenDTO = new PostulanteCitenDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteCitenEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteCitenId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteCitenId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        postulanteCitenDTO.PostulanteCitenId = Convert.ToInt32(dr["PostulanteCitenId"]);
                        postulanteCitenDTO.DNIPostulanteCiten = dr["DNIPostulanteCiten"].ToString();
                        postulanteCitenDTO.GeneroPostulanteCiten = Regex.Replace(dr["GeneroPostulanteCiten"].ToString(), @"\s", "");
                        postulanteCitenDTO.FechaNacimientoPostulanteCiten = Convert.ToDateTime(dr["FechaNacimientoPostulanteCiten"]).ToString("yyy-MM-dd");
                        postulanteCitenDTO.LugarNacimiento = dr["LugarNacimiento"].ToString();
                        postulanteCitenDTO.ProcedenciaPostulanteCiten = dr["ProcedenciaPostulanteCiten"].ToString();
                        postulanteCitenDTO.TipoColegioProveniente = dr["TipoColegioProveniente"].ToString();
                        postulanteCitenDTO.ColegioProcedencia = dr["ColegioProcedencia"].ToString();
                        postulanteCitenDTO.LugarColegio = dr["LugarColegio"].ToString();
                        postulanteCitenDTO.PadresEntidadMilitar = dr["PadresEntidadMilitar"].ToString();
                        postulanteCitenDTO.ModalidadIngreso = dr["ModalidadIngreso"].ToString();
                        postulanteCitenDTO.TipoPreparacion = dr["TipoPreparacion"].ToString();
                        postulanteCitenDTO.LugarPostulacion = dr["LugarPostulacion"].ToString();
                        postulanteCitenDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        postulanteCitenDTO.SituacionIngreso = dr["SituacionIngreso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return postulanteCitenDTO;
        }

        public string ActualizaFormato(PostulanteCitenDTO postulanteCitenDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PostulanteCitenActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteCitenId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteCitenId"].Value = postulanteCitenDTO.PostulanteCitenId;

                    cmd.Parameters.Add("@DNIPostulanteCiten", SqlDbType.NChar, 8);
                    cmd.Parameters["@DNIPostulanteCiten"].Value = postulanteCitenDTO.DNIPostulanteCiten;

                    cmd.Parameters.Add("@GeneroPostulanteCiten", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GeneroPostulanteCiten"].Value = postulanteCitenDTO.GeneroPostulanteCiten;

                    cmd.Parameters.Add("@FechaNacimientoPostulanteCiten", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPostulanteCiten"].Value = postulanteCitenDTO.FechaNacimientoPostulanteCiten;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@LugarNacimiento"].Value = postulanteCitenDTO.LugarNacimiento;

                    cmd.Parameters.Add("@ProcedenciaPostulanteCiten", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ProcedenciaPostulanteCiten"].Value = postulanteCitenDTO.ProcedenciaPostulanteCiten;

                    cmd.Parameters.Add("@TipoColegioProveniente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoColegioProveniente"].Value = postulanteCitenDTO.TipoColegioProveniente;

                    cmd.Parameters.Add("@ColegioProcedencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColegioProcedencia"].Value = postulanteCitenDTO.ColegioProcedencia;

                    cmd.Parameters.Add("@LugarColegio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@LugarColegio"].Value = postulanteCitenDTO.LugarColegio;

                    cmd.Parameters.Add("@PadresEntidadMilitar", SqlDbType.NChar, 1);
                    cmd.Parameters["@PadresEntidadMilitar"].Value = postulanteCitenDTO.PadresEntidadMilitar;

                    cmd.Parameters.Add("@ModalidadIngreso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ModalidadIngreso"].Value = postulanteCitenDTO.ModalidadIngreso;

                    cmd.Parameters.Add("@TipoPreparacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoPreparacion"].Value = postulanteCitenDTO.TipoPreparacion;

                    cmd.Parameters.Add("@LugarPostulacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@LugarPostulacion"].Value = postulanteCitenDTO.LugarPostulacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = postulanteCitenDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@SituacionIngreso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionIngreso"].Value = postulanteCitenDTO.SituacionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteCitenDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PostulanteCitenDTO postulanteCitenDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteCitenEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteCitenId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteCitenId"].Value = postulanteCitenDTO.PostulanteCitenId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteCitenDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PostulanteCitenRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteCiten", SqlDbType.Structured);
                    cmd.Parameters["@PostulanteCiten"].TypeName = "Formato.PostulanteCiten";
                    cmd.Parameters["@PostulanteCiten"].Value = datos;

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
