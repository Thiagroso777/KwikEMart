using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RestoreBLL
    {
        RestoreDAL restoreDAL = new RestoreDAL();

        public void GenerarBackUp()
        {
            restoreDAL.GenerarBackUp();
        }

        public void RestaurarBase(string BackUpFilePath)
        {
            restoreDAL.RestaurarBase(BackUpFilePath);
        }
    }
}
