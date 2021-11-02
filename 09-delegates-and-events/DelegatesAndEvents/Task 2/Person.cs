using System;
using System.Text;

namespace Task_2
{
    public class Person
    {
        private string greeting;
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        DateTime morningStartRef = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
        DateTime dayStartRef = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
        DateTime eveningStartRef = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);
        DateTime nightStartRef = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 0, 0);

        public void SayHello(string otherPerson, DateTime time)
        {
            StringBuilder sb = new StringBuilder();

            if (TimeSpan.Compare(time.TimeOfDay, morningStartRef.TimeOfDay) > 0 &&
                TimeSpan.Compare(time.TimeOfDay, dayStartRef.TimeOfDay) < 0)
                greeting = "Доброе утро";

            else if (TimeSpan.Compare(time.TimeOfDay, dayStartRef.TimeOfDay) > 0 &&
                     TimeSpan.Compare(time.TimeOfDay, eveningStartRef.TimeOfDay) < 0)
                greeting = "Добрый день";

            else if(TimeSpan.Compare(time.TimeOfDay, eveningStartRef.TimeOfDay) > 0 &&
                    TimeSpan.Compare(time.TimeOfDay, nightStartRef.TimeOfDay) < 0)
                greeting = "Добрый вечер";

            sb.Append(greeting);
            sb.Append(", ");
            sb.Append(otherPerson);
            sb.Append(" - сказал ");
            sb.Append(Name);

            Console.WriteLine(sb.ToString());
        }
        public void SayGoodBye(string otherName)
        {
            Console.WriteLine("До свидания, {0} - сказал {1}", otherName, Name);
        }
    }
}
