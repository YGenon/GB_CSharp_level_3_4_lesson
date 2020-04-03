using System;
using System.Diagnostics;
using CodePasswordDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodePasswordDLLTest
{
    [TestClass]
    public class CodePasswordTest : IDisposable
    {
        CodePassword codePasswd;

        [TestInitialize]
        public void Init()
        {               
            codePasswd = new CodePassword();           
        }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine($"TestCleanup - конец теста {DateTime.Now}");
        }

        [TestMethod]
        public void Crypt_qwerty_to_pvdqsx()
        {
            var input_str = "qwerty";
            var expected_result = "pvdqsx";

            var actual_result = codePasswd.getPassword(input_str);

            Assert.AreEqual(expected_result, actual_result, "Ошибка кодирования строки");
            
            Debug.WriteLine($"Тестовое сообщение внутри теста");
        }

        [TestMethod]
        public void StringAssert_crypt_qwerty_to_pvdqsx()
        {
            var input_str = "qwerty";
            var expected_result = "pvdqsx";

            var actual_result = codePasswd.getPassword(input_str);

            StringAssert.Equals(expected_result, actual_result);
           
        }

        public void Dispose()
        {
            Debug.WriteLine($"Dispose {DateTime.Now}");
        }
    }
}
