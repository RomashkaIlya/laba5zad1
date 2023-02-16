using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace testsesta
{
    class MainClass
    {
        //public static object a { get; private set; }

        public enum Type { Тр,Тс,А, Неизвестен }

        struct TypeOfTransport
        {
            public double timeToRoad;//время в дороге
            public string number;//номер маршрута
            public double km;//протяженность в км
            public Type type;
                    
            
                //Console.WriteLine("Тип Трансорта,номер транспорта,протяженность маршрута(км),время в дороге(мин)");
            
            public void DisplayInfo()
            {
                Console.WriteLine($"|{type,-20 } | {number,-20}| {km,-20} |{timeToRoad,-21}|");
            }
        }

        struct Log
        {
            public string number;
            public DateTime time;
            public string operation;

            public void DisplayLog()
            {
                Console.WriteLine($"{time,-20} {operation,-20} {number,-20}");
            }
        }

        public static void Main(string[] args)
        {
            TypeOfTransport Tram;
            Tram.number = "12" ;
            Tram.km = 27.2;
            Tram.timeToRoad = 75;
            Tram.type = Type.Тр;

            TypeOfTransport trolleybus;
            trolleybus.number = "17";
            trolleybus.km = 13;
            trolleybus.timeToRoad = 57;
            trolleybus.type = Type.Тс;

            TypeOfTransport bus;
            bus.number = "12a";
            bus.km = 57;
            bus.timeToRoad = 117;
            bus.type = Type.А;

            var Table = new List<TypeOfTransport>();
            Table.Add(Tram);
            Table.Add(trolleybus);
            Table.Add(bus);

            var Log = new List<Log>();
            DateTime time_1 = DateTime.Now;
            DateTime time_2 = DateTime.Now;
            TimeSpan timeInterval_1 = time_2 - time_1;

            string Menu = "\n1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Выход\n";
            bool optionError = true;

            do
            {
                Console.WriteLine(Menu);
                int Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1: // Просмотр таблицы                  
                        Console.WriteLine("|Тип Трансорта        |номер транспорта     |протяженность (км)    |время в дороге(мин)  |");
                        for (int i = 0; i < Table.Count; i++)
                        {

                            Table[i].DisplayInfo();
                        }
                        break;
                        case 2://добавить запись
                        {
                            Console.WriteLine("введите номер маршрута");
                            string number = Console.ReadLine();

                            Console.WriteLine("введите протяженность маршрута(км)");
                            double km = double.Parse(Console.ReadLine());
                            //нужно сделать опретор объединения с null
                            Console.WriteLine("введите время в дороге(минуты)");
                            int timeToRoad = int.Parse(Console.ReadLine());

                            Console.WriteLine("введите тип транспорта:(Тр - трамвай,Тс - троллейбус,А - автобус)");
                            var type = Type.Неизвестен;
                            bool typeError = false;
                            do 
                            {
                                string choiceType = Console.ReadLine();

                                if (choiceType == "Тс"|| choiceType == "Tc")
                                {
                                    type = Type.Тр;
                                    typeError = false;
                                }
                                else if (choiceType == "Тр" || choiceType == "Tp")
                                {
                                    type = Type.Тс;
                                    typeError = false;
                                }
                                else if (choiceType == "А" || choiceType == "A")//слева рус,справа англ
                                {
                                    type = Type.А;
                                    typeError = false;
                                }                               
                                else
                                {
                                    Console.WriteLine("введите ПРАВИЛЬНЫЙ тип транспорта:(Тр - трамвай,Тс - троллейбус,А - автобус)");
                                    typeError = true;
                                }
                            }
                            while (typeError == true);
                            TypeOfTransport newtypeOfTransport;
                            newtypeOfTransport.type = type;
                            newtypeOfTransport.km = km;
                            newtypeOfTransport.timeToRoad = timeToRoad;
                            newtypeOfTransport.number = number;
                            Table.Add(newtypeOfTransport);

                            Log newLog;
                            newLog.number = Convert.ToString(number);
                            newLog.time = DateTime.Now;
                            newLog.operation = "Запись добавлена!";
                            Log.Add(newLog);

                            time_1 = DateTime.Now;
                            TimeSpan timeInterval_2 = time_1 - time_2;
                            if (timeInterval_1 < timeInterval_2)
                            {
                                timeInterval_1 = timeInterval_2;
                            }
                            time_2 = newLog.time;




                        }
                        break ;

                    case 3: // Удалить запись
                        {
                            Console.Write("Введите номер записи: ");

                            bool deleteError = false;
                            do // (1, 2, 3, 4, 5, 6, 7)
                            {
                                deleteError = false;

                                int choiceNumberDelete = Convert.ToInt32(Console.ReadLine());
                                if (choiceNumberDelete > 0 && choiceNumberDelete < Table.Count+1)
                                {
                                  
                                    Log newDelete;
                                    newDelete.number = Table[choiceNumberDelete - 1].number ;////
                                    newDelete.time = DateTime.Now;
                                    newDelete.operation = "Запись удалена!";
                                    Log.Add(newDelete);
                                    Table.RemoveAt(choiceNumberDelete - 1);

                                    time_1 = DateTime.Now;
                                    TimeSpan timeInterval_2 = time_1 - time_2;
                                    if (timeInterval_1 < timeInterval_2)
                                    {
                                        timeInterval_1 = timeInterval_2;
                                    }
                                    time_2 = newDelete.time;
                                    Console.WriteLine("запись удалена");

                                }
                                else
                                {
                                    Console.WriteLine("Введите правильный номер! (1, 2, 3, 4, 5, 6, 7)");
                                    deleteError = true;
                                }
                            }
                            while (deleteError == true);
                        }
                        break;

                    case 4: // заменить запись
                        {
                            Console.Write("Введите номер записи: ");

                            bool changeError = false;
                            do // (1, 2, 3, 4, 5, 6, 7)
                            {
                                int choiceNumberChange = Convert.ToInt32(Console.ReadLine());
                                if (choiceNumberChange > 0 && choiceNumberChange < Table.Count+1)
                                {
                                    string oldNumber = Table[choiceNumberChange - 1].number;
                                    Console.WriteLine("введите номер маршрута: ");
                                    string number = Console.ReadLine();
                                    if (number == String.Empty)
                                    {
                                        number = oldNumber;
                                    }

                                    double oldkm = Table[choiceNumberChange - 1].km;
                                    Console.WriteLine("введите протяженность маршрута(км): ");
                                    string km = Console.ReadLine();
                                    if (km == String.Empty)
                                    {
                                        km = Convert.ToString(oldkm);
                                    }

                                    double oldtimetoroad = Table[choiceNumberChange - 1].timeToRoad;
                                    Console.WriteLine("введите время в дороге(минуты): ");
                                    string timeToRoad = Convert.ToString(Console.ReadLine());                                   
                                    if (timeToRoad == string.Empty)
                                    {
                                        timeToRoad = Convert.ToString(oldtimetoroad);
                                        changeError = false;
                                    }
                                    

                                    var oldType = Table[choiceNumberChange - 1].type;
                                    Console.WriteLine("введите тип транспорта:(Тр - трамвай,Тс - троллейбус,А - автобус)");
                                    var type = Type.Неизвестен;

                                    bool typeError = false;
                                    do 
                                    {
                                        string choiceType = Console.ReadLine();
                                        if (choiceType == "Тр"|| choiceType =="Tp ")
                                        {
                                            type = Type.Тр;
                                            typeError = false;
                                        }
                                        else if (choiceType == "А" || choiceType == "A")
                                        {
                                            type = Type.А;
                                            typeError = false;
                                        }
                                        else if (choiceType == "Tc" || choiceType == "Тс")
                                        {
                                            type = Type.Тс;
                                            typeError = false;
                                        }
                                        
                                        else if (choiceType == String.Empty)
                                        {
                                            type = oldType;
                                        }
                                        else
                                        {
                                            Console.WriteLine("введите ПРАВИЛЬНЫЙ тип транспорта:(Тр - трамвай,Тс - троллейбус,А - автобус)");
                                            typeError = true;
                                        }
                                    }
                                    while (typeError == true);
                                    TypeOfTransport typeOfTransport;
                                    typeOfTransport.number = number;
                                    typeOfTransport.type = type;
                                    typeOfTransport.km = Convert.ToDouble(km);
                                    typeOfTransport.timeToRoad = Convert.ToDouble(timeToRoad);
                                    Table.RemoveAt(choiceNumberChange - 1  );
                                    Table.Insert(choiceNumberChange - 1, typeOfTransport);

                                    Log NewLog;
                                    NewLog.number = number;
                                    NewLog.time = DateTime.Now;
                                    NewLog.operation = "запись обновлена";
                                    Log.Add(NewLog);




                                }
                                else
                                {
                                    Console.WriteLine("Введите правильный номер! (1, 2, 3, 4, 5, 6, 7)");
                                }
                            }
                            while (changeError == true);

                        }
                        break;
                    case 5: //поиск записей
                         {
                            Console.WriteLine("введите тип транспорта:(р - трамвай,с - троллейбус,а - автобус)");

                            bool seatchError = false;
                            do 
                            {
                                int choiceNumberSearch = Convert.ToChar(Console.ReadLine());
                                if (choiceNumberSearch == 'а'||choiceNumberSearch == 'а')
                                {
                                    var records = Table.FindAll(i => i.type == Type.А);
                                    foreach (var record in records)
                                    {
                                        record.DisplayInfo();
                                    }
                                    seatchError = false;
                                }
                                else if (choiceNumberSearch == 'р' || choiceNumberSearch == 'p')
                                {
                                    var records = Table.FindAll(i => i.type == Type.Тр);
                                    foreach (var record in records)
                                    {
                                        record.DisplayInfo();
                                    }
                                    seatchError = false;
                                }
                                else if (choiceNumberSearch == 'c' || choiceNumberSearch == 'с')
                                {
                                    var records = Table.FindAll(i => i.type == Type.Тс);
                                    foreach (var record in records)
                                    {
                                        record.DisplayInfo();
                                    }
                                    seatchError = false;
                                }
                               
                                else
                                {
                                    Console.WriteLine("введите ПРАВИЛЬНЫЙ тип транспорта:(р - трамвай,с - троллейбус,А - автобус)");
                                    seatchError = true;
                                }
                            }
                            while (seatchError == true);



                         }
                        break ;
                    case 6: // Просмотреть лог,работает неправильно

                        {
                            for (int i = 0; i < Log.Count; i++)
                            {
                                Log[i].DisplayLog();
                            }
                            Console.WriteLine();
                            Console.WriteLine(timeInterval_1 + " - Самый долгий период бездействия пользователя");
                        }
                        break;
                    case 7: // Выход
                        {
                            optionError = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Введите правильную команду!");
                        optionError = true;
                        break;




                }       
            } while (optionError);
        }
    }
}
            
