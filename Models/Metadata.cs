using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace LabASP.Models
{
    public class UserMetadata
    {
        [StringLength(35)]
        [Display(Name ="ФИО")]
        public string ФИО { get; set; }
        [StringLength(50)]
        [Display(Name ="Должность")]
        public string Должность { get; set; }
    }
    public class AccountMetadata
    {
        [StringLength(10)]
        [Display(Name ="Логин")]
        public string Логин { get; set; }

        [StringLength(10)]
        [Display(Name ="Пароль")]
        public string Пароль { get; set; }

        [Range(1, 4)]
        [Display(Name ="Уровень доступа")]
        public int Уровень_доступа { get; set; }
    }
    public class AgreementMetadata
    {
        [StringLength(35)]
        [Display(Name = "ФИО")]
        public string ФИО { get; set; }

        [StringLength(50)]
        [Display(Name = "Адрес")]
        public string Адрес { get; set; }

        [StringLength(12)]
        [Display(Name = "Номер")]
        public string Номер { get; set; }
    }

    public class ProductMetadata
    {
        [StringLength(50)]
        [Display(Name ="Наименование")]
        public string Наименование_ { get; set; }
    }
    public class StatusMetadata
    {
        [StringLength(10)]
        [Display(Name ="Статус")]
        public string Статус { get; set; }
    }
}