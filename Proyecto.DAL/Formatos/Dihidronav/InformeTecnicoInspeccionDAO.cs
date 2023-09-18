using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class InformeTecnicoInspeccionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InformeTecnicoInspeccionDTO> ObtenerLista(int? CargaId =null)
        {
            List<InformeTecnicoInspeccionDTO> lista = new List<InformeTecnicoInspeccionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InformeTecnicoInspeccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InformeTecnicoInspeccionDTO()
                        {
                            InformeTecnicoInspeccionId = Convert.ToInt32(dr["InformeTecnicoInspeccionId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            NumeroInformeTecnico = dr["NumeroInformeTecnico"].ToString(),
                            DescTipoObra = dr["DescTipoObra"].ToString(),
                            DescripcionInspeccion = dr["DescripcionInspeccion"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EmpresaPersonaSolicitante = dr["EmpresaPersonaSolicitante"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformeTecnicoInspeccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = informeTecnicoInspeccionDTO.NumeroOrden;

                    cmd.Parameters.Add("@NumeroInformeTecnico", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroInformeTecnico"].Value = informeTecnicoInspeccionDTO.NumeroInformeTecnico;

                    cmd.Parameters.Add("@CodigoTipoObra", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoObra"].Value = informeTecnicoInspeccionDTO.CodigoTipoObra;

                    cmd.Parameters.Add("@DescripcionInspeccion", SqlDbType.VarChar,200);
                    cmd.Parameters["@DescripcionInspeccion"].Value = informeTecnicoInspeccionDTO.DescripcionInspeccion;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = informeTecnicoInspeccionDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@EmpresaPersonaSolicitante", SqlDbType.VarChar,200);
                    cmd.Parameters["@EmpresaPersonaSolicitante"].Value = informeTecnicoInspeccionDTO.EmpresaPersonaSolicitante;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = informeTecnicoInspeccionDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = informeTecnicoInspeccionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informeTecnicoInspeccionDTO.UsuarioIngresoRegistro;

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

        public InformeTecnicoInspeccionDTO BuscarFormato(int Codigo)
        {
            InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO = new InformeTecnicoInspeccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformeTecnicoInspeccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeTecnicoInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@InformeTecnicoInspeccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        informeTecnicoInspeccionDTO.InformeTecnicoInspeccionId = Convert.ToInt32(dr["InformeTecnicoInspeccionId"]);
                        informeTecnicoInspeccionDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        informeTecnicoInspeccionDTO.NumeroInformeTecnico = dr["NumeroInformeTecnico"].ToString();
                        informeTecnicoInspeccionDTO.CodigoTipoObra = dr["CodigoTipoObra"].ToString();
                        informeTecnicoInspeccionDTO.DescripcionInspeccion = dr["DescripcionInspeccion"].ToString();
                        informeTecnicoInspeccionDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        informeTecnicoInspeccionDTO.EmpresaPersonaSolicitante = dr["EmpresaPersonaSolicitante"].ToString();
                        informeTecnicoInspeccionDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return informeTecnicoInspeccionDTO;
        }

        public string ActualizaFormato(InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InformeTecnicoInspeccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@InformeTecnicoInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@InformeTecnicoInspeccionId"].Value = informeTecnicoInspeccionDTO.InformeTecnicoInspeccionId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = informeTecnicoInspeccionDTO.NumeroOrden;

                    cmd.Parameters.Add("@NumeroInformeTecnico", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroInformeTecnico"].Value = informeTecnicoInspeccionDTO.NumeroInformeTecnico;

                    cmd.Parameters.Add("@CodigoTipoObra", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoObra"].Value = informeTecnicoInspeccionDTO.CodigoTipoObra;

                    cmd.Parameters.Add("@DescripcionInspeccion", SqlDbType.VarChar,200);
                    cmd.Parameters["@DescripcionInspeccion"].Value = informeTecnicoInspeccionDTO.DescripcionInspeccion;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = informeTecnicoInspeccionDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@EmpresaPersonaSolicitante", SqlDbType.VarChar,200);
                    cmd.Parameters["@EmpresaPersonaSolicitante"].Value = informeTecnicoInspeccionDTO.EmpresaPersonaSolicitante;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = informeTecnicoInspeccionDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informeTecnicoInspeccionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformeTecnicoInspeccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeTecnicoInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@InformeTecnicoInspeccionId"].Value = informeTecnicoInspeccionDTO.InformeTecnicoInspeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informeTecnicoInspeccionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InformeTecnicoInspeccionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeTecnicoInspeccion", SqlDbType.Structured);
                    cmd.Parameters["@InformeTecnicoInspeccion"].TypeName = "Formato.InformeTecnicoInspeccion";
                    cmd.Parameters["@InformeTecnicoInspeccion"].Value = datos;

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
