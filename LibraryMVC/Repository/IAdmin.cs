using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMVC4.Models;

namespace LibraryMVC4.Repository
{
    public interface IAdmin<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetList();
        IEnumerable<T> List();
        IEnumerable<T> GetCatList();
        IEnumerable<T> GetSubmittedQs();
        IEnumerable<T> GetAssignQs();
        IEnumerable<T> GetSubmittedQsNo();
        IEnumerable<T> GetLibAdminPeople();
        IEnumerable<T> GetFeedBack();
        //IEnumerable<T> SearchKeyWords(string a, string b, string c);

        T PatronInfo(string id);      
        T GetById(int id);
        T GetByKeyId(int id);
        T GetAssignQ(int id);
        T CategoryEdit(int id);
        T GetCheckBox(int id);
      
        object Edit(T entity);
        object EditLibPerson(T entity, int id);

        object AddQ(T entity);
        object Add(T entity);
        object AddPhoneQt(T entity);
                  
        object Delete(int id);
        //object DeleteQt(int id);
        object EditCategory(T entity);
    }
}
