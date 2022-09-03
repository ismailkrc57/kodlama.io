using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProgramingLanguage : Entity
{
    public string Name { get; set; }

    public ProgramingLanguage()
    {
    }


    public ProgramingLanguage(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}