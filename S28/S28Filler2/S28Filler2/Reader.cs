using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static S28Filler2.Definitions;

namespace S28Filler2
{
    public class Reader
    {
        private string baseLocation;

        public Reader()
        {
            this.baseLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        }

        public List<publicacao> GetStock()
        {
            var content = File.ReadAllText($"{baseLocation}\\arquivos\\site\\estoque\\estoque.json");
            return JsonConvert.DeserializeObject<List<publicacao>>(content);
        }

        public List<publicacao> GetReceived()
        {
            var receivedPublications = new List<publicacao>();
            var files = Directory.GetFiles($"{baseLocation}\\arquivos\\site\\recebidos\\");

            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                receivedPublications.AddRange( JsonConvert.DeserializeObject<List<publicacao>>(content));
            }

            return receivedPublications;

        }



        public class publicacao
        {
            public string Codigo;
            public string Quantidade;
            public eRow Linha
            {
                get
                {
                    eRow linha = eRow.NotFound;
                    try
                    {
                        linha = (eRow)Enum.Parse(eRow.NotFound.GetType(), $"p{Codigo}");
                    }
                    catch (Exception)
                    {
                    }
                    return linha;
                }
            }
        }

    }

}
