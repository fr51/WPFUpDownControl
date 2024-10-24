using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
		/// Exposes the <see cref="CurrentValueChanged"/> event
		/// </summary>
		public static readonly RoutedEvent CurrentValueChangedEvent=EventManager.RegisterRoutedEvent ("CurrentValueChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));
		/// <summary>
		/// Exposes the <see cref="StepChanged"/> event
		/// </summary>
		public static readonly RoutedEvent StepChangedEvent=EventManager.RegisterRoutedEvent ("StepChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));

		/// <summary>
		/// This event triggers when the <see cref="CurrentValue"/> changes
		/// </summary>
		[Description ("Triggered when the current value changes")]
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
		[Description ("Triggered when the step value changes")]
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
		/// Constructor. It performs a few value checks before the user uses the control
		/// </summary>
		public UpDownControl ()
		{
			InitializeComponent ();

			this.Loaded+=this.UpDownControl_Loaded;
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

			if (value<=0m)
			{
				throw new Exception ("Step value must be more than 0");
			}
		}

		/// <summary>
		/// Performs some checks and adjustments when the control is ready to use
		/// </summary>
		/// <param name="sender">
		/// the <see cref="UpDownControl"/> control
		/// </param>
		/// <param name="routedEventArgs">
		/// some event-related data
		/// </param>
		private void UpDownControl_Loaded (object sender, RoutedEventArgs routedEventArgs)
		{
			this.CheckCurrentValue (this.CurrentValue);
			this.CheckStep (this.Step);
		}

		/// <summary>
		/// Handles the click on the <see cref="increaseButton"/> button
		/// </summary>
		/// <param name="sender">
		/// the <see cref="increaseButton"/> button
		/// </param>
		/// <param name="routedEventArgs">
		/// some event-related data
		/// </param>
		private void IncreaseButton_Click (object sender, RoutedEventArgs routedEventArgs)
		{
			this.IncreaseCurrentValue ();
		}

		/// <summary>
		/// Handles the click on the <see cref="decreaseButton"/> button
		/// </summary>
		/// <param name="sender">
		/// the <see cref="decreaseButton"/> button
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
			this.CurrentValue+=this.Step;
		}

		/// <summary>
		/// Subtracts <see cref="Step"/> from <see cref="CurrentValue"/>
		/// </summary>
		private void DecreaseCurrentValue ()
		{
			this.CurrentValue-=this.Step;
		}
	}
}