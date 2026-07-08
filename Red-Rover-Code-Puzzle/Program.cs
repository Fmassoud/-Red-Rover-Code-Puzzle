// See https://aka.ms/new-console-template for more information
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


const string input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
//const string input = "fady(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
Console.WriteLine($"Input: {input}");

if (!string.IsNullOrWhiteSpace(input))
{
    var outputList = StringParser.Parse(input);

    Console.WriteLine($"\r\n Output:");
    Print(outputList);

    Console.WriteLine("\r\n Ordered List: ");
    Print(outputList, Order: true);
}
else
    Console.WriteLine("\r\n Input string is empty ");

static void Print(List<Output> results, string space = "", bool Order = false)
{
    if (Order)
        results = results.OrderBy(x => x.Name).ToList();
    foreach (var x in results)
    {
        Console.WriteLine(space + " - " + x.Name);
        Print(x.Children, space + "  ", Order);
    }
}
