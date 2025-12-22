using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	public enum Operation { Add, Subtract, Multiply, Divide }

	public class CalculatorController : Controller
    {
        private CalculatorContext _context;

        public CalculatorController(CalculatorContext context)
        {
            _context = context;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Calculate(double num1, double num2, Operation operation)
		{
			double result = 0;

			switch (operation)
			{
				case Operation.Add:
					result = num1 + num2;
					break;
				case Operation.Subtract:
					result = num1 - num2;
					break;
				case Operation.Multiply:
					result = num1 * num2;
					break;
				case Operation.Divide:
					if (num2 == 0)
					{
						ViewBag.Error = "Деление на ноль невозможно!";
						return View("Index");
					}
					result = num1 / num2;
					break;
			}
			ViewBag.Result = result;
            ViewBag.Num1 = num1;
            ViewBag.Num2 = num2;
            ViewBag.Operation = operation;

            DataInputVarian dataInputVarian = new();
			dataInputVarian.Num1 = num1.ToString();
			dataInputVarian.Num2 = num2.ToString();
            dataInputVarian.Operation = operation.ToString();
            dataInputVarian.Result = result.ToString();

			_context.DataInputVarians.Add(dataInputVarian);
            // _context.SaveChanges();

            try
            {
                int saved = _context.SaveChanges();
                Console.WriteLine($"=== DEBUG: Сохранено записей: {saved} ===");

                if (saved > 0)
                {
                    Console.WriteLine($"ID новой записи: {dataInputVarian.ID_DataInputVarian}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== DEBUG: ОШИБКА: {ex.Message} ===");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                ViewBag.Error = "Ошибка сохранения: " + ex.Message;
            }

            return View("Index");
		}
	}

}
