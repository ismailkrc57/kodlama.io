using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Features.ProgramingLanguages.Dto;

public class ProgramingLanguageListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}