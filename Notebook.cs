using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    /*
    * Очередное приключение в Рейд-режиме ждёт! Условия и задачи текущей стадии находятся в файле Conditions.txt.
    */

    public class Notebook
    {
        public Dictionary<int, Note> allNotes = new Dictionary<int, Note>();
        private int count = 0;
        public static void Main(string[] args)
        {
            Notebook n = new Notebook();
            n.Action();


        }

        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!");
            Console.WriteLine("\t- для создания новой записи введите команду: create.");
            Console.WriteLine("\t- для просмотра записи введите команду: show.");
            Console.WriteLine("\t- для редактирования записи введите команду: edit.");
            Console.WriteLine("\t- для удаления записи введите команду: del.");
            Console.WriteLine("\t- для просмотра списка всех записей введите команду: all.");
            Console.WriteLine("\t- для выхода из программы введите команду: exit.");
        }

        private void Action()
        {
            Greetings();

            while (true)
            {
                Console.Write("Введите команду: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "create":
                        CreateNote();
                        break;
                    case "show":
                        ReadNote();
                        break;
                    case "edit":
                        UpdateNote();
                        break;
                    case "del":
                        DeleteNote();
                        break;
                    case "all":
                        ShowAllNotes();
                        break;
                    case "exit":
                        Console.WriteLine("Пока-пока!");
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                        break;
                }
                if (option == "exit")
                {
                    break;
                }
            }
        }

        private void CreateNote()
        {
            Note note = new Note() { Id = count };
            note.Surname = ReadUntilValidationPass("Surname");
            note.Name = ReadUntilValidationPass("Name");
            note.SecondName = ReadUntilValidationPass("SecondName");
            note.Phone = ReadUntilValidationPass("Phone");
            note.Country = ReadUntilValidationPass("Country");
            note.DateOfBirth = ReadUntilValidationPass("DateOfBirth");
            note.Organization = ReadUntilValidationPass("Organization");
            note.Position = ReadUntilValidationPass("Position");
            note.Remark = ReadUntilValidationPass("Remark");
            allNotes.Add(count, note);
            count++;
        }

        private void ReadNote()
        {
            Console.Write("Введите Id записи: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                Console.WriteLine("Введен некорректный идентификатор!");
            else if (!allNotes.ContainsKey(id))
                Console.WriteLine("Данной записи не найдено!");
            else
                Console.WriteLine(allNotes[id].ToString());
        }

        private void UpdateNote()
        {
            Console.Write("Укажите ID записи для редактирования: ");
            int redactID;
            if (Int32.TryParse(Console.ReadLine(), out redactID))
            {
                if (!allNotes.ContainsKey(redactID))
                    Console.WriteLine("Данной записи не найдено!");
                else
                {
                    while (true)
                    {
                        Console.WriteLine(allNotes[redactID]);
                        Console.WriteLine("Какое поле необходимо отредактировать?");
                        Console.WriteLine("\t1 - Фамилия\n\t2 - Имя\n\t3 - Отчество\n\t4 - Телефон\n\t5 - Страна\n\t6 - Дата рождения\n\t7 - Организация\n\t8 - Должность\n\t9 - Примечание");
                        Console.Write("Введите цифру для выбора или cancel для завершения редактирования: ");
                        string comm = "";
                        while (comm == "")
                        {
                            comm = Console.ReadLine();
                            if (comm == "cancel")
                                return;
                            switch (comm)
                            {
                                case "1":
                                    allNotes[redactID].Surname = ReadUntilValidationPass("Surname");
                                    break;
                                case "2":
                                    allNotes[redactID].Name = ReadUntilValidationPass("Name");
                                    break;
                                case "3":
                                    allNotes[redactID].SecondName = ReadUntilValidationPass("SecondName");
                                    if (String.IsNullOrWhiteSpace(allNotes[redactID].SecondName)) allNotes[redactID].SecondName = null;
                                    break;
                                case "4":
                                    allNotes[redactID].Phone = ReadUntilValidationPass("Phone");
                                    break;
                                case "5":
                                    allNotes[redactID].Country = ReadUntilValidationPass("Country");
                                    if (String.IsNullOrWhiteSpace(allNotes[redactID].Country)) allNotes[redactID].Country = null;
                                    break;
                                case "6":
                                    allNotes[redactID].DateOfBirth = ReadUntilValidationPass("DateOfBirth");
                                    if (String.IsNullOrWhiteSpace(allNotes[redactID].DateOfBirth)) allNotes[redactID].DateOfBirth = null;
                                    break;
                                case "7":
                                    allNotes[redactID].Organization = ReadUntilValidationPass("Organization");
                                    if (String.IsNullOrWhiteSpace(allNotes[redactID].Organization)) allNotes[redactID].Organization = null;
                                    break;
                                case "8":
                                    if (String.IsNullOrWhiteSpace(allNotes[redactID].Position)) allNotes[redactID].Position = null;
                                    allNotes[redactID].Remark = ReadUntilValidationPass("Remark");
                                    break;
                                case "9":
                                    allNotes[redactID].Remark = ReadUntilValidationPass("Remark");
                                    if (String.IsNullOrWhiteSpace(allNotes[redactID].Remark)) allNotes[redactID].Remark = null;
                                    break;
                                default:
                                    Console.Write("Команда не найдена! Введите ещё раз: ");
                                    comm = "";
                                    break;
                            }
                        }
                        Console.Write("Поле изменено! Продолжить редактирование записи? (yes/no): ");
                        comm = Console.ReadLine();
                        while (comm != "yes" && comm != "no")
                        {
                            Console.Write("Пожалуйста введите yes или no: ");
                            comm = Console.ReadLine();
                        }

                        if (comm == "yes")
                            Console.Clear();
                        else
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }
        }

        private void DeleteNote()
        {
            Console.Write("Введите Id записи для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                Console.WriteLine("Введен некорректный идентификатор!");
            else if (!allNotes.ContainsKey(id))
                Console.WriteLine("Данной записи не найдено!");
            else
            {
                allNotes.Remove(id);
                Console.WriteLine($"Запись {id} удалена!");
            }

        }

        private void ShowAllNotes()
        {
            foreach (var item in allNotes)
            {
                Console.WriteLine(item.Value.ToShortString());
            }
        }

        private string ReadUntilValidationPass(string field)
        {
            Console.Write($"Введите {field}: ");
            do
            {
                string input = Console.ReadLine();
                if (Note.fieldsValidation[field].TryValidate(input, out string error))
                {
                    if (string.IsNullOrEmpty(input))
                        return null;
                    else
                        return input;
                }
                else
                    Console.WriteLine(error); ;
            }
            while (true);
        }
    }
}