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
//      Ficheiro da Biblioteca "a3_DadosClasses" que manipula os dados relativos à classe equipamentos
// </desc>
//-----------------------------------------------------------------------

using c1_ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace a3_DadosClasses
{
    [Serializable]
    public class Equipamentos
    {
        #region ATRIBUTOS
        private static List<EquipamentoCompleto> equ;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por defeito
        /// </summary>
        static Equipamentos()
        {
            equ = new List<EquipamentoCompleto>();
        }

        #endregion

        #region FUNCOES

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
                EquipamentoCompleto ec = new EquipamentoCompleto(e);
                ec.e.Codigo = (equ.Count) + 1;
                if (ExisteEquipamento(e.Codigo) == true) return 0;
                equ.Add(ec);
                return ec.e.Codigo;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return 0;
            }
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
                foreach (EquipamentoCompleto ec in equ)
                    if (ec.e.Codigo == cod) return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
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
                if (ExisteEquipamento(e.Codigo) == false) return false;
                for (int i = 0; i < equ.Count; i++)
                    if (equ[i].e.Codigo == e.Codigo)
                    {
                        equ[i].e.DataAquisicao = e.DataAquisicao;
                        equ[i].e.Marca = e.Marca;
                        equ[i].e.Modelo = e.Modelo;
                        equ[i].e.Tipo = e.Tipo;
                    }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
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
                foreach (EquipamentoCompleto ec in equ)
                    if (cod == ec.e.Codigo)
                    {
                        ec.codVulns.Add(codv);
                        return true;
                    }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Apresenta informação dos equipamentos
        /// </summary>
        /// <param name="e">Equipamento Completo </param>
        public static void MostraEquipamentos() /* TEM WRITELINES! */
        {
            try
            {
                Console.WriteLine(":{0, -78}:\n:{1, -78}:", "-> Lista de Equipamentos", " ");
                Console.WriteLine(": {0, -7}: {1, -11}: {2,-10}: {3, -10}: {4, -12}: {5, -17}:", "Código", "Data", "Tipo", "Marca", "Modelo", "Vulnerabilidades");
                Console.WriteLine(": {0, -7}: {1, -11}: {2,-10}: {3, -10}: {4, -12}: {5, -17}:", "", "", "", "", "", "");
                foreach (EquipamentoCompleto ec in equ)
                {
                    Console.WriteLine(": {0, -7}: {1, -11}: {2,-10}: {3, -10}: {4, -12}: {5, -17}:", ec.e.Codigo.ToString(), ec.e.DataAquisicao.ToShortDateString(), ec.e.Tipo, ec.e.Marca, ec.e.Modelo, ec.codVulns.Count.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
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
                foreach (EquipamentoCompleto ec in equ)
                    if (ec.e.Codigo == cod)
                        return ec.e;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtém quantidade de vulnerabilidades num equipamento
        /// </summary>
        /// <param name="cod">Código de equipamento</param>
        /// <returns>Quantidade de vulnerabilidades do equipamento</returns>
        public static int ObterQuantidadeVulnerabilidadesEquipamento(int cod)
        {
            try
            {
                foreach (EquipamentoCompleto ec in equ)
                    if (ec.e.Codigo == cod)
                        return ec.codVulns.Count;
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Obtém código da vulnerabilidade
        /// </summary>
        /// <param name="cod">Codigo Equipamento</param>
        /// <param name="pos">Posição do código da vulnerabilidade</param>
        /// <returns>Código da vulnerabilidade</returns>
        public static int ObterCodigoVulnerabilidade(int cod, int pos)
        {
            try
            {
                foreach (EquipamentoCompleto ec in equ)
                    if (ec.e.Codigo == cod)
                        return ec.codVulns[pos];
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Equipamento
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarEquipamentos(string fileName) /* TEM WRITELINES! */
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, equ);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                Console.Write("ERRO:" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.Write("ERRO:" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Equipamento
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarEquipamentos(string fileName)/* TEM WRITELINES! */
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    equ = (List<EquipamentoCompleto>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("ERRO:" + e.Message);
                    return false;
                }
            }
            return false;
        }

        #endregion

        #endregion
    }

    [Serializable]
    /// <summary>
    /// Classe que compõe a classe Equipamento
    /// </summary>
    class EquipamentoCompleto
    {
        #region ATRIBUTOS
        public Equipamento e;
        public List<int> codVulns;
        #endregion

        #region CONSTRUTORES
        /// <summary>
        /// Construtor sem adicionar código de vulnerabilidade
        /// </summary>
        /// <param name="e"> Equipamento sem lista de Códigos</param>
        public EquipamentoCompleto(Equipamento e)
        {
            this.e = e;
            codVulns = new List<int>();
        }

        /// <summary>
        /// Construtor com adição de código de vulnerabilidade
        /// </summary>
        /// <param name="e"> Equipamento sem lista de Códigos</param>
        /// <param name="codV"> Código de Vulnerabilidade</param>
        public EquipamentoCompleto(Equipamento e, int codV)
        {
            this.e = e;
            codVulns = new List<int>();
            codVulns.Add(codV);
        }
        #endregion
    }
}

