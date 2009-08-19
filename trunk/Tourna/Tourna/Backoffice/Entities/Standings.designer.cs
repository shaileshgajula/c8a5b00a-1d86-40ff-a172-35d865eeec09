﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tourna.Backoffice.Entities
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="PiniTest")]
	public partial class StandingsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSchedule(Schedule instance);
    partial void UpdateSchedule(Schedule instance);
    partial void DeleteSchedule(Schedule instance);
    partial void InsertTournament(Tournament instance);
    partial void UpdateTournament(Tournament instance);
    partial void DeleteTournament(Tournament instance);
    #endregion
		
		public StandingsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public StandingsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StandingsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StandingsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StandingsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Schedule> Schedules
		{
			get
			{
				return this.GetTable<Schedule>();
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
	
	[Table(Name="dbo.Schedules")]
	public partial class Schedule : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Guid _TournamentId;
		
		private System.Guid _PlayerA;
		
		private System.Guid _PlayerB;
		
		private System.DateTime _Start;
		
		private System.DateTime _End;
		
		private System.Nullable<char> _Winner;
		
		private System.Nullable<int> _ScoreA;
		
		private System.Nullable<int> _ScoreB;
		
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
    partial void OnWinnerChanging(System.Nullable<char> value);
    partial void OnWinnerChanged();
    partial void OnScoreAChanging(System.Nullable<int> value);
    partial void OnScoreAChanged();
    partial void OnScoreBChanging(System.Nullable<int> value);
    partial void OnScoreBChanged();
    #endregion
		
		public Schedule()
		{
			this._Tournament = default(EntityRef<Tournament>);
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[Column(Storage="_TournamentId", DbType="UniqueIdentifier NOT NULL")]
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
		
		[Column(Storage="_PlayerA", DbType="UniqueIdentifier NOT NULL")]
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
		
		[Column(Storage="_PlayerB", DbType="UniqueIdentifier NOT NULL")]
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
		
		[Column(Storage="_Start", DbType="DateTime NOT NULL")]
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
		
		[Column(Name="[End]", Storage="_End", DbType="DateTime NOT NULL")]
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
		
		[Column(Storage="_Winner", DbType="Char(1)")]
		public System.Nullable<char> Winner
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
		
		[Column(Storage="_ScoreA", DbType="Int")]
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
		
		[Column(Storage="_ScoreB", DbType="Int")]
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
		
		[Association(Name="Tournament_Schedule", Storage="_Tournament", ThisKey="TournamentId", OtherKey="Id", IsForeignKey=true)]
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
						previousValue.Schedules.Remove(this);
					}
					this._Tournament.Entity = value;
					if ((value != null))
					{
						value.Schedules.Add(this);
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
	
	[Table(Name="dbo.Tournaments")]
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
		
		private System.Nullable<int> _TimeWindowStart;
		
		private System.Nullable<int> _TimeWindowEnd;
		
		private System.Nullable<bool> _IsOpenAllDay;
		
		private System.Nullable<int> _FirstPrize;
		
		private System.Nullable<int> _SecondPrize;
		
		private System.Nullable<int> _ThirdPrize;
		
		private System.Nullable<System.DateTime> _StartDate;
		
		private string _EmailTemplate;
		
		private bool _IsApproved;
		
		private EntitySet<Schedule> _Schedules;
		
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
    partial void OnTimeWindowStartChanging(System.Nullable<int> value);
    partial void OnTimeWindowStartChanged();
    partial void OnTimeWindowEndChanging(System.Nullable<int> value);
    partial void OnTimeWindowEndChanged();
    partial void OnIsOpenAllDayChanging(System.Nullable<bool> value);
    partial void OnIsOpenAllDayChanged();
    partial void OnFirstPrizeChanging(System.Nullable<int> value);
    partial void OnFirstPrizeChanged();
    partial void OnSecondPrizeChanging(System.Nullable<int> value);
    partial void OnSecondPrizeChanged();
    partial void OnThirdPrizeChanging(System.Nullable<int> value);
    partial void OnThirdPrizeChanged();
    partial void OnStartDateChanging(System.Nullable<System.DateTime> value);
    partial void OnStartDateChanged();
    partial void OnEmailTemplateChanging(string value);
    partial void OnEmailTemplateChanged();
    partial void OnIsApprovedChanging(bool value);
    partial void OnIsApprovedChanged();
    #endregion
		
		public Tournament()
		{
			this._Schedules = new EntitySet<Schedule>(new Action<Schedule>(this.attach_Schedules), new Action<Schedule>(this.detach_Schedules));
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
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
		
		[Column(Storage="_OrganisationId", DbType="UniqueIdentifier NOT NULL")]
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
		
		[Column(Storage="_TournamentName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[Column(Storage="_Abstract", DbType="NVarChar(250)")]
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
		
		[Column(Storage="_Locations", DbType="NVarChar(50)")]
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
		
		[Column(Storage="_NumberOfPlayersLimit", DbType="Int NOT NULL")]
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
		
		[Column(Storage="_GameId", DbType="Int")]
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
		
		[Column(Storage="_MatchingAlgo", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[Column(Storage="_TimeWindowStart", DbType="Int")]
		public System.Nullable<int> TimeWindowStart
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
		
		[Column(Storage="_TimeWindowEnd", DbType="Int")]
		public System.Nullable<int> TimeWindowEnd
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
		
		[Column(Storage="_IsOpenAllDay", DbType="Bit")]
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
		
		[Column(Storage="_FirstPrize", DbType="Int")]
		public System.Nullable<int> FirstPrize
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
		
		[Column(Storage="_SecondPrize", DbType="Int")]
		public System.Nullable<int> SecondPrize
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
		
		[Column(Storage="_ThirdPrize", DbType="Int")]
		public System.Nullable<int> ThirdPrize
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
		
		[Column(Storage="_StartDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> StartDate
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
		
		[Column(Storage="_EmailTemplate", DbType="Text", UpdateCheck=UpdateCheck.Never)]
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
		
		[Column(Storage="_IsApproved", DbType="Bit NOT NULL")]
		public bool IsApproved
		{
			get
			{
				return this._IsApproved;
			}
			set
			{
				if ((this._IsApproved != value))
				{
					this.OnIsApprovedChanging(value);
					this.SendPropertyChanging();
					this._IsApproved = value;
					this.SendPropertyChanged("IsApproved");
					this.OnIsApprovedChanged();
				}
			}
		}
		
		[Association(Name="Tournament_Schedule", Storage="_Schedules", ThisKey="Id", OtherKey="TournamentId")]
		public EntitySet<Schedule> Schedules
		{
			get
			{
				return this._Schedules;
			}
			set
			{
				this._Schedules.Assign(value);
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
		
		private void attach_Schedules(Schedule entity)
		{
			this.SendPropertyChanging();
			entity.Tournament = this;
		}
		
		private void detach_Schedules(Schedule entity)
		{
			this.SendPropertyChanging();
			entity.Tournament = null;
		}
	}
}
#pragma warning restore 1591