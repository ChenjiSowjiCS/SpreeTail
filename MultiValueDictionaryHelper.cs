using System;
using System.Collections.Generic;

namespace SpreeTrail
{
    public static class MultiValueDictionaryHelper
    {
        private static readonly char SEPARATOR = ' ';
        public static void ShowOperationList()
        {
            Print("Usage:  {Command}  [key]  [value]\n\n");
            Print("\tADD\t\t- Adds key & value to the dictionary \n\t\t\t  Usage: ADD {key} {value}\n");
            Print("\tREMOVE\t\t- Removes a value from a key \n\t\t\t  Usage: REMOVE {key} {value}\n");
            Print("\tREMOVEALL\t- Removes all values from a key \n\t\t\t  Usage: REMOVEALL {key}\n");
            Print("\tCLEAR\t\t- Removes all keys & values from the dictionary \n\t\t\t  Usage: CLEAR\n");
            Print("\tKEYS\t\t- Retuns all the keys in the dictionary \n\t\t\t  Usage: KEYS\n");
            Print("\tMEMBERS\t\t- Retuns collection of string(members) for given key \n\t\t\t  Usage: MEMBERS {key}\n");
            Print("\tKEYEXISTS\t- Returns a key exists or not \n\t\t\t  Usage: KEYEXISTS {key}\n");
            Print("\tVALUEEXISTS\t- Returns if a value exists within a key \n\t\t\t  Usage: VALUEEXISTS {key} {value}\n");
            Print("\tALLMEMBERS\t- Returns all the values in the dictionary \n\t\t\t  Usage: ALLMEMBERS\n");
            Print("\tITEMS\t\t- Returns all keys and correponding values in the dictionary \n\t\t\t  Usage: ITEMS \n");
            Print("\tEXIT\t\t- To exit out of the application \n\t\t\t  Usage: EXIT \n");
            Print("\tHELP\t\t- To show the command list \n\t\t\t  Usage: HELP\n");
        }

        public static void CallOperation(string operation, MultiValueDictionary<string, string> mvd)
        {
            if (operation == null)
            {
                Print("Invalid Operation");
                return;
            }

            string[] ops = operation.Split(SEPARATOR);
            string command = null;
            string key = null;
            string val = null;
            int counter = 0;

            if (ops.Length >= 1) { command = ops[0]; }
            if (ops.Length >= 2) { key = ops[1]; }
            if (ops.Length == 3) { val = ops[2]; }

            try
            {
                switch (command.ToUpper())
                {
                    case "ADD":
                        mvd.Add(key, val);
                        Print("Added");
                        break;

                    case "REMOVE":
                        mvd.Remove(key, val);
                        Print("Removed");
                        break;

                    case "VALUEEXISTS":
                        bool isValExist = mvd.CheckValueExists(key, val);
                        if (isValExist)
                        {
                            Print("true");
                        }
                        else
                        {
                            Print("false");
                        }
                        break;

                    case "MEMBERS":
                        List<string> members = mvd.GetMembers(key);
                        counter = 0;
                        if (members.Count == 0)
                        {
                            Print("(empty set)");
                        }
                        else
                        {
                            foreach (string s in members)
                            {
                                Print(++counter + ") " + s);
                            }
                        }
                        break;

                    case "REMOVEALL":
                        mvd.RemoveAll(key);
                        Print("Removed");
                        break;

                    case "KEYEXISTS":
                        bool isKeyExist = mvd.CheckKeyExists(key);
                        if (isKeyExist)
                        {
                            Print("true");
                        }
                        else
                        {
                            Print("false");
                        }
                        break;

                    case "KEYS":
                        List<string> keys = mvd.GetKeys();
                        counter = 0;
                        if (keys.Count == 0)
                        {
                            Print("(empty set)");
                        }
                        else
                        {
                            foreach (string s in keys)
                            {
                                Print(++counter + ") " + s);
                            }
                        }
                        break;

                    case "CLEAR":
                        mvd.Clear();
                        Print("Cleared");
                        break;

                    case "ALLMEMBERS":
                        List<string> allMembers = mvd.GetAllMembers();
                        counter = 0;
                        if (allMembers.Count == 0)
                        {
                            Print("(empty set)");
                        }
                        else
                        {
                            foreach (string s in allMembers)
                            {
                                Print(++counter + ") " + s);
                            }
                        }
                        break;

                    case "ITEMS":
                        Dictionary<string, List<string>> items = mvd.GetItems();
                        counter = 0;
                        if (items.Count == 0)
                        {
                            Print("(empty set)");
                        }
                        else
                        {
                            foreach (KeyValuePair<string, List<string>> kvp in items)
                            {
                                List<string> list = kvp.Value;
                                foreach (string s in list)
                                {
                                    Print(++counter + ") " + kvp.Key + ": " + s);
                                }
                            }
                        }
                        break;

                    case "HELP": ShowOperationList();
                        break;

                    default: Print("Invalid Input. Please refer to the command list above or type HELP");
                        break;
                }
            }
            catch (Exception e)
            {
                Print(e.Message);
            }
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}