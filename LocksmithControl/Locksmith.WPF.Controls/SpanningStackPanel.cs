using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Locksmith.WPF.Controls
{
	
	public class SpanningStackPanel : Grid
	{
		#region Ctor

		public SpanningStackPanel()
            : base()
        {
            //Default Orientation Should Be Vertical
            this.Orientation = Orientation.Vertical;

            //Handle the Panel's Loaded Event
            this.Loaded += new RoutedEventHandler(SpanningStackPanel_Loaded);
        }


        #endregion
				
		#region Events

		public delegate void OnChildrenCahngedHandler(object sender, ChildrenChangedEventArg e);
		public event OnChildrenCahngedHandler OnChildrenCahnged;

		#endregion

		#region Dependency Properties

		private static DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SpanningStackPanel), new PropertyMetadata(new PropertyChangedCallback(OnOrientationPropertyChanged)));
        /// <summary>
        /// Orientation of items inside Panel, Vertical or Horizontal.
        /// </summary>
        public Orientation Orientation
        {
            get
            {
                return (Orientation)this.GetValue(OrientationProperty);
            }

            set
            {
                this.SetValue(OrientationProperty, value);
            }
        }

		private static DependencyProperty PrioritizeItemProperty = DependencyProperty.Register("PrioritizeItem", typeof(int), typeof(SpanningStackPanel));
		/// <summary>
		/// Defines the AutoFitted Prioritize Item
		/// </summary>
		public int PrioritizeItem
		{
			get
			{
				return (int)this.GetValue(PrioritizeItemProperty);
			}

			set
			{
				this.SetValue(PrioritizeItemProperty, value);
			}
		}

		private static DependencyProperty IsAutoFittedProperty = DependencyProperty.Register("IsAutoFitted", typeof(bool), typeof(SpanningStackPanel),new PropertyMetadata(new PropertyChangedCallback(OnAutoFittedPropertyChanged)));
		/// <summary>
		/// Defines if the AutoFitted functionality is on
		/// </summary>
		public bool IsAutoFitted
		{
			get
			{
				return (bool)this.GetValue(IsAutoFittedProperty);
			}

			set
			{
				this.SetValue(IsAutoFittedProperty, value);
			}
		}


        #endregion Dependency Properties

        #region Protected Methods

        /// <summary>
        /// When the visual children change we want to make
        /// sure that our "custom" layout occurs.
        /// </summary>
        /// <param name="visualAdded"></param>
        /// <param name="visualRemoved"></param>
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
			if (visualAdded != null && visualAdded is FrameworkElement)
			{
				((FrameworkElement)visualAdded).SizeChanged += new SizeChangedEventHandler(SpanningStackPanel_Item_SizeChanged);
			}			
			LayoutChildren();
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
			ChildrenChanged(visualAdded, visualRemoved);
        }	

        #endregion Protected Methods

        #region Private Methods

		private void ChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
		{
			if (this.OnChildrenCahnged != null)
			{
				this.OnChildrenCahnged(this, new ChildrenChangedEventArg(visualAdded, visualRemoved));
			}
		}

        /// <summary>
        /// Event Handler for the SpanningStackPanel Loaded Event
        /// We want to call LayoutChildren after a load completes even though
        /// it should have been called during the controls initialization phase.
        /// It isn't until the panel is completely loaded that we can know for 
        /// sure the desired layout of the children.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpanningStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutChildren();
        }

		void SpanningStackPanel_Item_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			LayoutChildren();
		}

        /// <summary>
        /// Event Handler for Orientation Property Change Event
        /// </summary>
        /// <param name="target"></param>
        /// <param name="e"></param>
        private static void OnOrientationPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is SpanningStackPanel)
            {
                ((SpanningStackPanel)target).LayoutChildren();
            }
        }

		 /// <summary>
        /// Event Handler for AutoFitted Property Change Event
        /// </summary>
        /// <param name="target"></param>
        /// <param name="e"></param>
        private static void OnAutoFittedPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is SpanningStackPanel)
            {
                ((SpanningStackPanel)target).LayoutChildren();
            }
        }

        /// <summary>
        /// The "Main" layout function to be called anytime the children
        /// needs to be placed.
        /// </summary>
        public void LayoutChildren()
        {
            if (FlowDirection == FlowDirection.LeftToRight)
            {
                LayoutChildrenLeftToRight();
            }
            else
            {
                LayoutChildrenRightToLeft();
            }
        }


        /// <summary>
        /// Layout Method for when the panel's FlowDirection is 
        /// RightToLeft
        /// </summary>
        private void LayoutChildrenRightToLeft()
        {
            //Clear the current row and column definitions.
            this.RowDefinitions.Clear();
            this.ColumnDefinitions.Clear();

            int indexTracker = 0;

            //Cycle through the children and generate the proper row or column.
            for(int i = this.Children.Count - 1; i >= 0; i--)
            {
                UIElement child = this.Children[i];

                //Determine if rows or columns should be used.
                if (this.Orientation == Orientation.Vertical)
                {
                    //Orientation is Vertical so use rows.
                    RowDefinition newRowDefinition = CreateRowDefinitionForChild(child);

                    //Add the Row Definition and set the row property on child.
                    this.RowDefinitions.Add(newRowDefinition);
					if (child != null)
					{
						SetRow(child, indexTracker);
					}
					else
					{
						SetRow(new FrameworkElement(), indexTracker);
					}

                }
                else
                {
                    //Orientation is Horizontal so use columns.
                    ColumnDefinition newColumnDefinition = CreateColumnDefinitionForChild(child);
                    //Add the ColumnDefintion and set the row property on the child.
                    this.ColumnDefinitions.Add(newColumnDefinition);
					if (child != null)
					{
						SetColumn(child, indexTracker);
					}
					else
					{
						SetColumn(new FrameworkElement(), indexTracker);
					}
                }

                indexTracker++;
            }
			if (IsAutoFitted)
			{
				if (this.Orientation == Orientation.Vertical)
				{
					PerformRowSizeAdjustment();
				}
				else
				{
					PerformColumnSizeAdjustment();
				}
			}
        }

        /// <summary>
        /// Layout Method for when the panel's FlowDirection is
        /// LeftToRight
        /// </summary>
        private void LayoutChildrenLeftToRight()
        {
            //Clear the current row and column definitions.
            this.RowDefinitions.Clear();
            this.ColumnDefinitions.Clear();

            int indexTracker = 0;

            //Cycle through the children and generate the proper row or column.
            foreach (UIElement child in this.Children)
            {
                //Determine if rows or columns should be used.
                if (this.Orientation == Orientation.Vertical)
                {
                    //Orientation is Vertical so use rows.
                    RowDefinition newRowDefinition = CreateRowDefinitionForChild(child);

                    //Add the Row Definition and set the row property on child.
                    this.RowDefinitions.Add(newRowDefinition);
					if (child != null)
					{
						SetRow(child, indexTracker);
					}
					else
					{
						SetRow(new FrameworkElement(), indexTracker);
					}

                }
                else
                {
                    //Orientation is Horizontal so use columns.
                    ColumnDefinition newColumnDefinition = CreateColumnDefinitionForChild(child);
                    //Add the ColumnDefintion and set the row property on the child.
                    this.ColumnDefinitions.Add(newColumnDefinition);
					if (child != null)
					{
						SetRow(child, indexTracker);
					}
					else
					{
						SetRow(new FrameworkElement(), indexTracker);
					}                   
                }

                indexTracker++;
            }
			if (IsAutoFitted)
			{
				if (this.Orientation == Orientation.Vertical)
				{
					PerformRowSizeAdjustment();
				}
				else
				{
					PerformColumnSizeAdjustment();
				}
			}
        }

		private void PerformColumnSizeAdjustment()
		{
			double accumulatedColumnSize = 0;

			if (this.Parent != null)
			{
				if (((FrameworkElement)this.Parent).ActualWidth > 0)
				{
					double delta = 0;
					accumulatedColumnSize = 0;
					foreach (FrameworkElement element in this.Children)
					{
						if (element != null)
						{
							accumulatedColumnSize += element.ActualWidth;
						}
					}				
									
					if (((FrameworkElement)this.Parent).ActualWidth > accumulatedColumnSize)
					{
						delta = ((FrameworkElement)this.Parent).ActualWidth - accumulatedColumnSize;					
						if (this.Children[PrioritizeItem] is FrameworkElement)
						{
							((FrameworkElement)this.Children[PrioritizeItem]).Width = ((FrameworkElement)this.Children[PrioritizeItem]).ActualWidth + delta;
						}													
					}
					else
					{
						delta = accumulatedColumnSize - ((FrameworkElement)this.Parent).ActualWidth;						
						if (this.Children[PrioritizeItem] is FrameworkElement)
						{
							double adjSize = ((FrameworkElement)this.Children[PrioritizeItem]).ActualWidth - delta;
							if (adjSize >= 0)
							{
								((FrameworkElement)this.Children[PrioritizeItem]).Width = adjSize;
							}
							
						}									
					}								
				}
			}
		}

		private void PerformRowSizeAdjustment()
		{
			double accumulatedRowSize = 0;

			if (this.Parent != null)
			{
				if (((FrameworkElement)this.Parent).ActualHeight > 0)
				{
					double delta = 0;
					accumulatedRowSize = 0;
					foreach (FrameworkElement element in this.Children)
					{
						if (element != null)
						{
							accumulatedRowSize += element.ActualHeight;
						}
					}

					if (((FrameworkElement)this.Parent).ActualHeight > accumulatedRowSize)
					{
						delta = ((FrameworkElement)this.Parent).ActualHeight - accumulatedRowSize;					
						if (this.Children[PrioritizeItem] is FrameworkElement)
						{
							((FrameworkElement)this.Children[PrioritizeItem]).Height = ((FrameworkElement)this.Children[PrioritizeItem]).ActualHeight + delta;
						}			
					}
					else
					{
						delta = accumulatedRowSize - ((FrameworkElement)this.Parent).ActualHeight;
						if (this.Children[PrioritizeItem] is FrameworkElement)
						{
							double adjSize = ((FrameworkElement)this.Children[PrioritizeItem]).ActualHeight - delta;
							if (adjSize >= 0)
							{
								((FrameworkElement)this.Children[PrioritizeItem]).Height = adjSize;
							}
						}
					}
				}
			}
		}


        /// <summary>
        /// Takes in a UIElement and creates a ColumnDefinition for the passed
        /// child to reside in.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private ColumnDefinition CreateColumnDefinitionForChild(UIElement child)
        {
            //If the child is a FrameworkElement we can sneak a peak at it's height value.  Else we'll ask it its desired size.
            Size sizeOfChild;

			//Create the RowDefinition
			ColumnDefinition newColumnDefinition = new ColumnDefinition();

			if (child != null)
			{
				//Come back and rethink how this is done.
				if (child is FrameworkElement)
				{
					FrameworkElement feChild = child as FrameworkElement;
					sizeOfChild = new Size(feChild.ActualWidth, feChild.ActualWidth);
				}
				else
				{
					//Tell the child he has all the room in the world.
					child.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
					//Ask the child how much room he'd like to use.
					sizeOfChild = child.DesiredSize;
				}
				//Determine Height of the Row
				if (Double.IsNaN(sizeOfChild.Width) || Double.IsPositiveInfinity(sizeOfChild.Width) || sizeOfChild.Width == 0)
				{
					newColumnDefinition.Width = new GridLength(1, GridUnitType.Star);
				}
				else
				{
					newColumnDefinition.Width = new GridLength(1, GridUnitType.Auto);
				}
			}
			else
			{
				newColumnDefinition.Width = new GridLength(1, GridUnitType.Auto);
			}

            return newColumnDefinition;
        }

        /// <summary>
        /// Takes in a UIElement and creates a RowDefinition for the passed child
        /// to reside in.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private RowDefinition CreateRowDefinitionForChild(UIElement child)
        {
            //If the child is a FrameworkElement we can sneak a peak at it's height value.  Else we'll ask it its desired size.
            Size sizeOfChild;
			//Create the RowDefinition
			RowDefinition newRowDefinition = new RowDefinition();
				
			if (child != null)
			{
				//Come back and rethink how this is done.
				if (child is FrameworkElement)
				{
					FrameworkElement feChild = child as FrameworkElement;
					sizeOfChild = new Size(feChild.ActualHeight, feChild.ActualWidth);
				}
				else
				{
					//Tell the child he has all the room in the world.
					child.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));				
					//Ask the child how much room he'd like to use.
					sizeOfChild = child.DesiredSize;
				}

				//Determine Height of the Row
				if (Double.IsNaN(sizeOfChild.Height) || Double.IsPositiveInfinity(sizeOfChild.Height) || sizeOfChild.Height == 0)
				{
					newRowDefinition.Height = new GridLength(1, GridUnitType.Star);
				}
				else
				{
					newRowDefinition.Height = new GridLength(1, GridUnitType.Auto);					
				}
			}
			else
			{
				newRowDefinition.Height = new GridLength(1, GridUnitType.Auto);
			}

            return newRowDefinition;
        }

        #endregion Private Methods
    }
}
