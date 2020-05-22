﻿//-----------------------------------------------------------------------
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
//      Ficheiro da Biblioteca "a3_DadosClasses" que manipula os dados relativos à classe colaboradores
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
    public class Colaboradores : Pessoa
    {
        #region ATRIBUTOS
        private static List<Colaborador> col;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por defeito.
        /// </summary>
        static Colaboradores()
        {
            col = new List<Colaborador>();
        }

        #endregion

        #region FUNCOES

        /// <summary>
        /// Regista um Colaborador
        /// </summary>
        /// <param name="c">Colaborador Completo </param>
        /// <returns> false se já existir esse colaborador
        /// true se for inserido o colaborador</returns>
        public static bool RegistaColaborador(Colaborador c)
        {
            if (PesquisaColaborador(c.Nif) != 0) return false;
            c.Codigo = (col.Count) + 1;
            col.Add(c);
            return true;
        }

        /// <summary>
        /// Edita as informações de um colaborador
        /// </summary>
        /// <param name="c">Colaborador completo </param>
        /// <returns> True se as informações forem editadas corretamente
        /// False se as informações não forem editadas corretamente </returns>
        public static bool EditaColaborador(Colaborador c)
        {
            if (ExisteColaborador(c.Codigo) == false) return false;
            for (int i = 0; i < col.Count; i++)
                if (col[i].Codigo == c.Codigo)
                {
                    col[i].Genero = c.Genero;
                    col[i].Idade = c.Idade;
                    col[i].Nome = c.Nome;
                    col[i].Nif = c.Nif;
                }
            return true;
        }

        /// <summary>
        /// Verifica se existe colaborador através do seu código
        /// </summary>
        /// <param name="cod">Codigo do colaborador.</param>
        /// <returns>True se existir colaborador
        /// False se não existir</returns>
        public static bool ExisteColaborador(int cod)
        {
            foreach (Colaborador c in col)
                if (c.Codigo == cod) return true;
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
            foreach (Colaborador c in col)
                if (c.Nif == nif) return c.Codigo;
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
            if (ExisteColaborador(cod) == false) return false;
            for (int i = 0; i < col.Count; i++)
                if (col[i].Codigo == cod)
                    col[i].QuantAuds++;
            return true;
        }

        /// <summary>
        /// Torna um colaborador Inativo
        /// </summary>
        /// <param name="cod">Codigo do colaborador.</param>
        /// <returns>True se tornar um colaborador inativo
        /// False se não tornar um colaborador inativo</returns>
        public static bool TornarColaboradorInativo(int cod)
        {
            foreach (Colaborador c in col)
                if (c.Codigo == cod && c.Atividade == Atividade.ATIVO)
                {
                    c.Atividade = Atividade.INATIVO;
                    return true;
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
            foreach (Colaborador c in col)
                if (c.Codigo == cod)
                    if (c.Atividade == Atividade.ATIVO) return true;
            return false;
        }

        /// <summary>
        /// Apresenta informação dos colaboradores
        /// </summary>
        public static void MostraColaboradores()/* TEM WRITELINES! */
        {
            Console.WriteLine(":{0, -78}:\n:{1, -78}:", "-> Lista de Colaboradores", " ");
            Console.WriteLine(": {0, -7}: {1, -13}: {2,-10}: {3, -7}: {4, -6}: {5, -11}: {6, -11}:", "Código", "Nome", "Nif", "Idade", "Sexo", "Atividade", "Auditorias");
            Console.WriteLine(": {0, -7}: {1, -13}: {2,-10}: {3, -7}: {4, -6}: {5, -11}: {6, -11}:", "", "", "", "", "", "", "");
            foreach (Colaborador c in col)
            {
                Console.WriteLine(": {0, -7}: {1, -13}: {2,-10}: {3, -7}: {4, -6}: {5, -11}: {6, -11}:", c.Codigo.ToString(), c.Nome, c.Nif.ToString(), c.Idade.ToString(), c.Genero.ToString(), c.Atividade.ToString(), c.QuantAuds.ToString());
            }
        }

        /// <summary>
        /// Guarda em ficheiro binário a informação relativa à classe Colaborador
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool GuardarColaboradores(string fileName)/* TEM WRITELINES! */
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, col);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                Console.Write("ERRO:" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Carrega o ficheiro binário com a informação relativa à classe Colaborador
        /// </summary>
        /// <param name="fileName">Diretório do ficheiro</param>
        public static bool CarregarColaboradores(string fileName)/* TEM WRITELINES! */
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    col = (List<Colaborador>)bin.Deserialize(stream);
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
}
