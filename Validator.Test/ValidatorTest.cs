using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validator.Test
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void EmailAddressTest()
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

           EmailValidator emailValidator = new EmailValidator();
            foreach (var valid in validEmails)
            {
                Assert.IsTrue(emailValidator.IsValid(valid), String.Format("{0} : is Valid but says invalid ", valid));
            }

            foreach (var invalid in inValidEmails)
            {
                Assert.IsFalse(emailValidator.IsValid(invalid), String.Format("{0} : is Invalid but says valid ", invalid));
            }

        }


        [TestMethod]
        public void UrlValidatorTest()
        {
            List<string> validUrls = new List<string>()
            {
                "http://foo.com/blah_blah","http://foo.com/blah_blah/","http://foo.com/blah_blah_(wikipedia)","http://foo.com/blah_blah_(wikipedia)_(again)","http://www.example.com/wpstyle/?p=364","https://www.example.com/foo/?bar=baz&inga=42&quux","http://✪df.ws/123","http://userid:password@example.com:8080","http://userid:password@example.com:8080/","http://userid@example.com","http://userid@example.com/","http://userid@example.com:8080","http://userid@example.com:8080/","http://userid:password@example.com","http://userid:password@example.com/","http://142.42.1.1/","http://142.42.1.1:8080/","http://➡.ws/䨹","http://⌘.ws","http://⌘.ws/","http://foo.com/blah_(wikipedia)#cite-1","http://foo.com/blah_(wikipedia)_blah#cite-1","http://foo.com/unicode_(✪)_in_parens","http://foo.com/(something)?after=parens","http://☺.damowmow.com/","http://code.google.com/events/#&product=browser","http://j.mp","ftp://foo.bar/baz","http://foo.bar/?q=Test%20URL-encoded%20stuff","http://مثال.إختبار","http://例子.测试","http://उदाहरण.परीक्षा","http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com","http://1337.net","http://a.b-c.de","http://223.255.255.254"
            };

            List<string> inValidUrls = new List<string>()
            {
                "http://",
                "http://.",
                "http://..",
                "http://../",
                "http://?",
                "http://??",
                "http://??/",
                "http://#","http://##","http://##/",
//                "http://foo.bar?q=Spaces should be encoded",
                "//",
                "//a",
                "///a","///","http:///a","foo.com","rdar://1234","h://test","http:// shouldfail.com",":// should fail",
                "http://foo.bar/foo(bar)baz quux",
                "ftps://foo.bar/","http://-error-.invalid/","http://a.b--c.de/","http://-a.b.co","http://a.b-.co","http://0.0.0.0","http://10.1.1.0","http://10.1.1.255","http://224.1.1.1","http://1.1.1.1.1","http://123.123.123","http://3628126748","http://.www.foo.bar/","http://www.foo.bar./","http://.www.foo.bar./","http://10.1.1.1","http://10.1.1.254"
            };
            UrlValidator urlValidator = new UrlValidator();
            foreach (var valid in validUrls)
            {
                Assert.IsTrue(urlValidator.IsValid(valid), String.Format("{0} : is Valid but says invalid ", valid));
            }

            foreach (var invalid in inValidUrls)
            {
                Assert.IsFalse(urlValidator.IsValid(invalid), String.Format("{0} : is Invalid but says valid ", invalid));
            }

        }
    }
}
