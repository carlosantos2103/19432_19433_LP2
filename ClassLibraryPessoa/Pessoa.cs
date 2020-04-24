//-----------------------------------------------------------------------
// <copyright file="Pessoa.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <date> 04/24/2020 </date>
// <time> 15:56 </time>
// <author> Carlos Santos (19432) & Ruben Silva (19433) </author>
//-----------------------------------------------------------------------

namespace ClassLibraryPessoa
{
    public class Pessoa
    {
        #region ESTADO

        string sexo;
        string nome;
        int idade;
        int nif;

        #endregion

        #region PROPRIEDADES

        //Métodos usados para manipular atributos do Estado

        /// <summary>
        /// Manipula o atributo "sexo"
        /// string sexo;
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        /// <summary>
        /// Manipula o atributo "nome"
        /// string nome;
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Manipula o atributo "nif"
        /// int nif;
        /// </summary>
        public int Nif
        {
            set { nif = value; }
            get { return nif; }
        }

        /// <summary>
        /// Manipula o atributo "idade"
        /// int idade;
        /// </summary>
        public int Idade
        {
            get => idade;
            set
            {
                if (value <= 0)
                {
                    idade = -1;
                }
                else
                {
                    idade = value;
                }
            }
        }
        #endregion

        #region METODOS

        #region CONSTRUTORES
        //Métodos usados na criação de novos objectos

        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Pessoa()
        {
            this.nif = -1;
            this.idade = -1;
            this.nome = "";
            this.sexo = "";
        }

        /// <summary>
        /// Construtor com dados vindos do exterior
        /// </summary>
        /// <param nome="nome">Nome da Pessoa</param>
        /// <param sexo="sexo">Sexo da Pessoa</param>
        /// <param nif="nif">Nif da Pessoa</param>
        /// <param idade="idade">Idade da Pessoa</param>
        public Pessoa(string nome, string sexo, int idade, int nif)
        {
            this.nome = nome;
            this.sexo = sexo;
            this.idade = idade;
            this.nif = nif;
        }

        #endregion

        #endregion

    }

    public class Pessoas
    {
        #region ATRIBUTOS

        const int MAX = 100;
        static Pessoa[] pes;
        static int totalPes = 0;

        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// Construtor de classe
        /// </summary>
        static Pessoas()
        {
            pes = new Pessoa[MAX];
        }
        #endregion

        #region FUNCOES

        /// <summary>
        /// Verifica se exeiste determinada pessoa
        /// </summary>
        /// <param nif="nif">Nif da Pessoa</param>
        /// <returns> True se existir
        /// False se não existir</returns>
        private static bool ExistePessoa(int nif)
        {
            for (int i = 0; i < totalPes; i++)
            {
                // Caso seja essa Pessoa
                if (pes[i].Nif.CompareTo(nif) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Regista uma pessoa
        /// </summary>
        /// <param pessoa="p"></param>
        /// <returns> 0 se não houver lugares disponíveis no array
        /// -1 se já existir essa pessoa
        /// 1 se for inserida a pessoa</returns>
        public static int RegistaPessoa(Pessoa p)
        {
            if (totalPes >= MAX) return 0;
            if (ExistePessoa(p.Nif)) return -1;

            pes[totalPes++] = p;
            return 1;
        }

        #endregion

        #endregion


    }
}
