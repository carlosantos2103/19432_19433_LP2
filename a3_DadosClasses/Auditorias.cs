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
//      Ficheiro da Biblioteca "a3_DadosClasses" que manipula os dados relativos à classe auditorias
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
    public class Auditorias
    {
        #region ATRIBUTOS
        private static List<AuditoriaCompleta> aud;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Auditorias()
        {
            aud = new List<AuditoriaCompleta>();
        }

        #endregion

        #region FUNCOES

        /// <summary>
        /// Regista uma auditoria
        /// </summary>
        /// <param name="a">Auditoria Completa </param>
        /// <returns> a.Codigo se a auditoria for inserida
        /// 0 se não for inserida a auditoria</returns>
        public static int InsereAuditoria(Auditoria a)
        {
            try
            {
                AuditoriaCompleta ac = new AuditoriaCompleta(a);
                ac.a.Codigo = (aud.Count) + 1;
                if (ExisteAuditoria(a.Codigo) == true) return 0;
                aud.Add(ac);
                return ac.a.Codigo;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Verifica se existe determinada auditoria
        /// </summary>
        /// <param name="cod">Codigo de auditoria </param>
        /// <returns> True se existir
        /// False se não existir</returns>
        public static bool ExisteAuditoria(int cod)
        {
            try
            {
                foreach (AuditoriaCompleta ac in aud)
                    if (ac.a.Codigo == cod) return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Obtém a quantidade de auditorias
        /// </summary>
        /// <returns>Devolve a quantidade de auditorias</returns>
        public static int QuantidadeAuditorias()
        {
            try
            {
                return aud.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Adiciona uma nova vulnerabilidade a uma auditoria
        /// </summary>
        /// <param name="cod">Codigo de auditoria </param>
        /// <param name="codv">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se for adicionada
        /// False se não for adicionada</returns>
        public static bool AdicionaVulnerabilidade(int cod, int codv)
        {
            try
            {
                foreach (AuditoriaCompleta ac in aud)
                    if (cod == ac.a.Codigo)
                    {
                        ac.codVulns.Add(codv);
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
        /// Remove uma nova vulnerabilidade a uma auditoria
        /// </summary>
        /// <param name="cod">Codigo de auditoria </param>
        /// <param name="codv">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se for removida
        /// False se não for removida</returns>
        public static bool RemoveVulnerabilidade(int cod, int codv)
        {
            try
            {
                foreach (AuditoriaCompleta ac in aud)
                    if (cod == ac.a.Codigo)
                    {
                        ac.codVulns.Remove(codv);
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
        /// Edita as informações de uma auditoria
        /// </summary>
        /// <param name="a">Auditoria completa </param>
        /// <returns> True se as informações forem editadas corretamente
        /// False se as informações não forem editadas corretamente </returns>
        public static bool EditaAuditoria(Auditoria a)
        {
            try
            {
                if (ExisteAuditoria(a.Codigo) == false) return false;
                for (int i = 0; i < aud.Count; i++)
                    if (aud[i].a.Codigo == a.Codigo)
                    {
                        aud[i].a.DataRegisto = a.DataRegisto;
                        aud[i].a.Duracao = a.Duracao;
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
        /// Apresenta informação de auditoria detalhada
        /// </summary>
        /// <param name="a">Auditoria Completa </param>
        public static void MostraAuditorias()/* TEM WRITELINES! */
        {
            try
            {
                Console.WriteLine(":{0, -78}:\n:{1, -78}:", "-> Lista de Auditorias", " ");
                Console.WriteLine(": {0, -7}: {1, -11}: {2,-8}: {3, -12}: {4, -12}: {5, -17}:", "Código", "Data", "Duração", "Colaborador", "Equipamento", "Vulnerabilidades");
                Console.WriteLine(": {0, -7}: {1, -11}: {2,-8}: {3, -12}: {4, -12}: {5, -17}:", "", "", "", "", "", "");
                foreach (AuditoriaCompleta ac in aud)
                    Console.WriteLine(": {0, -7}: {1, -11}: {2,-3} min : {3, -12}: {4, -12}: {5, -17}:", ac.a.Codigo.ToString(), ac.a.DataRegisto.ToShortDateString(), ac.a.Duracao.ToString(), ac.a.CodColab.ToString(), ac.a.CodEqui.ToString(), ac.codVulns.Count.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        /// <summary>
        /// Apresenta detalhes sobre as auditorias de um colaborador
        /// </summary>
        /// <param name="codc">Codigo da Vulnerabilidade a adicionar </param>
        /// <returns> True se forem apresentadas auditorias
        /// False se não forem apresentadas auditorias</returns>
        public static bool ApresentaAuditoriasColaborador(int codc)/* TEM WRITELINES! */
        {
            try
            {
                bool x = false;
                Console.WriteLine(" Auditorias por Colaborador:");
                Console.WriteLine(" Codigo Colaborador: {0}\n", codc.ToString());
                for (int i = 0; i < aud.Count; i++)
                {
                    if (aud[i].a.CodColab == codc)
                    {
                        Console.WriteLine("Auditoria {0}:", i + 1);
                        Console.WriteLine("Codigo: {0}", aud[i].a.Codigo.ToString());
                        Console.WriteLine("Data: {0}", aud[i].a.DataRegisto.ToShortDateString());
                        Console.WriteLine("Quantidade Vulnerabilidades: {0}", aud[i].codVulns.Count.ToString());
                        x = true;
                    }
                    if (i == (aud.Count - 1) && x == false)
                    {
                        Console.WriteLine("O colaborador não tem Auditorias registadas.");
                        return false;
                    }
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
        /// Apresenta detalhes sobre as auditorias por ordem decrescente de vulnerabilidades
        /// </summary>
        public static void ApresentaAuditoriasOrdenadasVuln()
        {
            try
            {
                List<AuditoriaCompleta> aux = new List<AuditoriaCompleta>();
                AuditoriaCompleta x;
                aux = aud;
                for (int i = 0; i < aux.Count - 1; i++)
                {
                    for (int j = i + 1; i < aux.Count; i++)
                    {
                        if (aux[i].codVulns.Count < aux[j].codVulns.Count)
                        {
                            x = aux[i];
                            aux[i] = aux[j];
                            aux[j] = x;
                        }
                    }
                }
                Console.WriteLine(":{0, -78}:\n:{1, -78}:", "-> Lista de Auditorias por Ordem Decrescente de Vulnerabilidades", " ");
                Console.WriteLine(": {0, -7}: {1, -11}: {2,-8}: {3, -12}: {4, -12}: {5, -17}:", "Código", "Data", "Duração", "Colaborador", "Equipamento", "Vulnerabilidades");
                Console.WriteLine(": {0, -7}: {1, -11}: {2,-8}: {3, -12}: {4, -12}: {5, -17}:", "", "", "", "", "", "");
                foreach (AuditoriaCompleta ac in aux)
                    Console.WriteLine(": {0, -7}: {1, -11}: {2,-3} min : {3, -12}: {4, -12}: {5, -17}:", ac.a.Codigo.ToString(), ac.a.DataRegisto.ToShortDateString(), ac.a.Duracao.ToString(), ac.a.CodColab.ToString(), ac.a.CodEqui.ToString(), ac.codVulns.Count.ToString());
            }
            catch (Exception x)
            {
                Console.WriteLine("Erro: " + x.Message);
            }
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
                foreach (AuditoriaCompleta ac in aud)
                    if (ac.a.Codigo == cod)
                        return ac.a;
                return null;
            }
            catch (Exception x)
            {
                Console.WriteLine("Erro: " + x.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtém quantidade de vulnerabilidades em uma auditoria
        /// </summary>
        /// <param name="cod">Código de auditoria</param>
        /// <returns>Quantidade de vulnerabilidades da auditoria</returns>
        public static int ObterQuantidadeVulnerabilidadesAuditoria(int cod)
        {
            try
            {
                foreach (AuditoriaCompleta ac in aud)
                    if (ac.a.Codigo == cod)
                        return ac.codVulns.Count;
                return 0;
            }
            catch (Exception x)
            {
                Console.WriteLine("Erro: " + x.Message);
                return 0;
            }
        }

        /// <summary>
        /// Obtem a auditoria que tem mais vulnerabilidades registadas
        /// </summary>
        /// <returns>Auditoria com mais vulnerabilidades</returns>
        public static Auditoria ObterAuditoriaMaisVuln()
        {
            try
            {
                int maior = 0;
                Auditoria audmaior = new Auditoria();
                for (int i = 0; i < aud.Count; i++)
                    if (aud[i].codVulns.Count >= maior)
                    {
                        audmaior = aud[i].a;
                        maior = aud[i].codVulns.Count;
                    }
                return audmaior;
            }
            catch (Exception x)
            {
                Console.WriteLine("Erro: " + x.Message);
                return null;
            }

        }

        /// <summary>
        /// Obtem a auditoria que tem menos vulnerabilidades registadas
        /// </summary>
        /// <returns>Auditoria com menos vulnerabilidades</returns>
        public static Auditoria ObterAuditoriaMenosVuln()
        {
            try
            {
                int menor = 9999999;
                Auditoria audmenor = new Auditoria();
                for (int i = 0; i < aud.Count; i++)
                    if (aud[i].codVulns.Count <= menor)
                        audmenor = aud[i].a;
                return audmenor;
            }
            catch (Exception x)
            {
                Console.WriteLine("Erro: " + x.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtem a média de vulnerabilidades registadas nas auditorias
        /// </summary>
        /// <returns>Media de vulnerabilidades registadas</returns>
        public static float ObtemMediaVulns()
        {
            try
            {
                int soma = 0;
                foreach (AuditoriaCompleta ac in aud)
                    soma += ac.codVulns.Count;
                return soma / (float)aud.Count;
            }
            catch (Exception x)
            {
                Console.WriteLine("Erro: " + x.Message);
                return 0;
            }
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Auditoria
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarAuditorias(string fileName)
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, aud);
                stream.Close();
                return true;
            }
            catch (IOException x)
            {
                Console.Write("ERRO:" + x.Message);
                return false;
            }
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Auditoria
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarAuditorias(string fileName)/* TEM WRITELINES! */
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    aud = (List<AuditoriaCompleta>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (IOException x)
                {
                    Console.Write("ERRO:" + x.Message);
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
    /// Classe que compõe a classe Auditoria
    /// </summary>
    class AuditoriaCompleta
    {
        #region ATRIBUTOS
        public Auditoria a;
        public List<int> codVulns;
        #endregion

        #region CONSTRUTORES
        /// <summary>
        /// Construtores
        /// </summary>
        /// <param name="a">Auditoria</param>
        public AuditoriaCompleta(Auditoria a)
        {
            this.a = a;
            codVulns = new List<int>();
        }

        public AuditoriaCompleta(Auditoria a, int codV)
        {
            this.a = a;
            codVulns = new List<int>();
            codVulns.Add(codV);
        }
        #endregion
    }
}
