using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary.Models;

namespace TrainerLibrary.Repos
{
    public class EFTrainerRepository : ITrainerRepository
    {
        ZelisTrainerEFDBContext ctx;
        public EFTrainerRepository()
        {
            ctx = new ZelisTrainerEFDBContext();
        }
        public async Task DeleteTrainerAsync(string trainerId)
        {
            Trainer trainer = await GetTrainerAsync(trainerId);
            try
            {
                ctx.Trainers.Remove(trainer);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainerException(ex.Message);
            }
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            List<Trainer> trainers = await (from t in ctx.Trainers select t).ToListAsync();
            return trainers;
        }

        public async Task<Trainer> GetTrainerAsync(string trainerId)
        {
            try
            {
                Trainer trainer = await (from t in ctx.Trainers where t.TrainerId == trainerId select t).FirstAsync();
                return trainer;
            }
            catch (Exception ex)
            {
                throw new TrainerException("No such Trainer with the given Id");
            }
        }

        public async Task<List<Trainer>> GetTrainerByTypeAsync(string type)
        {
            List<Trainer> trainers = await (from t in ctx.Trainers where t.TrainerType == type select t).ToListAsync();
            if (trainers.Count == 0)
                throw new TrainerException("No trainers with the given type");
            else
                return trainers;
        }

        public async Task NewTrainerAsync(Trainer trainer)
        {
            try
            {
                await ctx.Trainers.AddAsync(trainer);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainerException(ex.Message);
            }
        }

        public async Task UpdateTrainerAsync(string trainerId, Trainer trainer)
        {
            try
            {
                Trainer trainer2edit = await GetTrainerAsync(trainerId);
                trainer2edit.TrainerEmail = trainer.TrainerEmail;
                trainer2edit.TrainerPhoneNo = trainer.TrainerPhoneNo;
                trainer2edit.TrainerName = trainer.TrainerName;
                trainer2edit.TrainerType = trainer.TrainerType;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainerException("No such Trainer Id");
            }
        }
    }
}
