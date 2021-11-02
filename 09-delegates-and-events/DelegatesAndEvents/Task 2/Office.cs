using System;

namespace Task_2
{
    // Делегат определяет сигнатуру для метода обработчика события
    // класса подписчика
    public delegate void PersonCame(string name, DateTime time);
    public delegate void PersonLeft(string name);

    class Office
    {
        // Класс Office является публикатором событий
        public Office(/*List<Person> persons*/)
        {
        }

        // Класс будет публиковать данные события
        public event PersonCame PersonCame;
        public event PersonLeft PersonLeft;

        public void Come(Person p)
        {
            OfficeEventArgs args = new OfficeEventArgs();
            args.Name = p.Name;
            args.Timing = DateTime.Now;

            Console.WriteLine("[{0} пришел на работу]", p.Name);
            OnPersonCame(args);
        }

        public void Leave(Person p)
        {
            OfficeEventArgs args = new OfficeEventArgs();
            args.Name = p.Name;
            args.Timing = DateTime.Now;

            Console.WriteLine("[{0} уходит с работы]", p.Name);
            OnPersonLeft(args);
        }

        protected virtual void OnPersonCame(OfficeEventArgs args)
        {
            // Вызвать делегат, если PersonCame не null
            PersonCame?.Invoke(args.Name, args.Timing);
        }

        protected virtual void OnPersonLeft(OfficeEventArgs args)
        {
            // Вызвать делегат, если PersonLeft не null
            PersonLeft?.Invoke(args.Name);
        }
    }

    public class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public DateTime Timing { get; set; }
    }
}
