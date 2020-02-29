using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Lab2_Ed1_ABB.Models;
using Lab2_Ed1_ABB.Helpers;

namespace Lab2_Ed1_ABB.Controllers
{
    public class ReadFile
    {
        public List<Medication> SearcInFile(int lineNumber)
        {
            string route = Storage.Instance.route;
            var line = "";
            int coutLine = 0;
            var showMediction = new List<Medication>();
            using (FileStream fileStream = new FileStream(route, FileMode.Open))
            {
                using (StreamReader file = new StreamReader(fileStream))
                {
                    while ((line = file.ReadLine()) != null && coutLine <= lineNumber)
                    {
                        if (coutLine == lineNumber)
                        {
                            var values = line.Split(',');
                            var medication = new Medication
                            {
                                Id = int.Parse(values[0]),
                                NameDrug = values[1],
                                Stock = int.Parse(values[values.Length - 1])    
                            };
                            string sPrice = values[values.Length - 2].Trim('$');
                            var change = sPrice.Split('.');                          
                            medication.Price = double.Parse(sPrice = change[0] + ',' + change[1]);
                            showMediction.Add(medication);
                        }
                        coutLine++;
                    }
                }
            }
            return showMediction;
        }
        public void ReadFiles()
        {
            string route = Storage.Instance.route;
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