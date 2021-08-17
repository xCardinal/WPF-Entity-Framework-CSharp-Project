namespace Data
{
    public class MovieDetails
    {
        //PK
        public int MovieDetailsID { get; set; }

        public int MovieID { get; set; }

        public string CategoryName { get; set; }

        //Possible List of actors && actresses
        //public string[] listOfActors { get; set; }

        //FK
        public virtual Movie Movie { get; set; }

    }
}
