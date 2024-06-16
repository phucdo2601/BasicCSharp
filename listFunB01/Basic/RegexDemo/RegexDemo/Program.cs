/*
 * ^ - Starts with
 * $ - Ends with
 * [] - Range
 * () - Group
 * . - Single character once
 * + - one or more characters in a row
 * ? - optional preceding character match
 * \ - escape character
 * \n - New line
 * \d - Digit
 * \D - Non-digit
 * \s - White space
 * \S - non-white space
 * \w - alphanumeric/underscore character (word chars)
 * \W - non-word characters
 * {x,y} - Repeat low (x) to high (y) (no "y" means at least x, no ",y" means that many)
 * (x|y) - Alternative - x or y
 * 
 * [^x] - Anything but x (where x is whatever character you want)
 */

using System.Diagnostics;
using System.Text.RegularExpressions;

/*string pattern = @"(\s|^)Tim(\s|$)"*/;
/*string toSearch = "Tim Match";*/

/*Console.WriteLine("Tim Match: "+Regex.IsMatch("Tim Match", pattern));
Console.WriteLine("Tim Test: " + Regex.IsMatch("Timothy Test", pattern));
Console.WriteLine("Sometimes: " + Regex.IsMatch("Always Tim", pattern));
Console.WriteLine("I am Tim Corey: " + Regex.IsMatch("I am Tim Corey", pattern));*/

/*Stopwatch stopwatch = new();
stopwatch.Start();

Regex test = new Regex(pattern);

for (int i = 0; i < 10000; i++)
{


    test.IsMatch("I am Tim Cook");
}

stopwatch.Stop();

Console.WriteLine($"Time Elapse in ms: {stopwatch.ElapsedMilliseconds} ");
*/

string toSearch = File.ReadAllText("test.txt");
string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";
MatchCollection matches = Regex.Matches(toSearch, pattern);

foreach (Match match in matches)
{
    Console.WriteLine(match.Value);
}