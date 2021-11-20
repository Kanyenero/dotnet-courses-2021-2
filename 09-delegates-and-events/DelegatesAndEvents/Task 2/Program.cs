using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Mike = new Person("Mike");
            Person Den = new Person("Den");
            Person Ron = new Person("Ron");

            Office office = new Office();

            office.Come(Mike);
            office.Come(Den);
            office.Come(Ron);

            office.Leave(Mike);
            office.Leave(Den);
            office.Leave(Ron);
        }
    }
}

// Output

//[Mike пришел на работу]
//[Den пришел на работу]
//Добрый вечер, Den - сказал Mike
//[Ron пришел на работу]
//Добрый вечер, Ron - сказал Mike
//Добрый вечер, Ron - сказал Den
//[Mike уходит с работы]
//До свидания, Mike - сказал Den
//До свидания, Mike - сказал Ron
//[Den уходит с работы]
//До свидания, Den - сказал Ron
//[Ron уходит с работы]
