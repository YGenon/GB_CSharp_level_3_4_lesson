using System.Windows.Controls;

namespace MailSender.Views
{
	public partial class SaveEmailView : UserControl
	{
		public SaveEmailView() => InitializeComponent();

		private void Validation_OnError(object sender, ValidationErrorEventArgs e)
		{
			switch (e.Action)
			{
				case ValidationErrorEventAction.Added:
					((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
                    SaveButton.IsEnabled = false;
                    break;

				case ValidationErrorEventAction.Removed:
					((Control)sender).ToolTip = null;
                    SaveButton.IsEnabled = true;
                    break;
			}
		}
	}
}
