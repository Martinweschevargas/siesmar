﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonaDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServiceReference1.PersonaNavalDC))]
    public partial class PersonaDC : object
    {
        
        private string Nombre1Field;
        
        private string Nombre2Field;
        
        private string Nombre3Field;
        
        private string NombreCompletoField;
        
        private string SexoField;
        
        private string TipoDocumentoField;
        
        private string NumeroDocumentoField;
        
        private string ApellidoPaternoField;
        
        private string ApellidoMaternoField;
        
        private string NombresField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre1
        {
            get
            {
                return this.Nombre1Field;
            }
            set
            {
                this.Nombre1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre2
        {
            get
            {
                return this.Nombre2Field;
            }
            set
            {
                this.Nombre2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre3
        {
            get
            {
                return this.Nombre3Field;
            }
            set
            {
                this.Nombre3Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreCompleto
        {
            get
            {
                return this.NombreCompletoField;
            }
            set
            {
                this.NombreCompletoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sexo
        {
            get
            {
                return this.SexoField;
            }
            set
            {
                this.SexoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoDocumento
        {
            get
            {
                return this.TipoDocumentoField;
            }
            set
            {
                this.TipoDocumentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string NumeroDocumento
        {
            get
            {
                return this.NumeroDocumentoField;
            }
            set
            {
                this.NumeroDocumentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string ApellidoPaterno
        {
            get
            {
                return this.ApellidoPaternoField;
            }
            set
            {
                this.ApellidoPaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public string ApellidoMaterno
        {
            get
            {
                return this.ApellidoMaternoField;
            }
            set
            {
                this.ApellidoMaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public string Nombres
        {
            get
            {
                return this.NombresField;
            }
            set
            {
                this.NombresField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonaNavalDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class PersonaNavalDC : ServiceReference1.PersonaDC
    {
        
        private ServiceReference1.CalificacionDC CalificacionField;
        
        private string CipField;
        
        private string CorreoExternoField;
        
        private string CorreoInternoField;
        
        private ServiceReference1.DependenciaDC DependenciaField;
        
        private ServiceReference1.EspecialidadDC EspecialidadField;
        
        private System.Nullable<System.DateTime> FechaIngresoField;
        
        private ServiceReference1.GradoDC GradoField;
        
        private ServiceReference1.GradoInstruccionDC GradoInstruccionField;
        
        private string TelefonoCelularField;
        
        private string TelefonoFijoField;
        
        private ServiceReference1.TipoPersonaDC TipoPersonaField;
        
        private string UbigeoDomicilioField;
        
        private string UbigeoIdDomicilioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.CalificacionDC Calificacion
        {
            get
            {
                return this.CalificacionField;
            }
            set
            {
                this.CalificacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cip
        {
            get
            {
                return this.CipField;
            }
            set
            {
                this.CipField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorreoExterno
        {
            get
            {
                return this.CorreoExternoField;
            }
            set
            {
                this.CorreoExternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorreoInterno
        {
            get
            {
                return this.CorreoInternoField;
            }
            set
            {
                this.CorreoInternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.DependenciaDC Dependencia
        {
            get
            {
                return this.DependenciaField;
            }
            set
            {
                this.DependenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.EspecialidadDC Especialidad
        {
            get
            {
                return this.EspecialidadField;
            }
            set
            {
                this.EspecialidadField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> FechaIngreso
        {
            get
            {
                return this.FechaIngresoField;
            }
            set
            {
                this.FechaIngresoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.GradoDC Grado
        {
            get
            {
                return this.GradoField;
            }
            set
            {
                this.GradoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.GradoInstruccionDC GradoInstruccion
        {
            get
            {
                return this.GradoInstruccionField;
            }
            set
            {
                this.GradoInstruccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TelefonoCelular
        {
            get
            {
                return this.TelefonoCelularField;
            }
            set
            {
                this.TelefonoCelularField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TelefonoFijo
        {
            get
            {
                return this.TelefonoFijoField;
            }
            set
            {
                this.TelefonoFijoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.TipoPersonaDC TipoPersona
        {
            get
            {
                return this.TipoPersonaField;
            }
            set
            {
                this.TipoPersonaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UbigeoDomicilio
        {
            get
            {
                return this.UbigeoDomicilioField;
            }
            set
            {
                this.UbigeoDomicilioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UbigeoIdDomicilio
        {
            get
            {
                return this.UbigeoIdDomicilioField;
            }
            set
            {
                this.UbigeoIdDomicilioField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CalificacionDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class CalificacionDC : object
    {
        
        private int CalificacionIdField;
        
        private string DescripcionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CalificacionId
        {
            get
            {
                return this.CalificacionIdField;
            }
            set
            {
                this.CalificacionIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DependenciaDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class DependenciaDC : object
    {
        
        private string AbreviaturaField;
        
        private string DescripcionField;
        
        private string IdField;
        
        private ServiceReference1.SituacionDC SituacionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Abreviatura
        {
            get
            {
                return this.AbreviaturaField;
            }
            set
            {
                this.AbreviaturaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.SituacionDC Situacion
        {
            get
            {
                return this.SituacionField;
            }
            set
            {
                this.SituacionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EspecialidadDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class EspecialidadDC : object
    {
        
        private string AbreviaturaField;
        
        private string DescripcionField;
        
        private int EspecialidadIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Abreviatura
        {
            get
            {
                return this.AbreviaturaField;
            }
            set
            {
                this.AbreviaturaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EspecialidadId
        {
            get
            {
                return this.EspecialidadIdField;
            }
            set
            {
                this.EspecialidadIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GradoDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class GradoDC : object
    {
        
        private string AbreviaturaField;
        
        private string DescripcionField;
        
        private int GradoIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Abreviatura
        {
            get
            {
                return this.AbreviaturaField;
            }
            set
            {
                this.AbreviaturaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int GradoId
        {
            get
            {
                return this.GradoIdField;
            }
            set
            {
                this.GradoIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GradoInstruccionDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class GradoInstruccionDC : object
    {
        
        private string DescripcionField;
        
        private int GradoInstruccionIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int GradoInstruccionId
        {
            get
            {
                return this.GradoInstruccionIdField;
            }
            set
            {
                this.GradoInstruccionIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoPersonaDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class TipoPersonaDC : object
    {
        
        private string DescripcionField;
        
        private int TipoPersonaIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TipoPersonaId
        {
            get
            {
                return this.TipoPersonaIdField;
            }
            set
            {
                this.TipoPersonaIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SituacionDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class SituacionDC : object
    {
        
        private string AbreviaturaField;
        
        private string DescripcionField;
        
        private string IdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Abreviatura
        {
            get
            {
                return this.AbreviaturaField;
            }
            set
            {
                this.AbreviaturaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RespuestaDC", Namespace="http://schemas.datacontract.org/2004/07/PrjServicios.Contratos")]
    public partial class RespuestaDC : object
    {
        
        private string DescripcionField;
        
        private string IdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ISeguridad")]
    public interface ISeguridad
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/Login", ReplyAction="http://tempuri.org/ISeguridad/LoginResponse")]
        ServiceReference1.LoginResponse Login(ServiceReference1.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/Login", ReplyAction="http://tempuri.org/ISeguridad/LoginResponse")]
        System.Threading.Tasks.Task<ServiceReference1.LoginResponse> LoginAsync(ServiceReference1.LoginRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Login", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class LoginRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string usuario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string contraseña;
        
        public LoginRequest()
        {
        }
        
        public LoginRequest(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LoginResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class LoginResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.PersonaNavalDC LoginResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public ServiceReference1.RespuestaDC respuestaDc;
        
        public LoginResponse()
        {
        }
        
        public LoginResponse(ServiceReference1.PersonaNavalDC LoginResult, ServiceReference1.RespuestaDC respuestaDc)
        {
            this.LoginResult = LoginResult;
            this.respuestaDc = respuestaDc;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ISeguridadChannel : ServiceReference1.ISeguridad, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class SeguridadClient : System.ServiceModel.ClientBase<ServiceReference1.ISeguridad>, ServiceReference1.ISeguridad
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SeguridadClient() : 
                base(SeguridadClient.GetDefaultBinding(), SeguridadClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpsBinding_ISeguridad.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SeguridadClient(EndpointConfiguration endpointConfiguration) : 
                base(SeguridadClient.GetBindingForEndpoint(endpointConfiguration), SeguridadClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SeguridadClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SeguridadClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SeguridadClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SeguridadClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SeguridadClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ServiceReference1.LoginResponse Login(ServiceReference1.LoginRequest request)
        {
            return base.Channel.Login(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.LoginResponse> LoginAsync(ServiceReference1.LoginRequest request)
        {
            return base.Channel.LoginAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpsBinding_ISeguridad))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            string Ws_Usuario = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["WS_Usuarios"];

            if ((endpointConfiguration == EndpointConfiguration.BasicHttpsBinding_ISeguridad))
            {
                return new System.ServiceModel.EndpointAddress(new Uri(Ws_Usuario));
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SeguridadClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpsBinding_ISeguridad);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SeguridadClient.GetEndpointAddress(EndpointConfiguration.BasicHttpsBinding_ISeguridad);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpsBinding_ISeguridad,
        }
    }
}
