using System;
using System.Collections.Generic;

namespace Backend.DB.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public int? StatusId { get; set; }

    public int? FacultyId { get; set; }

    public virtual ICollection<DisciplineTeacher> DisciplineTeachers { get; set; } = new List<DisciplineTeacher>();

    public virtual Faculty? Faculty { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Role? Role { get; set; }

    public virtual Status? Status { get; set; }
}
