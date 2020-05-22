//-----------------------------------------------------------------------
// <copyright file="Excecoes.cs" company="IPCA">
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
//      Ficheiro da Biblioteca "c2_Validacoes" que contém exceções predefinidas para serem aplicadas
// </desc>
//-----------------------------------------------------------------------

using System;

namespace c2_Validacoes
{
    public class Excecoes : ApplicationException
    {
        public Excecoes() : base("Erro")
        {

        }

        public Excecoes(string g) : base(g) { }

        public Excecoes(string s, Exception e)
        {
            throw new Excecoes("ERRO: " + s + "" + e.Message);
        }
    }
}
