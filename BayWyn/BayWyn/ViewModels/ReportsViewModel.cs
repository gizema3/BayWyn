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
        public ObservableCollection<CourierJob> ReportJobs { get; } = new ObservableCollection<CourierJob>();
        private string _summary = string.Empty;
        public string Summary { get => _summary; set { _summary = value; OnPropertyChanged(); } }

        public ICommand TodayCourierReportCommand { get; }
        public ICommand CurrentMonthJobsCommand { get; }
        public ICommand MonthlyValueReportCommand { get; }

        public ReportsViewModel()
        {
            TodayCourierReportCommand = new RelayCommand(_ => LoadTodayCourierReport());
            CurrentMonthJobsCommand = new RelayCommand(_ => LoadCurrentMonthJobs());
            MonthlyValueReportCommand = new RelayCommand(_ => LoadMonthlyValueReport());
        }

        private void LoadTodayCourierReport()
        {
            var result = DataService.Jobs
                .Where(j => j.CourierName == "courier" && j.DeliveryDate.Date == DateTime.Today)
                .ToList();

            ReportJobs.Clear();
            foreach (var j in result) ReportJobs.Add(j);

            Summary = $"Today's assignments for courier: {result.Count}";
        }

        private void LoadCurrentMonthJobs()
        {
            var now = DateTime.Now;
            var result = DataService.Jobs
                .Where(j => j.DeliveryDate.Month == now.Month && j.DeliveryDate.Year == now.Year)
                .ToList();

            ReportJobs.Clear();
            foreach (var j in result) ReportJobs.Add(j);

            Summary = $"Current month assignments: {result.Count}";
        }

        private void LoadMonthlyValueReport()
        {
            var now = DateTime.Now;
            var monthlyJobs = DataService.Jobs
                .Where(j => j.DeliveryDate.Month == now.Month && j.DeliveryDate.Year == now.Year)
                .ToList();

            decimal contractRunTotal = monthlyJobs.Where(j => j.IsContractClient).Sum(j => 2.50m);
            decimal nonContractTotal = monthlyJobs.Where(j => !j.IsContractClient).Sum(j => 10m);
            decimal monthlyContractFees = DataService.Contracts.Count * 50m;
            decimal total = contractRunTotal + nonContractTotal + monthlyContractFees;

            ReportJobs.Clear();
            foreach (var j in monthlyJobs) ReportJobs.Add(j);

            Summary = $"Contract fees: £{monthlyContractFees} | Contract runs: £{contractRunTotal} | Non-contract runs: £{nonContractTotal} | Total: £{total}";
        }
    }
}