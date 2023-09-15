using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TiempoServicioExperienciaDAO
    {

        SqlCommand cmd = new();

        public List<TiempoServicioExperienciaDTO> ObtenerTiempoServicioExperiencias()
        {
            List<TiempoServicioExperienciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TiempoServicioExperienciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TiempoServicioExperienciaDTO()
                        {
                            TiempoServicioExperienciaId = Convert.ToInt32(dr["TiempoServicioExperienciaId"]),
                            BAPAmazonas = Convert.ToChar(dr["BAPAmazonas"]),
                            BAPLoreto = Convert.ToChar(dr["BAPLoreto"]),
                            BAPMaranon = Convert.ToChar(dr["BAPMaranon"]),
                            BAPUcayali = Convert.ToChar(dr["BAPUcayali"]),
                            BAPClavero = Convert.ToChar(dr["BAPClavero"]),
                            BAPCastillo = Convert.ToChar(dr["BAPCastillo"]),
                            BAPMorona = Convert.ToChar(dr["BAPMorona"]),
                            BAPCorrientes = Convert.ToChar(dr["BAPCorrientes"]),
                            BAPPastaza = Convert.ToChar(dr["BAPPastaza"]),
                            Personal = Convert.ToChar(dr["Personal"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTiempoServicioExperiencia(TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TiempoServicioExperienciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BAPAmazonas", SqlDbType.Char);
                    cmd.Parameters["@BAPAmazonas"].Value = tiempoServicioExperienciaDTO.BAPAmazonas;

                    cmd.Parameters.Add("@BAPLoreto", SqlDbType.Char);
                    cmd.Parameters["@BAPLoreto"].Value = tiempoServicioExperienciaDTO.BAPLoreto;

                    cmd.Parameters.Add("@BAPMaranon", SqlDbType.Char);
                    cmd.Parameters["@BAPMaranon"].Value = tiempoServicioExperienciaDTO.BAPMaranon;

                    cmd.Parameters.Add("@BAPUcayali", SqlDbType.Char);
                    cmd.Parameters["@BAPUcayali"].Value = tiempoServicioExperienciaDTO.BAPUcayali;

                    cmd.Parameters.Add("@BAPClavero", SqlDbType.Char);
                    cmd.Parameters["@BAPClavero"].Value = tiempoServicioExperienciaDTO.BAPClavero;

                    cmd.Parameters.Add("@BAPCastillo", SqlDbType.Char);
                    cmd.Parameters["@BAPCastillo"].Value = tiempoServicioExperienciaDTO.BAPCastillo;

                    cmd.Parameters.Add("@BAPMorona", SqlDbType.Char);
                    cmd.Parameters["@BAPMorona"].Value = tiempoServicioExperienciaDTO.BAPMorona;

                    cmd.Parameters.Add("@BAPCorrientes", SqlDbType.Char);
                    cmd.Parameters["@BAPCorrientes"].Value = tiempoServicioExperienciaDTO.BAPCorrientes;

                    cmd.Parameters.Add("@BAPPastaza", SqlDbType.Char);
                    cmd.Parameters["@BAPPastaza"].Value = tiempoServicioExperienciaDTO.BAPPastaza;

                    cmd.Parameters.Add("@Personal", SqlDbType.Char);
                    cmd.Parameters["@Personal"].Value = tiempoServicioExperienciaDTO.Personal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tiempoServicioExperienciaDTO.UsuarioIngresoRegistro;

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

        public TiempoServicioExperienciaDTO BuscarTiempoServicioExperienciaID(int Codigo)
        {
            TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO = new TiempoServicioExperienciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TiempoServicioExperienciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TiempoServicioExperienciaId", SqlDbType.Int);
                    cmd.Parameters["@TiempoServicioExperienciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tiempoServicioExperienciaDTO.TiempoServicioExperienciaId = Convert.ToInt32(dr["TiempoServicioExperienciaId"]);
                        tiempoServicioExperienciaDTO.BAPAmazonas = Convert.ToChar(dr["BAPAmazonas"]);
                        tiempoServicioExperienciaDTO.BAPLoreto = Convert.ToChar(dr["BAPLoreto"]);
                        tiempoServicioExperienciaDTO.BAPMaranon = Convert.ToChar(dr["BAPMaranon"]);
                        tiempoServicioExperienciaDTO.BAPUcayali = Convert.ToChar(dr["BAPUcayali"]);
                        tiempoServicioExperienciaDTO.BAPClavero = Convert.ToChar(dr["BAPClavero"]);
                        tiempoServicioExperienciaDTO.BAPCastillo = Convert.ToChar(dr["BAPCastillo"]);
                        tiempoServicioExperienciaDTO.BAPMorona = Convert.ToChar(dr["BAPMorona"]);
                        tiempoServicioExperienciaDTO.BAPCorrientes = Convert.ToChar(dr["BAPCorrientes"]);
                        tiempoServicioExperienciaDTO.BAPPastaza = Convert.ToChar(dr["BAPPastaza"]);
                        tiempoServicioExperienciaDTO.Personal = Convert.ToChar(dr["Personal"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tiempoServicioExperienciaDTO;
        }

        public string ActualizarTiempoServicioExperiencia(TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TiempoServicioExperienciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TiempoServicioExperienciaId", SqlDbType.Int);
                    cmd.Parameters["@TiempoServicioExperienciaId"].Value = tiempoServicioExperienciaDTO.TiempoServicioExperienciaId;


                    cmd.Parameters.Add("@BAPAmazonas", SqlDbType.Char);
                    cmd.Parameters["@BAPAmazonas"].Value = tiempoServicioExperienciaDTO.BAPAmazonas;

                    cmd.Parameters.Add("@BAPLoreto", SqlDbType.Char);
                    cmd.Parameters["@BAPLoreto"].Value = tiempoServicioExperienciaDTO.BAPLoreto;

                    cmd.Parameters.Add("@BAPMaranon", SqlDbType.Char);
                    cmd.Parameters["@BAPMaranon"].Value = tiempoServicioExperienciaDTO.BAPMaranon;

                    cmd.Parameters.Add("@BAPUcayali", SqlDbType.Char);
                    cmd.Parameters["@BAPUcayali"].Value = tiempoServicioExperienciaDTO.BAPUcayali;

                    cmd.Parameters.Add("@BAPClavero", SqlDbType.Char);
                    cmd.Parameters["@BAPClavero"].Value = tiempoServicioExperienciaDTO.BAPClavero;

                    cmd.Parameters.Add("@BAPCastillo", SqlDbType.Char);
                    cmd.Parameters["@BAPCastillo"].Value = tiempoServicioExperienciaDTO.BAPCastillo;

                    cmd.Parameters.Add("@BAPMorona", SqlDbType.Char);
                    cmd.Parameters["@BAPMorona"].Value = tiempoServicioExperienciaDTO.BAPMorona;

                    cmd.Parameters.Add("@BAPCorrientes", SqlDbType.Char);
                    cmd.Parameters["@BAPCorrientes"].Value = tiempoServicioExperienciaDTO.BAPCorrientes;

                    cmd.Parameters.Add("@BAPPastaza", SqlDbType.Char);
                    cmd.Parameters["@BAPPastaza"].Value = tiempoServicioExperienciaDTO.BAPPastaza;

                    cmd.Parameters.Add("@Personal", SqlDbType.Char);
                    cmd.Parameters["@Personal"].Value = tiempoServicioExperienciaDTO.Personal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tiempoServicioExperienciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTiempoServicioExperiencia(TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TiempoServicioExperienciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TiempoServicioExperienciaId", SqlDbType.Int);
                    cmd.Parameters["@TiempoServicioExperienciaId"].Value = tiempoServicioExperienciaDTO.TiempoServicioExperienciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tiempoServicioExperienciaDTO.UsuarioIngresoRegistro;

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
