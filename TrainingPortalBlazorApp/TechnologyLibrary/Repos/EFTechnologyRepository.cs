using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyLibrary.Models;

namespace TechnologyLibrary.Repos
{
    public class EFTechnologyRepository : ITechnologyRepository
    {
        ZelisTechnologyEFDBContext ctx;
        public EFTechnologyRepository()
        {
            ctx = new ZelisTechnologyEFDBContext();
        }
        public async Task DeleteTechnologyAsync(string techId)
        {
            Technology technology = await GetTechnologyAsync(techId);
            try
            {
                ctx.Technologies.Remove(technology);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Technology>> GetAllTechnologiesAsync()
        {
            List<Technology> technologies = await ctx.Technologies.ToListAsync();
            return technologies;
        }

        public async Task<List<Technology>> GetTechnologiesByDurationAsync(int duration)
        {
            List<Technology> technologies = await (from t in ctx.Technologies where t.Duration == duration select t).ToListAsync();
            if (technologies.Count == 0)
                throw new TechnologyException("No technologies with the given duration");
            else
                return technologies;
        }

        public async Task<Technology> GetTechnologyAsync(string techId)
        {
            try
            {
                Technology technology = await (from t in ctx.Technologies where t.TechnologyId == techId select t).FirstAsync();
                return technology;
            }
            catch (Exception ex)
            {
                throw new TechnologyException("No such technology id");
            }
        }

        public async Task<List<Technology>> GetTechnologyByLevelAsync(string level)
        {
            List<Technology> technologies = await (from t in ctx.Technologies where t.Level == level select t).ToListAsync();
            if (technologies.Count == 0)
                throw new TechnologyException("No technologies with the given level");
            else
                return technologies;
        }

        public async Task NewTechnologyAsync(Technology technology)
        {
            try
            {
                await ctx.Technologies.AddAsync(technology);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TechnologyException(ex.Message);
            }
        }

        public async Task UpdateTechnologyAsync(string techId, Technology technology)
        {
            try
            {
                Technology tech2edit = await GetTechnologyAsync(techId);
                tech2edit.TechnologyName = technology.TechnologyName;
                tech2edit.Duration = technology.Duration;
                tech2edit.Level = technology.Level;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TechnologyException("No such Technology with the given Id");
            }
        }
    }
}
