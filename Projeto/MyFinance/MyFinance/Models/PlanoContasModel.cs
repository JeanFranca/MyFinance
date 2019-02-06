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
    public class PlanoContasModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descricao")]
        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public int Usuario_Id { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public PlanoContasModel()
        {

        }

        public PlanoContasModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<PlanoContasModel> ListaPlanoContas()
        {
            List<PlanoContasModel> lista = new List<PlanoContasModel>();
            PlanoContasModel item;

            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT ID, DESCRICAO, TIPO, USUARIO_ID FROM PLANO_CONTAS WHERE USUARIO_ID = {Id_usuario_logado}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new PlanoContasModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                item.Tipo = dt.Rows[i]["TIPO"].ToString();
                item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                lista.Add(item);
            }
            return lista;
        }

        public void Insert()
        {
            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "";
            if (Id == 0)
            {
                sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO, USUARIO_ID) VALUES( '{Descricao}', '{Tipo}', '{Id_usuario_logado}');";
            }
            else
            {
                sql = $"UPDATE PLANO_CONTAS SET DESCRICAO = '{Descricao}', TIPO = '{Tipo}' WHERE USUARIO_ID='{Id_usuario_logado}' AND ID='{Id}'";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_plano_conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM PLANO_CONTAS WHERE ID = " + id_plano_conta);
        }

        public PlanoContasModel CarregarRegistro(int? id_plano_conta)
        {
            PlanoContasModel item = new PlanoContasModel();

            string Id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT ID, DESCRICAO, TIPO, USUARIO_ID FROM PLANO_CONTAS WHERE USUARIO_ID = '{Id_usuario_logado}' AND ID = '{id_plano_conta}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
            item.Tipo = dt.Rows[0]["TIPO"].ToString();
            item.Usuario_Id = int.Parse(dt.Rows[0]["USUARIO_ID"].ToString());

            return item;

        }

    }
}
