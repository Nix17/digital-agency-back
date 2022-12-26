using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserEntity: AuditableBaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
}
