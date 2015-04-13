using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class AngajatService
    {
        AnuntDAL da = new AnuntDAL();
        UserDAL du = new UserDAL();
        int id;

        public String getRole(String user, String pass)
        {
            id = du.getId(user, pass);
            return du.getRole(user, pass);
        }

        public void add(String title, String description, String type, float price)
        {
            da.add(title, description, type, price, id);
        }

        public List<Anunt> getAll()
        {
            return da.getAll();
        }
    }
}
