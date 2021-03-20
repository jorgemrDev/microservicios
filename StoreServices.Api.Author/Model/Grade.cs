using System;

namespace StoreServices.Api.Autor.Model
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime DateGrade { get; set; }
        public int AuthorBookId { get; set; }
        public AuthorBook AuthorBook { get; set; }
        public string GradeGuid { get; set; }
    }
}
