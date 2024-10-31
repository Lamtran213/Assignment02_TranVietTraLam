using Assignment02_BusinessObject;
using Assignment02_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment02_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHraccountServices hraccountServices;
        public MainWindow()
        {
            InitializeComponent();
            hraccountServices = new HraccountServices();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = hraccountServices.GetHraccountByEmail(txtEmail.Text.Trim());

            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
            {
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        CandidateManagement candForm = new CandidateManagement(roleID);
                        candForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        CandidateManagement staffCandidate = new CandidateManagement(roleID);
                        staffCandidate.Show();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Bye bye!");
            }
        }

    }
}