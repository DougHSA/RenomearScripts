using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RenomearScriptsBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string sourcePath = @"..\CRIAÇÃO DO BANCO\LADO BRUNSKER\PKG'S";

            string targetPath = sourcePath + @"\Script\ScriptCompleto.txt";

            Console.WriteLine("Digite o banco do Cliente: (Exemplo: BSGLA)");
            string bancoCliente = Console.ReadLine().ToUpper();
            FileInfo criadoEm;
            try
            {
                Directory.CreateDirectory(sourcePath + @"\Script");
                var arquivosExistentes = Directory.EnumerateFiles(sourcePath + @"\Script","*.txt");
                if (arquivosExistentes !=null)
                    File.Delete(targetPath);
                
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    
                    var files = Directory.EnumerateFiles(sourcePath, "*.txt");
                    foreach (var file in files)
                    {
                        string[] lines = lines = File.ReadAllLines(file);

                        foreach (string line in lines)
                        {
                            sw.WriteLine(line.Replace("BSGLA", bancoCliente));
                        }
                    }
                    criadoEm = new FileInfo(targetPath);
                }
                Console.WriteLine($"Arquivo gerado em {criadoEm.FullName}");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
