﻿namespace CommonNews.Data.Models.Abstract
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Contracts;

    public abstract class BaseModel<TKey> : IAuditInfo, IDeletableEntity
    {
        [Key]
        public TKey Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? DeletedOn { get; set; }
    }
}
