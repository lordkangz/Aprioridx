﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.209
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=1.0.3705.209.
// 
namespace VISUAL_BASIC_DATA_MINING_NET {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class NorthwindDataSchema : DataSet {
        
        private ProductsTableDataTable tableProductsTable;
        
        private OrdersTableDataTable tableOrdersTable;
        
        private OrderDetailsTableDataTable tableOrderDetailsTable;
        
        public NorthwindDataSchema() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected NorthwindDataSchema(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["ProductsTable"] != null)) {
                    this.Tables.Add(new ProductsTableDataTable(ds.Tables["ProductsTable"]));
                }
                if ((ds.Tables["OrdersTable"] != null)) {
                    this.Tables.Add(new OrdersTableDataTable(ds.Tables["OrdersTable"]));
                }
                if ((ds.Tables["OrderDetailsTable"] != null)) {
                    this.Tables.Add(new OrderDetailsTableDataTable(ds.Tables["OrderDetailsTable"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ProductsTableDataTable ProductsTable {
            get {
                return this.tableProductsTable;
            }
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public OrdersTableDataTable OrdersTable {
            get {
                return this.tableOrdersTable;
            }
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public OrderDetailsTableDataTable OrderDetailsTable {
            get {
                return this.tableOrderDetailsTable;
            }
        }
        
        public override DataSet Clone() {
            NorthwindDataSchema cln = ((NorthwindDataSchema)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["ProductsTable"] != null)) {
                this.Tables.Add(new ProductsTableDataTable(ds.Tables["ProductsTable"]));
            }
            if ((ds.Tables["OrdersTable"] != null)) {
                this.Tables.Add(new OrdersTableDataTable(ds.Tables["OrdersTable"]));
            }
            if ((ds.Tables["OrderDetailsTable"] != null)) {
                this.Tables.Add(new OrderDetailsTableDataTable(ds.Tables["OrderDetailsTable"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableProductsTable = ((ProductsTableDataTable)(this.Tables["ProductsTable"]));
            if ((this.tableProductsTable != null)) {
                this.tableProductsTable.InitVars();
            }
            this.tableOrdersTable = ((OrdersTableDataTable)(this.Tables["OrdersTable"]));
            if ((this.tableOrdersTable != null)) {
                this.tableOrdersTable.InitVars();
            }
            this.tableOrderDetailsTable = ((OrderDetailsTableDataTable)(this.Tables["OrderDetailsTable"]));
            if ((this.tableOrderDetailsTable != null)) {
                this.tableOrderDetailsTable.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "NorthwindDataSchema";
            this.Prefix = "";
            this.Namespace = "";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableProductsTable = new ProductsTableDataTable();
            this.Tables.Add(this.tableProductsTable);
            this.tableOrdersTable = new OrdersTableDataTable();
            this.Tables.Add(this.tableOrdersTable);
            this.tableOrderDetailsTable = new OrderDetailsTableDataTable();
            this.Tables.Add(this.tableOrderDetailsTable);
        }
        
        private bool ShouldSerializeProductsTable() {
            return false;
        }
        
        private bool ShouldSerializeOrdersTable() {
            return false;
        }
        
        private bool ShouldSerializeOrderDetailsTable() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void ProductsTableRowChangeEventHandler(object sender, ProductsTableRowChangeEvent e);
        
        public delegate void OrdersTableRowChangeEventHandler(object sender, OrdersTableRowChangeEvent e);
        
        public delegate void OrderDetailsTableRowChangeEventHandler(object sender, OrderDetailsTableRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ProductsTableDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnProductID;
            
            private DataColumn columnProductName;
            
            internal ProductsTableDataTable() : 
                    base("ProductsTable") {
                this.InitClass();
            }
            
            internal ProductsTableDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn ProductIDColumn {
                get {
                    return this.columnProductID;
                }
            }
            
            internal DataColumn ProductNameColumn {
                get {
                    return this.columnProductName;
                }
            }
            
            public ProductsTableRow this[int index] {
                get {
                    return ((ProductsTableRow)(this.Rows[index]));
                }
            }
            
            public event ProductsTableRowChangeEventHandler ProductsTableRowChanged;
            
            public event ProductsTableRowChangeEventHandler ProductsTableRowChanging;
            
            public event ProductsTableRowChangeEventHandler ProductsTableRowDeleted;
            
            public event ProductsTableRowChangeEventHandler ProductsTableRowDeleting;
            
            public void AddProductsTableRow(ProductsTableRow row) {
                this.Rows.Add(row);
            }
            
            public ProductsTableRow AddProductsTableRow(int ProductID, string ProductName) {
                ProductsTableRow rowProductsTableRow = ((ProductsTableRow)(this.NewRow()));
                rowProductsTableRow.ItemArray = new object[] {
                        ProductID,
                        ProductName};
                this.Rows.Add(rowProductsTableRow);
                return rowProductsTableRow;
            }
            
            public ProductsTableRow FindByProductID(int ProductID) {
                return ((ProductsTableRow)(this.Rows.Find(new object[] {
                            ProductID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                ProductsTableDataTable cln = ((ProductsTableDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new ProductsTableDataTable();
            }
            
            internal void InitVars() {
                this.columnProductID = this.Columns["ProductID"];
                this.columnProductName = this.Columns["ProductName"];
            }
            
            private void InitClass() {
                this.columnProductID = new DataColumn("ProductID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnProductID);
                this.columnProductName = new DataColumn("ProductName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnProductName);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnProductID}, true));
                this.columnProductID.AllowDBNull = false;
                this.columnProductID.Unique = true;
            }
            
            public ProductsTableRow NewProductsTableRow() {
                return ((ProductsTableRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new ProductsTableRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(ProductsTableRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.ProductsTableRowChanged != null)) {
                    this.ProductsTableRowChanged(this, new ProductsTableRowChangeEvent(((ProductsTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.ProductsTableRowChanging != null)) {
                    this.ProductsTableRowChanging(this, new ProductsTableRowChangeEvent(((ProductsTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.ProductsTableRowDeleted != null)) {
                    this.ProductsTableRowDeleted(this, new ProductsTableRowChangeEvent(((ProductsTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.ProductsTableRowDeleting != null)) {
                    this.ProductsTableRowDeleting(this, new ProductsTableRowChangeEvent(((ProductsTableRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveProductsTableRow(ProductsTableRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ProductsTableRow : DataRow {
            
            private ProductsTableDataTable tableProductsTable;
            
            internal ProductsTableRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableProductsTable = ((ProductsTableDataTable)(this.Table));
            }
            
            public int ProductID {
                get {
                    return ((int)(this[this.tableProductsTable.ProductIDColumn]));
                }
                set {
                    this[this.tableProductsTable.ProductIDColumn] = value;
                }
            }
            
            public string ProductName {
                get {
                    try {
                        return ((string)(this[this.tableProductsTable.ProductNameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableProductsTable.ProductNameColumn] = value;
                }
            }
            
            public bool IsProductNameNull() {
                return this.IsNull(this.tableProductsTable.ProductNameColumn);
            }
            
            public void SetProductNameNull() {
                this[this.tableProductsTable.ProductNameColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ProductsTableRowChangeEvent : EventArgs {
            
            private ProductsTableRow eventRow;
            
            private DataRowAction eventAction;
            
            public ProductsTableRowChangeEvent(ProductsTableRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public ProductsTableRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrdersTableDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnOrderID;
            
            internal OrdersTableDataTable() : 
                    base("OrdersTable") {
                this.InitClass();
            }
            
            internal OrdersTableDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn OrderIDColumn {
                get {
                    return this.columnOrderID;
                }
            }
            
            public OrdersTableRow this[int index] {
                get {
                    return ((OrdersTableRow)(this.Rows[index]));
                }
            }
            
            public event OrdersTableRowChangeEventHandler OrdersTableRowChanged;
            
            public event OrdersTableRowChangeEventHandler OrdersTableRowChanging;
            
            public event OrdersTableRowChangeEventHandler OrdersTableRowDeleted;
            
            public event OrdersTableRowChangeEventHandler OrdersTableRowDeleting;
            
            public void AddOrdersTableRow(OrdersTableRow row) {
                this.Rows.Add(row);
            }
            
            public OrdersTableRow AddOrdersTableRow(int OrderID) {
                OrdersTableRow rowOrdersTableRow = ((OrdersTableRow)(this.NewRow()));
                rowOrdersTableRow.ItemArray = new object[] {
                        OrderID};
                this.Rows.Add(rowOrdersTableRow);
                return rowOrdersTableRow;
            }
            
            public OrdersTableRow FindByOrderID(int OrderID) {
                return ((OrdersTableRow)(this.Rows.Find(new object[] {
                            OrderID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                OrdersTableDataTable cln = ((OrdersTableDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new OrdersTableDataTable();
            }
            
            internal void InitVars() {
                this.columnOrderID = this.Columns["OrderID"];
            }
            
            private void InitClass() {
                this.columnOrderID = new DataColumn("OrderID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrderID);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnOrderID}, true));
                this.columnOrderID.AllowDBNull = false;
                this.columnOrderID.Unique = true;
            }
            
            public OrdersTableRow NewOrdersTableRow() {
                return ((OrdersTableRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new OrdersTableRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(OrdersTableRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.OrdersTableRowChanged != null)) {
                    this.OrdersTableRowChanged(this, new OrdersTableRowChangeEvent(((OrdersTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.OrdersTableRowChanging != null)) {
                    this.OrdersTableRowChanging(this, new OrdersTableRowChangeEvent(((OrdersTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.OrdersTableRowDeleted != null)) {
                    this.OrdersTableRowDeleted(this, new OrdersTableRowChangeEvent(((OrdersTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.OrdersTableRowDeleting != null)) {
                    this.OrdersTableRowDeleting(this, new OrdersTableRowChangeEvent(((OrdersTableRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveOrdersTableRow(OrdersTableRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrdersTableRow : DataRow {
            
            private OrdersTableDataTable tableOrdersTable;
            
            internal OrdersTableRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableOrdersTable = ((OrdersTableDataTable)(this.Table));
            }
            
            public int OrderID {
                get {
                    return ((int)(this[this.tableOrdersTable.OrderIDColumn]));
                }
                set {
                    this[this.tableOrdersTable.OrderIDColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrdersTableRowChangeEvent : EventArgs {
            
            private OrdersTableRow eventRow;
            
            private DataRowAction eventAction;
            
            public OrdersTableRowChangeEvent(OrdersTableRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public OrdersTableRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrderDetailsTableDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnProductID;
            
            private DataColumn columnOrderID;
            
            internal OrderDetailsTableDataTable() : 
                    base("OrderDetailsTable") {
                this.InitClass();
            }
            
            internal OrderDetailsTableDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn ProductIDColumn {
                get {
                    return this.columnProductID;
                }
            }
            
            internal DataColumn OrderIDColumn {
                get {
                    return this.columnOrderID;
                }
            }
            
            public OrderDetailsTableRow this[int index] {
                get {
                    return ((OrderDetailsTableRow)(this.Rows[index]));
                }
            }
            
            public event OrderDetailsTableRowChangeEventHandler OrderDetailsTableRowChanged;
            
            public event OrderDetailsTableRowChangeEventHandler OrderDetailsTableRowChanging;
            
            public event OrderDetailsTableRowChangeEventHandler OrderDetailsTableRowDeleted;
            
            public event OrderDetailsTableRowChangeEventHandler OrderDetailsTableRowDeleting;
            
            public void AddOrderDetailsTableRow(OrderDetailsTableRow row) {
                this.Rows.Add(row);
            }
            
            public OrderDetailsTableRow AddOrderDetailsTableRow(int ProductID, int OrderID) {
                OrderDetailsTableRow rowOrderDetailsTableRow = ((OrderDetailsTableRow)(this.NewRow()));
                rowOrderDetailsTableRow.ItemArray = new object[] {
                        ProductID,
                        OrderID};
                this.Rows.Add(rowOrderDetailsTableRow);
                return rowOrderDetailsTableRow;
            }
            
            public OrderDetailsTableRow FindByProductIDOrderID(int ProductID, int OrderID) {
                return ((OrderDetailsTableRow)(this.Rows.Find(new object[] {
                            ProductID,
                            OrderID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                OrderDetailsTableDataTable cln = ((OrderDetailsTableDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new OrderDetailsTableDataTable();
            }
            
            internal void InitVars() {
                this.columnProductID = this.Columns["ProductID"];
                this.columnOrderID = this.Columns["OrderID"];
            }
            
            private void InitClass() {
                this.columnProductID = new DataColumn("ProductID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnProductID);
                this.columnOrderID = new DataColumn("OrderID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrderID);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnProductID,
                                this.columnOrderID}, true));
                this.columnProductID.AllowDBNull = false;
                this.columnOrderID.AllowDBNull = false;
            }
            
            public OrderDetailsTableRow NewOrderDetailsTableRow() {
                return ((OrderDetailsTableRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new OrderDetailsTableRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(OrderDetailsTableRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.OrderDetailsTableRowChanged != null)) {
                    this.OrderDetailsTableRowChanged(this, new OrderDetailsTableRowChangeEvent(((OrderDetailsTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.OrderDetailsTableRowChanging != null)) {
                    this.OrderDetailsTableRowChanging(this, new OrderDetailsTableRowChangeEvent(((OrderDetailsTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.OrderDetailsTableRowDeleted != null)) {
                    this.OrderDetailsTableRowDeleted(this, new OrderDetailsTableRowChangeEvent(((OrderDetailsTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.OrderDetailsTableRowDeleting != null)) {
                    this.OrderDetailsTableRowDeleting(this, new OrderDetailsTableRowChangeEvent(((OrderDetailsTableRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveOrderDetailsTableRow(OrderDetailsTableRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrderDetailsTableRow : DataRow {
            
            private OrderDetailsTableDataTable tableOrderDetailsTable;
            
            internal OrderDetailsTableRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableOrderDetailsTable = ((OrderDetailsTableDataTable)(this.Table));
            }
            
            public int ProductID {
                get {
                    return ((int)(this[this.tableOrderDetailsTable.ProductIDColumn]));
                }
                set {
                    this[this.tableOrderDetailsTable.ProductIDColumn] = value;
                }
            }
            
            public int OrderID {
                get {
                    return ((int)(this[this.tableOrderDetailsTable.OrderIDColumn]));
                }
                set {
                    this[this.tableOrderDetailsTable.OrderIDColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrderDetailsTableRowChangeEvent : EventArgs {
            
            private OrderDetailsTableRow eventRow;
            
            private DataRowAction eventAction;
            
            public OrderDetailsTableRowChangeEvent(OrderDetailsTableRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public OrderDetailsTableRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}