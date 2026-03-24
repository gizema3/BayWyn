using Microsoft.VisualStudio.TestTools.UnitTesting;
using BayWyn.Services;

namespace BayWyn.Tests
{
    [TestClass]
    public class AuthServiceTests
    {
        [TestInitialize]
        public void Setup() //Resets previous login
        {
            AuthService.Logout();
        }

        [TestMethod]
        public void Login_WithValidCredentials_ReturnsTrue() //Login with correct details
        {
            var result = AuthService.Login("Jones", "j1234");

            Assert.IsTrue(result);
            Assert.IsNotNull(AuthService.CurrentUser);
            Assert.AreEqual("OM", AuthService.CurrentUser.Role);
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ReturnsFalse() //Login with incorrect details
        {
            var result = AuthService.Login("WrongUser", "WrongPass");

            Assert.IsFalse(result);
            Assert.IsNull(AuthService.CurrentUser);
        }
    }
}