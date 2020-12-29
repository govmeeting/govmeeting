using GM.Application.Configuration;
//using GM.DatabaseRepositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.Application.AppCore.Entities.Meetings;

namespace GM.Infrastructure.FileDataRepositories
{
    public interface IFileRepository
    {
        public string WorkfolderPath(long meetingId);
        public string WorkfolderPath(Meeting meeting);
        public string SourcefilePath(Meeting meeting);
    }

    public class FileRepository : IFileRepository
    {
        //readonly IMeetingRepository meetingRepository;
        ////readonly IDBOperations dbOperations;
        readonly AppSettings config;


        public FileRepository(
            //IMeetingRepository _meetingRepository,
            IOptions<AppSettings> _config
            ////IDBOperations _dBOperations
            )
        {
            //meetingRepository = _meetingRepository;
            ////dbOperations = _dBOperations;
            config = _config.Value;
        }

        public string WorkfolderPath(long meetingId)
        {
            //return Path.Combine(config.DatafilesPath, "PROCESSING", meetingRepository.GetLongName(meetingId));
            return "";
        }

        public string WorkfolderPath(Meeting meeting)
        {
            ////string workfolderName = dbOperations.GetWorkFolderName(meeting);
            string workfolderName = "fjkfjklajfkljsajakjkj";  /// TODO - FIX
            return Path.Combine(config.DatafilesPath,workfolderName);
        }

        public string SourcefilePath(Meeting meeting)
        {
            return Path.Combine(WorkfolderPath(meeting), meeting.SourceFilename);
        }

    }
}
