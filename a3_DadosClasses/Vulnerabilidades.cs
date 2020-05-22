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
//      Ficheiro da Biblioteca "a3_DadosClasses" que manipula os dados relativos à classe vulnerabilidades
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
    public class Vulnerabilidades
    {
        #region VARIAVEIS
        private static List<Vulnerabilidade> vul;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Vulnerabilidades()
        {
            vul = new List<Vulnerabilidade>();
        }

        #endregion

        #region FUNCOES

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
                v.Codigo = (vul.Count) + 1;
                if (ExisteVulnerabilidade(v.Codigo) == true) return 0;
                vul.Add(v);
                return v.Codigo;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return 0;
        }

        /// <summary>
        /// Verifica se existe vulnerabilidade
        /// </summary>
        /// <param name="cod">Codigo de vulnerabilidade </param>
        /// <returns> True se existir
        /// False se não existir</returns>
        private static bool ExisteVulnerabilidade(int cod)
        {
            try
            {
                foreach (Vulnerabilidade v in vul)
                    if (v.Codigo == cod) return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
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
                if (ExisteVulnerabilidade(v.Codigo) == false) return false;
                for (int i = 0; i < vul.Count; i++)
                    if (vul[i].Codigo == v.Codigo)
                        vul[i] = v;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Lista vuilnerabilidades de uma auditoria agrupadas por nivel de impacto
        /// </summary>
        /// <param name="lst">Lista de codigos de vulnerabilidades</param>
        public static void ListarVulnerabilidadesImpacto(List<int> lst)/*TEM WRITELINES*/
        {
            try
            {
                Vulnerabilidade aux2;
                List<Vulnerabilidade> aux = new List<Vulnerabilidade>();

                foreach (int i in lst)
                    foreach (Vulnerabilidade v in vul)
                        if (i == v.Codigo)
                        {
                            aux.Add(v);
                        }
                for (int i = 0; i < aux.Count - 1; i++)
                    for (int j = i + 1; j < aux.Count; j++)
                        if (aux[i].Impacto > aux[j].Impacto)
                        {
                            aux2 = aux[i];
                            aux[i] = aux[j];
                            aux[j] = aux2;
                        }
                Console.Write("\nBaixo: ");
                foreach (Vulnerabilidade v in aux)
                    if (v.Impacto == NivelImpacto.BAIXO)
                        Console.Write("{0} | ", v.Codigo);
                Console.Write("\nModerado: ");
                foreach (Vulnerabilidade v in aux)
                    if (v.Impacto == NivelImpacto.MODERADO)
                        Console.Write("{0} | ", v.Codigo);
                Console.Write("\nElevado: ");
                foreach (Vulnerabilidade v in aux)
                    if (v.Impacto == NivelImpacto.BAIXO)
                        Console.WriteLine("{0} | ", v.Codigo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        /// <summary>
        /// Lista vuilnerabilidade relativa a equipamento
        /// </summary>
        /// <param name="cod">Codigo de Vulnerabilidade</param>
        public static void ListarVulnerabilidadeEquipamento(int cod) /*TEM WRITELINES*/
        {
            try
            {
                foreach (Vulnerabilidade v in vul)
                    if (v.Codigo == cod)
                        Console.WriteLine("Vulnerabilidade:\nCódigo: {0}\nEstado: {1}\nImpacto: {2}\n", v.Codigo.ToString(), v.Estado.ToString(), v.Impacto.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Vulnerabilidade
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarVulnerabilidades(string fileName)/* TEM WRITELINES! */
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, vul);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                Console.Write("Erro:" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.Write("Erro:" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Vulnerabilidade
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarVulnerabilidades(string fileName)/* TEM WRITELINES! */
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    vul = (List<Vulnerabilidade>)bin.Deserialize(stream);
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
                    Console.Write("Erro:" + e.Message);
                    return false;
                }
            }
            return false;
        }


        #endregion

        #endregion

    }
}
