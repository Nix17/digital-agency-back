﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Settings;

public class MailSettings
{
    public string EmailFrom { get; set; } = string.Empty;
    public string SmtpHost { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = string.Empty;
    public string SmtpPass { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public bool UseSSL { get; set; }
    public string RootFolder { get; set; } = string.Empty;
    public string Templates { get; set; } = string.Empty;
}