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

        [Fact]
        public void RegistrationModelStateValidationTestEmail_15_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej@seznam.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_16_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrejbabis@seznam.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_17_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej-babis@seznam.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_18_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "andrej_babis@gov.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_19_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "Andrej_Babis-Milos_Zeman@seznam.vlada.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_20_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "a-b@seznam.milosovo-vlada.cz",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_21_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "jirka.milos.mirek.andrej@nase-.spasa_vlada.uk",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_22_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "...@---.---",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_23_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = ".mila-andy/miravasek-_(alenka).@vl./_-ada.-s-",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_24_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "m@",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_25_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-correct-long-email-@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_26_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "@s",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestEmail_27_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = ".mila-andy-miravasek-__alenka__.@vl._-ada.-s-",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_1_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej babis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej?babis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej*babis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_4_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_5_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andy/",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_6_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "a",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_7_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "ab",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_8_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszemanandrejbabis-miloszeman",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_9_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej/babis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_10_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej-babis?",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_11_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej-babis!",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_12_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej-babis*",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_13_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej-babis=",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_14_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej+babis=slunicko",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_15_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej-babis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_16_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrej+babis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_17_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_18_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "---",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_19_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "___",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_20_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "+++",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestUsername_21_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdasd",
                Password = "asdasd",
                UserName = "a-n-D_Y",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_0_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "           ",
                Password = "           ",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_1_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asd",
                Password = "asd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "asdqw",
                Password = "asdqw",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "correctpasswordcorrectpasswordcorrectpasswordcorrectpasswordcorrectpassword",
                Password = "correctpasswordcorrectpasswordcorrectpasswordcorrectpasswordcorrectpassword",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_4_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "correctpassword",
                Password = "correctpassword",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_5_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"`        ",
                Password = @"`        ",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_6_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "/ * - + () [] {}",
                Password = "/ * - + () [] {}",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_7_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "******",
                Password = "******",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_8_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = "/-/-/-/-/-/",
                Password = "/-/-/-/-/-/",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_9_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"`~???\\/<>/*-**PKe..",
                Password = @"`~???\\/<>/*-**PKe..",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestPassword_10_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"`          ~???\\/<>/*-**PKe..",
                Password = @"`          ~???\\/<>/*-**PKe..",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.True(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_1_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"qweqwe",
                Password = @"asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_2_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"asdasd ",
                Password = @"asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_3_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"ASDASD",
                Password = @"asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_4_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"",
                Password = @"asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_5_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @" asdasd",
                Password = @"asdasd",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_6_ReturnsFalse()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"",
                Password = @"",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

            Assert.False(!ValidateModel(model).Any());
        }

        [Fact]
        public void RegistrationModelStateValidationTestConfirmPassword_7_ReturnsTrue()
        {
            var controller = new Mock<AccountController>(null, null, null, null).Object;
            var model = new RegisterViewModel
            {
                Email = "correct@email.com",
                ConfirmPassword = @"ubrouskuprostrise",
                Password = @"ubrouskuprostrise",
                UserName = "andrejbabis",
            };

            _ = controller.Register(model);

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