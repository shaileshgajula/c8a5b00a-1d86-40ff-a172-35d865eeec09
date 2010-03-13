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

namespace StrongerOrg.BL.DL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="StrongerOrg")]
	public partial class TournamentsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTournamentMatchup(TournamentMatchup instance);
    partial void UpdateTournamentMatchup(TournamentMatchup instance);
    partial void DeleteTournamentMatchup(TournamentMatchup instance);
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    partial void InsertOrganisationHoliday(OrganisationHoliday instance);
    partial void UpdateOrganisationHoliday(OrganisationHoliday instance);
    partial void DeleteOrganisationHoliday(OrganisationHoliday instance);
    partial void InsertTournament(Tournament instance);
    partial void UpdateTournament(Tournament instance);
    partial void DeleteTournament(Tournament instance);
    #endregion
		
		public TournamentsDataContext() : 
				base(global::StrongerOrg.BL.Properties.Settings.Default.StrongerOrgConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TournamentsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TournamentsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TournamentsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TournamentsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TournamentMatchup> TournamentMatchups
		{
			get
			{
				return this.GetTable<TournamentMatchup>();
			}
		}
		
		public System.Data.Linq.Table<Players2Tournament> Players2Tournaments
		{
			get
			{
				return this.GetTable<Players2Tournament>();
			}
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
		
		public System.Data.Linq.Table<OrganisationHoliday> OrganisationHolidays
		{
			get
			{
				return this.GetTable<OrganisationHoliday>();
			}
		}
		
		public System.Data.Linq.Table<Tournament> Tournaments
		{
			get
			{
				return this.GetTable<Tournament>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TournamentMatchups")]
	public partial class TournamentMatchup : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Guid _TournamentId;
		
		private System.Guid _PlayerA;
		
		private System.Guid _PlayerB;
		
		private System.DateTime _Start;
		
		private System.DateTime _End;
		
		private System.Nullable<System.Guid> _Winner;
		
		private System.Nullable<int> _ScoreA;
		
		private System.Nullable<int> _ScoreB;
		
		private System.Nullable<System.Guid> _UpdatedBy;
		
		private int _MatchUpId;
		
		private int _Round;
		
		private int _NextMatchId;
		
		private bool _IsEmailSent;
		
		private EntityRef<Tournament> _Tournament;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTournamentIdChanging(System.Guid value);
    partial void OnTournamentIdChanged();
    partial void OnPlayerAChanging(System.Guid value);
    partial void OnPlayerAChanged();
    partial void OnPlayerBChanging(System.Guid value);
    partial void OnPlayerBChanged();
    partial void OnStartChanging(System.DateTime value);
    partial void OnStartChanged();
    partial void OnEndChanging(System.DateTime value);
    partial void OnEndChanged();
    partial void OnWinnerChanging(System.Nullable<System.Guid> value);
    partial void OnWinnerChanged();
    partial void OnScoreAChanging(System.Nullable<int> value);
    partial void OnScoreAChanged();
    partial void OnScoreBChanging(System.Nullable<int> value);
    partial void OnScoreBChanged();
    partial void OnUpdatedByChanging(System.Nullable<System.Guid> value);
    partial void OnUpdatedByChanged();
    partial void OnMatchUpIdChanging(int value);
    partial void OnMatchUpIdChanged();
    partial void OnRoundChanging(int value);
    partial void OnRoundChanged();
    partial void OnNextMatchIdChanging(int value);
    partial void OnNextMatchIdChanged();
    partial void OnIsEmailSentChanging(bool value);
    partial void OnIsEmailSentChanged();
    #endregion
		
		public TournamentMatchup()
		{
			this._Tournament = default(EntityRef<Tournament>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TournamentId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid TournamentId
		{
			get
			{
				return this._TournamentId;
			}
			set
			{
				if ((this._TournamentId != value))
				{
					if (this._Tournament.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTournamentIdChanging(value);
					this.SendPropertyChanging();
					this._TournamentId = value;
					this.SendPropertyChanged("TournamentId");
					this.OnTournamentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerA", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid PlayerA
		{
			get
			{
				return this._PlayerA;
			}
			set
			{
				if ((this._PlayerA != value))
				{
					this.OnPlayerAChanging(value);
					this.SendPropertyChanging();
					this._PlayerA = value;
					this.SendPropertyChanged("PlayerA");
					this.OnPlayerAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerB", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid PlayerB
		{
			get
			{
				return this._PlayerB;
			}
			set
			{
				if ((this._PlayerB != value))
				{
					this.OnPlayerBChanging(value);
					this.SendPropertyChanging();
					this._PlayerB = value;
					this.SendPropertyChanged("PlayerB");
					this.OnPlayerBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Start", DbType="DateTime NOT NULL")]
		public System.DateTime Start
		{
			get
			{
				return this._Start;
			}
			set
			{
				if ((this._Start != value))
				{
					this.OnStartChanging(value);
					this.SendPropertyChanging();
					this._Start = value;
					this.SendPropertyChanged("Start");
					this.OnStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[End]", Storage="_End", DbType="DateTime NOT NULL")]
		public System.DateTime End
		{
			get
			{
				return this._End;
			}
			set
			{
				if ((this._End != value))
				{
					this.OnEndChanging(value);
					this.SendPropertyChanging();
					this._End = value;
					this.SendPropertyChanged("End");
					this.OnEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Winner", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> Winner
		{
			get
			{
				return this._Winner;
			}
			set
			{
				if ((this._Winner != value))
				{
					this.OnWinnerChanging(value);
					this.SendPropertyChanging();
					this._Winner = value;
					this.SendPropertyChanged("Winner");
					this.OnWinnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScoreA", DbType="Int")]
		public System.Nullable<int> ScoreA
		{
			get
			{
				return this._ScoreA;
			}
			set
			{
				if ((this._ScoreA != value))
				{
					this.OnScoreAChanging(value);
					this.SendPropertyChanging();
					this._ScoreA = value;
					this.SendPropertyChanged("ScoreA");
					this.OnScoreAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScoreB", DbType="Int")]
		public System.Nullable<int> ScoreB
		{
			get
			{
				return this._ScoreB;
			}
			set
			{
				if ((this._ScoreB != value))
				{
					this.OnScoreBChanging(value);
					this.SendPropertyChanging();
					this._ScoreB = value;
					this.SendPropertyChanged("ScoreB");
					this.OnScoreBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdatedBy", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> UpdatedBy
		{
			get
			{
				return this._UpdatedBy;
			}
			set
			{
				if ((this._UpdatedBy != value))
				{
					this.OnUpdatedByChanging(value);
					this.SendPropertyChanging();
					this._UpdatedBy = value;
					this.SendPropertyChanged("UpdatedBy");
					this.OnUpdatedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatchUpId", DbType="Int NOT NULL")]
		public int MatchUpId
		{
			get
			{
				return this._MatchUpId;
			}
			set
			{
				if ((this._MatchUpId != value))
				{
					this.OnMatchUpIdChanging(value);
					this.SendPropertyChanging();
					this._MatchUpId = value;
					this.SendPropertyChanged("MatchUpId");
					this.OnMatchUpIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Round", DbType="Int NOT NULL")]
		public int Round
		{
			get
			{
				return this._Round;
			}
			set
			{
				if ((this._Round != value))
				{
					this.OnRoundChanging(value);
					this.SendPropertyChanging();
					this._Round = value;
					this.SendPropertyChanged("Round");
					this.OnRoundChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NextMatchId", DbType="Int NOT NULL")]
		public int NextMatchId
		{
			get
			{
				return this._NextMatchId;
			}
			set
			{
				if ((this._NextMatchId != value))
				{
					this.OnNextMatchIdChanging(value);
					this.SendPropertyChanging();
					this._NextMatchId = value;
					this.SendPropertyChanged("NextMatchId");
					this.OnNextMatchIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsEmailSent", DbType="Bit NOT NULL")]
		public bool IsEmailSent
		{
			get
			{
				return this._IsEmailSent;
			}
			set
			{
				if ((this._IsEmailSent != value))
				{
					this.OnIsEmailSentChanging(value);
					this.SendPropertyChanging();
					this._IsEmailSent = value;
					this.SendPropertyChanged("IsEmailSent");
					this.OnIsEmailSentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tournament_TournamentMatchup", Storage="_Tournament", ThisKey="TournamentId", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Tournament Tournament
		{
			get
			{
				return this._Tournament.Entity;
			}
			set
			{
				Tournament previousValue = this._Tournament.Entity;
				if (((previousValue != value) 
							|| (this._Tournament.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tournament.Entity = null;
						previousValue.TournamentMatchups.Remove(this);
					}
					this._Tournament.Entity = value;
					if ((value != null))
					{
						value.TournamentMatchups.Add(this);
						this._TournamentId = value.Id;
					}
					else
					{
						this._TournamentId = default(System.Guid);
					}
					this.SendPropertyChanged("Tournament");
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
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Players2Tournaments")]
	public partial class Players2Tournament
	{
		
		private System.Guid _PlayerId;
		
		private System.Guid _TournamentId;
		
		public Players2Tournament()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid PlayerId
		{
			get
			{
				return this._PlayerId;
			}
			set
			{
				if ((this._PlayerId != value))
				{
					this._PlayerId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TournamentId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid TournamentId
		{
			get
			{
				return this._TournamentId;
			}
			set
			{
				if ((this._TournamentId != value))
				{
					this._TournamentId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Players")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _OrganisationId;
		
		private string _Name;
		
		private string _Email;
		
		private string _NickName;
		
		private string _Department;
		
		private System.DateTime _CreateDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnOrganisationIdChanging(System.Guid value);
    partial void OnOrganisationIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnNickNameChanging(string value);
    partial void OnNickNameChanged();
    partial void OnDepartmentChanging(string value);
    partial void OnDepartmentChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    #endregion
		
		public Player()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrganisationId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid OrganisationId
		{
			get
			{
				return this._OrganisationId;
			}
			set
			{
				if ((this._OrganisationId != value))
				{
					this.OnOrganisationIdChanging(value);
					this.SendPropertyChanging();
					this._OrganisationId = value;
					this.SendPropertyChanged("OrganisationId");
					this.OnOrganisationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NickName", DbType="NVarChar(150)")]
		public string NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				if ((this._NickName != value))
				{
					this.OnNickNameChanging(value);
					this.SendPropertyChanging();
					this._NickName = value;
					this.SendPropertyChanged("NickName");
					this.OnNickNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Department", DbType="NVarChar(50)")]
		public string Department
		{
			get
			{
				return this._Department;
			}
			set
			{
				if ((this._Department != value))
				{
					this.OnDepartmentChanging(value);
					this.SendPropertyChanging();
					this._Department = value;
					this.SendPropertyChanged("Department");
					this.OnDepartmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
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
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OrganisationHolidays")]
	public partial class OrganisationHoliday : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Guid _OrganisationId;
		
		private string _Name;
		
		private System.DateTime _Date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOrganisationIdChanging(System.Guid value);
    partial void OnOrganisationIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    #endregion
		
		public OrganisationHoliday()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrganisationId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid OrganisationId
		{
			get
			{
				return this._OrganisationId;
			}
			set
			{
				if ((this._OrganisationId != value))
				{
					this.OnOrganisationIdChanging(value);
					this.SendPropertyChanging();
					this._OrganisationId = value;
					this.SendPropertyChanged("OrganisationId");
					this.OnOrganisationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
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
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tournaments")]
	public partial class Tournament : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _OrganisationId;
		
		private string _TournamentName;
		
		private string _Abstract;
		
		private string _Locations;
		
		private int _NumberOfPlayersLimit;
		
		private System.Nullable<int> _GameId;
		
		private string _MatchingAlgo;
		
		private int _TimeWindowStart;
		
		private int _TimeWindowEnd;
		
		private System.Nullable<bool> _IsOpenAllDay;
		
		private string _FirstPrize;
		
		private string _SecondPrize;
		
		private string _ThirdPrize;
		
		private System.DateTime _LastRegistrationDate;
		
		private System.DateTime _StartDate;
		
		private string _EmailTemplate;
		
		private bool _IsTournamentOver;
		
		private System.DateTime _DateCreated;
		
		private EntitySet<TournamentMatchup> _TournamentMatchups;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnOrganisationIdChanging(System.Guid value);
    partial void OnOrganisationIdChanged();
    partial void OnTournamentNameChanging(string value);
    partial void OnTournamentNameChanged();
    partial void OnAbstractChanging(string value);
    partial void OnAbstractChanged();
    partial void OnLocationsChanging(string value);
    partial void OnLocationsChanged();
    partial void OnNumberOfPlayersLimitChanging(int value);
    partial void OnNumberOfPlayersLimitChanged();
    partial void OnGameIdChanging(System.Nullable<int> value);
    partial void OnGameIdChanged();
    partial void OnMatchingAlgoChanging(string value);
    partial void OnMatchingAlgoChanged();
    partial void OnTimeWindowStartChanging(int value);
    partial void OnTimeWindowStartChanged();
    partial void OnTimeWindowEndChanging(int value);
    partial void OnTimeWindowEndChanged();
    partial void OnIsOpenAllDayChanging(System.Nullable<bool> value);
    partial void OnIsOpenAllDayChanged();
    partial void OnFirstPrizeChanging(string value);
    partial void OnFirstPrizeChanged();
    partial void OnSecondPrizeChanging(string value);
    partial void OnSecondPrizeChanged();
    partial void OnThirdPrizeChanging(string value);
    partial void OnThirdPrizeChanged();
    partial void OnLastRegistrationDateChanging(System.DateTime value);
    partial void OnLastRegistrationDateChanged();
    partial void OnStartDateChanging(System.DateTime value);
    partial void OnStartDateChanged();
    partial void OnEmailTemplateChanging(string value);
    partial void OnEmailTemplateChanged();
    partial void OnIsTournamentOverChanging(bool value);
    partial void OnIsTournamentOverChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public Tournament()
		{
			this._TournamentMatchups = new EntitySet<TournamentMatchup>(new Action<TournamentMatchup>(this.attach_TournamentMatchups), new Action<TournamentMatchup>(this.detach_TournamentMatchups));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrganisationId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid OrganisationId
		{
			get
			{
				return this._OrganisationId;
			}
			set
			{
				if ((this._OrganisationId != value))
				{
					this.OnOrganisationIdChanging(value);
					this.SendPropertyChanging();
					this._OrganisationId = value;
					this.SendPropertyChanged("OrganisationId");
					this.OnOrganisationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TournamentName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TournamentName
		{
			get
			{
				return this._TournamentName;
			}
			set
			{
				if ((this._TournamentName != value))
				{
					this.OnTournamentNameChanging(value);
					this.SendPropertyChanging();
					this._TournamentName = value;
					this.SendPropertyChanged("TournamentName");
					this.OnTournamentNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Abstract", DbType="NVarChar(250)")]
		public string Abstract
		{
			get
			{
				return this._Abstract;
			}
			set
			{
				if ((this._Abstract != value))
				{
					this.OnAbstractChanging(value);
					this.SendPropertyChanging();
					this._Abstract = value;
					this.SendPropertyChanged("Abstract");
					this.OnAbstractChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Locations", DbType="NVarChar(50)")]
		public string Locations
		{
			get
			{
				return this._Locations;
			}
			set
			{
				if ((this._Locations != value))
				{
					this.OnLocationsChanging(value);
					this.SendPropertyChanging();
					this._Locations = value;
					this.SendPropertyChanged("Locations");
					this.OnLocationsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumberOfPlayersLimit", DbType="Int NOT NULL")]
		public int NumberOfPlayersLimit
		{
			get
			{
				return this._NumberOfPlayersLimit;
			}
			set
			{
				if ((this._NumberOfPlayersLimit != value))
				{
					this.OnNumberOfPlayersLimitChanging(value);
					this.SendPropertyChanging();
					this._NumberOfPlayersLimit = value;
					this.SendPropertyChanged("NumberOfPlayersLimit");
					this.OnNumberOfPlayersLimitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameId", DbType="Int")]
		public System.Nullable<int> GameId
		{
			get
			{
				return this._GameId;
			}
			set
			{
				if ((this._GameId != value))
				{
					this.OnGameIdChanging(value);
					this.SendPropertyChanging();
					this._GameId = value;
					this.SendPropertyChanged("GameId");
					this.OnGameIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatchingAlgo", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MatchingAlgo
		{
			get
			{
				return this._MatchingAlgo;
			}
			set
			{
				if ((this._MatchingAlgo != value))
				{
					this.OnMatchingAlgoChanging(value);
					this.SendPropertyChanging();
					this._MatchingAlgo = value;
					this.SendPropertyChanged("MatchingAlgo");
					this.OnMatchingAlgoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeWindowStart", DbType="Int NOT NULL")]
		public int TimeWindowStart
		{
			get
			{
				return this._TimeWindowStart;
			}
			set
			{
				if ((this._TimeWindowStart != value))
				{
					this.OnTimeWindowStartChanging(value);
					this.SendPropertyChanging();
					this._TimeWindowStart = value;
					this.SendPropertyChanged("TimeWindowStart");
					this.OnTimeWindowStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeWindowEnd", DbType="Int NOT NULL")]
		public int TimeWindowEnd
		{
			get
			{
				return this._TimeWindowEnd;
			}
			set
			{
				if ((this._TimeWindowEnd != value))
				{
					this.OnTimeWindowEndChanging(value);
					this.SendPropertyChanging();
					this._TimeWindowEnd = value;
					this.SendPropertyChanged("TimeWindowEnd");
					this.OnTimeWindowEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsOpenAllDay", DbType="Bit")]
		public System.Nullable<bool> IsOpenAllDay
		{
			get
			{
				return this._IsOpenAllDay;
			}
			set
			{
				if ((this._IsOpenAllDay != value))
				{
					this.OnIsOpenAllDayChanging(value);
					this.SendPropertyChanging();
					this._IsOpenAllDay = value;
					this.SendPropertyChanged("IsOpenAllDay");
					this.OnIsOpenAllDayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstPrize", DbType="NVarChar(150)")]
		public string FirstPrize
		{
			get
			{
				return this._FirstPrize;
			}
			set
			{
				if ((this._FirstPrize != value))
				{
					this.OnFirstPrizeChanging(value);
					this.SendPropertyChanging();
					this._FirstPrize = value;
					this.SendPropertyChanged("FirstPrize");
					this.OnFirstPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecondPrize", DbType="NVarChar(150)")]
		public string SecondPrize
		{
			get
			{
				return this._SecondPrize;
			}
			set
			{
				if ((this._SecondPrize != value))
				{
					this.OnSecondPrizeChanging(value);
					this.SendPropertyChanging();
					this._SecondPrize = value;
					this.SendPropertyChanged("SecondPrize");
					this.OnSecondPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThirdPrize", DbType="NVarChar(150)")]
		public string ThirdPrize
		{
			get
			{
				return this._ThirdPrize;
			}
			set
			{
				if ((this._ThirdPrize != value))
				{
					this.OnThirdPrizeChanging(value);
					this.SendPropertyChanging();
					this._ThirdPrize = value;
					this.SendPropertyChanged("ThirdPrize");
					this.OnThirdPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastRegistrationDate", DbType="DateTime NOT NULL")]
		public System.DateTime LastRegistrationDate
		{
			get
			{
				return this._LastRegistrationDate;
			}
			set
			{
				if ((this._LastRegistrationDate != value))
				{
					this.OnLastRegistrationDateChanging(value);
					this.SendPropertyChanging();
					this._LastRegistrationDate = value;
					this.SendPropertyChanged("LastRegistrationDate");
					this.OnLastRegistrationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL")]
		public System.DateTime StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if ((this._StartDate != value))
				{
					this.OnStartDateChanging(value);
					this.SendPropertyChanging();
					this._StartDate = value;
					this.SendPropertyChanged("StartDate");
					this.OnStartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailTemplate", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string EmailTemplate
		{
			get
			{
				return this._EmailTemplate;
			}
			set
			{
				if ((this._EmailTemplate != value))
				{
					this.OnEmailTemplateChanging(value);
					this.SendPropertyChanging();
					this._EmailTemplate = value;
					this.SendPropertyChanged("EmailTemplate");
					this.OnEmailTemplateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsTournamentOver", DbType="Bit NOT NULL")]
		public bool IsTournamentOver
		{
			get
			{
				return this._IsTournamentOver;
			}
			set
			{
				if ((this._IsTournamentOver != value))
				{
					this.OnIsTournamentOverChanging(value);
					this.SendPropertyChanging();
					this._IsTournamentOver = value;
					this.SendPropertyChanged("IsTournamentOver");
					this.OnIsTournamentOverChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tournament_TournamentMatchup", Storage="_TournamentMatchups", ThisKey="Id", OtherKey="TournamentId")]
		public EntitySet<TournamentMatchup> TournamentMatchups
		{
			get
			{
				return this._TournamentMatchups;
			}
			set
			{
				this._TournamentMatchups.Assign(value);
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
		
		private void attach_TournamentMatchups(TournamentMatchup entity)
		{
			this.SendPropertyChanging();
			entity.Tournament = this;
		}
		
		private void detach_TournamentMatchups(TournamentMatchup entity)
		{
			this.SendPropertyChanging();
			entity.Tournament = null;
		}
	}
}
#pragma warning restore 1591