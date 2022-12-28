using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User;

public class Account
{
    public Guid Id { get; set; }
    public string Role { get; set; }
    public DateTime Created { get; set; }
}
