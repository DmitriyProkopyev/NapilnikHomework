public static int Clamp(int value, int minLimit, int maxLimit)
{
    if (value < minLimit)
        return minLimit;
    if (value > maxLimit)
        return maxLimit;
    return value;
}
