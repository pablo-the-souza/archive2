using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPolicyRepository
    {
        Task<Policy> GetPolicyByIdAsync(int id);
        Task<IReadOnlyList<Policy>> GetPoliciesAsync();
        Task<Policy> PostPolicy(Policy policy);
        Task<Policy> DeletePolicy(int id);
        Task<Policy> PutPolicy(Policy policy);
    }
}