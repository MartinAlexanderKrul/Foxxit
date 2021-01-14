using Xunit;
using Foxxit.Models.ViewModels;
using Foxxit.Controllers;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace XUnitTestsForFoxxit
{
    public class UnitTestsForUserManagementPasswordChange
    {
        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_1_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asd",
                ConfirmPassword = @"asd",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asdqw",
                ConfirmPassword = @"asdqw",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "correctpasswordcorrectpasswordcorrectpasswordcorrectpasswordcorrectpassword",
                ConfirmPassword = @"correctpasswordcorrectpasswordcorrectpasswordcorrectpasswordcorrectpassword",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_4_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "correctpassword",
                ConfirmPassword = @"correctpassword",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_5_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = @"`        ",
                ConfirmPassword = @"`        ",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_6_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "/ * - + () [] {}",
                ConfirmPassword = @"/ * - + () [] {}",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_7_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "******",
                ConfirmPassword = @"******",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_8_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "/-/-/-/-/-/",
                ConfirmPassword = @"/-/-/-/-/-/",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_9_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = @"`~???\\/<>/*-**PKe..",
                ConfirmPassword = @"`~???\\/<>/*-**PKe..",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewPassword_10_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = @"`          ~???\\/<>/*-**PKe..",
                ConfirmPassword = @"`          ~???\\/<>/*-**PKe..",
                CurrentPassword = @"correct-currenT=Pa55W0rD,",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_1_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asdasd",
                ConfirmPassword = @"asdasd",
                CurrentPassword = @"asdasd",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asdasd",
                ConfirmPassword = @"asdasd ",
                CurrentPassword = @"current-pa55W0rD ",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asdasd",
                ConfirmPassword = @"ASDASD",
                CurrentPassword = @"current-pa55W0rD ",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_4_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asdasd",
                ConfirmPassword = @"",
                CurrentPassword = @"current-pa55W0rD ",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_5_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "asdasd",
                ConfirmPassword = @" asdasd",
                CurrentPassword = @"current-pa55W0rD ",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_6_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "",
                ConfirmPassword = "",
                CurrentPassword = @"current-pa55W0rD ",
            };

            _ = controller.PasswordChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_7_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "ubrouskuprostrise",
                ConfirmPassword = "ubrouskuprostrise",
                CurrentPassword = @"current-pa55W0rD ",
            };

            _ = controller.PasswordChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_8_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new PasswordChangeViewModel
            {
                NewPassword = "qwerty",
                ConfirmPassword = "qwerty",
                CurrentPassword = @"",
            };

            _ = controller.PasswordChange(model);

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