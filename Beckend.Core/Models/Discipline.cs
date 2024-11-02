using System;
using System.Collections.Generic;

namespace Backend.Core.Models;

public partial class Discipline
{
    public Discipline(Guid id, string name, int departmentid, Department department, ICollection<DisciplineTeacher> disciplineTeachers, ICollection<Report> reports, ICollection<Testing> testings)
    {
        Id = id;
        Name = name;
        DepartmentId = departmentid;
        Department = department;
        DisciplineTeachers = disciplineTeachers;
        Reports = reports;
        Testings = testings;
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<DisciplineTeacher> DisciplineTeachers { get; set; } = new List<DisciplineTeacher>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Testing> Testings { get; set; } = new List<Testing>();
}
