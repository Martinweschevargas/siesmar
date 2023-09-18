using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Disamar
{
    public class RegistroPersonalSaludEstablecimientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroPersonalSaludEstablecimientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RegistroPersonalSaludEstablecimientoDTO> lista = new List<RegistroPersonalSaludEstablecimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroPersonalSaludEstablecimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroPersonalSaludEstablecimientoDTO()
                        {
                            RegistroPersonalSaludEstablecimientoId = Convert.ToInt32(dr["RegistroPersonalSaludEstablecimientoId"]),
                            ApellidosNombresPersonalMedico = dr["ApellidosNombresPersonalMedico"].ToString(),
                            CIPPersonalMedico = dr["CIPPersonalMedico"].ToString(),
                            DNIPersonalMedico = dr["DNIPersonalMedico"].ToString(),
                            TipoPersonal = dr["TipoPersonal"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            NombreColegioProfesional = dr["NombreColegioProfesional"].ToString(),
                            NumeroColegiatura = dr["NumeroColegiatura"].ToString(),
                            Especialidad = dr["Especialidad"].ToString(),
                            DescEstablecimientoSalud = dr["DescEstablecimientoSalud"].ToString(),
                            DescCondicionLaboral = dr["DescCondicionLaboral"].ToString(),
                            TipoLaborRealizar = dr["TipoLaborRealizar"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroPersonalSaludEstablecimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApellidosNombresPersonalMedico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ApellidosNombresPersonalMedico"].Value = registroPersonalSaludEstablecimientoDTO.ApellidosNombresPersonalMedico;

                    cmd.Parameters.Add("@CIPPersonalMedico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CIPPersonalMedico"].Value = registroPersonalSaludEstablecimientoDTO.CIPPersonalMedico;

                    cmd.Parameters.Add("@DNIPersonalMedico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DNIPersonalMedico"].Value = registroPersonalSaludEstablecimientoDTO.DNIPersonalMedico;

                    cmd.Parameters.Add("@TipoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoPersonal"].Value = registroPersonalSaludEstablecimientoDTO.TipoPersonal;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroPersonalSaludEstablecimientoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NombreColegioProfesional", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreColegioProfesional"].Value = registroPersonalSaludEstablecimientoDTO.NombreColegioProfesional;

                    cmd.Parameters.Add("@NumeroColegiatura", SqlDbType.VarChar, 10);
                    cmd.Parameters["@NumeroColegiatura"].Value = registroPersonalSaludEstablecimientoDTO.NumeroColegiatura;

                    cmd.Parameters.Add("@Especialidad", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Especialidad"].Value = registroPersonalSaludEstablecimientoDTO.Especialidad;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroPersonalSaludEstablecimientoDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@CodigoCondicionLaboral", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCondicionLaboral"].Value = registroPersonalSaludEstablecimientoDTO.CodigoCondicionLaboral;

                    cmd.Parameters.Add("@TipoLaborRealizar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoLaborRealizar"].Value = registroPersonalSaludEstablecimientoDTO.TipoLaborRealizar;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroPersonalSaludEstablecimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public RegistroPersonalSaludEstablecimientoDTO BuscarFormato(int Codigo)
        {
            RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO = new RegistroPersonalSaludEstablecimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroPersonalSaludEstablecimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroPersonalSaludEstablecimientoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroPersonalSaludEstablecimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        registroPersonalSaludEstablecimientoDTO.RegistroPersonalSaludEstablecimientoId = Convert.ToInt32(dr["RegistroPersonalSaludEstablecimientoId"]);
                        registroPersonalSaludEstablecimientoDTO.ApellidosNombresPersonalMedico = dr["ApellidosNombresPersonalMedico"].ToString();
                        registroPersonalSaludEstablecimientoDTO.CIPPersonalMedico = dr["CIPPersonalMedico"].ToString();
                        registroPersonalSaludEstablecimientoDTO.DNIPersonalMedico = dr["DNIPersonalMedico"].ToString();
                        registroPersonalSaludEstablecimientoDTO.TipoPersonal = dr["TipoPersonal"].ToString();
                        registroPersonalSaludEstablecimientoDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        registroPersonalSaludEstablecimientoDTO.NombreColegioProfesional = dr["NombreColegioProfesional"].ToString();
                        registroPersonalSaludEstablecimientoDTO.NumeroColegiatura = dr["NumeroColegiatura"].ToString();
                        registroPersonalSaludEstablecimientoDTO.Especialidad = dr["Especialidad"].ToString();
                        registroPersonalSaludEstablecimientoDTO.CodigoEstablecimientoSaludMGP = dr["CodigoEstablecimientoSaludMGP"].ToString();
                        registroPersonalSaludEstablecimientoDTO.CodigoCondicionLaboral = dr["CodigoCondicionLaboral"].ToString();
                        registroPersonalSaludEstablecimientoDTO.TipoLaborRealizar = dr["TipoLaborRealizar"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroPersonalSaludEstablecimientoDTO;
        }

        public string ActualizaFormato(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroPersonalSaludEstablecimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroPersonalSaludEstablecimientoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroPersonalSaludEstablecimientoId"].Value = registroPersonalSaludEstablecimientoDTO.RegistroPersonalSaludEstablecimientoId;

                    cmd.Parameters.Add("@ApellidosNombresPersonalMedico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ApellidosNombresPersonalMedico"].Value = registroPersonalSaludEstablecimientoDTO.ApellidosNombresPersonalMedico;

                    cmd.Parameters.Add("@CIPPersonalMedico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CIPPersonalMedico"].Value = registroPersonalSaludEstablecimientoDTO.CIPPersonalMedico;

                    cmd.Parameters.Add("@DNIPersonalMedico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DNIPersonalMedico"].Value = registroPersonalSaludEstablecimientoDTO.DNIPersonalMedico;

                    cmd.Parameters.Add("@TipoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoPersonal"].Value = registroPersonalSaludEstablecimientoDTO.TipoPersonal;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroPersonalSaludEstablecimientoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NombreColegioProfesional", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreColegioProfesional"].Value = registroPersonalSaludEstablecimientoDTO.NombreColegioProfesional;

                    cmd.Parameters.Add("@NumeroColegiatura", SqlDbType.VarChar, 10);
                    cmd.Parameters["@NumeroColegiatura"].Value = registroPersonalSaludEstablecimientoDTO.NumeroColegiatura;

                    cmd.Parameters.Add("@Especialidad", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Especialidad"].Value = registroPersonalSaludEstablecimientoDTO.Especialidad;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroPersonalSaludEstablecimientoDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@CodigoCondicionLaboral", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCondicionLaboral"].Value = registroPersonalSaludEstablecimientoDTO.CodigoCondicionLaboral;

                    cmd.Parameters.Add("@TipoLaborRealizar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoLaborRealizar"].Value = registroPersonalSaludEstablecimientoDTO.TipoLaborRealizar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroPersonalSaludEstablecimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroPersonalSaludEstablecimientoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroPersonalSaludEstablecimientoId"].Value = registroPersonalSaludEstablecimientoDTO.RegistroPersonalSaludEstablecimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "RegistroPersonalSaludEstablecimiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroPersonalSaludEstablecimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_RegistroPersonalSaludEstablecimientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroPersonalSaludEstablecimiento", SqlDbType.Structured);
                    cmd.Parameters["@RegistroPersonalSaludEstablecimiento"].TypeName = "Formato.RegistroPersonalSaludEstablecimiento";
                    cmd.Parameters["@RegistroPersonalSaludEstablecimiento"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
