//-----------------------------------------------------------------------
// <copyright file="Auditorias.cs" company="IPCA">
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
//      Ficheiro da Biblioteca "a2_RegrasNeogico" que aplica regras aos métodos executados na classe Auditorias
// </desc>
//-----------------------------------------------------------------------


using a3_DadosClasses;
using c1_ObjetosNegocio;
using c2_Validacoes;
using System;

namespace a2_RegrasNegocio
{
    public class AudRegras
    {
        #region METODOS

        /// <summary>
        /// Regista uma auditoria verificando todas as regras e excecoes
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int RegistaAuditoria(Auditoria a)
        {
            try
            {
                return Auditorias.InsereAuditoria(a);
            }
            catch (Excecoes x)
            {
                throw x;
            }
        }

        /// <summary>
        /// Verifica se existe auditoria
        /// </summary>
        /// <param name="cod"></param>
        /// <returns> True se existir
        /// False se não existir</returns>
        public static bool ExisteAuditoria(int cod)
        {
            try
            {
                return Auditorias.ExisteAuditoria(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Obtém a quantidade de auditorias
        /// </summary>
        /// <returns>Devolve a quantidade de auditorias</returns>
        public static int QuantidadeAuditorias()
        {
            try
            {
                return Auditorias.QuantidadeAuditorias();
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return 0;

        }

        /// <summary>
        /// Adiciona uma nova vulnerabilidade a uma auditoria
        /// </summary>
        /// <param name="cod">Codigo de auditoria </param>
        /// <param name="codv">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se for adicionada
        /// False se não for adicionada</returns>
        public static bool AdicionaVulnerabilidadeAuditoria(int cod, int codv)
        {
            try
            {
                return Auditorias.AdicionaVulnerabilidade(cod, codv);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Remove uma nova vulnerabilidade a uma auditoria
        /// </summary>
        /// <param name="cod">Codigo de auditoria </param>
        /// <param name="codv">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se for removida
        /// False se não for removida</returns>
        public static bool RemoveVulnerabilidadeAuditoria(int cod, int codv)
        {
            try
            {
                return Auditorias.RemoveVulnerabilidade(cod, codv);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Edita as informações de uma auditoria
        /// </summary>
        /// <param name="a">Auditoria completa </param>
        /// <returns> True se as informações forem editadas corretamente
        /// False se as informações não forem editadas corretamente </returns>
        public static bool EditaAuditoria(Auditoria a)
        {
            try
            {
                return Auditorias.EditaAuditoria(a);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Apresenta informação de auditoria detalhada
        /// </summary>
        /// <param name="a">Auditoria Completa </param>
        public static void MostraAuditorias()
        {
            Auditorias.MostraAuditorias();
        }

        /// <summary>
        /// Apresenta detalhes sobre as auditorias de um colaborador
        /// </summary>
        /// <param name="codc">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se forem apresentadas auditorias
        /// False se não forem apresentadas auditorias</returns>
        public static bool ApresentaAuditoriasColaborador(int codc)
        {
            try
            {
                return Auditorias.ApresentaAuditoriasColaborador(codc);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Apresenta detalhes sobre as auditorias por ordem decrescente de vulnerabilidades
        /// </summary>
        public static void ApresentaAuditoriasOrdenadasVuln()
        {
            Auditorias.ApresentaAuditoriasOrdenadasVuln();
        }

        /// <summary>
        /// Obtém auditoria completa através do código recebido
        /// </summary>
        /// <param name="cod">Código da auditoria</param>
        /// <returns>Devolve auditoria completa</returns>
        public static Auditoria ObterAuditoria(int cod)
        {
            try
            {
                if (Auditorias.ObterAuditoria(cod) == null)
                    Console.WriteLine("\n ERRO! ");
                return Auditorias.ObterAuditoria(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return null;
        }

        /// <summary>
        /// Obtém quantidade de vulnerabilidades em uma auditoria
        /// </summary>
        /// <param name="cod">Código de auditoria</param>
        /// <returns>Quantidade de vulnerabilidades da auditoria</returns>
        public static int ObterQuantidadeVulnerabilidadesAuditoria(int cod)
        {
            return Auditorias.ObterQuantidadeVulnerabilidadesAuditoria(cod);
        }

        /// <summary>
        /// Obtem a auditoria que tem mais vulnerabilidades registadas
        /// </summary>
        /// <returns>Auditoria com mais vulnerabilidades</returns>
        public static Auditoria ObterAuditoriaMaisVuln()
        {
            try
            {
                return Auditorias.ObterAuditoriaMaisVuln();
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return null;
        }

        /// <summary>
        /// Obtem a auditoria que tem menos vulnerabilidades registadas
        /// </summary>
        /// <returns>Auditoria com menos vulnerabilidades</returns>
        public static Auditoria ObterAuditoriaMenosVuln()
        {
            try
            {
                return Auditorias.ObterAuditoriaMenosVuln();
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return null;
        }

        /// <summary>
        /// Obtem a média de vulnerabilidades registadas nas auditorias
        /// </summary>
        /// <returns>Media de vulnerabilidades registadas</returns>
        public static float ObtemMediaVulns()
        {
            try
            {
                return Auditorias.ObtemMediaVulns();
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return 0;
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Auditoria
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarAuditorias(string fileName)
        {
            try
            {
                return Auditorias.GuardarAuditorias(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Auditoria
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarAuditorias(string fileName)
        {
            try
            {
                return Auditorias.CarregarAuditorias(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }


        #endregion
    }
}
