using Assignment02_BusinessObject;
using Assignment02_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Assignment02_WPF
{
    /// <summary>
    /// Interaction logic for CandidateManagement.xaml
    /// </summary>
    public partial class CandidateManagement : Window
    {
        private readonly ICandidateProfileServices _profileServices;
        private int? roleID;

        public CandidateManagement(int? roleID)
        {
            InitializeComponent();
            _profileServices = new CandidateProfileServices();
            this.roleID = roleID;
            LoadProductList();
        }
        public void LoadProductList()
        {
            this.dtgCandidateProfile.ItemsSource = _profileServices.GetAllCandidates().Select(a => new { a.CandidateId, a.Fullname});
            this.cbxPostingID.DisplayMemberPath = "JobPostingTitle";
            this.cbxPostingID.SelectedValuePath = "PostingId";
        }
        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid == null || dataGrid.SelectedIndex < 0)
            {
                return;
            }
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn =
                (DataGridCell)dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)RowColumn.Content).Text;
            CandidateProfile candidateProfile = _profileServices.GetCandidateById(id);
            txtCandidateID.Text = candidateProfile.CandidateId;
            txtFullName.Text = candidateProfile.Fullname;
            txtProfileURL.Text = candidateProfile.ProfileUrl;
            dpBirthdate.Text = candidateProfile.Birthday.ToString();
            cbxPostingID.SelectedValue = candidateProfile.PostingId;
            txtDescription.Text = candidateProfile.ProfileShortDescription;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
