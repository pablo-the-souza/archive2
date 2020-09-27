using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBoxRepository
    {
        Task<Box> GetBoxByIdAsync(int id);
        Task<IReadOnlyList<Box>> GetBoxesAsync();
        Task<Box> PostBox(Box box);
        Task<Box> DeleteBox(int id);
        Task<Box> PutBox(Box box);
    }
}