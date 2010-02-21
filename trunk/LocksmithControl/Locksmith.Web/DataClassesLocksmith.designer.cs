﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.21006.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Locksmith.Web
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Runtime.Serialization;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="StrongerOrg")]
	public partial class DataClassesLocksmithDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTechnician(Technician instance);
    partial void UpdateTechnician(Technician instance);
    partial void DeleteTechnician(Technician instance);
    partial void InsertCompany(Company instance);
    partial void UpdateCompany(Company instance);
    partial void DeleteCompany(Company instance);
    partial void InsertJob(Job instance);
    partial void UpdateJob(Job instance);
    partial void DeleteJob(Job instance);
    #endregion
		
		public DataClassesLocksmithDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["StrongerOrgConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesLocksmithDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesLocksmithDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesLocksmithDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesLocksmithDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Technician> Technicians
		{
			get
			{
				return this.GetTable<Technician>();
			}
		}
		
		public System.Data.Linq.Table<Company> Companies
		{
			get
			{
				return this.GetTable<Company>();
			}
		}
		
		public System.Data.Linq.Table<Job> Jobs
		{
			get
			{
				return this.GetTable<Job>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Technician")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Technician : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Company;
		
		private string _Address;
		
		private string _State;
		
		private string _City;
		
		private string _Phone;
		
		private string _MobilePhone;
		
		private string _email;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnCompanyChanging(string value);
    partial void OnCompanyChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnStateChanging(string value);
    partial void OnStateChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnMobilePhoneChanging(string value);
    partial void OnMobilePhoneChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    #endregion
		
		public Technician()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Company", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string Company
		{
			get
			{
				return this._Company;
			}
			set
			{
				if ((this._Company != value))
				{
					this.OnCompanyChanging(value);
					this.SendPropertyChanging();
					this._Company = value;
					this.SendPropertyChanged("Company");
					this.OnCompanyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public string State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MobilePhone", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=9)]
		public string MobilePhone
		{
			get
			{
				return this._MobilePhone;
			}
			set
			{
				if ((this._MobilePhone != value))
				{
					this.OnMobilePhoneChanging(value);
					this.SendPropertyChanging();
					this._MobilePhone = value;
					this.SendPropertyChanged("MobilePhone");
					this.OnMobilePhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=10)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Companies")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Company : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Name;
		
		private string _Address;
		
		private string _State;
		
		private string _City;
		
		private string _Zip_Code;
		
		private string _Phone1;
		
		private string _Phone2;
		
		private string _Phone3;
		
		private string _Fax;
		
		private string _Email;
		
		private string _Url;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnStateChanging(string value);
    partial void OnStateChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnZip_CodeChanging(string value);
    partial void OnZip_CodeChanged();
    partial void OnPhone1Changing(string value);
    partial void OnPhone1Changed();
    partial void OnPhone2Changing(string value);
    partial void OnPhone2Changed();
    partial void OnPhone3Changing(string value);
    partial void OnPhone3Changed();
    partial void OnFaxChanging(string value);
    partial void OnFaxChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    #endregion
		
		public Company()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Zip Code]", Storage="_Zip_Code", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public string Zip_Code
		{
			get
			{
				return this._Zip_Code;
			}
			set
			{
				if ((this._Zip_Code != value))
				{
					this.OnZip_CodeChanging(value);
					this.SendPropertyChanging();
					this._Zip_Code = value;
					this.SendPropertyChanged("Zip_Code");
					this.OnZip_CodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone1", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public string Phone1
		{
			get
			{
				return this._Phone1;
			}
			set
			{
				if ((this._Phone1 != value))
				{
					this.OnPhone1Changing(value);
					this.SendPropertyChanging();
					this._Phone1 = value;
					this.SendPropertyChanged("Phone1");
					this.OnPhone1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone2", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public string Phone2
		{
			get
			{
				return this._Phone2;
			}
			set
			{
				if ((this._Phone2 != value))
				{
					this.OnPhone2Changing(value);
					this.SendPropertyChanging();
					this._Phone2 = value;
					this.SendPropertyChanged("Phone2");
					this.OnPhone2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone3", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=9)]
		public string Phone3
		{
			get
			{
				return this._Phone3;
			}
			set
			{
				if ((this._Phone3 != value))
				{
					this.OnPhone3Changing(value);
					this.SendPropertyChanging();
					this._Phone3 = value;
					this.SendPropertyChanged("Phone3");
					this.OnPhone3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fax", DbType="NVarChar(MAX)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=10)]
		public string Fax
		{
			get
			{
				return this._Fax;
			}
			set
			{
				if ((this._Fax != value))
				{
					this.OnFaxChanging(value);
					this.SendPropertyChanging();
					this._Fax = value;
					this.SendPropertyChanged("Fax");
					this.OnFaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=11)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=12)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Jobs")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Job : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Status;
		
		private string _Technician;
		
		private string _First_Name;
		
		private string _Last_Name;
		
		private string _Address;
		
		private string _State;
		
		private string _City;
		
		private string _Phone;
		
		private string _Mobile_Phone;
		
		private string _Job_Type;
		
		private string _Company;
		
		private string _Job_Pricing;
		
		private string _Total;
		
		private string _Cost;
		
		private string _Payment_Method;
		
		private string _Info;
		
		private string _Gross;
		
		private string _Gross_Cost;
		
		private string _Tech_Cut;
		
		private string _Tech_Payout;
		
		private string _Company_Payout;
		
		private string _Net_pay;
		
		private string _Sum_Cash;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnTechnicianChanging(string value);
    partial void OnTechnicianChanged();
    partial void OnFirst_NameChanging(string value);
    partial void OnFirst_NameChanged();
    partial void OnLast_NameChanging(string value);
    partial void OnLast_NameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnStateChanging(string value);
    partial void OnStateChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnMobile_PhoneChanging(string value);
    partial void OnMobile_PhoneChanged();
    partial void OnJob_TypeChanging(string value);
    partial void OnJob_TypeChanged();
    partial void OnCompanyChanging(string value);
    partial void OnCompanyChanged();
    partial void OnJob_PricingChanging(string value);
    partial void OnJob_PricingChanged();
    partial void OnTotalChanging(string value);
    partial void OnTotalChanged();
    partial void OnCostChanging(string value);
    partial void OnCostChanged();
    partial void OnPayment_MethodChanging(string value);
    partial void OnPayment_MethodChanged();
    partial void OnInfoChanging(string value);
    partial void OnInfoChanged();
    partial void OnGrossChanging(string value);
    partial void OnGrossChanged();
    partial void OnGross_CostChanging(string value);
    partial void OnGross_CostChanged();
    partial void OnTech_CutChanging(string value);
    partial void OnTech_CutChanged();
    partial void OnTech_PayoutChanging(string value);
    partial void OnTech_PayoutChanged();
    partial void OnCompany_PayoutChanging(string value);
    partial void OnCompany_PayoutChanged();
    partial void OnNet_payChanging(string value);
    partial void OnNet_payChanged();
    partial void OnSum_CashChanging(string value);
    partial void OnSum_CashChanged();
    #endregion
		
		public Job()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Technician", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string Technician
		{
			get
			{
				return this._Technician;
			}
			set
			{
				if ((this._Technician != value))
				{
					this.OnTechnicianChanging(value);
					this.SendPropertyChanging();
					this._Technician = value;
					this.SendPropertyChanged("Technician");
					this.OnTechnicianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[First Name]", Storage="_First_Name", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string First_Name
		{
			get
			{
				return this._First_Name;
			}
			set
			{
				if ((this._First_Name != value))
				{
					this.OnFirst_NameChanging(value);
					this.SendPropertyChanging();
					this._First_Name = value;
					this.SendPropertyChanged("First_Name");
					this.OnFirst_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Last Name]", Storage="_Last_Name", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public string Last_Name
		{
			get
			{
				return this._Last_Name;
			}
			set
			{
				if ((this._Last_Name != value))
				{
					this.OnLast_NameChanging(value);
					this.SendPropertyChanging();
					this._Last_Name = value;
					this.SendPropertyChanged("Last_Name");
					this.OnLast_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public string State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=9)]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Mobile Phone]", Storage="_Mobile_Phone", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=10)]
		public string Mobile_Phone
		{
			get
			{
				return this._Mobile_Phone;
			}
			set
			{
				if ((this._Mobile_Phone != value))
				{
					this.OnMobile_PhoneChanging(value);
					this.SendPropertyChanging();
					this._Mobile_Phone = value;
					this.SendPropertyChanged("Mobile_Phone");
					this.OnMobile_PhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Job Type]", Storage="_Job_Type", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=11)]
		public string Job_Type
		{
			get
			{
				return this._Job_Type;
			}
			set
			{
				if ((this._Job_Type != value))
				{
					this.OnJob_TypeChanging(value);
					this.SendPropertyChanging();
					this._Job_Type = value;
					this.SendPropertyChanged("Job_Type");
					this.OnJob_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Company", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=12)]
		public string Company
		{
			get
			{
				return this._Company;
			}
			set
			{
				if ((this._Company != value))
				{
					this.OnCompanyChanging(value);
					this.SendPropertyChanging();
					this._Company = value;
					this.SendPropertyChanged("Company");
					this.OnCompanyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Job Pricing]", Storage="_Job_Pricing", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=13)]
		public string Job_Pricing
		{
			get
			{
				return this._Job_Pricing;
			}
			set
			{
				if ((this._Job_Pricing != value))
				{
					this.OnJob_PricingChanging(value);
					this.SendPropertyChanging();
					this._Job_Pricing = value;
					this.SendPropertyChanged("Job_Pricing");
					this.OnJob_PricingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=14)]
		public string Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this.OnTotalChanging(value);
					this.SendPropertyChanging();
					this._Total = value;
					this.SendPropertyChanged("Total");
					this.OnTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cost", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=15)]
		public string Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				if ((this._Cost != value))
				{
					this.OnCostChanging(value);
					this.SendPropertyChanging();
					this._Cost = value;
					this.SendPropertyChanged("Cost");
					this.OnCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Payment Method]", Storage="_Payment_Method", DbType="NVarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=16)]
		public string Payment_Method
		{
			get
			{
				return this._Payment_Method;
			}
			set
			{
				if ((this._Payment_Method != value))
				{
					this.OnPayment_MethodChanging(value);
					this.SendPropertyChanging();
					this._Payment_Method = value;
					this.SendPropertyChanged("Payment_Method");
					this.OnPayment_MethodChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Info", DbType="NVarChar(200)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=17)]
		public string Info
		{
			get
			{
				return this._Info;
			}
			set
			{
				if ((this._Info != value))
				{
					this.OnInfoChanging(value);
					this.SendPropertyChanging();
					this._Info = value;
					this.SendPropertyChanged("Info");
					this.OnInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gross", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=18)]
		public string Gross
		{
			get
			{
				return this._Gross;
			}
			set
			{
				if ((this._Gross != value))
				{
					this.OnGrossChanging(value);
					this.SendPropertyChanging();
					this._Gross = value;
					this.SendPropertyChanged("Gross");
					this.OnGrossChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Gross-Cost]", Storage="_Gross_Cost", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=19)]
		public string Gross_Cost
		{
			get
			{
				return this._Gross_Cost;
			}
			set
			{
				if ((this._Gross_Cost != value))
				{
					this.OnGross_CostChanging(value);
					this.SendPropertyChanging();
					this._Gross_Cost = value;
					this.SendPropertyChanged("Gross_Cost");
					this.OnGross_CostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Tech Cut]", Storage="_Tech_Cut", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=20)]
		public string Tech_Cut
		{
			get
			{
				return this._Tech_Cut;
			}
			set
			{
				if ((this._Tech_Cut != value))
				{
					this.OnTech_CutChanging(value);
					this.SendPropertyChanging();
					this._Tech_Cut = value;
					this.SendPropertyChanged("Tech_Cut");
					this.OnTech_CutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Tech Payout]", Storage="_Tech_Payout", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=21)]
		public string Tech_Payout
		{
			get
			{
				return this._Tech_Payout;
			}
			set
			{
				if ((this._Tech_Payout != value))
				{
					this.OnTech_PayoutChanging(value);
					this.SendPropertyChanging();
					this._Tech_Payout = value;
					this.SendPropertyChanged("Tech_Payout");
					this.OnTech_PayoutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Company Payout]", Storage="_Company_Payout", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=22)]
		public string Company_Payout
		{
			get
			{
				return this._Company_Payout;
			}
			set
			{
				if ((this._Company_Payout != value))
				{
					this.OnCompany_PayoutChanging(value);
					this.SendPropertyChanging();
					this._Company_Payout = value;
					this.SendPropertyChanged("Company_Payout");
					this.OnCompany_PayoutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Net pay]", Storage="_Net_pay", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=23)]
		public string Net_pay
		{
			get
			{
				return this._Net_pay;
			}
			set
			{
				if ((this._Net_pay != value))
				{
					this.OnNet_payChanging(value);
					this.SendPropertyChanging();
					this._Net_pay = value;
					this.SendPropertyChanged("Net_pay");
					this.OnNet_payChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Sum Cash]", Storage="_Sum_Cash", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=24)]
		public string Sum_Cash
		{
			get
			{
				return this._Sum_Cash;
			}
			set
			{
				if ((this._Sum_Cash != value))
				{
					this.OnSum_CashChanging(value);
					this.SendPropertyChanging();
					this._Sum_Cash = value;
					this.SendPropertyChanged("Sum_Cash");
					this.OnSum_CashChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
}
#pragma warning restore 1591