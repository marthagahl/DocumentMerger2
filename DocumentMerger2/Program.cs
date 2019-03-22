using System;
using System.IO;
using System.Linq;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Document Merger 2");
                foreach (string arg in args)
                {
                    Console.WriteLine(arg);
                }
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
                return;
            }

            foreach (string input in args)
            {
                bool doc = IsValid(input);
                if (doc is false)
                {
                    Console.WriteLine("Filename does not exist.");
                    return;
                }
            }

            string[] sourceFiles = args.Take(args.Length - 1).ToArray();
            string content = "";

            foreach (string doc in sourceFiles)
            {
                StreamReader reader = new StreamReader(doc);
                try
                {
                    string content1 = reader.ReadToEnd();
                    content = content + content1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            StreamWriter writer = new StreamWriter(args[args.Length - 1]);
            try
            {
                writer.WriteLine(content);
                Console.WriteLine("{0} was successfully saved.", args[args.Length - 1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }


        static bool IsValid(string doc)
        {
            if (File.Exists(doc) is false)
            {
                return false;
            }
            return true;
        } 

    }
}
