//-----------------------------------------------------------------------
// <copyright file="Colaboradores.cs" company="IPCA">
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
//      Ficheiro da Biblioteca "a2_RegrasNeogico" que aplica regras aos métodos executados na classe Colaboradores
// </desc>
//-----------------------------------------------------------------------

using a3_DadosClasses;
using c1_ObjetosNegocio;
using c2_Validacoes;
using System;

namespace a2_RegrasNegocio
{
    public class ColRegras
    {
        #region METODOS

        /// <summary>
        /// Regista um Colaborador
        /// </summary>
        /// <param name="c">Colaborador Completo </param>
        /// <returns> false se já existir esse colaborador
        /// true se for inserido o colaborador</returns>
        public static bool RegistaColaborador(Colaborador c)
        {
            try
            {
                return Colaboradores.RegistaColaborador(c);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Edita as informações de um colaborador
        /// </summary>
        /// <param name="c">Colaborador completo </param>
        /// <returns> True se as informações forem editadas corretamente
        /// False se as informações não forem editadas corretamente </returns>
        public static bool EditaColaborador(Colaborador c)
        {
            try
            {
                return Colaboradores.EditaColaborador(c);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Verifica se existe colaborador através do seu código
        /// </summary>
        /// <param name="cod">Codigo do colaborador.</param>
        /// <returns>True se existir colaborador
        /// False se não existir</returns>
        public static bool ExisteColaborador(int cod)
        {
            try
            {
                return Colaboradores.ExisteColaborador(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Procura um colaborador pelo Nif e devolve o seu código
        /// </summary>
        /// <param name="nif">Nif do colaborador.</param>
        /// <returns>c.Codigo se for encontrado o colaborador
        /// 0 se não for encontrado o colaborador</returns>
        public static int PesquisaColaborador(int nif)
        {
            try
            {
                return Colaboradores.PesquisaColaborador(nif);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return 0;
        }

        /// <summary>
        /// Incrementa a quantidade de auditorias de um colaborador
        /// </summary>
        /// <param name="cod">Código do colaborador.</param>
        /// <returns>true se for incrementado corretamente
        /// false se não for encontrado o colaborador</returns>
        public static bool AdicionaAuditoriaColaborador(int cod)
        {
            try
            {
                return Colaboradores.AdicionaAuditoriaColaborador(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Torna um colaborador Inativo
        /// </summary>
        /// <param name="cod">Codigo do colaborador.</param>
        /// <returns>True se tornar um colaborador inativo
        /// False se não tornar um colaborador inativo</returns>
        public static bool TornarColaboradorInativo(int cod)
        {
            try
            {
                return Colaboradores.TornarColaboradorInativo(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Verifica o estado de atividade de um colaborador
        /// </summary>
        /// <param name="cod"> Codigo do colaborador em questão </param>
        /// <returns>True se estiver Ativo
        /// False se estiver Inativo </returns>
        public static bool VerificaAtividade(int cod)
        {
            try
            {
                return Colaboradores.VerificaAtividade(cod);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Apresenta informação dos colaboradores
        /// </summary>
        /// <param name="a">Auditoria Completa </param>
        public static void MostraColaboradores()
        {
            Colaboradores.MostraColaboradores();
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Colaborador
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarColaboradores(string fileName)
        {
            try
            {
                return Colaboradores.GuardarColaboradores(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Colaborador
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarColaboradores(string fileName)
        {
            try
            {
                return Colaboradores.CarregarColaboradores(fileName);
            }
            catch (Excecoes x)
            {
                Console.WriteLine(x.Message);
            }
            return false;
        }
        #endregion
    }
}
