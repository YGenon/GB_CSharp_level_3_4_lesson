using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Service;

namespace MailSender.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly IDataAccessService _dataService;
		private ObservableCollection<Emails> _emails = new ObservableCollection<Emails>();

		public ObservableCollection<Emails> Emails
		{
			get => _emails;
			set
			{
				if (!Set(ref _emails, value)) return;
				_emailsView = new CollectionViewSource { Source = value };
				_emailsView.Filter += OnEmailsCollectionViewSourceFilter;
				RaisePropertyChanged(nameof(EmailsView));
			}
		}

		private void OnEmailsCollectionViewSourceFilter(object sender, FilterEventArgs e)
		{
			if (!(e.Item is Emails email) || string.IsNullOrWhiteSpace(_filterName)) return;
			if (!email.Name.Contains(_filterName))
				e.Accepted = false;
		}

		private Emails _currentEmail = new Emails();
		public Emails CurrentEmail
		{
			get => _currentEmail;
			set => Set(ref _currentEmail, value);
		}

		private string _filterName;
		public string FilterName
		{
			get => _filterName;
			set
			{
				if (!Set(ref _filterName, value)) return;
				EmailsView.Refresh();
			}
		}
		private CollectionViewSource _emailsView;
		public ICollectionView EmailsView => _emailsView?.View;

		public RelayCommand<Emails> SaveEmailCommand { get; }
        public RelayCommand ReadAllMailsCommand { get; }

        public MainWindowViewModel(IDataAccessService dataService)
		{
			_dataService = dataService;
			ReadAllMailsCommand = new RelayCommand(GetEmails);
			SaveEmailCommand = new RelayCommand<Emails>(SaveEmail);
		}

		private void SaveEmail(Emails email)
		{
			email.Id = _dataService.CreateEmail(email);
			if (email.Id == 0) return;
			Emails.Add(email);
		}

		private void GetEmails() => Emails = _dataService.GetEmails();
	}
}
