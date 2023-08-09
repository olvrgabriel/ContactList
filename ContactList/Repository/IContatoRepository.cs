using ContactList.Models;

namespace ContactList.Repository
{
    public interface IContatoRepository
    {
        List<ContactModel> GetAll();
        ContactModel Add(ContactModel contact);
           
        ContactModel Update(ContactModel contact);

        ContactModel GetById(int id);

        bool Delete(int id);
    }
}
