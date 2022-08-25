using SchoolManagement.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolManagement.Core.Contracts
{
    public interface IParent
    {
        Task<IEnumerable<Parent>> GetParentAsync();
    }
}
