//-----------------------------------------------------------------------
// <copyright file="Vulnerabilidades.cs" company="IPCA">
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
//      Ficheiro da Biblioteca "a2_RegrasNeogico" que aplica regras aos métodos executados na classe Vulnerabilidades
// </desc>
//-----------------------------------------------------------------------

using a3_DadosClasses;
using c1_ObjetosNegocio;
using c2_Validacoes;
using System;
using System.Collections.Generic;

namespace a2_RegrasNegocio
{
    public class VulRegras
    {

        /// <summary>
        /// Regista uma vulnerabilidade
        /// </summary>
        /// <param name="v">Vulnerabilidade Completa </param>
        /// <returns> false se já existir essa vulnerabilidade
        /// 1 se for inserida a vulnerabilidade</returns>
        public static int RegistaVulnerabilidade(Vulnerabilidade v)
        {
            try
            {
                return Vulnerabilidades.RegistaVulnerabilidade(v);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return 0;
        }

        /// <summary>
        /// Edita as informações de uma vulnerabilidade
        /// </summary>
        /// <param name="v">Vulnerabilidade completa </param>
        /// <returns> True se as informações forem editadas corretamente
        /// False se as informações não forem editadas corretamente </returns>
        public static bool EditaVulnerabilidade(Vulnerabilidade v)
        {
            try
            {
                return Vulnerabilidades.EditaVulnerabilidade(v);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Lista vuilnerabilidades relativas a auditoria agrupadas por nivel de impacto
        /// </summary>
        /// <param name="lst">Lista de codigos de vulnerabilidades</param>
        public static void ListarVulnerabilidadesImpacto(List<int> lst)
        {
            Vulnerabilidades.ListarVulnerabilidadesImpacto(lst);
        }

        /// <summary>
        /// Lista vuilnerabilidades relativas a equipamento
        /// </summary>
        /// <param name="cod"> Código da vulnerabilidade a listar </param>
        public static void ListarVulnerabilidadeEquipamento(int cod)
        {
            Vulnerabilidades.ListarVulnerabilidadeEquipamento(cod);
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Vulnerabilidade
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarVulnerabilidades(string fileName)
        {
            try
            {
                return Vulnerabilidades.GuardarVulnerabilidades(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Vulnerabilidade
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarVulnerabilidades(string fileName)
        {
            try
            {
                return Vulnerabilidades.CarregarVulnerabilidades(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }
    }
}
