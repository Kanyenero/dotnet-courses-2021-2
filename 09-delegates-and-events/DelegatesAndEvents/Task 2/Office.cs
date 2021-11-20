using System;

namespace Task_2
{
    public delegate void PersonCame(string name, DateTime time);
    public delegate void PersonLeft(string name);

    class Office
    {
        public Office() {}

        public event PersonCame PersonCame;
        public event PersonLeft PersonLeft;

        public void Come(Person p)
        {
            OfficeEventArgs args = new OfficeEventArgs();
            args.Name = p.Name;
            args.Timing = DateTime.Now;

            Console.WriteLine("[{0} пришел на работу]", p.Name);
            OnPersonCame(args);

            PersonCame += p.SayHello;
            PersonLeft += p.SayGoodBye;
        }

        public void Leave(Person p)
        {
            OfficeEventArgs args = new OfficeEventArgs();
            args.Name = p.Name;
            args.Timing = DateTime.Now;

            Console.WriteLine("[{0} уходит с работы]", p.Name);

            PersonCame -= p.SayHello;
            PersonLeft -= p.SayGoodBye;
            OnPersonLeft(args);
        }

        protected virtual void OnPersonCame(OfficeEventArgs args)
        {
            PersonCame?.Invoke(args.Name, args.Timing);
        }

        protected virtual void OnPersonLeft(OfficeEventArgs args)
        {
            PersonLeft?.Invoke(args.Name);
        }
    }

    public class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public DateTime Timing { get; set; }
    }
}
