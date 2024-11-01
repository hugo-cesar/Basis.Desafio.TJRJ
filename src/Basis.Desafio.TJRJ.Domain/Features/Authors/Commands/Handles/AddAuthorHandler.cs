using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Handles;

public class AddSubjectHandler : IRequestHandler<AddAuthorRequest, AuthorDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddSubjectHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthorDto> Handle(AddAuthorRequest request, CancellationToken cancellationToken)
    {
        var author = new Author { Name = request.Name };

        await _authorRepository.AddAsync(author, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthorDto(author);
    }
}