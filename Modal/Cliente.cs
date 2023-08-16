namespace DotNetTestetec.Modal;
using System;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int id{ get; set;}
    public Guid Clienteid { get; set; }
    public string username { get; set; }
}