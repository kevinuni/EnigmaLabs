﻿using Enigma.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Model;

[BsonCollection("Person")]
public class Person : Document
{
    public int? PersonId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DOI { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public bool? IsPerNat { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string RUC { get; set; } = null!;
}