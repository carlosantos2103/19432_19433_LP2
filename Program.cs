/*-----------------------------------------------------------------------
* <copyright file="Program.cs" company="IPCA">
*     Copyright. All rights reserved.
* </copyright>
* <date> 05/09/2020 </date>
* <time> 00:45 </time>
* <author> 
*      Carlos Santos (19432)
*      Rúben Silva (19433) 
* </author>
* <email>
*      a19432@alunos.ipca.pt
*      a19433@alunos.ipca.pt
* </email>
* <desc>
*      Ficheiro principal que agrupa todas as classes vindas das bibliotecas e implementa os métodos.
* </desc>
-----------------------------------------------------------------------*/

using a2_RegrasNegocio;
using c1_ObjetosNegocio;

using System;
using System.Collections.Generic;


namespace TrabalhoPrático1_19432_19433
{
    class Program
    {
        static void Main(string[] args)
        {
            #region VARIAVEIS

            int quant;
            float media;

            Auditoria a = new Auditoria();
            Auditoria amaior = new Auditoria();
            Auditoria amenor = new Auditoria();
            Colaborador c = new Colaborador();
            Equipamento e = new Equipamento();
            Vulnerabilidade v = new Vulnerabilidade();

            List<int> vulnsAux = new List<int>();

            #endregion

            #region CARREGAMENTOS
            EquRegras.CarregarEquipamentos(@"..\..\Ficheiros\Equipamentos");
            VulRegras.CarregarVulnerabilidades(@"..\..\Ficheiros\Vulnerabilidades");
            ColRegras.CarregarColaboradores(@"..\..\Ficheiros\Colaboradores");
            AudRegras.CarregarAuditorias(@"..\..\Ficheiros\Auditorias");
            #endregion

            #region DADOS TESTE 

            /*Criação de Objetos exemplares*/
            Colaborador col1 = new Colaborador(1, Atividade.ATIVO, 0, "Carlo", Genero.M, 20, 164015584);
            Colaborador col2 = new Colaborador(2, Atividade.ATIVO, 0, "Filipe", Genero.M, 23, 251312021);
            Equipamento equ1 = new Equipamento(1, "Portatil", "HP", "cs006np", DateTime.Parse("21/02/2020"));
            Equipamento equ2 = new Equipamento(2, "Monitor", "LG", "ex123", DateTime.Today);
            Vulnerabilidade vul1 = new Vulnerabilidade(1, "Falha no sistema", NivelImpacto.ELEVADO, Estado.NAORESOLVIDA);
            Vulnerabilidade vul2 = new Vulnerabilidade(2, "Erro", NivelImpacto.MODERADO, Estado.NAORESOLVIDA);
            Vulnerabilidade vul3 = new Vulnerabilidade(3, "Problema", NivelImpacto.BAIXO, Estado.RESOLVIDA);

            /*Registo de cada um dos objetos*/
            ColRegras.RegistaColaborador(col1);
            ColRegras.RegistaColaborador(col2);
            EquRegras.RegistaEquipamento(equ1);
            VulRegras.RegistaVulnerabilidade(vul1);
            VulRegras.RegistaVulnerabilidade(vul2);
            VulRegras.RegistaVulnerabilidade(vul3);

            /*Criação de Objetos exemplares*/
            Auditoria aud1 = new Auditoria(1, 10, DateTime.Today, col1.Codigo, equ1.Codigo);
            Auditoria aud2 = new Auditoria(2, 54, DateTime.Today, col2.Codigo, equ2.Codigo);

            /*Complementação das auditorias e equipamentos ao adicionar vulnerabilidades*/
            AudRegras.RegistaAuditoria(aud1);
            AudRegras.RegistaAuditoria(aud2);
            ColRegras.AdicionaAuditoriaColaborador(aud1.CodColab);
            ColRegras.AdicionaAuditoriaColaborador(aud2.CodColab);
            AudRegras.AdicionaVulnerabilidadeAuditoria(aud1.Codigo, vul1.Codigo);
            AudRegras.AdicionaVulnerabilidadeAuditoria(aud1.Codigo, vul2.Codigo);
            AudRegras.AdicionaVulnerabilidadeAuditoria(aud2.Codigo, vul3.Codigo);
            EquRegras.AdicionaVulnerabilidadeEquipamento(equ1.Codigo, vul1.Codigo);
            EquRegras.AdicionaVulnerabilidadeEquipamento(equ1.Codigo, vul2.Codigo);
            EquRegras.AdicionaVulnerabilidadeEquipamento(equ2.Codigo, vul3.Codigo);

            /*Apresentação do dashboard*/
            if (AudRegras.QuantidadeAuditorias() != 0)
            {
                amaior = AudRegras.ObterAuditoriaMaisVuln();
                amenor = AudRegras.ObterAuditoriaMenosVuln();
                media = AudRegras.ObtemMediaVulns();
                Console.WriteLine("     -> Quantidade de Auditorias: {0}\n", AudRegras.QuantidadeAuditorias());
                Console.WriteLine("     -> Auditoria com mais Vulnerabilidades");
                Console.WriteLine("         Código: {0, -5}|  Data: {1, -10}  |  Quantidade de Vulnerabilidades: {2}\n", amaior.Codigo.ToString(), amaior.DataRegisto.ToShortDateString(), AudRegras.ObterQuantidadeVulnerabilidadesAuditoria(amaior.Codigo).ToString());
                Console.WriteLine("     -> Auditoria com menos Vulnerabilidades");
                Console.WriteLine("         Código: {0, -5}|  Data: {1, -10}  |  Quantidade de Vulnerabilidades: {2}\n", amenor.Codigo.ToString(), amenor.DataRegisto.ToShortDateString(), AudRegras.ObterQuantidadeVulnerabilidadesAuditoria(amenor.Codigo).ToString());
                Console.WriteLine("     -> Média de Vulnerabilidades por Auditoria: {0}\n\n", media.ToString());
            }
            Console.ReadKey();
            Console.Clear();

            /*Mostrar Informações*/
            AudRegras.MostraAuditorias();
            Console.WriteLine();
            ColRegras.MostraColaboradores();
            Console.WriteLine();
            EquRegras.MostraEquipamentos();
            Console.ReadKey();
            Console.Clear();

            /*Editar Objetos*/
            a = new Auditoria(1, 26, DateTime.Parse("22/02/2020"), col1.Codigo, equ1.Codigo);
            AudRegras.EditaAuditoria(a);

            /*Editar Colaborador e tornar inativo*/
            c = new Colaborador(1, Atividade.ATIVO, 0, "Carlos", Genero.M, 21, 164015584);
            ColRegras.EditaColaborador(c);
            if (ColRegras.VerificaAtividade(c.Codigo))
                ColRegras.TornarColaboradorInativo(c.Codigo);

            /*Apresentação de algumas informações*/
            AudRegras.ApresentaAuditoriasColaborador(c.Codigo);
            Console.WriteLine();
            AudRegras.ApresentaAuditoriasOrdenadasVuln();
            Console.ReadKey();
            Console.Clear();

            e = EquRegras.ObterEquipamento(a.CodEqui);
            Console.WriteLine("- Detalhes de Equipamento\n");
            Console.WriteLine("Código: " + e.Codigo.ToString());
            Console.WriteLine("Tipo: " + e.Tipo);
            Console.WriteLine("Data de Aquisição: " + e.DataAquisicao.ToShortDateString());
            quant = EquRegras.ObterQuantidadeVulnerabilidadesEquipamento(e.Codigo);
            Console.WriteLine("Quantidade de Vulnerabilidades: " + quant.ToString());
            Console.WriteLine("\nVulnerabilidades do Equipamento:\n");
            if (quant > 0)
                for (int i = 0; i < quant; i++)
                    VulRegras.ListarVulnerabilidadeEquipamento(EquRegras.ObterCodigoVulnerabilidade(e.Codigo, i));
            else
                Console.WriteLine("- Este equipamento não tem vulnerabilidades registadas.");
            Console.ReadKey();

            #endregion

            #region GUARDAR 
            EquRegras.GuardarEquipamentos(@"..\..\Ficheiros\Equipamentos");
            VulRegras.GuardarVulnerabilidades(@"..\..\Ficheiros\Vulnerabilidades");
            ColRegras.GuardarColaboradores(@"..\..\Ficheiros\Colaboradores");
            AudRegras.GuardarAuditorias(@"..\..\Ficheiros\Auditorias");
            #endregion
        }
    }
}
