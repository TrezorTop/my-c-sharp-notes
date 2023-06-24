// See https://aka.ms/new-console-template for more information

using System.Globalization;

string str = "2/52";

NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
{
    NumberDecimalSeparator = "/",
};

float number = Convert.ToSingle(str, numberFormatInfo);

Console.WriteLine(number);
