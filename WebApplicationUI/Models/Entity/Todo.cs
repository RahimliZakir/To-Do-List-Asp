using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationUI.Models.Entity
{
    public class Todo
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(150)]
        public string Title { get; set; }

        [Required()]
        [StringLength(150)]
        public string Description { get; set; }

        [Required()]
        [StringLength(150)]
        public string ResponsiblePersons { get; set; }

        public bool IsCompleted { get; set; }

        //User Date.di sehv salmisham
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUserId { get; set; }

        public DateTime? DeletedUserId { get; set; }
    }
}
