using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginReg.Models;

namespace LoginReg.Controllers.Business
{
    public interface IBLLReg
    {
        string addRecord(User details);
    }

}
