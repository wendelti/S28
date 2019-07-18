using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static S28Filler2.Definitions;

namespace S28Filler2
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Bem vindo ao auxiliador de preenchimento do S28!");
            Console.WriteLine("Escolha qual a��o voc� deseja executar:");

            Console.WriteLine("1) Definir o estoque anterior");

            Console.WriteLine("2) Definir o estoque/recebido do m�s Set/Mar");
            Console.WriteLine("3) Definir o estoque/recebido do m�s Out/Abr");
            Console.WriteLine("4) Definir o estoque/recebido do m�s Nov/Mai");
            Console.WriteLine("5) Definir o estoque/recebido do m�s Dez/Jun");
            Console.WriteLine("6) Definir o estoque/recebido do m�s Jan/Jul");
            Console.WriteLine("7) Definir o estoque/recebido do m�s Fev/Ago");

            var acao = Console.ReadLine();
            var filler = new Filler(new Reader(), new Definitions.Mapping());
            switch (acao)
            {
                case "1":
                    filler.fillStock();
                    break;

                case "2":
                    filler.fillMonthStock(eCell.SetMarEst, eCell.SetMarRec);
                    break;

                case "3":
                    filler.fillMonthStock(eCell.OutAbrEst, eCell.OutAbrRec);
                    break;

                case "4":
                    filler.fillMonthStock(eCell.NovMaiEst, eCell.NovMaiRec);
                    break;

                case "5":
                    filler.fillMonthStock(eCell.DezJunEst, eCell.DezJunRec);
                    break;

                case "6":
                    filler.fillMonthStock(eCell.JanJulEst, eCell.JanJulRec);
                    break;

                case "7":
                    filler.fillMonthStock(eCell.FevAgoEst, eCell.FevAgoRec);
                    break;

                default:
                    break;
            }

            Console.WriteLine("A��o realizada com sucesso! Verifique o arquivo de sa�da. Obrigado!");
            Console.ReadLine();

        }





    }

}
