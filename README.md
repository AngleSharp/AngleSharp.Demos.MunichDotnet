# AngleSharp.Demos.MunichDotnet

Simple and sweet demonstration playground for AngleSharp as shown in the Munich.NET usergroup on December 2015.

If you have anything to add to the demo, then feel free to do so. Push requests are always highly appreciated.

## Companion Slides

The slides for the talk can be found at [talks.florian-rappl.de/AngleSharp-muc/](http://talks.florian-rappl.de/AngleSharp-muc/?full#final). They are rather sparse and do not provide the full information spread during the talk.

## Running the Sample

The demo is a Visual Studio 2015 solution that uses C# 6 together with the AngleSharp library. For demonstration purposes also the AngleSharp.Scripting.JavaScript library has been loaded.

The application is a WPF UI that uses the MVVM pattern. The main viewmodel is the `MainViewModel`. Here the connection to the transformation is designed. The `Parse` command performs the asynchronous parse operation.

## Playing around with the Sample

The sample can be used to illustrate some JavaScript interaction with AngleSharp as well as some CSS capabilities. To get some grasp of CSS the following code block has been inserted into the viewmodel:

```cs
var sheet = document.StyleSheets[0] as ICssStyleSheet;
var rules = sheet?.Rules ?? Enumerable.Empty<ICssRule>();

foreach (var rule in rules)
{
    var styleRule = rule as ICssStyleRule;

    var style = styleRule.Style;
}
```

A breakpoint at the closing curly bracket can be used to inspect the contents of the `style` variable. This should yield some rather interesting insights, e.g., the decuced selector and style declaration. As seen in the code only the first stylesheet is inspected (if any).

Another thing is that a JavaScript engine has been integrated. Thus parsing the following chunk of HTML code actually does something:

```html
<script>console.log('Hi Mum!')</script>
```

The debug output view of Visual Studio should display "Hi Mum!". This can be abused as such:

```html
<script>document.write('<span>again</span>')</script>
```

Inserting this and pressing "Transform!" multiple types will repeat the *again* in the `span` element. This is a nice way to "grow" a document. Granted, a rather boring document.

## License

The MIT License (MIT)

Copyright (c) 2015 - 2016 AngleSharp

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
