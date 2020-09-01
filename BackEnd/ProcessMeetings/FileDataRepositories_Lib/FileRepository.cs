using GM.Configuration;
using GM.DatabaseRepositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GM.FileDataRepositories
{
    public interface IFileRepository
    {
        public string WorkFolderPath(long meetingId);
        public string SourceFilePath(long meetingId);
    }

    public class FileRepository : IFileRepository
    {
        readonly IMeetingRepository meetingRepository;
        readonly AppSettings config;


        public FileRepository(
            IMeetingRepository _meetingRepository,
            IOptions<AppSettings> _config
            )
        {
            meetingRepository = _meetingRepository;
            config = _config.Value;
        }

        public string WorkFolderPath(long meetingId)
        {
            return Path.Combine(config.DatafilesPath, "PROCESSING", meetingRepository.GetLongName(meetingId));
        }

        public string SourceFilePath(long meetingId)
        {
            return Path.Combine(config.DatafilesPath, "RECEIVED", meetingRepository.GetSourceFilename(meetingId));
        }

    }
}
