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

        #region OVERRIDES

        //public override bool Equals(Object obj)
        //{
        //    return (this.nome == ((Pessoa)obj).nome);
        //}

        //public override string ToString()
        //{
        //    return string.Format("Nome= {0} - Idade= {1}", Nome, Idade);
        //}
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
        /// Verifica se determinada pessoa existe
        /// </summary>
        /// <param nif="nif">Nif da Pessoa</param>
        /// <returns></returns>
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
        /// Regista uma nova pessoa
        /// </summary>
        /// <param name="p"></param>
        public static int InserePessoa(Pessoa p)
        {
            //Testar se está cheio
            if (totalPes >= MAX) return 0;
            //testar se já existe; 
            if (ExistePessoa(p.Nif)) return 0;
            //ou
            //if (totPessoas >= MAX || GetPessoa(p.Idade) != null) return 0;

            pes[totalPes++] = p;
            return 1;
        }

        ///// <summary>
        ///// Tenta registar nova pessoa e devolve o resultado da operação
        ///// </summary>
        ///// <param name="p">Nova pessoa</param>
        ///// <returns>Estado da Operação</returns>
        //public static int InserePessoaRes(Pessoa p)
        //{
        //    //Testar se está cheio
        //    if (totalPes >= MAX) return 0;
        //    //testar se já existe; 
        //    if (ExistePessoa(p.Nif)) return 0;

        //    pes[totalPes++] = p;
        //    return 1;
        //}

        ///// <summary>
        ///// Procura a ficha de determinada pessoa ...
        ///// </summary>
        ///// <param name="id">Nome da pessoa</param>
        //public static Pessoa GetPessoa(int i)
        //{
        //    for (int i = 0; i < totalPes; i++)
        //    {
        //        // Caso seja essa Pessoa
        //        if (pes[i].Idade == i) return pes[i];
        //    }
        //    return null;
        //}

        /// <summary>
        /// Verifica se uma pessoa existe. Se existir devolve a Ficha da Pessoa
        /// </summary>
        /// <param name="nome">Nome da Pessoa</param>
        /// <returns>Ficha da Pessoa caso exista; NULL caso nao exista</returns>
        //public static Pessoa WhereIs(string nome)
        //{
        //    for (int i = 0; i < numPess; i++)
        //    {
        //        // Caso seja essa Pessoa
        //        if (pess[i].Nome.CompareTo(nome) == 0)
        //        {
        //            return pess[i];
        //        }
        //    }
        //    return null;
        //}

        #endregion

        #endregion


    }
}
