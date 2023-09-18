using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroEquipoConectividadDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEquipoConectividadDTO> ObtenerLista()
        {
            List<RegistroEquipoConectividadDTO> lista = new List<RegistroEquipoConectividadDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEquipoConectividadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEquipoConectividadDTO()
                        {
                            RegistroEquipoConectividadId = Convert.ToInt32(dr["RegistroEquipoConectividadId"]),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            Conectividad = dr["Conectividad"].ToString(),
                            Condicion = dr["Condicion"].ToString(),
                            NivelCapa = dr["NivelCapa"].ToString(),
                            CantidadPuerto = dr["CantidadPuerto"].ToString(),
                            AnioAdquisicionConectividad = (dr["AnioAdquisicionConectividad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoOperatividadConectividad = dr["EstadoOperatividadConectividad"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            CodigoIBPEquipoConectividad = dr["CodigoIBPEquipoConectividad"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroEquipoConectividadDTO registroEquipoConectividadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoConectividadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoConectividadDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoConectividadDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoConectividadDTO.MarcaId;

                    cmd.Parameters.Add("@Conectividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Conectividad"].Value = registroEquipoConectividadDTO.Conectividad;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Condicion"].Value = registroEquipoConectividadDTO.Condicion;

                    cmd.Parameters.Add("@NivelCapa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelCapa"].Value = registroEquipoConectividadDTO.NivelCapa;

                    cmd.Parameters.Add("@CantidadPuerto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CantidadPuerto"].Value = registroEquipoConectividadDTO.CantidadPuerto;

                    cmd.Parameters.Add("@AnioAdquisicionConectividad", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionConectividad"].Value = registroEquipoConectividadDTO.AnioAdquisicionConectividad;

                    cmd.Parameters.Add("@EstadoOperatividadConectividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadConectividad"].Value = registroEquipoConectividadDTO.EstadoOperatividadConectividad;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoConectividadDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoConectividadDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoIBPEquipoConectividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoConectividad"].Value = registroEquipoConectividadDTO.CodigoIBPEquipoConectividad;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoConectividadDTO.UsuarioIngresoRegistro;

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

        public RegistroEquipoConectividadDTO BuscarFormato(int Codigo)
        {
            RegistroEquipoConectividadDTO registroEquipoConectividadDTO = new RegistroEquipoConectividadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoConectividadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoConectividadId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoConectividadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEquipoConectividadDTO.RegistroEquipoConectividadId = Convert.ToInt32(dr["RegistroEquipoConectividadId"]);
                        registroEquipoConectividadDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroEquipoConectividadDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroEquipoConectividadDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroEquipoConectividadDTO.Conectividad = dr["Conectividad"].ToString();
                        registroEquipoConectividadDTO.Condicion = dr["Condicion"].ToString();
                        registroEquipoConectividadDTO.NivelCapa = dr["NivelCapa"].ToString();
                        registroEquipoConectividadDTO.CantidadPuerto = dr["CantidadPuerto"].ToString();
                        registroEquipoConectividadDTO.AnioAdquisicionConectividad = Convert.ToDateTime(dr["AnioAdquisicionConectividad"]).ToString("yyy-MM-dd");
                        registroEquipoConectividadDTO.EstadoOperatividadConectividad = dr["EstadoOperatividadConectividad"].ToString();
                        registroEquipoConectividadDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroEquipoConectividadDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        registroEquipoConectividadDTO.CodigoIBPEquipoConectividad = dr["CodigoIBPEquipoConectividad"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEquipoConectividadDTO;
        }

        public string ActualizaFormato(RegistroEquipoConectividadDTO registroEquipoConectividadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEquipoConectividadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEquipoConectividadId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoConectividadId"].Value = registroEquipoConectividadDTO.RegistroEquipoConectividadId;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoConectividadDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoConectividadDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoConectividadDTO.MarcaId;

                    cmd.Parameters.Add("@Conectividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Conectividad"].Value = registroEquipoConectividadDTO.Conectividad;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Condicion"].Value = registroEquipoConectividadDTO.Condicion;

                    cmd.Parameters.Add("@NivelCapa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelCapa"].Value = registroEquipoConectividadDTO.NivelCapa;

                    cmd.Parameters.Add("@CantidadPuerto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CantidadPuerto"].Value = registroEquipoConectividadDTO.CantidadPuerto;

                    cmd.Parameters.Add("@AnioAdquisicionConectividad", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionConectividad"].Value = registroEquipoConectividadDTO.AnioAdquisicionConectividad;

                    cmd.Parameters.Add("@EstadoOperatividadConectividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadConectividad"].Value = registroEquipoConectividadDTO.EstadoOperatividadConectividad;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoConectividadDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoConectividadDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoIBPEquipoConectividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoConectividad"].Value = registroEquipoConectividadDTO.CodigoIBPEquipoConectividad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoConectividadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEquipoConectividadDTO registroEquipoConectividadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoConectividadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoConectividadId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoConectividadId"].Value = registroEquipoConectividadDTO.RegistroEquipoConectividadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoConectividadDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEquipoConectividadRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoConectividad", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEquipoConectividad"].TypeName = "Formato.RegistroEquipoConectividad";
                    cmd.Parameters["@RegistroEquipoConectividad"].Value = datos;

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
