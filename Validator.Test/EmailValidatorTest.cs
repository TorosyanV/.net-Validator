using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validator.Test
{
    [TestClass]
    public class EmailValidatorTest
    {
        [TestMethod]
        public void IsValidEmailAddressTest()
        {
            List<String> validEmails = new List<string>()
            {
                "email@example.com",
                "firstname.lastname@example.com",
                "email@subdomain.example.com",
                "firstname+lastname@example.com",
                "email@123.123.123.123",
                "email@[123.123.123.123]",
                "\"email\"@example.com",
                "1234567890@example.com",
                "email@example-one.com",
                "email@example.name",
                "email@example.museum",
                "email@example.co.jp",
                "firstname-lastname@example.com",
               "jones@ms1.proseware.com",
                "david.jones@proseware.com",
                "d.j@server1.proseware.com",
                "j@proseware.com9",
                "js#internal@proseware.com",
                "j_9@[129.126.118.1]",
                "js@proseware.com9",
                "j.s@server1.proseware.com",
                "\"j\\\"s\\\"\"@proseware.com",
                "js@contoso.中国",
            };
            List<String> inValidEmails = new List<string>()
            {
               "j..s@proseware.com",
               "js*@proseware.com",
               "js@proseware..com",
               "j.@server1.proseware.com",
               "----@---.com",
               ".text.text@text.text",
                "#@%^%#$@#$@#.com",
                "@example.com",
                "Joe Smith <email@example.com>",
                "email.example.com",
                "email@example@example.com",
                ".email@example.com",
                "email.@example.com",
                "email..email@example.com",
                "あいうえお@example.com",
                "email@example.com (Joe Smith)",
                "email@example",
                "email@-example.com",
                "email@example..com",
                "Abc..123@example.com",
            };

            AbstractValidator<String> emailValidator = new EmailValidator();
            foreach (var valid in validEmails)
            {
                Assert.IsTrue(emailValidator.IsValid(valid), String.Format("{0} : is Valid but says invalid ", valid));
            }

            foreach (var invalid in inValidEmails)
            {
                Assert.IsFalse(emailValidator.IsValid(invalid), String.Format("{0} : is Invalid but says valid ", invalid));
            }

        }

    }
}
