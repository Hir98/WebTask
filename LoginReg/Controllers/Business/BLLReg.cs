using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoginReg.Controllers.Data;
using LoginReg.Models;

namespace LoginReg.Controllers.Business
{
    public class BLLReg : IBLLReg
    {

        private IDALReg _objIDALReg;
        
        public BLLReg(IDALReg objIDALReg)
        {
            _objIDALReg = objIDALReg;
        }

 

        public string addRecord(User details)
        {
            return _objIDALReg.addRecord(details);
        }
    }
}
