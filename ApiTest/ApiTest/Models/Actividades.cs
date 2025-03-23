using System;
using System.Collections.Generic;

namespace ApiTest.Models;

public partial class Actividades
{
    public int IdActividad { get; set; }

    public DateTime CreateDate { get; set; }

    public int IdUsuario { get; set; }

    public string Actividad { get; set; } = null!;
}
