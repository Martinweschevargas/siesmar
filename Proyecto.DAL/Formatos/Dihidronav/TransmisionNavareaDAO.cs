using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class TransmisionNavareaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<TransmisionNavareaDTO> ObtenerLista(int? CargaId=null)
        {
            List<TransmisionNavareaDTO> lista = new List<TransmisionNavareaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_TransmisionNavareaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TransmisionNavareaDTO()
                        {
                            TransmisionNavareaId = Convert.ToInt32(dr["TransmisionNavareaId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            NumeroNavarea = dr["NumeroNavarea"].ToString(),
                            RadioavisoNautico = dr["RadioavisoNautico"].ToString(),
                            FechaEmision = (dr["FechaEmision"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Promotor = dr["Promotor"].ToString(),
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(TransmisionNavareaDTO transmisionNavareaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TransmisionNavareaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = transmisionNavareaDTO.NumeroOrden;

                    cmd.Parameters.Add("@NumeroNavarea", SqlDbType.VarChar,10);
                    cmd.Parameters["@NumeroNavarea"].Value = transmisionNavareaDTO.NumeroNavarea;

                    cmd.Parameters.Add("@RadioavisoNautico", SqlDbType.VarChar,50);
                    cmd.Parameters["@RadioavisoNautico"].Value = transmisionNavareaDTO.RadioavisoNautico;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = transmisionNavareaDTO.FechaEmision;

                    cmd.Parameters.Add("@Promotor", SqlDbType.VarChar,50);
                    cmd.Parameters["@Promotor"].Value = transmisionNavareaDTO.Promotor;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = transmisionNavareaDTO.FechaTermino;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = transmisionNavareaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = transmisionNavareaDTO.UsuarioIngresoRegistro;

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

        public TransmisionNavareaDTO BuscarFormato(int Codigo)
        {
            TransmisionNavareaDTO transmisionNavareaDTO = new TransmisionNavareaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TransmisionNavareaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransmisionNavareaId", SqlDbType.Int);
                    cmd.Parameters["@TransmisionNavareaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        transmisionNavareaDTO.TransmisionNavareaId = Convert.ToInt32(dr["TransmisionNavareaId"]);
                        transmisionNavareaDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        transmisionNavareaDTO.NumeroNavarea = dr["NumeroNavarea"].ToString();
                        transmisionNavareaDTO.RadioavisoNautico = dr["RadioavisoNautico"].ToString();
                        transmisionNavareaDTO.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]).ToString("yyy-MM-dd");
                        transmisionNavareaDTO.Promotor = dr["Promotor"].ToString();
                        transmisionNavareaDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd"); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return transmisionNavareaDTO;
        }

        public string ActualizaFormato(TransmisionNavareaDTO transmisionNavareaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_TransmisionNavareaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@TransmisionNavareaId", SqlDbType.Int);
                    cmd.Parameters["@TransmisionNavareaId"].Value = transmisionNavareaDTO.TransmisionNavareaId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = transmisionNavareaDTO.NumeroOrden;

                    cmd.Parameters.Add("@NumeroNavarea", SqlDbType.VarChar,10);
                    cmd.Parameters["@NumeroNavarea"].Value = transmisionNavareaDTO.NumeroNavarea;

                    cmd.Parameters.Add("@RadioavisoNautico", SqlDbType.VarChar,50);
                    cmd.Parameters["@RadioavisoNautico"].Value = transmisionNavareaDTO.RadioavisoNautico;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = transmisionNavareaDTO.FechaEmision;

                    cmd.Parameters.Add("@Promotor", SqlDbType.VarChar,50);
                    cmd.Parameters["@Promotor"].Value = transmisionNavareaDTO.Promotor;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = transmisionNavareaDTO.FechaTermino;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = transmisionNavareaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(TransmisionNavareaDTO transmisionNavareaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_TransmisionNavareaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransmisionNavareaId", SqlDbType.Int);
                    cmd.Parameters["@TransmisionNavareaId"].Value = transmisionNavareaDTO.TransmisionNavareaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = transmisionNavareaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_TransmisionNavareaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransmisionNavarea", SqlDbType.Structured);
                    cmd.Parameters["@TransmisionNavarea"].TypeName = "Formato.TransmisionNavarea";
                    cmd.Parameters["@TransmisionNavarea"].Value = datos;

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
