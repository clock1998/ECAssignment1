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

namespace Assignment1
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Assignment1")]
	public partial class ProductCatalogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    partial void InsertProduct_image(Product_image instance);
    partial void UpdateProduct_image(Product_image instance);
    partial void DeleteProduct_image(Product_image instance);
    #endregion
		
		public ProductCatalogDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Assignment1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ProductCatalogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProductCatalogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProductCatalogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProductCatalogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
		
		public System.Data.Linq.Table<Product_image> Product_images
		{
			get
			{
				return this.GetTable<Product_image>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _item;
		
		private System.Nullable<decimal> _price;
		
		private string _description;
		
		private string _shipping;
		
		private string _seller;
		
		private System.Nullable<int> _quantities;
		
		private string _specs;
		
		private System.Nullable<decimal> _handling;
		
		private EntitySet<Product_image> _Product_images;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnitemChanging(string value);
    partial void OnitemChanged();
    partial void OnpriceChanging(System.Nullable<decimal> value);
    partial void OnpriceChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnshippingChanging(string value);
    partial void OnshippingChanged();
    partial void OnsellerChanging(string value);
    partial void OnsellerChanged();
    partial void OnquantitiesChanging(System.Nullable<int> value);
    partial void OnquantitiesChanged();
    partial void OnspecsChanging(string value);
    partial void OnspecsChanged();
    partial void OnhandlingChanging(System.Nullable<decimal> value);
    partial void OnhandlingChanged();
    #endregion
		
		public Product()
		{
			this._Product_images = new EntitySet<Product_image>(new Action<Product_image>(this.attach_Product_images), new Action<Product_image>(this.detach_Product_images));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_item", DbType="NVarChar(MAX)")]
		public string item
		{
			get
			{
				return this._item;
			}
			set
			{
				if ((this._item != value))
				{
					this.OnitemChanging(value);
					this.SendPropertyChanging();
					this._item = value;
					this.SendPropertyChanged("item");
					this.OnitemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shipping", DbType="NVarChar(MAX)")]
		public string shipping
		{
			get
			{
				return this._shipping;
			}
			set
			{
				if ((this._shipping != value))
				{
					this.OnshippingChanging(value);
					this.SendPropertyChanging();
					this._shipping = value;
					this.SendPropertyChanged("shipping");
					this.OnshippingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_seller", DbType="NVarChar(MAX)")]
		public string seller
		{
			get
			{
				return this._seller;
			}
			set
			{
				if ((this._seller != value))
				{
					this.OnsellerChanging(value);
					this.SendPropertyChanging();
					this._seller = value;
					this.SendPropertyChanged("seller");
					this.OnsellerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quantities", DbType="Int")]
		public System.Nullable<int> quantities
		{
			get
			{
				return this._quantities;
			}
			set
			{
				if ((this._quantities != value))
				{
					this.OnquantitiesChanging(value);
					this.SendPropertyChanging();
					this._quantities = value;
					this.SendPropertyChanged("quantities");
					this.OnquantitiesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_specs", DbType="NVarChar(MAX)")]
		public string specs
		{
			get
			{
				return this._specs;
			}
			set
			{
				if ((this._specs != value))
				{
					this.OnspecsChanging(value);
					this.SendPropertyChanging();
					this._specs = value;
					this.SendPropertyChanged("specs");
					this.OnspecsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_handling", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> handling
		{
			get
			{
				return this._handling;
			}
			set
			{
				if ((this._handling != value))
				{
					this.OnhandlingChanging(value);
					this.SendPropertyChanging();
					this._handling = value;
					this.SendPropertyChanged("handling");
					this.OnhandlingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Product_image", Storage="_Product_images", ThisKey="Id", OtherKey="product_id")]
		public EntitySet<Product_image> Product_images
		{
			get
			{
				return this._Product_images;
			}
			set
			{
				this._Product_images.Assign(value);
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
		
		private void attach_Product_images(Product_image entity)
		{
			this.SendPropertyChanging();
			entity.Product = this;
		}
		
		private void detach_Product_images(Product_image entity)
		{
			this.SendPropertyChanging();
			entity.Product = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product_images")]
	public partial class Product_image : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _product_id;
		
		private string _description;
		
		private string _path;
		
		private EntityRef<Product> _Product;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onproduct_idChanging(int value);
    partial void Onproduct_idChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnpathChanging(string value);
    partial void OnpathChanged();
    #endregion
		
		public Product_image()
		{
			this._Product = default(EntityRef<Product>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_id", DbType="Int NOT NULL")]
		public int product_id
		{
			get
			{
				return this._product_id;
			}
			set
			{
				if ((this._product_id != value))
				{
					if (this._Product.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onproduct_idChanging(value);
					this.SendPropertyChanging();
					this._product_id = value;
					this.SendPropertyChanged("product_id");
					this.Onproduct_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_path", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string path
		{
			get
			{
				return this._path;
			}
			set
			{
				if ((this._path != value))
				{
					this.OnpathChanging(value);
					this.SendPropertyChanging();
					this._path = value;
					this.SendPropertyChanged("path");
					this.OnpathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Product_image", Storage="_Product", ThisKey="product_id", OtherKey="Id", IsForeignKey=true)]
		public Product Product
		{
			get
			{
				return this._Product.Entity;
			}
			set
			{
				Product previousValue = this._Product.Entity;
				if (((previousValue != value) 
							|| (this._Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product.Entity = null;
						previousValue.Product_images.Remove(this);
					}
					this._Product.Entity = value;
					if ((value != null))
					{
						value.Product_images.Add(this);
						this._product_id = value.Id;
					}
					else
					{
						this._product_id = default(int);
					}
					this.SendPropertyChanged("Product");
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
