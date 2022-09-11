using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProgramingLanguage : Entity
{
    public ProgramingLanguage()
    {
    }


    public ProgramingLanguage(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }
    public ICollection<Technology> Technologies { get; set; }
}