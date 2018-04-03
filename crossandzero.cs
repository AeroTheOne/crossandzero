using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossAndZero
{
    class botAlgorithmX
    {
        private int[,] weights = new int[20, 20];
        private int[,] field = new int[20, 20];
        private int botp, playerp, side, mainFieldSize;
        public botAlgorithmX(int side1, int fieldSize)
        {
            mainFieldSize = fieldSize;
            side = side1;
            if (side1 == 0)
            {
                for (int i = 0; i < mainFieldSize; i++)
                    for (int j = 0; j < mainFieldSize; j++)
                        field[i, j] = -mainFieldSize;
                Random r = new Random();
                int x = r.Next(0, mainFieldSize);
                int y = r.Next(0, mainFieldSize);
                field[x, y] = 1;
                botp = 1;
                playerp = 0;
            }
            else
            {
                for (int i = 0; i < mainFieldSize; i++)
                    for (int j = 0; j < mainFieldSize; j++)
                        field[i, j] = -mainFieldSize;
                botp = 0;
                playerp = 1;
            }
        }


        public int[,] setWeights1(int[,] field)
        {
            //инициализируем матрицу весов для каждого хода бота 
            bool bool1 = true;
            int weight = 0;
            for (int i = 0; i < mainFieldSize; i++)
            {
                for (int j = 0; j < mainFieldSize; j++)
                    weights[i, j] = 0;
            }
            //обходим все горизонтальные линии и расставляем веса 
            for (int i = 0; i < mainFieldSize; i++)
            {
                bool1 = true;
                weight = 0;
                for (int j = 0; j < mainFieldSize; j++)
                {
                    if (field[i, j] == playerp) bool1 = false;
                    else if (field[i, j] == botp) weight++;
                }
                if (bool1)
                {
                    int kol = 0;
                    for (int k = 0; k < mainFieldSize; k++)
                    {
                        if (field[i, k] == botp) kol++;
                        if (field[i, k] != botp) weights[i, k] += weight;
                    }
                    if (kol == mainFieldSize - 1)
                    {
                        for (int k = 0; k < mainFieldSize; k++)
                        {
                            if (field[i, k] == -mainFieldSize) weights[i, k] += 10;
                        }
                    }
                }
            }
            //обходим все вертикальные линии и расставляем веса 
            for (int j = 0; j < mainFieldSize; j++)
            {
                bool1 = true;
                weight = 0;
                for (int i = 0; i < mainFieldSize; i++)
                {
                    if (field[i, j] == playerp) bool1 = false;
                    else if (field[i, j] == botp) weight++;
                }
                if (bool1)
                {
                    int kol = 0;
                    for (int k = 0; k < mainFieldSize; k++)
                    {
                        if (field[k, j] == botp) kol++;
                        if (field[k, j] != botp) weights[k, j] += weight;
                    }
                    if (kol == mainFieldSize - 1)
                    {
                        for (int k = 0; k < mainFieldSize; k++)
                        {
                            if (field[k, j] == -mainFieldSize) weights[k, j] += 2;
                        }
                    }
                }
            }
            //обходим главную диагональ и расставляем веса 
            bool1 = true;
            weight = 0;
            for (int i = 0; i < mainFieldSize; i++)
            {
                if (field[i, i] == playerp) bool1 = false;
                else if (field[i, i] == botp) weight++;
            }
            if (bool1)
            {
                int kol = 0;
                for (int i = 0; i < mainFieldSize; i++)
                {
                    if (field[i, i] == botp) kol++;
                    if (field[i, i] != botp) weights[i, i] += weight;
                }
                if (kol == mainFieldSize - 1)
                {
                    for (int i = 0; i < mainFieldSize; i++)
                    {
                        if (field[i, i] == -mainFieldSize) weights[i, i] += 2;
                    }
                }
            }
            //обходим побочную диагональ и расставляем веса 
            bool1 = true;
            weight = 0;
            for (int i = 0; i < mainFieldSize; i++)
            {
                if (field[i, mainFieldSize - 1 - i] == playerp) bool1 = false;
                else if (field[i, mainFieldSize - 1 - i] == botp) weight++;
            }
            if (bool1)
            {
                int kol = 0;
                for (int i = 0; i < mainFieldSize; i++)
                {
                    if (field[i, mainFieldSize - 1 - i] == botp) kol++;
                    if (field[i, mainFieldSize - 1 - i] != botp) weights[i, mainFieldSize - 1 - i] += weight;
                }
                if (kol == mainFieldSize - 1)
                {
                    for (int i = 0; i < mainFieldSize; i++)
                    {
                        if (field[i, mainFieldSize - 1 - i] == -mainFieldSize) weights[i, mainFieldSize - 1 - i] += 2;
                    }
                }
            }
            //учитываем положение ноликов соперника 
            //делаем еще одну матрицу и также заполняем ее весами 
            //инициализация второй матрицы 
            bool1 = true;
            weight = 0;
            int[,] weightsZero = new int[20, 20];
            for (int i = 0; i < mainFieldSize; i++)
            {
                for (int j = 0; j < mainFieldSize; j++)
                    weightsZero[i, j] = 0;
            }
            //обходим все горизонтальные линии и расставляем веса 
            for (int i = 0; i < mainFieldSize; i++)
            {
                bool1 = true;
                weight = 0;
                for (int j = 0; j < mainFieldSize; j++)
                {
                    if (field[i, j] == botp) bool1 = false;
                    else if (field[i, j] == playerp) weight++;
                }
                if (bool1)
                {
                    int kol = 0;
                    for (int k = 0; k < mainFieldSize; k++)
                    {
                        if (field[i, k] == playerp) kol++;
                        if (field[i, k] != playerp) weightsZero[i, k] += weight;
                    }
                    if (kol == mainFieldSize - 1)
                    {
                        for (int k = 0; k < mainFieldSize; k++)
                        {

                            if (field[i, k] == -mainFieldSize) weightsZero[i, k] += 2;
                        }
                    }

                }
            }
            //обходим все вертикальные линии и расставляем веса 
            for (int j = 0; j < mainFieldSize; j++)
            {
                bool1 = true;
                weight = 0;
                for (int i = 0; i < mainFieldSize; i++)
                {
                    if (field[i, j] == botp) bool1 = false;
                    else if (field[i, j] == playerp) weight++;
                }
                if (bool1)
                {
                    int kol = 0;
                    for (int k = 0; k < mainFieldSize; k++)
                    {
                        if (field[k, j] == playerp) kol++;
                        if (field[k, j] != playerp) weightsZero[k, j] += weight;
                    }
                    if (kol == mainFieldSize - 1)
                    {
                        for (int k = 0; k < mainFieldSize; k++)
                        {
                            if (field[k, j] == -mainFieldSize) weightsZero[k, j] += 2;
                        }
                    }
                }
            }
            //обходим главную диагональ и расставляем веса 
            bool1 = true;
            weight = 0;
            for (int i = 0; i < mainFieldSize; i++)
            {
                if (field[i, i] == botp) bool1 = false;
                else if (field[i, i] == playerp) weight++;
            }
            if (bool1)
            {
                int kol = 0;
                for (int i = 0; i < mainFieldSize; i++)
                {
                    if (field[i, i] == playerp) kol++;
                    if (field[i, i] != playerp) weightsZero[i, i] += weight;
                }
                if (kol == mainFieldSize - 1)
                {
                    for (int i = 0; i < mainFieldSize; i++)
                    {
                        if (field[i, i] == -mainFieldSize) weightsZero[i, i] += 2;
                    }
                }
            }
            //обходим побочную диагональ и расставляем веса 
            bool1 = true;
            weight = 0;
            for (int i = 0; i < mainFieldSize; i++)
            {
                if (field[i, mainFieldSize - 1 - i] == botp) bool1 = false;
                else if (field[i, mainFieldSize - 1 - i] == playerp) weight++;
            }
            if (bool1)
            {
                int kol = 0;
                for (int i = 0; i < mainFieldSize; i++)
                {
                    if (field[i, mainFieldSize - 1 - i] == playerp) kol++;
                    if (field[i, mainFieldSize - 1 - i] != playerp) weightsZero[i, mainFieldSize - 1 - i] += weight;
                }
                if (kol == mainFieldSize - 1)
                {
                    for (int i = 0; i < mainFieldSize; i++)
                    {
                        if (field[i, mainFieldSize - 1 - i] == -mainFieldSize) weightsZero[i, mainFieldSize - 1 - i] += 2;
                    }
                }
            }
            for (int a = 0; a < mainFieldSize; a++)
            {
                for (int b = 0; b < mainFieldSize; b++)
                {
                    int finalKol = 0;
                    if (field[a, b] == -mainFieldSize)
                    {

                        int kol = 0;
                        int tmp = field[a, b];
                        //проверяем на вилки игрока 
                        field[a, b] = playerp;

                        for (int i = 0; i < mainFieldSize; i++)
                        {
                            for (int k = 0; k < mainFieldSize; k++)
                            {
                                if (field[i, k] == playerp) kol++;
                            }
                            if (kol == mainFieldSize - 1) finalKol++;
                            kol = 0;
                        }

                        for (int j = 0; j < mainFieldSize; j++)
                        {
                            for (int k = 0; k < mainFieldSize; k++)
                            {
                                if (field[k, j] == playerp) kol++;
                            }
                            if (kol == mainFieldSize - 1) finalKol++;
                            kol = 0;
                        }

                        for (int i = 0; i < mainFieldSize; i++)
                        {
                            if (field[i, i] == playerp) kol++;
                        }
                        if (kol == mainFieldSize - 1) finalKol++;
                        kol = 0;
                        for (int i = 0; i < mainFieldSize; i++)
                        {
                            if (field[i, mainFieldSize - 1 - i] == playerp) kol++;
                        }
                        if (kol == mainFieldSize - 1) finalKol++;
                        kol = 0;
                        //теперь прибавляем к этому вилки бота 
                        field[a, b] = botp;

                        for (int i = 0; i < mainFieldSize; i++)
                        {
                            for (int k = 0; k < mainFieldSize; k++)
                            {
                                if (field[i, k] == botp) kol++;
                            }
                            if (kol == mainFieldSize - 1) finalKol++;
                            kol = 0;
                        }

                        for (int j = 0; j < mainFieldSize; j++)
                        {
                            for (int k = 0; k < mainFieldSize; k++)
                            {
                                if (field[k, j] == botp) kol++;
                            }
                            if (kol == mainFieldSize - 1) finalKol++;
                            kol = 0;
                        }

                        for (int i = 0; i < mainFieldSize; i++)
                        {
                            if (field[i, i] == botp) kol++;
                        }
                        if (kol == mainFieldSize - 1) finalKol++;
                        kol = 0;
                        for (int i = 0; i < mainFieldSize; i++)
                        {
                            if (field[i, mainFieldSize - 1 - i] == botp) kol++;
                        }
                        if (kol == mainFieldSize - 1) finalKol++;
                        kol = 0;
                        field[a, b] = tmp;
                    }
                    weights[a, b] += finalKol;
                }
            }
            //суммируем обе матрицы и ищем все координаты максимувов 
            for (int i = 0; i < mainFieldSize; i++)
                for (int j = 0; j < mainFieldSize; j++)
                    weights[i, j] +=
                    weightsZero[i, j];
            return weights;
        }

        public int findKolMax(int[,] mas)
        {
            int kol = 0, max = mas[0, 0];
            for (int i = 0; i < mainFieldSize; i++)
            {
                for (int j = 0; j < mainFieldSize; j++)
                {
                    kol += mas[i, j];
                }
            }
            return kol;
        }
        public void showWeightsMatr()
        {
            for (int i = 0; i < mainFieldSize; i++)
            {
                for (int j = 0; j < mainFieldSize; j++)
                    Console.Write("{0,5} ", weights[i, j] + " ");
                Console.WriteLine();
            }
        }
        public void showFieldMatr()
        {
            for (int i = 0; i < mainFieldSize; i++)
            {
                for (int j = 0; j < mainFieldSize; j++)
                    Console.Write("{0,5} ", field[i, j] + " ");
                Console.WriteLine();
            }
        }
        public bool botMove(int x, int y)
        {
            if (field[x, y] == -mainFieldSize)
            {
                field[x, y] = playerp;
                setWeights1(field);
                //если несколько одинаковых весов в разных клетках, то надо выбрать самый оптимальный ход 
                //поэтому бот ставит в каждую из этих точек крестик, и смотрит где сумма весов, рассчитанных по тому же алгоритму больше 
                int[,] dopMas = new int[mainFieldSize, mainFieldSize];
                for (int i = 0; i < mainFieldSize; i++)
                {
                    for (int j = 0; j < mainFieldSize; j++)
                    {
                        if (field[i, j] == -mainFieldSize)
                        {
                            int tmp = field[i, j];
                            field[i, j] = botp;
                            int preMax = findKolMax(setWeights1(field));
                            field[i, j] = playerp;
                            preMax += findKolMax(setWeights1(field));
                            dopMas[i, j] = preMax;
                            field[i, j] = tmp;
                        }
                    }
                }

                int maxi = 0, maxj = 0;
                bool bool1 = false;
                setWeights1(field);
                for (int i = 0; i < mainFieldSize; i++)
                {
                    for (int j = 0; j < mainFieldSize; j++)
                    {
                        if (field[i, j] == -mainFieldSize)
                        {
                            int tmp = field[i, j];
                            field[i, j] = botp;
                            if (check2Win())
                            {
                                bool1 = true;
                                maxi = i;
                                maxj = j;
                            }
                            field[i, j] = playerp;
                            if (check2Win() && !bool1)
                            {
                                bool1 = true;
                                maxi = i;
                                maxj = j;
                            }
                            field[i, j] = tmp;
                        }
                        weights[i, j] += dopMas[i, j];
                        if (weights[i, j] > weights[maxi, maxj] && !bool1)
                        {
                            maxi = i;
                            maxj = j;
                        }
                    }
                }

                if (field[maxi, maxj] == -mainFieldSize)
                    field[maxi, maxj] = botp;
                return true;
            }
            else return false;
        }
        public bool check2Win()
        {
            bool bool1 = false;
            int sum;
            for (int i = 0; i < mainFieldSize; i++)
            {
                sum = 0;
                for (int j = 0; j < mainFieldSize; j++)
                    sum += field[i, j];
                if (sum == 0 | sum == mainFieldSize) bool1 = true;
            }
            for (int j = 0; j < mainFieldSize; j++)
            {
                sum = 0;
                for (int i = 0; i
                < mainFieldSize; i++)
                    sum += field[i, j];
                if (sum == 0 | sum == mainFieldSize) bool1 = true;
            }
            sum = 0;
            for (int i = 0; i < mainFieldSize; i++)
                sum += field[i, i];
            if (sum == 0 | sum == mainFieldSize) bool1 = true;
            sum = 0;
            for (int i = 0; i < mainFieldSize; i++)
                sum += field[i, mainFieldSize - i - 1];
            if (sum == 0 | sum == mainFieldSize) bool1 = true;
            int cnt = 0;
            for (int i = 0; i < mainFieldSize; i++)
                for (int j = 0; j < mainFieldSize; j++)
                    if (field[i, j] == -mainFieldSize) cnt++;
            if (cnt == 0) bool1 = true;
            return bool1;
        }
    }
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер поля [1..20]: ");
            int fieldSize = Int32.Parse(Console.ReadLine());
            bool gameOn = true;
            Console.WriteLine("Выбирете сторону (крестики ходят первыми), напишите 1 если крестики и 0 если нолики");
            int side = Int32.Parse(Console.ReadLine());
            if (side == 0)
            {
                botAlgorithmX bot1 = new botAlgorithmX(side, fieldSize);
                bot1.showFieldMatr();
                while (gameOn)
                {
                    Console.WriteLine("Введите координаты нолика:");
                    int x, y;
                    Console.Write("Введите X (от 1 до " + (fieldSize) + "): ");
                    y = Int32.Parse(Console.ReadLine());
                    Console.Write("Введите Y (от 1 до " + (fieldSize) + "): ");
                    x = Int32.Parse(Console.ReadLine());
                    if (bot1.botMove(x - 1, y - 1) == false)
                    {
                        Console.WriteLine("Вы ввели недопустимые координаты. Попробуйте еще раз");
                    }

                    Console.WriteLine("Игровое поле:");
                    bot1.showFieldMatr();
                    Console.WriteLine();
                    if (bot1.check2Win())
                    {
                        gameOn = false;
                        Console.WriteLine("Игра законченна");
                    }
                }
                Console.ReadKey();
            }
            else if (side == 1)
            {


                botAlgorithmX bot1 = new botAlgorithmX(side, fieldSize);
                bot1.showFieldMatr();
                while (gameOn)
                {
                    Console.WriteLine("Введите координаты крестика:");
                    int x, y;
                    Console.Write("Введите X (от 1 до " + (fieldSize) + "): ");
                    y = Int32.Parse(Console.ReadLine());
                    Console.Write("Введите Y (от 1 до " + fieldSize + "): ");
                    x = Int32.Parse(Console.ReadLine());
                    if (bot1.botMove(x - 1, y - 1) == false)
                    {
                        Console.WriteLine("Вы ввели недопустимые координаты. Попробуйте еще раз");
                    }
                    Console.WriteLine("Игровое поле:");
                    bot1.showFieldMatr();
                    Console.WriteLine();
                    if (bot1.check2Win())
                    {
                        gameOn = false;
                        Console.WriteLine("Игра законченна");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}