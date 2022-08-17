using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Oto_Servis
{
    class ConnectionClass
    {
        
        private string server = "localhost";
        private string db = "otoservis";
        private string id = "root";
        private string pass = "";

        /*
        private string server = "77.245.159.13:3306";
        private string db = "opengue1_otoServis_1";
        private string id = "opengue1_otoServis101";
        private string pass = "2ddfa11b46Ds";
        */

        public MySqlConnection conn;

        public ConnectionClass() //yapıcıda bağlantı otomatik ayarlanıyor
        {
            conn = new MySqlConnection($"Server='{server}';Database='{db}';Uid='{id}';Pwd='{pass}'; Allow Zero Datetime=true");
        }

        public MySqlConnection myConnection() {
            return conn;
        }
    }
}
