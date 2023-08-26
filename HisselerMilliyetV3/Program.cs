using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HisselerMilliyetV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var htmlDOC = web.Load("https://uzmanpara.milliyet.com.tr/canli-borsa/");
            //https://kur.doviz.com/

            var stringID = "table3";

            var tables = htmlDOC.DocumentNode.SelectNodes($"//table[@class='{stringID}']");

            if (tables != null)
            {
                foreach (var table in tables)
                {

                    var rows = table.SelectNodes(".//tr");

                    foreach (var row in rows)
                    {
                        var cells = row.SelectNodes(".//td");
                        if (cells != null)
                        {
                            foreach (var cell in cells)
                            {
                                Console.Write(cell.InnerText.Trim() + "\t");

                            }

                        }
                    }
                    Console.WriteLine("-----------");

                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("Tablo yok ki");
                Console.ReadKey();
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
