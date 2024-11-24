

namespace ToDoList
{
    public class ToDoItem
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? Deadline { get; set; }

        public ToDoItem(string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
        }

        public ToDoItem(string content, DateTime? deadline)
            : this(content)
        {
            Deadline = deadline;
        }

        public ToDoItem()
            : this(null)
        {

        }

        public override string ToString()
        {
            var deadlineString = Deadline.HasValue ? ("Сделать до " + Deadline.Value.ToShortDateString() + " " + Deadline.Value.ToShortTimeString()) : "";
            return Content + " Дата создания: " + CreationDate.ToShortDateString() + " " + CreationDate.ToShortTimeString() + " " + deadlineString;
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
