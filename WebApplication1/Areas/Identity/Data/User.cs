using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace WebApplication1.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    [PersonalData]
    [EmailAddress]
    [System.ComponentModel.DataAnnotations.Required]
    public string Mail { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [PersonalData]
    public string Sifre { get; set; }
}

