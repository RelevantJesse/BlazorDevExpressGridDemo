using BlazorDevExpressGridDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDevExpressGridDemo.EditFormTemplates
{
    public class FormEditContext
    {
        public FormEditContext(Role role)
        {
            Role = role;
            if (Role == null)
            {
                Role = new Role();
                IsNewRow = true;
            }
            Name = Role.Name;
        }

        public Role Role { get; set; }
        public bool IsNewRow { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 4,
        ErrorMessage = "The description should be 4 to 32 characters.")]
        public string Name { get; set; }

        public Action StateHasChanged { get; set; }
    }
}
