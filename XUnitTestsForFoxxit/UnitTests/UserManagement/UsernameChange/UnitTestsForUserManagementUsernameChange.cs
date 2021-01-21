using Xunit;
using Foxxit.Models.ViewModels;
using Foxxit.Controllers;
using Moq;
using System.Collections.Generic;
using   System.ComponentModel.DataAnnotations;
using System.Linq;

namespace XUnitTestsForFoxxit
{
    public class UserManagementUnitTestsNewUserNameChange
    {
        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_1_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej babis",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_2_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej?babis",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_3_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej*babis",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_4_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_5_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andy/",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_6_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "a",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_7_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "ab",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_8_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszeman",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_9_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej/babis",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_10_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej-babis?",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_11_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej-babis!",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_12_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej-babis*",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_13_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej-babis=",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_14_ReturnsFalse()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej+babis=slunicko",
            };

            _ = controller.UsernameChange(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_15_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej-babis",
            };

            _ = controller.UsernameChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_16_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrej+babis",
            };

            _ = controller.UsernameChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_17_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "andrejbabis",
            };

            _ = controller.UsernameChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_18_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "---",
            };

            _ = controller.UsernameChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_19_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "___",
            };

            _ = controller.UsernameChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_20_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "+++",
            };

            _ = controller.UsernameChange(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestNewUserName_21_ReturnsTrue()
        {
            var controller = new Mock<FoxxitController>(null, null, null, null, null, null, null, null, null, null).Object;
            var model = new UsernameChangeViewModel
            {
                NewUserName = "a-n-D_Y",
            };

            _ = controller.UsernameChange(model);

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