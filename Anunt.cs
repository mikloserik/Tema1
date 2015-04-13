using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Anunt
    {
        private String title;
        private String description;
        private String type;
        private float price;

        public Anunt(String title, String description, String type, float price)
        {
            this.title = title;
            this.description = description;
            this.type = type;
            this.price = price;
        }

        public String getType()
        {
            return type;
        }
    }
}
