
using EventProject.Application.Repositories.Payments;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Payments;

public class PaymentReadRepository : ReadRepository<Payment>, IPaymentReadRepository
{
	public PaymentReadRepository(AppDbContext context) : base(context)
	{
	}
}
