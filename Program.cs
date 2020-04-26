//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <date> 04/24/2020 </date>
// <time> 15:56 </time>
// <author> Carlos Santos (19432) & Rúben Silva (19433) </author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryAuditoria;
using ClassLibraryColaborador;
using ClassLibraryEquipamento;
using ClassLibraryVulnerabilidade;
using ClassLibraryPessoa;

namespace TESTE
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DADOS TESTE 

            // DADOS A INSERIR POR ORDEM NUMA AUDITORIA
            // CODIGO / DURACAO / DATA

            //int codigo, string nome, string sexo, int idade, int nif

            Colaborador col1 = new Colaborador(12, "Carlos", "M", 20, 164015);
            Equipamento equ1 = new Equipamento(15, "Portatil", "HP", DateTime.Today);

            Vulnerabilidade vul1 = new Vulnerabilidade(5, "Falha no sistema", NivelImpacto.ELEVADO);
            Console.WriteLine("VULNERABILIDADE:");
            Console.WriteLine("Codigo:" + vul1.Codigo);
            Console.WriteLine("Descrição: " + vul1.Descricao);
            Console.WriteLine("Nível de Impacto: " + vul1.Impacto);
            Console.WriteLine("");

            Auditoria teste = new Auditoria(152, 10, DateTime.Today, col1.Codigo, equ1.Codigo);
            Auditoria teste2 = new Auditoria(56, 25, DateTime.Today, col1.Codigo, equ1.Codigo);

            Auditorias.RegistaAuditoria(teste);
            Auditorias.RegistaAuditoria(teste2);

            Auditorias.MostraAuditoria(teste);

            #endregion
            Console.ReadKey();
        }
    }
}
