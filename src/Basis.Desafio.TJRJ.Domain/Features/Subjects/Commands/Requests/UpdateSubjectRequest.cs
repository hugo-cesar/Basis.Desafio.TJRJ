using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using MediatR;
using System.Text.Json.Serialization;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;

public class UpdateSubjectRequest : IRequest<SubjectDto?>
{
    [JsonIgnore]
    public int Id { get; private set; }
    public string? Description { get; set; }
    public void SetId(int id) => Id = id;
}