﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.UserService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDto", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Dto")]
    [System.SerializableAttribute()]
    public partial class UserDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FIOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal MoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FIO {
            get {
                return this.FIOField;
            }
            set {
                if ((object.ReferenceEquals(this.FIOField, value) != true)) {
                    this.FIOField = value;
                    this.RaisePropertyChanged("FIO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Money {
            get {
                return this.MoneyField;
            }
            set {
                if ((this.MoneyField.Equals(value) != true)) {
                    this.MoneyField = value;
                    this.RaisePropertyChanged("Money");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
    [System.SerializableAttribute()]
    public partial class CustomException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoleDto", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Dto")]
    [System.SerializableAttribute()]
    public partial class RoleDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoleIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoleId {
            get {
                return this.RoleIdField;
            }
            set {
                if ((this.RoleIdField.Equals(value) != true)) {
                    this.RoleIdField = value;
                    this.RaisePropertyChanged("RoleId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUsers", ReplyAction="http://tempuri.org/IUserService/GetUsersResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/GetUsersCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.UserDto[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUsers", ReplyAction="http://tempuri.org/IUserService/GetUsersResponse")]
        System.Threading.Tasks.Task<Data.UserService.UserDto[]> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUsersByRole", ReplyAction="http://tempuri.org/IUserService/GetUsersByRoleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/GetUsersByRoleCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.UserDto[] GetUsersByRole(int RoleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUsersByRole", ReplyAction="http://tempuri.org/IUserService/GetUsersByRoleResponse")]
        System.Threading.Tasks.Task<Data.UserService.UserDto[]> GetUsersByRoleAsync(int RoleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/GetUserCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.UserDto GetUser(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        System.Threading.Tasks.Task<Data.UserService.UserDto> GetUserAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/AddUserCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.UserDto AddUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        System.Threading.Tasks.Task<Data.UserService.UserDto> AddUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/EditUser", ReplyAction="http://tempuri.org/IUserService/EditUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/EditUserCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.UserDto EditUser(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/EditUser", ReplyAction="http://tempuri.org/IUserService/EditUserResponse")]
        System.Threading.Tasks.Task<Data.UserService.UserDto> EditUserAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ExistsUser", ReplyAction="http://tempuri.org/IUserService/ExistsUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/ExistsUserCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.UserDto ExistsUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ExistsUser", ReplyAction="http://tempuri.org/IUserService/ExistsUserResponse")]
        System.Threading.Tasks.Task<Data.UserService.UserDto> ExistsUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetRoles", ReplyAction="http://tempuri.org/IUserService/GetRolesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.UserService.CustomException), Action="http://tempuri.org/IUserService/GetRolesCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.UserService.RoleDto[] GetRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetRoles", ReplyAction="http://tempuri.org/IUserService/GetRolesResponse")]
        System.Threading.Tasks.Task<Data.UserService.RoleDto[]> GetRolesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Data.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Data.UserService.IUserService>, Data.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Data.UserService.UserDto[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<Data.UserService.UserDto[]> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public Data.UserService.UserDto[] GetUsersByRole(int RoleId) {
            return base.Channel.GetUsersByRole(RoleId);
        }
        
        public System.Threading.Tasks.Task<Data.UserService.UserDto[]> GetUsersByRoleAsync(int RoleId) {
            return base.Channel.GetUsersByRoleAsync(RoleId);
        }
        
        public Data.UserService.UserDto GetUser(int userId) {
            return base.Channel.GetUser(userId);
        }
        
        public System.Threading.Tasks.Task<Data.UserService.UserDto> GetUserAsync(int userId) {
            return base.Channel.GetUserAsync(userId);
        }
        
        public Data.UserService.UserDto AddUser() {
            return base.Channel.AddUser();
        }
        
        public System.Threading.Tasks.Task<Data.UserService.UserDto> AddUserAsync() {
            return base.Channel.AddUserAsync();
        }
        
        public Data.UserService.UserDto EditUser(int userId) {
            return base.Channel.EditUser(userId);
        }
        
        public System.Threading.Tasks.Task<Data.UserService.UserDto> EditUserAsync(int userId) {
            return base.Channel.EditUserAsync(userId);
        }
        
        public Data.UserService.UserDto ExistsUser(string login, string password) {
            return base.Channel.ExistsUser(login, password);
        }
        
        public System.Threading.Tasks.Task<Data.UserService.UserDto> ExistsUserAsync(string login, string password) {
            return base.Channel.ExistsUserAsync(login, password);
        }
        
        public Data.UserService.RoleDto[] GetRoles() {
            return base.Channel.GetRoles();
        }
        
        public System.Threading.Tasks.Task<Data.UserService.RoleDto[]> GetRolesAsync() {
            return base.Channel.GetRolesAsync();
        }
    }
}