using DevStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStudio.WebAppBusinessLayer
{
    //Provides business logic and access to web app data access layer for web app ui layer
    public class HomeService
    {
        private ApplicationDbContext Context = ApplicationDbContext.Create();

        //return all people in the database
        public IEnumerable<Person> getPeople()
        {
            return Context.People.Where(x => x != null);
        }

        //return all community groups in the database
        public IEnumerable<CommunityGroup> getCommunityGroups()
        {
            return Context.CommunityGroups.Where(x => x != null);
        }

        //return all requests in the database
        public IEnumerable<Request> getRequestsByDate()
        {
            return Context.Requests.Where(x => x != null).OrderBy(x => x.RequestDate);
        }

        //return all requests in the database
        public IEnumerable<Request> getRequestsByDateDescending()
        {
            return Context.Requests.Where(x => x != null).OrderByDescending(x => x.RequestDate);
        }

        //handle Community Group
        public IEnumerable<IndexViewModels> getAllSubmissions()
        {
            List<IndexViewModels> submissions = new List<IndexViewModels>();

            foreach (Request r in this.getRequestsByDate().ToList())
            {
                var indexViewModel = new IndexViewModels();
                var person = this.getPeople().Where(x => x.ID == r.Person.ID);
                var group = this.getCommunityGroups().Where(x => x.ID == r.Person.CommunityGroup.ID);

                indexViewModel.FirstName = person.Single().FirstName;
                indexViewModel.LastName = person.Single().LastName;
                indexViewModel.Email = person.Single().Email;
                indexViewModel.PhoneNumber = person.Single().PhoneNumber;
                indexViewModel.GroupName = group.Single().GroupName;
                indexViewModel.Url = group.Single().Url;
                indexViewModel.RequestDescription = r.RequestDescription;
                indexViewModel.RequestTimestamp = r.RequestDate;
                indexViewModel.RequestNotes = r.RequestNotes;
                indexViewModel.RequestStatus = r.RequestStatus;

                submissions.Add(indexViewModel);
            }

            return submissions;
        }

        public IEnumerable<IndexViewModels> getSubmissionsByPerson(string name)
        {
            List<IndexViewModels> submissions = new List<IndexViewModels>();

            foreach (Request r in this.getRequestsByDateDescending().ToList())
            {
                var indexViewModel = new IndexViewModels();
                var person = this.getPeople().Where(x => x.ID == r.Person.ID);
                var group = this.getCommunityGroups().Where(x => x.ID == r.Person.CommunityGroup.ID);

                if (object.Equals(r.Person.FirstName, name))
                {
                    indexViewModel.FirstName = person.Single().FirstName;
                    indexViewModel.LastName = person.Single().LastName;
                    indexViewModel.Email = person.Single().Email;
                    indexViewModel.PhoneNumber = person.Single().PhoneNumber;
                    indexViewModel.GroupName = group.Single().GroupName;
                    indexViewModel.Url = group.Single().Url;
                    indexViewModel.RequestDescription = r.RequestDescription;
                    indexViewModel.RequestTimestamp = r.RequestDate;
                    indexViewModel.RequestNotes = r.RequestNotes;
                    indexViewModel.RequestStatus = r.RequestStatus;

                    submissions.Add(indexViewModel);
                }
            }

            return submissions;
        }
    }
}