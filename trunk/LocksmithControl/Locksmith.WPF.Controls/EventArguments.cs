using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows;

namespace Locksmith.WPF.Controls
{
    #region Event Args

    public class OnPathChangedEventArg : EventArgs
    {

        #region Private Members

        private string _newPath;
		private bool _isBarGrowing;	
        #endregion

        #region Ctor

        public OnPathChangedEventArg(string newPath , bool isBarGrowing)
        {
            _newPath = newPath;
			_isBarGrowing = isBarGrowing;
        }

        #endregion

        #region properties


        public string NewPath
        {
            get { return _newPath; }
        }

		public bool IsBarGrowing
		{
			get { return _isBarGrowing; }			
		}


        #endregion
    }

	public class OnItemSelectionChangedEventArg : EventArgs
	{

		#region Private Members

		private readonly string _newPath;
		private readonly bool _hasWidget;

		#endregion

		#region Ctor

		public OnItemSelectionChangedEventArg(string newPath, bool hasWidget)
		{
			_newPath = newPath;
			_hasWidget = hasWidget;
		}

		#endregion

		#region properties


		public string NewPath
		{
			get { return _newPath; }
		}

		public bool HasWidget
		{
			get { return _hasWidget; }
		}



		#endregion
	}	

	public class ChildrenChangedEventArg : EventArgs
	{

		#region Private Members

		private readonly DependencyObject _visualAdded;
		private readonly DependencyObject _visualRemoved;

		#endregion

		#region Ctor

		public ChildrenChangedEventArg(DependencyObject visualAdded, DependencyObject visualRemoved)
		{
			_visualAdded = visualAdded;
			_visualRemoved = visualRemoved;
		}

		#endregion

		#region properties


		public DependencyObject VisualAdded
		{
			get { return _visualAdded; }
		}

		public DependencyObject VisualRemoved
		{
			get { return _visualRemoved; }
		}

		#endregion
	}
	
    #endregion
}
