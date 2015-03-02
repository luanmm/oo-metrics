﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OOM.Model
{
    [Table("Field")]
    public partial class Field : IEntity<int>
    {
        public Field()
        {
            ReferencingMethods = new HashSet<Method>();
        }

        [Key]
        public int Id { get; set; }

        public int ClassId { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Display(Name = "Fully qualified identifier"), Required, MaxLength(250)]
        public string FullyQualifiedIdentifier { get; set; }

        [Required]
        public EncapsulationTypes Encapsulation { get; set; }

        [Required]
        public QualificationTypes Qualification { get; set; }

        public virtual ICollection<Method> ReferencingMethods { get; set; }

        public virtual Class Class { get; set; }

        #region Not mapped properties

        [NotMapped]
        public bool IsPrivate { get { return Encapsulation.HasFlag(EncapsulationTypes.Private); } }

        [NotMapped]
        public bool IsProtected { get { return Encapsulation.HasFlag(EncapsulationTypes.Protected); } }

        [NotMapped]
        public bool IsPublic { get { return Encapsulation.HasFlag(EncapsulationTypes.Public); } }

        #endregion
    }
}