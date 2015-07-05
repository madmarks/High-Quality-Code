public void PrintStatistics(double[] array, int count)
{
    var max = array[0];
        
    for (int i = 1; i < count; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
        }
    }

    PrintMaxValueOfArrayElements(max);

    var min = array[0];

    for (int i = 1; i < count; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
        }
    }

    PrintMinValueOfArrayElements(min);

    double sum = 0;

    for (int i = 0; i < count; i++)
    {
        sum += array[i];
    }

    var average = sum / count;

    PrintAverageValueOfArrayElements(average);
}