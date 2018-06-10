using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossAndZeroReborn
{
    class Program
    {
        class Bot
        {
            private int fieldSize, side, botSide;
            private int[,] field = new int[20, 20];
            public Bot(int fieldSize1, int side1)
            {
                fieldSize = fieldSize1;
                side = side1;
                botSide = (side == 1) ? 0 : 1;
                for (int i = 0; i < fieldSize; i++)
                    for (int j = 0; j < fieldSize; j++)
                    {
                        field[i, j] = -fieldSize;
                    }
            }
            public void showField()
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                        Console.Write("{0,4}", field[i, j]);
                    Console.WriteLine();
                }
            }
            public void showMas(int[,] mas, int size)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        Console.Write(mas[i, j] + " ");
                    Console.WriteLine();
                }
            }
            public int ifGameOn()
            {
                int sum;
                int kol = 0;
                for (int i = 0; i < fieldSize; i++)
                {
                    sum = 0;
                    for (int j = 0; j < fieldSize; j++)
                    {
                        sum += field[i, j];
                        if (field[i, j] == -fieldSize) kol++;
                    }
                    if (sum == 0) return 0; else if (sum == fieldSize) return 1;
                }
                if (kol == 0) return 2;
                for (int j = 0; j < fieldSize; j++)
                {
                    sum = 0;
                    for (int i = 0; i < fieldSize; i++)
                        sum += field[i, j];
                    if (sum == 0) return 0; else if (sum == fieldSize) return 1;
                }
                sum = 0;
                for (int i = 0; i < fieldSize; i++)
                    sum += field[i, i];
                if (sum == 0) return 0; else if (sum == fieldSize) return 1;
                sum = 0;
                for (int i = 0; i < fieldSize; i++)
                    sum += field[i, fieldSize - 1 - i];
                if (sum == 0) return 0; else if (sum == fieldSize) return 1;
                return -1;

            }
            public int[,] setWeights0(int[,] field)
            {
                int[,] weights = new int[fieldSize, fieldSize];
                for (int i = 0; i < fieldSize; i++)
                    for (int j = 0; j < fieldSize; j++)
                        weights[i, j] = 0;
                bool bool1;
                int kol = 0;
                for (int i = 0; i < fieldSize; i++)
                {
                    kol = 0;
                    bool1 = true;
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if (field[i, j] == side) kol++;
                        if (field[i, j] == botSide) bool1 = false;
                    }
                    if (bool1)
                        for (int j = 0; j < fieldSize; j++)
                            if (field[i, j] == -fieldSize) weights[i, j] += kol;
                }
                for (int j = 0; j < fieldSize; j++)
                {
                    kol = 0;
                    bool1 = true;
                    for (int i = 0; i < fieldSize; i++)
                    {
                        if (field[i, j] == side) kol++;
                        if (field[i, j] == botSide) bool1 = false;
                    }
                    if (bool1)
                        for (int i = 0; i < fieldSize; i++)
                            if (field[i, j] == -fieldSize) weights[i, j] += kol;
                }
                kol = 0;
                bool1 = true;
                for (int i = 0; i < fieldSize; i++)
                {
                    if (field[i, i] == side) kol++;
                    if (field[i, i] == botSide) bool1 = false;
                }
                if (bool1)
                {
                    for (int i = 0; i < fieldSize; i++)
                        if (field[i, i] == -fieldSize) weights[i, i] += kol;
                }
                kol = 0;
                bool1 = true;
                for (int i = 0; i < fieldSize; i++)
                {
                    if (field[i, fieldSize - i - 1] == side) kol++;
                    if (field[i, fieldSize - i - 1] == botSide) bool1 = false;
                }
                if (bool1)
                {
                    for (int i = 0; i < fieldSize; i++)
                        if (field[i, fieldSize - i - 1] == -fieldSize) weights[i, fieldSize - i - 1] += kol;
                }
                return weights;
            }
            public int[,] setWeights1(int[,] field)
            {
                int[,] weights = new int[fieldSize, fieldSize];
                for (int i = 0; i < fieldSize; i++)
                    for (int j = 0; j < fieldSize; j++)
                        weights[i, j] = 0;
                bool bool1;
                int kol = 0;
                for (int i = 0; i < fieldSize; i++)
                {
                    kol = 0;
                    bool1 = true;
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if (field[i, j] == botSide) kol++;
                        if (field[i, j] == side) bool1 = false;
                    }
                    if (bool1)
                        for (int j = 0; j < fieldSize; j++)
                            if (field[i, j] == -fieldSize) weights[i, j] += kol;
                }
                for (int j = 0; j < fieldSize; j++)
                {
                    kol = 0;
                    bool1 = true;
                    for (int i = 0; i < fieldSize; i++)
                    {
                        if (field[i, j] == botSide) kol++;
                        if (field[i, j] == side) bool1 = false;
                    }
                    if (bool1)
                        for (int i = 0; i < fieldSize; i++)
                            if (field[i, j] == -fieldSize) weights[i, j] += kol;
                }
                kol = 0;
                bool1 = true;
                for (int i = 0; i < fieldSize; i++)
                {
                    if (field[i, i] == botSide) kol++;
                    if (field[i, i] == side) bool1 = false;
                }
                if (bool1)
                {
                    for (int i = 0; i < fieldSize; i++)
                        if (field[i, i] == -fieldSize) weights[i, i] += kol;
                }
                kol = 0;
                bool1 = true;
                for (int i = 0; i < fieldSize; i++)
                {
                    if (field[i, fieldSize - i - 1] == botSide) kol++;
                    if (field[i, fieldSize - i - 1] == side) bool1 = false;
                }
                if (bool1)
                {
                    for (int i = 0; i < fieldSize; i++)
                        if (field[i, fieldSize - i - 1] == -fieldSize) weights[i, fieldSize - i - 1] += kol;
                }
                return weights;
            }
            public int countPossibleWins(int[,] field, int side)
            {
                int sum, kol = 0;
                for (int i = 0; i < fieldSize; i++)
                {
                    sum = 0;
                    for (int j = 0; j < fieldSize; j++)
                        if (field[i, j] == side) sum++;
                    if (sum == fieldSize - 1) kol++;
                }
                for (int j = 0; j < fieldSize; j++)
                {
                    sum = 0;
                    for (int i = 0; i < fieldSize; i++)
                        if (field[i, j] == side) sum++;
                    if (sum == fieldSize - 1) kol++;
                }
                sum = 0;
                for (int i = 0; i < fieldSize; i++)
                    if (field[i, i] == side) sum++;
                if (sum == fieldSize - 1) kol++;
                sum = 0;
                for (int i = 0; i < fieldSize; i++)
                    if (field[i, fieldSize - 1 - i] == side) sum++;
                if (sum == fieldSize - 1) kol++;
                return kol;
            }
            public int botMove(int x, int y, bool firstMove)
            {
                if (firstMove == false)
                {
                    if (field[x - 1, y - 1] != -fieldSize || x > fieldSize || y > fieldSize) return -1;
                    field[x - 1, y - 1] = side;
                }
                if (botSide == 0)
                {
                    for (int i = 0; i < fieldSize; i++)
                        for (int j = 0; j < fieldSize; j++)
                            if (field[i, j] == -fieldSize)
                            {
                                field[i, j] = botSide;
                                if (ifGameOn() == 0) return 0;
                                field[i, j] = -fieldSize;
                            }
                    for (int i = 0; i < fieldSize; i++)
                        for (int j = 0; j < fieldSize; j++)
                            if (field[i, j] == -fieldSize)
                            {
                                field[i, j] = side;
                                if (ifGameOn() == 1)
                                {
                                    field[i, j] = botSide;
                                    return 0;
                                }
                                field[i, j] = -fieldSize;
                            }
                    int max = -21, kolMax = 0;
                    int[,] resWeights = new int[fieldSize, fieldSize];
                    int[,] resWeights1 = new int[fieldSize, fieldSize];
                    resWeights1 = setWeights0(field);
                    for (int i = 0; i < fieldSize; i++)
                        for (int j = 0; j < fieldSize; j++)
                            if (resWeights1[i, j] == max) kolMax++;
                            else if (resWeights1[i, j] > max)
                            {
                                max = resWeights1[i, j];
                                kolMax = 1;
                            }
                    if (kolMax == 1)
                    {
                        for (int i = 0; i < fieldSize; i++)
                            for (int j = 0; j < fieldSize; j++)
                                if (resWeights1[i, j] == max) field[i, j] = botSide;
                        return 0;
                    }
                    else
                    {
                        kolMax = 0; max = -21;
                        for (int i = 0; i < fieldSize; i++)
                        {
                            for (int j = 0; j < fieldSize; j++)
                            {
                                if (field[i, j] == -fieldSize)
                                {
                                    field[i, j] = side;
                                    int[,] dopMas = new int[fieldSize, fieldSize];
                                    int res = 0;
                                    dopMas = setWeights0(field);
                                    for (int ii = 0; ii < fieldSize; ii++)
                                        for (int jj = 0; jj < fieldSize; jj++)
                                            res += dopMas[ii, jj];
                                    res += countPossibleWins(field, side);
                                    if (res == max) kolMax++;
                                    else if (res > max)
                                    {
                                        kolMax = 1;
                                        max = res;
                                    }
                                    resWeights[i, j] = res;
                                    field[i, j] = -fieldSize;
                                }
                            }
                        }
                        if (kolMax == 1)
                        {
                            for (int i = 0; i < fieldSize; i++)
                                for (int j = 0; j < fieldSize; j++)
                                    if (resWeights[i, j] == max && field[i, j] == -fieldSize) field[i, j] = botSide;
                            return 0;
                        }
                        else
                        {

                            int kol = 0;
                            for (int i = 0; i < fieldSize; i++)
                                for (int j = 0; j < fieldSize; j++)
                                {
                                    if (field[i, j] == -fieldSize)
                                    {
                                        field[i, j] = botSide;
                                        kol = 0;
                                        for (int xx = 0; xx < fieldSize; xx++)
                                            if (field[i, xx] == botSide) kol++;
                                        if (kol == fieldSize - 1)
                                        {
                                            bool bool1 = false;
                                            for (int xx = 0; xx < fieldSize; xx++)
                                                if (field[i, xx] == -fieldSize && resWeights[i, xx] != max) bool1 = true;
                                            if (bool1)
                                                return 0;
                                        }
                                        kol = 0;
                                        for (int xx = 0; xx < fieldSize; xx++)
                                            if (field[xx, j] == botSide) kol++;
                                        if (kol == fieldSize - 1)
                                        {
                                            bool bool1 = false;
                                            for (int xx = 0; xx < fieldSize; xx++)
                                                if (field[xx, j] == -fieldSize && resWeights[xx, j] != max) bool1 = true;
                                            if (bool1)
                                                return 0;
                                        }
                                        field[i, j] = -fieldSize;
                                    }
                                }
                            for (int i = 0; i < fieldSize; i++)
                                for (int j = 0; j < fieldSize; j++)
                                    if (resWeights[i, j] == max && field[i, j] == -fieldSize)
                                    {
                                        field[i, j] = botSide;
                                        return 0;
                                    }
                        }
                    }
                    return 0;
                }
                else
                {
                    for (int i = 0; i < fieldSize; i++)
                        for (int j = 0; j < fieldSize; j++)
                            if (field[i, j] == -fieldSize)
                            {
                                field[i, j] = botSide;
                                if (ifGameOn() != -1)
                                {
                                    field[i, j] = botSide;
                                    return 0;
                                }
                                field[i, j] = -fieldSize;
                            }
                    for (int i = 0; i < fieldSize; i++)
                        for (int j = 0; j < fieldSize; j++)
                            if (field[i, j] == -fieldSize)
                            {
                                field[i, j] = side;
                                if (ifGameOn() != -1)
                                {
                                    field[i, j] = botSide;
                                    return 0;
                                }
                                field[i, j] = -fieldSize;
                            }
                    int[,] resWeights1 = new int[fieldSize, fieldSize];
                    resWeights1 = setWeights1(field);
                    int max = -21, kolMax = 0;
                    for (int i = 0; i < fieldSize; i++)
                        for (int j = 0; j < fieldSize; j++)
                            if (resWeights1[i, j] == max) kolMax++;
                            else if (resWeights1[i, j] > max)
                            {
                                kolMax = 1;
                                max = resWeights1[i, j];
                            }
                    if (kolMax == 1)
                    {
                        for (int i = 0; i < fieldSize; i++)
                            for (int j = 0; j < fieldSize; j++)
                                if (resWeights1[i, j] == max && field[i, j] == -fieldSize)
                                {
                                    field[i, j] = botSide;
                                    return 0;
                                }
                    }
                    else
                    {
                        int[,] resWeights = new int[fieldSize, fieldSize];
                        for (int i = 0; i < fieldSize; i++)
                            for (int j = 0; j < fieldSize; j++)
                                resWeights[i, j] = 0;
                        kolMax = 0; max = -fieldSize;
                        for (int i = 0; i < fieldSize; i++)
                            for (int j = 0; j < fieldSize; j++)
                                if (field[i, j] == -fieldSize)
                                {
                                    int res = 0;
                                    field[i, j] = botSide;
                                    int[,] dopMas = new int[fieldSize, fieldSize];
                                    dopMas = setWeights1(field);
                                    int sum = 0;
                                    for (int ii = 0; ii < fieldSize; ii++)
                                        for (int jj = 0; jj < fieldSize; jj++)
                                            sum += dopMas[ii, jj];
                                    res += sum;
                                    res += countPossibleWins(field, botSide);
                                    resWeights[i, j] = res;
                                    if (res == max) kolMax++;
                                    else if (res > max)
                                    {
                                        kolMax = 1;
                                        max = res;
                                    }
                                    field[i, j] = -fieldSize;
                                }
                        for (int i = 0; i < fieldSize; i++)
                            for (int j = 0; j < fieldSize; j++)
                                if (resWeights[i, j] == max)
                                {
                                    field[i, j] = botSide;
                                    int[,] dopMas1 = new int[fieldSize, fieldSize];
                                    int[,] dopMas2 = new int[fieldSize, fieldSize];
                                    int kol = 0;
                                    dopMas1 = setWeights1(field);
                                    dopMas2 = setWeights0(field);
                                    for (int ii = 0; ii < fieldSize; ii++)
                                        for (int jj = 0; jj < fieldSize; jj++)
                                            if (dopMas1[ii, jj] > 1)
                                            {
                                                if (dopMas2[ii, jj] > 0) kol++;
                                            }
                                    if (kol == 1) resWeights[i, j]--;
                                    field[i, j] = -fieldSize;
                                }
                        for (int i = 0; i < fieldSize; i++)
                            for (int j = 0; j < fieldSize; j++)
                                if (resWeights[i, j] == max && field[i, j] == -fieldSize)
                                {
                                    field[i, j] = botSide;
                                    return 0;
                                }
                    }
                    return 0;
                }
            }
            public void goGame()
            {
                if (side == 0)
                    botMove(0, 0, true);
                while (ifGameOn() == -1)
                {
                    Console.WriteLine("Game field:");
                    showField();
                    Console.WriteLine("Enter the coordinates of the square: ");
                    Console.Write("Col(1-{0}): ", fieldSize);
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Row(1-{0}): ", fieldSize);
                    int y = int.Parse(Console.ReadLine());
                    if (botMove(y, x, false) == -1) Console.WriteLine("You entered inappropriate coordinates, try again");
                }
                if (ifGameOn() != -1)
                {
                    Console.WriteLine("Game field:");
                    showField();
                    if (ifGameOn() == 1 || ifGameOn() == 0)
                    {
                        Console.Write("Game over, the winner is ");
                        if (ifGameOn() == 1) Console.Write("X(1)!"); else Console.Write("O(0)!");
                    }
                    if (ifGameOn() == 2) Console.WriteLine("Draw!");
                }
            }
        }
        static void Main(string[] args)
        {
        startAgain: Console.WriteLine("Enter the field size (from 3 to 20)");
            int fieldSize = int.Parse(Console.ReadLine());
            if (fieldSize > 2 & fieldSize < 21)
            {
                Console.WriteLine("Choose Your side, X(1) or O(0), X moves first");
                int side = int.Parse(Console.ReadLine());
                Bot bot = new Bot(fieldSize, side);
                bot.goGame();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You entered inappropriate field size");
                goto startAgain;
            }

        }
    }
}

