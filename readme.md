# WPFUpDownControl

This is a WPF numeric up-down counter. I wrote it because WPF framework doesn't embed this useful component, and I need it in other projects

This component intends to only hold a numeric value, whereas the TextBox aims to hold any string

## Table of contents

1. [Installation](#installation)
2. [How to use](#how-to-use)
3. [Exposed properties](#exposed-properties)
	1. [Current value](#currentvalue)
	2. [Step](#step)
	3. [Minimum value](#minvalue)
	4. [Maximum value](#maxvalue)
4. [Exposed events](#exposed-events)
	1. [Current value changed](#currentvaluechanged)
	2. [Step changed](#stepchanged)
	3. [Minimum value changed](#minvaluechanged)
	4. [Maximum value changed](#maxvaluechanged)
5. [Documentation](#documentation)
6. [Dependencies](#dependencies)
7. [Tests](#tests)
8. [Changelog](#changelog)
9. [License](#license)
10. [Credits](#credits)

## Installation

1. Download the latest release from the Releases section
2. In your project, add a reference to the DLL file you just downloaded by browsing it
3. In your markup,
	1. import the namespace by adding the following to your component declaration (where you can see the `xlmns` declarations): `xmlns:vc="clr-namespace:WPFUpDownControl;assembly=WPFUpDownControl"`
	2. add the control with the following: `<vc:UpDownControl/>`
	3. then set the properties

## How to use

> [!NOTE]
> This section applies to the final user

The only way to change the value is, for now, by clicking the buttons. Additional ways will be added in upcoming versions

## Exposed properties

These are the properties you'll use in your markup

> [!NOTE]
> These properties are of `decimal` type. It's up to you to cast to other types if needed

Here's a snippet example showing how to set these properties in your markup:
```xaml
<vc:UpDownControl CurrentValue="5.1" Step="0.75" MinValue="1" MaxValue="10.999"/>
```

Here's the same one seen from your code-behind (assuming you named the variable as "WUDC"):
```c#
WUDC.CurrentValue=5.1m;
WUDC.Step=0.75m;
WUDC.MinValue=1m;
WUDC.MaxValue=10.999m;
```

### `CurrentValue`

This is the counter's value

> [!NOTE]
> This value is required

> [!WARNING]
> Be careful when changing this one in your code-behind. If `MinValue` and/or `MaxValue` are defined, it always has to be between these two ones (i.e. `MinValue (if defined) <= CurrentValue <= MaxValue (if defined)`). Otherwise, an exception will pop up
>
> For example, let's say you have the following:
> - `CurrentValue=1.5`
> - `MaxValue=2`
> - `MinValue=-3`.
>
> Setting `CurrentValue` to `3` will throw an exception. Whereas setting `MaxValue` to `3.1`, then `CurrentValue` to `3` won't

### `Step`

This is the value which is added/subtracted when you increase/decrease the current one

> [!NOTE]
> This value is required

> [!NOTE]
> It must be defined and positive (i.e. `>= 0`)

### `MinValue`

This is the value the current one can't go under

> [!NOTE]
> This value is optional

> [!NOTE]
> It must be less than current value and (if defined) maximum one, i.e. `MinValue (if defined) <= CurrentValue` and `MinValue (if defined) <= MaxValue (if defined)`

### `MaxValue`

This is the value the current one can't go above

> [!NOTE]
> This value is optional

> [!NOTE]
> It must be more than current value and (if defined) minimum one, i.e. `MaxValue (if defined) >= CurrentValue` and `MaxValue (if defined) >= MinValue (if defined)`

## Exposed events

These are the events you may subscribe to

Here's the expanded previous snippet example showing how to subscribe to these events in your markup:
```xaml
<vc:UpDownControl CurrentValue="5.1" Step="0.75" MinValue="1" MaxValue="10.999" CurrentValueChanged="WUDC_CurrentValueChanged" StepChanged="WUDC_StepChanged" MinValueChanged="WUDC_MinValueChanged" MaxValueChanged="WUDC_MaxValueChanged"/>
```

Here's the same one seen from your code-behind (still assuming you named the variable as "WUDC"):
```c#
WUDC.CurrentValue=5.1m;
WUDC.Step=0.75m;
WUDC.MinValue=1m;
WUDC.MaxValue=10.999m;

WUDC.CurrentValueChanged+=WUDC_CurrentValueChanged;
WUDC.StepChanged+=WUDC_StepChanged;
WUDC.MinValueChanged+=WUDC_MinValueChanged;
WUDC.MaxValueChanged+=WUDC_MaxValueChanged;
```

### `CurrentValueChanged`

This event is triggered when the current value changes

### `StepChanged`

This event is triggered when the step changes

### `MinValueChanged`

This event is triggered when the minimum value changes

### `MaxValueChanged`

This event is triggered when the maximum value changes

## Documentation

The code documentation is written in XML (as it's the C# standard way)

## Dependencies

- .NET framework 4.8.1+. This project intends to run on Windows

## Tests

Tests are functional ones and performed manually. They include the following:

- checking required properties are set and not null
- checking you can subscribe to and unsubscribe from events
- checking buttons change the current value according to the step
- checking current value remains within defined minimum and/or maximum value(s)
- checking minimum value is always less than maximum and current ones
- checking maximum value is always more than minimum and current ones
- checking current value changes when you roll the mousewheel
- checking current value changes when you use the `Up` and `Down` arrow keys

## Changelog

See the [changelog](changelog.md)

## License

This project is licensed under the Apache 2.0 license

## Credits

I did a 1st try for the XAML markup, but didn't get the result I wanted. So I picked part of the markup from [Stopbyte/WPF-Numeric-Spinner-NumericUpDown project](https://github.com/Stopbyte/WPF-Numeric-Spinner-NumericUpDown/blob/master/NumericSpinner.xaml) instead

As I found the events system quite uneasy to understand at first (it's the 1st time I'm diving into this), I asked ChatGPT to write the `CurrentValueChanged` event (including the dependency property). Then I copied/pasted/adapted in order to make the following ones