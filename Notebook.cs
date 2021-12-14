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
        public static void Main(string[] args)
        {

            //var a = new Notebook();
            //a.Action();


        }


        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!\n" +
                "\t- для создания новой записи введите команду: create.\n" +
                "\t- для просмотра записи введите команду: show.\n" +
                "\t- для редактирования записи введите команду: edit.\n" +
                "\t- для удаления записи введите команду: del.\n" +
                "\t- для просмотра списка всех записей введите команду: all.\n" +
                "\t- для выхода из программы введите команду: exit.\n");
        }


        private void Action()
        {
            Console.Write("Введите команду: ");
            string inCommand = Console.ReadLine(); ;
            while (inCommand != "create" && inCommand != "show" && inCommand != "edit" && inCommand != "del" && inCommand != "all" && inCommand != "exit")
            {
                Console.Clear();
                Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                inCommand = Console.ReadLine();
            }
            switch (inCommand)
            {
                case "create":
                    Console.WriteLine("Создание");
                    break;
                case "show":
                    Console.WriteLine("Показ");
                    break;
                case "edit":
                    Console.WriteLine("Редактирование");
                    break;
                case "del":
                    Console.WriteLine("Удаление");
                    break;
                case "all":
                    Console.WriteLine("Всё");
                    break;
                case "exit":
                    Console.WriteLine("Выход");
                    break;
                default:
                    break;
            }
        }


        private void createNote()
        {

        }



    }
}