using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public Usuario Find(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList(); 
        }

        public void Remove(int id)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.ID == id);
            _context.Usuarios.Remove(user);
            _context.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _context.Usuarios.Update(user);
            _context.SaveChanges();
        }
    }
}
