using System;
using System.Linq;

namespace LCStringToIntegerAtoi
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "-3147483648";

            Console.WriteLine(ConvertToInt(str));

            int ConvertToInt(string str)
            {
                if (!str.Any(char.IsDigit))
                {
                    return 0;
                }

                str = str.TrimStart(' ');     
                
                if (char.IsDigit(str[0]) || str[0].Equals('+') && char.IsDigit(str[1]) || str[0].Equals('-') && char.IsDigit(str[1]))
                {
                    bool isNegative = false;

                    if (str[0].Equals('-') || str[0].Equals('+'))
                    {
                        if (str[0].Equals('-'))
                        {
                            isNegative = true;
                        }

                        str = str.Substring(1);
                    }

                    str = str.TrimStart('0');

                    if (string.IsNullOrEmpty(str) || !char.IsDigit(str[0]))
                    {
                        return 0;
                    }

                    string digitString = string.Empty;

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (char.IsDigit(str[i]))
                        {
                            digitString += str[i];

                            if (digitString.Length > 10)
                            {
                                if (isNegative)
                                {
                                    return int.MinValue;
                                }

                                return int.MaxValue;
                            }

                            try
                            {
                                if (!char.IsDigit(str[i + 1])) { break; }
                            }
                            catch { break; }
                        }
                    }

                    long.TryParse(digitString, out var extractedNumber);

                    if (isNegative)
                    {
                        extractedNumber *= -1;
                    }

                    if (extractedNumber > int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                    if (extractedNumber < int.MinValue)
                    {
                        return int.MinValue;
                    }

                    return (int)extractedNumber;
                }

                return 0;
            }
        }
    }
}
