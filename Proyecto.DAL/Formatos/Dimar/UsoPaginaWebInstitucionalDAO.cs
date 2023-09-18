using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class UsoPaginaWebInstitucionalDAO
    {

        SqlCommand cmd = new SqlCommand();


        public List<UsoPaginaWebInstitucionalDTO> ObtenerLista(int? CargaId = null)
        {
            List<UsoPaginaWebInstitucionalDTO> lista = new List<UsoPaginaWebInstitucionalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_UsoPaginaWebInstitucionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UsoPaginaWebInstitucionalDTO()
                        {
                            UsoPaginaWebInstitucionalId = Convert.ToInt32(dr["UsoPaginaWebInstitucionalId"]),
                            DescTipoInformacion = dr["TipoInformacionId"].ToString(),
                            NumeroPublicaciones = Convert.ToInt32(dr["NumeroPublicaciones"]),
                            FechaPublicacion = (dr["FechaPublicacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoPaginaWebInstitucionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoInformacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacion "].Value = usoPaginaWebInstitucionalDTO.CodigoTipoInformacion;

                    cmd.Parameters.Add("@NumeroPublicaciones", SqlDbType.Int);
                    cmd.Parameters["@NumeroPublicaciones"].Value = usoPaginaWebInstitucionalDTO.NumeroPublicaciones;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.Date);
                    cmd.Parameters["@FechaPublicacion"].Value = usoPaginaWebInstitucionalDTO.FechaPublicacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = usoPaginaWebInstitucionalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoPaginaWebInstitucionalDTO.UsuarioIngresoRegistro;

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

        public UsoPaginaWebInstitucionalDTO BuscarFormato(int Codigo)
        {
            UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO = new UsoPaginaWebInstitucionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoPaginaWebInstitucionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoPaginaWebInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@UsoPaginaWebInstitucionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        usoPaginaWebInstitucionalDTO.UsoPaginaWebInstitucionalId = Convert.ToInt32(dr["UsoPaginaWebInstitucionalId"]);
                        usoPaginaWebInstitucionalDTO.CodigoTipoInformacion = dr["CodigoTipoInformacion"].ToString();
                        usoPaginaWebInstitucionalDTO.NumeroPublicaciones = Convert.ToInt32(dr["NumeroPublicaciones"]);
                        usoPaginaWebInstitucionalDTO.FechaPublicacion = Convert.ToDateTime(dr["FechaPublicacion"]).ToString("yyy-MM-dd");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return usoPaginaWebInstitucionalDTO;
        }

        public string ActualizaFormato(UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_UsoPaginaWebInstitucionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UsoPaginaWebInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@UsoPaginaWebInstitucionalId"].Value = usoPaginaWebInstitucionalDTO.UsoPaginaWebInstitucionalId;

                    cmd.Parameters.Add("@CodigoTipoInformacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInformacion "].Value = usoPaginaWebInstitucionalDTO.CodigoTipoInformacion;

                    cmd.Parameters.Add("@NumeroPublicaciones", SqlDbType.Int);
                    cmd.Parameters["@NumeroPublicaciones"].Value = usoPaginaWebInstitucionalDTO.NumeroPublicaciones;

                    cmd.Parameters.Add("@FechaPublicacion", SqlDbType.Date);
                    cmd.Parameters["@FechaPublicacion"].Value = usoPaginaWebInstitucionalDTO.FechaPublicacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoPaginaWebInstitucionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoPaginaWebInstitucionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoPaginaWebInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@UsoPaginaWebInstitucionalId"].Value = usoPaginaWebInstitucionalDTO.UsoPaginaWebInstitucionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoPaginaWebInstitucionalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_UsoPaginaWebInstitucionalMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoPaginaWebInstitucional", SqlDbType.Structured);
                    cmd.Parameters["@UsoPaginaWebInstitucional"].TypeName = "Formato.UsoPaginaWebInstitucional";
                    cmd.Parameters["@UsoPaginaWebInstitucional"].Value = datos;

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