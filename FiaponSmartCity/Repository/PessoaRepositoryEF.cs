using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;

namespace FiapSmartCity.Repository
{
    public class PessoaRepositoryEF
    {
        private readonly DataBaseContext context;

        public PessoaRepositoryEF()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }


        public IList<PessoaEF> Listar()
        {
            return context.PessoaEF.ToList();
        }

        public PessoaEF Consultar(int id)
        {
            return context.PessoaEF.Find(id);
        }


        public void Inserir(PessoaEF pessoa)
        {
            context.PessoaEF.Add(pessoa);
            context.SaveChanges();
        }

        public void Alterar(PessoaEF pessoa)
        {
            context.PessoaEF.Update(pessoa);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var pessoa = new PessoaEF()
            {
                IdPessoa = id
            };

            context.PessoaEF.Remove(pessoa);
            context.SaveChanges();
        }

    }
}
