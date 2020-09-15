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
            Console.WriteLine("Hello World!");
            float[] pos = {1.6f, 2.8f};
            HahaClass myNewClass = new HahaClass(pos, "hello", true);

            FileStream file = File.Open(@"class.xml", FileMode.OpenOrCreate);
            myNewClass = (HahaClass) serializer.Deserialize(file);
            serializer.Serialize(file, myNewClass);

        }
    }
}
