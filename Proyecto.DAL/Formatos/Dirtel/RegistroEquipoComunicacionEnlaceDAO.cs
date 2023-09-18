using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroEquipoComunicacionEnlaceDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEquipoComunicacionEnlaceDTO> ObtenerLista()
        {
            List<RegistroEquipoComunicacionEnlaceDTO> lista = new List<RegistroEquipoComunicacionEnlaceDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEnlaceListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEquipoComunicacionEnlaceDTO()
                        {
                            RegistroEquipoComunicacionEnlaceId = Convert.ToInt32(dr["RegistroEquipoComunicacionEnlaceId"]),
                            CodigoIBPEquipoEnlace = dr["CodigoIBPEquipoEnlace"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            ModeloEquipoEnlace = dr["ModeloEquipoEnlace"].ToString(),
                            ModoEquipoEnlace = dr["ModoEquipoEnlace"].ToString(),
                            NumeroCanalEquipo = Convert.ToInt32(dr["NumeroCanalEquipo"]),
                            AnchoBanda = dr["AnchoBanda"].ToString(),
                            TipoEquipoComunicacionEnlace = dr["TipoEquipoComunicacionEnlace"].ToString(),
                            EstadoOperatividadEnlace = dr["EstadoOperatividadEnlace"].ToString(),
                            AnioAdquisicion = (dr["AnioAdquisicion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEnlaceRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPEquipoEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoEnlace"].Value = registroEquipoComunicacionEnlaceDTO.CodigoIBPEquipoEnlace;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoComunicacionEnlaceDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloEquipoEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModeloEquipoEnlace"].Value = registroEquipoComunicacionEnlaceDTO.ModeloEquipoEnlace;

                    cmd.Parameters.Add("@ModoEquipoEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModoEquipoEnlace"].Value = registroEquipoComunicacionEnlaceDTO.ModoEquipoEnlace;

                    cmd.Parameters.Add("@NumeroCanalEquipo", SqlDbType.Int);
                    cmd.Parameters["@NumeroCanalEquipo"].Value = registroEquipoComunicacionEnlaceDTO.NumeroCanalEquipo;

                    cmd.Parameters.Add("@AnchoBanda", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AnchoBanda"].Value = registroEquipoComunicacionEnlaceDTO.AnchoBanda;

                    cmd.Parameters.Add("@TipoEquipoComunicacionEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoEquipoComunicacionEnlace"].Value = registroEquipoComunicacionEnlaceDTO.TipoEquipoComunicacionEnlace;

                    cmd.Parameters.Add("@EstadoOperatividadEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadEnlace"].Value = registroEquipoComunicacionEnlaceDTO.EstadoOperatividadEnlace;

                    cmd.Parameters.Add("@AnioAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicion"].Value = registroEquipoComunicacionEnlaceDTO.AnioAdquisicion;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoComunicacionEnlaceDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoComunicacionEnlaceDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComunicacionEnlaceDTO.UsuarioIngresoRegistro;

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

        public RegistroEquipoComunicacionEnlaceDTO BuscarFormato(int Codigo)
        {
            RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO = new RegistroEquipoComunicacionEnlaceDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEnlaceEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComunicacionEnlaceId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComunicacionEnlaceId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEquipoComunicacionEnlaceDTO.RegistroEquipoComunicacionEnlaceId = Convert.ToInt32(dr["RegistroEquipoComunicacionEnlaceId"]);
                        registroEquipoComunicacionEnlaceDTO.CodigoIBPEquipoEnlace = dr["CodigoIBPEquipoEnlace"].ToString();
                        registroEquipoComunicacionEnlaceDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroEquipoComunicacionEnlaceDTO.ModeloEquipoEnlace = dr["ModeloEquipoEnlace"].ToString();
                        registroEquipoComunicacionEnlaceDTO.ModoEquipoEnlace = dr["ModoEquipoEnlace"].ToString();
                        registroEquipoComunicacionEnlaceDTO.NumeroCanalEquipo = Convert.ToInt32(dr["NumeroCanalEquipo"]);
                        registroEquipoComunicacionEnlaceDTO.AnchoBanda = dr["AnchoBanda"].ToString();
                        registroEquipoComunicacionEnlaceDTO.TipoEquipoComunicacionEnlace = dr["TipoEquipoComunicacionEnlace"].ToString();
                        registroEquipoComunicacionEnlaceDTO.EstadoOperatividadEnlace = dr["EstadoOperatividadEnlace"].ToString();
                        registroEquipoComunicacionEnlaceDTO.AnioAdquisicion = Convert.ToDateTime(dr["AnioAdquisicion"]).ToString("yyy-MM-dd");
                        registroEquipoComunicacionEnlaceDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroEquipoComunicacionEnlaceDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEquipoComunicacionEnlaceDTO;
        }

        public string ActualizaFormato(RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEnlaceActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEquipoComunicacionEnlaceId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComunicacionEnlaceId"].Value = registroEquipoComunicacionEnlaceDTO.RegistroEquipoComunicacionEnlaceId;

                    cmd.Parameters.Add("@CodigoIBPEquipoEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoEnlace"].Value = registroEquipoComunicacionEnlaceDTO.CodigoIBPEquipoEnlace;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoComunicacionEnlaceDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloEquipoEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModeloEquipoEnlace"].Value = registroEquipoComunicacionEnlaceDTO.ModeloEquipoEnlace;

                    cmd.Parameters.Add("@ModoEquipoEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModoEquipoEnlace"].Value = registroEquipoComunicacionEnlaceDTO.ModoEquipoEnlace;

                    cmd.Parameters.Add("@NumeroCanalEquipo", SqlDbType.Int);
                    cmd.Parameters["@NumeroCanalEquipo"].Value = registroEquipoComunicacionEnlaceDTO.NumeroCanalEquipo;

                    cmd.Parameters.Add("@AnchoBanda", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AnchoBanda"].Value = registroEquipoComunicacionEnlaceDTO.AnchoBanda;

                    cmd.Parameters.Add("@TipoEquipoComunicacionEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoEquipoComunicacionEnlace"].Value = registroEquipoComunicacionEnlaceDTO.TipoEquipoComunicacionEnlace;

                    cmd.Parameters.Add("@EstadoOperatividadEnlace", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadEnlace"].Value = registroEquipoComunicacionEnlaceDTO.EstadoOperatividadEnlace;

                    cmd.Parameters.Add("@AnioAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicion"].Value = registroEquipoComunicacionEnlaceDTO.AnioAdquisicion;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoComunicacionEnlaceDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoComunicacionEnlaceDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComunicacionEnlaceDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEnlaceEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComunicacionEnlaceId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComunicacionEnlaceId"].Value = registroEquipoComunicacionEnlaceDTO.RegistroEquipoComunicacionEnlaceId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComunicacionEnlaceDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEnlaceRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComunicacionEnlace", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEquipoComunicacionEnlace"].TypeName = "Formato.RegistroEquipoComunicacionEnlace";
                    cmd.Parameters["@RegistroEquipoComunicacionEnlace"].Value = datos;

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
