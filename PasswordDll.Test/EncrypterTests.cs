using System;
using System.Diagnostics;
using System.Threading;
using EncrypterDll;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordDll.Test
{
	[TestClass]
	public class EncrypterTests : IDisposable
	{
		[TestInitialize]
		public void Init()
		{
			Debug.WriteLine($"TestInitialize {DateTime.Now}");
		}

		[TestCleanup]
		public void Cleanup()
		{
			Debug.WriteLine($"TestCleanup {DateTime.Now}");
		}

		[TestMethod]
		public void Encrypt_abc_cde()
		{
			#region Подготавливаем исходные данные для тестирования

			var input_str = "abc";
			var key = 1;
			var expected_result = "bcd";
			#endregion

			#region Тестируем целевой объект
			var actual_result = Encrypter.Encrypt(input_str, key);
			#endregion

			#region Проверяем результаты теста
			Assert.AreEqual(expected_result, actual_result, "Ошибка кодирования строки");
			#endregion
		}

		[TestMethod, Timeout(10), Description("Это метод тестирует...")]
		public void Encrypt_EmptyString()
		{
			var input = "";
			var key = 1;
			var expected = "";
		    Thread.Sleep(20);
			var actual = Encrypter.Encrypt(input, key);

			Assert.AreEqual(expected, actual);

			//StringAssert.Contains();
			//CollectionAssert.Contains();
		}

		//[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		//public void Encrypt_NullRef()
		//{
		//	string input = null;
		//	var key = 1;

		//	var actual = Encrypter.Encrypt(input, key);

		//	Assert.IsNull(actual);
		//}

		public void Dispose()
		{
			Debug.WriteLine($"Dispose {DateTime.Now}");
		}
	}
}
