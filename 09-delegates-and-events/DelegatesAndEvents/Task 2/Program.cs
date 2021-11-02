using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание подписчиков
            Person Mike = new Person("Mike");
            Person Den = new Person("Den");
            Person Ron = new Person("Ron");

            // Создание публикатора
            Office office = new Office();

            // Подписчики подписываются на события публикатора
            office.Come(Mike);
            office.PersonCame += Mike.SayHello;
            office.PersonLeft += Mike.SayGoodBye;
            office.Come(Den);
            office.PersonCame += Den.SayHello;
            office.PersonLeft += Den.SayGoodBye;
            office.Come(Ron);
            office.PersonCame += Ron.SayHello;
            office.PersonLeft += Ron.SayGoodBye;

            // Подписчики отписываются от событий публикатора
            office.PersonCame -= Mike.SayHello;
            office.PersonLeft -= Mike.SayGoodBye;
            office.Leave(Mike);
            office.PersonCame -= Den.SayHello;
            office.PersonLeft -= Den.SayGoodBye;
            office.Leave(Den);
            office.PersonCame -= Ron.SayHello;
            office.PersonLeft -= Ron.SayGoodBye;
            office.Leave(Ron);
        }
    }
}

// Output

//[Mike пришел на работу]
//[Den пришел на работу]
//Добрый день, Den - сказал Mike
//[Ron пришел на работу]
//Добрый день, Ron - сказал Mike
//Добрый день, Ron - сказал Den
//[Mike уходит с работы]
//До свидания, Mike - сказал Den
//До свидания, Mike - сказал Ron
//[Den уходит с работы]
//До свидания, Den - сказал Ron
//[Ron уходит с работы]
