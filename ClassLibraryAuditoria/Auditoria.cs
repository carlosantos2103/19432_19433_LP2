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
        static Colaboradores col;
        Equipamentos equ;
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
        }

        /// <summary>
        /// Construtor com valores vindos do exterior
        /// </summary>
        /// <param codigo="codigo">Codigo da Auditoria </param>
        /// <param duracao="duracao">Duracao da Auditoria</param>
        /// /// <param dataRegisto="dataRegisto">Data de Registo da Auditoria</param>
        public Auditoria(int codigo, int duracao, DateTime dataRegisto)
        {
            this.codigo = codigo;
            this.duracao = duracao;
            this.dataRegisto = dataRegisto;
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

        #endregion

        #region FUNCOES

        public static bool RegistaColaboradorAuditoria(Colaborador c)
        {
            //Validações
            /*if (col.ExisteColaborador(c.codigo) == false)*/
            Colaboradores.RegistaColaborador(c);
            return true;
        }

        #endregion

        #endregion
    }

    public class Auditorias
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static Auditoria[] aud;
        static Colaborador[] col;
        static Equipamento[] equ;
        static int totalAud=0;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Auditorias()
        {
            aud = new Auditoria[MAX];
            col = new Colaborador[MAX];
            equ = new Equipamento[MAX];
        }

        #endregion

        #region PROPRIEDADES

        #region FUNCOES

        public static bool RegistaAuditoria(Auditoria a, Colaborador c, Equipamento e)
        {
            //Validar;
            aud[totalAud++] = a;
            //Auditoria.RegistaColaboradorAuditoria(c);
            return true;
        }

        public static bool ExisteAuditoria(int cod)
        {
            //procurar;
            return true;
        }


        #endregion

        #endregion
    }
}
