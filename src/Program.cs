using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Subjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива предметов:");
            int sizeAr = 0;
            bool validSize = false;
            while (!validSize)
            {
                if (int.TryParse(Console.ReadLine(), out sizeAr) && sizeAr > 0)
                {
                    Console.WriteLine("Размер массива введён!");
                    validSize = true;
                }
                else
                {
                    Console.WriteLine("Введите целое число в качестве размера массива предметов!");
                }
            }

            SubjectControl subjects = new SubjectControl(sizeAr);

            for (int i = 0; i < sizeAr; i++)
            {
                Console.WriteLine($"Введите название предмета {i}:");
                string subjName = "";
                string tempSubjName = Console.ReadLine();
                bool validSubjName = false;
                while (!validSubjName)
                {
                    if (string.IsNullOrEmpty(tempSubjName))
                    {
                        Console.WriteLine($"Название предмета {i} не может быть пустым!");
                        tempSubjName = Console.ReadLine();
                    }
                    else if (!tempSubjName.All(char.IsLetter))
                    {
                        Console.WriteLine($"Название предмета {i} должно содержать только буквы!");
                        tempSubjName = Console.ReadLine();
                    }
                    else
                    {
                        validSubjName = true;
                        subjName = tempSubjName;
                    }
                }

                Console.WriteLine($"Введите семестр для предмета {i}, максимальный семестр - 10: ");
                int subjHalfyear = 0;
                bool validSubjHalfyear = false;
                while (!validSubjHalfyear)
                {
                    if (int.TryParse(Console.ReadLine(), out subjHalfyear))
                    {
                        if (subjHalfyear <= 10)
                        {
                            Console.WriteLine($"Семестр для предмета {i} введён успешно!");
                            validSubjHalfyear = true;
                        }
                        else
                        {
                            Console.WriteLine($"Введите семестр для предмета {i} снова!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Введите семестр для предмета {i} снова!");
                    }
                }

                Console.WriteLine($"Введите форму аттестации для предмета {i}, введите минимум 5 символов ло 25 символов на русском языке: ");
                string subjFormExam = "";
                string tempSubjFormExam = Console.ReadLine();
                bool validSubjFormExam = false;
                while (!validSubjFormExam)
                {
                    if (string.IsNullOrEmpty(tempSubjFormExam))
                    {
                        Console.WriteLine($"Форма аттестации для предмета {i} не может быть пустой! Введите знеачение снова!");
                        tempSubjFormExam = Console.ReadLine();
                    }
                    else if (!tempSubjFormExam.All(char.IsLetter))
                    {
                        Console.WriteLine($"Название предмета {i} должно содержать только буквы! Введите значение снова!");
                        tempSubjFormExam = Console.ReadLine();
                    }
                    else
                    {
                        validSubjFormExam = true;
                        subjFormExam = tempSubjFormExam;
                    }
                }

                Subject subject = new Subject { SubjectName = subjName, Halfyear = subjHalfyear, FormExam = subjFormExam };
                subjects.AddSubjectInArr(subject);


            }

            subjects.SortingToNameAndForm();

            for (int i = 0; i < sizeAr; i++)
            {
                Subject subject = subjects.GetSubject(i);
                Console.WriteLine($"Название предмета: {subject.SubjectName}, Семестр предмета: {subject.Halfyear}, Форма аттестации предмета: {subject.FormExam}");
            }

            Console.WriteLine("Введите название документа для сохранения \n отсортированного массива предметов в виде .txt - файла \n" +
                " Ввод название без '.txt'!");
            string filename = Console.ReadLine() + ".txt";
            try
            {
                subjects.SaveToTxt(filename);
                Console.WriteLine($"Данные успешно сохранены в файл {filename} !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при сохранении данных в файле.\n" +
                    $"Подробности: " + ex.Message);
            }
        }
    }
}
