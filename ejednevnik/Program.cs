namespace ejednevnik
{
    internal class Program  //Общий класс
    {
        public static List<Dela> List = new List<Dela>(); //Создаем лист. *Лист - место, где хранятся наши данные
        static List<Dela> searchTasks(DateTime date) //Поиск дел на дату, на которой мы находимся
        {
            List<Dela> response = new List<Dela>();
            foreach (Dela task in List)
            {
                if (task.date == date)
                    response.Add(task);
            }
            return response;
        }
        static void newTask(DateTime data) //Начало части, где мы можем создать свою задачу (если на выбранной дате их нет)
        {
            Console.Write("Введите название: "); //Создаем свое название дела
            string title = Console.ReadLine(); //
            Console.Write("Введите описание: "); //
            string description = Console.ReadLine();
            List.Add(new Dela() //Наш лист, который находится в другом классе
            {
                date = data, 
                title = title,
                desc = description,
            });
            Console.WriteLine("  Выход");
            Console.ReadKey(); //Чтение кнобки
        }
        static void Main(string[] args) //Начало части, где у нас уже установленны дела на определенные даты
        {
            for (int i = 0; i < 5; i++) //
                List.Add(new Dela()); //Добавляет обьект

            List[0] = new Dela() //Подключаем дела и переменные из листа №1
            {
                date = new DateTime(2022, 11, 07),
                title = "Покушать",
                desc = "Макароны с пюрешкой"
            };

            List[1] = new Dela() //Подключаем дела и переменные из листа №2
            {
                date = new DateTime(2022, 11, 08),
                title = "Спать",
                desc = "Долго"
            };

            List[2] = new Dela() //Подключаем дела и переменные из листа №3
            {
                date = new DateTime(2022, 11, 09),
                title = "Сходить в библиотеку",
                desc = "Прочитать ранобе"
            };

            List[3] = new Dela() //Подключаем дела и переменные из листа №4
            {
                date = new DateTime(2022, 11, 07),
                title = "Помочь",
                desc = "Себе"
            };

            List[4] = new Dela() //Подключаем дела и переменные из листа №5
            {
                date = new DateTime(2022, 11, 07),
                title = "Исполнить мечту",
                desc = "Я хочу быть счастливым Т-Т"
            };

            DateTime currentDate = DateTime.Now; //Начало части, где у нас прописана функция DateTime (Счетчик времени)
            currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0); //Выбранная дата будет записана так: год,месяц, день
            int position = 1; //Задаем позицию курсора
            int maxPosition;
            while (true)
            {
                Console.Clear(); //Очищает консоль
                Console.WriteLine($"Задачи на {currentDate.ToShortDateString()}"); //Выводит задачи на ВЫБРАННУЮ нами дату

                string cursor = "->"; //Как выглядитв наш курсор
                List<Dela> todayTasks = searchTasks(currentDate); //Проверяем, есть ли на эту дату дела, если нет, то мы смлжем создаеть их
                maxPosition = todayTasks.Count + 1; 
                foreach (var task in todayTasks)
                {
                    Console.WriteLine("     " + task.title);
                }
                Console.WriteLine("     Создать новую задачу");
                Console.SetCursorPosition(0, position);
                Console.WriteLine(cursor); //Вывод курсора
                ConsoleKeyInfo keyPressed = Console.ReadKey(); //Чтение кнопки клавиатуры, на которуую мы нажали
                switch (keyPressed.Key) //Конструкция case
                {
                    case ConsoleKey.RightArrow: //Смещение позиции вправо на 1
                        currentDate = currentDate.AddDays(1);
                        position = 1;
                        break;
                    case ConsoleKey.LeftArrow: //Смещение позиции влево на 1
                        currentDate = currentDate.AddDays(-1);
                        position = 1;
                        break;
                    case ConsoleKey.DownArrow: //Смещение позиции вниз на 1
                        if (position != maxPosition)
                            position++;
                        break;
                    case ConsoleKey.UpArrow: //Смещение позиции вверх на 1
                        if (position != 1)
                            position--;
                        break;
                    case ConsoleKey.Enter: //Принажатии ентера мы применяем то, что выбрали
                        if (position == maxPosition)
                        {
                            newTask(currentDate);
                        }
                        else
                        {
                            Dela ourTask = todayTasks[position - 1];
                            Console.Clear();
                            Console.WriteLine(ourTask.title);
                            Console.WriteLine(ourTask.desc);
                            Console.WriteLine(cursor + "Выход");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }
}