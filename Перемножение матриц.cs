int CorrectInput()
{
    string? UserNumber;
    int number = 0;
    bool check = false;
    while (check == false)
    {
        UserNumber = Console.ReadLine();
        if (int.TryParse(UserNumber, out number))
        {
            check = true;
        }
        else
        {
            Console.Write("Ошибка ввода.\n Повторите ввод:");
        }
    }
    return number;
}

// создание двумерного массива
int[,] CreateArray()
{
    Console.Write("Введите количество строк: ");
    int n = CorrectInput();
    Console.Write("Введите количество столбцов: ");
    int m = CorrectInput();
    int[,] matrix = new int[n, m];
    for (int i = 0; i<n; i++)
    {
        for (int j = 0; j<m; j++)
        {
            matrix[i,j] = new Random().Next(-9,10);            
        }
    }
    return matrix;
}

// Вывод двумерного массива
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i<matrix.GetUpperBound(0) + 1; i++)
    {
        for (int j = 0; j<matrix.GetUpperBound(1) + 1; j++)
        {
            if (matrix[i,j]<0)
                Console.Write(matrix[i,j]+" ");
            else
                Console.Write(" " + matrix[i,j]+" ");             
        }
    Console.WriteLine();
    }
}


// Произведение матриц
void MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
    if (matrix2.GetLength(0) == matrix1.GetLength(1))
    {
        int[,] resultMatrix = new int[matrix1.GetLength(0),matrix2.GetLength(1)];
        int size = matrix1.GetLength(1);
        for (int i = 0; i < resultMatrix.GetLength(0) ; i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1) ; j++)
            {
                for (int k = 0; k < size ; k++)
                {
                    resultMatrix[i,j] += matrix1[i,k]*matrix2[k,j];
                }
            }
        }
        Console.WriteLine("Произведение матриц равно:");
        PrintMatrix(resultMatrix);
    }
    else
        Console.WriteLine("Эти матрицы перемножить нельзя. Ошибка при вводе размеров.");
}


//Код программы
Console.WriteLine("Введите матрицу 1");
int[,] matrix01 = CreateArray();
PrintMatrix(matrix01);
Console.WriteLine("Введите матрицу 2");
int[,] matrix02 = CreateArray();
PrintMatrix(matrix02);

MultiplicationMatrix(matrix01,matrix02);