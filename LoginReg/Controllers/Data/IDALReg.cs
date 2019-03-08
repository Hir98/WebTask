using LoginReg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginReg.Controllers.Data
{
   public interface IDALReg
    {
        string addRecord(User details);
    }
}
