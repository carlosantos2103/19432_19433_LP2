//-----------------------------------------------------------------------
// <copyright file="Vulnerabilidade.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <date> 04/24/2020 </date>
// <time> 15:56 </time>
// <author> Carlos Santos (19432) & Ruben Silva (19433) </author>
//-----------------------------------------------------------------------

using System;

namespace ClassLibraryVulnerabilidade
{

    #region ENUMS
    public enum NivelImpacto
    {
        BAIXO,
        MODERADO,
        ELEVADO
    }
    #endregion

    public class Vulnerabilidade
    {
        #region ESTADO
        int codigo;
        string descricao;
        NivelImpacto impacto;
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
            this.impacto = 0;
        }

        /// <summary>
        /// Construtor com valores vindos do exterior
        /// </summary>
        /// <param codigo="codigo">Código da Vulnerabilidade</param>
        /// <param descricao="descricao">Descrição da Vulnerabilidade</param>
        /// <param impacto="impacto">Nivel de Imapcto da Vulnerabilidade</param>
        public Vulnerabilidade(int codigo, string descricao, NivelImpacto impacto)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.impacto = impacto;
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
        /// Manipula o atributo "impacto"
        /// NivelImpacto impacto;
        /// </summary>
        public NivelImpacto Impacto
        {
            get => impacto;
            set => impacto = value;
        }


        #endregion

        #endregion
    }

    public class Vulnerabilidades
    {
        #region VARIAVEIS
        const int MAX = 100;
        static Vulnerabilidade[] vul;
        static int totalVul;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Vulnerabilidades()
        {
            vul = new Vulnerabilidade[MAX];
        }

        #endregion

        #region FUNCOES

        /// <summary>
        /// Regista uma vulnerabilidade
        /// </summary>
        /// <param Vulnerabilidade="v">Vulnerabilidade Completa </param>
        /// <returns> 0 se não houver lugares disponíveis no array
        /// -1 se já existir essa vulnerabilidade
        /// 1 se for inserida a vulnerabilidade</returns>
        public static int RegistaVulnerabilidade(Vulnerabilidade v)
        {
            if (totalVul >= MAX) return 0;
            if (ExisteVulnerabilidade(v.Codigo) == true) return -1;

            vul[totalVul++] = v;

            return 1;
        }

        /// <summary>
        /// Verifica se existe vulnerabilidade
        /// </summary>
        /// <param codigo="cod">Codigo de vulnerabilidade </param>
        /// <returns> True se existir
        /// False se não existir</returns>
        private static bool ExisteVulnerabilidade(int cod)
        {
            for (int i = 0; i < totalVul; i++)
                if (vul[i].Codigo == cod) return true;
            return true;
        }


        #endregion

        #endregion

    }
}
