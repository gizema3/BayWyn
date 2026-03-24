using BayWyn.Commands;
using BayWyn.Models;
using BayWyn.Services;
using BayWyn.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BayWyn.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        //DataGrid presents reports.
        public ObservableCollection<CourierJob> ReportJobs { get; } = new ObservableCollection<CourierJob>();
        private string _summary = string.Empty;
        public string Summary { get => _summary; set { _summary = value; OnPropertyChanged(); } } //Presents information box.

        public ICommand TodayCourierReportCommand { get; }
        public ICommand CurrentMonthJobsCommand { get; }
        public ICommand MonthlyValueReportCommand { get; }

        public ReportsViewModel()
        {
            TodayCourierReportCommand = new RelayCommand(_ => LoadTodayCourierReport()); //Setting up button commands.
            CurrentMonthJobsCommand = new RelayCommand(_ => LoadCurrentMonthJobs());
            MonthlyValueReportCommand = new RelayCommand(_ => LoadMonthlyValueReport());
        }

        private void LoadTodayCourierReport() //Shows only today's reports.
        {
            var result = DataService.Jobs
                .Where(j => j.CourierName == "courier" && j.DeliveryDate.Date == DateTime.Today)
                .ToList();

            ReportJobs.Clear();
            foreach (var j in result) ReportJobs.Add(j);

            Summary = $"Today's assignments for courier: {result.Count}"; //Shows the summary
        }

        private void LoadCurrentMonthJobs()
        {
            //Generates reports for this month.
            var now = DateTime.Now;
            var result = DataService.Jobs //Links to DataService Jobs
                .Where(j => j.DeliveryDate.Month == now.Month && j.DeliveryDate.Year == now.Year) //Validates the date.
                .ToList();

            ReportJobs.Clear();
            foreach (var j in result) ReportJobs.Add(j); //Shows the summary.

            Summary = $"Current month assignments: {result.Count}";
        }

        private void LoadMonthlyValueReport()
        {
            //Calculating all income.

            //First taking this months earnings.
            var now = DateTime.Now;
            var monthlyJobs = DataService.Jobs
                .Where(j => j.DeliveryDate.Month == now.Month && j.DeliveryDate.Year == now.Year)
                .ToList();

            decimal contractRunTotal = monthlyJobs.Where(j => j.IsContractClient).Sum(j => 2.50m); //Assigning values based on pricing rules.
            decimal nonContractTotal = monthlyJobs.Where(j => !j.IsContractClient).Sum(j => 10m);
            decimal monthlyContractFees = DataService.Contracts.Count * 50m;
            decimal total = contractRunTotal + nonContractTotal + monthlyContractFees; // Calculating all earnings.

            ReportJobs.Clear();
            foreach (var j in monthlyJobs) ReportJobs.Add(j); //Presenting all earnings.

            Summary = $"Contract fees: £{monthlyContractFees} | Contract runs: £{contractRunTotal} | Non-contract runs: £{nonContractTotal} | Total: £{total}";
        }
    }
}