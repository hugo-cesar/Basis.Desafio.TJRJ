using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using MediatR;
using System.Text.Json.Serialization;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;

public class UpdateAuthorRequest : IRequest<AuthorDto?>
{
    [JsonIgnore]
    public int Id { get; private set; }
    public string? Name { get; set; }

    public void SetId(int id) => Id = id;
}