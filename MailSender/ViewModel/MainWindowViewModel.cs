using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ListViewItemScheduler;
using MailSender.Service;

namespace MailSender.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly IDataAccessService _dataService;
		private ObservableCollection<Emails> _emails = new ObservableCollection<Emails>();
		private ObservableCollection<object> _newEmails = new ObservableCollection<object>();

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
		public RelayCommand Click_AddNewEmail { get; }
		public RelayCommand RemoveButton_Click { get; }



		public MainWindowViewModel(IDataAccessService dataService)
		{
			_dataService = dataService;
			ReadAllMailsCommand = new RelayCommand(GetEmails);
			SaveEmailCommand = new RelayCommand<Emails>(SaveEmail);
			Click_AddNewEmail = new RelayCommand(AddNewItem);
			RemoveButton_Click = new RelayCommand(DellItem);
		}

		private void SaveEmail(Emails email)
		{
			email.Id = _dataService.CreateEmail(email);
			if (email.Id == 0) return;
			Emails.Add(email);
		}

		private void GetEmails() => Emails = _dataService.GetEmails();

		//
		public object newEmail 
		{
			get => _newEmails;
			
		}

		/// <summary>
		/// Добавляет новое письмо на вкладке планировщик
		/// </summary>
		public void AddNewItem()
		{
			//MessageBox.Show("Добавили");
			ListViewItemSchedulerControl newEmail = new ListViewItemSchedulerControl();			
			_newEmails.Add(newEmail);
		}

		/// <summary>
		/// Удаляем письмо на вкладке планировщик
		/// </summary>
		public void DellItem() 
		{
			//MessageBox.Show("Удалили");
			_newEmails.RemoveAt(0);
		}
	}
}
