# WPFUpDownControl

This is a WPF numeric up-down counter. I wrote it because WPF framework doesn't embed this useful component, and I need it in other projects

This component intends to only hold a numeric value, whereas the TextBox aims to hold any string

## Table of contents

1. [Installation](#installation)
2. [How to use](#how-to-use)
3. [Exposed properties](#exposed-properties)
	1. [Current value](#currentvalue)
	2. [Step](#step)
4. [Exposed events](#exposed-events)
	1. [Current value changed](#currentvaluechanged)
	2. [Step changed](#stepchanged)
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
<vc:UpDownControl CurrentValue="5.1" Step="0.75"/>
```

Here's the same one seen from your code-behind (assuming you named the variable as "WUDC"):
```c#
WUDC.CurrentValue=5.1m;
WUDC.Step=0.75m;
```

### `CurrentValue`

This is the counter's value

> [!NOTE]
> This value is required

### `Step`

This is the value which is added/subtracted when you increase/decrease the current one

> [!NOTE]
> This value is required

> [!NOTE]
> It must be defined and positive (i.e. `>= 0`)

## Exposed events

These are the events you may subscribe to

Here's the expanded previous snippet example showing how to subscribe to these events in your markup:
```xaml
<vc:UpDownControl CurrentValue="5.1" Step="0.75" CurrentValueChanged="WUDC_CurrentValueChanged" StepChanged="WUDC_StepChanged"/>
```

Here's the same one seen from your code-behind (still assuming you named the variable as "WUDC"):
```c#
WUDC.CurrentValue=5.1m;
WUDC.Step=0.75m;

WUDC.CurrentValueChanged+=WUDC_CurrentValueChanged;
WUDC.StepChanged+=WUDC_StepChanged;
```

### `CurrentValueChanged`

This event is triggered when the current value changes

### `StepChanged`

This event is triggered when the step changes

## Documentation

The code documentation is written in XML (as it's the C# standard way)

## Dependencies

- .NET framework 4.8.1+. This project intends to run on Windows

## Tests

Tests are functional ones and performed manually. They include the following:

- checking required properties are set and not null
- checking you can subscribe to and unsubscribe from events
- checking buttons change the current value according to the step

## Changelog

See the [changelog](changelog.md)

## License

This project is licensed under the Apache 2.0 license

## Credits

I did a 1st try for the XAML markup, but didn't get the result I wanted. So I picked part of the markup from [Stopbyte/WPF-Numeric-Spinner-NumericUpDown project](https://github.com/Stopbyte/WPF-Numeric-Spinner-NumericUpDown/blob/master/NumericSpinner.xaml) instead

As I found the events system quite uneasy to understand at first (it's the 1st time I'm diving into this), I asked ChatGPT to write the `CurrentValueChanged` event (including the dependency property). Then I copied/pasted/adapted in order to make the following ones