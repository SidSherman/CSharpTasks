using System;
using System.Runtime.CompilerServices;

namespace skillbox_homework
{
    class SkillboxTask1
    {
        static void Main()
        {
            // 1.Объявление переменных

            string fullName;
            string email;
            int age;
            float codeScore;
            float mathScore;
            float physScore;

            // 2. Присваивание значений переменным

            fullName = "Laskus Aleksandr Sergeevich";
            email = "myemail@konoha.com";
            age = 23;
            codeScore = 100f;
            mathScore = 50f;
            physScore = 100f;

            // 3. Вывод значений переменных на экран

            Console.WriteLine(
                $"Ф.И.О:                     {fullName} \n" +
                $"Возраст:                   {age} \n" +
                $"Баллы по программированию: {codeScore} \n" +
                $"Баллы по математике:       {mathScore} \n" +
                $"Баллы по физике:           {physScore} \n" +
                $"E-mail:                    {email}"
                );

            Console.ReadKey();

            // 4. Подсчет суммы баллов с помощью функции Sum и вывод на экран

            Console.WriteLine(
                $"\bСумма всех баллов:             {Sum(new float[3] { codeScore, mathScore, physScore })}");

            // 5. Подсчет среднего арифметического баллов с помощью функции AverangeValue и вывод на экран

            Console.WriteLine(
                $"Среднее арифметическое баллов: {AverangeValue(new float[3] { codeScore, mathScore, physScore })}");

        }

        // Функция для подсчета суммы значений
        static float Sum(float[] values)
        {
            if (values.Length == 0)
                return 0;

            float sum = 0;

            foreach (float value in values)
            {
                sum += value;
            }

            return sum;

        }

        // Функция для подсчета среднего арифметического
        static float AverangeValue(float[] values)
        {
            if (values.Length == 0)
                return 0;

            float averangeValue = 0;

            averangeValue = Sum(values) / values.Length;

            return averangeValue;
        }

    }

}
