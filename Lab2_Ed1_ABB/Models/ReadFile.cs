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
        public static void editStock(int lineNumber, int newStock , string path)
        {
            path += "Prueva.txt";
            var route = Storage.Instance.route;
            var line = "";
            int countLine = 0;

            try
            {
                using (FileStream fs = File.Create(path))
                {
                }

                using (StreamReader sr = File.OpenText(route))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (countLine == lineNumber)
                            {
                                string[] incertarNuevo = line.Split(',');
                                incertarNuevo[incertarNuevo.Length-1] = newStock.ToString();
                                line = "";
                                foreach (string item in incertarNuevo)
                                {
                                    item.Trim();
                                    if (item.CompareTo(newStock.ToString()) == 0)
                                        line += item;
                                    else
                                        line += item + ", ";
                                }
                                sw.WriteLine(line);
                            }
                            else
                            {
                                sw.WriteLine(line);
                            }
                            countLine++;
                        }
                    }
                }
                using (StreamReader sr = File.OpenText(path))
                {
                    using (StreamWriter sw = File.CreateText(route))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                File.Delete(path);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            ReadFiles();
        }
        public static List<Medication> SearcInFile(int lineNumber)
        {
            string route = Storage.Instance.route;
            var line = "";
            int coutLine = 0;
            List<Medication> newMedication = new List<Medication>(); 
            using (FileStream fileStream = new FileStream(route, FileMode.Open))
            {
                using (StreamReader file = new StreamReader(fileStream))
                {
                    while ((line = file.ReadLine()) != null && coutLine <= lineNumber)
                    {
                        if (coutLine == lineNumber)
                        {
                            var values = line.Split(',');
                            values = verificationName(values);
                            var medication = new Medication
                            {
                                Id = int.Parse(values[0]),
                                NameDrug = values[1],
                                Price = double.Parse(values[values.Length - 2].Trim().Trim('$').Replace('.',',')),
                                Stock = int.Parse(values[values.Length - 1])    
                            };
                            newMedication.Add(medication);
                            Storage.Instance.showMedication = newMedication;
                        }
                        coutLine++;
                    }
                }
            }
            return newMedication;
        }
        public static void ReadFiles()
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
                        values = verificationName(values);
                        if (ejecutar)
                        {
                            var indice = new Indice
                            {
                                lineNumber = int.Parse(values[0]),
                                nameDrug = values[1].TrimStart('"').TrimEnd('"')
                            };
                            indice.saveIndice();
                        }
                        ejecutar = true;
                    }
                }
            }
        }

        public static string[] verificationName(string[] values)
        {
            string[] newValues = new string[4];
            int i = 2;
            if (values[1].Contains('"'))
            {
                values[1] += ", ";
                while (!values[i].Contains('"'))
                {
                    values[1] += values[i].Trim() + ", ";
                    values[i] = null;
                    i++;
                }
                values[1] += values[i].Trim();
                values[i] = null;
            }
            newValues[0] = values[0];
            newValues[1] = values[1];
            newValues[2] = values[values.Length -2];
            newValues[3] = values[values.Length -1];
            return newValues;
        }
    }
}