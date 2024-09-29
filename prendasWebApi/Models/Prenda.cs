using System;
using System.Collections.Generic;

namespace prendasWebApi.Models;

public partial class Prenda
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Talle { get; set; } = null!;

    public string Color { get; set; } = null!;

    public Guid IdMarca { get; set; }

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
