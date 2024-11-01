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

namespace Assignment02_WPF
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private readonly IJobPostingServices jobPostingServices;
        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingServices = new JobPostingServices();
            LoadJobPostingList();
        }

        private void LoadJobPostingList()
        {
            try
            {
                this.dtgJobPosting.ItemsSource = jobPostingServices.GetJobPostings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            JobPosting jobPosting = jobPostingServices.GetJobPostingByID(id);
            txtPostingID.Text = jobPosting.PostingId;
            txtTitle.Text = jobPosting.JobPostingTitle;
            txtDescription.Text = jobPosting.Description;
            dpPostedDate.SelectedDate = jobPosting.PostedDate;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JobPosting jobPosting = new JobPosting();
                if (jobPosting != null)
                {
                    jobPosting.PostingId = txtPostingID.Text;
                    jobPosting.JobPostingTitle = txtTitle.Text;
                    jobPosting.Description = txtDescription.Text;
                    jobPosting.PostedDate = dpPostedDate.SelectedDate;
                    bool isUpdated = jobPostingServices.AddJobPosting(jobPosting);
                    if (isUpdated)
                    {
                        MessageBox.Show("Candidate with ID: " + jobPosting.PostingId + " is added");
                        LoadJobPostingList();
                    }
                    else
                    {
                        MessageBox.Show("Candidate cannot added for some reason!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPostingID.Text.Length > 0)
                {
                    JobPosting jobPosting = new JobPosting();
                    jobPosting.PostingId = txtPostingID.Text;
                    jobPosting.JobPostingTitle = txtTitle.Text;
                    jobPosting.Description = txtDescription.Text;
                    jobPosting.PostedDate = dpPostedDate.SelectedDate;
                    bool isUpdated = jobPostingServices.UpdateJobPosting(jobPosting);
                    if (isUpdated)
                    {
                        MessageBox.Show("Job posting with ID: " + jobPosting.PostingId + " is updated");
                        LoadJobPostingList();
                    }
                    else
                    {
                        MessageBox.Show("Cannot update for some reason!");
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Exception: "+ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPostingID.Text.Length > 0)
                {
                    string jobPostingID = txtPostingID.Text;
                    if (jobPostingServices.DeleteJobPosting(jobPostingID))
                    {
                        MessageBox.Show("Job posting with ID: " + jobPostingID + " is deleted.");
                        LoadJobPostingList();
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
