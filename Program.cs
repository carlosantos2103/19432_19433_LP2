using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryAuditoria;
using ClassLibraryColaborador;
using ClassLibraryEquipamento;
using ClassLibraryPessoa;

namespace TESTE
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DADOS DOS INDIVIDUOS 
            // DADOS A INSERIR POR ORDEM NUMA AUDITORIA
            //int codigo, string nome, string sexo, int idade, int nif
            // CODIGO / DURACAO / DATA
            Auditoria teste = new Auditoria(152, 10, DateTime.Today);
            Auditoria teste2 = new Auditoria(56, 25, DateTime.Today);
            Colaborador col1 = new Colaborador(12, "Carlos", "M", 20, 164015);
            Equipamento equ1 = new Equipamento(15, "Portatil", "HP", DateTime.Today);
            Auditorias.RegistaAuditoria(teste, col1, equ1);


            Console.WriteLine("TESTE 1");
            Console.WriteLine("CODIGO: {0}", teste.Codigo);
            Console.WriteLine("DURACAO: {0}", teste.Duracao);
            Console.WriteLine("DATA: {0}", teste.DataRegisto);
            Console.WriteLine("COLABORADOR:  {0}");
            Console.WriteLine("NOME COLAB: {0}"); 

            #endregion
            Console.ReadKey();
        }
    }
}
