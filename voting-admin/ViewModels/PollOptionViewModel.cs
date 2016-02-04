using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace voting.admin.ViewModels
{
    public class PollOptionViewModel
    {
      [Required]
      public string Name { get; set; }
    }
}
