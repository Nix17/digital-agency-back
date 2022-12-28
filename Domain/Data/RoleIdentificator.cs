using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data;

public static class RoleIdentificator
{
    public static string User { get; } = "user";
    public static string Admin { get; } = "admin";
    public static string Root { get; } = "root";
}
