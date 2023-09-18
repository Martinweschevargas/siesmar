using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dipermar
{
    public class InvestigacionDisciplinariaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InvestigacionDisciplinariaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<InvestigacionDisciplinariaDTO> lista = new List<InvestigacionDisciplinariaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InvestigacionDisciplinariaListar", conexion);
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
                        lista.Add(new InvestigacionDisciplinariaDTO()
                        {
                            InvestigacionDisciplinariaId = Convert.ToInt32(dr["InvestigacionDisciplinariaId"]),
                            FechaInicioInvestigacion = (dr["FechaInicioInvestigacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGrado = dr["DescGrado"].ToString(),
                            SexoPersonal = dr["SexoPersonal"].ToString(),
                            DescInfraccionDisciplinariaGenerica = dr["DescInfraccionDisciplinariaGenerica"].ToString(),
                            DescInfraccionDisciplinariaEspecifica = dr["DescInfraccionDisciplinariaEspecifica"].ToString(),
                            NivelInfraccion = dr["NivelInfraccion"].ToString(),
                            DescGradoPresidenteJunta = dr["DescGradoPresidenteJunta"].ToString(),
                            NombrePresidenteJunta = dr["NombrePresidenteJunta"].ToString(),
                            ConclusionFinal = dr["ConclusionFinal"].ToString(),
                            ConclusionFinalDescripcion = dr["ConclusionFinalDescripcion"].ToString(),
                            DescSancionDisciplinariaNaval = dr["DescSancionDisciplinariaNaval"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InvestigacionDisciplinariaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = investigacionDisciplinariaDTO.FechaInicioInvestigacion;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = investigacionDisciplinariaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPersonal"].Value = investigacionDisciplinariaDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaGenerica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaGenerica"].Value = investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaGenerica;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaEspecifica"].Value = investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaEspecifica;

                    cmd.Parameters.Add("@NivelInfraccion", SqlDbType.VarChar,50);
                    cmd.Parameters["@NivelInfraccion"].Value = investigacionDisciplinariaDTO.NivelInfraccion;

                    cmd.Parameters.Add("@CodigoGradoPresidenteJunta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPresidenteJunta"].Value = investigacionDisciplinariaDTO.CodigoGradoPresidenteJunta;

                    cmd.Parameters.Add("@NombrePresidenteJunta", SqlDbType.VarChar,260);
                    cmd.Parameters["@NombrePresidenteJunta"].Value = investigacionDisciplinariaDTO.NombrePresidenteJunta;

                    cmd.Parameters.Add("@ConclusionFinal", SqlDbType.VarChar,10);
                    cmd.Parameters["@ConclusionFinal"].Value = investigacionDisciplinariaDTO.ConclusionFinal;

                    cmd.Parameters.Add("@ConclusionFinalDescripcion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@ConclusionFinalDescripcion"].Value = investigacionDisciplinariaDTO.ConclusionFinalDescripcion;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSancionDisciplinariaNaval"].Value = investigacionDisciplinariaDTO.CodigoSancionDisciplinariaNaval;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = investigacionDisciplinariaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionDisciplinariaDTO.UsuarioIngresoRegistro;

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

        public InvestigacionDisciplinariaDTO BuscarFormato(int Codigo)
        {
            InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO = new InvestigacionDisciplinariaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InvestigacionDisciplinariaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionDisciplinariaId", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionDisciplinariaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        investigacionDisciplinariaDTO.InvestigacionDisciplinariaId = Convert.ToInt32(dr["InvestigacionDisciplinariaId"]);
                        investigacionDisciplinariaDTO.FechaInicioInvestigacion = Convert.ToDateTime(dr["FechaInicioInvestigacion"]).ToString("yyy-MM-dd");
                        investigacionDisciplinariaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString(); 
                        investigacionDisciplinariaDTO.SexoPersonal = dr["SexoPersonal"].ToString(); 
                        investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaGenerica = dr["CodigoInfraccionDisciplinariaGenerica"].ToString();
                        investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaEspecifica = dr["CodigoInfraccionDisciplinariaEspecifica"].ToString();
                        investigacionDisciplinariaDTO.NivelInfraccion = dr["NivelInfraccion"].ToString();
                        investigacionDisciplinariaDTO.CodigoGradoPresidenteJunta = dr["CodigoGradoPresidenteJunta"].ToString();
                        investigacionDisciplinariaDTO.NombrePresidenteJunta = dr["NombrePresidenteJunta"].ToString();
                        investigacionDisciplinariaDTO.ConclusionFinal = dr["ConclusionFinal"].ToString();
                        investigacionDisciplinariaDTO.ConclusionFinalDescripcion = dr["ConclusionFinalDescripcion"].ToString();
                        investigacionDisciplinariaDTO.CodigoSancionDisciplinariaNaval = dr["CodigoSancionDisciplinariaNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return investigacionDisciplinariaDTO;
        }

        public string ActualizaFormato(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InvestigacionDisciplinariaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionDisciplinariaId", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionDisciplinariaId"].Value = investigacionDisciplinariaDTO.InvestigacionDisciplinariaId;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = investigacionDisciplinariaDTO.FechaInicioInvestigacion;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = investigacionDisciplinariaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonal"].Value = investigacionDisciplinariaDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaGenerica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaGenerica"].Value = investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaGenerica;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaEspecifica"].Value = investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaEspecifica;

                    cmd.Parameters.Add("@NivelInfraccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelInfraccion"].Value = investigacionDisciplinariaDTO.NivelInfraccion;

                    cmd.Parameters.Add("@CodigoGradoPresidenteJunta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPresidenteJunta"].Value = investigacionDisciplinariaDTO.CodigoGradoPresidenteJunta;

                    cmd.Parameters.Add("@NombrePresidenteJunta", SqlDbType.VarChar, 260);
                    cmd.Parameters["@NombrePresidenteJunta"].Value = investigacionDisciplinariaDTO.NombrePresidenteJunta;

                    cmd.Parameters.Add("@ConclusionFinal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ConclusionFinal"].Value = investigacionDisciplinariaDTO.ConclusionFinal;

                    cmd.Parameters.Add("@ConclusionFinalDescripcion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@ConclusionFinalDescripcion"].Value = investigacionDisciplinariaDTO.ConclusionFinalDescripcion;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSancionDisciplinariaNaval"].Value = investigacionDisciplinariaDTO.CodigoSancionDisciplinariaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionDisciplinariaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InvestigacionDisciplinariaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionDisciplinariaId", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionDisciplinariaId"].Value = investigacionDisciplinariaDTO.InvestigacionDisciplinariaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionDisciplinariaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO)
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
                    cmd.Parameters["@Formato"].Value = "InvestigacionDisciplinaria";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = investigacionDisciplinariaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionDisciplinariaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InvestigacionDisciplinariaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionDisciplinaria", SqlDbType.Structured);
                    cmd.Parameters["@InvestigacionDisciplinaria"].TypeName = "Formato.InvestigacionDisciplinaria";
                    cmd.Parameters["@InvestigacionDisciplinaria"].Value = datos;

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
