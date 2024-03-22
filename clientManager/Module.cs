using System;
using System.Windows.Forms;

namespace clientManager
{
    public  class Client
    {
        public string Name { get; set; }
        public int id { get; private set; }        
        public string Type { get;private set; }

       private static int clientNumber = 0;
        
        public void generateIdNumber()
        {
            id = clientNumber++;
        }

        public void setTypeOnline() {
            Type = "online";
        }
        public void setTypeOffline()
        {
            Type = "offline";
        }
    }
  
}
