using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;

public class SubjectDto
{
    public SubjectDto(Subject? subject)
    {
        if (subject is not null)
        {
            Id = subject.Id;
            Description = subject.Description;
        }
    }

    public int Id { get; set; }
    public string? Description { get; set; }
}