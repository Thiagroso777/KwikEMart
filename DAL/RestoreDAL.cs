using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RestoreDAL
    {
        private readonly DataAccess dataAccess;
        public RestoreDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public void GenerarBackUp()
        {


            string path = $"X:/Restores/BackUp del {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}.bak";

            string query = "BACKUP DATABASE KwikEMart TO DISK = '" + path + "'";

            dataAccess.ReadWithQuery(query, null);
        }

        public void RestaurarBase(string path)
        {
            string query = "USE master\n" + $"ALTER DATABASE KwikEMart SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n" + $"RESTORE DATABASE KwikEMart FROM DISK = '" + path + "' WITH REPLACE \n" + $"ALTER DATABASE KwikEMart SET MULTI_USER";

            dataAccess.RestaurarDB(query);
        }

        
    }
}
