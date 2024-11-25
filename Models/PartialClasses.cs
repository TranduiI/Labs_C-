using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LabASP.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }

    [MetadataType(typeof(AgreementMetadata))]
    public partial class Agreement
    {
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
    }

    [MetadataType(typeof(StatusMetadata))]
    public partial class Status
    {
    }





}