namespace Domain.Commands.v1.User.Create
{
    using AutoMapper;
    using Domain.Entities.v1.User;
    using Domain.Interfaces.v1.User;
    using MediatR;
    using System.Security.Cryptography;
    using System.Text;

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
                var entity = _mapper.Map<User>(request);
                entity.CreateHash();

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
