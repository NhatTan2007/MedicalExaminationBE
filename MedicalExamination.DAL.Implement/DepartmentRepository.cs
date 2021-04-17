using MedicalExamination.DAL.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.DAL.Implement
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration config) : base (config)
        {

        }
    }
}
