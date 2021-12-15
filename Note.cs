using System.Collections.Generic;
using System.Linq;

namespace Notebook
{
    public class Note 
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }

        public static Dictionary<string, Validation> fieldsValidation = new Dictionary<string, Validation>();


        static Note()
        {
            string letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя-";
            string numbers = "0123456789";
            string symbols = ",.?!()\\+-=№@'\"&$;:^ ";
            fieldsValidation.Add("Name", new Validation(true, 1, 20, (letters + " ").ToArray()));
            fieldsValidation.Add("Surname", new Validation(true, 1, 20, (letters + " ").ToArray()));
            fieldsValidation.Add("SecondName", new Validation(false, 0, 20, (letters + " ").ToArray()));
            fieldsValidation.Add("Phone", new Validation(true, 5, 11, numbers.ToArray()));
            fieldsValidation.Add("Country", new Validation(false, 0, 20, (letters + " .").ToArray()));
            fieldsValidation.Add("DateOfBirth", new Validation(false, 10, 10, (numbers + ".").ToArray()));
            fieldsValidation.Add("Organization", new Validation(false, 0, 20, (letters + " .").ToArray()));
            fieldsValidation.Add("Position", new Validation(false, 0, 20, (letters + " .").ToArray()));
            fieldsValidation.Add("Remark", new Validation(false, 0, 200, (letters + numbers + symbols).ToArray()));
            fieldsValidation.Add("Id", new Validation(true, 1, 10, numbers.ToArray()));
        }

        public override string ToString()
        {
             return $"\n\tID: {Id}\n\tФамилия: {Surname}\n\tИмя: {Name}\n\tОтчество: {SecondName}\n\tНомер телефона: {Phone}\n\tСтрана: {Country}\n\tДата рождения: {DateOfBirth}\n\tОрганизация: {Organization}\n\tДолжность: {Position}\n\tПримечание: {Remark}";
        }
        public string ToShortString()
        {
            return $"{Id} {Surname} {Name} {Phone}";
        }
    }
}