using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Users.Commands.DeleteUser;
public class DeleteUserCommand:IRequest
{
    public Guid Id { get; set; }
}
public class DeleteUserCommandHandler:
