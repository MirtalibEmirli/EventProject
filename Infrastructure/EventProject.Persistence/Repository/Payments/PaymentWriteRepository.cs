using EventProject.Application.Repositories.Payments;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Payments;

public class PaymentWriteRepository : WriteRepository<Payment>, IPaymentWriteRepository
{
	public PaymentWriteRepository(AppDbContext context) : base(context)
	{
	}
}
