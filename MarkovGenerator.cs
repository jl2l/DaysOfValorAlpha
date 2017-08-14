using MarkovSharp.TokenisationStrategies;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    public class MarkovGenerator
    {

        public List<string> Headlines;
        public List<string> terminals;
        public List<string> startwords;
        public string generatedHeadline = string.Empty;
        public string path = "c:\\users\\joseph.loiacono\\documents\\visual studio 2015\\Projects\\ConsoleApplication3\\ConsoleApplication3\\NewFolder1\\headlines.json";
        //public MarkovChain<string> GeneratorHeadline;

        public void ProcessHeadlines()
        {
            Headlines = new List<string>();
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray o2 = (JArray)JToken.ReadFrom(reader);
                o2.ToList().ForEach(headline => {
                    var sentence = headline.First<JToken>().Value<string>();
                    Headlines.Add(sentence);
                });
               
                   
            }

        }

        public void ProcessMarkov(List<string> inputHeadlines)
        {

            ProcessHeadlines();
            // Create a new model
            var model = new StringMarkov(1);

            // Train the model
            model.Learn(Headlines.ToArray());

            for (int i = 0; i < 3; i++)
            {
                generatedHeadline += model.Walk(3).First() +".\n";
                Console.WriteLine(generatedHeadline);
            }
           
            // Create some permutations
           
            Console.Read();
        }



    }
}
