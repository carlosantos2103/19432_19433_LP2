//-----------------------------------------------------------------------
// <copyright file="Validacoes.cs" company="IPCA">
//     Copyright. All rights reserved.
// </copyright>
// <date> 05/09/2020 </date>
// <time> 00:45 </time>
// <author> 
//      Carlos Santos (19432)
//      Rúben Silva (19433) 
// </author>
// <email>
//      a19432@alunos.ipca.pt
//      a19433@alunos.ipca.pt
// </email>
// <desc>
//      Ficheiro da Biblioteca "c2_Validacoes" que contém algumas validações a serem usadas.
// </desc>
//-----------------------------------------------------------------------

using System;

namespace c2_Validacoes
{
    public class Validacoes
    {
        /// <summary>
        /// Verifica a validade de leitura de um numero inteiro
        /// </summary>
        /// <returns>Numero Inteiro válido</returns>
        public static int TryCatchInt()
        {
            int x = 0;
            bool verif = false;
            do
            {
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Caracteres Inválidos.\nInsira Novamente > ");
                    continue;
                }
                catch (Exception e)
                {
                    Console.Write("ERRO: " + e.Message);
                    continue;
                }
                verif = true;
            } while (verif == false);

            return x;
        }

        /// <summary>
        /// Verifica a validade de leitura de uam data
        /// </summary>
        /// <returns>Data válida</returns>
        public static DateTime TryCatchDateTime()
        {
            DateTime x = DateTime.Today;
            bool verif = false;
            do
            {
                try
                {
                    x = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Caracteres Inválidos.\nInsira Novamente > ");
                    continue;
                }
                catch (Exception e)
                {
                    Console.Write("ERRO: " + e.Message);
                    continue;
                }
                verif = true;
            } while (verif == false);

            return x;
        }
    }
}
