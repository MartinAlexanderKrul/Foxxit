using Xunit;
using Foxxit.Models.ViewModels;
using Foxxit.Controllers;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace XUnitTestsForFoxxit
{
    public class UserManagementUnitTestsLogin
    {
        [Fact]
        public void RegistrationModelStateValidationTestUsername_1_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej babis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej?babis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej*babis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_4_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_5_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andy/",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_6_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "a",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_7_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "ab",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_8_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszeman",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_9_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej/babis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_10_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej-babis?",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_11_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej-babis!",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_12_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej-babis*",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_13_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej-babis=",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_14_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej+babis=slunicko",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_15_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej-babis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_16_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrej+babis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_17_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_18_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "---",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_19_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "___",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_20_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "+++",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_21_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdasd",
                UserName = "a-n-D_Y",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_0_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "           ",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_1_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asd",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "asdqw",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "correctpasswordcorrectpasswordcorrectpasswordcorrectpasswordcorrectpassword",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_4_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "correctpassword",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_5_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = @"`        ",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_6_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "/ * - + () [] {}",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_7_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "******",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_8_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = "/-/-/-/-/-/",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_9_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = @"`~???\\/<>/*-**PKe..",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_10_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new LoginViewModel
            {
                Password = @"`          ~???\\/<>/*-**PKe..",
                UserName = "andrejbabis",
            };

            _ = controller.Login(model);

            Assert.True(!ValidateModel(model).Any());
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