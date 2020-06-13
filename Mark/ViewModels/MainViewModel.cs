using System;

namespace Mark.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
		private string _markdownText;

		public string MarkdownText
		{
			get { return _markdownText; }
			set { 
				_markdownText = value;
				OnPropertyChanged();
				MarkdownChanged();
			}
		}

		private string _htmlContent;

		public string HtmlContent
		{
			get { return _htmlContent; }
			set { if (string.IsNullOrWhiteSpace(value))
					return;
				_htmlContent = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			MarkdownText = string.Empty;
			HtmlContent = string.Empty;
		}

		private void MarkdownChanged()
		{
			// render html
			HtmlContent = Markdig.Markdown.ToHtml(_markdownText);
		}
	}
}
