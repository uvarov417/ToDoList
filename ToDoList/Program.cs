// Возможность ставить дедлайн
// 1. Спросить у пользователя, хочет ли он поставить дедлайн на задачу
// 2. Если хочет поставить дедлайн, то попросить ввести дату и сохранить. Если нет, то ничего не записывать

using System.Drawing;

namespace ToDoList
{
    internal class Program
    {
        private static List<ToDoItem> _toDoList;
        private static Point _currentCursorPosition;

        static void Main(string[] args)
        {
            _toDoList = new List<ToDoItem>() 
            {
                new ToDoItem("Вынести мусор", new DateTime(2025, 1, 1)),
                new ToDoItem("Сходить в магазин", new DateTime(2024, 12, 1, 17, 0, 0)),
                new ToDoItem("Дочитать CLR via C#")
            };

            while (true)
            {
                Console.Clear();
                ShowMenu();
                var pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.A)
                {
                    AddToDo();
                }
                else if (pressedKey.Key == ConsoleKey.S)
                {
                    ShowToDoItems();
                }
                else if (pressedKey.Key == ConsoleKey.D)
                {
                    RemoveToDo();
                }
                else if (pressedKey.Key == ConsoleKey.Q)
                {
                    return;
                }
            }
        }

        private static void RemoveToDo()
        {
            //var index = 0;
            //var cursorPosition = new Point(0, 0);

            //Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
            for (int i = 0; i < _toDoList.Count; i++)
            {
                if (i == 0)
                {
                    var tuple = Console.GetCursorPosition();
                    _currentCursorPosition = new Point(tuple.Left, tuple.Top);
                }
                Console.WriteLine(_toDoList[i]);
            }
            Console.ReadKey();
        }

        private static void ShowToDoItems()
        {
            if (_toDoList.Count == 0)
            {
                Console.WriteLine("У вас нет дел!");
                return;
            }

            foreach (var item in _toDoList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        private static void AddToDo()
        {
            var toDoItem = new ToDoItem();
            Console.WriteLine("Введите описание задачи:\r\n");
            var content = Console.ReadLine();
            toDoItem.Content = content;
            toDoItem = AddDeadline(toDoItem);
            _toDoList.Add(toDoItem);
        }

        private static ToDoItem AddDeadline(ToDoItem item)
        {
            var deadlineRequier = AskUser("Хотите поставить крайний срок? (Y/N)", s => new[] { "Y", "N" }.Contains(s, StringComparer.OrdinalIgnoreCase));

            if (deadlineRequier.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                var dateString = AskUser("Введите дату крайнего срока (день/месяц/год часы:минуты)", s => DateTime.TryParse(s, out var r));
                item.Deadline = DateTime.Parse(dateString);
            }

            return item;
        }

        private static string AskUser(string message, Func<string, bool> validator)
        {
            Console.WriteLine(message);
            while (true)
            {
                var userInput = Console.ReadLine();
                if (validator(userInput))
                    return userInput;
                else
                    Console.WriteLine("Неверный формат ввода");
            }
        }


        private static void ShowMenu()
        {
            Console.WriteLine("Выберите действие: \r\nA - добавить запись\r\nS - показать все записи\r\nD - удалить запись\r\nQ - выход\r\n");
        }
    }

    /* Функционал списка дел:
     * 1. Добавить запись
     * 2. Показать все записи
     * 3. Удалить запись
     * 4. Редактировать запись
     * 
     * Добавление записи : 
     * 1. Записать содержимое
     * 2. Указать дату создания (автоматически)
     * 3. Указать крайний срок выполнения (опционально)
     * 
     * Показ записей:
     * 1. Взять записи из хранилища
     * 2. Показать (пока на консоли)
     * 
     * Удаление записи:
     * 1. Показать все записи
     * 2. Пользователь выбирает нужную запись
     * 3. Удаление записи из хранилища
     * 
     * Редактирование записи:
     * 1. Показать все записи
     * 2. Пользователь выбирает нужную запись
     * 3. Редактирование нужной записи
     * 
     * Выбор нужной записи:
     * 1. Выделение записи
     * 2. Получить информацию об выделенном тексте
     * 3. Сопоставить выделенный текст с задачей
     * 
     * Выделение текста в консоли и получение содержимоко выделения
     */

}
