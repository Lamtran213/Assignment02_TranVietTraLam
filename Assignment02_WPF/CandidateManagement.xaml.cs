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
        private readonly IJobPostingServices _jobPostingServices;
        private int? roleID;

        public CandidateManagement(int? roleID)
        {
            InitializeComponent();
            _profileServices = new CandidateProfileServices();
            _jobPostingServices = new JobPostingServices();
            this.roleID = roleID;
            LoadProductList();
        }
        public void LoadProductList()
        {
            this.dtgCandidateProfile.ItemsSource = _profileServices.GetAllCandidates().Select(a => new { a.CandidateId, a.Fullname, a.Posting.JobPostingTitle });
            this.cbxPostingID.ItemsSource = _jobPostingServices.GetJobPostings();
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
            Application.Current.Shutdown();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CandidateProfile candidateProfile = new CandidateProfile();
                if (candidateProfile != null)
                {
                    candidateProfile.CandidateId = txtCandidateID.Text;
                    candidateProfile.Fullname = txtFullName.Text;
                    candidateProfile.Birthday = dpBirthdate.SelectedDate;
                    candidateProfile.ProfileShortDescription = txtDescription.Text;
                    candidateProfile.ProfileUrl = txtProfileURL.Text;
                    candidateProfile.PostingId = cbxPostingID.SelectedValue.ToString();
                    bool isAdd = _profileServices.AddCandidateProfile(candidateProfile);
                    if (isAdd)
                    {
                        MessageBox.Show("Candidate added successfully.");
                        LoadProductList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCandidateID.Text.Length > 0)
                {
                    string candidateID = txtCandidateID.Text;
                    if (_profileServices.DeleteCandidateProfile(candidateID))
                    {
                        MessageBox.Show("Candidate with ID: " + candidateID + " is deleted.");
                        LoadProductList();
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete with ID: " + candidateID + "for some reason!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCandidateID.Text.Length > 0)
                {
                    CandidateProfile candidateProfile = new CandidateProfile();
                    candidateProfile.CandidateId = txtCandidateID.Text;
                    candidateProfile.Fullname = txtFullName.Text;
                    candidateProfile.Birthday = dpBirthdate.SelectedDate;
                    candidateProfile.ProfileShortDescription = txtDescription.Text;
                    candidateProfile.ProfileUrl = txtDescription.Text;
                    candidateProfile.PostingId = cbxPostingID.SelectedValue.ToString();
                    bool isUpdated = _profileServices.UpdateCandidateProfile(candidateProfile);
                    if (isUpdated)
                    {
                        MessageBox.Show("Candidate with ID:" + candidateProfile.CandidateId + " is updated");
                        LoadProductList() ;
                    }
                    else
                    {
                        MessageBox.Show("Cannot updated for some reason.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow();
            jobPostingWindow.ShowDialog();
        }
    }
}
