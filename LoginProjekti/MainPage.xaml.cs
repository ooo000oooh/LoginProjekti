using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LoginProjekti.Resources;

namespace LoginProjekti
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Boolean loginFailed;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Back pressed");
            toggleLoginPanelOn();
        }

        private void Checbox_Clicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Checkbox pressed");
            if(this.Use_outlook_weblight_instructions.Visibility==Visibility.Collapsed){
                this.Use_outlook_weblight_instructions.Visibility=Visibility.Visible;
            }
            else
            {
                this.Use_outlook_weblight_instructions.Visibility = Visibility.Collapsed;
            }
            
        }

        //Toggles private/public computer information visibility based on clicked radioButton
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
            RadioButton rb = (RadioButton)sender;
            if (rb.Name.Equals("PublicComputerRadioButton"))
            {
                System.Diagnostics.Debug.WriteLine("public computer radiobutton checked");
                this.PrivateComputerInstructionsText.Visibility = Visibility.Collapsed;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("private computer radiobutton checked");
                this.PrivateComputerInstructionsText.Visibility = Visibility.Visible;
            }           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Login pressed");
            this.LoginFailedText.Visibility = Visibility.Collapsed;
            String userNameTrimmed = userNameTextBox.Text.Trim();
            String passwordTrimmed = passwordTextBox.Text.Trim();
            if (userNameTrimmed.Equals("") || passwordTrimmed.Equals(""))
            {
                System.Diagnostics.Debug.WriteLine("Login failed. usrname was:" + userNameTrimmed);
                this.LoginFailedText.Visibility = Visibility.Visible;
                return;
            }
            toggleLoggedInPanelOn();
            System.Diagnostics.Debug.WriteLine(userNameTextBox.Text);
        }

        private void toggleLoggedInPanelOn()
        {
            System.Diagnostics.Debug.WriteLine("Toggling logged in panel on");
            this.LoggedInPanel.Visibility = Visibility.Visible;
            this.ContentPanel.Visibility = Visibility.Collapsed;
        }

        private void toggleLoginPanelOn()
        {
            this.ContentPanel.Visibility = Visibility.Visible;
            this.LoggedInPanel.Visibility = Visibility.Collapsed;
        }
    }
}