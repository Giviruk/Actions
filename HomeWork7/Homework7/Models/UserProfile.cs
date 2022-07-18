using System.ComponentModel.DataAnnotations;
using Homework7.ErrorMessages;
using Homework7.Models.ForTests;

namespace Homework7.Models;

public enum Sex : byte
{
    Male,
    Female
};

public class UserProfile : BaseModel
{
    [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"{nameof(FirstName)} {Messages.MaxLengthMessage}")]
    [Display(Name = "Имя")]
    public override string FirstName { get; set; } = null!;

    [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"{nameof(LastName)} {Messages.MaxLengthMessage}")]
    [Display(Name = "Фамилия")]
    public override string LastName { get; set; } = null!;

    [Required(ErrorMessage = Messages.RequiredMessage)] 
    [MaxLength(30, ErrorMessage = $"{nameof(MiddleName)} {Messages.MaxLengthMessage}")]
    [Display(Name = "Отчество")]
    public override string? MiddleName { get; set; }
    
    [Range(10, 100, ErrorMessage = $"{nameof(Age)} {Messages.RangeMessage}")]
    [Display(Name = "Возраст")]
    public override int Age { get; set; }
        
    [Display(Name = "Пол")]
    public override Sex Sex { get; set; }
} 