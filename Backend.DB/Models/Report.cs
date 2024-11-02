using System;
using System.Collections.Generic;

namespace Backend.DB.Models;

public partial class Report
{
    public int Id { get; set; }

    public int? DisciplineId { get; set; }

    public int? TeacherId { get; set; }

    public string? FilePath { get; set; }

    public byte? IsCorrect { get; set; }

    public string? ResultOfAttestation { get; set; }

    public byte? DoneInPaperForm { get; set; }

    public byte? DoneInElectronicForm { get; set; }

    public byte? AllDone { get; set; }

    public virtual Discipline? Discipline { get; set; }

    public virtual User? Teacher { get; set; }

    public virtual ICollection<Testing> Testings { get; set; } = new List<Testing>();
}
