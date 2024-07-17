using System;
using System.Collections.Generic;

namespace RegistrationApi.DBModel;

public partial class Userinfo
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public string? ProfileImage { get; set; }
}
