using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diperadmon
{
    public class PersonalSuperiorSubalternoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PersonalSuperiorSubalternoDTO> ObtenerLista(int? CargaId = null)
        {
            List<PersonalSuperiorSubalternoDTO> lista = new List<PersonalSuperiorSubalternoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PersonalSuperiorSubalternoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalSuperiorSubalternoDTO()
                        {
                            PersonalSuperiorSubalternoId = Convert.ToInt32(dr["PersonalSuperiorSubalternoId"]),
                            DNIPSupSub = dr["DNIPSupSub"].ToString(),
                            DescProcedencia = dr["DescProcedencia"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            Sexo = dr["Sexo"].ToString(),
                            DescDistritoNacimiento = dr["DescDistritoNacimiento"].ToString(),
                            FechaNacimientoPSupSub = (dr["FechaNacimientoPSupSub"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDistritoLabora = dr["DescDistritoLabora"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            FechaIngresoDepPSupSub = (dr["FechaIngresoDepPSupSub"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoCivilPSupSub = dr["EstadoCivilPSupSub"].ToString(),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            DescSistemaPension = dr["DescSistemaPension"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            FechaIngresoInstitucion = (dr["FechaIngresoInstitucion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaAltaPSupSub = (dr["FechaAltaPSupSub"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaUltimoAscensoPSupSub = (dr["FechaUltimoAscensoPSupSub"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(PersonalSuperiorSubalternoDTO personalSuperiorSubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalSuperiorSubalternoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPSupSub", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPSupSub"].Value = personalSuperiorSubDTO.DNIPSupSub;

                    cmd.Parameters.Add("@CodigoProcedencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProcedencia"].Value = personalSuperiorSubDTO.CodigoProcedencia;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = personalSuperiorSubDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar,10);
                    cmd.Parameters["@Sexo"].Value = personalSuperiorSubDTO.Sexo;

                    cmd.Parameters.Add("@UbigeoNacimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@UbigeoNacimiento"].Value = personalSuperiorSubDTO.UbigeoNacimiento;

                    cmd.Parameters.Add("@FechaNacimientoPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPSupSub"].Value = personalSuperiorSubDTO.FechaNacimientoPSupSub;

                    cmd.Parameters.Add("@UbigeoLabora", SqlDbType.VarChar,20);
                    cmd.Parameters["@UbigeoLabora"].Value = personalSuperiorSubDTO.UbigeoLabora;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = personalSuperiorSubDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaIngresoDepPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDepPSupSub"].Value = personalSuperiorSubDTO.FechaIngresoDepPSupSub;

                    cmd.Parameters.Add("@EstadoCivilPSupSub", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EstadoCivilPSupSub"].Value = personalSuperiorSubDTO.EstadoCivilPSupSub;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = personalSuperiorSubDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoSistemaPension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPension"].Value = personalSuperiorSubDTO.CodigoSistemaPension;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = personalSuperiorSubDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@FechaIngresoInstitucion", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInstitucion"].Value = personalSuperiorSubDTO.FechaIngresoInstitucion;

                    cmd.Parameters.Add("@FechaAltaPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaAltaPSupSub"].Value = personalSuperiorSubDTO.FechaAltaPSupSub;

                    cmd.Parameters.Add("@FechaUltimoAscensoPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoAscensoPSupSub"].Value = personalSuperiorSubDTO.FechaUltimoAscensoPSupSub;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalSuperiorSubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalSuperiorSubDTO.UsuarioIngresoRegistro;

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

        public PersonalSuperiorSubalternoDTO BuscarFormato(int Codigo)
        {
            PersonalSuperiorSubalternoDTO personalSuperiorSubDTO = new PersonalSuperiorSubalternoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalSuperiorSubalternoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSuperiorSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@PersonalSuperiorSubalternoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        personalSuperiorSubDTO.PersonalSuperiorSubalternoId = Convert.ToInt32(dr["PersonalSuperiorSubalternoId"]);
                        personalSuperiorSubDTO.DNIPSupSub = dr["DNIPSupSub"].ToString();
                        personalSuperiorSubDTO.CodigoProcedencia = dr["CodigoProcedencia"].ToString();
                        personalSuperiorSubDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        personalSuperiorSubDTO.Sexo = dr["Sexo"].ToString();
                        personalSuperiorSubDTO.UbigeoNacimiento = dr["UbigeoNacimiento"].ToString();
                        personalSuperiorSubDTO.FechaNacimientoPSupSub = Convert.ToDateTime(dr["FechaNacimientoPSupSub"]).ToString("yyy-MM-dd");
                        personalSuperiorSubDTO.UbigeoLabora = dr["UbigeoLabora"].ToString();
                        personalSuperiorSubDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        personalSuperiorSubDTO.FechaIngresoDepPSupSub = Convert.ToDateTime(dr["FechaIngresoDepPSupSub"]).ToString("yyy-MM-dd");
                        personalSuperiorSubDTO.EstadoCivilPSupSub = dr["EstadoCivilPSupSub"].ToString();
                        personalSuperiorSubDTO.CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString();
                        personalSuperiorSubDTO.CodigoSistemaPension = dr["CodigoSistemaPension"].ToString();
                        personalSuperiorSubDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        personalSuperiorSubDTO.FechaIngresoInstitucion = Convert.ToDateTime(dr["FechaIngresoInstitucion"]).ToString("yyy-MM-dd");
                        personalSuperiorSubDTO.FechaAltaPSupSub = Convert.ToDateTime(dr["FechaAltaPSupSub"]).ToString("yyy-MM-dd");
                        personalSuperiorSubDTO.FechaUltimoAscensoPSupSub = Convert.ToDateTime(dr["FechaUltimoAscensoPSupSub"]).ToString("yyy-MM-dd");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personalSuperiorSubDTO;
        }

        public string ActualizaFormato(PersonalSuperiorSubalternoDTO personalSuperiorSubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalSuperiorSubalternoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSuperiorSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@PersonalSuperiorSubalternoId"].Value = personalSuperiorSubDTO.PersonalSuperiorSubalternoId;

                    cmd.Parameters.Add("@DNIPSupSub", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPSupSub"].Value = personalSuperiorSubDTO.DNIPSupSub;

                    cmd.Parameters.Add("@CodigoProcedencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProcedencia"].Value = personalSuperiorSubDTO.CodigoProcedencia;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = personalSuperiorSubDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Sexo"].Value = personalSuperiorSubDTO.Sexo;

                    cmd.Parameters.Add("@UbigeoNacimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@UbigeoNacimiento"].Value = personalSuperiorSubDTO.UbigeoNacimiento;

                    cmd.Parameters.Add("@FechaNacimientoPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPSupSub"].Value = personalSuperiorSubDTO.FechaNacimientoPSupSub;

                    cmd.Parameters.Add("@UbigeoLabora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoLabora"].Value = personalSuperiorSubDTO.UbigeoLabora;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = personalSuperiorSubDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaIngresoDepPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDepPSupSub"].Value = personalSuperiorSubDTO.FechaIngresoDepPSupSub;

                    cmd.Parameters.Add("@EstadoCivilPSupSub", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EstadoCivilPSupSub"].Value = personalSuperiorSubDTO.EstadoCivilPSupSub;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = personalSuperiorSubDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@CodigoSistemaPension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPension"].Value = personalSuperiorSubDTO.CodigoSistemaPension;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = personalSuperiorSubDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@FechaIngresoInstitucion", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInstitucion"].Value = personalSuperiorSubDTO.FechaIngresoInstitucion;

                    cmd.Parameters.Add("@FechaAltaPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaAltaPSupSub"].Value = personalSuperiorSubDTO.FechaAltaPSupSub;

                    cmd.Parameters.Add("@FechaUltimoAscensoPSupSub", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoAscensoPSupSub"].Value = personalSuperiorSubDTO.FechaUltimoAscensoPSupSub;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalSuperiorSubDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;       

        }

        public bool EliminarFormato(PersonalSuperiorSubalternoDTO personalSuperiorSubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalSuperiorSubalternoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSuperiorSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@PersonalSuperiorSubalternoId"].Value = personalSuperiorSubDTO.PersonalSuperiorSubalternoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalSuperiorSubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PersonalSuperiorSubalternoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSuperiorSubalterno", SqlDbType.Structured);
                    cmd.Parameters["@PersonalSuperiorSubalterno"].TypeName = "Formato.PersonalSuperiorSubalterno";
                    cmd.Parameters["@PersonalSuperiorSubalterno"].Value = datos;

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
