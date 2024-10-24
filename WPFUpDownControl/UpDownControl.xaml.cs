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
		/// Exposes the <see cref="CurrentValueChanged"/> event
		/// </summary>
		public static readonly RoutedEvent CurrentValueChangedEvent=EventManager.RegisterRoutedEvent ("CurrentValueChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (UpDownControl));

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
		}
	}
}