
using System.Numerics;

Console.WriteLine("Введите Unix код");
long input = Convert.ToInt64(Console.ReadLine());
long seconds = input / 1000;
long minutes = seconds / 60;
long hours = minutes / 60;
long days = hours / 24;
int year = 1970;
int month = 1;
int dayS = 1;


for (int i = year; days >= 365; days -= 365 )
{
    year++;
    if(year % 4 == 0)
    {
        days--;
    }

}


int[] monthDays = {31, 31, (year % 4 == 0 ? 29 : 28) , 31, 30, 31, 30, 31, 30, 30, 31, 31,30};

for (int i = month; days >= monthDays[month - 1]; days -= monthDays[month - 1] )
{

/*    if (days == 29 && month == 2) {  month --;break; }*/
    month++;
}

if (year % 4 == 0) { days++; }
days += dayS;


if (year % 4 == 0 && month == 2 && days >= 30) { month++; days -= days; }
if (year > 2038 && month == 2 && days == 29) { month++; days -= days; }

int day = Convert.ToInt32(days);
int hour = Convert.ToInt32(hours % 24);
int minute = Convert.ToInt32(minutes % 60);
int second = Convert.ToInt32(seconds % 60);
string inputStr = input.ToString();
string milliseconds;
if (inputStr.Length >= 4)
{
milliseconds = inputStr.Substring(inputStr.Length - 3);
}
else
{
    milliseconds = inputStr;
}

string millisec = milliseconds.Length == 1 ? "00" + milliseconds : milliseconds.Length == 2 ? "0" + milliseconds : milliseconds;

if (day == 0 || day < 0)
{
    day = dayS;
}
string yearHigh = (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0)) ? "Високосный" : "Не високосный" ;
string output = String.Format("{0:d2}.{1:d2}.{2} {3:d2}:{4:d2}:{5:d2}.{6} {7}",day,month,year,hour,minute,second,millisec,yearHigh);
Console.WriteLine(output);
