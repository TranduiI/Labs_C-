using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LabASP.ViewModels
{
    public class AgreementPerDate
    {
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public int AgreementCount { get; set; }
    }
}