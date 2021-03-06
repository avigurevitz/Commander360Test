﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Commander360Test.Common.Faults
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseFault", Namespace="http://schemas.datacontract.org/2004/07/Commander360Test.Common.Faults")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Commander360Test.Common.Faults.UserNotFoundFault))]
    public partial class BaseFault : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string DescriptionField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/Commander360Test.Common.Faults")]
    public partial class UserNotFoundFault : Commander360Test.Common.Faults.BaseFault
    {
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServer", CallbackContract=typeof(IServerCallback))]
public interface IServer
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Login", ReplyAction="http://tempuri.org/IServer/LoginResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(Commander360Test.Common.Faults.UserNotFoundFault), Action="http://tempuri.org/IServer/LoginUserNotFoundFaultFault", Name="UserNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/Commander360Test.Common.Faults")]
    System.Guid Login(string userName, string password);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Start", ReplyAction="http://tempuri.org/IServer/StartResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(Commander360Test.Common.Faults.UserNotFoundFault), Action="http://tempuri.org/IServer/StartUserNotFoundFaultFault", Name="UserNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/Commander360Test.Common.Faults")]
    void Start(System.Guid sessionKey);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Stop", ReplyAction="http://tempuri.org/IServer/StopResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(Commander360Test.Common.Faults.UserNotFoundFault), Action="http://tempuri.org/IServer/StopUserNotFoundFaultFault", Name="UserNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/Commander360Test.Common.Faults")]
    void Stop(System.Guid sessionKey);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServerCallback
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/UpdateData")]
    void UpdateData(double result);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/UploadData")]
    void UploadData(byte[] buffer);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServerChannel : IServer, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServerClient : System.ServiceModel.DuplexClientBase<IServer>, IServer
{
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance) : 
            base(callbackInstance)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
            base(callbackInstance, endpointConfigurationName)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, binding, remoteAddress)
    {
    }
    
    public System.Guid Login(string userName, string password)
    {
        return base.Channel.Login(userName, password);
    }
    
    public void Start(System.Guid sessionKey)
    {
        base.Channel.Start(sessionKey);
    }
    
    public void Stop(System.Guid sessionKey)
    {
        base.Channel.Stop(sessionKey);
    }
}
