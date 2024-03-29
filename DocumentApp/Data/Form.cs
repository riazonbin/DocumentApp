﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Data
{
    public class Form
    {
        public Form()
        {
            IsApproved = false;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public List<FormField> FormFields { get; set; } = new List<FormField>();

        public bool IsApproved;
    }
}
