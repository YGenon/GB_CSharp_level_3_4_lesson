using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationModel
{
	internal class Program
	{
		public class Employee
		{
			public string Name { get; set; }

			[Required, Range(1, 100)]
			public int Age { get; set; }

			[StringLength(50, MinimumLength = 3)]
			public string Address { get; set; }
		}

		private static void Main()
		{
			Console.WriteLine("Введите возраст:");
			int age = Int32.Parse(Console.ReadLine());

			Console.WriteLine("Введите aдрес:");
			string address = Console.ReadLine();

			Employee employee = new Employee { Address = address, Age = age };

			var results = new List<ValidationResult>();
			var context = new ValidationContext(employee);
			if (!Validator.TryValidateObject(employee, context, results, true))
			{
				foreach (var error in results)
				{
					Console.WriteLine(error.ErrorMessage);
				}
			}
			Console.Read();
		}

	}
}
