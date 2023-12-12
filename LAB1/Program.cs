// ввод размера массива n

Console.WriteLine("ЧАСТЬ 1\n");
Console.Write("Введите размер массива N: ");
var isValid = int.TryParse(Console.ReadLine(), out var n);
if (!isValid || n <= 0)
{
    Console.WriteLine("Размер массива должен быть натуральным числом");
    return;
}

var array = new int[n];
var random = new Random();
var minpos = 999;
var maxpos = 0;
var sum = 0;

// заполнение массива
for (var i = 0; i < n; i++)
{
    array[i] = random.Next(-100, 100);
    Console.Write(array[i] + " ");
    if (Math.Abs(array[i]) < Math.Abs(minpos))
        minpos = array[i];
    if (Math.Abs(array[i]) > Math.Abs(maxpos))
        maxpos = array[i];
    if (array[i] > 0)
        sum += array[i];
}

Console.WriteLine();
Console.WriteLine($"Сумма положительных элементов массива: {sum}");

minpos = Array.IndexOf(array, minpos);
maxpos = Array.IndexOf(array, maxpos);

if (minpos > maxpos)
{
    sum = minpos;
    minpos = maxpos;
    maxpos = sum;
}

sum = 1;
minpos += 1;
if (minpos == maxpos)
{
    sum = 0;}
else
{
    for (var i = minpos; i < maxpos; i++)
    {
        sum *= array[i];
    }
}

Console.WriteLine(
    $"Произведение элементов массива, расположенных между максимальным по модулю и минимальным по модулю элементами: {sum}\n");


Console.WriteLine("ЧАСТЬ 2\n");

Console.Write("Введите размер массива X: ");
isValid = int.TryParse(Console.ReadLine(), out var x);
if (!isValid || x <= 0)
{
    Console.WriteLine("Размер массива должен быть натуральным числом");
    return;
}

Console.Write("Введите размер массива Y: ");
isValid = int.TryParse(Console.ReadLine(), out var y);
if (!isValid || y <= 0)
{
    Console.WriteLine("Размер массива должен быть натуральным числом");
    return;
}

// заполнение матрицы
var matrix = new int[y, x];
sum = 0;
Array.Clear(array);

for (var i = 0; i < y; i++)
{
    for (var j = 0; j < x; j++)
    {
        matrix[i, j] = random.Next(-100, 100);
        Console.Write(matrix[i,j] + " ");
    }
    Console.WriteLine();
}

// вычсиления
for (var i = 0; i < y; i++)
{
    for (var j = 0; j < x; j++)
    {
        if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
            array[i] += matrix[i, j];
        if (matrix[i, j] == 0)
            break;
        if (j == x - 1)
            sum++;
    }
}

Console.WriteLine($"Количество столбцов, не содержащих ни одного нулевого элемента: {sum}\n");
sum = 0;

// суммы
for (var i = 0; i < y; i++)
{
    Console.Write(array[i] + " ");
}
Console.WriteLine();

// массив с очередностью
for (var i = 0; i < y; i++)
{
    foreach (var j in array)
    {
        if (j > sum)
            sum = j;
    }
    
    array[Array.IndexOf(array, sum)] = i * -1;
    sum = 0;
}

// вывод очередности
for (var i = 0; i < y; i++)
{
    array[i] *= -1;
    Console.Write(array[i] + " ");
}
Console.WriteLine("\n");



// создание новой матрицы
var newMatrix = new int[y, x];
for (int i = 0; i < y; i++)
{
    for (int j = 0; j < x; j++)
    {
        newMatrix[i, j] = matrix[Array.IndexOf(array, i), j];
        Console.Write(newMatrix[i,j] + " ");
    }
    Console.WriteLine();
}

