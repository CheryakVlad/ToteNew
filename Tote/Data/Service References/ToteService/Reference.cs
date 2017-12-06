﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.ToteService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BetListDto", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Dto")]
    [System.SerializableAttribute()]
    public partial class BetListDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BetIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommandGuestField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommandHomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryGuestField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryHomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DrawField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MatchIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double WinCommandGuestField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double WinCommandHomeField;
        
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
        public int BetId {
            get {
                return this.BetIdField;
            }
            set {
                if ((this.BetIdField.Equals(value) != true)) {
                    this.BetIdField = value;
                    this.RaisePropertyChanged("BetId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CommandGuest {
            get {
                return this.CommandGuestField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandGuestField, value) != true)) {
                    this.CommandGuestField = value;
                    this.RaisePropertyChanged("CommandGuest");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CommandHome {
            get {
                return this.CommandHomeField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandHomeField, value) != true)) {
                    this.CommandHomeField = value;
                    this.RaisePropertyChanged("CommandHome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryGuest {
            get {
                return this.CountryGuestField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryGuestField, value) != true)) {
                    this.CountryGuestField = value;
                    this.RaisePropertyChanged("CountryGuest");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryHome {
            get {
                return this.CountryHomeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryHomeField, value) != true)) {
                    this.CountryHomeField = value;
                    this.RaisePropertyChanged("CountryHome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Draw {
            get {
                return this.DrawField;
            }
            set {
                if ((this.DrawField.Equals(value) != true)) {
                    this.DrawField = value;
                    this.RaisePropertyChanged("Draw");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MatchId {
            get {
                return this.MatchIdField;
            }
            set {
                if ((this.MatchIdField.Equals(value) != true)) {
                    this.MatchIdField = value;
                    this.RaisePropertyChanged("MatchId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double WinCommandGuest {
            get {
                return this.WinCommandGuestField;
            }
            set {
                if ((this.WinCommandGuestField.Equals(value) != true)) {
                    this.WinCommandGuestField = value;
                    this.RaisePropertyChanged("WinCommandGuest");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double WinCommandHome {
            get {
                return this.WinCommandHomeField;
            }
            set {
                if ((this.WinCommandHomeField.Equals(value) != true)) {
                    this.WinCommandHomeField = value;
                    this.RaisePropertyChanged("WinCommandHome");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SportDto", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Dto")]
    [System.SerializableAttribute()]
    public partial class SportDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SportIdField;
        
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
        public int SportId {
            get {
                return this.SportIdField;
            }
            set {
                if ((this.SportIdField.Equals(value) != true)) {
                    this.SportIdField = value;
                    this.RaisePropertyChanged("SportId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EventDto", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Dto")]
    [System.SerializableAttribute()]
    public partial class EventDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double CoefficientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EventIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MatchIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public double Coefficient {
            get {
                return this.CoefficientField;
            }
            set {
                if ((this.CoefficientField.Equals(value) != true)) {
                    this.CoefficientField = value;
                    this.RaisePropertyChanged("Coefficient");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EventId {
            get {
                return this.EventIdField;
            }
            set {
                if ((this.EventIdField.Equals(value) != true)) {
                    this.EventIdField = value;
                    this.RaisePropertyChanged("EventId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MatchId {
            get {
                return this.MatchIdField;
            }
            set {
                if ((this.MatchIdField.Equals(value) != true)) {
                    this.MatchIdField = value;
                    this.RaisePropertyChanged("MatchId");
                }
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TournamentDto", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Dto")]
    [System.SerializableAttribute()]
    public partial class TournamentDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SportIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TournamentIdField;
        
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
        public int SportId {
            get {
                return this.SportIdField;
            }
            set {
                if ((this.SportIdField.Equals(value) != true)) {
                    this.SportIdField = value;
                    this.RaisePropertyChanged("SportId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TournamentId {
            get {
                return this.TournamentIdField;
            }
            set {
                if ((this.TournamentIdField.Equals(value) != true)) {
                    this.TournamentIdField = value;
                    this.RaisePropertyChanged("TournamentId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ToteService.IBetListService")]
    public interface IBetListService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetBets", ReplyAction="http://tempuri.org/IBetListService/GetBetsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/GetBetsCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.BetListDto[] GetBets(System.Nullable<int> sportId, System.Nullable<int> tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetBets", ReplyAction="http://tempuri.org/IBetListService/GetBetsResponse")]
        System.Threading.Tasks.Task<Data.ToteService.BetListDto[]> GetBetsAsync(System.Nullable<int> sportId, System.Nullable<int> tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetBetsAll", ReplyAction="http://tempuri.org/IBetListService/GetBetsAllResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/GetBetsAllCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.BetListDto[] GetBetsAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetBetsAll", ReplyAction="http://tempuri.org/IBetListService/GetBetsAllResponse")]
        System.Threading.Tasks.Task<Data.ToteService.BetListDto[]> GetBetsAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetSport", ReplyAction="http://tempuri.org/IBetListService/GetSportResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/GetSportCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.SportDto GetSport(System.Nullable<int> id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetSport", ReplyAction="http://tempuri.org/IBetListService/GetSportResponse")]
        System.Threading.Tasks.Task<Data.ToteService.SportDto> GetSportAsync(System.Nullable<int> id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetSports", ReplyAction="http://tempuri.org/IBetListService/GetSportsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/GetSportsCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.SportDto[] GetSports();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetSports", ReplyAction="http://tempuri.org/IBetListService/GetSportsResponse")]
        System.Threading.Tasks.Task<Data.ToteService.SportDto[]> GetSportsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/UpdateSport", ReplyAction="http://tempuri.org/IBetListService/UpdateSportResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/UpdateSportCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        bool UpdateSport(Data.ToteService.SportDto sportDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/UpdateSport", ReplyAction="http://tempuri.org/IBetListService/UpdateSportResponse")]
        System.Threading.Tasks.Task<bool> UpdateSportAsync(Data.ToteService.SportDto sportDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/AddSport", ReplyAction="http://tempuri.org/IBetListService/AddSportResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/AddSportCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        bool AddSport(Data.ToteService.SportDto sportDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/AddSport", ReplyAction="http://tempuri.org/IBetListService/AddSportResponse")]
        System.Threading.Tasks.Task<bool> AddSportAsync(Data.ToteService.SportDto sportDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/DeleteSport", ReplyAction="http://tempuri.org/IBetListService/DeleteSportResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/DeleteSportCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        bool DeleteSport(int sportId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/DeleteSport", ReplyAction="http://tempuri.org/IBetListService/DeleteSportResponse")]
        System.Threading.Tasks.Task<bool> DeleteSportAsync(int sportId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetEvents", ReplyAction="http://tempuri.org/IBetListService/GetEventsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/GetEventsCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.EventDto[] GetEvents(System.Nullable<int> id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetEvents", ReplyAction="http://tempuri.org/IBetListService/GetEventsResponse")]
        System.Threading.Tasks.Task<Data.ToteService.EventDto[]> GetEventsAsync(System.Nullable<int> id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetEventsAll", ReplyAction="http://tempuri.org/IBetListService/GetEventsAllResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/IBetListService/GetEventsAllCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.EventDto[] GetEventsAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetListService/GetEventsAll", ReplyAction="http://tempuri.org/IBetListService/GetEventsAllResponse")]
        System.Threading.Tasks.Task<Data.ToteService.EventDto[]> GetEventsAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBetListServiceChannel : Data.ToteService.IBetListService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BetListServiceClient : System.ServiceModel.ClientBase<Data.ToteService.IBetListService>, Data.ToteService.IBetListService {
        
        public BetListServiceClient() {
        }
        
        public BetListServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BetListServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BetListServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BetListServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Data.ToteService.BetListDto[] GetBets(System.Nullable<int> sportId, System.Nullable<int> tournamentId) {
            return base.Channel.GetBets(sportId, tournamentId);
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.BetListDto[]> GetBetsAsync(System.Nullable<int> sportId, System.Nullable<int> tournamentId) {
            return base.Channel.GetBetsAsync(sportId, tournamentId);
        }
        
        public Data.ToteService.BetListDto[] GetBetsAll() {
            return base.Channel.GetBetsAll();
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.BetListDto[]> GetBetsAllAsync() {
            return base.Channel.GetBetsAllAsync();
        }
        
        public Data.ToteService.SportDto GetSport(System.Nullable<int> id) {
            return base.Channel.GetSport(id);
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.SportDto> GetSportAsync(System.Nullable<int> id) {
            return base.Channel.GetSportAsync(id);
        }
        
        public Data.ToteService.SportDto[] GetSports() {
            return base.Channel.GetSports();
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.SportDto[]> GetSportsAsync() {
            return base.Channel.GetSportsAsync();
        }
        
        public bool UpdateSport(Data.ToteService.SportDto sportDto) {
            return base.Channel.UpdateSport(sportDto);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateSportAsync(Data.ToteService.SportDto sportDto) {
            return base.Channel.UpdateSportAsync(sportDto);
        }
        
        public bool AddSport(Data.ToteService.SportDto sportDto) {
            return base.Channel.AddSport(sportDto);
        }
        
        public System.Threading.Tasks.Task<bool> AddSportAsync(Data.ToteService.SportDto sportDto) {
            return base.Channel.AddSportAsync(sportDto);
        }
        
        public bool DeleteSport(int sportId) {
            return base.Channel.DeleteSport(sportId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteSportAsync(int sportId) {
            return base.Channel.DeleteSportAsync(sportId);
        }
        
        public Data.ToteService.EventDto[] GetEvents(System.Nullable<int> id) {
            return base.Channel.GetEvents(id);
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.EventDto[]> GetEventsAsync(System.Nullable<int> id) {
            return base.Channel.GetEventsAsync(id);
        }
        
        public Data.ToteService.EventDto[] GetEventsAll() {
            return base.Channel.GetEventsAll();
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.EventDto[]> GetEventsAllAsync() {
            return base.Channel.GetEventsAllAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ToteService.ITournamentService")]
    public interface ITournamentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/GetTournament", ReplyAction="http://tempuri.org/ITournamentService/GetTournamentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/ITournamentService/GetTournamentCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.TournamentDto[] GetTournament(System.Nullable<int> sportId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/GetTournament", ReplyAction="http://tempuri.org/ITournamentService/GetTournamentResponse")]
        System.Threading.Tasks.Task<Data.ToteService.TournamentDto[]> GetTournamentAsync(System.Nullable<int> sportId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/GetTournamentes", ReplyAction="http://tempuri.org/ITournamentService/GetTournamentesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/ITournamentService/GetTournamentesCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.TournamentDto[] GetTournamentes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/GetTournamentes", ReplyAction="http://tempuri.org/ITournamentService/GetTournamentesResponse")]
        System.Threading.Tasks.Task<Data.ToteService.TournamentDto[]> GetTournamentesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/GetTournamentById", ReplyAction="http://tempuri.org/ITournamentService/GetTournamentByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/ITournamentService/GetTournamentByIdCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        Data.ToteService.TournamentDto GetTournamentById(int tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/GetTournamentById", ReplyAction="http://tempuri.org/ITournamentService/GetTournamentByIdResponse")]
        System.Threading.Tasks.Task<Data.ToteService.TournamentDto> GetTournamentByIdAsync(int tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/UpdateTournament", ReplyAction="http://tempuri.org/ITournamentService/UpdateTournamentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/ITournamentService/UpdateTournamentCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        bool UpdateTournament(Data.ToteService.TournamentDto tournamentDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/UpdateTournament", ReplyAction="http://tempuri.org/ITournamentService/UpdateTournamentResponse")]
        System.Threading.Tasks.Task<bool> UpdateTournamentAsync(Data.ToteService.TournamentDto tournamentDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/AddTournament", ReplyAction="http://tempuri.org/ITournamentService/AddTournamentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/ITournamentService/AddTournamentCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        bool AddTournament(Data.ToteService.TournamentDto tournamentDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/AddTournament", ReplyAction="http://tempuri.org/ITournamentService/AddTournamentResponse")]
        System.Threading.Tasks.Task<bool> AddTournamentAsync(Data.ToteService.TournamentDto tournamentDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/DeleteTournament", ReplyAction="http://tempuri.org/ITournamentService/DeleteTournamentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Data.ToteService.CustomException), Action="http://tempuri.org/ITournamentService/DeleteTournamentCustomExceptionFault", Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/Service.Contracts.Exception")]
        bool DeleteTournament(int tournamentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITournamentService/DeleteTournament", ReplyAction="http://tempuri.org/ITournamentService/DeleteTournamentResponse")]
        System.Threading.Tasks.Task<bool> DeleteTournamentAsync(int tournamentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITournamentServiceChannel : Data.ToteService.ITournamentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TournamentServiceClient : System.ServiceModel.ClientBase<Data.ToteService.ITournamentService>, Data.ToteService.ITournamentService {
        
        public TournamentServiceClient() {
        }
        
        public TournamentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TournamentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TournamentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TournamentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Data.ToteService.TournamentDto[] GetTournament(System.Nullable<int> sportId) {
            return base.Channel.GetTournament(sportId);
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.TournamentDto[]> GetTournamentAsync(System.Nullable<int> sportId) {
            return base.Channel.GetTournamentAsync(sportId);
        }
        
        public Data.ToteService.TournamentDto[] GetTournamentes() {
            return base.Channel.GetTournamentes();
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.TournamentDto[]> GetTournamentesAsync() {
            return base.Channel.GetTournamentesAsync();
        }
        
        public Data.ToteService.TournamentDto GetTournamentById(int tournamentId) {
            return base.Channel.GetTournamentById(tournamentId);
        }
        
        public System.Threading.Tasks.Task<Data.ToteService.TournamentDto> GetTournamentByIdAsync(int tournamentId) {
            return base.Channel.GetTournamentByIdAsync(tournamentId);
        }
        
        public bool UpdateTournament(Data.ToteService.TournamentDto tournamentDto) {
            return base.Channel.UpdateTournament(tournamentDto);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateTournamentAsync(Data.ToteService.TournamentDto tournamentDto) {
            return base.Channel.UpdateTournamentAsync(tournamentDto);
        }
        
        public bool AddTournament(Data.ToteService.TournamentDto tournamentDto) {
            return base.Channel.AddTournament(tournamentDto);
        }
        
        public System.Threading.Tasks.Task<bool> AddTournamentAsync(Data.ToteService.TournamentDto tournamentDto) {
            return base.Channel.AddTournamentAsync(tournamentDto);
        }
        
        public bool DeleteTournament(int tournamentId) {
            return base.Channel.DeleteTournament(tournamentId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteTournamentAsync(int tournamentId) {
            return base.Channel.DeleteTournamentAsync(tournamentId);
        }
    }
}
