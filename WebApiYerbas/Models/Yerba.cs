﻿using System;
using System.Collections.Generic;

namespace WebApiYerbas.Models;

public partial class Yerba
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }
}
