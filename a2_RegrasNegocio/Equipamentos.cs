//-----------------------------------------------------------------------
// <copyright file="Equipamentos.cs" company="IPCA">
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
//      Ficheiro da Biblioteca "a2_RegrasNeogico" que aplica regras aos métodos executados na classe Equipamentos
// </desc>
//-----------------------------------------------------------------------

using a3_DadosClasses;
using c1_ObjetosNegocio;
using c2_Validacoes;
using System;

namespace a2_RegrasNegocio
{
    public class EquRegras
    {

        /// <summary>
        /// Regista um equipamento
        /// </summary>
        /// <param name="e">Equipamento Completo</param>
        /// <returns> e.Codigo se o equipamento for inserido
        /// 0 se não for inserido o equipamento</returns>
        public static int RegistaEquipamento(Equipamento e)
        {
            try
            {
                return Equipamentos.RegistaEquipamento(e);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return 0;
        }

        /// <summary>
        /// Verifica se existe Equipamento através do código
        /// </summary>
        /// <param name="cod">Codigo de equipamento </param>
        /// <returns> True se existir
        /// False se não existir</returns>
        public static bool ExisteEquipamento(int cod)
        {
            try
            {
                return Equipamentos.ExisteEquipamento(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Edita as informações de um equipamento
        /// </summary>
        /// <param name="e">Equipamento Completo </param>
        /// <returns> True se as informações forem editadas corretamente
        /// False se as informações não forem editadas corretamente </returns>
        public static bool EditaEquipamento(Equipamento e)
        {
            try
            {
                return Equipamentos.EditaEquipamento(e);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Adiciona uma nova vulnerabilidade a um equipamento
        /// </summary>
        /// <param name="cod">Codigo de equipamento </param>
        /// <param name="codv">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se for adicionada
        /// False se não for adicionada</returns>
        public static bool AdicionaVulnerabilidadeEquipamento(int cod, int codv)
        {
            try
            {
                return Equipamentos.AdicionaVulnerabilidadeEquipamento(cod, codv);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Apresenta informação dos equipamentos
        /// </summary>
        /// <param name="e">Equipamento Completo </param>
        public static void MostraEquipamentos()
        {
            Equipamentos.MostraEquipamentos();
        }

        /// <summary>
        /// Obtém equipamento completo através do código recebido
        /// </summary>
        /// <param name="cod"></param>
        /// <returns>Devolve equipamento completo</returns>
        public static Equipamento ObterEquipamento(int cod)
        {
            try
            {
                return Equipamentos.ObterEquipamento(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return null;
        }

        /// <summary>
        /// Obtém quantidade de vulnerabilidades num equipamento
        /// </summary>
        /// <param name="cod">Código de equipamento</param>
        /// <returns>Quantidade de vulnerabilidades do equipamento</returns>
        public static int ObterQuantidadeVulnerabilidadesEquipamento(int cod)
        {
            return Equipamentos.ObterQuantidadeVulnerabilidadesEquipamento(cod);
        }

        /// <summary>
        /// Obtém código da vulnerabilidade
        /// </summary>
        /// <param name="cod">Codigo Equipamento</param>
        /// <param name="pos">Posição do código da vulnerabilidade</param>
        /// <returns>Código da vulnerabilidade</returns>
        public static int ObterCodigoVulnerabilidade(int cod, int pos)
        {
            return Equipamentos.ObterCodigoVulnerabilidade(cod, pos);
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Equipamento
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarEquipamentos(string fileName)
        {
            try
            {
                return Equipamentos.GuardarEquipamentos(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Equipamento
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarEquipamentos(string fileName)
        {
            try
            {
                return Equipamentos.CarregarEquipamentos(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x);
            }
            return false;
        }
    }
}
