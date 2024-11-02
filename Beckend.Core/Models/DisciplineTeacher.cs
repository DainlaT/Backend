using System;
using System.Collections.Generic;

namespace Backend.Core.Models;

public partial class DisciplineTeacher
{
    public DisciplineTeacher(Guid id, int? disciplineId, int? responsibleTeacherId, Discipline? discipline, User? responsibleTeacher)
    {
        Id = id;
        DisciplineId = disciplineId;
        ResponsibleTeacherId = responsibleTeacherId;
        Discipline = discipline;
        ResponsibleTeacher = responsibleTeacher;
        
    }

    public Guid Id { get; set; }

    public int? DisciplineId { get; set; }

    public int? ResponsibleTeacherId { get; set; }

    public virtual Discipline? Discipline { get; set; }

    public virtual User? ResponsibleTeacher { get; set; }
}
