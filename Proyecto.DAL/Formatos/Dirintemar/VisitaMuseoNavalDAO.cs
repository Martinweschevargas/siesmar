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
    public class VisitaMuseoNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<VisitaMuseoNavalDTO> ObtenerLista()
        {
            List<VisitaMuseoNavalDTO> lista = new List<VisitaMuseoNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_VisitaMuseoNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VisitaMuseoNavalDTO()
                        {
                            VisitaMuseoNavalId = Convert.ToInt32(dr["VisitaMuseoNavalId"]),
                            DescMuseoNaval = dr["DescMuseoNaval"].ToString(),
                            PeriodoVisitaMuseoNaval = dr["PeriodoVisitaMuseoNaval"].ToString(),
                            QNinos = Convert.ToInt32(dr["QNinos"]),
                            QAdultos = Convert.ToInt32(dr["QAdultos"]),
                            QEstudianteEscolar = Convert.ToInt32(dr["QEstudianteEscolar"]),
                            QEstudianteUniversitario = Convert.ToInt32(dr["QEstudianteUniversitario"]),
                            QDocente = Convert.ToInt32(dr["QDocente"]),
                            QMilitar = Convert.ToInt32(dr["QMilitar"]),
                            QFamiliaNavalAdulto = Convert.ToInt32(dr["QFamiliaNavalAdulto"]),
                            QFamiliaNavalNino = Convert.ToInt32(dr["QFamiliaNavalNino"]),
                            QPersonaDiscapacitada = Convert.ToInt32(dr["QPersonaDiscapacitada"]),
                            QAdultosCivilMayor65 = Convert.ToInt32(dr["QAdultosCivilMayor65"]),
                            QExtranjera = Convert.ToInt32(dr["QExtranjera"]),
                            QOtroExtranjero = Convert.ToInt32(dr["QOtroExtranjero"]),
                            QNochesLima = Convert.ToInt32(dr["QNochesLima"]),
                            TotalQVisita = Convert.ToInt32(dr["TotalQVisita"]),
                            RacaudacionTotal = Convert.ToInt32(dr["RacaudacionTotal"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(VisitaMuseoNavalDTO visitaMuseoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VisitaMuseoNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@MuseoNavalId"].Value = visitaMuseoNavalDTO.MuseoNavalId;

                    cmd.Parameters.Add("@PeriodoVisitaMuseoNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@PeriodoVisitaMuseoNaval"].Value = visitaMuseoNavalDTO.PeriodoVisitaMuseoNaval;

                    cmd.Parameters.Add("@QNinos", SqlDbType.Int);
                    cmd.Parameters["@QNinos"].Value = visitaMuseoNavalDTO.QNinos;

                    cmd.Parameters.Add("@QAdultos", SqlDbType.Int);
                    cmd.Parameters["@QAdultos"].Value = visitaMuseoNavalDTO.QAdultos;

                    cmd.Parameters.Add("@QEstudianteEscolar", SqlDbType.Int);
                    cmd.Parameters["@QEstudianteEscolar"].Value = visitaMuseoNavalDTO.QEstudianteEscolar;

                    cmd.Parameters.Add("@QEstudianteUniversitario", SqlDbType.Int);
                    cmd.Parameters["@QEstudianteUniversitario"].Value = visitaMuseoNavalDTO.QEstudianteUniversitario;

                    cmd.Parameters.Add("@QDocente", SqlDbType.Int);
                    cmd.Parameters["@QDocente"].Value = visitaMuseoNavalDTO.QDocente;

                    cmd.Parameters.Add("@QMilitar", SqlDbType.Int);
                    cmd.Parameters["@QMilitar"].Value = visitaMuseoNavalDTO.QMilitar;

                    cmd.Parameters.Add("@QFamiliaNavalAdulto", SqlDbType.Int);
                    cmd.Parameters["@QFamiliaNavalAdulto"].Value = visitaMuseoNavalDTO.QFamiliaNavalAdulto;

                    cmd.Parameters.Add("@QFamiliaNavalNino", SqlDbType.Int);
                    cmd.Parameters["@QFamiliaNavalNino"].Value = visitaMuseoNavalDTO.QFamiliaNavalNino;

                    cmd.Parameters.Add("@QPersonaDiscapacitada", SqlDbType.Int);
                    cmd.Parameters["@QPersonaDiscapacitada"].Value = visitaMuseoNavalDTO.QPersonaDiscapacitada;

                    cmd.Parameters.Add("@QAdultosCivilMayor65", SqlDbType.Int);
                    cmd.Parameters["@QAdultosCivilMayor65"].Value = visitaMuseoNavalDTO.QAdultosCivilMayor65;

                    cmd.Parameters.Add("@QExtranjera", SqlDbType.Int);
                    cmd.Parameters["@QExtranjera"].Value = visitaMuseoNavalDTO.QExtranjera;

                    cmd.Parameters.Add("@QOtroExtranjero", SqlDbType.Int);
                    cmd.Parameters["@QOtroExtranjero"].Value = visitaMuseoNavalDTO.QOtroExtranjero;

                    cmd.Parameters.Add("@QNochesLima", SqlDbType.Int);
                    cmd.Parameters["@QNochesLima"].Value = visitaMuseoNavalDTO.QNochesLima;

                    cmd.Parameters.Add("@TotalQVisita", SqlDbType.Int);
                    cmd.Parameters["@TotalQVisita"].Value = visitaMuseoNavalDTO.TotalQVisita;

                    cmd.Parameters.Add("@RacaudacionTotal", SqlDbType.Int);
                    cmd.Parameters["@RacaudacionTotal"].Value = visitaMuseoNavalDTO.RacaudacionTotal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaMuseoNavalDTO.UsuarioIngresoRegistro;

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

        public VisitaMuseoNavalDTO BuscarFormato(int Codigo)
        {
            VisitaMuseoNavalDTO visitaMuseoNavalDTO = new VisitaMuseoNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaMuseoNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaMuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@VisitaMuseoNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        visitaMuseoNavalDTO.VisitaMuseoNavalId = Convert.ToInt32(dr["VisitaMuseoNavalId"]);
                        visitaMuseoNavalDTO.MuseoNavalId = Convert.ToInt32(dr["MuseoNavalId"]);
                        visitaMuseoNavalDTO.PeriodoVisitaMuseoNaval = dr["PeriodoVisitaMuseoNaval"].ToString();
                        visitaMuseoNavalDTO.QNinos = Convert.ToInt32(dr["QNinos"]);
                        visitaMuseoNavalDTO.QAdultos = Convert.ToInt32(dr["QAdultos"]);
                        visitaMuseoNavalDTO.QEstudianteEscolar = Convert.ToInt32(dr["QEstudianteEscolar"]);
                        visitaMuseoNavalDTO.QEstudianteUniversitario = Convert.ToInt32(dr["QEstudianteUniversitario"]);
                        visitaMuseoNavalDTO.QDocente = Convert.ToInt32(dr["QDocente"]);
                        visitaMuseoNavalDTO.QMilitar = Convert.ToInt32(dr["QMilitar"]);
                        visitaMuseoNavalDTO.QFamiliaNavalAdulto = Convert.ToInt32(dr["QFamiliaNavalAdulto"]);
                        visitaMuseoNavalDTO.QFamiliaNavalNino = Convert.ToInt32(dr["QFamiliaNavalNino"]);
                        visitaMuseoNavalDTO.QPersonaDiscapacitada = Convert.ToInt32(dr["QPersonaDiscapacitada"]);
                        visitaMuseoNavalDTO.QAdultosCivilMayor65 = Convert.ToInt32(dr["QAdultosCivilMayor65"]);
                        visitaMuseoNavalDTO.QExtranjera = Convert.ToInt32(dr["QExtranjera"]);
                        visitaMuseoNavalDTO.QOtroExtranjero = Convert.ToInt32(dr["QOtroExtranjero"]);
                        visitaMuseoNavalDTO.QNochesLima = Convert.ToInt32(dr["QNochesLima"]);
                        visitaMuseoNavalDTO.TotalQVisita = Convert.ToInt32(dr["TotalQVisita"]);
                        visitaMuseoNavalDTO.RacaudacionTotal = Convert.ToInt32(dr["RacaudacionTotal"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return visitaMuseoNavalDTO;
        }

        public string ActualizaFormato(VisitaMuseoNavalDTO visitaMuseoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VisitaMuseoNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaMuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@VisitaMuseoNavalId"].Value = visitaMuseoNavalDTO.VisitaMuseoNavalId;

                    cmd.Parameters.Add("@MuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@MuseoNavalId"].Value = visitaMuseoNavalDTO.MuseoNavalId;

                    cmd.Parameters.Add("@PeriodoVisitaMuseoNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@PeriodoVisitaMuseoNaval"].Value = visitaMuseoNavalDTO.PeriodoVisitaMuseoNaval;

                    cmd.Parameters.Add("@QNinos", SqlDbType.Int);
                    cmd.Parameters["@QNinos"].Value = visitaMuseoNavalDTO.QNinos;

                    cmd.Parameters.Add("@QAdulto", SqlDbType.Int);
                    cmd.Parameters["@QAdulto"].Value = visitaMuseoNavalDTO.QAdultos;

                    cmd.Parameters.Add("@QEstudianteEscolar", SqlDbType.Int);
                    cmd.Parameters["@QEstudianteEscolar"].Value = visitaMuseoNavalDTO.QEstudianteEscolar;

                    cmd.Parameters.Add("@QEstudianteUniversitario", SqlDbType.Int);
                    cmd.Parameters["@QEstudianteUniversitario"].Value = visitaMuseoNavalDTO.QEstudianteUniversitario;

                    cmd.Parameters.Add("@QDocente", SqlDbType.Int);
                    cmd.Parameters["@QDocente"].Value = visitaMuseoNavalDTO.QDocente;

                    cmd.Parameters.Add("@QMilitar", SqlDbType.Int);
                    cmd.Parameters["@QMilitar"].Value = visitaMuseoNavalDTO.QMilitar;

                    cmd.Parameters.Add("@QFamiliaNavalAdulto", SqlDbType.Int);
                    cmd.Parameters["@QFamiliaNavalAdulto"].Value = visitaMuseoNavalDTO.QFamiliaNavalAdulto;

                    cmd.Parameters.Add("@QFamiliaNavalNino", SqlDbType.Int);
                    cmd.Parameters["@QFamiliaNavalNino"].Value = visitaMuseoNavalDTO.QFamiliaNavalNino;

                    cmd.Parameters.Add("@QPersonaDiscapacitada", SqlDbType.Int);
                    cmd.Parameters["@QPersonaDiscapacitada"].Value = visitaMuseoNavalDTO.QPersonaDiscapacitada;

                    cmd.Parameters.Add("@QAdultosCivilMayor65", SqlDbType.Int);
                    cmd.Parameters["@QAdultosCivilMayor65"].Value = visitaMuseoNavalDTO.QAdultosCivilMayor65;

                    cmd.Parameters.Add("@QExtranjera", SqlDbType.Int);
                    cmd.Parameters["@QExtranjera"].Value = visitaMuseoNavalDTO.QExtranjera;

                    cmd.Parameters.Add("@QOtroExtranjero", SqlDbType.Int);
                    cmd.Parameters["@QOtroExtranjero"].Value = visitaMuseoNavalDTO.QOtroExtranjero;

                    cmd.Parameters.Add("@QNochesLima", SqlDbType.Int);
                    cmd.Parameters["@QNochesLima"].Value = visitaMuseoNavalDTO.QNochesLima;

                    cmd.Parameters.Add("@TotalQVisita", SqlDbType.Int);
                    cmd.Parameters["@TotalQVisita"].Value = visitaMuseoNavalDTO.TotalQVisita;

                    cmd.Parameters.Add("@RacaudacionTotal", SqlDbType.Int);
                    cmd.Parameters["@RacaudacionTotal"].Value = visitaMuseoNavalDTO.RacaudacionTotal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaMuseoNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(VisitaMuseoNavalDTO visitaMuseoNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VisitaMuseoNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaMuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@VisitaMuseoNavalId"].Value = visitaMuseoNavalDTO.VisitaMuseoNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = visitaMuseoNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_VisitaMuseoNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VisitaMuseoNaval", SqlDbType.Structured);
                    cmd.Parameters["@VisitaMuseoNaval"].TypeName = "Formato.VisitaMuseoNaval";
                    cmd.Parameters["@VisitaMuseoNaval"].Value = datos;

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
