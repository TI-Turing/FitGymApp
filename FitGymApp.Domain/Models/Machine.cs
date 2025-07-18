﻿using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class Machine
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Observations { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid MachineCategoryId { get; set; }

    public Guid BrandId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual MachineCategory MachineCategory { get; set; } = null!;

    public virtual ICollection<Exercise> MachineExerciseMachines { get; set; } = new List<Exercise>();
}
