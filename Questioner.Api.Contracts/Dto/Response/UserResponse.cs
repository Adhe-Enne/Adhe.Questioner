using Core.Contracts.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questioner.Api.Contracts.Dto.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public string? DNI { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string? Image { get; set; }
        public string? City { get; set; } = default!;
        public string? Country { get; set; } = default!;
        public UserRole Role { get; set; } = UserRole.User;
    }
}
