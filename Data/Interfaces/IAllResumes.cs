using Recruting_Agency_POP.Data.Models;
using System.Collections.Generic;


namespace Recruting_Agency_POP.Data.Interfaces
{
    public interface IAllResumes
    {
        IEnumerable<Resume> AllResumes { get; }

        IEnumerable<Resume> getSelectedResumes { get; }

        Resume getObjectResume(int resumeID);

        void AddNewResume(Resume resume);

        void ChangeIsSelected(Resume resume);
    }
}
