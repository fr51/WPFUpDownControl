# WPFUpDownControl

This is a WPF numeric up-down counter. I wrote it because WPF framework doesn't embed this useful component, and I need it in other projects

This component intends to only hold a numeric value, whereas the TextBox aims to hold any string

## Table of contents

1. [Installation](#installation)
2. [How to use](#how-to-use)
3. [Exposed properties](#exposed-properties)
4. [Exposed events](#exposed-events)
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

## Exposed properties

These are the properties you'll use in your markup

> [!NOTE]
> These properties are of `decimal` type. It's up to you to cast to other types if needed

Here's a snippet example showing how to set these properties in your markup:
```xaml
<vc:UpDownControl/>
```

Here's the same one seen from your code-behind (assuming you named the variable as "WUDC"):
```c#
```

## Exposed events

These are the events you may subscribe to

Here's the expanded previous snippet example showing how to subscribe to these events in your markup:
```xaml
<vc:UpDownControl/>
```

Here's the same one seen from your code-behind (still assuming you named the variable as "WUDC"):
```c#
```

## Documentation

The code documentation is written in XML (as it's the C# standard way)

## Dependencies

- .NET framework 4.8.1+. This project intends to run on Windows

## Tests

Tests are functional ones and performed manually. They include the following:

## Changelog

See the [changelog](changelog.md)

## License

This project is licensed under the Apache 2.0 license

## Credits

I did a 1st try for the XAML markup, but didn't get the result I wanted. So I picked part of the markup from [Stopbyte/WPF-Numeric-Spinner-NumericUpDown project](https://github.com/Stopbyte/WPF-Numeric-Spinner-NumericUpDown/blob/master/NumericSpinner.xaml) instead