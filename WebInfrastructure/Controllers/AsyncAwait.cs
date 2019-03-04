using System;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Controllers
{
	public class AsyncAwait
	{
		private int miliDelay = 1000;

		public async Task<string> DelayFunc(string line = "")
		{
			Console.WriteLine("..................."+line);

			Task<string> task = Task3();

			var response = await task;
			return response;
		}

		public async Task<string> Task3()
		{
			var wa = Task.Delay(1000);
			await wa;
			var person = new Person()
			{
				Name = "Park Hang Seo",
				Age = 39
			};
			var JSONPerson = new StringBuilder();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);

			return JSONPerson.ToString();
		}

		public AsyncAwait()
		{
		}

		public async Task<string> FullTask(int run = 0)
		{
			Task<string> task_1 = new Task<string>(() => task1(run));
			Task task_2 = new Task(() => task2(run));

			//task_1.Start();
			//task_2.Start();

			getBegin(run);

			getIntermediate(run);
			getTheEnd(run);
			//await Task.WhenAll(task_1.Start(), task_2.Start());
			await Task.Run(() => getCategories(run));
			await Task.Run(() => task2(run));
			string response = await task_1;

			Console.WriteLine(response);

			Console.WriteLine("The end of AsyncAwait.......... 1");
			Console.WriteLine("The end of AsyncAwait.......... 2");
			Console.WriteLine("The end of AsyncAwait.......... 3");
			Console.WriteLine("The end of AsyncAwait.......... 4");
			return response;
		}

		public async Task TestHowToBeAsync()
		{
			Console.WriteLine(DateTime.Now);

			// This block takes 1 second to run because all
			// 5 tasks are running simultaneously
			{
				var a = DelayFunc("a");				
				var b = DelayFunc("b");				
				var c = DelayFunc("c");				
				var d = DelayFunc();
				var e = DelayFunc();

				await a;
				Console.WriteLine(DateTime.Now);
				await b;
				Console.WriteLine(DateTime.Now);
				await c;
				Console.WriteLine(DateTime.Now);
				await d;
				Console.WriteLine(DateTime.Now);
				await e;
			}

			Console.WriteLine(DateTime.Now);

			// This block takes 5 seconds to run because each "await"
			// pauses the code until the task finishes
			{
				await DelayFunc();
				Console.WriteLine(DateTime.Now);
				await DelayFunc();
				Console.WriteLine(DateTime.Now);
				await DelayFunc();
				Console.WriteLine(DateTime.Now);
				await DelayFunc();
				Console.WriteLine(DateTime.Now);
				await DelayFunc();
			}
			Console.WriteLine(DateTime.Now);
			/*
			5 / 24 / 2017 2:22:50 PM
			5 / 24 / 2017 2:22:51 PM(First block took 1 second)
			5 / 24 / 2017 2:22:56 PM(Second block took 5 seconds)
			*/
		}

		private void task2(int number)
		{
			var person = new Person()
			{
				Name = "Park Hang Seo",
				Age = 39
			};
			Console.WriteLine("....... task2 1." + number + "......");
			DelayFunc();

			var JSONPerson = new StringBuilder();
			Console.WriteLine("....... task2 2." + number + "......");
			DelayFunc();

			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine("....... task2 3." + number + "......");
			DelayFunc();

			Console.WriteLine("....... task2 4." + number + "......");
			DelayFunc();

			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine("....... task2 5." + number + "......");
			DelayFunc();

			Console.WriteLine("....... task2 6." + number + "......");
			DelayFunc();

			Console.WriteLine("....... task2 7." + number + "......");
			DelayFunc();

			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine("....... task2 8." + number + "......");
			DelayFunc();

			Console.WriteLine("....... task2 9." + number + "......");
			DelayFunc();

			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine("....... task2 10." + number + "......");
			DelayFunc();
		}

		private void getCategories(int number = 0)
		{
			Console.WriteLine(".... getCategories 1." + number);
			DelayFunc();
			Console.WriteLine(".... getCategories 2." + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 3." + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 4. " + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 5. " + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 6. " + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 7. " + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 8. " + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 9. " + number);
			DelayFunc();

			Console.WriteLine(".... getCategories 10. " + number);
			DelayFunc();
		}

		private string task1(int number = 0)
		{
			var person = new Person()
			{
				Name = "Park Hang Seo",
				Age = 39
			};
			Console.WriteLine(".... task1 1." + number + "....");
			DelayFunc();
			var JSONPerson = new StringBuilder();
			Console.WriteLine(".... task1 2." + number + "....");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".... task1 3." + number + "....");
			DelayFunc();
			Console.WriteLine(".... task1 4." + number + "....");
			DelayFunc();
			Console.WriteLine(".... task1 5." + number + "....");
			DelayFunc();
			Console.WriteLine(".... task1 6." + number + "....");
			DelayFunc();
			Console.WriteLine(".... task1 7." + number + "....");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".... task1 8." + number + "....");
			DelayFunc();
			Console.WriteLine(".... task1 9." + number + "....");
			DelayFunc();
			Console.WriteLine(".... task1 10." + number + "....");

			return JSONPerson.ToString();
		}

		private void getBegin(int number = 0)
		{
			var person = new Person()
			{
				Name = "Park Hang Seo",
				Age = 39
			};
			Console.WriteLine(".....................begin 1." + number + "..................");
			DelayFunc();
			var JSONPerson = new StringBuilder();
			Console.WriteLine(".....................begin 2." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................begin 3." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................begin 4." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................begin 5." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................begin 6." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................begin 7." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................begin 8." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................begin 9." + number + "..................");
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			DelayFunc();
			Console.WriteLine(".....................begin 10." + number + "..................");
		}

		private void getIntermediate(int number = 0)
		{
			var person = new Person()
			{
				Name = "Park Hang Seo",
				Age = 39
			};
			Console.WriteLine(".....................intermediate 1." + number + "..................");
			DelayFunc();
			var JSONPerson = new StringBuilder();
			Console.WriteLine(".....................intermediate 2." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................intermediate 3." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................intermediate 4." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................intermediate 5." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................intermediate 6." + number + "..................");
			DelayFunc();

			Console.WriteLine(".....................intermediate 7." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................intermediate 8." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................intermediate 9." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................intermediate 10." + number + "..................");
			DelayFunc();
		}

		private void getTheEnd(int number = 0)
		{
			var person = new Person()
			{
				Name = "Park Hang Seo",
				Age = 39
			};
			Console.WriteLine(".....................the_end 1." + number + "..................");
			DelayFunc();
			var JSONPerson = new StringBuilder();
			Console.WriteLine(".....................the_end 2." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................the_end 3." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................the_end 4." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................the_end 5." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................the_end 6." + number + "..................");
			DelayFunc();

			Console.WriteLine(".....................the_end 7." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................the_end 8." + number + "..................");
			DelayFunc();
			Console.WriteLine(".....................the_end 9." + number + "..................");
			DelayFunc();
			JSONPerson = JSONPerson.Append(person.Name + " " + person.Age);
			Console.WriteLine(".....................the_end 10." + number + "..................");
			DelayFunc();
		}
	}
}