using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangFireLegacy.Models
{
    public class Foo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Bar { get; set; }
    }
}
