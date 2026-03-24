using Microsoft.VisualStudio.TestTools.UnitTesting;
using BayWyn.Services;

namespace BayWyn.Tests
{
    [TestClass]
    public class AuthServiceTests
    {
        [TestInitialize]
        public void Setup()
        {
            AuthService.Logout();
        }

        [TestMethod]
        public void Login_WithValidCredentials_ReturnsTrue()
        {
            var result = AuthService.Login("Jones", "j1234");

            Assert.IsTrue(result);
            Assert.IsNotNull(AuthService.CurrentUser);
            Assert.AreEqual("OM", AuthService.CurrentUser.Role);
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ReturnsFalse()
        {
            var result = AuthService.Login("WrongUser", "WrongPass");

            Assert.IsFalse(result);
            Assert.IsNull(AuthService.CurrentUser);
        }
    }
}