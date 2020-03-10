using OnlineMovieTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTicket.BL
{
    public class MovieBL
    {
        public void DeleteBl(int id)
        {
            MovieRepository.DeleteMovie(id);
        } 
    }
}
