using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Infrastructure.Models;
using System.Web.Mvc;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ParentRepository : IParent
    {
        private readonly SchoolManagementContext _schoolManagementContext;

        public ParentRepository(SchoolManagementContext schoolManagementContext)
        {
            _schoolManagementContext = schoolManagementContext;
        }

        public async Task<IEnumerable<Parent>> GetParentAsync()
        {
           var data= await (from parent in _schoolManagementContext.Parents
                             select parent).ToListAsync();
            return data;
        }
    }
}
