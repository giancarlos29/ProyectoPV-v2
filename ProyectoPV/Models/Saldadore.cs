
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProyectoPV.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Saldadore
{

    public int IDSaldador { get; set; }

    public string Nombres { get; set; }

    public string Apellidos { get; set; }

    public Nullable<double> CapitalSaldado { get; set; }

    public Nullable<System.DateTime> FechaInicializacionPrestamo { get; set; }

    public Nullable<System.DateTime> FechaFinalizacionPrestamo { get; set; }

    public Nullable<int> CuotasGeneradas { get; set; }

    public Nullable<int> CuotasPagadasATiempo { get; set; }

    public Nullable<int> Score { get; set; }

    public string Telefono { get; set; }

    public string Direccion { get; set; }

    public string Cedula { get; set; }

}

}
