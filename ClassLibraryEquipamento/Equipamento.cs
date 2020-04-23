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

        static Vulnerabilidades vul;
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


        #endregion

        #region FUNCOES

        public static bool RegistaVulnerabilidadeEquipamento(Vulnerabilidade v)
        {
            //Validações
            if (vul.ExisteVulnerabilidade(v.Codigo) == false)
                vul.RegistaVulnerabilidade(v);
            return true;
        }

        #endregion

        #endregion
    }

    public class Equipamentos
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static Equipamento[] equ;
        static Vulnerabilidade[] vul;
        static int totalEqu = 0;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Equipamentos()
        {
            equ = new Equipamento[MAX];
            vul = new Vulnerabilidade[MAX];
        }

        #endregion

        #region PROPRIEDADES

        #region FUNCOES
        public static bool RegistaEquipamento(Equipamento e)
        {
            //Validar;
            equ[totalEqu++] = e;
            return true;
        }

        public static bool ExisteEquipamento(int equ)
        {
            //procurar;
            return true;
        }


        #endregion

        #endregion
    }
}
