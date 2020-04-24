//-----------------------------------------------------------------------
// <copyright file="Equipamento.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <date> 04/24/2020 </date>
// <time> 15:56 </time>
// <author> Carlos Santos (19432) & Ruben Silva (19433) </author>
//-----------------------------------------------------------------------

using System;

using ClassLibraryVulnerabilidade;

namespace ClassLibraryEquipamento
{
    public class Equipamento
    {
        #region ESTADO
        int codigo;
        string tipo;
        string modelo;
        DateTime dataAquisicao;
        int codVuln;

        #endregion

        #region METODOS

        #region CONSTRUTORES
        //Criação de novos objetos

        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Equipamento()
        {
            this.codigo = -1;
            this.tipo = "";
            this.modelo = "";
            this.dataAquisicao = DateTime.Today;
            this.codVuln = -1;
        }

        /// <summary>
        /// Construtor com valores vindos do exterior
        /// </summary>
        /// <param codigo="codigo">Codigo do Equipamento </param>
        /// <param tipo="tipo">Tipo do Equipamento</param>
        /// <param modelo="modelo">Modelo do Equipamento</param>
        /// <param dataAquisicao="dataAquisicao">Data de aquisição do Equipamento</param>
        public Equipamento(int codigo, string tipo, string modelo, DateTime dataAquisicao)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.modelo = modelo;
            this.dataAquisicao = dataAquisicao;
            this.codVuln = -1;
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
        /// Manipula o atributo "tipo"
        /// string tipo;
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Manipula o atributo "modelo"
        /// string modelo;
        /// </summary>
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        /// <summary>
        /// Manipula o atributo "dataAquisicao"
        /// DateTime dataAquisicao;
        /// </summary>
        public DateTime DataAquisicao
        {
            get { return dataAquisicao; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataAquisicao = value;
                }
            }
        }

        /// <summary>
        /// Manipula o atributo "codigo Vulnerabilidade"
        /// int codVuln;
        /// </summary>
        public int CodVuln
        {
            get => codVuln;
            set => codVuln = value;
        }

        #endregion

        #endregion
    }

    public class Equipamentos
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static Equipamento[] equ;
        static int totalEqu = 0;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Equipamentos()
        {
            equ = new Equipamento[MAX];
        }

        #endregion

        #region FUNCOES

        /// <summary>
        /// Regista um equipamento
        /// </summary>
        /// <param equipamento="e">Equipamento Completo</param>
        /// <returns> 0 se não houver lugares disponíveis no array
        /// -1 se já existir esse equipamento
        /// 1 se for inserido o equipamento</returns>
        public static int RegistaEquipamento(Equipamento e)
        {
            if (totalEqu >= MAX) return 0;
            if (ExisteEquipamento(e.Codigo) == true) return -1;

            equ[totalEqu++] = e;

            return 1;
        }

        /// <summary>
        /// Verifica se existe Equipamento
        /// </summary>
        /// <param codigo="cod">Codigo de equipamento </param>
        /// <returns> True se existir
        /// False se não existir</returns>
        private static bool ExisteEquipamento(int cod)
        {
            for (int i = 0; i < totalEqu; i++)
                if (equ[i].Codigo == cod) return true;
            return true;
        }


        #endregion

        #endregion
    }
}
