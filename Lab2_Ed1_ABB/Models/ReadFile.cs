using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Lab2_Ed1_ABB.Models;

namespace Lab2_Ed1_ABB.Controllers
{
    public class ReadFile
    {
        public void ReadFiles(string route)
        {

            bool ejecutar = false;
            var line = "";
            using (FileStream fileStream = new FileStream(route, FileMode.Open))
            {
                using (StreamReader file = new StreamReader(fileStream))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        var values = line.Split(',');

                        if (ejecutar)
                        {
                            var indice = new Indice
                            {
                                lineNumber = int.Parse(values[0]),
                                nameDrug = values[1]
                            };
                            indice.saveIndice();
                        }
                        ejecutar = true;
                    }
                }
            }
        }
    }
}