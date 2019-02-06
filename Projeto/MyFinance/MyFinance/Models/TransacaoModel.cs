using Microsoft.AspNetCore.Http;
using MyFinance.util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class TransacaoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Data da conta")]
        public string Data { get; set; }

        public string DataFinal { get; set; }

        public String Tipo { get; set; }

        [Required(ErrorMessage = "Informe o Valor da conta")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Informe a Descricao da conta")]
        public String Descricao { get; set; }

        public int Conta_Id { get; set; }

        public string NomeConta { get; set; }

        public int Plano_Contas_Id { get; set; }

        public string DescricaoPlanoConta { get; set; }
        
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public TransacaoModel()
        {

        }

        public TransacaoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<TransacaoModel> ListaTransacao()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            //Utilizado pela view extrato

            string filtro = "";

            filtro += "";

            if((Data != null) && (DataFinal != null))
            {
                filtro += $"and t.Data >= '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' and t.Data <= '{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}'";
            }

            if(Conta_Id != 0)
            {
                filtro += $"and t.Conta_Id = '{Conta_Id}'";
            }

            if(Tipo != null)
            {
                if(Tipo != "Receitas e Despesas")
                {
                    filtro += $"and t.Tipo = '{Tipo}'";
                }
            }
            filtro += "";
            //fim

            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql =  "select t.Id, t.Data, t.Tipo, t.Valor, t.Descricao as historico, t.Conta_Id,c.Nome as conta, t.Plano_Contas_Id, p.Descricao as  plano_conta" +
                          " from transacao as t inner join conta c" +
                          " on t.Conta_Id = c.Id inner join Plano_Contas as p" +
                          " on t.Plano_Contas_Id = p.Id where" + 
                          $" t.Usuario_Id = '{Id_usuario_logado}' {filtro} order by t.data desc limit 10;";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new TransacaoModel();
                item.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                item.Data = DateTime.Parse(dt.Rows[i]["Data"].ToString()).ToString("dd/MM/yyyy");
                item.Tipo = dt.Rows[i]["Tipo"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["Valor"].ToString());
                item.Descricao = dt.Rows[i]["historico"].ToString();
                item.Conta_Id = int.Parse(dt.Rows[i]["Conta_Id"].ToString());
                item.NomeConta = dt.Rows[i]["conta"].ToString();
                item.Plano_Contas_Id = int.Parse(dt.Rows[i]["Plano_Contas_Id"].ToString());
                item.DescricaoPlanoConta = dt.Rows[i]["plano_conta"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public TransacaoModel CarregarRegistro(int? id_plano_conta)
        {
            TransacaoModel item = new TransacaoModel();

            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT T.ID, T.DATA, T.TIPO, T.VALOR, t.Descricao as historico, t.Conta_Id,c.Nome as conta, t.Plano_Contas_Id, p.Descricao as  plano_conta" +
                          " from transacao as t inner join conta c" +
                          " on t.Conta_Id = c.Id inner join Plano_Contas as p" +
                          $" on t.Plano_Contas_Id = p.Id WHERE T.ID = '{id_plano_conta}' AND T.USUARIO_ID = '{Id_usuario_logado}' ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Data = DateTime.Parse(dt.Rows[0]["Data"].ToString()).ToString("dd/MM/yyyy");
            item.Tipo = dt.Rows[0]["TIPO"].ToString();
            item.Valor = double.Parse(dt.Rows[0]["VALOR"].ToString());
            item.Descricao = dt.Rows[0]["historico"].ToString();
            item.Conta_Id = int.Parse(dt.Rows[0]["Conta_Id"].ToString());
            item.NomeConta = dt.Rows[0]["conta"].ToString();
            item.Plano_Contas_Id = int.Parse(dt.Rows[0]["Plano_Contas_Id"].ToString());
            item.DescricaoPlanoConta = dt.Rows[0]["plano_conta"].ToString();
            return item;

        }

        public void Insert()
        {
            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "";
            if (Id == 0)
            {
                sql = $"INSERT INTO TRANSACAO (DATA, TIPO, DESCRICAO, VALOR, CONTA_ID, PLANO_CONTAS_ID, USUARIO_ID) VALUES( '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}', '{Tipo}', '{Descricao}', '{Valor}', '{Conta_Id}', '{Plano_Contas_Id}', '{Id_usuario_logado}');";
            }
            else
            {
                sql = $"UPDATE TRANSACAO SET DATA = '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}', TIPO = '{Tipo}', DESCRICAO = '{Descricao}',VALOR = '{Valor}',CONTA_ID = '{Conta_Id}',PLANO_CONTAS_ID = '{Plano_Contas_Id}' WHERE USUARIO_ID='{Id_usuario_logado}' AND ID='{Id}'";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_transacao)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM TRANSACAO WHERE ID = " + id_transacao);
        }
    }

    public class DashBoard
    {
        public double Total { get; set; }
        public string PlanoConta { get; set; }

        public double saldoConta { get; set; }
        public string NomeConta { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public DashBoard()
        {

        }

        public DashBoard(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<DashBoard> RetornarDadosGraficoPie()
        {
            List<DashBoard> lista = new List<DashBoard>();

            DashBoard item;
            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"select sum(t.valor) as total, p.Descricao from transacao as t inner join plano_contas as p on t.Plano_Contas_Id = p.Id where t.Tipo = 'Despesa' and t.Usuario_Id = '{Id_usuario_logado}' group by p.Descricao";
            DAL objDAL = new DAL();
            DataTable dt = new DataTable();
            dt = objDAL.RetDataTable(sql);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                item = new DashBoard();
                item.Total = double.Parse(dt.Rows[i]["Total"].ToString());
                item.PlanoConta = dt.Rows[i]["Descricao"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public List<DashBoard> RetornarDadosGraficoBar()
        {
            List<DashBoard> lista = new List<DashBoard>();

            DashBoard item;
            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"select saldo, Nome from conta where Usuario_id = '{Id_usuario_logado}';";
            DAL objDAL = new DAL();
            DataTable dt = new DataTable();
            dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new DashBoard();
                item.saldoConta = double.Parse(dt.Rows[i]["saldo"].ToString());
                item.NomeConta = dt.Rows[i]["Nome"].ToString();
                lista.Add(item);
            }
            return lista;
        }

    }
}
