﻿using System;
namespace Core.Entities
{
	public class Direccion
	{
		public int Id { get; set; }
		public string Calle { get; set; }
		public string Ciudad { get; set; }
		public string Departamento { get; set; }
		public string CodigoPostal { get; set; }
		public string UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
	}
}

