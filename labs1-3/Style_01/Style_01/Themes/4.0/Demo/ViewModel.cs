using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Demo
{
	public class ViewModel : System.ComponentModel.INotifyPropertyChanged
	{
		public ViewModel()
		{
			this.myViewModelSourceList = new List<DataGridCellInfo>();			

			this.PropertyChanged += (sender, e) =>
			{
				if (myViewModelSourceList != null && e.PropertyName == "myViewModelSourceList")
				{
					string text = string.Format("Selection count: {0} .", myViewModelSourceList.Count);
					foreach (var info in myViewModelSourceList)
						text += (info.Item ?? info).ToString();
					this.viewModelText = text;
				}				
			};			
		}


		string _viewModelText;
		public string viewModelText
		{
			get { return _viewModelText; }
			set
			{
				_viewModelText = value;
				OnPropertyChanged("viewModelText");
			}
		}
        

		IList<DataGridCellInfo> _myViewModelSourceList;
		public IList<DataGridCellInfo> myViewModelSourceList
		{
			get { return _myViewModelSourceList; }
			set
			{
				_myViewModelSourceList = value;
				OnPropertyChanged("myViewModelSourceList");
			}
		}
        

		#region INotifyPropertyChanged Members

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The property that has a new value.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{


			// Is anybody out there?
			System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler == null) return;

			// Somebody is listening, so raise a property changed event
			var args = new System.ComponentModel.PropertyChangedEventArgs(propertyName);
			handler(this, args);
		}
		/// <summary>
		/// get the string name of the member (property)
		/// </summary>
		/// <param name="expr"></param>
		/// <returns></returns>
		protected string GetMemberName<T>(System.Linq.Expressions.Expression<Func<T>> expr)
		{
			System.Linq.Expressions.MemberExpression mem = (System.Linq.Expressions.MemberExpression)expr.Body;
			return mem.Member.Name;
		}

		#endregion
	}
}
