using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class usuarioModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public usuarioModel()
        {

        }
        public usuarioModel(string UserName, string PassWord)
        {
            this.UserName = UserName;
            this.PassWord = PassWord;
        }

        public usuarioModel(int ID, string UserName, string PassWord)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.PassWord = PassWord;
        }


    }

}