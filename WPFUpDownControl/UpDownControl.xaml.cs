using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFUpDownControl
{
	/// <summary>
	/// interaction logic for UpDownControl.xaml
	/// </summary>
	public partial class UpDownControl : UserControl
	{
		/// <summary>
		/// Exposes the <see cref="CurrentValue"/> property
		/// </summary>
		public static readonly DependencyProperty currentValueProperty=DependencyProperty.Register ("CurrentValue", typeof (decimal?), typeof (UpDownControl), new PropertyMetadata (null, OnCurrentValuePropertyChanged));
		/// <summary>
		/// Exposes the <see cref="Step"/> property
		/// </summary>
		public static readonly DependencyProperty stepProperty=DependencyProperty.Register ("Step", typeof (decimal?), typeof (UpDownControl), new PropertyMetadata (null, OnStepPropertyChanged));
		/// <summary>
		/// Exposes the <see cref="MinValue"/> property
		/// </summary>
		public static readonly DependencyProperty minValueProperty=DependencyProperty.Register ("MinValue", typeof (decimal?), typeof (UpDownControl), new PropertyMetadata (null, OnMinValuePropertyChanged));
		/// <summary>
		/// Exposes the <see cref="MaxValue"/> property
		/// </summary>
		public static readonly DependencyProperty maxValueProperty=DependencyProperty.Register ("MaxValue", typeof (decimal?), typeof (UpDownControl), new PropertyMetadata (null, OnMaxValuePropertyChanged));

		/// <summary>
		/// Exposes the <see cref="CurrentValueChanged"/> event
		/// </summary>
		public static readonly RoutedEvent CurrentValueChangedEvent=EventManager.RegisterRoutedEvent ("CurrentValueChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));
		/// <summary>
		/// Exposes the <see cref="StepChanged"/> event
		/// </summary>
		public static readonly RoutedEvent StepChangedEvent=EventManager.RegisterRoutedEvent ("StepChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));
		/// <summary>
		/// Exposes the <see cref="MinValueChanged"/> event
		/// </summary>
		public static readonly RoutedEvent MinValueChangedEvent=EventManager.RegisterRoutedEvent ("MinValueChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));
		/// <summary>
		/// Exposes the <see cref="MaxValueChanged"/> event
		/// </summary>
		public static readonly RoutedEvent MaxValueChangedEvent=EventManager.RegisterRoutedEvent ("MaxValueChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));

		/// <summary>
		/// This event triggers when the <see cref="CurrentValue"/> changes
		/// </summary>
		[Description ("Occurs when the current value changes")]
		public event RoutedEventHandler CurrentValueChanged
		{
			add
			{
				AddHandler (CurrentValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler (CurrentValueChangedEvent, value);
			}
		}
		/// <summary>
		/// This event triggers when the <see cref="Step"/> changes
		/// </summary>
		[Description ("Occurs when the step value changes")]
		public event RoutedEventHandler StepChanged
		{
			add
			{
				AddHandler (StepChangedEvent, value);
			}
			remove
			{
				RemoveHandler (StepChangedEvent, value);
			}
		}
		/// <summary>
		/// This event triggers when the <see cref="MinValue"/> changes
		/// </summary>
		[Description ("Occurs when the minimum value changes")]
		public event RoutedEventHandler MinValueChanged
		{
			add
			{
				AddHandler (MinValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler (MinValueChangedEvent, value);
			}
		}
		/// <summary>
		/// This event triggers when the <see cref="MaxValue"/> changes
		/// </summary>
		[Description ("Occurs when the maximum value changes")]
		public event RoutedEventHandler MaxValueChanged
		{
			add
			{
				AddHandler (MaxValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler (MaxValueChangedEvent, value);
			}
		}

		/// <summary>
		/// This is the counter's value
		/// </summary>
		[Bindable (true)]
		public decimal? CurrentValue
		{
			get
			{
				return ((decimal?) GetValue (currentValueProperty));
			}
			set
			{
				this.CheckCurrentValue (value);
				SetValue (currentValueProperty, value);
			}
		}
		/// <summary>
		/// This is the value which will be added/subtracted when you increase/decrease the <see cref="CurrentValue"/>
		/// </summary>
		[Bindable (true)]
		public decimal? Step
		{
			get
			{
				return ((decimal?) GetValue (stepProperty));
			}
			set
			{
				this.CheckStep (value);
				SetValue (stepProperty, value);
			}
		}
		/// <summary>
		/// This is the value the <see cref="CurrentValue"/> can't go under
		/// </summary>
		[Bindable (true)]
		public decimal? MinValue
		{
			get
			{
				return ((decimal?) GetValue (minValueProperty));
			}
			set
			{
				this.CheckMinValue (value);
				SetValue (minValueProperty, value);
			}
		}
		/// <summary>
		/// This is the value the <see cref="CurrentValue"/> can't go above
		/// </summary>
		[Bindable (true)]
		public decimal? MaxValue
		{
			get
			{
				return ((decimal?) GetValue (maxValueProperty));
			}
			set
			{
				this.CheckMaxValue (value);
				SetValue (maxValueProperty, value);
			}
		}

		/// <summary>
		/// Constructor. It performs a few value checks before the user uses the control
		/// </summary>
		public UpDownControl ()
		{
			InitializeComponent ();

			this.Loaded+=this.UpDownControl_Loaded;
		}

		/// <summary>
		/// Performs some checks and adjustments when the control is ready to use
		/// </summary>
		/// <param name="sender">
		/// the <see cref="SpinnerItself"/> control
		/// </param>
		/// <param name="routedEventArgs">
		/// some event-related data
		/// </param>
		private void UpDownControl_Loaded (object sender, RoutedEventArgs routedEventArgs)
		{
			this.CheckCurrentValue (this.CurrentValue);
			this.CheckStep (this.Step);
			this.CheckMinValue (this.MinValue);
			this.CheckMaxValue (this.MaxValue);
		}

		/// <summary>
		/// Checks <see cref="CurrentValue"/> fulfills some constraints
		/// </summary>
		/// <param name="value">
		/// the <see cref="CurrentValue"/>
		/// </param>
		/// <exception cref="Exception">
		/// thrown when one of the constraints isn't fulfilled
		/// </exception>
		private void CheckCurrentValue (decimal? value)
		{
			if (value==null)
			{
				throw new Exception ("Current value must be defined");
			}

			if (this.MinValue!=null && value<this.MinValue)
			{
				throw new Exception ("Current value can't be less than min one");
			}

			if (this.MaxValue!=null && value>this.MaxValue)
			{
				throw new Exception ("Current value can't be more than max one");
			}
		}

		/// <summary>
		/// Checks <see cref="Step"/> fulfills some constraints
		/// </summary>
		/// <param name="value">
		/// the <see cref="Step"/>
		/// </param>
		/// <exception cref="Exception">
		/// thrown when one of the constraints isn't fulfilled
		/// </exception>
		private void CheckStep (decimal? value)
		{
			if (value==null)
			{
				throw new Exception ("Step must be defined");
			}

			if (value<0m)
			{
				throw new Exception ("Step value must be at least 0");
			}
		}

		/// <summary>
		/// Checks <see cref="MinValue"/> fulfills some constraints
		/// </summary>
		/// <param name="value">
		/// the <see cref="MinValue"/>
		/// </param>
		/// <exception cref="Exception">
		/// thrown when one of the constraints isn't fulfilled
		/// </exception>
		private void CheckMinValue (decimal? value)
		{
			if (value!=null)
			{
				if (value>this.CurrentValue)
				{
					throw new Exception ("Min value must be less than current one");
				}

				if (this.MaxValue!=null && value>this.MaxValue)
				{
					throw new Exception ("Min value must be less than max one");
				}
			}
		}

		/// <summary>
		/// Checks <see cref="MaxValue"/> fulfills some constraints
		/// </summary>
		/// <param name="value">
		/// the <see cref="MaxValue"/>
		/// </param>
		/// <exception cref="Exception">
		/// thrown when one of the constraints isn't fulfilled
		/// </exception>
		private void CheckMaxValue (decimal? value)
		{
			if (value!=null)
			{
				if (value<this.CurrentValue)
				{
					throw new Exception ("Max value must be more than current one");
				}

				if (this.MinValue!=null && value<this.MinValue)
				{
					throw new Exception ("Max value must be more than min one");
				}
			}
		}

		/// <summary>
		/// callback triggered when the <see cref="currentValueProperty"/> changes
		/// </summary>
		/// <param name="dependencyObject">
		/// the <see cref="DependencyObject"/> where the property changed
		/// </param>
		/// <param name="dependencyPropertyChangedEventArgs">
		/// some change-related data
		/// </param>
		private static void OnCurrentValuePropertyChanged (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			UpDownControl upDownControl=(UpDownControl) dependencyObject;

			upDownControl.OnCurrentValueChanged ();
		}

		/// <summary>
		/// Raises the <see cref="CurrentValueChangedEvent"/> event
		/// </summary>
		protected void OnCurrentValueChanged ()
		{
			RoutedEventArgs routedEventArgs=new RoutedEventArgs (CurrentValueChangedEvent);

			RaiseEvent (routedEventArgs);
		}

		/// <summary>
		/// callback triggered when the <see cref="stepProperty"/> changes
		/// </summary>
		/// <param name="dependencyObject">
		/// the <see cref="DependencyObject"/> where the property changed
		/// </param>
		/// <param name="dependencyPropertyChangedEventArgs">
		/// some change-related data
		/// </param>
		private static void OnStepPropertyChanged (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			UpDownControl upDownControl=(UpDownControl) dependencyObject;

			upDownControl.OnStepChanged ();
		}

		/// <summary>
		/// Raises the <see cref="StepChangedEvent"/> event
		/// </summary>
		protected void OnStepChanged ()
		{
			RoutedEventArgs routedEventArgs=new RoutedEventArgs (StepChangedEvent);

			RaiseEvent (routedEventArgs);
		}

		/// <summary>
		/// callback triggered when the <see cref="minValueProperty"/> changes
		/// </summary>
		/// <param name="dependencyObject">
		/// the <see cref="DependencyObject"/> where the property changed
		/// </param>
		/// <param name="dependencyPropertyChangedEventArgs">
		/// some change-related data
		/// </param>
		private static void OnMinValuePropertyChanged (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			UpDownControl upDownControl=(UpDownControl) dependencyObject;

			upDownControl.OnMinValueChanged ();
		}

		/// <summary>
		/// Raises the <see cref="MinValueChangedEvent"/> event
		/// </summary>
		protected void OnMinValueChanged ()
		{
			RoutedEventArgs routedEventArgs=new RoutedEventArgs (MinValueChangedEvent);

			RaiseEvent (routedEventArgs);
		}

		/// <summary>
		/// callback triggered when the <see cref="maxValueProperty"/> changes
		/// </summary>
		/// <param name="dependencyObject">
		/// the <see cref="DependencyObject"/> where the property changed
		/// </param>
		/// <param name="dependencyPropertyChangedEventArgs">
		/// some change-related data
		/// </param>
		private static void OnMaxValuePropertyChanged (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			UpDownControl upDownControl=(UpDownControl) dependencyObject;

			upDownControl.OnMaxValueChanged ();
		}

		/// <summary>
		/// Raises the <see cref="MaxValueChangedEvent"/> event
		/// </summary>
		protected void OnMaxValueChanged ()
		{
			RoutedEventArgs routedEventArgs=new RoutedEventArgs (MaxValueChangedEvent);

			RaiseEvent (routedEventArgs);
		}

		/// <summary>
		/// Handles the click on the <see cref="IncreaseButton"/> button
		/// </summary>
		/// <param name="sender">
		/// the <see cref="IncreaseButton"/> button
		/// </param>
		/// <param name="routedEventArgs">
		/// some event-related data
		/// </param>
		private void IncreaseButton_Click (object sender, RoutedEventArgs routedEventArgs)
		{
			this.IncreaseCurrentValue ();
		}

		/// <summary>
		/// Handles the click on the <see cref="DecreaseButton"/> button
		/// </summary>
		/// <param name="sender">
		/// the <see cref="DecreaseButton"/> button
		/// </param>
		/// <param name="routedEventArgs">
		/// some event-related data
		/// </param>
		private void DecreaseButton_Click (object sender, RoutedEventArgs routedEventArgs)
		{
			this.DecreaseCurrentValue ();
		}

		/// <summary>
		/// Adds <see cref="Step"/> to <see cref="CurrentValue"/>
		/// </summary>
		private void IncreaseCurrentValue ()
		{
			if (this.MaxValue!=null)
			{
				if (this.CurrentValue+this.Step<=this.MaxValue)
				{
					this.CurrentValue+=this.Step;
				}
			}
			else
			{
				this.CurrentValue+=this.Step;
			}
		}

		/// <summary>
		/// Subtracts <see cref="Step"/> from <see cref="CurrentValue"/>
		/// </summary>
		private void DecreaseCurrentValue ()
		{
			if (this.MinValue!=null)
			{
				if (this.CurrentValue-this.Step>=this.MinValue)
				{
					this.CurrentValue-=this.Step;
				}
			}
			else
			{
				this.CurrentValue-=this.Step;
			}
		}
	}
}