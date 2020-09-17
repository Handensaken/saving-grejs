using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace saving_grejs
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HahaClass));
            HahaClass myNewClass = new HahaClass();
            FileStream file = File.Open(@"class.xml", FileMode.OpenOrCreate);
            string[] message = {"loadin existing","create new"};
            if(LetsSee(message, "load or create new") && File.Exists(@"class.xml")){
                myNewClass = (HahaClass) serializer.Deserialize(file);
                System.Console.WriteLine("loaded in existing class");
                file.Close();
                System.Console.WriteLine("loaded class with stats: ");
                System.Console.WriteLine(File.ReadAllText("class.xml"));
            }
            else{
                System.Console.WriteLine("made new class");
                System.Console.WriteLine("enter new name: ");
                myNewClass.name = Console.ReadLine();
                Console.Clear();
                System.Console.WriteLine("enter x pos");
                myNewClass.position[0] = Parser(myNewClass.position[0]);
                Console.Clear();
                System.Console.WriteLine("enter y pos");
                myNewClass.position[1] = Parser(myNewClass.position[1]);
                Console.Clear();
                string[] choices ={"yes", "no"};
                myNewClass.alive = LetsSee(choices, "is alive?");
                serializer.Serialize(file, myNewClass);
                file.Close();
                System.Console.WriteLine("created new class with stats: ");
                System.Console.WriteLine(File.ReadAllText("class.xml"));
            }
            Console.ReadLine();

            float Parser(float value){
                bool success = false;
                while (!success){if(float.TryParse(Console.ReadLine(), out value)){success = true;}else{System.Console.WriteLine("enter number"); Console.ReadKey();}}
                return value; 
            }
            bool LetsSee(string[] m, string question)
            {
                int current = 0;
                while(true)
                {
                        System.Console.WriteLine(question);
                    for (int i = 0; i < m.Length; i++)
                    {
                        if(current == i){
                            System.Console.WriteLine($"> {m[i]}");
                        }
                        else{
                            System.Console.WriteLine($"  {m[i]}");
                        }
                    }
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W){current--;}
                    if(key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S){current++;}
                    if(current < 0){current = m.Length-1;}
                    if(current > m.Length-1){current = 0;}
                    if(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.E){
                        if(current == 0){
                            Console.Clear();
                            return true;
                        }
                        else{
                            Console.Clear();
                            return false;
                        }
                    }
                    Console.Clear();
                }
            }
        }
    }
}
