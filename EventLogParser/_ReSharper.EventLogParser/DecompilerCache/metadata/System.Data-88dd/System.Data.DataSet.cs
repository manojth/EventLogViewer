// Type: System.Data.DataSet
// Assembly: System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Data
{
    [DefaultProperty("DataSetName")]
    [ToolboxItem(
        "Microsoft.VSDesigner.Data.VS.DataSetToolboxItem, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    [XmlSchemaProvider("GetDataSetSchema")]
    [Designer(
        "Microsoft.VSDesigner.Data.VS.DataSetDesigner, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    [XmlRoot("DataSet")]
    [Serializable]
    public class DataSet : MarshalByValueComponent, IListSource, IXmlSerializable, ISupportInitializeNotification,
                           ISupportInitialize, ISerializable
    {
        public DataSet();
        public DataSet(string dataSetName);
        protected DataSet(SerializationInfo info, StreamingContext context);
        protected DataSet(SerializationInfo info, StreamingContext context, bool ConstructSchema);

        [DefaultValue(0)]
        public SerializationFormat RemotingFormat { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual SchemaSerializationMode SchemaSerializationMode { get; set; }

        [DefaultValue(false)]
        public bool CaseSensitive { get; set; }

        [Browsable(false)]
        public DataViewManager DefaultViewManager { get; }

        [DefaultValue(true)]
        public bool EnforceConstraints { get; set; }

        [DefaultValue("")]
        public string DataSetName { get; set; }

        [DefaultValue("")]
        public string Namespace { get; set; }

        [DefaultValue("")]
        public string Prefix { get; set; }

        [Browsable(false)]
        public PropertyCollection ExtendedProperties { get; }

        [Browsable(false)]
        public bool HasErrors { get; }

        public CultureInfo Locale { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ISite Site { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataRelationCollection Relations { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataTableCollection Tables { get; }

        #region IListSource Members

        IList IListSource.GetList();
        bool IListSource.ContainsListCollection { get; }

        #endregion

        #region ISerializable Members

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context);

        #endregion

        #region ISupportInitializeNotification Members

        public void BeginInit();
        public void EndInit();

        [Browsable(false)]
        public bool IsInitialized { get; }

        public event EventHandler Initialized;

        #endregion

        #region IXmlSerializable Members

        XmlSchema IXmlSerializable.GetSchema();
        void IXmlSerializable.ReadXml(XmlReader reader);
        void IXmlSerializable.WriteXml(XmlWriter writer);

        #endregion

        protected bool IsBinarySerialized(SerializationInfo info, StreamingContext context);

        protected SchemaSerializationMode DetermineSchemaSerializationMode(SerializationInfo info,
                                                                           StreamingContext context);

        protected SchemaSerializationMode DetermineSchemaSerializationMode(XmlReader reader);
        protected void GetSerializationData(SerializationInfo info, StreamingContext context);
        protected virtual void InitializeDerivedDataSet();
        protected virtual bool ShouldSerializeRelations();
        protected virtual bool ShouldSerializeTables();
        public void AcceptChanges();
        public void Clear();
        public virtual DataSet Clone();
        public DataSet Copy();
        public DataSet GetChanges();
        public DataSet GetChanges(DataRowState rowStates);
        public string GetXml();
        public string GetXmlSchema();
        public bool HasChanges();
        public bool HasChanges(DataRowState rowStates);
        public void InferXmlSchema(XmlReader reader, string[] nsArray);
        public void InferXmlSchema(Stream stream, string[] nsArray);
        public void InferXmlSchema(TextReader reader, string[] nsArray);
        public void InferXmlSchema(string fileName, string[] nsArray);
        public void ReadXmlSchema(XmlReader reader);
        public void ReadXmlSchema(Stream stream);
        public void ReadXmlSchema(TextReader reader);
        public void ReadXmlSchema(string fileName);
        public void WriteXmlSchema(Stream stream);
        public void WriteXmlSchema(TextWriter writer);
        public void WriteXmlSchema(XmlWriter writer);
        public void WriteXmlSchema(string fileName);
        public XmlReadMode ReadXml(XmlReader reader);
        public XmlReadMode ReadXml(Stream stream);
        public XmlReadMode ReadXml(TextReader reader);
        public XmlReadMode ReadXml(string fileName);
        public XmlReadMode ReadXml(XmlReader reader, XmlReadMode mode);
        public XmlReadMode ReadXml(Stream stream, XmlReadMode mode);
        public XmlReadMode ReadXml(TextReader reader, XmlReadMode mode);
        public XmlReadMode ReadXml(string fileName, XmlReadMode mode);
        public void WriteXml(Stream stream);
        public void WriteXml(TextWriter writer);
        public void WriteXml(XmlWriter writer);
        public void WriteXml(string fileName);
        public void WriteXml(Stream stream, XmlWriteMode mode);
        public void WriteXml(TextWriter writer, XmlWriteMode mode);
        public void WriteXml(XmlWriter writer, XmlWriteMode mode);
        public void WriteXml(string fileName, XmlWriteMode mode);
        public void Merge(DataSet dataSet);
        public void Merge(DataSet dataSet, bool preserveChanges);
        public void Merge(DataSet dataSet, bool preserveChanges, MissingSchemaAction missingSchemaAction);
        public void Merge(DataTable table);
        public void Merge(DataTable table, bool preserveChanges, MissingSchemaAction missingSchemaAction);
        public void Merge(DataRow[] rows);
        public void Merge(DataRow[] rows, bool preserveChanges, MissingSchemaAction missingSchemaAction);
        protected virtual void OnPropertyChanging(PropertyChangedEventArgs pcevent);
        protected internal virtual void OnRemoveTable(DataTable table);
        protected virtual void OnRemoveRelation(DataRelation relation);
        protected internal void RaisePropertyChanging(string name);
        public virtual void RejectChanges();
        public virtual void Reset();
        protected virtual void ReadXmlSerializable(XmlReader reader);
        protected virtual XmlSchema GetSchemaSerializable();
        public static XmlSchemaComplexType GetDataSetSchema(XmlSchemaSet schemaSet);

        public virtual void Load(IDataReader reader, LoadOption loadOption, FillErrorEventHandler errorHandler,
                                 params DataTable[] tables);

        public void Load(IDataReader reader, LoadOption loadOption, params DataTable[] tables);
        public void Load(IDataReader reader, LoadOption loadOption, params string[] tables);
        public DataTableReader CreateDataReader();
        public DataTableReader CreateDataReader(params DataTable[] dataTables);

        public event MergeFailedEventHandler MergeFailed;
    }
}
