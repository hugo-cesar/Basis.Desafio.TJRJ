using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;

public class AuthorDto
{
    public AuthorDto(Author? author)
    {
        if (author is not null)
        {
            Id = author.Id;
            Name = author.Name;
        }
    }

    public int Id { get; set; }
    public string? Name { get; set; }
}