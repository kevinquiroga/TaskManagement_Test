using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
	public class TaskDTO
	{
        [Key]
        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StateTask State { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public enum StateTask
    {
        Pendiente,
        EnProgreso,
        Completada
    }
}

