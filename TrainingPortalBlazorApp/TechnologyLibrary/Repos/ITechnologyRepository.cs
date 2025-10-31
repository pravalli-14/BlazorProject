using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyLibrary.Models;

namespace TechnologyLibrary.Repos
{
    public interface ITechnologyRepository
    {
        Task NewTechnologyAsync(Technology technology);
        Task UpdateTechnologyAsync(string techId, Technology technology);
        Task DeleteTechnologyAsync(string techId);
        Task<Technology> GetTechnologyAsync(string techId);
        Task<List<Technology>> GetTechnologyByLevelAsync(string level);
        Task<List<Technology>> GetTechnologiesByDurationAsync(int duration);
        Task<List<Technology>> GetAllTechnologiesAsync();


    }
}
