using AutoMapper;
using CrossCutting.Exception.v1;
using Domain.Entities.v1.User;
using Domain.Interfaces.v1.User;
using MediatR;

namespace Domain.Commands.v1.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<UserEntity>(request);

                entity.CreatePasswordHash();

                var userExists = await _userRepository.ExistsUser(entity.Email);

                if (userExists) throw new UserExistsException("Email já existente.");

                await _userRepository.AddAsync(entity);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
