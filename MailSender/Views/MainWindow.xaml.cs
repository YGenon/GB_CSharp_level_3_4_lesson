﻿using ListViewItemScheduler;
using System.Windows;

namespace MailSender
{
	public partial class MainWindow : Window
	{
		private EmailSendServiceClass _emailSender;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void TabSwitcherControl_OnBack(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == 0) return;
			MainTabControl.SelectedIndex--;
		}

		private void TabSwitcherControl_OnForward(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1) return;
			MainTabControl.SelectedIndex++;
		}

		
		private void Button_Click_AddNewEmail(object sender, RoutedEventArgs e)
		{
			
		}

		private void cbSenderSelect_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{

		}
	}
}
