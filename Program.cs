using System;
using System.Collections.Generic;

namespace SpreeTrail
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome Screen
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("************ MULTI VALUE DICTIONARY APP *************");
            Console.WriteLine("-----------------------------------------------------");

            MultiValueDictionary<string, string> mvd = new MultiValueDictionary<string, string>();

            MultiValueDictionaryHelper.ShowOperationList();

            do
            {
                string operation = Console.ReadLine();

                if (operation.ToUpper().Equals("EXIT"))
                {
                    Environment.Exit(0);
                }

                MultiValueDictionaryHelper.CallOperation(operation, mvd);

            } while (true);
        }
    }
}
