using System;
using System.Collections.Generic;

namespace Backend.Core.Models;

public partial class Department
{
    private Department(in Guid id, string name, int facultyId, ICollection<Discipline> disciplines, Faculty? faculty, ICollection<StudyProgram> studyPrograms)
    {
        Id = id;
        Name = name;
        FacultyId = facultyId;
        Disciplines = disciplines;
        Faculty = faculty;
        StudyPrograms = studyPrograms;

    }

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? FacultyId { get; set; }

    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();

    public virtual Faculty? Faculty { get; set; }

    public virtual ICollection<StudyProgram> StudyPrograms { get; set; } = new List<StudyProgram>();
}
