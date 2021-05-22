using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync<T>(string viewName, T model);
    }
}
