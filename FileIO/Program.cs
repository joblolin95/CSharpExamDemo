using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //var docs = Environment.SpecialFolder.MyDocuments;
            var directory = Directory.GetCurrentDirectory();
            var file = Path.Combine(directory, "newFile.txt");
            var content = "Testing testing - 1, 2, 3";

            #region Basic File Reading and Writing
            //write to said file
            File.WriteAllText(file, content);

            // read from said file
            var read = File.ReadAllText(file);
            Console.Write(read.Equals(content));
            

            //var iso = IsolatedStorageFile
            //    .GetStore(IsolatedStorageScope.Assembly, "CSharpExamDemo")
            //    .GetDirectoryNames("*");

            var manualPath = new DirectoryInfo("c:\\Users\\joseph.olin");
            var file2 = Path.Combine(manualPath.ToString(), "newFile1.txt");
            var content2 = "Now testing using a manual file path";
            File.WriteAllText(file2, content2);

            var read2 = File.ReadAllText(file2);
            Console.WriteLine(read2.Equals(content2));

            
            foreach(var item in Directory.GetFiles(directory))
            {
                Console.WriteLine(Path.GetFileName(item));
            }
            #endregion

            #region Copying/Moving Files Around
            var path1 = Path.Combine(manualPath.ToString(), "newFile1.txt");
            var path2 = Path.Combine(manualPath.ToString(), "newFileCopy.txt");

            if (File.Exists(path2))
            {
                Console.WriteLine(path2 + " already exists. Deleting it ...");
                File.Delete(path2);
                Console.WriteLine(path2 + " was deleted");
            }
            File.Copy(path1, path2);

            var info = new FileInfo(path2);
            Console.WriteLine(info.Name);
            Console.WriteLine(info.Length + " bytes");
            #endregion

            #region JSON Serialization
            /* 
            var url = new Uri("http://localhost:1234/MyService.svc/json/4");
            var client = new System.Net.WebClient();
            var json = await client.DownloadStringTaskAsync(url);

            // deserialize JSON into objects
            var serializer = new JavascriptSerializer();
            var data = serializer.Deserialize<JSONSAMPLE.Data>(json);

            // use the objects
            Console.Writeline(data.number);
            foreach (var item in data.Multiples)
                Console.Write("{0}", item);
            */

            Data d = new Data
            { 
                Number = 10, 
                Multiples = new int[3]{1, 2, 3}
            };

            using (MemoryStream stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(Data));
                serializer.WriteObject(stream, d);

                stream.Position = 0;
                StreamReader streamReader = new StreamReader(stream);
                Console.WriteLine("Serialized JSON Data");
                Console.WriteLine(streamReader.ReadToEnd());


                stream.Position = 0;
                Console.WriteLine("De-serialized Data");
                Data outcomingData = serializer.ReadObject(stream) as Data;
                Console.WriteLine(outcomingData);
            }



            #endregion

            #region XML Serialization

            var path = Path.Combine(directory, "xmlFile.xml");

            var ser = new XmlSerializer(typeof(Data));

            string xml = "";
            using (StringWriter stringWriter = new StringWriter())
            {
                ser.Serialize(stringWriter, d);
                xml = stringWriter.ToString();
                Console.WriteLine(xml);
                File.WriteAllText(path, xml);
            }
            using (var stringReader = new StringReader(xml))
            {
                var d2 = ser.Deserialize(stringReader) as Data;
                Console.WriteLine(d2);
            }

                #endregion


                ProgramFlow.Class1.Pause();
        }
    }
}
