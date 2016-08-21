﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JogoRest.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="JogosBD")]
	public partial class JogoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPlataforma(Plataforma instance);
    partial void UpdatePlataforma(Plataforma instance);
    partial void DeletePlataforma(Plataforma instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertGenero(Genero instance);
    partial void UpdateGenero(Genero instance);
    partial void DeleteGenero(Genero instance);
    partial void InsertJogo(Jogo instance);
    partial void UpdateJogo(Jogo instance);
    partial void DeleteJogo(Jogo instance);
    partial void InsertMeuJogo(MeuJogo instance);
    partial void UpdateMeuJogo(MeuJogo instance);
    partial void DeleteMeuJogo(MeuJogo instance);
    partial void InsertPlataformaJogo(PlataformaJogo instance);
    partial void UpdatePlataformaJogo(PlataformaJogo instance);
    partial void DeletePlataformaJogo(PlataformaJogo instance);
    #endregion
		
		public JogoDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["JogosBDConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public JogoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JogoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JogoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JogoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Plataforma> Plataformas
		{
			get
			{
				return this.GetTable<Plataforma>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuarios
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Genero> Generos
		{
			get
			{
				return this.GetTable<Genero>();
			}
		}
		
		public System.Data.Linq.Table<Jogo> Jogos
		{
			get
			{
				return this.GetTable<Jogo>();
			}
		}
		
		public System.Data.Linq.Table<MeuJogo> MeuJogos
		{
			get
			{
				return this.GetTable<MeuJogo>();
			}
		}
		
		public System.Data.Linq.Table<PlataformaJogo> PlataformaJogos
		{
			get
			{
				return this.GetTable<PlataformaJogo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Plataforma")]
	public partial class Plataforma : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Descricao;
		
		private EntitySet<PlataformaJogo> _PlataformaJogos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDescricaoChanging(string value);
    partial void OnDescricaoChanged();
    #endregion
		
		public Plataforma()
		{
			this._PlataformaJogos = new EntitySet<PlataformaJogo>(new Action<PlataformaJogo>(this.attach_PlataformaJogos), new Action<PlataformaJogo>(this.detach_PlataformaJogos));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descricao", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Descricao
		{
			get
			{
				return this._Descricao;
			}
			set
			{
				if ((this._Descricao != value))
				{
					this.OnDescricaoChanging(value);
					this.SendPropertyChanging();
					this._Descricao = value;
					this.SendPropertyChanged("Descricao");
					this.OnDescricaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Plataforma_PlataformaJogo", Storage="_PlataformaJogos", ThisKey="Id", OtherKey="IdPlataforma")]
		internal EntitySet<PlataformaJogo> PlataformaJogos
		{
			get
			{
				return this._PlataformaJogos;
			}
			set
			{
				this._PlataformaJogos.Assign(value);
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
		
		private void attach_PlataformaJogos(PlataformaJogo entity)
		{
			this.SendPropertyChanging();
			entity.Plataforma = this;
		}
		
		private void detach_PlataformaJogos(PlataformaJogo entity)
		{
			this.SendPropertyChanging();
			entity.Plataforma = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Nome;
		
		private string _Email;
		
		private string _Senha;
		
		private string _Imagem;
		
		private bool _EstaAutenticado;
		
		private EntitySet<MeuJogo> _MeuJogos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnSenhaChanging(string value);
    partial void OnSenhaChanged();
    partial void OnImagemChanging(string value);
    partial void OnImagemChanged();
    partial void OnEstaAutenticadoChanging(bool value);
    partial void OnEstaAutenticadoChanged();
    #endregion
		
		public Usuario()
		{
			this._MeuJogos = new EntitySet<MeuJogo>(new Action<MeuJogo>(this.attach_MeuJogos), new Action<MeuJogo>(this.detach_MeuJogos));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Senha", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Senha
		{
			get
			{
				return this._Senha;
			}
			set
			{
				if ((this._Senha != value))
				{
					this.OnSenhaChanging(value);
					this.SendPropertyChanging();
					this._Senha = value;
					this.SendPropertyChanged("Senha");
					this.OnSenhaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Imagem", DbType="VarChar(MAX)")]
		public string Imagem
		{
			get
			{
				return this._Imagem;
			}
			set
			{
				if ((this._Imagem != value))
				{
					this.OnImagemChanging(value);
					this.SendPropertyChanging();
					this._Imagem = value;
					this.SendPropertyChanged("Imagem");
					this.OnImagemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstaAutenticado", DbType="Bit NOT NULL")]
		public bool EstaAutenticado
		{
			get
			{
				return this._EstaAutenticado;
			}
			set
			{
				if ((this._EstaAutenticado != value))
				{
					this.OnEstaAutenticadoChanging(value);
					this.SendPropertyChanging();
					this._EstaAutenticado = value;
					this.SendPropertyChanged("EstaAutenticado");
					this.OnEstaAutenticadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_MeuJogo", Storage="_MeuJogos", ThisKey="Id", OtherKey="IdUsuario")]
		internal EntitySet<MeuJogo> MeuJogos
		{
			get
			{
				return this._MeuJogos;
			}
			set
			{
				this._MeuJogos.Assign(value);
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
		
		private void attach_MeuJogos(MeuJogo entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_MeuJogos(MeuJogo entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Genero")]
	public partial class Genero : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Descricao;
		
		private EntitySet<Jogo> _Jogos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDescricaoChanging(string value);
    partial void OnDescricaoChanged();
    #endregion
		
		public Genero()
		{
			this._Jogos = new EntitySet<Jogo>(new Action<Jogo>(this.attach_Jogos), new Action<Jogo>(this.detach_Jogos));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descricao", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Descricao
		{
			get
			{
				return this._Descricao;
			}
			set
			{
				if ((this._Descricao != value))
				{
					this.OnDescricaoChanging(value);
					this.SendPropertyChanging();
					this._Descricao = value;
					this.SendPropertyChanged("Descricao");
					this.OnDescricaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Genero_Jogo", Storage="_Jogos", ThisKey="Id", OtherKey="IdGenero")]
		internal EntitySet<Jogo> Jogos
		{
			get
			{
				return this._Jogos;
			}
			set
			{
				this._Jogos.Assign(value);
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
		
		private void attach_Jogos(Jogo entity)
		{
			this.SendPropertyChanging();
			entity.Genero = this;
		}
		
		private void detach_Jogos(Jogo entity)
		{
			this.SendPropertyChanging();
			entity.Genero = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Jogo")]
	public partial class Jogo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Nome;
		
		private string _Ano;
		
		private string _Sinopse;
		
		private string _Desenvolvedora;
		
		private string _NotaMedia;
		
		private string _Imagem;
		
		private int _IdGenero;
		
		private EntitySet<MeuJogo> _MeuJogos;
		
		private EntitySet<PlataformaJogo> _PlataformaJogos;
		
		private EntityRef<Genero> _Genero;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnAnoChanging(string value);
    partial void OnAnoChanged();
    partial void OnSinopseChanging(string value);
    partial void OnSinopseChanged();
    partial void OnDesenvolvedoraChanging(string value);
    partial void OnDesenvolvedoraChanged();
    partial void OnNotaMediaChanging(string value);
    partial void OnNotaMediaChanged();
    partial void OnImagemChanging(string value);
    partial void OnImagemChanged();
    partial void OnIdGeneroChanging(int value);
    partial void OnIdGeneroChanged();
    #endregion
		
		public Jogo()
		{
			this._MeuJogos = new EntitySet<MeuJogo>(new Action<MeuJogo>(this.attach_MeuJogos), new Action<MeuJogo>(this.detach_MeuJogos));
			this._PlataformaJogos = new EntitySet<PlataformaJogo>(new Action<PlataformaJogo>(this.attach_PlataformaJogos), new Action<PlataformaJogo>(this.detach_PlataformaJogos));
			this._Genero = default(EntityRef<Genero>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ano", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Ano
		{
			get
			{
				return this._Ano;
			}
			set
			{
				if ((this._Ano != value))
				{
					this.OnAnoChanging(value);
					this.SendPropertyChanging();
					this._Ano = value;
					this.SendPropertyChanged("Ano");
					this.OnAnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sinopse", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Sinopse
		{
			get
			{
				return this._Sinopse;
			}
			set
			{
				if ((this._Sinopse != value))
				{
					this.OnSinopseChanging(value);
					this.SendPropertyChanging();
					this._Sinopse = value;
					this.SendPropertyChanged("Sinopse");
					this.OnSinopseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Desenvolvedora", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Desenvolvedora
		{
			get
			{
				return this._Desenvolvedora;
			}
			set
			{
				if ((this._Desenvolvedora != value))
				{
					this.OnDesenvolvedoraChanging(value);
					this.SendPropertyChanging();
					this._Desenvolvedora = value;
					this.SendPropertyChanged("Desenvolvedora");
					this.OnDesenvolvedoraChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotaMedia", DbType="VarChar(50)")]
		public string NotaMedia
		{
			get
			{
				return this._NotaMedia;
			}
			set
			{
				if ((this._NotaMedia != value))
				{
					this.OnNotaMediaChanging(value);
					this.SendPropertyChanging();
					this._NotaMedia = value;
					this.SendPropertyChanged("NotaMedia");
					this.OnNotaMediaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Imagem", DbType="VarChar(MAX)")]
		public string Imagem
		{
			get
			{
				return this._Imagem;
			}
			set
			{
				if ((this._Imagem != value))
				{
					this.OnImagemChanging(value);
					this.SendPropertyChanging();
					this._Imagem = value;
					this.SendPropertyChanged("Imagem");
					this.OnImagemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdGenero", DbType="Int NOT NULL")]
		public int IdGenero
		{
			get
			{
				return this._IdGenero;
			}
			set
			{
				if ((this._IdGenero != value))
				{
					if (this._Genero.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdGeneroChanging(value);
					this.SendPropertyChanging();
					this._IdGenero = value;
					this.SendPropertyChanged("IdGenero");
					this.OnIdGeneroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Jogo_MeuJogo", Storage="_MeuJogos", ThisKey="Id", OtherKey="IdJogo")]
		internal EntitySet<MeuJogo> MeuJogos
		{
			get
			{
				return this._MeuJogos;
			}
			set
			{
				this._MeuJogos.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Jogo_PlataformaJogo", Storage="_PlataformaJogos", ThisKey="Id", OtherKey="IdJogo")]
		internal EntitySet<PlataformaJogo> PlataformaJogos
		{
			get
			{
				return this._PlataformaJogos;
			}
			set
			{
				this._PlataformaJogos.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Genero_Jogo", Storage="_Genero", ThisKey="IdGenero", OtherKey="Id", IsForeignKey=true)]
		internal Genero Genero
		{
			get
			{
				return this._Genero.Entity;
			}
			set
			{
				Genero previousValue = this._Genero.Entity;
				if (((previousValue != value) 
							|| (this._Genero.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Genero.Entity = null;
						previousValue.Jogos.Remove(this);
					}
					this._Genero.Entity = value;
					if ((value != null))
					{
						value.Jogos.Add(this);
						this._IdGenero = value.Id;
					}
					else
					{
						this._IdGenero = default(int);
					}
					this.SendPropertyChanged("Genero");
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
		
		private void attach_MeuJogos(MeuJogo entity)
		{
			this.SendPropertyChanging();
			entity.Jogo = this;
		}
		
		private void detach_MeuJogos(MeuJogo entity)
		{
			this.SendPropertyChanging();
			entity.Jogo = null;
		}
		
		private void attach_PlataformaJogos(PlataformaJogo entity)
		{
			this.SendPropertyChanging();
			entity.Jogo = this;
		}
		
		private void detach_PlataformaJogos(PlataformaJogo entity)
		{
			this.SendPropertyChanging();
			entity.Jogo = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MeuJogo")]
	public partial class MeuJogo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Status;
		
		private string _Comentario;
		
		private string _Classificacao;
		
		private int _IdJogo;
		
		private int _IdUsuario;
		
		private EntityRef<Jogo> _Jogo;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnComentarioChanging(string value);
    partial void OnComentarioChanged();
    partial void OnClassificacaoChanging(string value);
    partial void OnClassificacaoChanged();
    partial void OnIdJogoChanging(int value);
    partial void OnIdJogoChanged();
    partial void OnIdUsuarioChanging(int value);
    partial void OnIdUsuarioChanged();
    #endregion
		
		public MeuJogo()
		{
			this._Jogo = default(EntityRef<Jogo>);
			this._Usuario = default(EntityRef<Usuario>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comentario", DbType="VarChar(MAX)")]
		public string Comentario
		{
			get
			{
				return this._Comentario;
			}
			set
			{
				if ((this._Comentario != value))
				{
					this.OnComentarioChanging(value);
					this.SendPropertyChanging();
					this._Comentario = value;
					this.SendPropertyChanged("Comentario");
					this.OnComentarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Classificacao", DbType="VarChar(50)")]
		public string Classificacao
		{
			get
			{
				return this._Classificacao;
			}
			set
			{
				if ((this._Classificacao != value))
				{
					this.OnClassificacaoChanging(value);
					this.SendPropertyChanging();
					this._Classificacao = value;
					this.SendPropertyChanged("Classificacao");
					this.OnClassificacaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdJogo", DbType="Int NOT NULL")]
		public int IdJogo
		{
			get
			{
				return this._IdJogo;
			}
			set
			{
				if ((this._IdJogo != value))
				{
					if (this._Jogo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdJogoChanging(value);
					this.SendPropertyChanging();
					this._IdJogo = value;
					this.SendPropertyChanged("IdJogo");
					this.OnIdJogoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", DbType="Int NOT NULL")]
		public int IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdUsuarioChanging(value);
					this.SendPropertyChanging();
					this._IdUsuario = value;
					this.SendPropertyChanged("IdUsuario");
					this.OnIdUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Jogo_MeuJogo", Storage="_Jogo", ThisKey="IdJogo", OtherKey="Id", IsForeignKey=true)]
		internal Jogo Jogo
		{
			get
			{
				return this._Jogo.Entity;
			}
			set
			{
				Jogo previousValue = this._Jogo.Entity;
				if (((previousValue != value) 
							|| (this._Jogo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Jogo.Entity = null;
						previousValue.MeuJogos.Remove(this);
					}
					this._Jogo.Entity = value;
					if ((value != null))
					{
						value.MeuJogos.Add(this);
						this._IdJogo = value.Id;
					}
					else
					{
						this._IdJogo = default(int);
					}
					this.SendPropertyChanged("Jogo");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_MeuJogo", Storage="_Usuario", ThisKey="IdUsuario", OtherKey="Id", IsForeignKey=true)]
		internal Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.MeuJogos.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.MeuJogos.Add(this);
						this._IdUsuario = value.Id;
					}
					else
					{
						this._IdUsuario = default(int);
					}
					this.SendPropertyChanged("Usuario");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PlataformaJogo")]
	public partial class PlataformaJogo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdJogo;
		
		private int _IdPlataforma;
		
		private EntityRef<Jogo> _Jogo;
		
		private EntityRef<Plataforma> _Plataforma;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdJogoChanging(int value);
    partial void OnIdJogoChanged();
    partial void OnIdPlataformaChanging(int value);
    partial void OnIdPlataformaChanged();
    #endregion
		
		public PlataformaJogo()
		{
			this._Jogo = default(EntityRef<Jogo>);
			this._Plataforma = default(EntityRef<Plataforma>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdJogo", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdJogo
		{
			get
			{
				return this._IdJogo;
			}
			set
			{
				if ((this._IdJogo != value))
				{
					if (this._Jogo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdJogoChanging(value);
					this.SendPropertyChanging();
					this._IdJogo = value;
					this.SendPropertyChanged("IdJogo");
					this.OnIdJogoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdPlataforma", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdPlataforma
		{
			get
			{
				return this._IdPlataforma;
			}
			set
			{
				if ((this._IdPlataforma != value))
				{
					if (this._Plataforma.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdPlataformaChanging(value);
					this.SendPropertyChanging();
					this._IdPlataforma = value;
					this.SendPropertyChanged("IdPlataforma");
					this.OnIdPlataformaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Jogo_PlataformaJogo", Storage="_Jogo", ThisKey="IdJogo", OtherKey="Id", IsForeignKey=true)]
		internal Jogo Jogo
		{
			get
			{
				return this._Jogo.Entity;
			}
			set
			{
				Jogo previousValue = this._Jogo.Entity;
				if (((previousValue != value) 
							|| (this._Jogo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Jogo.Entity = null;
						previousValue.PlataformaJogos.Remove(this);
					}
					this._Jogo.Entity = value;
					if ((value != null))
					{
						value.PlataformaJogos.Add(this);
						this._IdJogo = value.Id;
					}
					else
					{
						this._IdJogo = default(int);
					}
					this.SendPropertyChanged("Jogo");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Plataforma_PlataformaJogo", Storage="_Plataforma", ThisKey="IdPlataforma", OtherKey="Id", IsForeignKey=true)]
		internal Plataforma Plataforma
		{
			get
			{
				return this._Plataforma.Entity;
			}
			set
			{
				Plataforma previousValue = this._Plataforma.Entity;
				if (((previousValue != value) 
							|| (this._Plataforma.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Plataforma.Entity = null;
						previousValue.PlataformaJogos.Remove(this);
					}
					this._Plataforma.Entity = value;
					if ((value != null))
					{
						value.PlataformaJogos.Add(this);
						this._IdPlataforma = value.Id;
					}
					else
					{
						this._IdPlataforma = default(int);
					}
					this.SendPropertyChanged("Plataforma");
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
}
#pragma warning restore 1591
