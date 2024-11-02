﻿using System;
using System.Collections.Generic;

namespace Backend.DB.Models;

public partial class DisciplineTeacher
{
    public int Id { get; set; }

    public int? DisciplineId { get; set; }

    public int? ResponsibleTeacherId { get; set; }

    public virtual Discipline? Discipline { get; set; }

    public virtual User? ResponsibleTeacher { get; set; }
}
