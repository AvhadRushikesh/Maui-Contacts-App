﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact { ContactId = 1, Name = "John Doe", Email="johnDoe@gmail.com"},
            new Contact { ContactId = 2, Name = "Jane Doe", Email="janeDoe@gmail.com"},
            new Contact { ContactId = 3, Name = "Tom Hanks", Email="tomHanks@gmail.com"},
            new Contact { ContactId = 4, Name = "Frank Liu", Email="frankliu@gmail.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }
    }
}
