using System;

namespace ClassLibraryVulnerabilidade
{
    enum NIVELIMPACTO
    {
        BAIXO=0,
        MODERADO=1,
        ELEVADO=2
    }
    public class Vulnerabilidade
    {
        #region ESTADO
        int codigo;
        string descricao;
        int nivelImpacto;
        #endregion

        #region METODOS

        #region CONSTRUTORES
        //Criação de novos objetos

        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Vulnerabilidade()
        {
            this.codigo = -1;
            this.descricao = "";
            this.nivelImpacto = -1;
        }

        /// <summary>
        /// Construtor com valores vindos do exterior
        /// </summary>
        /// <param codigo="codigo">Código da Vulnerabilidade</param>
        /// <param descricao="descricao">Descrição da Vulnerabilidade</param>
        /// <param nivelImpacto="nivelImpacto">Nivel de Imapcto da Vulnerabilidade</param>
        public Vulnerabilidade(int codigo, string descricao, int nivelImpacto)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.nivelImpacto = nivelImpacto;
        }

        #endregion

        #region PROPRIEDADES
        // Manipular os atributos do Estado

        /// <summary>
        /// Manipula o atributo "codigo"
        /// int codigo;
        /// </summary>
        public int Codigo
        {
            get => codigo;
            set => codigo = value;
        }

        /// <summary>
        /// Manipula o atributo "nome"
        /// string nome;
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        /// <summary>
        /// Manipula o atributo "nivelImpacto"
        /// int codigo;
        /// </summary>
        public int NivelImpacto
        {
            get => nivelImpacto;
            set => nivelImpacto = value;
        }


        #endregion

        #endregion
    }

    public class Vulnerabilidades
    {
        #region VARIAVEIS
        const int MAX = 100;
        public string vulnerabilidades;
        Vulnerabilidade[] vul;
        int totalVul;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Vulnerabilidades()
        {
            vul = new Vulnerabilidade[MAX];
        }

        #endregion

        #region PROPRIEDADES

        #region FUNCOES
        public bool RegistaVulnerabilidade(Vulnerabilidade v)
        {
            //Validar;
            vul[totalVul++] = v;
            return true;
        }

        public bool ExisteVulnerabilidade(int cod)
        {
            //procurar;
            return true;
        }


        #endregion

        #endregion
    }
}
