//-----------------------------------------------------------------------
// <copyright file="Colaborador.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <date> 04/24/2020 </date>
// <time> 15:56 </time>
// <author> Carlos Santos (19432) & Ruben Silva (19433) </author>
//-----------------------------------------------------------------------

using System;

using ClassLibraryPessoa;

namespace ClassLibraryColaborador
{
    public class Colaborador : Pessoa
    {
        #region ESTADO
        int codigo;
        #endregion

        #region METODOS

        #region CONSTRUTORES
        //Criação de novos objetos

        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Colaborador() : base()
        {
            this.codigo = -1;
        }

        /// <summary>
        /// Construtor com valores vindos do exterior
        /// </summary>
        /// <param codigo="codigo">Codigo do Colaborador </param>
        /// <param nome="nome">Nome do Colaborador </param>
        /// <param sexo="sexo">Sexo do Colaborador </param>
        /// <param idade="idade">Idade do Colaborador </param>
        /// <param nif="nif">Nif do Colaborador </param>
        public Colaborador(int codigo, string nome, string sexo, int idade, int nif) : base(nome, sexo, idade, nif)
        {
            this.codigo = codigo;
            base.Nome = nome;
            base.Sexo = sexo;
            base.Idade = idade;
            base.Nif = nif;
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

        #endregion

        #endregion
    }

    public class Colaboradores : Pessoa
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static Colaborador[] col;
        static int totalCol=0;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Colaboradores()
        {
            col = new Colaborador[MAX];
        }

        #endregion

        #region FUNCOES

        /// <summary>
        /// Regista um Colaborador
        /// </summary>
        /// <param colaborador="c">Colaborador Completo </param>
        /// <returns> 0 se não houver lugares disponíveis no array
        /// -1 se já existir esse colaborador
        /// 1 se for inserido o colaborador</returns>
        public static int RegistaColaborador(Colaborador c)
        {
            if (totalCol >= MAX) return 0;
            if (ExisteColaborador(c.Codigo) == true) return -1;

            col[totalCol++] = c;
            return 1;
        }

        /// <summary>
        /// Verifica se existe colaborador
        /// </summary>
        /// <param codigo="cod">Codigo do colaborador.</param>
        /// <returns>True se existir colaborador
        /// False se não existir</returns>
        private static bool ExisteColaborador(int cod)
        {
            for (int i = 0; i < totalCol; i++)
                if (col[i].Codigo == cod) return true;
            return false;
        }


        #endregion

        #endregion
    }
}
