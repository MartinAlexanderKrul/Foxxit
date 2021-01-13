using Xunit;
using Foxxit.Models.ViewModels;
using Foxxit.Controllers;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace XUnitTestsForFoxxit
{
    public class UserManagementUnitTests
    {
        [Fact]
        public void RegistrationModelStateValidationTestEmail_1_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrejbabis@mfdnes.gov",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = null,
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrejbabis.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_4_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrejbabis",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_5_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej.b@seznam.vlada",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_6_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "a@seznam.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_7_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "@seznam.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_8_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej@babis.c",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_9_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej:babis@google.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_10_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrejbabis@mail:google.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_11_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej/babis@google.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_12_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej*babis@google.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_13_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej&milos@vlada.gov",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_14_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej@sez/nam.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        private static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}