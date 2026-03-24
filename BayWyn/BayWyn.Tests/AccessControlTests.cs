using Microsoft.VisualStudio.TestTools.UnitTesting;
using BayWyn.Services;
using BayWyn.ViewModels;

namespace BayWyn.Tests
{
    [TestClass]
    public class AccessControlTests
    {
        [TestInitialize]
        public void Setup()
        {
            AuthService.Logout();
        }

        

        [TestMethod]
        public void OperationsManager_ShouldViewContractsJobsAndReports()
        {
            AuthService.Login("Jones", "j1234");

            var vm = new MainViewModel();

            Assert.IsTrue(vm.CanViewContracts);
            Assert.IsTrue(vm.CanViewJobs);
            Assert.IsFalse(vm.CanViewAssignments);
            Assert.IsTrue(vm.CanViewReports);
        }
        [TestMethod]
        public void CourierRole_ShouldOnlyViewAssignments()
        {
            var loginResult = AuthService.Login("Courier", "c1234");
            Assert.IsTrue(loginResult);

            Assert.IsNotNull(AuthService.CurrentUser);
            Assert.AreEqual("C", AuthService.CurrentUser.Role);

            var vm = new MainViewModel();

            Assert.IsFalse(vm.CanViewContracts);
            Assert.IsFalse(vm.CanViewJobs);
            Assert.IsTrue(vm.CanViewAssignments);
            Assert.IsFalse(vm.CanViewReports);
        }
    }
}