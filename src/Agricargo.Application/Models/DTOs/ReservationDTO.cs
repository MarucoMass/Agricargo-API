﻿

namespace Agricargo.Application.Models.DTOs;

public class ReservationDTO
{
    public int Id { get; set; }
    public string? Trip { get; set; }
    public DateTime Date { get; set; }
    public float Price { get; set; }
    public float GrainQuantity { get; set; }
    public string? Status { get; set; }

    public DateTime DepartureDate { get; set; }

    public DateTime ArriveDate { get; set; }
}
