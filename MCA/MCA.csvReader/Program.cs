using CsvHelper;
using FileHelpers;
using NodeCreate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TreeBuilder;

namespace MCA.csvReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string relativePathFileCSV = @"Navigation.csv";

            List<Node> nodes = new List<Node>();
     



            StreamReader reader = new StreamReader(relativePathFileCSV);
            var counter = File.ReadAllLines(relativePathFileCSV).Count();
            Console.WriteLine(counter);
            var line = reader.ReadLine();

          

            while (line.Length > 0)
            {

                

                    line = reader.ReadLine();
                    {

                        //Console.WriteLine(line);
                        if(line != null) 
                        {
                        nodes.Add(new Node(line));
                        }
                        else
                        {
                        break;
                        }
                    }
                
            }
                reader.Close();
            Tree ajax = new Tree(nodes);
            ajax.PrintTree();

            Console.ReadLine();
        }
    }
}



