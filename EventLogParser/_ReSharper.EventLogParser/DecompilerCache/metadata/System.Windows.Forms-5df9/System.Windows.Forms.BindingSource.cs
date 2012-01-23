// Type: System.Windows.Forms.BindingSource
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;

namespace System.Windows.Forms
{
    [DefaultProperty("DataSource")]
    [DefaultEvent("CurrentChanged")]
    [ComplexBindingProperties("DataSource", "DataMember")]
    [Designer(
        "System.Windows.Forms.Design.BindingSourceDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    public class BindingSource : Component, IBindingListView, IBindingList, IList, ICollection, IEnumerable, ITypedList,
                                 ICancelAddNew, ISupportInitializeNotification, ISupportInitialize,
                                 ICurrencyManagerProvider
    {
        public BindingSource();
        public BindingSource(object dataSource, string dataMember);
        public BindingSource(IContainer container);

        [Browsable(false)]
        public object Current { get; }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Editor(
            "System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [DefaultValue("")]
        public string DataMember { get; set; }

        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof (IListSource))]
        public object DataSource { get; set; }

        [Browsable(false)]
        public bool IsBindingSuspended { get; }

        [Browsable(false)]
        public IList List { get; }

        [DefaultValue(-1)]
        [Browsable(false)]
        public int Position { get; set; }

        [DefaultValue(true)]
        [Browsable(false)]
        public bool RaiseListChangedEvents { get; set; }

        [DefaultValue(null)]
        public string Sort { get; set; }

        #region IBindingListView Members

        public virtual IEnumerator GetEnumerator();
        public virtual void CopyTo(Array arr, int index);
        public virtual int Add(object value);
        public virtual void Clear();
        public virtual bool Contains(object value);
        public virtual int IndexOf(object value);
        public virtual void Insert(int index, object value);
        public virtual void Remove(object value);
        public virtual void RemoveAt(int index);
        public virtual object AddNew();
        void IBindingList.AddIndex(PropertyDescriptor property);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ApplySort(PropertyDescriptor property, ListSortDirection sort);

        public virtual int Find(PropertyDescriptor prop, object key);
        void IBindingList.RemoveIndex(PropertyDescriptor prop);
        public virtual void RemoveSort();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ApplySort(ListSortDescriptionCollection sorts);

        public virtual void RemoveFilter();

        [Browsable(false)]
        public virtual int Count { get; }

        [Browsable(false)]
        public virtual bool IsSynchronized { get; }

        [Browsable(false)]
        public virtual object SyncRoot { get; }

        [Browsable(false)]
        public virtual object this[int index] { get; set; }

        [Browsable(false)]
        public virtual bool IsFixedSize { get; }

        [Browsable(false)]
        public virtual bool IsReadOnly { get; }

        [Browsable(false)]
        public virtual bool AllowEdit { get; }

        public virtual bool AllowNew { get; set; }

        [Browsable(false)]
        public virtual bool AllowRemove { get; }

        [Browsable(false)]
        public virtual bool SupportsChangeNotification { get; }

        [Browsable(false)]
        public virtual bool SupportsSearching { get; }

        [Browsable(false)]
        public virtual bool SupportsSorting { get; }

        [Browsable(false)]
        public virtual bool IsSorted { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual PropertyDescriptor SortProperty { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual ListSortDirection SortDirection { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ListSortDescriptionCollection SortDescriptions { get; }

        [DefaultValue(null)]
        public virtual string Filter { get; set; }

        [Browsable(false)]
        public virtual bool SupportsAdvancedSorting { get; }

        [Browsable(false)]
        public virtual bool SupportsFiltering { get; }

        public event ListChangedEventHandler ListChanged;

        #endregion

        #region ICancelAddNew Members

        void ICancelAddNew.CancelNew(int position);
        void ICancelAddNew.EndNew(int position);

        #endregion

        #region ICurrencyManagerProvider Members

        public virtual CurrencyManager GetRelatedCurrencyManager(string dataMember);

        [Browsable(false)]
        public virtual CurrencyManager CurrencyManager { get; }

        #endregion

        #region ISupportInitializeNotification Members

        void ISupportInitialize.BeginInit();
        void ISupportInitialize.EndInit();
        bool ISupportInitializeNotification.IsInitialized { get; }
        event EventHandler ISupportInitializeNotification.Initialized;

        #endregion

        #region ITypedList Members

        public virtual string GetListName(PropertyDescriptor[] listAccessors);
        public virtual PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors);

        #endregion

        public void CancelEdit();
        protected override void Dispose(bool disposing);
        public void EndEdit();
        public int Find(string propertyName, object key);
        public void MoveFirst();
        public void MoveLast();
        public void MoveNext();
        public void MovePrevious();
        protected virtual void OnAddingNew(AddingNewEventArgs e);
        protected virtual void OnBindingComplete(BindingCompleteEventArgs e);
        protected virtual void OnCurrentChanged(EventArgs e);
        protected virtual void OnCurrentItemChanged(EventArgs e);
        protected virtual void OnDataError(BindingManagerDataErrorEventArgs e);
        protected virtual void OnDataMemberChanged(EventArgs e);
        protected virtual void OnDataSourceChanged(EventArgs e);
        protected virtual void OnListChanged(ListChangedEventArgs e);
        protected virtual void OnPositionChanged(EventArgs e);
        public void RemoveCurrent();

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual void ResetAllowNew();

        public void ResetBindings(bool metadataChanged);
        public void ResetCurrentItem();
        public void ResetItem(int itemIndex);
        public void ResumeBinding();
        public void SuspendBinding();

        public event AddingNewEventHandler AddingNew;
        public event BindingCompleteEventHandler BindingComplete;
        public event BindingManagerDataErrorEventHandler DataError;
        public event EventHandler DataSourceChanged;
        public event EventHandler DataMemberChanged;
        public event EventHandler CurrentChanged;
        public event EventHandler CurrentItemChanged;
        public event EventHandler PositionChanged;
    }
}
