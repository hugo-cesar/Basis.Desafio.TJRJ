using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Handles;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorRequest, AuthorDto?>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuthorHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthorDto?> Handle(UpdateAuthorRequest request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id, cancellationToken);

        if (author is null) return null;

        author.Name = request.Name;
        await _unitOfWork.SaveChangesAsync();

        return new AuthorDto(author);
    }
}