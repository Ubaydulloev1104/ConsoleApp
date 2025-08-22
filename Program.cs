using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Базовая папка
        string baseDir = @"C:\Users\azamjon\source\repos\ConsoleApp2";

        // Пути к файлам
        string path1 = Path.Combine(baseDir, "numbers1.txt");
        string path2 = Path.Combine(baseDir, "numbers2.txt");
        string outputPath = Path.Combine(baseDir, "difference.txt");

        try
        {
            // Проверяем существование файлов
            if (!File.Exists(path1))
            {
                Console.WriteLine($"Файл не найден: {path1}");
                return;
            }
            if (!File.Exists(path2))
            {
                Console.WriteLine($"Файл не найден: {path2}");
                return;
            }

            // Очищаем файл difference или создаём новый
            File.WriteAllText(outputPath, string.Empty);

            // Загружаем numbers2 в HashSet
            var numbers2 = new HashSet<int>();
            foreach (var line in File.ReadLines(path2))
            {
                string trimmed = line.Trim();
                if (int.TryParse(trimmed, out int num))
                    numbers2.Add(num);
            }

            // Список для разницы
            var difference = new List<string>();

            // Читаем numbers1 и проверяем наличие в numbers2
            foreach (var line in File.ReadLines(path1))
            {
                string trimmed = line.Trim();
                if (int.TryParse(trimmed, out int num))
                {
                    if (!numbers2.Contains(num))
                        difference.Add(num.ToString());
                }
            }

            // Записываем результат
            File.WriteAllLines(outputPath, difference);

            Console.WriteLine($"Разница найдена: {difference.Count} элементов");
            Console.WriteLine($"Результат записан в: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
