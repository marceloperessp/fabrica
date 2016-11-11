using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IAlunoRepository
    {
        void Cadastro(Aluno aluno);
        void Editar(Aluno aluno);
        void Excluir(int id);
        Aluno Buscar(int id);
        ICollection<Aluno> Listar();
        ICollection<Aluno> BuscaPor(Expression<Func<Aluno, bool>> filtro);

    }
}
