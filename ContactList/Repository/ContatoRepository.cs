using ContactList.Models;
using ContactList.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContactListDbContext _dbContext;
        public ContatoRepository(ContactListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContactModel Add(ContactModel contact)
        {
            _dbContext.Contatos.Add(contact);
            _dbContext.SaveChanges();

            return contact;
        }

        public bool Delete(int id)
        {
            ContactModel contatoDB = GetById(id);
            if (contatoDB == null)
                throw new Exception("Houve um erro na exclusão doo contato");

            _dbContext.Contatos.Remove(contatoDB);
            _dbContext.SaveChanges();

            return true;
        }

        public List<ContactModel> GetAll()
        {
            return _dbContext.Contatos.ToList();
        }

        public ContactModel GetById(int id)
        {
            var contact = _dbContext.Contatos
                 .SingleOrDefault(c => c.Id == id);

            if (contact == null)
                throw new Exception("Contato com ID inexistente.");

            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contatoDb = GetById(contact.Id);
            if (contatoDb == null)
                throw new Exception("Houve um erro na atualização do contato");

            contatoDb.Name = contact.Name;
            contatoDb.Email = contact.Email;
            contatoDb.Phone = contact.Phone;

            _dbContext.Contatos.Update(contatoDb);
            _dbContext.SaveChanges();
            return contatoDb;
        }   
    }
}
