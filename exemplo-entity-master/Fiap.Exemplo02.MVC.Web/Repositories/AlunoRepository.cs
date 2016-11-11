using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        
        private PortalContext _context;

        public AlunoRepository(PortalContext context)
        {
            _context = context;
        }

        public ICollection<Aluno> BuscaPor(Expression<Func<Aluno, bool>> filtro)
        {
            return _context.Aluno.Where(filtro).ToList();
        }

        public Aluno Buscar(int id)
        {
            return _context.Aluno.Find(id);
        }

        public void Cadastro(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
        }
        //Save changes fica no final, então não colocamos eles no método
        public void Editar(Aluno aluno)
        {
            _context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(int id)
        {
            var aluno = Buscar(id);
            _context.Aluno.Remove(aluno);
        }

        public ICollection<Aluno> Listar()
        {
            return _context.Aluno.Include("Grupo").ToList();
        }
    }
}