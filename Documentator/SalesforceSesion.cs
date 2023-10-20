using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATOR
{
    public class SalesforceSesion
    {
        /*Singleton */
        private static SalesforceSesion _instancia = new SalesforceSesion();
        public static SalesforceSesion Instancia
        {
            get
            {
                return _instancia;
            }
        }
        /*constructor*/
        private SalesforceSesion()
        {
         
        }

        /*Propiedades*/
        public string token { get; set; }
        public string url { get; set; }
        public string api { get; set; }

        

    }
}
