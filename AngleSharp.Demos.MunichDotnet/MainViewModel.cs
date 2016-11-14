namespace AngleSharp.Demos.MunichDotnet
{
    using AngleSharp.Dom.Css;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Input;

    sealed class MainViewModel : INotifyPropertyChanged
    {
        private String _content;
        private String _title;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _content = String.Empty;
            _title = String.Empty;

            var configuration = Configuration.Default.WithJavaScript().WithCss();
            var context = BrowsingContext.New(configuration);

            Parse = new RelayCommand(async () =>
            {
                var source = Content;
                var document = await context.OpenAsync(res => res.Content(source));

                var sheet = document.StyleSheets[0] as ICssStyleSheet;
                var rules = sheet?.Rules ?? Enumerable.Empty<ICssRule>();

                foreach (var rule in rules)
                {
                    var styleRule = rule as ICssStyleRule;

                    var style = styleRule.Style;
                }

                Content = document.ToHtml();
                Title = document.Title;
            });
        }

        public ICommand Parse
        {
            get;
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }

        public String Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChanged(); }
        }

        private void RaisePropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
