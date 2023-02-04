using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ApiDTOs
{
    public class TeamDTO
    {

        public class TeamMember
        {
            public string id { get; set; }
            public string username { get; set; }
            //public Perfs perfs { get; set; }
            public long createdAt { get; set; }
            //public Profile profile { get; set; }
            public long seenAt { get; set; }
            //public Playtime playTime { get; set; }
            public string url { get; set; }
            public long joinedTeamAt { get; set; }
        }

        public class Perfs
        {
            public Chess960 chess960 { get; set; }
            public Storm storm { get; set; }
            public Antichess antichess { get; set; }
            public Atomic atomic { get; set; }
            public Racingkings racingKings { get; set; }
            public Racer racer { get; set; }
            public Ultrabullet ultraBullet { get; set; }
            public Blitz blitz { get; set; }
            public Kingofthehill kingOfTheHill { get; set; }
            public Crazyhouse crazyhouse { get; set; }
            public Threecheck threeCheck { get; set; }
            public Bullet bullet { get; set; }
            public Correspondence correspondence { get; set; }
            public Horde horde { get; set; }
            public Puzzle puzzle { get; set; }
            public Classical classical { get; set; }
            public Rapid rapid { get; set; }
        }

        public class Chess960
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Storm
        {
            public int runs { get; set; }
            public int score { get; set; }
        }

        public class Antichess
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Atomic
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Racingkings
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Racer
        {
            public int runs { get; set; }
            public int score { get; set; }
        }

        public class Ultrabullet
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Blitz
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
        }

        public class Kingofthehill
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Crazyhouse
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Threecheck
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Bullet
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
        }

        public class Correspondence
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Horde
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Puzzle
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
        }

        public class Classical
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Rapid
        {
            public int games { get; set; }
            public int rating { get; set; }
            public int rd { get; set; }
            public int prog { get; set; }
            public bool prov { get; set; }
        }

        public class Profile
        {
            public string location { get; set; }
            public string country { get; set; }
            public string firstName { get; set; }
            public int fideRating { get; set; }
            public string bio { get; set; }
            public string lastName { get; set; }
        }

        public class Playtime
        {
            public int total { get; set; }
            public int tv { get; set; }
        }

    }
}
