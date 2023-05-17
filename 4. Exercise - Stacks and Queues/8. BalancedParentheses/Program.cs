//   {[()]}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

string parentes = (Console.ReadLine());
Stack<char> openParantes = new();
bool isValid = true;

foreach (var item in parentes)
{
    if (item == '{' || item == '[' || item == '(')
    {
        openParantes.Push(item);
        continue;
    }
    if (item == '}')
    {
        if (!openParantes.Any() || openParantes.Pop() != '{')
        {
            Console.WriteLine("NO");
            return;
        }        
    }
    else if (item == ']')
    {
        if (!openParantes.Any() || openParantes.Pop() != '[')
        {
            Console.WriteLine("NO");
            return;
        }
    }
    else if (item == ')')
    {
        if (!openParantes.Any() || openParantes.Pop() != '(')
        {
            Console.WriteLine("NO");
            return;
        }
    }
}

if (!openParantes.Any())
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}