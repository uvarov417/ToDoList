

namespace ToDoList
{
    internal class Program
    {
        private static List<ToDoItem> _toDoList = new List<ToDoItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                var pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.A)
                {
                    AddToDo();
                }
            }
        }

        private static void AddToDo()
        {
            Console.WriteLine("Введите описание задачи:\r\n");
            var content = Console.ReadLine();
            _toDoList.Add(new ToDoItem(content));
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Выберите действие: \r\nA - добавить запись\r\n");
        }
    }

    public class ToDoItem
    {
        public string Content { get; set; }

        public ToDoItem(string content)
        {
            Content = content;
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
