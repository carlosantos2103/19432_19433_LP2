//-----------------------------------------------------------------------
// <copyright file="Auditoria.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <date> 04/24/2020 </date>
// <time> 15:56 </time>
// <author> Carlos Santos (19432) & Ruben Silva (19433) </author>
//-----------------------------------------------------------------------

using System;

using ClassLibraryColaborador;
using ClassLibraryEquipamento;
using ClassLibraryVulnerabilidade;
using ClassLibraryPessoa;

namespace ClassLibraryAuditoria
{
    public class Auditoria
    {
        #region ESTADO
        int codigo;
        int duracao;
        DateTime dataRegisto;
        int codColab;
        int codEqui;
        #endregion

        #region METODOS

        #region CONSTRUTORES
        //Criação de novos objetos

        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Auditoria()
        {
            this.codigo = -1;
            this.duracao = -1;
            this.dataRegisto = DateTime.Today;
            this.codColab = -1;
            this.codEqui = -1;
        }

        /// <summary>
        /// Construtor com valores vindos do exterior
        /// </summary>
        /// <param codigo="codigo">Codigo da Auditoria </param>
        /// <param duracao="duracao">Duracao da Auditoria</param>
        /// <param dataRegisto="dataRegisto">Data de Registo da Auditoria</param>
        public Auditoria(int codigo, int duracao, DateTime dataRegisto, int codColab, int codEqui)
        {
            this.codigo = codigo;
            this.duracao = duracao;
            this.dataRegisto = dataRegisto;
            this.codColab = codColab;
            this.codEqui = codEqui;
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
        /// Manipula o atributo "duracao"
        /// int duracao;
        /// </summary>
        public int Duracao
        {
            get => duracao;
            set => duracao = value;
        }

        /// <summary>
        /// Manipula o atributo "dataRegisto"
        /// DateTime dataRegisto;
        /// </summary>
        public DateTime DataRegisto
        {
            get { return dataRegisto; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataRegisto = value;
                }
            }
        }

        /// <summary>
        /// Manipula o atributo "codigo Colaborador"
        /// int codColab;
        /// </summary>
        public int CodColab
        {
            get => codColab;
            set => codColab = value;
        }

        /// <summary>
        /// Manipula o atributo "codigo Equipamento"
        /// int codEqui;
        /// </summary>
        public int CodEqui
        {
            get => codEqui;
            set => codEqui = value;
        }

        #endregion

        #endregion
    }

    public class Auditorias
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static Auditoria[] aud;
        static int totalAud=0;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Auditorias()
        {
            aud = new Auditoria[MAX];
        }

        #endregion

        #region FUNCOES

        /// <summary>
        /// Regista uma auditoria
        /// </summary>
        /// <param auditoria="a">Auditoria Completa </param>
        /// <returns> 0 se não houver lugares disponíveis no array
        /// -1 se já existir essa auditoria
        /// 1 se for inserida a auditoria</returns>
        public static int RegistaAuditoria(Auditoria a)
        {
            if (totalAud >= MAX) return 0;
            if (ExisteAuditoria(a.Codigo) == true) return -1;

            aud[totalAud++] = a;

            return 1;
        }

        /// <summary>
        /// Verifica se existe determinada auditoria
        /// </summary>
        /// <param codigo="cod">Codigo de auditoria </param>
        /// <returns> True se existir
        /// False se não existir</returns>
        private static bool ExisteAuditoria(int cod)
        {
            for (int i = 0; i < totalAud; i++)
                if (aud[i].Codigo == cod) return true;
            return false;
        }

        /// <summary>
        /// Apresenta informação de auditoria detalhada
        /// </summary>
        /// <param auditoria="a">Auditoria Completa </param>
        public static void MostraAuditoria(Auditoria a)
        {
            Console.WriteLine("AUDITORIA");
            Console.WriteLine("CODIGO: {0}", a.Codigo);
            Console.WriteLine("DURACAO: {0}", a.Duracao);
            Console.WriteLine("DATA: {0}", a.DataRegisto);
            Console.WriteLine("COLABORADOR:  {0}", a.CodColab);
            Console.WriteLine("EQUIPAMENTOS: {0}", a.CodEqui);
        }


        #endregion

        #endregion
    }
}
