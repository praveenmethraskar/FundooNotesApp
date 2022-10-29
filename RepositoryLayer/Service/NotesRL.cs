﻿using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NotesRL : INotesRL
    {

        private readonly FundooContext fundooContext;
        private readonly IConfiguration iconfiguration;

        public NotesRL(FundooContext fundooContext, IConfiguration iconfiguration)
        {
            this.fundooContext = fundooContext;
            this.iconfiguration=iconfiguration;
        }

        public NotesEntity createNotes(NotesModel notesModel, long userId)
        {
            try
            {
                NotesEntity notesEntityobj = new NotesEntity();
                var result = fundooContext.NotesTable.Where(x => x.UserId==userId);
                if(result != null)
                {

                notesEntityobj.UserId = userId;
                notesEntityobj.title = notesModel.title;
                notesEntityobj.Desciption = notesModel.Desciption;
                notesEntityobj.remainder = notesModel.remainder;
                notesEntityobj.color = notesModel.color;
                notesEntityobj.image = notesModel.image;
                notesEntityobj.archive = notesModel.archive;
                notesEntityobj.pin = notesModel.pin;
                notesEntityobj.trash = notesModel.trash;
                notesEntityobj.created = notesModel.created;
                notesEntityobj.edited = notesModel.edited;

                fundooContext.NotesTable.Add(notesEntityobj);
                fundooContext.SaveChanges();
                    return notesEntityobj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<NotesEntity> retrieveNotes(long userId, long noteId)
        {
            try
            {
                var result = fundooContext.NotesTable.Where(x => x.noteid == noteId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotesId(long noteId)
        {
            try
            {
                NotesEntity result = fundooContext.NotesTable.FirstOrDefault(x => x.noteid == noteId);

                //var result = fundooContext.NotesTable.Where(x => x.noteid == noteId);
                

                if (result != null)
                {
                    fundooContext.NotesTable.Remove(result);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}