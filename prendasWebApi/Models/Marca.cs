using System;
using System.Collections.Generic;

namespace prendasWebApi.Models;

public partial class Marca
{
    public Guid Id { get; set; }

    public string Marca1 { get; set; } = null!;

    public virtual ICollection<Prenda> Prenda { get; set; } = new List<Prenda>();
}
