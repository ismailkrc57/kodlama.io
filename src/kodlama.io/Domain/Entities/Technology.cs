using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Technology : Entity
{
    public string Name { get; set; }
    public int ProgramingLanguageId { get; set; }
    public ProgramingLanguage? ProgramingLanguage { get; set; }

    public Technology()
    {
    }

    public Technology(int id, string name, int programingLanguageId) : base(id)
    {
        Name = name;
        ProgramingLanguageId = programingLanguageId;
    }
}