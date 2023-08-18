namespace DotNetTestetec.Modal;
using System;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    
    public Guid id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    
}