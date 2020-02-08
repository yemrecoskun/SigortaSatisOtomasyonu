using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals
{
    public class Globals
    {
        //MySQL Veritabanı Bağlantı kurma.
        public static MySqlConnection con = new MySqlConnection("Server=localhost;Database=sigortaotomasyonu;user=root;pwd='';");
        //Ürün Listesinde Düzenleme kısmında İd Disibled olduğundan Veriyi alamıyoruz. Bu durumda Globale değer vererek düzenleme yapabilmemiz mevcut.
        public static int duzenleid;
    }
}
